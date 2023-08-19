using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PriconneReTLInstaller.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InstallerFunctions;
using HelperFunctions;
using LoggerFunctions;

namespace PriconneReTLInstaller
{
    public partial class MainForm : Form
    {
        private Logger logger;
        private string priconnePath;
        private string githubAPI = Properties.Settings.Default.githubApi;
        private string latestVersion;
        private string assetLink;
        private string localVersion;
        private string tempFile;
        // PrivateFontCollection priconnefont = new PrivateFontCollection();
        private bool mouseDown;
        private Point lastLocation;

        Helper helper = new Helper();
        Installer installer = new Installer();

        public MainForm()
        {
            InitializeComponent();

            installer.Log += OnLog;
            installer.ErrorLog += OnErrorLog;
            installer.DisableStart += OnDisableStart;

            Icon = Resources.jewel;
            helper.PriconneFont();
            helper.SetFontForAllControls(Controls);

            logger = new Logger("ReTLInstaller.log", outputTextBox, toolStripStatusLabel1);
            logger.StartSession();

            this.Height = 480;

            priconnePath = installer.GetGamePath();
            // priconnePath = "C:\\Test"; // -- set fixed path for testing purposes

            priconnePathLinkLabel.Text = priconnePath == null ? "ERROR!" : priconnePath;

            (latestVersion, assetLink) = GetLatestRelease();
            UpdateUI();

            tempFile = Path.GetTempFileName();

        }

        private void OnLog(string message, string color)
        { 
            logger.Log(message, color); 
        }

        private void OnErrorLog(string message)
        {
            logger.Error(message);
        }

        public void OnDisableStart()
        {
            startButton.Enabled = false;
            startButton.BackgroundImage = Resources.start_disabled;
        }

        public static void DisableStartButton(Button startButton)
        {
            startButton.Enabled = false;
            startButton.BackgroundImage = Resources.start_disabled;
        }

        // Functions
        private void UpdateUI()
        {
            localVersion = GetLocalVersion();
            labelCurrentVersion.Text = "Current (Local) Version: " + localVersion;

            newPictureBox.Visible = localVersion == latestVersion ? false : true;

            if (localVersion == "None" || localVersion == "Invalid")
            {
                forceRedownloadCheckBox.Enabled = false;
                uninstallCheckBox.Enabled = false;
            }
            else
            {
                uninstallCheckBox.Enabled = true;
                forceRedownloadCheckBox.Enabled = true;
            }

            removeConfigCheckBox.Enabled = uninstallCheckBox.Checked ? true : false;

            UpdateModeDescription();
        }

        private void UpdateModeDescription()
        {
            if (forceRedownloadCheckBox.Checked)
            {
                modeLabel.Text = Settings.Default.fredownloadMode;
                modeDescritpionLabel.Text = Settings.Default.fredownloadModeDescription;
                return;
            }

            if (uninstallCheckBox.Checked)
            {
                string config = removeConfigCheckBox.Checked ? Settings.Default.deleteConfigText + Environment.NewLine : Settings.Default.keepConfigText + Environment.NewLine;
                string ignored = removeIgnoredCheckBox.Checked ? Settings.Default.deleteIgnoredText + Environment.NewLine : Settings.Default.keepIgnoredText + Environment.NewLine;
                string interops = removeInteropsCheckBox.Checked ? Settings.Default.deleteInteropsText : Settings.Default.keepInteropsText;

                modeLabel.Text = Settings.Default.uninstallMode;
                modeDescritpionLabel.Text = Settings.Default.uninstallModeDescription + Environment.NewLine + config + ignored + interops;
                return;
            }

            switch (priconnePath)
            {
                case null:
                case "Not found!":
                case "Error!":
                    modeLabel.Text = Settings.Default.disabledMode;
                    modeDescritpionLabel.Text = Settings.Default.disabledModeDescription;
                    return;

            }

            if (localVersion == "None" || localVersion == "Invalid")
            {
                modeLabel.Text = Settings.Default.installMode;
                modeDescritpionLabel.Text = Settings.Default.installModeDescription;
                return;
            }

            modeLabel.Text = Settings.Default.updateMode;
            modeDescritpionLabel.Text = Settings.Default.updateModeDescription;
            return;
        }

        private string GetGamePath()
        {
            try
            {
                string cfgFileContent = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "dmmgameplayer5", "dmmgame.cnf"));
                dynamic cfgJson = JsonConvert.DeserializeObject(cfgFileContent);

                if (cfgJson != null && cfgJson.contents != null)
                {
                    foreach (var content in cfgJson.contents)
                    {
                        if (content.productId == "priconner")
                        {
                            string priconnePath = content.detail.path;
                            logger.Log("Found Princess Connect Re:Dive in " + priconnePath, "info");
                            return priconnePath;
                        }
                    }
                }

                logger.Error("Cannot find the game path! Did you install Princess Connect Re:Dive from DMMGamePlayer?");
                startButton.Enabled = false;
                startButton.BackgroundImage = Resources.start_disabled;
                return "Not found!";
            }
            catch (FileNotFoundException)
            {
                logger.Error("Cannot find the DMMGamePlayer config file! Do you have DMMGamePlayer installed?");
                startButton.Enabled = false;
                startButton.BackgroundImage = Resources.start_disabled;
                return null;
            }
            catch (Exception ex)
            {
                logger.Error("Error getting game path: " + ex.Message);
                startButton.Enabled = false;
                startButton.BackgroundImage = Resources.start_disabled;
                return "ERROR!";
            }
        }

        private string GetLocalVersion()
        {
            try
            {
                if (priconnePath == null || priconnePath == "Not found!")
                {
                    // startButton.Enabled = false;
                    return "Unable to determine!";
                }

                string versionFilePath = Path.Combine(priconnePath, "BepInEx", "Translation", "en", "Text", "Version.txt");

                if (!File.Exists(versionFilePath))
                {
                    // startButton.Enabled = false;
                    return "None";
                }
                string rawVersionFile = File.ReadAllText(versionFilePath);
                string localVersion = System.Text.RegularExpressions.Regex.Match(rawVersionFile, @"\d{8}[a-z]?").Value;

                if (localVersion == "")
                {
                    // startButton.Enabled = false;
                    return "Invalid";

                }

                return localVersion;

            }
            catch (Exception ex)
            {
                logger.Error("Error getting local version: " + ex.Message);
                return "ERROR!";
            }
        }

        private (string, string) GetLatestRelease()
        {
            try
            {
                string releaseUrl = githubAPI + "/releases/latest";
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "PriconneTLUpdater");
                    string response = client.DownloadString(releaseUrl);
                    dynamic releaseJson = JsonConvert.DeserializeObject(response);
                    string version = releaseJson.tag_name;
                    string assetsLink = releaseJson.assets[0].browser_download_url;
                    latestReleaseLinkLabel.Text = version;
                    return (version, assetsLink);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error getting latest release: " + ex.Message);
                latestReleaseLinkLabel.Text = "ERROR!";
                return (null, null);
            }
        }

        private async Task<string[]> ProcessTree(string releaseTag)
        {
            string[] ignoreFiles = SetIgnoreFiles(addconfig: true);
            List<string> filePathsList = new List<string>();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("YourAppName");

                string treeUrl = $"{Settings.Default.githubApi}/git/trees/{releaseTag}?recursive=1";

                HttpResponseMessage response = await client.GetAsync(treeUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    dynamic treeJson = JObject.Parse(responseBody);

                    foreach (var item in treeJson.tree)
                    {
                        string fileType = item.type;
                        string filePath = item.path;

                        if (fileType == "blob" && filePath.StartsWith("src/"))
                        {
                            string trimmedPath = filePath.Substring("src/".Length);
                            if (!ignoreFiles.Contains(trimmedPath))
                            {
                                filePathsList.Add(trimmedPath);
                                Console.WriteLine($"File in 'src' Path: {trimmedPath}");
                            }
                            // filePathsList.Add(trimmedPath);
                            // Console.WriteLine($"File in 'src' Path: {trimmedPath}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to fetch tree for tag '{releaseTag}'. Status code: {response.StatusCode}");
                    logger.Error($"Failed to fetch tree for tag '{releaseTag}'. Status code: {response.StatusCode}");
                    return null;
                }

                return filePathsList.ToArray();
            }
        }

        private async Task GetTLMod(string tempFile, System.Windows.Forms.ToolStripProgressBar progressBar)
        {
            try
            {
                outputTextBox.Invoke((Action)(() =>
                {
                    logger.Log("Downloading compressed patch files...", "info", true);
                }));

                progressBar.Minimum = 0;
                progressBar.Maximum = 100;

                using (HttpClient client = new HttpClient())
                {
                    using (var response = await client.GetAsync(assetLink, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        long? totalBytesResponse = response.Content.Headers.ContentLength;
                        long totalBytes = totalBytesResponse ?? -1;

                        using (var contentStream = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = new FileStream(tempFile, FileMode.Create, FileAccess.Write))
                        {
                            var buffer = new byte[4096];
                            long downloadedBytes = 0;
                            int bytesRead;

                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);

                                downloadedBytes += bytesRead;

                                double progressPercentage = (double)downloadedBytes / totalBytes * 100;
                                progressBar.GetCurrentParent().Invoke((Action)(() => progressBar.Value = (int)progressPercentage));
                                toolStripStatusLabel3.Text = $"{Math.Truncate(progressPercentage)}%";
                            }
                        }
                    }
                }

                outputTextBox.Invoke((Action)(() =>
                {
                    logger.Log("Download completed.", "info", true);
                }));
            }
            catch (Exception ex)
            {
                outputTextBox.Invoke((Action)(() =>
                {
                    logger.Error("Error getting patch: " + ex.Message);
                }));
            }
        }

        private async Task ExtractFile(string file)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (var zip = ZipFile.OpenRead(tempFile))
                    {
                        ZipArchiveEntry entry = zip.GetEntry(file);

                        string fileName = entry.FullName;

                        string[] ignoreFiles = SetIgnoreFiles(addconfig: true);

                        if (!ignoreFiles.Contains(fileName))
                        {
                            string destinationPath = Path.Combine(priconnePath, Path.GetDirectoryName(fileName));
                            if (!Directory.Exists(destinationPath))
                                Directory.CreateDirectory(destinationPath);

                            ExtractZipEntry(entry, Path.Combine(priconnePath, fileName));
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                outputTextBox.Invoke((Action)(() =>
                {
                    logger.Error("Error extracting file: " + ex.Message);
                }));
            }
        }

        private async Task ExtractAllFiles()
        {
            try
            {
                await Task.Run(() =>
                {

                    using (var zip = ZipFile.OpenRead(tempFile))
                    {
                        outputTextBox.Invoke((Action)(() =>
                        {
                            logger.Log("Extracting files to game folder...", "add", true);
                            toolStripProgressBar1.Minimum = 0;
                            toolStripProgressBar1.Maximum = zip.Entries.Count;
                        }));

                        // Keep config files if Force Redownload is selected or config files already present
                        string[] ignoreFiles = SetIgnoreFiles(addconfig: forceRedownloadCheckBox.Checked || IsConfigPresent());
                        foreach (var entry in zip.Entries)
                        {
                            string fileName = entry.FullName;

                            outputTextBox.Invoke((Action)(() =>
                            {
                                logger.Log("Extracting: " + entry.FullName, "add");
                                toolStripProgressBar1.PerformStep();
                                double percentage = (double)toolStripProgressBar1.Value / zip.Entries.Count * 100;
                                toolStripStatusLabel3.Text = $"{Math.Truncate(percentage)}%";
                            }));

                            if (!ignoreFiles.Contains(fileName))
                            {
                                string destinationPath = Path.Combine(priconnePath, Path.GetDirectoryName(fileName));
                                if (!Directory.Exists(destinationPath))
                                    Directory.CreateDirectory(destinationPath);

                                ExtractZipEntry(entry, Path.Combine(priconnePath, fileName));
                            }
                        }
                    }

                    File.Delete(tempFile);

                });
            }
            catch (Exception ex)
            {

                outputTextBox.Invoke((Action)(() =>
                {
                    logger.Error("Error extracting all files: " + ex.Message);
                }));
            }
        }

        private void ExtractZipEntry(ZipArchiveEntry entry, string destinationPath)
        {
            try
            {
                if (entry.Name != "")
                {
                    var destinationDirectory = Path.GetDirectoryName(destinationPath);
                    Directory.CreateDirectory(destinationDirectory);

                    entry.ExtractToFile(destinationPath, true);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error extracting file: " + ex.Message);
            }
        }

        private async Task RemovePatchFiles(bool removeConfig, bool removeIgnored, bool removeInterops)
        {
            await Task.Run(() =>
            {
                try
                {
                    string[] configFiles = new string[Settings.Default.configFiles.Count];
                    Settings.Default.configFiles.CopyTo(configFiles, 0);
                    string[] ignoreFiles = new string[Settings.Default.ignoreFiles.Count];
                    Settings.Default.ignoreFiles.CopyTo(ignoreFiles, 0);

                    string[] currentFiles = ProcessTree(localVersion).GetAwaiter().GetResult();

                    if (currentFiles == null)
                    {
                        /*outputTextBox.Invoke((Action)(() =>
                        {
                            logger.Error("Failed to get list of files to remove! Cannot continue.");
                        }));*/
                        throw new Exception("Failed to get list of files to remove! Cannot continue.");
                    }

                    if (removeConfig) currentFiles = currentFiles.Concat(configFiles).ToArray();
                    if (removeIgnored) currentFiles = currentFiles.Concat(ignoreFiles).ToArray();

                    outputTextBox.Invoke((Action)(() =>
                    {
                        logger.Log(uninstallCheckBox.Checked ? "Removing patch files..." : "Removing old patch files...", "remove", true);
                    }));

                    foreach (var file in currentFiles)
                    {
                        string filePath = Path.Combine(priconnePath, file);
                        string directory = Path.GetDirectoryName(filePath);

                        // if (File.Exists(filePath) && (!ignoreFiles.Contains(file)))
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                            // Console.WriteLine($"File deleted: {file}");
                            outputTextBox.Invoke((Action)(() =>
                            {
                                logger.Log($"Removed file: {file}", "remove");
                            }));
                            DeleteEmptyDirectories(directory);
                        }
                    }

                    if (removeInterops)
                    {
                        RemoveInterops();
                    }

                }
                catch (Exception ex)
                {
                    
                    outputTextBox.Invoke((Action)(() =>
                    {
                        logger.Error("Error updating files: " + ex.Message);
                    }));
                }
            });
        }

        private void DeleteEmptyDirectories(string directoryPath)
        {
            if (!Directory.EnumerateFileSystemEntries(directoryPath).Any())
            {
                Directory.Delete(directoryPath);
                // Console.WriteLine($"Directory deleted: {directoryPath}");
                outputTextBox.Invoke((Action)(() =>
                {
                    logger.Log($"Removed directory: {directoryPath}", "remove");
                }));

                string parentDirectory = Path.GetDirectoryName(directoryPath);
                if (!string.IsNullOrEmpty(parentDirectory))
                {
                    DeleteEmptyDirectories(parentDirectory);
                }
            }
        }

        private void RemoveInterops()
        {
            try
            {
                string interopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BepInEx");
                if (Directory.Exists(interopPath))
                {
                    Directory.Delete(interopPath, true);
                    outputTextBox.Invoke((Action)(() =>
                    {
                        logger.Log($"Removed interop assemblies from {interopPath}", "remove");
                    }));
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error removing interop assemblies: " + ex.Message);
            }

        }
        /*public void PriconneFont()
        {
            //Select  font from the resources.
            int fontLength = Properties.Resources.Humming.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.Humming;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            priconnefont.AddMemoryFont(data, fontLength);

        }
        private void SetFontForAllControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Check if the control is a ToolStrip
                if (control is ToolStrip toolStrip)
                {
                    SetFontForToolStripItems(toolStrip.Items);
                }
                else
                {
                    control.Font = new Font(priconnefont.Families[0], control.Font.Size, FontStyle.Bold, GraphicsUnit.Point, 1);
                }

                // Check if the control has child controls
                if (control.Controls.Count > 0)
                {
                    // If it has child controls, call SetFontForAllControls recursively
                    SetFontForAllControls(control.Controls);
                }
            }
        }
        private void SetFontForToolStripItems(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                // Check if the item is a ToolStripLabel
                if (item is ToolStripLabel toolStripLabel)
                {
                    toolStripLabel.Font = new Font(priconnefont.Families[0], toolStripLabel.Font.Size, FontStyle.Bold, GraphicsUnit.Point, 1);
                }
                else if (item is ToolStripDropDownItem dropDownItem)
                {
                    // If the item is a drop-down item (e.g., ToolStripDropDownButton, ToolStripMenuItem), handle its subitems recursively
                    SetFontForToolStripItems(dropDownItem.DropDownItems);
                }
            }
        }*/

        private void SetToolTips()
        {
            StringCollection ignoreCollection = Settings.Default.ignoreFiles;
            StringCollection configCollection = Settings.Default.configFiles;

            StringBuilder ignoreList = new StringBuilder();
            foreach (string line in ignoreCollection)
            {
                ignoreList.AppendLine(line);
            }

            StringBuilder configList = new StringBuilder();
            foreach (string line in configCollection)
            {
                configList.AppendLine(line);
            }

            toolTip.SetToolTip(removeConfigCheckBox, $"Removes the following config files also:\n\n{configList}");
            toolTip.SetToolTip(removeIgnoredCheckBox, $"Removes the following ignored patch files also:\n\n{ignoreList}");
        }
        private string[] SetIgnoreFiles(bool addconfig)
        {
            string[] ignoreFiles = new string[Properties.Settings.Default.ignoreFiles.Count];
            Properties.Settings.Default.ignoreFiles.CopyTo(ignoreFiles, 0);

            if (addconfig)
            {
                List<string> ignoreFilesList = new List<string>(ignoreFiles);

                foreach (var configFile in Settings.Default.configFiles)
                {
                    if (File.Exists(Path.Combine(priconnePath, configFile)))
                    {
                        ignoreFilesList.Add(configFile);
                    }
                }

                ignoreFiles = ignoreFilesList.ToArray();
            }

            return ignoreFiles;
        }

        /*private string[] SetIgnoreFiles(bool addconfig)
        {
            string[] ignoreFiles;

            if (addconfig)
            {
                ignoreFiles = new string[Properties.Settings.Default.ignoreFiles.Count + Properties.Settings.Default.configFiles.Count];
                Properties.Settings.Default.ignoreFiles.CopyTo(ignoreFiles, 0);
                Properties.Settings.Default.configFiles.CopyTo(ignoreFiles, 0);

            }
            else
            {
                ignoreFiles = new string[Properties.Settings.Default.ignoreFiles.Count];
                Properties.Settings.Default.ignoreFiles.CopyTo(ignoreFiles, 0);
            }
            return ignoreFiles;
        }*/
        private bool IsConfigPresent()
        {
            bool isConfigPresent = false;
            foreach (var configFile in Properties.Settings.Default.configFiles)
            {
                if (File.Exists(Path.Combine(priconnePath, configFile)))
                {
                    isConfigPresent = true;

                }
            }
            if (isConfigPresent) outputTextBox.Invoke((Action)(() =>
            {
                logger.Log("Found config file(s). Adding them to the list of ignored/excluded files.", "error");
            }));
            return isConfigPresent;
        }

        // Events
        private async void startButton_Click_1(object sender, EventArgs e)
        {
            int versioncompare = localVersion.CompareTo(latestVersion);

            try
            {
                toolStripProgressBar1.Value = 0;
                toolStripStatusLabel3.Text = "";
                outputTextBox.Clear();
                startButton.Enabled = false;
                startButton.BackgroundImage = Resources.start_working;
                logger.Log("Starting process...", "info");

                if (uninstallCheckBox.Checked) // Uninstall
                {
                    // await RemoveMod(removeConfig: removeConfigCheckBox.Checked);
                    await RemovePatchFiles(removeConfig: removeConfigCheckBox.Checked, removeIgnored: removeIgnoredCheckBox.Checked, removeInterops: removeInteropsCheckBox.Checked);
                    logger.Log("Uninstall Complete!", "success", true);
                    UpdateUI();
                    return;
                }

                if (forceRedownloadCheckBox.Checked) // Force Redownload
                {
                    logger.Log("Reinstalling translation patch...", "info", true);
                    // await RemoveMod(removeConfig: false);
                    await RemovePatchFiles(removeConfig: false, removeIgnored: false, removeInterops: true);
                    await GetTLMod(tempFile, toolStripProgressBar1);
                    await ExtractAllFiles();
                    logger.Log("Forced Redownload / Reinstall complete!", "success", true);
                    UpdateUI();
                    return;
                }

                if (versioncompare == 0) // Installed version = Latest version
                {
                    logger.Log("You already have the latest version installed!", "success", true);
                    return;
                }

                if (versioncompare < 0) // Installed version < Latest version
                {
                    try
                    {
                        logger.Log("Updating translation patch...", "info", true);
                        await RemovePatchFiles(removeConfig: false, removeIgnored: false, removeInterops: false);
                        await GetTLMod(tempFile, toolStripProgressBar1);
                        await ExtractAllFiles();
                        logger.Log("Update complete!", "success", true);
                        UpdateUI();
                        return;
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Error updating translation patch: " + ex.Message);
                    }    
                }

                // nothing installed / invalid
                logger.Log("Downloading and installing translation patch...", "info", true);
                await GetTLMod(tempFile, toolStripProgressBar1);
                await ExtractAllFiles();
                logger.Log("Installation complete!", "success", true);
                UpdateUI();


            }
            catch (Exception ex)
            {
                logger.Error("Error completing process: " + ex.Message);
            }

            finally
            {
                startButton.Enabled = true;
                startButton.BackgroundImage = Resources.start_complete;
                forceRedownloadCheckBox.Checked = false;
                uninstallCheckBox.Checked = false;
            }



        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetToolTips();
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }

            catch (IOException)
            {
                DialogResult result = MessageBox.Show("There is currently a file download / extraction process in progress.\nDo you want to exit anyway?", "Exit Application?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

        }

        private void uninstallCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            uninstallCheckBox.Image = uninstallCheckBox.Checked ? Resources.check_checked_24x24_2 : Resources.check_empty_24x24_2;
            forceRedownloadCheckBox.Checked = uninstallCheckBox.Checked ? false : forceRedownloadCheckBox.Checked;
            removeConfigCheckBox.Enabled = uninstallCheckBox.Checked;
            removeIgnoredCheckBox.Enabled = uninstallCheckBox.Checked;
            removeInteropsCheckBox.Enabled = uninstallCheckBox.Checked;
            UpdateModeDescription();
        }

        private void uninstallCheckBox_EnabledChanged(object sender, EventArgs e)
        {
            uninstallCheckBox.Checked = false;
        }

        private void forceRedownloadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            forceRedownloadCheckBox.Image = forceRedownloadCheckBox.Checked ? Resources.check_checked_24x24_2 : Resources.check_empty_24x24_2;
            uninstallCheckBox.Checked = forceRedownloadCheckBox.Checked ? false : uninstallCheckBox.Checked;
            UpdateModeDescription();
        }

        private void forceRedownloadCheckBox_EnabledChanged(object sender, EventArgs e)
        {
            forceRedownloadCheckBox.Checked = false;
        }

        private void removeConfigCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            removeConfigCheckBox.Image = removeConfigCheckBox.Checked ? Resources.check_checked_24x24_2 : Resources.check_empty_24x24_2;
            UpdateModeDescription();

        }

        private void removeConfigCheckBox_EnabledChanged(object sender, EventArgs e)
        {
            removeConfigCheckBox.Checked = false;
        }

        private void showLogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showLogCheckBox.Checked)
            {
                showLogCheckBox.Image = Resources.check_checked_24x24_2;
                this.Height = 750;
            }
            else
            {
                showLogCheckBox.Image = Resources.check_empty_24x24_2;
                this.Height = 480;
            }
        }

        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            exitButton.BackgroundImage = Resources.door_open;
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            exitButton.BackgroundImage = Resources.door_closed;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_MouseEnter(object sender, EventArgs e)
        {
            minimizeButton.BackgroundImage = Resources.arrow_yellow;
        }

        private void minimizeButton_MouseLeave(object sender, EventArgs e)
        {
            minimizeButton.BackgroundImage = Resources.arrow_blue;
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void aboutButton_MouseEnter(object sender, EventArgs e)
        {
            aboutButton.BackgroundImage = Resources.q_bubble;
        }

        private void aboutButton_MouseLeave(object sender, EventArgs e)
        {
            aboutButton.BackgroundImage = Resources.i_bubble;
        }

        private void startButton_MouseEnter(object sender, EventArgs e)
        {
            if (startButton.Enabled) startButton.BackgroundImage = Resources.start_hover;
        }

        private void startButton_MouseLeave(object sender, EventArgs e)
        {
            if (startButton.Enabled) startButton.BackgroundImage = Resources.start_idle;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void priconnePathLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (priconnePath != null)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("explorer.exe");
                startInfo.Arguments = priconnePath;
                Process.Start(startInfo);
            }
        }

        private void latestReleaseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (latestVersion != null) Process.Start("https://github.com/ImaterialC/PriconneRe-TL/releases/latest");
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(aboutButton, new System.Drawing.Point(0, aboutButton.Height));
        }

        private void option1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Settings.Default.helpText, "How to use", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("https://github.com/tynave/PriconneReTL-Installer#readme");
        }

        private void option2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"[PriconneReTL Updater version: {String.Format(System.Windows.Forms.Application.ProductVersion)}]\n" + Settings.Default.aboutText, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void removeIgnoredCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            removeIgnoredCheckBox.Image = removeIgnoredCheckBox.Checked ? Resources.check_checked_24x24_2 : Resources.check_empty_24x24_2;
            UpdateModeDescription();
        }

        private void removeIgnoredCheckBox_EnabledChanged(object sender, EventArgs e)
        {
            removeIgnoredCheckBox.Checked = false;
        }

        private void removeInteropsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            removeInteropsCheckBox.Image = removeInteropsCheckBox.Checked ? Resources.check_checked_24x24_2 : Resources.check_empty_24x24_2;
            UpdateModeDescription();
        }

        private void removeInteropsCheckBox_EnabledChanged(object sender, EventArgs e)
        {
            removeInteropsCheckBox.Checked = false;
        }
    }
    // Extra Classes
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}



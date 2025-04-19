using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using InstallerFunctions;
using LoggerFunctions;
using Newtonsoft.Json;
using PriconneReTLInstaller;
using PriconneReTLInstaller.Properties;

namespace HelperFunctions
{   
    public class Helper
    {
        public event Action<string, string, bool> Log;
        public event Action<string> ErrorLog;

        [DllImport("gdi32.dll")]
        public static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        public void PriconneFont(PrivateFontCollection priconnefont)
        {
            //Select  font from the resources.
            int fontLength = Resources.NunitoBold.Length;

            // create a buffer to read in to
            byte[] fontdata = Resources.NunitoBold;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontdata.Length, IntPtr.Zero, ref cFonts);

            // pass the font to the font collection
            priconnefont.AddMemoryFont(data, fontLength);

            Marshal.FreeCoTaskMem(data);

        }
        public void SetFontForAllControls(PrivateFontCollection priconnefont, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is ToolStrip toolStrip)
                {
                    SetFontForToolStripItems(priconnefont, toolStrip.Items);
                }
                else if (control is RichTextBox richTextBox)
                {
                    richTextBox.Font = new Font(priconnefont.Families[0], richTextBox.Font.Size, richTextBox.Font.Style);
                }
                else if (control.ContextMenuStrip != null)
                {
                    SetFontForContextMenuItems(priconnefont, control.ContextMenuStrip.Items);
                }
                else
                {
                    control.Font = new Font(priconnefont.Families[0], control.Font.Size, control.Font.Style, GraphicsUnit.Point, 1);
                }

                // Check if the control has child controls
                if (control.Controls.Count > 0)
                {
                    // If it has child controls, call SetFontForAllControls recursively
                    SetFontForAllControls(priconnefont, control.Controls);
                }
            }
        }
        public void SetFontForToolStripItems(PrivateFontCollection priconnefont, ToolStripItemCollection items)
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
                    SetFontForToolStripItems(priconnefont, dropDownItem.DropDownItems);
                }
            }
        }
        public void SetFontForContextMenuItems(PrivateFontCollection priconnefont, ToolStripItemCollection contextMenuItems)
        {
            foreach (ToolStripItem item in contextMenuItems)
            {
                // Set font for each ToolStripItem in the context menu
                item.Font = new Font(priconnefont.Families[0], item.Font.Size, item.Font.Style, GraphicsUnit.Point, 1);

                // If the item is a drop-down item (like a sub-menu), handle its items recursively
                if (item is ToolStripDropDownItem dropDownItem)
                {
                    SetFontForContextMenuItems(priconnefont, dropDownItem.DropDownItems);
                }
            }
        }
        public bool isAnyChecked(CheckBox[] checkboxes)
        {
            if (checkboxes != null)
            {
                foreach (CheckBox checkbox in checkboxes) if (checkbox.Checked) return true;
            }
            return false;
        }
        public string[] SetIgnoreFiles(string priconnePath, bool addconfig)
        {
            string[] ignoreFiles = new string[Settings.Default.ignoreFiles.Count];
            Settings.Default.ignoreFiles.CopyTo(ignoreFiles, 0);

            foreach (var item in ignoreFiles)
            {
                Console.WriteLine(item);
            }

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
        public bool IsConfigPresent(string priconnePath)
        {
            bool isConfigPresent = false;
            foreach (var configFile in Settings.Default.configFiles)
            {
                if (File.Exists(Path.Combine(priconnePath, configFile)))
                {
                    isConfigPresent = true;
                }
            }

            if (isConfigPresent) Log?.Invoke("Found config file(s). Adding them to the list of ignored/excluded files.", "error", false);
            return isConfigPresent;
        }
        public void CannotExitNotification(FormClosingEventArgs e, string type)
        {
            MessageBox.Show($"There is currently a {type} process in progress.\nPlease wait for the operation to complete.", "Cannot Exit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = true;
        }
        public DialogResult UninstallReinstallNotification(bool uninstall, bool reinstall, bool removeConfig, bool removeIgnored, StringCollection configFilesSelected, StringCollection configFilesUnselected)
        {
            StringBuilder configFilesSelectedBuilder = new StringBuilder();
            StringBuilder configFilesUnselectedBuilder = new StringBuilder();

            foreach (string item in configFilesSelected) configFilesSelectedBuilder.AppendLine(item);
            foreach (string item in configFilesUnselected) configFilesUnselectedBuilder.AppendLine(item);

            string configFilesSelectedString = configFilesSelectedBuilder.ToString();
            string configFilesUnselectedString = configFilesUnselectedBuilder.ToString();

            string operationType = uninstall ? "uninstall" : "reinstall";
            string ignoreNofitication = $"The files set in the ignore list WILL{(removeIgnored ? "" : " NOT")} BE removed.";
            string noConfigRemove = "The config files WILL NOT BE removed.";
            string configSelectedNotification = $"The following config file(s) WILL BE deleted: {configFilesSelectedString}";
            string configUnselectedNotification = $"The following config file(s) WILL NOT BE deleted: {configFilesUnselectedString}";

            string notificationText = $"Are you sure you want to {operationType} the translation patch?\n\n{ignoreNofitication}";

            if (!removeConfig || configFilesSelectedString.Length == 0) notificationText += $"\n\n{noConfigRemove}";
            else
            {
                if (removeConfig && configFilesSelectedString.Length != 0) notificationText += $"\n\n{configSelectedNotification}";
                if (removeConfig && configFilesUnselectedString.Length != 0) notificationText += $"\n\n{configUnselectedNotification}";
            }

            DialogResult result = MessageBox.Show(notificationText, "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            return result;
        }
        public bool IsGameRunning()
        {
            // Get a list of all running processes with the specified name
            Process[] processes = Process.GetProcessesByName("PrincessConnectReDive");

            // Check if any processes with the given name are running
            return processes.Length > 0;
        }
        public bool IsFastLauncherInstalled()
        {
            try
            {
                string dmmFastLauncherPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DMMGamePlayerFastLauncher");
                string dmmFastLauncherExe = Path.Combine(dmmFastLauncherPath, "DMMGamePlayerFastLauncher.exe");

                if (File.Exists(dmmFastLauncherExe)) return true; else return false;
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error checking DMMGamePlayerFastlauncher: " + ex.Message);
                return false;
            }
        }
        public bool IsFastLauncherShortcutValid()
        {
            string fastLauncherLink = Settings.Default.fastLauncherLink;

            if (!File.Exists(fastLauncherLink))
            {
                MessageBox.Show(Settings.Default.cannotStartDMMFastLauncherError, "Cannot Start Game", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public void LogFastLauncherShortcut()
        {
            string fastLauncherShortcut = Settings.Default.fastLauncherLink;

            if (fastLauncherShortcut == "") Log?.Invoke("DMMGamePlayerFastLauncher link not set!", "info", false);
            else Log?.Invoke("DMMGamePlayerFastLauncher link path: " + fastLauncherShortcut, "info", false);
        }
        public void PopulateLauncherComboBox(ComboBox comboBox)
        {
            
            comboBox.Items.Clear();
            comboBox.Items.Add("DMMGamePlayer");

            if (IsFastLauncherInstalled()) 
            { 
                comboBox.Items.Add("DMMGamePlayerFastLauncher");
                Log?.Invoke("Found DMMGamePlayerFastLauncher!", "info", false);
            } else Log?.Invoke("DMMGamePlayerFastLauncher not installed!", "info", false);
        }
        public void PopulateConfigChecklistbox(CheckedListBox checkedListBox)
        {
            checkedListBox.Items.Clear();
            checkedListBox.Items.AddRange(Settings.Default.configFiles.Cast<object>().ToArray());

            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
            }
        }
        public void CreateAutoUpdaterShortcut(string priconnePath)
        {
            DialogResult messageboxResult = MessageBox.Show("The AutoUpdater is a modified version of the PriconneReTL-Installer, which automatically performs an update and launches the game after with the selected launcher." +
                "\n\nWould you like to create an AutoUpdate shortcut?", "Create shortcut?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (messageboxResult == DialogResult.No) return;

            string currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string executableName = Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string targetPath = Path.Combine(currentDirectory, executableName);

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.FileName = "PriconneReTL-Installer AutoUpdater";
            saveFileDialog.Filter = "Shortcut files (*.lnk)|*.lnk";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var wshShell = new IWshRuntimeLibrary.WshShell();
                string shortcutPath = saveFileDialog.FileName;
                IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(shortcutPath);

                shortcut.TargetPath = targetPath;
                shortcut.Description = "PriconneReTL-Installer AutoUpdater";
                shortcut.WorkingDirectory = currentDirectory;
                shortcut.IconLocation = Path.Combine(priconnePath, "PrincessConnectReDive.exe");
                shortcut.Arguments = "autoupdate";

                shortcut.Save();

                Console.WriteLine("Shortcut created successfully!");

                MessageBox.Show("Shortcut created!\n\nPlease note that the shortcut points to the PriconneReTL-Installer! If you move or remove the installer, you have to recreate the shortcut!", "Shortcut created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Console.WriteLine("Operation canceled by the user.");
            }
        }

        public void CheckForInstallerUpdate(string version, string body, string installerAssetLink, bool versionValid)
        {
            int versioncompare = String.Format(Application.ProductVersion).CompareTo(version);

            if (versionValid && versioncompare < 0)
            {
                SelfUpdateForm SelfUpdateForm = new SelfUpdateForm(version, body, installerAssetLink);
                SelfUpdateForm.ShowDialog();
            }
        }
        public static bool IsFileInSubfolder(string folderPath, string filePath)
        {
            folderPath = Path.GetFullPath(folderPath); // Ensure the folder path is full.
            filePath = Path.GetFullPath(filePath);     // Ensure the file path is full.

            // Check if the file path starts with the folder path.
            return filePath.StartsWith(folderPath, StringComparison.OrdinalIgnoreCase);
        }

        public static (int remaining, DateTime resetTime, TimeSpan timeUntilReset) CheckGithubRateLimit()
        {
            try
            {
                string rateUrl = "https://api.github.com/rate_limit";
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "PriconneReTLInstaller");

                    string response = client.DownloadString(rateUrl);
                    dynamic json = JsonConvert.DeserializeObject(response);

                    int remaining = json.rate.remaining;
                    long resetUnix = json.rate.reset;
                    DateTime resetTime = DateTimeOffset.FromUnixTimeSeconds(resetUnix).ToLocalTime().DateTime;
                    TimeSpan timeUntilReset = resetTime - DateTime.Now;

                    return (remaining, resetTime, timeUntilReset);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking rate limit: {ex.Message}");
                return (-1, DateTime.MinValue, TimeSpan.Zero); // Fallback values on error
            }
        }

        public (bool,string) CompareGameandModloaderVersions(string gameVersion, string modloaderLocalVersion, string modLoaderLatestRelease)
        {
            Version a = new Version(gameVersion);
            Version b = new Version(modloaderLocalVersion);
            Version c = new Version(modLoaderLatestRelease);

            if (a < b && a < c)
            {
                return (true, "Your game version is lower than the modloader version.\nPlease update your game!");
            }
            else if (a > b && a == c)
            {
                return (true, "Your modloader version is outdated.\nPlease update your TL patch!");
            }
            else if (a > b && a > c && b == c)
            {
                return (true, "Your modloader version is the latest available, but still lower than the game version.\nPlease wait for an updated TL patch release with the up-to-date modloader!");
            }

            return (false, null);
        }
        public static StringCollection DeserializeStringCollection(string serializedValue)
        {
            var stringCollection = new StringCollection();
            var serializer = new XmlSerializer(stringCollection.GetType());

            using (var reader = new XmlTextReader(new System.IO.StringReader(serializedValue)))
            {
                if (serializer.CanDeserialize(reader))
                {
                    stringCollection = (StringCollection)serializer.Deserialize(reader);
                }
            }

            return stringCollection;
        }
        public static string GetRelativePath(string fromPath, string toPath)
        {
            fromPath = fromPath.Replace("\\", "/");
            toPath = toPath.Replace("\\", "/");

            if (!toPath.StartsWith(fromPath, StringComparison.OrdinalIgnoreCase))
            {
                // If toPath is not under fromPath, return the full toPath.
                return toPath;
            }

            int fromPathLength = fromPath.Length;
            if (fromPathLength < toPath.Length)
            {
                // Exclude the common portion and the path separator if it exists
                string relativePath = toPath.Substring(fromPathLength).TrimStart('/');
                return relativePath;
            }

            // If fromPath is the same as toPath, return an empty string
            return string.Empty;
        }
        public void ExportSettings(string filePath)
        {
            try
            {
                var userSettings = new UserSettings
                {
                    launchState = Settings.Default.launchState,
                    selectedLauncher = Settings.Default.selectedLauncher,
                    ignoreFiles = Settings.Default.ignoreFiles,
                    fastLauncherLink = Settings.Default.fastLauncherLink,
                    LastKnownVersion = Settings.Default.LastKnownVersion,
                    checkForInstallerUpdates = Settings.Default.checkForInstallerUpdates,
                    showLogChecked = Settings.Default.showLogChecked
                };

                // Serialize user settings to XML
                XmlSerializer serializer = new XmlSerializer(typeof(UserSettings));
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, userSettings);
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public void ImportSettings(string filePath)
        {
            try
            {
                // Deserialize settings from file
                XmlSerializer serializer = new XmlSerializer(typeof(UserSettings));
                using (StreamReader reader = new StreamReader(filePath))
                {
                    var importedSettings = (UserSettings)serializer.Deserialize(reader);

                    // Update application settings with imported settings
                    Settings.Default.launchState = importedSettings.launchState;
                    Settings.Default.selectedLauncher = importedSettings.selectedLauncher;
                    Settings.Default.ignoreFiles = importedSettings.ignoreFiles;
                    Settings.Default.fastLauncherLink = importedSettings.fastLauncherLink;
                    Settings.Default.LastKnownVersion = importedSettings.LastKnownVersion;
                    Settings.Default.checkForInstallerUpdates = importedSettings.checkForInstallerUpdates;
                    Settings.Default.showLogChecked = importedSettings.showLogChecked;

                    // Save changes to application settings
                    Settings.Default.Save();
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}

[Serializable]
public class UserSettings
{
    public bool launchState { get; set; }
    public int selectedLauncher {  get; set; }
    public System.Collections.Specialized.StringCollection ignoreFiles { get; set; }
    public string fastLauncherLink { get; set; }
    public string LastKnownVersion { get; set; }
    public bool checkForInstallerUpdates { get; set; }
    public bool showLogChecked { get; set; }
    
}
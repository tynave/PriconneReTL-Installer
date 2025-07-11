﻿using HelperFunctions;
using LoggerFunctions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PriconneReTLInstaller;
using PriconneReTLInstaller.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace InstallerFunctions
{
    public class Installer
    {
        Helper helper = new Helper();

        private string patchgithubAPI = Settings.Default.patchGithubApi;

        private string assetLink;
        private string priconnePath;
        private bool priconnePathValid;
        private string gameVersion;
        private string localVersion;
        private bool localVersionValid;
        private string latestVersion;
        private bool latestVersionValid;
        private string tempFile = Path.GetTempFileName();
        private bool removeSuccess = true;
        private bool downloadSuccess = true;
        private bool extractSuccess = true;
        private bool removeProgress = false;
        private bool cancelledByUser = false;
        public event Action<double, double> DownloadProgress;
        public event Action<Image> ProgressPictureChange;
        public event Action<string, string, bool> Log;
        public event Action<string> ErrorLog;
        public event Action DisableStart;
        public event Action ProcessStart;
        public event Action ProcessFinish;
        public event Action ProcessError;

        public (string priconnePath, bool priconnePathValid, string gameVersion) GetGamePath()
        {
            try
            {

                //string cfgFileContent = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "dmmgameplayer5", "dmmgame.cnf"));
                string cfgFileContent = File.ReadAllText(Settings.Default.DMMConfigPath);
                dynamic cfgJson = JsonConvert.DeserializeObject(cfgFileContent);

                if (cfgJson != null && cfgJson.contents != null)
                {
                    foreach (var content in cfgJson.contents)
                    {
                        if (content.productId == "priconner")
                        {
                            #if DEBUG
                            priconnePath = "C:\\Test";
                            #else
                            priconnePath = content.detail.path;
                            #endif

                            gameVersion = content.detail.version;

                            Log?.Invoke("Found Princess Connect Re:Dive in " + priconnePath, "info", false);
                            return (priconnePath, priconnePathValid = true, gameVersion);
                        }
                    }
                }
                ErrorLog?.Invoke("Cannot find the game path! Did you install Princess Connect Re:Dive from DMMGamePlayer?");
                DisableStart?.Invoke();
                return (priconnePath = "Not found", priconnePathValid = false, gameVersion = "Not found");
            }
            catch (FileNotFoundException)
            {
                ErrorLog?.Invoke("Cannot find the DMMGamePlayer config file! Do you have DMMGamePlayer installed?");
                DisableStart?.Invoke();
                return (priconnePath = "Not found", priconnePathValid = false, gameVersion = "Not found");
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting game path: " + ex.Message);
                DisableStart?.Invoke();
                return (priconnePath = "ERROR!", priconnePathValid = false, gameVersion = "ERROR!");
            }
        }
        public (string localVersion, bool localVersionValid) GetInstalledPatchVersion()
        {
            try
            {

                if (!priconnePathValid)
                {
                    ErrorLog?.Invoke("Game path not valid, cannot determine installed patch version!");
                    return (localVersion = "N/A", localVersionValid = false);
                }

                string tlVersionFilePath = Path.Combine(priconnePath, "BepInEx", "Translation", "en", "Text", "Version.txt");

                if (!File.Exists(tlVersionFilePath))
                {
                    return (localVersion = "None", localVersionValid = false);
                }
                string rawVersionFile = File.ReadAllText(tlVersionFilePath);
                Match match = Regex.Match(rawVersionFile, @"\d{8}[a-z]?");

                if (match == null || !match.Success)
                {
                    return (localVersion = "Invalid", localVersionValid = false);
                }
                localVersion = match.Value;
                Log?.Invoke($"Found TL patch version {localVersion} installed!", "info", false);
                return (localVersion, localVersionValid = true);

            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting installed patch version: " + ex.Message);
                return (localVersion = "ERROR!", localVersionValid = false);
            }
        }

        public (string, bool) GetInstalledModloaderVersion()
        {
            try
            {

                if (!priconnePathValid)
                {
                    ErrorLog?.Invoke("Game path not valid, cannot determine installed modloader version!");
                    return ("N/A", false);
                }

                string modloaderVersionFilePath = Path.Combine(priconnePath, "BepInEx", "interop", "version");

                if (!File.Exists(modloaderVersionFilePath))
                {
                    return ("None", false);
                }
                string rawVersionFile = File.ReadAllText(modloaderVersionFilePath);
                Match match = Regex.Match(rawVersionFile, @"\b\d{1,2}\.\d{1,2}\.\d{1,2}\b");

                if (match == null || !match.Success)
                {
                    return ("Invalid", false);
                }
                //localVersion = match.Value;
                Log?.Invoke($"Found modloader version {match.Value} installed!", "info", false);
                return (match.Value, true);

            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting installed modloader version: " + ex.Message);
                return ("ERROR!", false);
            }
        }

        public (string latestVersion, bool latestVersionValid, string assetLink) GetLatestPatchRelease(string githubAPI)
        {
            
            try
            {
                string releaseUrl = githubAPI + "/releases/latest";
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "PriconneReTLInstaller");
                    string response = client.DownloadString(releaseUrl);
                    dynamic releaseJson = JsonConvert.DeserializeObject(response);
                    string version = releaseJson.tag_name;
                    assetLink = releaseJson.assets[0].browser_download_url;
                    return (latestVersion = version, latestVersionValid = true, assetLink);
                }
            }
            catch (WebException webEx)
            {
                // Check if the response contains JSON data (which happens in case of API errors)
                if (webEx.Response != null)
                {
                    using (var reader = new StreamReader(webEx.Response.GetResponseStream()))
                    {
                        string errorResponse = reader.ReadToEnd();
                        try
                        {
                            dynamic errorJson = JsonConvert.DeserializeObject(errorResponse);
                            string errorMessage = errorJson.message;
                            ErrorLog?.Invoke("Error getting latest patch release: " + errorMessage);
                        }
                        catch (Exception innerEx)
                        {
                            ErrorLog?.Invoke("Error reading API error message: " + innerEx.Message);
                        }
                    }
                }
                else
                {
                    ErrorLog?.Invoke("Error getting latest patch release: " + webEx.Message);
                }
                return (latestVersion = null, latestVersionValid = false, null);
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting latest patch release: " + ex.Message);
                return (latestVersion = null, latestVersionValid = false, null);
            }
        }

        public (string, string) GetLatestModloaderRelease()
        {
            try
            {
                if (latestVersion == null)
                {
                    ErrorLog?.Invoke("Error getting latest modeloader release: Cannot determine due to missing latest release version!");
                    return (null, null);
                }
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "PriconneReTLInstaller");

                    string refUrl = $"https://api.github.com/repos/ImaterialC/PriconneRe-TL/git/ref/tags/{latestVersion}";
                    string refResponse = client.DownloadString(refUrl);
                    dynamic responseJson = JObject.Parse(refResponse);
                    string commitSha = responseJson["object"]["sha"]?.ToString();

                    string fileUrl = $"https://raw.githubusercontent.com/ImaterialC/PriconneRe-TL/{commitSha}/src/BepInEx/interop/version";
                    string fileVersion = client.DownloadString(fileUrl);

                    return (fileVersion, commitSha.Substring(0,7));
                }
            }
            catch (WebException webEx)
            {
                // Check if the response contains JSON data (which happens in case of API errors)
                if (webEx.Response != null)
                {
                    using (var reader = new StreamReader(webEx.Response.GetResponseStream()))
                    {
                        string errorResponse = reader.ReadToEnd();
                        try
                        {
                            dynamic errorJson = JsonConvert.DeserializeObject(errorResponse);
                            string errorMessage = errorJson.message;
                            ErrorLog?.Invoke("Error getting latest modloader version: " + errorMessage);
                        }
                        catch (Exception innerEx)
                        {
                            ErrorLog?.Invoke("Error reading API error message: " + innerEx.Message);
                        }
                    }
                }
                else
                {
                    ErrorLog?.Invoke("Error getting latest modloader release: " + webEx.Message);
                }

                return (null, null);
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting latest modeloader release: " + ex.Message);
                return (null, null);
            }


        }
        public (string version, string body, string assetLink, bool versionValid) GetLatestInstallerRelease()
        {
            try
            {
                string releaseUrl = "https://api.github.com/repos/tynave/PriconneReTL-Installer/releases/latest";
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "PriconneReTLInstaller");
                    string response = client.DownloadString(releaseUrl);
                    dynamic releaseJson = JsonConvert.DeserializeObject(response);
                    string version = releaseJson.tag_name;
                    string body = releaseJson.body;
                    assetLink = releaseJson.assets[0].browser_download_url;
                    return (version, body, assetLink, true);
                }
            }
            catch (WebException webEx)
            {
                // Check if the response contains JSON data (which happens in case of API errors)
                if (webEx.Response != null)
                {
                    using (var reader = new StreamReader(webEx.Response.GetResponseStream()))
                    {
                        string errorResponse = reader.ReadToEnd();
                        try
                        {
                            dynamic errorJson = JsonConvert.DeserializeObject(errorResponse);
                            string errorMessage = errorJson.message;
                            ErrorLog?.Invoke("Error getting installer release: " + errorMessage);
                        }
                        catch (Exception innerEx)
                        {
                            ErrorLog?.Invoke("Error reading API error message: " + innerEx.Message);
                        }
                    }
                }
                else
                {
                    ErrorLog?.Invoke("Error getting installer release: " + webEx.Message);
                }

                return (null, null, null, false);
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting installer release: " + ex.Message);
                return (null, null, null, false);
            }
        }

        public async Task DownloadPatchFiles(string assetLink, string fileToSave = null)
        {

            try
            {
                Log?.Invoke("Downloading compressed files...", "info", true);
                ProgressPictureChange?.Invoke(Resources.pecorun);

                using (HttpClient client = new HttpClient())
                {
                    using (var response = await client.GetAsync(assetLink, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();

                        long? totalBytesResponse = response.Content.Headers.ContentLength;
                        long totalBytes = totalBytesResponse ?? -1;

                        string fileName = Path.GetFileName(new Uri(assetLink).AbsolutePath);
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                        using (var contentStream = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = new FileStream(fileToSave == null ? tempFile : fileToSave, FileMode.Create, FileAccess.Write))
                        {
                            var buffer = new byte[4096];
                            long downloadedBytes = 0;
                            int bytesRead;

                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);

                                downloadedBytes += bytesRead;
                                DownloadProgress?.Invoke(downloadedBytes, totalBytes);
                            }
                        }
                    }
                }

                Log?.Invoke("Download completed.", "info", true);
                downloadSuccess = true;

            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error downloading files: " + ex.Message);
                ProgressPictureChange?.Invoke(null);
                downloadSuccess = false;
            }
        }
        public async Task ExtractPatchFiles()

        {
            if (!removeSuccess || !downloadSuccess) return;

            try
            {
                int counter = 0;
                using (var zip = ZipFile.OpenRead(tempFile))
                {
                    Log?.Invoke("Extracting files to game folder...", "add", true);
                    ProgressPictureChange?.Invoke(Resources.kokorun);

                    // Keep config files if Reinstall is selected or config files already present
                    string[] ignoreFiles = helper.SetIgnoreFiles(priconnePath, addconfig: helper.IsConfigPresent(priconnePath));

                    foreach (var entry in zip.Entries)
                    {
                        counter++;
                        string fileName = entry.FullName;

                        Log?.Invoke("Extracting: " + entry.FullName, "add", false);
                        DownloadProgress?.Invoke(counter, zip.Entries.Count);
                        //DownloadProgressAutoUpdater?.Invoke(counter, zip.Entries.Count, Resources.kokkorowinnosquarenobg);

                        if (!ignoreFiles.Contains(fileName))
                        {
                            string destinationPath = Path.Combine(priconnePath, Path.GetDirectoryName(fileName));
                            if (!Directory.Exists(destinationPath))
                                Directory.CreateDirectory(destinationPath);

                            await Task.Run(() => ExtractZipEntry(entry, Path.Combine(priconnePath, fileName)));
                        }
                    }
                }
                extractSuccess = true;

            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error extracting all files: " + ex.Message);
                ProgressPictureChange?.Invoke(null);
                extractSuccess = false;
            }
        }
        public void ExtractZipEntry(ZipArchiveEntry entry, string destinationPath)
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
                ErrorLog?.Invoke("Error extracting file: " + ex.Message);
            }
        }
        public async Task<string[]> ProcessTree(string priconnePath, string releaseTag)
        {
            string[] ignoreFiles = helper.SetIgnoreFiles(priconnePath, addconfig: true);
            List<string> filePathsList = new List<string>();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("PriconneReTLInstaller");

                string treeUrl = $"{Settings.Default.patchGithubApi}/git/trees/{releaseTag}?recursive=1";

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
                                // Console.WriteLine($"File in 'src' Path: {trimmedPath}");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to fetch tree for tag '{releaseTag}'. Status code: {response.StatusCode}");
                    ErrorLog?.Invoke($"Failed to fetch tree for tag '{releaseTag}'. Status code: {response.StatusCode}");
                    return null;
                }

                return filePathsList.ToArray();
            }
        }
        public async Task RemovePatchFiles(bool uninstall, bool removeConfig, StringCollection configList, bool removeIgnored)

        {
            if (downloadSuccess == false) 
            {
                extractSuccess = false;
                return;
            }


            await Task.Run(() =>
            {
                try
                {
                    removeProgress = true;

                    string[] currentFiles = ProcessTree(priconnePath, localVersion).GetAwaiter().GetResult();

                    if (currentFiles == null)
                    {
                        removeSuccess = false;
                        throw new Exception("Failed to get list of files to remove! Cannot continue.");
                    }

                    Log?.Invoke(uninstall ? "Removing patch files..." : "Removing old patch files...", "remove", true);
                    ProgressPictureChange?.Invoke(Resources.kyarun);

                    int counter = 0;

                    foreach (var file in currentFiles)
                    {
                        counter++;
                        string filePath = Path.Combine(priconnePath, file);
                        string directory = Path.GetDirectoryName(filePath);

                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                            Log?.Invoke($"Removed file: {file}", "remove", false);

                            DeleteEmptyDirectories(directory);

                        }
                        double percentage = ((double)counter / currentFiles.Length) * 100;
                        DownloadProgress?.Invoke(counter, currentFiles.Length);
                        //DownloadProgressAutoUpdater?.Invoke(counter, currentFiles.Length, Resources.kyaruwinnosquarenobg);

                    }

                    if (removeConfig) RemoveConfigOrIgnoredFiles("config", configList);

                    if (removeIgnored) RemoveConfigOrIgnoredFiles("ignored", Settings.Default.ignoreFiles);

                    // if (removeInterops) RemoveInterops();

                    removeSuccess = true;
                    removeProgress = false;

                }
                catch (Exception ex)
                {
                    removeSuccess = false;
                    removeProgress = false;
                    ErrorLog?.Invoke("Error removing files: " + ex.Message);
                    ProgressPictureChange?.Invoke(null);
                }
            });
        }
        private void DeleteEmptyDirectories(string directoryPath)
        {
            if (!Directory.EnumerateFileSystemEntries(directoryPath).Any())
            {
                Directory.Delete(directoryPath);
                Log?.Invoke($"Removed directory: {directoryPath}", "remove", false);

                string parentDirectory = Path.GetDirectoryName(directoryPath);
                if (!string.IsNullOrEmpty(parentDirectory))
                {
                    DeleteEmptyDirectories(parentDirectory);
                }
            }
        }
        private void RemoveConfigOrIgnoredFiles(string type, StringCollection collection)
        {
            try
            {
                Log?.Invoke($"Removing {type} files...", "remove", false);
                foreach (var file in collection)
                {
                    string fullPath = Path.Combine(priconnePath, file);
                    string directory = Path.GetDirectoryName(fullPath);
                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                        Log?.Invoke($"Removed {type} file: {file}", "remove", false);
                        DeleteEmptyDirectories(directory);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke($"Error removing {type} files: " + ex.Message);
                removeSuccess = false;
            }

        }
        private void RemoveInterops() // obsolete, just kept code in case it'll ever be needed again
        {
            try
            {
                string interopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BepInEx");
                if (Directory.Exists(interopPath))
                {
                    Directory.Delete(interopPath, true);
                    Log?.Invoke($"Removed interop assemblies from {interopPath}", "remove", false);
                }
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error removing interop assemblies: " + ex.Message);
                removeSuccess = false;
            }

        }

        public async void ProcessOperation(string assetLink, bool install, bool uninstall, bool reinstall, bool launch, bool removeConfig, CheckedListBox configListBox, bool removeIgnored)
        {
            string processName = null;
            int versioncompare = localVersion.CompareTo(latestVersion);

            StringCollection configFilesSelected = new StringCollection();
            StringCollection configFilesUnSelected = new StringCollection();

            foreach (var item in configListBox.Items)
            {
                int index = configListBox.Items.IndexOf(item);
                if (configListBox.GetItemChecked(index)) configFilesSelected.Add(item.ToString());
                else configFilesUnSelected.Add(item.ToString());
            }

            try
            {

                if (uninstall || reinstall)
                {
                    DialogResult result = helper.UninstallReinstallNotification(uninstall, reinstall, removeConfig, removeIgnored, configFilesSelected, configFilesUnSelected);

                    if (result == DialogResult.No) 
                    {
                        cancelledByUser = true;
                        Log?.Invoke($"Operation cancelled!", "remove", true);
                        return;
                    };
                }

                ProcessStart?.Invoke();

                if (uninstall)
                {
                    processName = "Uninstall";
                    Log?.Invoke("Uninstalling translation patch...", "info", true);
                    await RemovePatchFiles(uninstall: uninstall, removeConfig: removeConfig, configList: configFilesSelected, removeIgnored: removeIgnored);
                    return;
                }

                if (reinstall)
                {
                    processName = "Reinstall";
                    Log?.Invoke("Reinstalling translation patch...", "info", true);
                    await DownloadPatchFiles(assetLink);
                    await RemovePatchFiles(uninstall: uninstall, removeConfig: removeConfig, configList: configFilesSelected, removeIgnored: removeIgnored);
                    await ExtractPatchFiles();
                    return;
                }

                if (install)
                {

                    if (versioncompare < 0)
                    {
                        processName = "Update";
                        Log?.Invoke("Updating translation patch...", "info", true);
                        await DownloadPatchFiles(assetLink);
                        await RemovePatchFiles(uninstall: uninstall, removeConfig: removeConfig, configList: configFilesSelected, removeIgnored: removeIgnored);
                        await ExtractPatchFiles();
                        return;
                    }

                    processName = "Install";
                    Log?.Invoke("Downloading and installing translation patch...", "info", true);
                    await DownloadPatchFiles(assetLink);
                    await ExtractPatchFiles();
                    return;
                }

            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error completing process: " + ex.Message);
            }

            finally
            {
                bool processSuccess = removeSuccess && downloadSuccess && extractSuccess;

                if (processName != null) 
                {
                    if (!processSuccess) ErrorLog?.Invoke($"{processName} failed"); 
                    else Log?.Invoke($"{processName} complete!", "success", true);
                }
                ProcessFinish?.Invoke();

                if (launch && !cancelledByUser)
                {
                    bool result = false;
                    switch (Settings.Default.selectedLauncher)
                    {
                            case 0:
                                result = StartDMMGamePlayer();
                                break;
                            case 1:                
                                result = StartDMMFastLauncher();
                                break;
                            default:
                                break;
                    }

                    if (result)
                    {
                        await Task.Delay(5000);
                        Application.Exit();
                    }

                }
                cancelledByUser = false;
            }
        }
        public async void ProcessAutoUpdateOperation(bool install, string assetLink)
        {
            try
            {
                ProcessStart?.Invoke();

                await DownloadPatchFiles(assetLink);
                if (!install) await RemovePatchFiles(uninstall: false, removeConfig: false, configList: Settings.Default.configFiles, removeIgnored: false);
                await ExtractPatchFiles();
                return;
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error completing process: " + ex.Message);
            }

            finally
            {
                bool processSuccess = removeSuccess && downloadSuccess && extractSuccess;

                if (!processSuccess)
                {
                    ErrorLog?.Invoke(install ? "Install failed!" : "Update failed!");
                    ProcessError?.Invoke();
                }
                else
                {
                    Log?.Invoke(install ? "Install complete!" : "Update complete!", "success", true);
                    ProcessFinish?.Invoke();
                }
            }
        }
        public async void ProcessInstallerUpdateOperation(string installerAssetLink, SaveFileDialog saveFileDialog, Form form)
        {
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedFile = saveFileDialog.FileName;
                Log?.Invoke("Downloading latest PriconneReTLInstaller version..", "info", true);
                await DownloadPatchFiles(installerAssetLink, selectedFile);

                if (downloadSuccess)
                {
                    Log?.Invoke($"New PriconneReTLInstaller version successfully downloaded to: {selectedFile}", "info", false);
                    DialogResult result2 = MessageBox.Show($"New installer version successfully downloaded to:\n{selectedFile}\n\nWould you like to close the application?", "Download successful!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result2 == DialogResult.Yes) Application.Exit();
                    else form.Close();
                }

                else
                {
                    MessageBox.Show("Error downloading the new installer version!\n\nCheck log for details!", "Download failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool StartDMMFastLauncher()
        {
            try
            {
                string dmmFastLauncherPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DMMGamePlayerFastLauncher");
                string dmmFastLauncherExe = Path.Combine(dmmFastLauncherPath, "DMMGamePlayerFastLauncher.exe");
                string fastLauncherLink = Settings.Default.fastLauncherLink;

                if (File.Exists(dmmFastLauncherExe))
                {

                    if (!helper.IsFastLauncherShortcutValid()) {
                        Log?.Invoke("Cannot start game! DMMGamePlayerFastLauncher shortcut invalid!", "error", true);
                        return false; 
                    }

                    Log?.Invoke("Starting game via DMMGamePlayerFastLauncher.", "info", true);
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = fastLauncherLink,
                    };
                    Process.Start(startInfo);
                    return true;
                }
                Log?.Invoke("Cannot start game! DMMGamePlayerFastLauncher not found!", "error", true);
                return false;
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error starting DMMGamePlayerFastLauncher: " + ex.Message);
                return false;
            }
        }
        public bool StartDMMGamePlayer()
        {
            try
            {
                Log?.Invoke("Starting game via DMMGamePlayer.", "info", true);
                Process.Start("dmmgameplayer://play/GCL/priconner/cl/win");
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error starting DMMGamePlayer: " + ex.Message);
                return false;
            }
        }

        public void HandleFormClosing(Form form, FormClosingEventArgs e)
        {
            try
            {
                if (removeProgress)
                {
                    helper.CannotExitNotification(e, "file removal");
                }
                else if (File.Exists(tempFile)) File.Delete(tempFile);

                Settings.Default.Save();
            }
            catch (IOException)
            {
                helper.CannotExitNotification(e, "file download / extraction");
            }
        }

    }
}
﻿using HelperFunctions;
using LoggerFunctions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PriconneReTLInstaller;
using PriconneReTLInstaller.Properties;
using System;
using System.Collections;
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
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstallerFunctions
{
    public class Installer
    {
        Helper helper = new Helper();

        private string patchgithubAPI = Settings.Default.patchGithubApi;

        private string assetLink;
        private string priconnePath;
        private bool priconnePathValid;
        private string localVersion;
        private bool localVersionValid;
        private string latestVersion;
        private bool latestVersionValid;
        private string tempFile = Path.GetTempFileName();
        private bool removeSuccess = true;
        private bool downloadSuccess = true;
        private bool extractSuccess = true;
        private bool removeProgress = false;

        public event Action<double, double> DownloadProgress;
        public event Action<string, string, bool> Log;
        public event Action<string> ErrorLog;
        public event Action DisableStart;
        public event Action ProcessStart;
        public event Action ProcessFinish;

        public (string priconnePath, bool priconnePathValid) GetGamePath()
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
                            priconnePath = content.detail.path;
                            // priconnePath = "C:\\Test"; // -- set fixed path for testing purposes
                            Log?.Invoke("Found Princess Connect Re:Dive in " + priconnePath, "info", false);
                            return (priconnePath, priconnePathValid = true);
                        }
                    }
                }
                ErrorLog?.Invoke("Cannot find the game path! Did you install Princess Connect Re:Dive from DMMGamePlayer?");
                DisableStart?.Invoke();
                return (priconnePath = "Not found", priconnePathValid = false);
            }
            catch (FileNotFoundException)
            {
                ErrorLog?.Invoke("Cannot find the DMMGamePlayer config file! Do you have DMMGamePlayer installed?");
                DisableStart?.Invoke();
                return (priconnePath = "Not found", priconnePathValid = false);
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting game path: " + ex.Message);
                DisableStart?.Invoke();
                return (priconnePath = "ERROR!", priconnePathValid = false);
            }
        }
        public (string localVersion, bool localVersionValid) GetPatchLocalVersion()
        {
            try
            {

                if (!priconnePathValid)
                {
                    return (localVersion = "Unable to determine!", localVersionValid = false);
                }

                string versionFilePath = Path.Combine(priconnePath, "BepInEx", "Translation", "en", "Text", "Version.txt");

                if (!File.Exists(versionFilePath))
                {
                    return (localVersion = "None", localVersionValid = false);
                }
                string rawVersionFile = File.ReadAllText(versionFilePath);
                Match match = Regex.Match(rawVersionFile, @"\d{8}[a-z]?");

                if (match == null || !match.Success)
                {
                    return (localVersion = "Invalid", localVersionValid = false);
                }
                localVersion = match.Value;
                return (localVersion, localVersionValid = true);

            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting local version: " + ex.Message);
                return (localVersion = "ERROR!", localVersionValid = false);
            }
        }

        public (string localVersion, bool localVersionValid) GetAULocalVersion(string priconnePath, string filename)
        {
            string filePath = Path.Combine(priconnePath, "BepInEx", "patchers", "PriconneReTLAutoUpdater", filename);

            if (!File.Exists(filePath))
            {
                return ("None", false);
            }

            string fullVersion = FileVersionInfo.GetVersionInfo(filePath).FileVersion;
            string[] versionParts = fullVersion.Split('.');
            string trimmedVersion = string.Join(".", versionParts.Take(3));
            return (trimmedVersion, true);
        }
        public (string latestVersion, bool latestVersionValid, string assetLink) GetLatestRelease(string githubAPI)
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
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting latest release: " + ex.Message);
                return (latestVersion = null, latestVersionValid = false, null);
            }
        }

        public async Task DownloadFiles(string assetLink)
        {

            try
            {
                Log?.Invoke("Downloading compressed files...", "info", true);

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

                    // Keep config files if Force Redownload is selected or config files already present
                    string[] ignoreFiles = helper.SetIgnoreFiles(priconnePath, addconfig: helper.IsConfigPresent(priconnePath));
                    foreach (var entry in zip.Entries)
                    {
                        counter++;
                        string fileName = entry.FullName;

                        Log?.Invoke("Extracting: " + entry.FullName, "add", false);
                        DownloadProgress?.Invoke(counter, zip.Entries.Count);

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
                extractSuccess = false;
            }
        }

        public async Task ExtractAUFiles()

        {
            if (!removeSuccess || !downloadSuccess) return;

            try
            {
                int counter = 0;
                using (var zip = ZipFile.OpenRead(tempFile))
                {
                    Log?.Invoke("Extracting files to game folder...", "add", true);
                  
                    foreach (var entry in zip.Entries)
                    {
                        counter++;
                        string fileName = entry.FullName;

                        Log?.Invoke("Extracting: " + entry.FullName, "add", false);
                        DownloadProgress?.Invoke(counter, zip.Entries.Count);

                        
                            string destinationPath = Path.Combine(priconnePath, Path.GetDirectoryName(fileName));
                            if (!Directory.Exists(destinationPath))
                                Directory.CreateDirectory(destinationPath);

                            await Task.Run(() => ExtractZipEntry(entry, Path.Combine(priconnePath, fileName)));
                    }
                }
                extractSuccess = true;
                Log?.Invoke("Extraction complete!", "success", true);
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error extracting all files: " + ex.Message);
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

        public async Task RemovePatchFiles(bool uninstall, bool removeConfig, bool removeIgnored, bool removeInterops)

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

                    }

                    if (removeConfig) RemoveConfigOrIgnoredFiles("config", Settings.Default.configFiles);

                    if (removeIgnored) RemoveConfigOrIgnoredFiles("ignored", Settings.Default.ignoreFiles);

                    if (removeInterops) RemoveInterops();

                    removeSuccess = true;
                    removeProgress = false;

                }
                catch (Exception ex)
                {
                    removeSuccess = false;
                    removeProgress = false;
                    ErrorLog?.Invoke("Error removing files: " + ex.Message);
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
        private void RemoveInterops()
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

        public async void ProcessOperation(string assetLink, bool install, bool uninstall, bool reinstall, bool launch, bool removeConfig, bool removeIgnored, bool removeInterops, ComboBox combobox)
        {
            string processName = null;
            int versioncompare = localVersion.CompareTo(latestVersion);

            try
            {
                ProcessStart?.Invoke();

                if (uninstall)
                {
                    processName = "Uninstall";
                    Log?.Invoke("Uninstalling translation patch...", "info", true);
                    await RemovePatchFiles(uninstall: uninstall, removeConfig: removeConfig, removeIgnored: removeIgnored, removeInterops: removeInterops);
                    return;
                }

                if (reinstall)
                {
                    processName = "Reinstall";
                    Log?.Invoke("Reinstalling translation patch...", "info", true);
                    await DownloadFiles(assetLink);
                    await RemovePatchFiles(uninstall: uninstall, removeConfig: removeConfig, removeIgnored: removeIgnored, removeInterops: removeInterops);
                    await ExtractPatchFiles();
                    return;
                }

                if (install)
                {
                    if (versioncompare == 0)
                    {
                        Log?.Invoke("You already have the latest version installed!", "success", true);
                        return;
                    }

                    if (versioncompare < 0)
                    {
                        processName = "Update";
                        Log?.Invoke("Updating translation patch...", "info", true);
                        await DownloadFiles(assetLink);
                        await RemovePatchFiles(uninstall: uninstall, removeConfig: removeConfig, removeIgnored: removeIgnored, removeInterops: removeInterops);
                        await ExtractPatchFiles();
                        return;
                    }

                    processName = "Install";
                    Log?.Invoke("Downloading and installing translation patch...", "info", true);
                    await DownloadFiles(assetLink);
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
                    if (!processSuccess) ErrorLog?.Invoke($"{processName} failed!"); else Log?.Invoke($"{processName} complete!", "success", true);
                }
                ProcessFinish?.Invoke();

                if (launch)
                {
                    bool result = false;
                    switch (combobox.SelectedIndex)
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
            }
        }

        public async void ProcessAuInstallOperation(string auAssetLink, string auAppAssetLink)
        {
            ProcessStart?.Invoke();
            try
            {
                Log?.Invoke("Downloading and installing AutoUpdater...", "info", true);
                await DownloadFiles(auAssetLink);
                await ExtractAUFiles();

                Log?.Invoke("Downloading and installing AutoUpdaterApp...", "info", true);
                await DownloadFiles(auAppAssetLink);
                await ExtractAUFiles();
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error installing AutoUpdater: " + ex.Message);
            }
            finally
            {
                bool processSuccess = removeSuccess && downloadSuccess && extractSuccess;
                if (!processSuccess) ErrorLog?.Invoke($"Installation failed!"); else Log?.Invoke($"Installation complete!", "success", true);
                ProcessFinish?.Invoke();
            }
        }

        public void ProcessAuUninstallOperation()
        {
            ProcessStart?.Invoke();
            Log?.Invoke("Removing AutoUpdater / AutoUpdaterApp...", "remove", true);
            string filePath = Path.Combine(priconnePath, "BepInEx", "patchers", "PriconneReTLAutoUpdater");

            try
            {
                if (Directory.Exists(filePath))
                {
                    Directory.Delete(filePath, true);
                    Log?.Invoke("Uninstall complete!", "success", true);
                    return;
                }
                Log?.Invoke("Nothing to uninstall!", "success", true);
            }

            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error deleting AutoUpdater:" + ex.Message);
            }
            finally
            {
                ProcessFinish?.Invoke();
            }
        }
        private bool StartDMMFastLauncher()
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

                    Log?.Invoke("Starting game via DMMGamePlayerFastLauncher. Closing installer in 5 seconds", "info", true);
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = fastLauncherLink,
                    };
                    Process.Start(startInfo);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error starting DMMGamePlayerFastLauncher: " + ex.Message);
                return false;
            }
        }

        private bool StartDMMGamePlayer()
        {
            try
            {
                Log?.Invoke("Starting game via DMMGamePlayer. Closing installer in 5 seconds.", "info", true);
                Process.Start("dmmgameplayer://play/GCL/priconner/cl/win");
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error starting DMMGamePlayer: " + ex.Message);
                return false;
            }
        }

        public void HandleFormClosing(MainForm form, FormClosingEventArgs e)
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
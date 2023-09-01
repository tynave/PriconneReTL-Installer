using HelperFunctions;
using LoggerFunctions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PriconneReTLInstaller;
using PriconneReTLInstaller.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Specialized;

namespace InstallerFunctions
{
    class Installer
    {
        Helper helper = new Helper();

        private string githubAPI = Settings.Default.githubApi;
        private string assetLink;
        private string priconnePath;
        private bool priconnePathValid;
        private string localVersion;
        private bool localVersionValid;
        private string latestVersion;
        private bool latestVersionValid;
        private bool removeSuccess = true;
        private bool downloadSuccess = true;

        public event Action<double, double> DownloadProgress;
        public event Action<string, string, bool> Log;
        public event Action<string> ErrorLog;
        public event Action DisableStart;

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
                            // priconnePath = content.detail.path;
                            priconnePath = "C:\\Test"; // -- set fixed path for testing purposes
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
        //public (string localVersion, bool localVersionValid ) GetLocalVersion(string priconnePath, bool priconnePathValid)
        public (string localVersion, bool localVersionValid) GetLocalVersion()
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
                localVersion = System.Text.RegularExpressions.Regex.Match(rawVersionFile, @"\d{8}[a-z]?").Value;

                if (localVersion == "")
                {
                    return (localVersion = "Invalid", localVersionValid = false);

                }

                return (localVersion, localVersionValid = true);

            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting local version: " + ex.Message);
                return (localVersion = "ERROR!", localVersionValid = false);
            }
        }
        public (string latestVersion, bool latestVersionValid) GetLatestRelease()
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
                    assetLink = releaseJson.assets[0].browser_download_url;
                    return (latestVersion = version, latestVersionValid = true);
                }
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting latest release: " + ex.Message);
                return (latestVersion = null, latestVersionValid = false);
            }
        }

        public async Task GetTLMod(string tempFile)
        {
            if (removeSuccess == false)
            {
                downloadSuccess = false;
                return;
            }

            try
            {
                /*outputTextBox.Invoke((Action)(() =>
                {
                    logger.Log("Downloading compressed patch files...", "info", true);
                }));*/
                Log?.Invoke("Downloading compressed patch files...", "info", true);

                // progressBar.Minimum = 0;
                // progressBar.Maximum = 100;

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
                ErrorLog?.Invoke("Error getting patch: " + ex.Message);
                downloadSuccess = false;
            }
        }

        //public async Task ExtractAllFiles(string tempFile, string priconnePath)
        public async Task ExtractAllFiles(string tempFile)

        {
            if (!downloadSuccess) return;

            try
            {
                //await Task.Run(() =>
                //{
                int counter = 0;
                using (var zip = ZipFile.OpenRead(tempFile))
                    {
                       Log?.Invoke("Extracting files to game folder...", "add", true);

                    // Keep config files if Force Redownload is selected or config files already present
                    // string[] ignoreFiles = SetIgnoreFiles(addconfig: forceRedownloadCheckBox.Checked || IsConfigPresent());
                    // string[] ignoreFiles = helper.SetIgnoreFiles(priconnePath, addconfig: forceRedownloadCheckBox.Checked || helper.IsConfigPresent(priconnePath));
                    string[] ignoreFiles = helper.SetIgnoreFiles(priconnePath, addconfig: helper.IsConfigPresent(priconnePath));
                    foreach (var entry in zip.Entries)
                        {
                            counter++;
                            string fileName = entry.FullName;

                            Log?.Invoke("Extracting: " + entry.FullName, "add", false);
                            double percentage = ((double)counter / zip.Entries.Count) * 100;
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

                    File.Delete(tempFile);

                //});
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error extracting all files: " + ex.Message);
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
                // logger.Error("Error extracting file: " + ex.Message);
                ErrorLog?.Invoke("Error extracting file: " + ex.Message);
            }
        }

        public async Task<string[]> ProcessTree(string priconnePath, string releaseTag)
        {
            string[] ignoreFiles = helper.SetIgnoreFiles(priconnePath, addconfig: true);
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

        // public async Task RemovePatchFiles(string priconnePath, string localVersion, bool removeConfig, bool removeIgnored, bool removeInterops)
        public async Task RemovePatchFiles(bool removeConfig, bool removeIgnored, bool removeInterops)

        {
            await Task.Run(() =>
            {
                try
                {
                    /*string[] configFiles = new string[Settings.Default.configFiles.Count];
                    Settings.Default.configFiles.CopyTo(configFiles, 0);
                    string[] ignoreFiles = new string[Settings.Default.ignoreFiles.Count];
                    Settings.Default.ignoreFiles.CopyTo(ignoreFiles, 0);*/

                string[] currentFiles = ProcessTree(priconnePath, localVersion).GetAwaiter().GetResult();
                    
                    if (currentFiles == null)
                    {
                        removeSuccess = false;
                        throw new Exception("Failed to get list of files to remove! Cannot continue.");
                    }

                    // if (removeConfig) currentFiles = currentFiles.Concat(configFiles).ToArray();
                    // if (removeIgnored) currentFiles = currentFiles.Concat(ignoreFiles).ToArray();

                    Log?.Invoke("Removing patch files..." , "remove", true);

                    int counter = 0;

                    foreach (var file in currentFiles)
                    {
                        counter++;
                        string filePath = Path.Combine(priconnePath, file);
                        string directory = Path.GetDirectoryName(filePath);

                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                            // Console.WriteLine($"File deleted: {file}");
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

                }
                catch (Exception ex)
                {
                    ErrorLog?.Invoke("Error updating files: " + ex.Message);
                    removeSuccess = false;
                }
            });
        }

        private void DeleteEmptyDirectories(string directoryPath)
        {
            if (!Directory.EnumerateFileSystemEntries(directoryPath).Any())
            {
                Directory.Delete(directoryPath);
                // Console.WriteLine($"Directory deleted: {directoryPath}");
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

        public static void HandleFormClosing(MainForm form, FormClosingEventArgs e, string tempFile)
        {
            try
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
            catch (IOException)
            {
                /*DialogResult result = MessageBox.Show("There is currently a file download process in progress.\nIf you close the application now, the file will be deleted.\nDo you want to exit anyway?", "Exit Application?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }*/
                MessageBox.Show("There is currently a file download / extraction process in progress.\nPlease wait for the operation to complete", "Cannot Exit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

    }
}
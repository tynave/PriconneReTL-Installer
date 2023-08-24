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

namespace InstallerFunctions
{
    class Installer
    {
        Helper helper = new Helper();

        private string githubAPI = Settings.Default.githubApi;

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
                            string priconnePath = content.detail.path;
                            Log?.Invoke("Found Princess Connect Re:Dive in " + priconnePath, "info", false);
                            return (priconnePath, true);
                        }
                    }
                }

                ErrorLog?.Invoke("Cannot find the game path! Did you install Princess Connect Re:Dive from DMMGamePlayer?");
                DisableStart?.Invoke();

                return ("Not found", false);
            }
            catch (FileNotFoundException)
            {
                ErrorLog?.Invoke("Cannot find the DMMGamePlayer config file! Do you have DMMGamePlayer installed?");
                DisableStart?.Invoke();
                return (null, false); // --> necessery?
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting game path: " + ex.Message);
                DisableStart?.Invoke();
                return ("ERROR!", false);
            }
        }
        public (string localVersion, bool localVersionValid ) GetLocalVersion(string priconnePath, bool priconnePathValid)
        {

            try
            {

                if (!priconnePathValid)
                {
                    return ("Unable to determine!", false);
                }

                string versionFilePath = Path.Combine(priconnePath, "BepInEx", "Translation", "en", "Text", "Version.txt");

                if (!File.Exists(versionFilePath))
                {
                    return ("None", false);
                }
                string rawVersionFile = File.ReadAllText(versionFilePath);
                string localVersion = System.Text.RegularExpressions.Regex.Match(rawVersionFile, @"\d{8}[a-z]?").Value;

                if (localVersion == "")
                {
                    return ("Invalid", false);

                }

                return (localVersion, true);

            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error getting local version: " + ex.Message);
                return ("ERROR!", false);
            }
        }
        public (string latestVersion, string assetLink, bool latestVersionValid) GetLatestRelease()
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
                    // latestReleaseLinkLabel.Text = version;
                    return (version, assetsLink, true);
                }
            }
            catch (Exception ex)
            {
                // logger.Error("Error getting latest release: " + ex.Message);
                ErrorLog?.Invoke("Error getting latest release: " + ex.Message);
                // latestReleaseLinkLabel.Text = "ERROR!";
                return (null, null, false);
            }
        }

        public async Task GetTLMod(string tempFile, string assetLink)
        {
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

                                // double progressPercentage = (double)downloadedBytes / totalBytes * 100;
                                DownloadProgress?.Invoke(downloadedBytes, totalBytes);
                                // progressBar.GetCurrentParent().Invoke((Action)(() => progressBar.Value = (int)progressPercentage));
                                // toolStripStatusLabel3.Text = $"{Math.Truncate(progressPercentage)}%";
                            }
                        }
                    }
                }

                /*outputTextBox.Invoke((Action)(() =>
                {
                    logger.Log("Download completed.", "info", true);
                }));*/
                Log?.Invoke("Download completed.", "info", true);
            }
            catch (Exception ex)
            {
                /*outputTextBox.Invoke((Action)(() =>
                {
                    logger.Error("Error getting patch: " + ex.Message);
                }));*/
                ErrorLog?.Invoke("Error getting patch: " + ex.Message);
            }
        }

        public async Task ExtractAllFiles(string tempFile, string priconnePath)
        {
            try
            {
                //await Task.Run(() =>
                //{
                int counter = 0;
                using (var zip = ZipFile.OpenRead(tempFile))
                    {
                        /*outputTextBox.Invoke((Action)(() =>
                        {
                            logger.Log("Extracting files to game folder...", "add", true);
                            toolStripProgressBar1.Minimum = 0;
                            toolStripProgressBar1.Maximum = zip.Entries.Count;
                        }));*/
                        Log?.Invoke("Extracting files to game folder...", "add", true);


                    // Keep config files if Force Redownload is selected or config files already present
                    // string[] ignoreFiles = SetIgnoreFiles(addconfig: forceRedownloadCheckBox.Checked || IsConfigPresent());
                    // string[] ignoreFiles = helper.SetIgnoreFiles(priconnePath, addconfig: forceRedownloadCheckBox.Checked || helper.IsConfigPresent(priconnePath));
                    string[] ignoreFiles = helper.SetIgnoreFiles(priconnePath, addconfig: helper.IsConfigPresent(priconnePath));
                    foreach (var entry in zip.Entries)
                        {
                            counter++;
                            string fileName = entry.FullName;

                            /*outputTextBox.Invoke((Action)(() =>
                            {
                                logger.Log("Extracting: " + entry.FullName, "add");
                                toolStripProgressBar1.PerformStep();
                                double percentage = (double)toolStripProgressBar1.Value / zip.Entries.Count * 100;
                                toolStripStatusLabel3.Text = $"{Math.Truncate(percentage)}%";
                            }));*/
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

                /*outputTextBox.Invoke((Action)(() =>
                {
                    logger.Error("Error extracting all files: " + ex.Message);
                }));*/
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

        public async Task RemovePatchFiles(string priconnePath, string localVersion, bool removeConfig, bool removeIgnored, bool removeInterops)
        {
            await Task.Run(() =>
            {
                try
                {
                    string[] configFiles = new string[Settings.Default.configFiles.Count];
                    Settings.Default.configFiles.CopyTo(configFiles, 0);
                    string[] ignoreFiles = new string[Settings.Default.ignoreFiles.Count];
                    Settings.Default.ignoreFiles.CopyTo(ignoreFiles, 0);

                string[] currentFiles = ProcessTree(priconnePath, localVersion).GetAwaiter().GetResult();

                    /*if (currentFiles == null)
                {
                    /*outputTextBox.Invoke((Action)(() =>
                    {
                        logger.Error("Failed to get list of files to remove! Cannot continue.");
                    }));
                    throw new Exception("Failed to get list of files to remove! Cannot continue.");
                }*/

                    if (removeConfig) currentFiles = currentFiles.Concat(configFiles).ToArray();
                    if (removeIgnored) currentFiles = currentFiles.Concat(ignoreFiles).ToArray();

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

                    if (removeInterops)
                    {
                        RemoveInterops();
                    }

                }
                catch (Exception ex)
                {
                    ErrorLog?.Invoke("Error updating files: " + ex.Message);
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
            }

        }
    }
}
using LoggerFunctions;
using Newtonsoft.Json;
using PriconneReTLInstaller;
using PriconneReTLInstaller.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace InstallerFunctions
{
    class Installer
    {

        public event Action<float> DownloadProgress;
        public event Action<string, string> Log;
        public event Action<string> ErrorLog;
        public event Action DisableStart;
        public string GetGamePath()
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
                            // logger.Log("Found Princess Connect Re:Dive in " + priconnePath, "info");
                            Log?.Invoke("Found Princess Connect Re:Dive in " + priconnePath, "info");
                            return priconnePath;
                        }
                    }
                }

                // logger.Error("Cannot find the game path! Did you install Princess Connect Re:Dive from DMMGamePlayer?");
                ErrorLog?.Invoke("Cannot find the game path! Did you install Princess Connect Re:Dive from DMMGamePlayer?");
                // startButton.Enabled = false;
                // startButton.BackgroundImage = Resources.start_disabled;
                DisableStart?.Invoke();
                
                return "Not found!";
            }
            catch (FileNotFoundException)
            {
                // logger.Error("Cannot find the DMMGamePlayer config file! Do you have DMMGamePlayer installed?");
                // mainForm.startButton.Enabled = false;
                // mainForm.startButton.BackgroundImage = Resources.start_disabled;
                ErrorLog?.Invoke("Cannot find the DMMGamePlayer config file! Do you have DMMGamePlayer installed?");
                DisableStart?.Invoke();
                return null;
            }
            catch (Exception ex)
            {
                // logger.Error("Error getting game path: " + ex.Message);
                ErrorLog?.Invoke("Error getting game path: " + ex.Message);
                // startButton.Enabled = false;
                // startButton.BackgroundImage = Resources.start_disabled;
                DisableStart?.Invoke();
                return "ERROR!";
            }
        }
    }
}
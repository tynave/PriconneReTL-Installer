using HelperFunctions;
using InstallerFunctions;
using LoggerFunctions;
using PriconneReTLInstaller.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace PriconneReTLInstaller
{
    public partial class AutoUpdateForm: BaseForm
    {
        private AutoUpdateLogger logger;
        private string priconnePath;
        private bool priconnePathValid;
        private string gameVersion;
        private string latestVersion;
        private bool latestVersionValid;
        private string localVersion;
        private bool localVersionValid;
        private string assetLink;
        public AutoUpdateForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Height = 140;

            installer.Log += OnLog;
            installer.ErrorLog += OnErrorLog;
            installer.DownloadProgress += OnDownloadProgress;
            installer.ProgressPictureChange += OnProgressPictureChange;
            installer.ProcessStart += OnProcessStart;
            installer.ProcessFinish += OnProcessFinish;
            installer.ProcessError += OnProcessError;

            helper.Log += OnLog;

            logger = new AutoUpdateLogger("ReTLAutoUpdater.log", statusLabel);
            logger.StartSession();

        }
        // Functions
        private void InitializeUI()
        {
            Icon = Resources.jewel;

            (priconnePath, priconnePathValid, gameVersion) = installer.GetGamePath();
            gamePathLinkLabel.Text = "Game Path: " + priconnePath;
            gameVersionLabel.Text = "Game Version: " + gameVersion;

            (latestVersion, latestVersionValid, assetLink) = installer.GetLatestPatchRelease(Settings.Default.patchGithubApi);
            latestVersionLinkLabel.Text = "Latest TL Patch Release: " + latestVersion;


            (localVersion, localVersionValid) = installer.GetLocalPatchVersion();
            localVersionLabel.Text = "Current (Local) TL Patch Version: " + localVersion;

            newPictureBox.Visible = (latestVersionValid && (localVersion == latestVersion)) ? false : true;

            progressLabel.Text = "";

        }
        private void CountDownToProcess(bool install)
        {
            int countdown = 2;
            timer1.Tick += (sender, e) =>
            {
                cancelButton.Visible = true;
                if (countdown > 0)
                {
                    cancelButton.Text = $"Cancel ({countdown})";
                    countdown--;
                }
                else
                {
                    timer1.Stop();
                    cancelButton.Visible = false;
                    this.Height = 240;
                    installer.ProcessAutoUpdateOperation(install, assetLink);
                }
            };
            timer1.Start();
        }
        private async void StartGame()
        {
            bool result = false;

            try
            {
                switch (Settings.Default.selectedLauncher)
                {
                    case 0:
                        installer.StartDMMGamePlayer();
                        break;
                    case 1:
                        result = installer.StartDMMFastLauncher();
                        if (result == false)
                        {
                            MessageBox.Show("Cannot start game via DMMGamePlayerFastLauncher!\nCheck logs for more details.\nFalling back to DMMGamePlayer!", "Cannot launch via DMMGamePlayerFastLauncher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            installer.StartDMMGamePlayer();
                            break;
                        }
                        break;
                    default:
                        break;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await Task.Delay(3000);
                Application.Exit();
            }
        }

        // Events
        private void OnLog(string message, string color, bool writeToStatus = false)
        {
            statusLabel.Invoke((Action)(() =>
            {
                logger.Log(message, color, writeToStatus);
                progressLabel.ForeColor = statusLabel.ForeColor;
                if (color == "error")
                {
                    progressPicture.Visible = false;
                    this.Height = 140;
                }
            }));
        }

        private void OnErrorLog(string message)
        {
            statusLabel.Invoke((Action)(() =>
            {
                logger.Error(message);
                progressPicture.Visible = false;
                this.Height = 140;
            }));
        }

        public void OnDownloadProgress(double currentValue, double maxValue)
        {
           
            double percentage = ((double)currentValue / (double)maxValue) * 100;
            statusLabel.Invoke((Action)(() =>
            {
                progressPicture.Left = 30 + (int)(percentage * 5);
                progressLabel.Text = $" {Math.Truncate(percentage)}%";
                progressLabel.Left = 30 + (int)(percentage * 5);
                
            }));
        }

        public void OnProgressPictureChange(Image progressImage)
        {
            if (progressImage == null)
            {
                progressPicture.Visible = false;
            }
            else 
            {
                progressPicture.Invoke((Action)(() =>
                {
                    progressPicture.Visible = true;
                    progressPicture.Image = progressImage;
                }));
            }
            
        }

        private void OnProcessStart()
        {
            // Placeholder event for future updates
        }

        private void OnProcessFinish()
        {
            localVersionLabel.Text = "Current (Local) TL Patch Version: " + latestVersion;
            newPictureBox.Visible = false;
            progressPicture.Visible = false;
            progressLabel.Text = "";
            StartGame();
        }

        private void OnProcessError() 
        { 
           exitButton.Visible = true;
           progressPicture.Visible = false;
           progressLabel.Text = "";
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            this.Activate();
            InitializeUI();

            if (priconnePathValid  && latestVersionValid)
            {
                int versioncompare = localVersion.CompareTo(latestVersion);

                if (versioncompare == 0)
                {
                    logger.Log("You already have the latest translation patch version installed! Starting game..", "success", true);
                    await Task.Delay(2000);
                    StartGame();
                    return;
                }

                if (versioncompare < 0)
                {
                    logger.Log("Found new version! Starting update...", "info", true);
                    CountDownToProcess(false);
                    return;
                }

                logger.Log("TL Patch not found! Starting installation...", "info", true);
                CountDownToProcess(true);
                return;

            }
            else
            {
                logger.Log("An error has occured! Cannot continue, exiting..", "error", true);
                OnProcessError();
            }
        }
        private void gamePathLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             ProcessStartInfo startInfo = new ProcessStartInfo("explorer.exe");
             startInfo.Arguments = priconnePath;
             Process.Start(startInfo);
        }

        private void latestVersionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (latestVersion != null) Process.Start("https://github.com/ImaterialC/PriconneRe-TL/releases/latest");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            cancelButton.Text = "Cancelled";
            cancelButton.Enabled = false;
            logger.Log("Cancelled.. Starting game..", "info", true);
            StartGame();
        }

        private void AutoUpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            installer.HandleFormClosing(this, e);
        }

        private void progressPicture_VisibleChanged(object sender, EventArgs e)
        {
            this.Height = progressPicture.Visible ? 240 : 140;
            progressLabel.Visible = progressPicture.Visible;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

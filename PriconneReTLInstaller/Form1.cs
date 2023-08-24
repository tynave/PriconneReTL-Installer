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
using System.Reflection;

namespace PriconneReTLInstaller
{
    public partial class MainForm : Form
    {
        private Logger logger;
        private string priconnePath;
        private bool priconnePathValid;
        private string githubAPI = Properties.Settings.Default.githubApi;
        private string latestVersion;
        private bool latestVersionValid;
        private string assetLink;
        private string localVersion;
        private bool localVersionValid;
        private string tempFile;
        PrivateFontCollection priconnefont = new PrivateFontCollection();
        private bool mouseDown;
        private Point lastLocation;

        Helper helper = new Helper();
        Installer installer = new Installer();

        public MainForm()
        {
            InitializeComponent();
            
            installer.Log += OnLog;
            installer.ErrorLog += OnErrorLog;
            helper.Log += OnLog;
            helper.ErrorLog += OnErrorLog;
            installer.DisableStart += OnDisableStart;
            installer.DownloadProgress += OnDownloadProgress;
            
            logger = new Logger("ReTLInstaller.log", outputTextBox, toolStripStatusLabel1);
            logger.StartSession();

            InitializeUI();

            tempFile = Path.GetTempFileName();

        }
        // Events
        
        private void OnLog(string message, string color, bool writeToToolStrip = false)
        {
            outputTextBox.Invoke((Action)(() =>
            {
                logger.Log(message, color, writeToToolStrip);
            }));
        }

        private void OnErrorLog(string message)
        {
            outputTextBox.Invoke((Action)(() =>
            {
                logger.Error(message);
            }));
        }

        public void OnDisableStart()
        {
            startButton.Enabled = false;
            startButton.BackgroundImage = Resources.start_disabled;
        }

        public void OnDownloadProgress(double currentValue, double maxValue)
        {
            double percentage = ((double)currentValue / (double)maxValue) * 100;
            statusStrip1.Invoke((Action)(() =>
            {   
                toolStripProgressBar1.Value = (int)percentage;
                toolStripStatusLabel3.Text = $"{Math.Truncate(percentage)}%";
            }));
        }

        public void SetUninstallandForceredownloadCheckBox(bool enabledState)
        {
            forceRedownloadCheckBox.Enabled = enabledState;
            uninstallCheckBox.Enabled = enabledState;
        }

        // Functions
        private void InitializeUI ()
        {
            Icon = Resources.jewel; 
            helper.PriconneFont(priconnefont);
            helper.SetFontForAllControls(priconnefont, Controls);
            Height = 480;

            // (priconnePath, priconnePathValid) = installer.GetGamePath();
            priconnePath = "C:\\Test"; // -- set fixed path for testing purposes
            priconnePathValid = true; // -- set fixed path for testing purposes
            priconnePathLinkLabel.Text = priconnePathValid ? priconnePath : "ERROR!";

            (latestVersion, assetLink, latestVersionValid) = installer.GetLatestRelease();
            latestReleaseLinkLabel.Text = latestVersionValid ? latestVersion : "ERROR!";

            UpdateUI();

        }
        private void UpdateUI()
        {
            (localVersion, localVersionValid) = installer.GetLocalVersion(priconnePath,priconnePathValid);
            labelCurrentVersion.Text = "Current (Local) Version: " + localVersion;

            newPictureBox.Visible = localVersion == latestVersion ? false : true;

            if (!localVersionValid)
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

            if (!priconnePathValid)
            {
                modeLabel.Text = Settings.Default.disabledMode;
                modeDescritpionLabel.Text = Settings.Default.disabledModeDescription;
                return;
            }

            if (!localVersionValid)
            {
                modeLabel.Text = Settings.Default.installMode;
                modeDescritpionLabel.Text = Settings.Default.installModeDescription;
                return;
            }

            modeLabel.Text = Settings.Default.updateMode;
            modeDescritpionLabel.Text = Settings.Default.updateModeDescription;
            return;
        }
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
                    // await RemovePatchFiles(removeConfig: removeConfigCheckBox.Checked, removeIgnored: removeIgnoredCheckBox.Checked, removeInterops: removeInteropsCheckBox.Checked);
                    await installer.RemovePatchFiles(priconnePath, localVersion, removeConfig: removeConfigCheckBox.Checked, removeIgnored: removeIgnoredCheckBox.Checked, removeInterops: removeInteropsCheckBox.Checked);
                    logger.Log("Uninstall Complete!", "success", true);
                    UpdateUI();
                    return;
                }

                if (forceRedownloadCheckBox.Checked) // Force Redownload
                {
                    logger.Log("Reinstalling translation patch...", "info", true);
                    // await RemoveMod(removeConfig: false);
                    // await RemovePatchFiles(removeConfig: false, removeIgnored: false, removeInterops: true);
                    await installer.RemovePatchFiles(priconnePath, localVersion, removeConfig: removeConfigCheckBox.Checked, removeIgnored: removeIgnoredCheckBox.Checked, removeInterops: removeInteropsCheckBox.Checked);
                    await installer.GetTLMod(tempFile, assetLink);
                    await installer.ExtractAllFiles(tempFile, priconnePath);
                    logger.Log("Reinstall complete!", "success", true);
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
                        await installer.RemovePatchFiles(priconnePath, localVersion, removeConfig: false, removeIgnored: false, removeInterops: false);
                        await installer.GetTLMod(tempFile, assetLink);
                        await installer.ExtractAllFiles(tempFile, priconnePath);
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
                // await GetTLMod(tempFile, toolStripProgressBar1);
                await installer.GetTLMod(tempFile, assetLink);
                await installer.ExtractAllFiles(tempFile, priconnePath);
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
            removeConfigCheckBox.Enabled = forceRedownloadCheckBox.Checked;
            removeIgnoredCheckBox.Enabled = forceRedownloadCheckBox.Checked;
            removeInteropsCheckBox.Enabled = forceRedownloadCheckBox.Checked;
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

        private async void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            //mouseDown = true;
            //lastLocation = e.Location;
            mouseDown = true;
            lastLocation = e.Location;

            await Task.Run(() =>
            {
                while (mouseDown)
                {
                    this.Invoke((Action)(() =>
                    {
                        this.Location = new Point(
                            (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                        this.Update();
                    }));
                }
            });
        }


        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (mouseDown)
            {
                this.Invoke((Action)(() =>
                {
                    this.Location = new Point(
                        (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                    this.Update();
                }));
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void priconnePathLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!priconnePathValid)
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
}



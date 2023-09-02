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
        private string latestVersion;
        private bool latestVersionValid;
        private string localVersion;
        private bool localVersionValid;
        //private string tempFile;
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
            installer.ProcessStart += OnProcessStart;
            installer.ProcessFinish += OnProcessFinish;

            uninstallCheckBox.CheckedChanged += OnCheckedChange;
            reinstallCheckBox.CheckedChanged += OnCheckedChange;

            uninstallCheckBox.EnabledChanged += OnEnabledChange;
            removeConfigCheckBox.EnabledChanged += OnEnabledChange;

            removeConfigCheckBox.CheckedChanged += OnCheckedChange;
            removeIgnoredCheckBox.CheckedChanged += OnCheckedChange;
            removeInteropsCheckBox.CheckedChanged += OnCheckedChange;
            showLogCheckBox.CheckedChanged += OnCheckedChange;

            removeConfigCheckBox.EnabledChanged += OnEnabledChange;
            removeIgnoredCheckBox.EnabledChanged += OnEnabledChange;
            removeInteropsCheckBox.EnabledChanged += OnEnabledChange;

            uninstallCheckBox.CheckedChanged += OnCheckBoxToggle;
            reinstallCheckBox.CheckedChanged += OnCheckBoxToggle;

            startButton.MouseEnter += OnButtonMouseEnter;
            startButton.MouseLeave += OnButtonMouseLeave;
            aboutButton.MouseEnter += OnButtonMouseEnter;
            aboutButton.MouseLeave += OnButtonMouseLeave;
            minimizeButton.MouseEnter += OnButtonMouseEnter;
            minimizeButton.MouseLeave += OnButtonMouseLeave;
            exitButton.MouseEnter += OnButtonMouseEnter;
            exitButton.MouseLeave += OnButtonMouseLeave;

            this.MouseDown += OnMouseDown;
            this.MouseMove += OnMouseMove;
            this.MouseUp += OnMouseUp;

            pictureBox1.MouseDown += OnMouseDown;
            pictureBox1.MouseMove += OnMouseMove;
            pictureBox1.MouseUp += OnMouseUp;

            logger = new Logger("ReTLInstaller.log", outputTextBox, toolStripStatusLabel1);
            logger.StartSession();

        }

        // Functions
        private void InitializeUI ()
        {
            Icon = Resources.jewel; 
            helper.PriconneFont(priconnefont);
            helper.SetFontForAllControls(priconnefont, Controls);
            Height = 480;

            (priconnePath, priconnePathValid) = installer.GetGamePath();
            priconnePathLinkLabel.Text = priconnePath;

            (latestVersion, latestVersionValid) = installer.GetLatestRelease();
            latestReleaseLinkLabel.Text = latestVersionValid ? latestVersion : "ERROR!";

            UpdateUI();

        }
        private void UpdateUI()
        {
            (localVersion, localVersionValid) = installer.GetLocalVersion();

            labelCurrentVersion.Text = "Current (Local) Version: " + localVersion;

            newPictureBox.Visible = localVersion == latestVersion ? false : true;

            SetUninstallandReinstallCheckBox(localVersionValid);

            UpdateModeDescription();
        }

        private void UpdateModeDescription()
        {
            if (reinstallCheckBox.Checked)
            {
                modeLabel.Text = Settings.Default.reinstallMode;
                modeDescritpionLabel.Text = Settings.Default.reinstallModeDescription;
                return;
            }

            if (uninstallCheckBox.Checked)
            {
                modeLabel.Text = Settings.Default.uninstallMode;
                modeDescritpionLabel.Text = Settings.Default.uninstallModeDescription;
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

        public void SetUninstallandReinstallCheckBox(bool enabledState)
        {
            reinstallCheckBox.Enabled = enabledState;
            uninstallCheckBox.Enabled = enabledState;
        }

        public void OnCheckedChange(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                checkBox.Image = checkBox.Checked ? Resources.check_checked_24x24_2 : Resources.check_empty_24x24_2;

                if (checkBox == showLogCheckBox)
                {
                    this.Height = checkBox.Checked ? 750 : 480;
                }
            }
            UpdateModeDescription();
        }

        public void OnEnabledChange(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox) checkBox.Checked = false;
        }

        private void OnCheckBoxToggle(object sender, EventArgs e)
        {
            CheckBox checkbox2;
            if (sender is CheckBox checkBox)
            {
                if (checkBox == uninstallCheckBox) checkbox2 = reinstallCheckBox;
                else checkbox2 = uninstallCheckBox;
                checkbox2.Checked = checkBox.Checked ? false : checkbox2.Checked;
                removeConfigCheckBox.Enabled = checkBox.Checked;
                removeIgnoredCheckBox.Enabled = checkBox.Checked;
                removeInteropsCheckBox.Enabled = checkBox.Checked;
            }
        }

        private async void OnMouseDown(object sender, MouseEventArgs e)
        {
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

        private void OnMouseMove(object sender, MouseEventArgs e)
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
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void OnButtonMouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == startButton && button.Enabled) button.BackgroundImage = Resources.start_hover;
                if (button == exitButton) button.BackgroundImage = Resources.door_open;
                if (button == minimizeButton) button.BackgroundImage = Resources.arrow_yellow;
                if (button == aboutButton) button.BackgroundImage = Resources.q_bubble;
            }
        }

        private void OnButtonMouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == startButton && button.Enabled) button.BackgroundImage = Resources.start_idle;
                if (button == exitButton) button.BackgroundImage = Resources.door_closed;
                if (button == minimizeButton) button.BackgroundImage = Resources.arrow_blue;
                if (button == aboutButton) button.BackgroundImage = Resources.i_bubble;
            }
        }

        private void OnProcessStart()
        {
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel3.Text = "";
            outputTextBox.Clear();
            startButton.Enabled = false;
            startButton.BackgroundImage = Resources.start_working;
            logger.Log("Starting process...", "info");
        }

        private void OnProcessFinish()
        {
            startButton.Enabled = true;
            startButton.BackgroundImage = Resources.start_complete;
            reinstallCheckBox.Checked = false;
            uninstallCheckBox.Checked = false;
            UpdateUI();
        }
        private void startButton_Click_1(object sender, EventArgs e)
        {
            installer.ProcessOperation(uninstallCheckBox.Checked, reinstallCheckBox.Checked, removeConfigCheckBox.Checked, removeIgnoredCheckBox.Checked, removeInteropsCheckBox.Checked/*, tempFile*/);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            SetToolTips();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            installer.HandleFormClosing(this, e/*, tempFile*/);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void priconnePathLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (priconnePathValid)
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

    }
}



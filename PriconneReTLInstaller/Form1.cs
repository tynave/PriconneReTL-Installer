using HelperFunctions;
using InstallerFunctions;
using LoggerFunctions;
using PriconneReTLInstaller.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private int versioncompare;
        PrivateFontCollection priconnefont = new PrivateFontCollection();
        private bool mouseDown;
        private Point lastLocation;
        private CheckBox[] exclusiveCheckboxes;
        private CheckBox[] operationCheckboxes;
        private CheckBox[] launcherCheckboxes;

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

            installCheckBox.CheckedChanged += OnCheckedChange;
            uninstallCheckBox.CheckedChanged += OnCheckedChange;
            reinstallCheckBox.CheckedChanged += OnCheckedChange;
            launchCheckBox.CheckedChanged += OnCheckedChange;

            //uninstallCheckBox.EnabledChanged += OnEnabledChange;
            //removeConfigCheckBox.EnabledChanged += OnEnabledChange;
            installCheckBox.EnabledChanged += OnEnabledChange;
            launchCheckBox.EnabledChanged += OnEnabledChange;

            removeConfigCheckBox.CheckedChanged += OnCheckedChange;
            removeIgnoredCheckBox.CheckedChanged += OnCheckedChange;
            removeInteropsCheckBox.CheckedChanged += OnCheckedChange;
            showLogCheckBox.CheckedChanged += OnCheckedChange;

            removeConfigCheckBox.EnabledChanged += OnEnabledChange;
            removeIgnoredCheckBox.EnabledChanged += OnEnabledChange;
            removeInteropsCheckBox.EnabledChanged += OnEnabledChange;

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
        private void InitializeUI()
        {
            Icon = Resources.jewel;
            helper.PriconneFont(priconnefont);
            helper.SetFontForAllControls(priconnefont, Controls);
            Height = 480;

            (priconnePath, priconnePathValid) = installer.GetGamePath();
            gamePathLinkLabel.Text = priconnePath;

            helper.PopulateComboBox(comboBox1);

            launchCheckBox.Enabled = priconnePathValid && comboBox1.Items.Count > 0;
            launchCheckBox.Checked = Settings.Default.launchState;

            (latestVersion, latestVersionValid) = installer.GetLatestRelease();
            latestVersionLinkLabel.Text = latestVersionValid ? latestVersion : "ERROR!";

            exclusiveCheckboxes = new CheckBox[] { installCheckBox, reinstallCheckBox, uninstallCheckBox };
            operationCheckboxes = new CheckBox[] { installCheckBox, reinstallCheckBox, uninstallCheckBox, launchCheckBox };

            foreach (CheckBox checkBox in exclusiveCheckboxes)
            {
                checkBox.CheckedChanged += ExclusiveCheckbox_CheckedChanged;
            }

            foreach (CheckBox checkBox in operationCheckboxes)
            {
                checkBox.CheckedChanged += OperationCheckbox_CheckedChanged;
            }

            UpdateUI();

            if (versioncompare == 0) logger.Log("You already have the latest version installed!", "success", true);

        }
        private void UpdateUI()
        {
            (localVersion, localVersionValid) = installer.GetLocalVersion();

            installCheckBox.Text = localVersionValid ? " Update" : " Install";

            localVersionLabel.Text = "Current (Local) Version: " + localVersion;

            versioncompare = localVersion.CompareTo(latestVersion);

            if ((!localVersionValid || versioncompare != 0) && priconnePathValid) installCheckBox.Enabled = true; else installCheckBox.Enabled = false;

            newPictureBox.Visible = localVersion == latestVersion ? false : true;

            SetUninstallandReinstallCheckBox(localVersionValid);

            UpdateModeDescription();
        }

        private void UpdateModeDescription()
        {
            bool exclusiveCheckboxChecked = helper.isAnyChecked(exclusiveCheckboxes);
           
            var modes = new List<(bool condition, string mode, string description)>
                {
                    (installCheckBox.Checked && !localVersionValid, Settings.Default.installMode, Settings.Default.installModeDescription),
                    (installCheckBox.Checked && localVersionValid, Settings.Default.updateMode, Settings.Default.updateModeDescription),
                    (reinstallCheckBox.Checked, Settings.Default.reinstallMode, Settings.Default.reinstallModeDescription),
                    (uninstallCheckBox.Checked, Settings.Default.uninstallMode, Settings.Default.uninstallModeDescription),
                    (!priconnePathValid || !latestVersionValid, Settings.Default.disabledMode, Settings.Default.disabledModeDescription),
                    (launchCheckBox.Checked && !exclusiveCheckboxChecked, Settings.Default.launchMode, Settings.Default.launchModeDescrption)
                };
  
            foreach (var (condition, mode, description) in modes)
            {
                if (condition)
                {
                    modeLabel.Text = mode;
                    toolTip.SetToolTip(modeLabel, description);
                    return;
                }
            }

            modeLabel.Text = Settings.Default.noOperationMode;
            toolTip.SetToolTip(modeLabel, Settings.Default.noOperationModeDescription);
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

        private void ExclusiveCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedCheckbox = (CheckBox)sender;

            // If the clicked checkbox is checked, uncheck all other checkboxes.
            if (clickedCheckbox.Checked)
            {
                foreach (CheckBox checkbox in exclusiveCheckboxes)
                {
                    if (checkbox != clickedCheckbox)
                    {
                        checkbox.Checked = false;
                    }
                }
            }
            if (clickedCheckbox == reinstallCheckBox || clickedCheckbox == uninstallCheckBox)
            {
                removeConfigCheckBox.Enabled = clickedCheckbox.Checked;
                removeIgnoredCheckBox.Enabled = clickedCheckbox.Checked;
                removeInteropsCheckBox.Enabled = clickedCheckbox.Checked;
            }
            
        }

        private void OperationCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            startButton.Enabled = helper.isAnyChecked(operationCheckboxes);
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
            logger.Log("Starting selected operation(s)...", "info");
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
            installer.ProcessOperation(installCheckBox.Checked, uninstallCheckBox.Checked, reinstallCheckBox.Checked, launchCheckBox.Checked, removeConfigCheckBox.Checked, removeIgnoredCheckBox.Checked, removeInteropsCheckBox.Checked, comboBox1);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            SetToolTips();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            installer.HandleFormClosing(this, e);
            Settings.Default.Save();
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

        private void startButton_EnabledChanged(object sender, EventArgs e)
        {
            startButton.BackgroundImage = startButton.Enabled ? Resources.start_idle : Resources.start_disabled;
        }

        private void launchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = launchCheckBox.Checked;
            Settings.Default.launchState = launchCheckBox.Checked;
        }
    }
}



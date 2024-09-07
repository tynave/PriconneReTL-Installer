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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriconneReTLInstaller
{
    public partial class MainForm : BaseForm
    {
        private string patchgithubAPI = Settings.Default.patchGithubApi;
        private string assetLink;
        private string priconnePath;
        private bool priconnePathValid;
        private string gameVersion;
        private string latestVersion;
        private bool latestVersionValid;
        private string localVersion;
        private bool localVersionValid;
        private int versioncompare;
        private CheckBox[] exclusiveCheckboxes;
        private CheckBox[] operationCheckboxes;
        private CheckBox[] optionCheckboxes;
        private Button[] menuButtons;

        public MainForm()
        {
            // Get the current assembly version
            Version currentVersion = Assembly.GetEntryAssembly().GetName().Version;

            // Get the last known assembly version from settings
            Version lastKnownVersion = new Version(Properties.Settings.Default.LastKnownVersion);

            // Compare the current version with the last known version
            if (currentVersion > lastKnownVersion)
            {
                // Upgrade is required
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.LastKnownVersion = currentVersion.ToString();
                Properties.Settings.Default.Save();
            }

            InitializeComponent();

            installer.Log += OnLog;
            installer.ErrorLog += OnErrorLog;
            helper.Log += OnLog;
            helper.ErrorLog += OnErrorLog;
            installer.DisableStart += OnDisableStart;
            installer.DownloadProgress += OnDownloadProgress;
            installer.ProcessStart += OnProcessStart;
            installer.ProcessFinish += OnProcessFinish;

            SubscribeToCheckBoxes(this.Controls);

            SubscribeToButtons(this.Controls);

            pictureBox1.MouseDown += OnMouseDown;
            pictureBox1.MouseMove += OnMouseMove;
            pictureBox1.MouseUp += OnMouseUp;

            operationsPanel.MouseDown += OnMouseDown;
            operationsPanel.MouseMove += OnMouseMove;
            operationsPanel.MouseUp += OnMouseUp;

            optionsPanel.MouseDown += OnMouseDown;
            optionsPanel.MouseMove += OnMouseMove;
            optionsPanel.MouseUp += OnMouseUp;

            this.Layout += OnOperationLabelChange;
            operationLabel.TextChanged += OnOperationLabelChange;

            logger = new Logger("ReTLInstaller.log", outputTextBox, toolStripStatusLabel1);
            logger.StartSession();

        }

        // Functions

        void SubscribeToCheckBoxes(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is CheckBox checkbox)
                {
                    // Console.WriteLine(checkbox.Name);
                    checkbox.CheckedChanged += OnCheckedChange;
                    checkbox.EnabledChanged += OnEnabledChange;
                }
                else if (control.HasChildren)
                {
                    // Recursively search for checkboxes in child controls
                    SubscribeToCheckBoxes(control.Controls);
                }
            }
        }

        void SubscribeToButtons(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button button)
                {
                    // Console.WriteLine(button.Name);
                    button.MouseEnter += OnButtonMouseEnter;
                    button.MouseLeave += OnButtonMouseLeave;
                }
                else if (control.HasChildren)
                {
                    // Recursively search for checkboxes in child controls
                    SubscribeToButtons(control.Controls);
                }
            }
        }

        void DisableCheckboxes(CheckBox[] checkboxes)
        {
            foreach (CheckBox checkBox in checkboxes)
            {
                checkBox.Enabled = false;
            }
        }

        void EnableCheckboxes(CheckBox[] checkboxes)
        {
            foreach (CheckBox checkBox in checkboxes)
            {
                checkBox.Enabled = true;
            }
        }

        private void InitializeUI()
        {
            string fastLauncherLink = Settings.Default.fastLauncherLink;

            Icon = Resources.jewel;
            Height = 480;
            optionsPanel.Height = 87;

            versionLinkLabel.Text = $"v{String.Format(Application.ProductVersion)}";

            removeConfigCheckBox.Enabled = false;
            removeIgnoredCheckBox.Enabled = false;

            (priconnePath, priconnePathValid, gameVersion) = installer.GetGamePath();
            gamePathLinkLabel.Text = priconnePath.Length < 55 ? "Game Path: " + priconnePath : "Game Path: " + priconnePath.Substring(0, 52) + "...";
            gameVersionLabel.Text = "Game Version: " + gameVersion;

            helper.LogFastLauncherShortcut();

            launchCheckBox.Enabled = priconnePathValid;
            launchCheckBox.Checked = Settings.Default.launchState;
            operationsPanel.Height = launchCheckBox.Checked ? 184 : 154;
            showLogCheckBox.Checked = Settings.Default.showLogChecked;

            (latestVersion, latestVersionValid, assetLink) = installer.GetLatestPatchRelease(patchgithubAPI);
            latestVersionLinkLabel.Text = "Latest Release: " + (latestVersionValid ? latestVersion : "ERROR!");

            exclusiveCheckboxes = new CheckBox[] { installCheckBox, reinstallCheckBox, uninstallCheckBox };
            operationCheckboxes = new CheckBox[] { installCheckBox, reinstallCheckBox, uninstallCheckBox, launchCheckBox };
            optionCheckboxes = new CheckBox[] { removeConfigCheckBox, removeIgnoredCheckBox };
            menuButtons = new Button[] { exitButton, minimizeButton, aboutButton, auButton, settingsButton };


            foreach (CheckBox checkBox in exclusiveCheckboxes)
            {
                checkBox.CheckedChanged += ExclusiveCheckbox_CheckedChanged;
            }

            foreach (CheckBox checkBox in operationCheckboxes)
            {
                checkBox.CheckedChanged += OperationCheckbox_CheckedChanged;
            }

            UpdateUI();

            if (versioncompare == 0) logger.Log("You already have the latest translation patch version installed!", "success", true);

            startButton.Enabled = helper.isAnyChecked(operationCheckboxes);
            checkForInstallerUpdatesToolStripMenuItem.Checked = Settings.Default.checkForInstallerUpdates;
        }

        private void UpdateUI()
        {
            (localVersion, localVersionValid) = installer.GetLocalPatchVersion();

            installCheckBox.Text = localVersionValid ? " Update" : " Install";
            localVersionLabel.Text = "Current (Local) Version: " + localVersion;

            versioncompare = localVersion.CompareTo(latestVersion);
            if ((!localVersionValid || versioncompare != 0) && priconnePathValid) installCheckBox.Enabled = true; else installCheckBox.Enabled = false;

            newPictureBox.Visible = localVersion == latestVersion ? false : true;

            SetUninstallandReinstallCheckBox(localVersionValid);
            UpdateModeDescription();

            helper.PopulateConfigChecklistbox(configListBox);

            removeConfigCheckBox.Enabled = false;
            removeIgnoredCheckBox.Enabled = false;
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
                    if (launchCheckBox.Checked && exclusiveCheckboxChecked)
                    {
                        operationLabel.Text = $"Current Operation: {mode} + {Settings.Default.launchMode}";
                        toolTip.SetToolTip(operationToolTipPicture, description + "\n\n" + Settings.Default.launchModeDescrption);
                        return;
                    }
                    operationLabel.Text = $"Current Operation: {mode}";
                    toolTip.SetToolTip(operationToolTipPicture, description);
                    return;
                }
            }

            operationLabel.Text = $"Current Operation: {Settings.Default.noOperationMode}";
            toolTip.SetToolTip(operationToolTipPicture, Settings.Default.noOperationModeDescription);
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

            toolTip.SetToolTip(removeConfigCheckBox, $"Removes the selected config files");
            toolTip.SetToolTip(removeIgnoredCheckBox, $"Removes the currently set ignored files also.");
        }

        // Events
        public void OnLog(string message, string color, bool writeToToolStrip = false)
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
                    Settings.Default.showLogChecked = checkBox.Checked;
                }
            }
            UpdateModeDescription();
        }

        public void OnEnabledChange(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                checkBox.Checked = false;
                checkBox.Image = checkBox.Enabled ? Resources.check_empty_24x24_2 : Resources._lock;
            }
                
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
            }
        }

        private void OperationCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            startButton.Enabled = helper.isAnyChecked(operationCheckboxes);
        }

        private void OnOperationLabelChange(object sender, EventArgs e)
        {
            operationToolTipPicture.Location = new Point(operationLabel.Right + 5, operationToolTipPicture.Top);
        }

        private void removeConfigCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            configListBox.Visible = removeConfigCheckBox.Checked;
            optionsPanel.Height = removeConfigCheckBox.Checked ? 154 : 87;
        }

        private void OnButtonMouseEnter(object sender, EventArgs e)
        {
            var menuButtonLabels = new List<(Button menuButton, string name)>
                {
                    (exitButton, "Exit Application"),
                    (minimizeButton, "Minimize Application"),
                    (aboutButton, "Help / About"),
                    (auButton, "Create AutoUpdater Shortcut"),
                    (settingsButton, "Settings")
                };

            if (sender is Button button)
            {
                if (button == startButton && button.Enabled) button.BackgroundImage = Resources.start_hover_lit;
                if (button == exitButton) button.BackgroundImage = Resources.door_open;
                if (button == minimizeButton) button.BackgroundImage = Resources.arrow_yellow;
                if (button == aboutButton) button.BackgroundImage = Resources.q_bubble;
                if (button == settingsButton) button.BackgroundImage = Resources.scroll_open;
                if (button == auButton) button.BackgroundImage = Resources.crystal_lit;
                
                foreach (var (menuButton, name) in menuButtonLabels)
                    {
                        if (button == menuButton)
                        {
                            menuButtonLabel.Visible = true;
                            menuButtonLabel.Text = name;
                        }
                    }
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
                if (button == settingsButton) button.BackgroundImage = Resources.scroll_closed_res2;
                if (button == auButton) button.BackgroundImage = Resources.crystal_normal_res;
                menuButtonLabel.Visible = false;
            }
        }
        private void OnProcessStart()
        {
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel3.Text = "";
            outputTextBox.Clear();
            startButton.Enabled = false;
            auButton.Enabled = false;
            settingsButton.Enabled = false;
            startButton.BackgroundImage = Resources.start_working;
            logger.Log("Starting selected operation(s)...", "info");
            DisableCheckboxes(operationCheckboxes);
            DisableCheckboxes(optionCheckboxes);
        }

        private void OnProcessFinish()
        {
            EnableCheckboxes(operationCheckboxes);
            EnableCheckboxes(optionCheckboxes);
            startButton.Enabled = false;
            auButton.Enabled = true; 
            settingsButton.Enabled= true;   
            startButton.BackgroundImage = Resources.start_complete;
            reinstallCheckBox.Checked = false;
            uninstallCheckBox.Checked = false;
            UpdateUI();
        }
        private void startButton_Click_1(object sender, EventArgs e)
        {
            
            if (helper.IsGameRunning())
            {
                MessageBox.Show($"The game is currently running.\nPlease exit the game before performing any operations.", "Cannot Start", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
               installer.ProcessOperation(assetLink, installCheckBox.Checked, uninstallCheckBox.Checked, reinstallCheckBox.Checked, launchCheckBox.Checked, removeConfigCheckBox.Checked, configListBox, removeIgnoredCheckBox.Checked);
            }

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            SetToolTips();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            installer.HandleFormClosing(this, e);
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
        private void versionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/tynave/PriconneReTL-Installer/releases/latest");
        }
        private void latestReleaseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (latestVersion != null) Process.Start("https://github.com/ImaterialC/PriconneRe-TL/releases/latest");
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            helpMenuStrip.Show(aboutButton, new System.Drawing.Point(0, aboutButton.Height));
        }

        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/tynave/PriconneReTL-Installer/wiki");
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"[PriconneReTL Updater version: {String.Format(Application.ProductVersion)}]\n" + Settings.Default.aboutText, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void startButton_EnabledChanged(object sender, EventArgs e)
        {
            startButton.BackgroundImage = startButton.Enabled ? Resources.start_idle : Resources.start_disabled;
        }

        private void launchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            operationsPanel.Height = launchCheckBox.Checked ? 184 : 154; 
            Settings.Default.launchState = launchCheckBox.Checked;
        }

        private void modeLabel_TextChanged(object sender, EventArgs e)
        {
            operationToolTipPicture.Location = new Point(operationLabel.Right + 10, operationToolTipPicture.Top);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            settingsMenuStrip.Show(settingsButton, new System.Drawing.Point(0, settingsButton.Height));
        }

        private void editIgnoredFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IgnoreForm ignoreForm = new IgnoreForm(priconnePath);
            ignoreForm.ShowDialog();
        }

        private void auButton_Click(object sender, EventArgs e)
        {
            helper.CreateAutoUpdaterShortcut(priconnePath);
        }

        private void settingsButton_EnabledChanged(object sender, EventArgs e)
        {
            settingsButton.BackgroundImage = settingsButton.Enabled ? Resources.scroll_closed_res2 : Resources.scroll_disabled;
        }

        private void auButton_EnabledChanged(object sender, EventArgs e)
        {
            auButton.BackgroundImage = auButton.Enabled ? Resources.crystal_normal_res : Resources.crystal_disabled;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            SetToolTips();
            currentLauncherLinkLabel.Text = "Launcher: " + (Settings.Default.selectedLauncher == 0 ? "DMMGamePlayer" : "DMMGamePlayerFastLauncher");
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Settings.Default.checkForInstallerUpdates)
            {
                try
                {
                    (string version, bool versionValid) = installer.GetLatestInstallerRelease();
                    helper.CheckForInstallerUpdate(version, versionValid);
                }
                catch (Exception ex)
                {
                    logger.Error("Error checking for installer update: " + ex.Message);
                }
            }
        }

        private void launcherSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LauncherForm LauncherForm = new LauncherForm();
            LauncherForm.ShowDialog();
        }

        private void importExportSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEForm iEForm = new IEForm(priconnePath);
            iEForm.ShowDialog();
        }

        private void currentLauncherLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LauncherForm LauncherForm = new LauncherForm();
            LauncherForm.ShowDialog();
        }

        private void checkForInstallerUpdatesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.checkForInstallerUpdates = checkForInstallerUpdatesToolStripMenuItem.Checked;
            Settings.Default.Save();
        }
    }
}



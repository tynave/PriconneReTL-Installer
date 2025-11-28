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
using System.Xml.Linq;

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
        private string localModLoaderVersion;
        private bool localModLoaderVersionValid;
        private string latestModLoaderVersion;
        private bool modLoaderOutdated;
        private string modLoaderTooltip;
        private string commitSha;
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

            Helper.SetDefaultDMMConfigPath();
            Helper.EnsureDMMConfigPathValid();

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

            var buttonImageMappings = new List<(Button button, Image normal, Image hover, EventHandler extraMouseEnterEvent, EventHandler extraMouseLeaveEvent)>
            {
                (startButton, Resources.start_idle, Resources.start_hover_lit, StartButtonExtraLogic, null),
                (exitButton, Resources.door_closed, Resources.door_open, MenuButtonEnterExtraLogic, MenuButtonLeaveExtraLogic),
                (minimizeButton, Resources.arrow_blue, Resources.arrow_yellow, MenuButtonEnterExtraLogic, MenuButtonLeaveExtraLogic),
                (settingsButton, Resources.scroll_closed_res2, Resources.scroll_open, MenuButtonEnterExtraLogic, MenuButtonLeaveExtraLogic),
                (aboutButton, Resources.i_bubble, Resources.q_bubble, MenuButtonEnterExtraLogic, MenuButtonLeaveExtraLogic),
                (auButton, Resources.crystal_normal_res, Resources.crystal_lit, MenuButtonEnterExtraLogic, MenuButtonLeaveExtraLogic)
            };

            RegisterButtonImagesBulk(buttonImageMappings);

            RegisterMouseDrag(new List<Control> { pictureBox1, operationsPanel, optionsPanel, gameInfoPanel, patchInfoPanel });

            this.Layout += OnOperationLabelChange;
            operationLabel.TextChanged += OnOperationLabelChange;


            logger = new Logger("ReTLInstaller.log", outputTextBox, toolStripStatusLabel1);
            logger.StartSession();

        }

        // Functions

        private void StartButtonExtraLogic(object sender, EventArgs e)
        {
            if (sender is Button button && !button.Enabled)
            {
                button.BackgroundImage = Resources.start_idle; // Ensure it does not change when disabled
            }
        }

        private void MenuButtonEnterExtraLogic(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                var menuButtonLabels = new List<(Button menuButton, string name)>
        {
            (exitButton, "Exit Application"),
            (minimizeButton, "Minimize Application"),
            (aboutButton, "Help / About"),
            (auButton, "Create AutoUpdater Shortcut"),
            (settingsButton, "Settings")
        };

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

        private void MenuButtonLeaveExtraLogic(object sender, EventArgs e)
        {
            menuButtonLabel.Visible = false;
        }

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
            Height = 580;
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
            latestVersionLinkLabel.Text = latestVersionValid ? latestVersion : "ERROR!";

            (latestModLoaderVersion, commitSha) = installer.GetLatestModloaderRelease();
            latestModloaderVersionLabel.Text = latestModLoaderVersion != null ? latestModLoaderVersion : "ERROR!";
            if (commitSha != null) toolTip.SetToolTip(latestModloaderVersionLabel, $"Commit SHA: {commitSha}");

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

            if (versioncompare == 0 && !modLoaderOutdated && latestModLoaderVersion != null) logger.Log("You already have the latest translation patch version installed!", "success", true);

            startButton.Enabled = (!latestVersionValid || latestModLoaderVersion == null ) ? false : helper.isAnyChecked(operationCheckboxes);
        }

        private void UpdateUI()
        {
            string githubAPIToken = Helper.DecryptString(Settings.Default.GithubAPIKey);
            (bool tokenvalid, _) = Helper.ValidateGitHubToken(githubAPIToken);
            if (!string.IsNullOrEmpty(githubAPIToken) && !tokenvalid) logger.Log("Github API token invalid or expired! Please check and reset it!", "error");

            (localVersion, localVersionValid) = installer.GetInstalledPatchVersion();
            (localModLoaderVersion, localModLoaderVersionValid)= installer.GetInstalledModloaderVersion();

            installCheckBox.Text = localVersionValid ? " Update" : " Install";

            localVersionLabel.Text = localVersion;
            localModloaderVersionLabel.Text = localModLoaderVersion;

            versioncompare = localVersion.CompareTo(latestVersion);
            //if ((!localVersionValid || versioncompare != 0) && priconnePathValid) installCheckBox.Enabled = true; else installCheckBox.Enabled = false;
            if ((!localVersionValid || versioncompare != 0) && priconnePathValid)
            {
                installCheckBox.Enabled = true;
                installCheckBox.Checked = true;
            }
            else installCheckBox.Enabled = false;


            if (localVersionValid && localModLoaderVersionValid)
            {
                if (latestModLoaderVersion != null) (modLoaderOutdated, modLoaderTooltip) = helper.CompareGameandModloaderVersions(gameVersion, localModLoaderVersion, latestModLoaderVersion);
                if (modLoaderOutdated)
                {
                    logger.Log($"Modloader check failed!", "error", true);
                    logger.Log($"{modLoaderTooltip}", "error", false);
                }
                modExPicture.Visible = modLoaderOutdated;
                toolTip.SetToolTip(modExPicture, modLoaderTooltip);
            }

            newPatchPictureBox.Visible = localVersion == latestVersion ? false : true;

            SetUninstallandReinstallCheckBox(localVersionValid);
            UpdateModeDescription();

            helper.PopulateConfigChecklistbox(configListBox);

            removeConfigCheckBox.Enabled = false;
            removeIgnoredCheckBox.Enabled = false;

            if (!latestVersionValid || latestModLoaderVersion == null)
            {
                foreach (CheckBox checkBox in operationCheckboxes)
                {
                    checkBox.Enabled = false;
                }
                startButton.Enabled = false;
                return;
            }
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
                    this.Height = checkBox.Checked ? 860 : 580;
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

        private void OnProcessStart()
        {
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel3.Text = "";
            outputTextBox.Clear();
            startButton.Enabled = false;
            auButton.Enabled = false;
            settingsButton.Enabled = false;
            helpMenuStrip.Items["checkForInstallerUpdatesToolStripMenuItem"].Enabled = false;
            helpMenuStrip.Items["githubAPIRateLimitInfoToolStripMenuItem"].Enabled = false;
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
            helpMenuStrip.Items["checkForInstallerUpdatesToolStripMenuItem"].Enabled = true;
            helpMenuStrip.Items["githubAPIRateLimitInfoToolStripMenuItem"].Enabled = true;
            startButton.BackgroundImage = Resources.start_complete;
            reinstallCheckBox.Checked = false;
            uninstallCheckBox.Checked = false;
            UpdateUI();
        }
        private void startButton_Click_1(object sender, EventArgs e)
        {

            if(!Helper.IsGameRunning(priconnePath)) 
                installer.ProcessOperation(assetLink, installCheckBox.Checked, uninstallCheckBox.Checked, reinstallCheckBox.Checked, launchCheckBox.Checked, removeConfigCheckBox.Checked, configListBox, removeIgnoredCheckBox.Checked);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
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
            MessageBox.Show($"[PriconneReTL Updater version: {String.Format(Application.ProductVersion)}]\n"
            + Settings.Default.aboutText, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            currentLauncherLinkLabel.Text = "Launcher: " + (Settings.Default.selectedLauncher == 0 ? "DMMGamePlayer" : "DMMGamePlayerFastLauncher");
            checkForInstallerUpdatesToolStripMenuItem.Checked = Settings.Default.checkForInstallerUpdates;

        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Settings.Default.checkForInstallerUpdates)
            {
                try
                {
                    (string version, string body, string installerAssetlink, bool versionValid) = installer.GetLatestInstallerRelease();
                    helper.CheckForInstallerUpdate(version, body, installerAssetlink, versionValid);
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
            if (checkForInstallerUpdatesToolStripMenuItem.Checked)
            {
                (string version, string body, string installerAssetlink, bool versionValid) = installer.GetLatestInstallerRelease();
                helper.CheckForInstallerUpdate(version, body, installerAssetlink, versionValid);
            }
        }

        private void githubAPIRateLimitInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (int remaining, DateTime resetTime, TimeSpan timeUntilReset, string username) = Helper.CheckGithubRateLimit();
            string auth = username == null ? "No" : $"Yes (Username: {username})";
            MessageBox.Show($"Github API rate limit info:\n\nAuthenticated: {auth}\nRemaining API calls: {remaining}\nResets at: {resetTime}, in: {timeUntilReset:mm\\:ss}", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gitHubAPISettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GithubForm GitHubForm = new GithubForm();
            GitHubForm.ShowDialog();
        }
    }
}



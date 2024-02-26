using HelperFunctions;
using InstallerFunctions;
using PriconneReTLInstaller.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriconneReTLInstaller;
using LoggerFunctions;
using System.Diagnostics;

namespace PriconneReTLInstaller
{
    public partial class AUForm : BaseForm
    {
        private string auGithubApi = Settings.Default.auGithubApi;
        private string auAppGithubApi = Settings.Default.auAppGithubApi;
        private string priconnePath;
        private bool priconnePathValid;
        private string auAssetLink;
        private string auAppAssetLink;
        private string auLocalVersion;
        private bool auLocalVersionValid;
        private string auAppLocalVersion;
        private bool auAppLocalVersionValid;
        private string auLatestVersion;
        private bool auLatestVersionValid;
        private string auAppLatestVersion;
        private bool auAppLatestVersionValid;

        private Logger aulogger;
        public AUForm(string arg1)
        {
            InitializeComponent();

            backButton.MouseEnter += OnButtonMouseEnter;
            backButton.MouseLeave += OnButtonMouseLeave;

            installer.Log += OnLog;
            installer.ErrorLog += OnErrorLog;
            installer.DownloadProgress += OnDownloadProgress;
            installer.ProcessStart += OnProcessStart;
            installer.ProcessFinish += OnProcessFinish;

            helper.Log += OnLog;
            helper.ErrorLog += OnErrorLog;

            aulogger = new Logger("ReTLInstaller.log", outputTextBox, toolStripStatusLabel1);
        }

        private void OnLog(string message, string color, bool writeToToolStrip = false)
        {
            outputTextBox.Invoke((Action)(() =>
            {
                aulogger.Log(message, color, writeToToolStrip);
            }));
        }

        private void OnErrorLog(string message)
        {
            outputTextBox.Invoke((Action)(() =>
            {
                aulogger.Error(message);
            }));

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

        public void OnProcessStart()
        {
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel3.Text = "";
            outputTextBox.Clear();
        }

        public void OnProcessFinish()
        {
            UpdateUI();
        }
        public void UpdateUI()
        {
            (auLocalVersion, auLocalVersionValid) = installer.GetAULocalVersion(priconnePath, "PriconneReTLAutoUpdater.dll");
            (auAppLocalVersion, auAppLocalVersionValid) = installer.GetAULocalVersion(priconnePath, "PriconneReTLAutoUpdaterApp.exe");

            auVersionLabel.Text = $"Local: {auLocalVersion} | Latest: {auLatestVersion}";
            auAppVersionLabel.Text = $"Local: {auAppLocalVersion} | Latest: {auAppLatestVersion}";

            installButton.Enabled = (auLocalVersion == auLatestVersion) && (auAppLocalVersion == auAppLatestVersion) ? false : true ;
            uninstallButton.Enabled = auAppLocalVersionValid && auAppLatestVersionValid;
        }

        private void OnButtonMouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == backButton) button.BackgroundImage = Resources.back_arrow_lit;
            }
        }

        private void OnButtonMouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == backButton) button.BackgroundImage = Resources.back_arrow;
            }
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AUForm_Load(object sender, EventArgs e)
        {
            (priconnePath, priconnePathValid) = installer.GetGamePath();

            (auLatestVersion, auLatestVersionValid, auAssetLink) = installer.GetLatestRelease(auGithubApi);
            (auAppLatestVersion, auAppLatestVersionValid,auAppAssetLink) = installer.GetLatestRelease(auAppGithubApi);

            UpdateUI();
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            installer.ProcessAuInstallOperation(auAssetLink, auAppAssetLink);
        }

        private void uninstallButton_Click(object sender, EventArgs e)
        {
            installer.ProcessAuUninstallOperation();
        }
        private void installButton_EnabledChanged(object sender, EventArgs e)
        {
            installButton.BackgroundImage = installButton.Enabled ? Resources.install_button2 : Resources.install_button_disabled2;
        }

        private void uninstallButton_EnabledChanged(object sender, EventArgs e)
        {
            uninstallButton.BackgroundImage = uninstallButton.Enabled ? Resources.uninstall_button : Resources.uninstall_button_disabled;
        }

        private void auLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/tynave/PriconneReTL-AutoUpdater");
        }

        private void auAppLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/tynave/PriconneReTL-AutoUpdaterApp");
        }
    }
}

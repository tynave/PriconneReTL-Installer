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
using LoggerFunctions;
using PriconneReTLInstaller.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PriconneReTLInstaller
{
    public partial class SelfUpdateForm : BaseForm
    {
        private Logger updatelogger;
        private string latestAvailableVersion;
        private string releaseBody;
        private string assetLink;
        public SelfUpdateForm(string version, string body, string assetLink)
        {
            InitializeComponent();

            installer.Log += OnLog;
            installer.ErrorLog += OnErrorLog;
            helper.Log += OnLog;
            helper.ErrorLog += OnErrorLog;

            downloadButton.MouseEnter += OnButtonMouseEnter;
            downloadButton.MouseLeave += OnButtonMouseLeave;

            cancelButton.MouseEnter += OnButtonMouseEnter;
            cancelButton.MouseLeave += OnButtonMouseLeave;

            latestAvailableVersion = version;
            releaseBody = body;
            this.assetLink = assetLink;
            currentVersionLabel.Text = "Current Version: " + String.Format(Application.ProductVersion);
            latestVersionLabel.Text = "Latest Available Version: " + latestAvailableVersion;

            checkForUpdatesCheckbox.Checked = Settings.Default.checkForInstallerUpdates;

            updatelogger = new Logger("ReTLInstaller.log", null, toolStripStatusLabel1);
        }

        private void OnButtonMouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == downloadButton) button.BackgroundImage = Resources.dlbutton_lit;
                if (button == cancelButton) button.BackgroundImage = Resources.cancel_lit;
            
            }
        }

        private void OnButtonMouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == downloadButton) button.BackgroundImage = Resources.dlbutton;
                if (button == cancelButton) button.BackgroundImage = Resources.cancel;

            }
        }

        public void OnLog(string message, string color, bool writeToToolStrip = false)
        {
                updatelogger.Log(message, color, writeToToolStrip);
        }

        private void OnErrorLog(string message)
        {
                updatelogger.Error(message);
        }

        private void ParseMarkdownToRichTextBox(string markdown)
        {
            // Split lines to process them one by one
            string[] lines = markdown.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                if (line.StartsWith("### "))
                {
                    // This is a header, apply bold formatting
                    string headerText = line.Substring(4); // Remove '### ' from the start
                    AppendFormattedText(headerText, FontStyle.Underline, 12, Color.Blue);
                }
                else
                {
                    // For other lines, append normally
                    AppendFormattedText(line, FontStyle.Regular, 10, Color.Black);
                }

                // Add a new line
                changeLogRichTextbox.AppendText(Environment.NewLine);
            }
        }
        private void AppendFormattedText(string text, FontStyle style, float fontSize, Color color)
        {
            // Save the current text length (used to select and format later)
            int start = changeLogRichTextbox.TextLength;

            // Append the text
            changeLogRichTextbox.AppendText(text);

            // Select the newly added text
            changeLogRichTextbox.Select(start, text.Length);

            // Apply the specified style and font size
            changeLogRichTextbox.SelectionFont = new Font(changeLogRichTextbox.Font.FontFamily, fontSize, style);
            changeLogRichTextbox.SelectionColor = color;


            // Deselect the text
            changeLogRichTextbox.SelectionLength = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkForUpdatesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            checkForUpdatesCheckbox.Image = checkForUpdatesCheckbox.Checked ? Resources.check_checked_24x24_2 : Resources.check_empty_24x24_2;
            Settings.Default.checkForInstallerUpdates = checkForUpdatesCheckbox.Checked;
            Settings.Default.Save();
            
        }

        private void SelfUpdateForm_Load(object sender, EventArgs e)
        {
            ParseMarkdownToRichTextBox(releaseBody);
            changeLogRichTextbox.SelectionStart = 0;
            changeLogRichTextbox.ScrollToCaret(); // Ensure the view scrolls to the caret
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            installer.ProcessInstallerUpdateOperation(assetLink, saveFileDialog1, this);
        }
    }
}

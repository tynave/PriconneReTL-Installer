using LoggerFunctions;
using PriconneReTLInstaller.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriconneReTLInstaller
{
    public partial class LauncherForm : BaseForm
    {
        public LauncherForm()
        {
            InitializeComponent();

            RegisterMouseDrag(new List<Control> { panel1, panel2 });

            var buttonImageMappings = new List<(Button button, Image normal, Image hover, EventHandler extraMouseEnterEvent, EventHandler extraMouseLeaveEvent)>
            {
                (backButton, Resources.back_arrow, Resources.back_arrow_lit, null, null),
                (shortcutAddButton, Resources.shortcutadd_button, Resources.shortcutadd_button_lit, null, null),
                (shortcutRemoveButton, Resources.shortcutremove_button, Resources.shortcutremove_button_lit, null, null),
            };

            RegisterButtonImagesBulk(buttonImageMappings);
        }

        // ─── Migration helper: move legacy single-string setting into the list ───
        private void MigrateLegacyLink()
        {
            string legacy = Settings.Default.fastLauncherLink;
            if (!string.IsNullOrEmpty(legacy))
            {
                var links = GetLinks();
                if (!links.Contains(legacy))
                {
                    links.Add(legacy);
                    SaveLinks(links);
                }
                // Clear legacy value so we don't migrate again
                Settings.Default.fastLauncherLink = "";
                Settings.Default.Save();
            }
        }

        // ─── Helpers: read/write list from Settings ───────────────────────────────
        private List<string> GetLinks()
        {
            var col = Settings.Default.fastLauncherLinks;
            if (col == null) return new List<string>();
            return col.Cast<string>().ToList();
        }

        private void SaveLinks(List<string> links)
        {
            var col = new StringCollection();
            col.AddRange(links.ToArray());
            Settings.Default.fastLauncherLinks = col;
            Settings.Default.Save();
        }

        // ─── UI Initialization ────────────────────────────────────────────────────
        private void InitializeUI()
        {
            helper.PopulateLauncherComboBox(launcherComboBox);
            if (Settings.Default.selectedLauncher >= 0 && Settings.Default.selectedLauncher < launcherComboBox.Items.Count)
                launcherComboBox.SelectedIndex = Settings.Default.selectedLauncher;
            else
                launcherComboBox.SelectedIndex = 0;
        }

        private void UpdateUI()
        {
            int selected = launcherComboBox.SelectedIndex;
            bool needsLink = (selected == 1 || selected == 2);

            // Label above shortcuts panel
            if (selected == 1)
                setFastlauncherLinkLabel.Text = "Set DMMGamePlayerFastLauncher shortcuts:";
            else if (selected == 2)
                setFastlauncherLinkLabel.Text = "Set PriconneMultiLauncher shortcuts:";
            else
                setFastlauncherLinkLabel.Text = "No shortcut configuration needed:";

            // Warning label
            if (selected == 1 && !helper.IsFastLauncherInstalled())
            {
                dmmfastlauncherLabel.Text = "DMMGamePlayerFastLauncher not installed! Falling back to DMMGamePlayer!";
                dmmfastlauncherLabel.Visible = true;
                shortcutAddButton.Enabled = false;
                shortcutRemoveButton.Enabled = false;
            }
            else if (selected == 2 && !helper.IsPriconneMultiLauncherInstalled())
            {
                dmmfastlauncherLabel.Text = "PriconneMultiLauncher not installed! Falling back to DMMGamePlayer!";
                dmmfastlauncherLabel.Visible = true;
                shortcutAddButton.Enabled = false;
                shortcutRemoveButton.Enabled = false;
            }
            else
            {
                dmmfastlauncherLabel.Visible = false;
                shortcutAddButton.Enabled = needsLink;
                shortcutRemoveButton.Enabled = needsLink && (shortcutListBox.SelectedIndex >= 0);
            }

            // Refresh list box
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            shortcutListBox.Items.Clear();
            var links = GetLinks();
            if (links.Count == 0)
            {
                shortcutListBox.Items.Add("(No shortcuts set)");
                shortcutListBox.Enabled = false;
            }
            else
            {
                foreach (var link in links)
                    shortcutListBox.Items.Add(link);
                shortcutListBox.Enabled = true;
            }
        }

        // ─── Button Handlers ──────────────────────────────────────────────────────
        private void backButton_Click(object sender, EventArgs e) => this.Close();

        private void shortcutAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog1.Multiselect = true;   // allow picking multiple .lnk files at once
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var links = GetLinks();
                    foreach (string file in openFileDialog1.FileNames)
                    {
                        if (!links.Contains(file))
                            links.Add(file);
                    }
                    SaveLinks(links);
                    UpdateUI();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot add shortcut!\nException: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcutRemoveButton_Click(object sender, EventArgs e)
        {
            int idx = shortcutListBox.SelectedIndex;
            if (idx < 0) return;

            var links = GetLinks();
            if (idx < links.Count)
            {
                links.RemoveAt(idx);
                SaveLinks(links);
                UpdateUI();
            }
        }

        private void shortcutAddButton_EnabledChanged(object sender, EventArgs e)
        {
            shortcutAddButton.BackgroundImage = shortcutAddButton.Enabled
                ? Resources.shortcutadd_button
                : Resources.shortcutadd_button_disabled;
        }

        private void shortcutRemoveButton_EnabledChanged(object sender, EventArgs e)
        {
            shortcutRemoveButton.BackgroundImage = shortcutRemoveButton.Enabled
                ? Resources.shortcutremove_button
                : Resources.shortcutremove_button_disabled;
        }

        private void FastLauncherForm_Load(object sender, EventArgs e)
        {
            MigrateLegacyLink();
            InitializeUI();
            UpdateUI();
        }

        private void launcherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.selectedLauncher = launcherComboBox.SelectedIndex;
            Settings.Default.Save();
            UpdateUI();
        }

        private void shortcutListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable Remove button only when a real item is selected
            int selected = launcherComboBox.SelectedIndex;
            bool needsLink = (selected == 1 || selected == 2);
            shortcutRemoveButton.Enabled = needsLink
                && shortcutListBox.Enabled
                && (shortcutListBox.SelectedIndex >= 0);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Settings.Default.selectedLauncher = launcherComboBox.SelectedIndex;
            Settings.Default.Save();
            MessageBox.Show($"Launcher set to: {launcherComboBox.SelectedItem}", "Launcher Set!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveButton_EnabledChanged(object sender, EventArgs e) { }
    }
}

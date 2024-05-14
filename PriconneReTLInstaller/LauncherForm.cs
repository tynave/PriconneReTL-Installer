using LoggerFunctions;
using PriconneReTLInstaller.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            
            backButton.MouseEnter += OnButtonMouseEnter;
            backButton.MouseLeave += OnButtonMouseLeave;

            shortcutAddButton.MouseEnter += OnButtonMouseEnter;
            shortcutAddButton.MouseLeave += OnButtonMouseLeave;

            shortcutRemoveButton.MouseEnter += OnButtonMouseEnter;
            shortcutRemoveButton.MouseLeave += OnButtonMouseLeave;

            panel1.MouseDown += OnMouseDown;
            panel1.MouseMove += OnMouseMove;
            panel1.MouseUp += OnMouseUp;

            panel2.MouseDown += OnMouseDown;
            panel2.MouseMove += OnMouseMove;
            panel2.MouseUp += OnMouseUp;

        }

        private void OnButtonMouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == backButton) button.BackgroundImage = Resources.back_arrow_lit;
                if (button == shortcutAddButton) button.BackgroundImage = Resources.shortcutadd_button_lit;
                if (button == shortcutRemoveButton && button.Enabled) button.BackgroundImage = Resources.shortcutremove_button_lit;
            }
        }

        private void OnButtonMouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == backButton) button.BackgroundImage = Resources.back_arrow;
                if (button == shortcutAddButton) button.BackgroundImage = Resources.shortcutadd_button;
                if (button == shortcutRemoveButton && button.Enabled) button.BackgroundImage = Resources.shortcutremove_button;
            }
        }

        private void InitializeUI()
        {
            if (!helper.IsFastLauncherInstalled())
            {
                if (Settings.Default.selectedLauncher == 1)
                {
                    Settings.Default.selectedLauncher = 0;
                    Settings.Default.Save();
                }

                dmmfastlauncherLabel.Visible = true;
                shortcutAddButton.Enabled = false;
                shortcutRemoveButton.Enabled = false;
            }

            helper.PopulateLauncherComboBox(launcherComboBox);
            launcherComboBox.SelectedIndex = Settings.Default.selectedLauncher;
        }
        private void UpdateUI()
        {
            shortcutPathLabel.Text = Settings.Default.fastLauncherLink == "" ? "Not Set!" : Settings.Default.fastLauncherLink;
            shortcutRemoveButton.Enabled = Settings.Default.fastLauncherLink == "" ? false : true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void shortcutAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog1.FileName;
                    Settings.Default.fastLauncherLink = selectedFile;
                    Settings.Default.Save();
                    UpdateUI();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot set shortcut!\nException: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcutAddButton_EnabledChanged(object sender, EventArgs e)
        {
            shortcutAddButton.BackgroundImage = shortcutAddButton.Enabled ? Resources.shortcutadd_button : Resources.shortcutadd_button_disabled;
        }

        private void shortcutRemoveButton_EnabledChanged(object sender, EventArgs e)
        {
            shortcutRemoveButton.BackgroundImage = shortcutRemoveButton.Enabled ? Resources.shortcutremove_button : Resources.shortcutremove_button_disabled;

        }

        private void FastLauncherForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            UpdateUI();
        }

        private void shortcutRemoveButton_Click(object sender, EventArgs e)
        {
            Settings.Default.fastLauncherLink = "";
            Settings.Default.Save();
            UpdateUI();
            
        }

        private void launcherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.selectedLauncher = launcherComboBox.SelectedIndex;
            Settings.Default.Save();
            UpdateUI();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Settings.Default.selectedLauncher = launcherComboBox.SelectedIndex;
            MessageBox.Show($"Launcher set to: {launcherComboBox.SelectedItem.ToString()}", "Launcher Set!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Settings.Default.Save();
        }

        private void saveButton_EnabledChanged(object sender, EventArgs e)
        {

        }
    }

}

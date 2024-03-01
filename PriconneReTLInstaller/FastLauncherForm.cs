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
    public partial class FastLauncherForm : BaseForm
    {
        public FastLauncherForm()
        {
            InitializeComponent();
            
            backButton.MouseEnter += OnButtonMouseEnter;
            backButton.MouseLeave += OnButtonMouseLeave;

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

        private void UpdateUI()
        {
            shortcutPathLabel.Text = Settings.Default.fastLauncherLink == "" ? "<Not Set!>" : Settings.Default.fastLauncherLink;
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
            UpdateUI();
        }

        private void shortcutRemoveButton_Click(object sender, EventArgs e)
        {
            Settings.Default.fastLauncherLink = "";
            Settings.Default.Save();
            UpdateUI();
            
        }
    }

}

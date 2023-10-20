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
    public partial class SettingsForm : BaseForm
    {
        private string defaultPath;
        private StringCollection ignoreFilesCollection;
        public SettingsForm(string arg)
        {
            InitializeComponent();

            backButton.MouseEnter += OnButtonMouseEnter;
            backButton.MouseLeave += OnButtonMouseLeave;

            fileListbox.MouseDown += OnMouseDown;
            fileListbox.MouseMove += OnMouseMove;
            fileListbox.MouseUp += OnMouseUp;

            defaultPath = arg;
            openFileDialog1.InitialDirectory = defaultPath;
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

        private void CreateFileList()
        {
            ignoreFilesCollection = Settings.Default.ignoreFiles;

            foreach (string item in Settings.Default.ignoreFiles)
            {
                fileListbox.Items.Add(item);
            }
        }
       
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            CreateFileList();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ignoreFilesCollection.Clear();

                foreach (var item in fileListbox.Items)
                {
                    ignoreFilesCollection.Add(item.ToString());
                }

                Settings.Default.ignoreFiles = ignoreFilesCollection;
                Settings.Default.Save();
                MessageBox.Show("Ignore list saved!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                saveButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot save list!\nException: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void defaultsButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogresult = MessageBox.Show("Do you really want to restore the default values?\nAll unsaved changes will be lost.", "Restore defaults?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogresult == DialogResult.Cancel) return;

                var serializedDefaultValue = Settings.Default.Properties["ignoreFiles"].DefaultValue as string;

                var defaultValue = HelperFunctions.Helper.DeserializeStringCollection(serializedDefaultValue);

                fileListbox.Items.Clear();

                foreach (string value in defaultValue)
                {
                    Console.WriteLine(value);
                    fileListbox.Items.Add(value);
                }
                fileListbox.SelectedIndex = -1;
                removeButton.Enabled = false;
                saveButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot restore defaults!\nException: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog1.FileName;
                    if (!HelperFunctions.Helper.IsFileInSubfolder(defaultPath, selectedFile)) 
                    {
                        MessageBox.Show("Invalid selection!\nPlease select a file that is in the Princess Connect Re:Dive game folder!", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } 
                    string relativePath = HelperFunctions.Helper.GetRelativePath(defaultPath, selectedFile);
                    fileListbox.Items.Add(relativePath);
                    saveButton.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot add item!\nException: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileListbox.Items.Remove(fileListbox.SelectedItem);
                saveButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot remove item. Exception: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fileListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeButton.Enabled = fileListbox.SelectedIndex != -1 ? true : false;
        }

        private void addButton_EnabledChanged(object sender, EventArgs e)
        {
            addButton.BackgroundImage = addButton.Enabled ? Resources.add_button : Resources.add_button_disabled;
        }

        private void removeButton_EnabledChanged(object sender, EventArgs e)
        {
            removeButton.BackgroundImage = removeButton.Enabled ? Resources.remove_button : Resources.remove_button_disabled;
        }

        private void saveButton_EnabledChanged(object sender, EventArgs e)
        {
            saveButton.BackgroundImage = saveButton.Enabled ? Resources.save_button : Resources.save_button_disabled;
        }

        private void SettingsForm_Click(object sender, EventArgs e)
        {
            fileListbox.ClearSelected();
        }
    }
}

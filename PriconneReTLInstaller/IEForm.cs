﻿using LoggerFunctions;
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
    public partial class IEForm : BaseForm
    {
        private Logger ielogger;
        private string priconnePath;
        public IEForm(string arg)
        {
            InitializeComponent();

            RegisterMouseDrag(new List<Control> { importExportLabel, importExportDescriptionLabel });


            var buttonImageMappings = new List<(Button button, Image normal, Image hover, EventHandler extraMouseEnterEvent, EventHandler extraMouseLeaveEvent)>
            {
                (backButton, Resources.back_arrow, Resources.back_arrow_lit, null, null),
                (importButton, Resources.import_button, Resources.import_button_lit, null, null),
                (exportButton, Resources.export_button, Resources.export_button_lit, null, null),
            };

            RegisterButtonImagesBulk(buttonImageMappings);


            priconnePath = arg;

            ielogger = new Logger("ReTLInstaller.log", null , toolStripStatusLabel1);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = saveFileDialog1.FileName;
                    helper.ExportSettings(selectedFile);
                    ielogger.Log("Export Successful!", "success", true);
                    ielogger.Log($"Settings successfully exported to ${selectedFile}", "info", false);
                    MessageBox.Show("Settings successfully exported", "Export Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during export!\n\nException: {ex.Message}\n\nStack trace: {ex.StackTrace}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ielogger.Error($"Error during export!\n\nException: {ex.Message}\n\nStack trace: {ex.StackTrace}");
            }

        }

        private void importButton_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog1.FileName;
                    helper.ImportSettings(selectedFile);
                    ielogger.Log("Import Successful!", "success", true);
                    ielogger.Log($"Settings successfully imported from ${selectedFile}", "info", false);
                    MessageBox.Show("Settings successfully imported!\n\nThe application will now restart.", "Import Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during import!\n\nException: {ex.Message}\n\nStack trace: {ex.StackTrace}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ielogger.Error($"Error during import!\n\nException: {ex.Message}\n\nStack trace: {ex.StackTrace}");
            }
        }
    }
}

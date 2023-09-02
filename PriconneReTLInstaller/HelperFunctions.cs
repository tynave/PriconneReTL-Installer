using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PriconneReTLInstaller.Properties;

namespace HelperFunctions
{   

    class Helper
    {
        public event Action<string, string, bool> Log;
        public event Action<string> ErrorLog;

        //PrivateFontCollection priconnefont = new PrivateFontCollection();
        public void PriconneFont(PrivateFontCollection priconnefont)
        {
            //Select  font from the resources.
            int fontLength = Resources.Humming.Length;

            // create a buffer to read in to
            byte[] fontdata = Resources.Humming;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            priconnefont.AddMemoryFont(data, fontLength);

        }
        public void SetFontForAllControls(PrivateFontCollection priconnefont, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Check if the control is a ToolStrip
                if (control is ToolStrip toolStrip)
                {
                    SetFontForToolStripItems(priconnefont, toolStrip.Items);
                }
                else
                {
                    control.Font = new Font(priconnefont.Families[0], control.Font.Size, FontStyle.Bold, GraphicsUnit.Point, 1);
                }

                // Check if the control has child controls
                if (control.Controls.Count > 0)
                {
                    // If it has child controls, call SetFontForAllControls recursively
                    SetFontForAllControls(priconnefont, control.Controls);
                }
            }
        }
        public void SetFontForToolStripItems(PrivateFontCollection priconnefont, ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                // Check if the item is a ToolStripLabel
                if (item is ToolStripLabel toolStripLabel)
                {
                    toolStripLabel.Font = new Font(priconnefont.Families[0], toolStripLabel.Font.Size, FontStyle.Bold, GraphicsUnit.Point, 1);
                }
                else if (item is ToolStripDropDownItem dropDownItem)
                {
                    // If the item is a drop-down item (e.g., ToolStripDropDownButton, ToolStripMenuItem), handle its subitems recursively
                    SetFontForToolStripItems(priconnefont, dropDownItem.DropDownItems);
                }
            }
        }

        public string[] SetIgnoreFiles(string priconnePath, bool addconfig)
        {
            string[] ignoreFiles = new string[Settings.Default.ignoreFiles.Count];
            Settings.Default.ignoreFiles.CopyTo(ignoreFiles, 0);

            if (addconfig)
            {
                List<string> ignoreFilesList = new List<string>(ignoreFiles);

                foreach (var configFile in Settings.Default.configFiles)
                {
                    if (File.Exists(Path.Combine(priconnePath, configFile)))
                    {
                        ignoreFilesList.Add(configFile);
                    }
                }

                ignoreFiles = ignoreFilesList.ToArray();
            }

            return ignoreFiles;
        }

        public bool IsConfigPresent(string priconnePath)
        {
            bool isConfigPresent = false;
            foreach (var configFile in Settings.Default.configFiles)
            {
                if (File.Exists(Path.Combine(priconnePath, configFile)))
                {
                    isConfigPresent = true;

                }
            }

            if (isConfigPresent) Log?.Invoke("Found config file(s). Adding them to the list of ignored/excluded files.", "error", false);
            return isConfigPresent;
        }

        public void CannotExitNotification(FormClosingEventArgs e, string type)
        {
            MessageBox.Show($"There is currently a {type} process in progress.\nPlease wait for the operation to complete.", "Cannot Exit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = true;
        }
    }
}
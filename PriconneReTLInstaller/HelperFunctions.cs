using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using LoggerFunctions;
using PriconneReTLInstaller;
using PriconneReTLInstaller.Properties;

namespace HelperFunctions
{   
    public class Helper
    {
        public event Action<string, string, bool> Log;
        public event Action<string> ErrorLog;

        [DllImport("gdi32.dll")]
        public static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

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

            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontdata.Length, IntPtr.Zero, ref cFonts);

            // pass the font to the font collection
            priconnefont.AddMemoryFont(data, fontLength);

            Marshal.FreeCoTaskMem(data);

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

        public bool isAnyChecked(CheckBox[] checkboxes)
        {
            if (checkboxes != null)
            {
                foreach (CheckBox checkbox in checkboxes) if (checkbox.Checked) return true;
            }
            return false;
        }

        public string[] SetIgnoreFiles(string priconnePath, bool addconfig)
        {
            string[] ignoreFiles = new string[Settings.Default.ignoreFiles.Count];
            Settings.Default.ignoreFiles.CopyTo(ignoreFiles, 0);

            foreach (var item in ignoreFiles)
            {
                Console.WriteLine(item);
            }

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
        public bool IsGameRunning()
        {
            // Get a list of all running processes with the specified name
            Process[] processes = Process.GetProcessesByName("PrincessConnectReDive");

            // Check if any processes with the given name are running
            return processes.Length > 0;
        }

        public bool IsFastLauncherInstalled()
        {
            try
            {
                string dmmFastLauncherPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DMMGamePlayerFastLauncher");
                string dmmFastLauncherExe = Path.Combine(dmmFastLauncherPath, "DMMGamePlayerFastLauncher.exe");

                if (File.Exists(dmmFastLauncherExe)) return true; else return false;
            }
            catch (Exception ex)
            {
                ErrorLog?.Invoke("Error checking DMMGamePlayerFastlauncher: " + ex.Message);
                return false;
            }
        }

        public bool IsFastLauncherShortcutValid() 
        {
            string fastLauncherLink = Settings.Default.fastLauncherLink;

            if (!File.Exists(fastLauncherLink))
            {          
                DialogResult result = MessageBox.Show(Settings.Default.cannotStartDMMFastLauncherError, "Cannot Start Game", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                
                if (result == DialogResult.OK)
                {
                    FastLauncherForm fastLauncherForm = new FastLauncherForm();
                    fastLauncherForm.ShowDialog();
                    return false;
                }
                else if (result == DialogResult.Cancel) return false;
            }
            return true;
        }


        public void LogFastLauncherShortcut()
        {
            string fastLauncherShortcut = Settings.Default.fastLauncherLink;

            if (fastLauncherShortcut == "") Log?.Invoke("DMMGamePlayerFastLauncher link not set!", "info", false);
            else Log?.Invoke("DMMGamePlayerFastLauncher link path: " + fastLauncherShortcut, "info", false);
        }

        public void PopulateLauncherComboBox(ComboBox comboBox)
        {
            
            comboBox.Items.Clear();
            comboBox.Items.Add("DMMGamePlayer");

            if (IsFastLauncherInstalled()) 
            { 
                comboBox.Items.Add("DMMGamePlayerFastLauncher");
                Log?.Invoke("Found DMMGamePlayerFastLauncher!", "info", false);
            } else Log?.Invoke("DMMGamePlayerFastLauncher not installed!", "info", false);

            if (comboBox.Items.Count > 0) comboBox.SelectedIndex = IsFastLauncherInstalled() ? 1 : 0;
        }

        public static bool IsFileInSubfolder(string folderPath, string filePath)
        {
            folderPath = Path.GetFullPath(folderPath); // Ensure the folder path is full.
            filePath = Path.GetFullPath(filePath);     // Ensure the file path is full.

            // Check if the file path starts with the folder path.
            return filePath.StartsWith(folderPath, StringComparison.OrdinalIgnoreCase);
        }

        public static StringCollection DeserializeStringCollection(string serializedValue)
        {
            var stringCollection = new StringCollection();
            var serializer = new XmlSerializer(stringCollection.GetType());

            using (var reader = new XmlTextReader(new System.IO.StringReader(serializedValue)))
            {
                if (serializer.CanDeserialize(reader))
                {
                    stringCollection = (StringCollection)serializer.Deserialize(reader);
                }
            }

            return stringCollection;
        }
        public static string GetRelativePath(string fromPath, string toPath)
        {
            fromPath = fromPath.Replace("\\", "/");
            toPath = toPath.Replace("\\", "/");

            if (!toPath.StartsWith(fromPath, StringComparison.OrdinalIgnoreCase))
            {
                // If toPath is not under fromPath, return the full toPath.
                return toPath;
            }

            int fromPathLength = fromPath.Length;
            if (fromPathLength < toPath.Length)
            {
                // Exclude the common portion and the path separator if it exists
                string relativePath = toPath.Substring(fromPathLength).TrimStart('/');
                return relativePath;
            }

            // If fromPath is the same as toPath, return an empty string
            return string.Empty;
        }
    }
}
﻿using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PriconneReTLInstaller.Properties;

namespace HelperFunctions
{   

    class Helper
    {
        PrivateFontCollection priconnefont = new PrivateFontCollection();
        public void PriconneFont()
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
        public void SetFontForAllControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Check if the control is a ToolStrip
                if (control is ToolStrip toolStrip)
                {
                    SetFontForToolStripItems(toolStrip.Items);
                }
                else
                {
                    control.Font = new Font(priconnefont.Families[0], control.Font.Size, FontStyle.Bold, GraphicsUnit.Point, 1);
                }

                // Check if the control has child controls
                if (control.Controls.Count > 0)
                {
                    // If it has child controls, call SetFontForAllControls recursively
                    SetFontForAllControls(control.Controls);
                }
            }
        }
        public void SetFontForToolStripItems(ToolStripItemCollection items)
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
                    SetFontForToolStripItems(dropDownItem.DropDownItems);
                }
            }
        }
    }
}
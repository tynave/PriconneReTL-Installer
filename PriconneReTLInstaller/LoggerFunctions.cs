using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System;

namespace LoggerFunctions 
{
    public class Logger
    {
        private string logFilePath;
        private Dictionary<string, Color> colors = new Dictionary<string, Color>
            {
                { "info", Color.Black },
                { "error", Color.Red },
                { "success", Color.Green },
                { "add", Color.Blue },
                { "remove", Color.Red },
            };
        private RichTextBox outputTextBox;
        private ToolStripStatusLabel toolStripStatusLabel1;

        public Logger(string logFilePath, RichTextBox outputTextBox, ToolStripStatusLabel toolStripStatusLabel1)
        {
            this.logFilePath = logFilePath;
            this.outputTextBox = outputTextBox;
            this.toolStripStatusLabel1 = toolStripStatusLabel1;
        }

        public void StartSession()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, false))
                {
                    writer.WriteLine($"[PriconneReTL Installer version: {String.Format(System.Windows.Forms.Application.ProductVersion)}]");
                    writer.WriteLine($"[Log file created at: {DateTime.Now}]");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing log file: {ex.Message}");
            }
        }

        public void Log(string message, string level, bool writeToToolStrip = false)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true)) writer.WriteLine($"[{DateTime.Now}] - {message}");

                if (outputTextBox != null && !outputTextBox.IsDisposed) outputTextBox.AppendText($"[{DateTime.Now}] - {message}" + Environment.NewLine, colors[level]);

                if (writeToToolStrip)
                {
                    toolStripStatusLabel1.ForeColor = colors[level];
                    toolStripStatusLabel1.Text = message;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }

        public void Error(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true)) writer.WriteLine($"[{DateTime.Now}] - ERROR: {message}");

                if (outputTextBox != null && !outputTextBox.IsDisposed) outputTextBox.AppendText($"[{DateTime.Now}] - ERROR:" + Environment.NewLine + message + Environment.NewLine, colors["error"]);

                toolStripStatusLabel1.ForeColor = colors["error"];
                toolStripStatusLabel1.Text = $"ERROR! - See log for details.";


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }

    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
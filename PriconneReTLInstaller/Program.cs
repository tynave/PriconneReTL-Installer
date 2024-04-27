using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriconneReTLInstaller
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0 && args[0] == "autoupdate")
            {
                // Instantiate and show the form you want to start with
                Application.Run(new AutoUpdateForm());
            }
            else
            {
                // Start with the default form
                Application.Run(new MainForm());
            }

            Application.Run(new MainForm());
        }
    }
}

using HelperFunctions;
using InstallerFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriconneReTLInstaller
{
    public partial class AUForm : Form
    {
        PrivateFontCollection priconnefont = new PrivateFontCollection();
        private bool mouseDown;
        private Point lastLocation;

        Helper helper = new Helper();
        Installer installer = new Installer();
        public AUForm()
        {
            InitializeComponent();

            helper.PriconneFont(priconnefont);
            helper.SetFontForAllControls(priconnefont, Controls);

            this.MouseDown += OnMouseDown;
            this.MouseMove += OnMouseMove;
            this.MouseUp += OnMouseUp;
        }

        private async void OnMouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;

            await Task.Run(() =>
            {
                while (mouseDown)
                {
                    this.Invoke((Action)(() =>
                    {
                        this.Location = new Point(
                            (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                        this.Update();
                    }));
                }
            });
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {

            if (mouseDown)
            {
                this.Invoke((Action)(() =>
                {
                    this.Location = new Point(
                        (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                    this.Update();
                }));
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

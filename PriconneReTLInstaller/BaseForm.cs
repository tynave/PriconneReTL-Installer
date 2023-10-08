using HelperFunctions;
using InstallerFunctions;
using LoggerFunctions;
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
    public partial class BaseForm : Form
    {
        protected bool mouseDown = false;
        protected Point lastLocation;
        protected PrivateFontCollection priconnefont = new PrivateFontCollection();

        protected Installer installer = new Installer();
        protected Helper helper = new Helper();

        protected Logger logger;

        public BaseForm()
        {
            InitializeComponent();

            this.MouseDown += OnMouseDown;
            this.MouseMove += OnMouseMove;
            this.MouseUp += OnMouseUp;

        }

        protected async void OnMouseDown(object sender, MouseEventArgs e)
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

        protected void OnMouseMove(object sender, MouseEventArgs e)
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

        protected void OnMouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            helper.PriconneFont(priconnefont);
            helper.SetFontForAllControls(priconnefont, Controls);
        }
    }
}

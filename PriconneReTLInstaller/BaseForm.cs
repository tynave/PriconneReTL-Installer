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

        protected void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }

        protected void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    this.Location.X + e.X - lastLocation.X,
                    this.Location.Y + e.Y - lastLocation.Y
                );
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

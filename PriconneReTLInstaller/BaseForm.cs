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

        private readonly Dictionary<Button, (Image normal, Image hover)> buttonImages = new Dictionary<Button, (Image, Image)>();

        public BaseForm()
        {
            InitializeComponent();

            this.MouseDown += OnMouseDown;
            this.MouseMove += OnMouseMove;
            this.MouseUp += OnMouseUp;

        }

        protected void RegisterMouseDrag(List<Control> controls)
        {
            foreach (Control control in controls) 
            {
                control.MouseDown += OnMouseDown;
                control.MouseMove += OnMouseMove;
                control.MouseUp += OnMouseUp;
            }
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

        protected void RegisterButtonImages(Button button, Image normal, Image hover, EventHandler extraMouseEnterLogic = null, EventHandler extraMouseLeaveLogic = null)
        {
            buttonImages[button] = (normal, hover);
            button.MouseEnter += OnButtonMouseEnter;
            button.MouseLeave += OnButtonMouseLeave;

            if (extraMouseEnterLogic != null)
                button.MouseEnter += extraMouseEnterLogic;

            if (extraMouseLeaveLogic != null)
                button.MouseLeave += extraMouseLeaveLogic;
        }

        protected void RegisterButtonImagesBulk(List<(Button button, Image normal, Image hover, EventHandler extraMouseEnterlogic, EventHandler extraMouseLeaveLogic)> buttonList)
        {
            foreach (var (button, normal, hover, extramouseenterlogic, extramouseleavelogic) in buttonList)
            {
                RegisterButtonImages(button, normal, hover, extramouseenterlogic, extramouseleavelogic);
            }
        }

        private void OnButtonMouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button && buttonImages.TryGetValue(button, out var images))
            {
                button.BackgroundImage = images.hover;
            }
        }

        private void OnButtonMouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button && buttonImages.TryGetValue(button, out var images))
            {
                button.BackgroundImage = images.normal;
            }
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            helper.PriconneFont(priconnefont);
            helper.SetFontForAllControls(priconnefont, Controls);
        }
    }
}

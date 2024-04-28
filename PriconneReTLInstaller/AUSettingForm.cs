using System;
using PriconneReTLInstaller.Properties;
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
    public partial class AUSettingForm : BaseForm
    {
        public AUSettingForm()
        {
            InitializeComponent();

            backButton.MouseEnter += OnButtonMouseEnter;
            backButton.MouseLeave += OnButtonMouseLeave;
        }

        private void OnButtonMouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == backButton) button.BackgroundImage = Resources.back_arrow_lit;

            }
        }

        private void OnButtonMouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == backButton) button.BackgroundImage = Resources.back_arrow;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AUSettingForm_Load(object sender, EventArgs e)
        {
            helper.PopulateLauncherComboBox(launcherComboBox);
        }
    }

}

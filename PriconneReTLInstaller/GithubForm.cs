using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelperFunctions;
using Newtonsoft.Json.Linq;
using PriconneReTLInstaller.Properties;

namespace PriconneReTLInstaller
{
    public partial class GithubForm: BaseForm
    {
        public GithubForm()
        {
            InitializeComponent();

            var buttonImageMappings = new List<(Button button, Image normal, Image hover, EventHandler extraMouseEnterEvent, EventHandler extraMouseLeaveEvent)>
            {
                (backButton, Resources.back_arrow, Resources.back_arrow_lit, null, null),
                (saveButton, Resources.savetokenbutton, Resources.savetokenbutton_lit, null, null),
                (validateButton, Resources.validatetokenbutton, Resources.validatetokenbutton_lit, null, null),
                //(clearButton, Resources.cleartokenbutton, Resources.cleartokenbutton_lit, null, null)
            };

            RegisterButtonImagesBulk(buttonImageMappings);
        }

        private void InitializeUI()
        {
            apiKeyTextbox.Text = Helper.DecryptString(Settings.Default.GithubAPIKey);
            if (apiKeyTextbox.Text == "") validateButton.Enabled = false;
            saveButton.Enabled = false;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GithubForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.GithubAPIKey = Helper.EncryptString(apiKeyTextbox.Text);
                Settings.Default.Save();
                MessageBox.Show("API key saved!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                saveButton.Enabled = false;
                validateButton.Enabled = string.IsNullOrEmpty(Settings.Default.GithubAPIKey) ? false : true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot save API key!\nException: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void apiKeyTextbox_TextChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
        }

        private void saveButton_EnabledChanged(object sender, EventArgs e)
        {
            saveButton.BackgroundImage = saveButton.Enabled ? Resources.savetokenbutton : Resources.savetokenbutton_disabled;
        }

        private void validateButton_EnabledChanged(object sender, EventArgs e)
        {
            validateButton.BackgroundImage = validateButton.Enabled ? Resources.validatetokenbutton : Resources.validatetokenbutton_disabled;
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            string githubToken = Helper.DecryptString(Settings.Default.GithubAPIKey);
            (bool tokenvalid, string username) = Helper.ValidateGitHubToken(githubToken);
            if (tokenvalid) MessageBox.Show($"Token valid!\n\nUsername: {username}", "Token validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                Settings.Default.GithubAPIKey = "";
                Settings.Default.Save();
                apiKeyTextbox.Text = "";
                MessageBox.Show($"Token invalid! Clearing saved token!", "Token validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                saveButton.Enabled = false;
                validateButton.Enabled = false;
            }
        }
    }
}

namespace PriconneReTLInstaller
{
    partial class GithubForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.apiKeyTextbox = new System.Windows.Forms.TextBox();
            this.gitHubApiKeyLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.validateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.savetokenbutton_disabled;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveButton.Enabled = false;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(76, 80);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(152, 48);
            this.saveButton.TabIndex = 11;
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.EnabledChanged += new System.EventHandler(this.saveButton_EnabledChanged);
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // apiKeyTextbox
            // 
            this.apiKeyTextbox.Location = new System.Drawing.Point(12, 42);
            this.apiKeyTextbox.Name = "apiKeyTextbox";
            this.apiKeyTextbox.Size = new System.Drawing.Size(643, 20);
            this.apiKeyTextbox.TabIndex = 8;
            this.apiKeyTextbox.TextChanged += new System.EventHandler(this.apiKeyTextbox_TextChanged);
            // 
            // gitHubApiKeyLabel
            // 
            this.gitHubApiKeyLabel.AutoSize = true;
            this.gitHubApiKeyLabel.BackColor = System.Drawing.Color.Transparent;
            this.gitHubApiKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gitHubApiKeyLabel.Location = new System.Drawing.Point(10, 16);
            this.gitHubApiKeyLabel.Name = "gitHubApiKeyLabel";
            this.gitHubApiKeyLabel.Size = new System.Drawing.Size(117, 16);
            this.gitHubApiKeyLabel.TabIndex = 7;
            this.gitHubApiKeyLabel.Text = "GitHub API Token:";
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.back_arrow;
            this.backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.backButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.backButton.Location = new System.Drawing.Point(616, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(39, 28);
            this.backButton.TabIndex = 6;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // validateButton
            // 
            this.validateButton.BackColor = System.Drawing.Color.Transparent;
            this.validateButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.validatetokenbutton;
            this.validateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.validateButton.FlatAppearance.BorderSize = 0;
            this.validateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.validateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.validateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.validateButton.Location = new System.Drawing.Point(365, 80);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(152, 48);
            this.validateButton.TabIndex = 12;
            this.validateButton.UseVisualStyleBackColor = false;
            this.validateButton.EnabledChanged += new System.EventHandler(this.validateButton_EnabledChanged);
            this.validateButton.Click += new System.EventHandler(this.validateButton_Click);
            // 
            // GithubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(675, 154);
            this.ControlBox = false;
            this.Controls.Add(this.validateButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.apiKeyTextbox);
            this.Controls.Add(this.gitHubApiKeyLabel);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GithubForm";
            this.Load += new System.EventHandler(this.GithubForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label gitHubApiKeyLabel;
        private System.Windows.Forms.TextBox apiKeyTextbox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button validateButton;
    }
}
namespace PriconneReTLInstaller
{
    partial class IgnoreForm
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
            this.defaultsButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.ignoreFilesLabel = new System.Windows.Forms.Label();
            this.fileListbox = new System.Windows.Forms.ListBox();
            this.backButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // defaultsButton
            // 
            this.defaultsButton.BackColor = System.Drawing.Color.Transparent;
            this.defaultsButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.defaults_button;
            this.defaultsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.defaultsButton.FlatAppearance.BorderSize = 0;
            this.defaultsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.defaultsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.defaultsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defaultsButton.Location = new System.Drawing.Point(489, 300);
            this.defaultsButton.Name = "defaultsButton";
            this.defaultsButton.Size = new System.Drawing.Size(152, 48);
            this.defaultsButton.TabIndex = 9;
            this.defaultsButton.UseVisualStyleBackColor = false;
            this.defaultsButton.Click += new System.EventHandler(this.defaultsButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.Transparent;
            this.removeButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.remove_button_disabled;
            this.removeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.removeButton.Enabled = false;
            this.removeButton.FlatAppearance.BorderSize = 0;
            this.removeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.removeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.Location = new System.Drawing.Point(173, 300);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(152, 48);
            this.removeButton.TabIndex = 8;
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.EnabledChanged += new System.EventHandler(this.removeButton_EnabledChanged);
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.add_button;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Location = new System.Drawing.Point(15, 300);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(152, 48);
            this.addButton.TabIndex = 7;
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.EnabledChanged += new System.EventHandler(this.addButton_EnabledChanged);
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // ignoreFilesLabel
            // 
            this.ignoreFilesLabel.AutoSize = true;
            this.ignoreFilesLabel.BackColor = System.Drawing.Color.Transparent;
            this.ignoreFilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ignoreFilesLabel.Location = new System.Drawing.Point(12, 12);
            this.ignoreFilesLabel.Name = "ignoreFilesLabel";
            this.ignoreFilesLabel.Size = new System.Drawing.Size(451, 16);
            this.ignoreFilesLabel.TabIndex = 6;
            this.ignoreFilesLabel.Text = "Ignored Files (paths relative to the Princess Connect Re:Dive game folder): ";
            // 
            // fileListbox
            // 
            this.fileListbox.FormattingEnabled = true;
            this.fileListbox.Location = new System.Drawing.Point(15, 37);
            this.fileListbox.Name = "fileListbox";
            this.fileListbox.Size = new System.Drawing.Size(626, 251);
            this.fileListbox.TabIndex = 5;
            this.fileListbox.SelectedIndexChanged += new System.EventHandler(this.fileListbox_SelectedIndexChanged);
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
            this.backButton.Location = new System.Drawing.Point(629, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(39, 28);
            this.backButton.TabIndex = 4;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.save_button_disabled;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveButton.Enabled = false;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(331, 300);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(152, 48);
            this.saveButton.TabIndex = 10;
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.EnabledChanged += new System.EventHandler(this.saveButton_EnabledChanged);
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "All Files|*.*";
            // 
            // IgnoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(676, 360);
            this.ControlBox = false;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.defaultsButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.ignoreFilesLabel);
            this.Controls.Add(this.fileListbox);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "IgnoreForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.Click += new System.EventHandler(this.SettingsForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ListBox fileListbox;
        private System.Windows.Forms.Label ignoreFilesLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button defaultsButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
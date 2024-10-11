namespace PriconneReTLInstaller
{
    partial class SelfUpdateForm
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
            this.newVersionLabel = new System.Windows.Forms.Label();
            this.currentVersionLabel = new System.Windows.Forms.Label();
            this.latestVersionLabel = new System.Windows.Forms.Label();
            this.changeLogRichTextbox = new System.Windows.Forms.RichTextBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.checkForUpdatesCheckbox = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // newVersionLabel
            // 
            this.newVersionLabel.AutoSize = true;
            this.newVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.newVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newVersionLabel.Location = new System.Drawing.Point(86, 9);
            this.newVersionLabel.Name = "newVersionLabel";
            this.newVersionLabel.Size = new System.Drawing.Size(414, 24);
            this.newVersionLabel.TabIndex = 13;
            this.newVersionLabel.Text = "New version of PriconneReTL-Installer available!";
            // 
            // currentVersionLabel
            // 
            this.currentVersionLabel.AutoSize = true;
            this.currentVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currentVersionLabel.Location = new System.Drawing.Point(12, 54);
            this.currentVersionLabel.Name = "currentVersionLabel";
            this.currentVersionLabel.Size = new System.Drawing.Size(125, 17);
            this.currentVersionLabel.TabIndex = 14;
            this.currentVersionLabel.Text = "Current version:";
            // 
            // latestVersionLabel
            // 
            this.latestVersionLabel.AutoSize = true;
            this.latestVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.latestVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.latestVersionLabel.Location = new System.Drawing.Point(12, 78);
            this.latestVersionLabel.Name = "latestVersionLabel";
            this.latestVersionLabel.Size = new System.Drawing.Size(189, 17);
            this.latestVersionLabel.TabIndex = 15;
            this.latestVersionLabel.Text = "Latest Version Available:";
            // 
            // changeLogRichTextbox
            // 
            this.changeLogRichTextbox.Location = new System.Drawing.Point(15, 110);
            this.changeLogRichTextbox.Name = "changeLogRichTextbox";
            this.changeLogRichTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.changeLogRichTextbox.Size = new System.Drawing.Size(550, 160);
            this.changeLogRichTextbox.TabIndex = 16;
            this.changeLogRichTextbox.Text = "";
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.Transparent;
            this.downloadButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.dlbutton;
            this.downloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.downloadButton.FlatAppearance.BorderSize = 0;
            this.downloadButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.downloadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.Location = new System.Drawing.Point(90, 320);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(179, 57);
            this.downloadButton.TabIndex = 17;
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.cancel;
            this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(312, 320);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(179, 57);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // checkForUpdatesCheckbox
            // 
            this.checkForUpdatesCheckbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkForUpdatesCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.checkForUpdatesCheckbox.FlatAppearance.BorderSize = 0;
            this.checkForUpdatesCheckbox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.checkForUpdatesCheckbox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.checkForUpdatesCheckbox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.checkForUpdatesCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkForUpdatesCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkForUpdatesCheckbox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.checkForUpdatesCheckbox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkForUpdatesCheckbox.Location = new System.Drawing.Point(15, 278);
            this.checkForUpdatesCheckbox.Name = "checkForUpdatesCheckbox";
            this.checkForUpdatesCheckbox.Size = new System.Drawing.Size(550, 36);
            this.checkForUpdatesCheckbox.TabIndex = 30;
            this.checkForUpdatesCheckbox.Text = " Check for application updates on startup";
            this.checkForUpdatesCheckbox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.checkForUpdatesCheckbox.UseVisualStyleBackColor = false;
            this.checkForUpdatesCheckbox.CheckedChanged += new System.EventHandler(this.checkForUpdatesCheckbox_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(593, 23);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(146, 18);
            this.toolStripStatusLabel1.Text = "Choose an option!";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(432, 18);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 18);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "PriconneReTLInstaller.zip";
            this.saveFileDialog1.Filter = "ZIP files (*.zip)|*.zip";
            // 
            // SelfUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(593, 413);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkForUpdatesCheckbox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.changeLogRichTextbox);
            this.Controls.Add(this.latestVersionLabel);
            this.Controls.Add(this.currentVersionLabel);
            this.Controls.Add(this.newVersionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SelfUpdateForm";
            this.Load += new System.EventHandler(this.SelfUpdateForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newVersionLabel;
        private System.Windows.Forms.Label currentVersionLabel;
        private System.Windows.Forms.Label latestVersionLabel;
        private System.Windows.Forms.RichTextBox changeLogRichTextbox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox checkForUpdatesCheckbox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
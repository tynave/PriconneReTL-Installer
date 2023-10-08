namespace PriconneReTLInstaller
{
    partial class AUForm
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
            this.installButton = new System.Windows.Forms.Button();
            this.uninstallButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.auVersionLabel = new System.Windows.Forms.Label();
            this.auAppVersionLabel = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // installButton
            // 
            this.installButton.BackColor = System.Drawing.Color.Transparent;
            this.installButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.install_button;
            this.installButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.installButton.FlatAppearance.BorderSize = 0;
            this.installButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.installButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.installButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.installButton.Location = new System.Drawing.Point(73, 36);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(266, 72);
            this.installButton.TabIndex = 0;
            this.installButton.UseVisualStyleBackColor = false;
            this.installButton.EnabledChanged += new System.EventHandler(this.installButton_EnabledChanged);
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // uninstallButton
            // 
            this.uninstallButton.BackColor = System.Drawing.Color.Transparent;
            this.uninstallButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.uninstall_button;
            this.uninstallButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uninstallButton.FlatAppearance.BorderSize = 0;
            this.uninstallButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.uninstallButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.uninstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uninstallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uninstallButton.Location = new System.Drawing.Point(359, 37);
            this.uninstallButton.Name = "uninstallButton";
            this.uninstallButton.Size = new System.Drawing.Size(266, 72);
            this.uninstallButton.TabIndex = 1;
            this.uninstallButton.UseVisualStyleBackColor = false;
            this.uninstallButton.EnabledChanged += new System.EventHandler(this.uninstallButton_EnabledChanged);
            this.uninstallButton.Click += new System.EventHandler(this.uninstallButton_Click);
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
            this.backButton.Location = new System.Drawing.Point(633, 7);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(39, 28);
            this.backButton.TabIndex = 3;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // auVersionLabel
            // 
            this.auVersionLabel.AutoSize = true;
            this.auVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.auVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.auVersionLabel.Location = new System.Drawing.Point(123, 128);
            this.auVersionLabel.Name = "auVersionLabel";
            this.auVersionLabel.Size = new System.Drawing.Size(135, 16);
            this.auVersionLabel.TabIndex = 4;
            this.auVersionLabel.Text = "AutoUpdater Version:";
            // 
            // auAppVersionLabel
            // 
            this.auAppVersionLabel.AutoSize = true;
            this.auAppVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.auAppVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.auAppVersionLabel.Location = new System.Drawing.Point(123, 158);
            this.auAppVersionLabel.Name = "auAppVersionLabel";
            this.auAppVersionLabel.Size = new System.Drawing.Size(160, 16);
            this.auAppVersionLabel.TabIndex = 5;
            this.auAppVersionLabel.Text = "AutoUpdaterApp Version:";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.outputTextBox.HideSelection = false;
            this.outputTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.outputTextBox.Location = new System.Drawing.Point(22, 192);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(633, 97);
            this.outputTextBox.TabIndex = 14;
            this.outputTextBox.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 318);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(681, 29);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 24);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(509, 24);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 23);
            this.toolStripProgressBar1.Step = 1;
            // 
            // AUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(681, 347);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.auAppVersionLabel);
            this.Controls.Add(this.auVersionLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.uninstallButton);
            this.Controls.Add(this.installButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AUForm";
            this.Load += new System.EventHandler(this.AUForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button uninstallButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label auVersionLabel;
        private System.Windows.Forms.Label auAppVersionLabel;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}
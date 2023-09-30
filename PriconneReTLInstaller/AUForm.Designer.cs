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
            this.statusLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
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
            this.uninstallButton.Location = new System.Drawing.Point(73, 129);
            this.uninstallButton.Name = "uninstallButton";
            this.uninstallButton.Size = new System.Drawing.Size(266, 72);
            this.uninstallButton.TabIndex = 1;
            this.uninstallButton.UseVisualStyleBackColor = false;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusLabel.Location = new System.Drawing.Point(3, 227);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(410, 17);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "< status >";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.backButton.Location = new System.Drawing.Point(373, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(39, 28);
            this.backButton.TabIndex = 3;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // AUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(417, 263);
            this.ControlBox = false;
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.uninstallButton);
            this.Controls.Add(this.installButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AUForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button uninstallButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button backButton;
    }
}
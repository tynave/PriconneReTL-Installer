namespace PriconneReTLInstaller
{
    partial class AUSettingForm
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
            this.backButton = new System.Windows.Forms.Button();
            this.selectLauncherLabel = new System.Windows.Forms.Label();
            this.launcherComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            this.backButton.Location = new System.Drawing.Point(537, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(39, 28);
            this.backButton.TabIndex = 4;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // selectLauncherLabel
            // 
            this.selectLauncherLabel.AutoSize = true;
            this.selectLauncherLabel.BackColor = System.Drawing.Color.Transparent;
            this.selectLauncherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.selectLauncherLabel.Location = new System.Drawing.Point(21, 64);
            this.selectLauncherLabel.Name = "selectLauncherLabel";
            this.selectLauncherLabel.Size = new System.Drawing.Size(144, 16);
            this.selectLauncherLabel.TabIndex = 5;
            this.selectLauncherLabel.Text = "AutoUpdater Launcher:";
            // 
            // launcherComboBox
            // 
            this.launcherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.launcherComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.launcherComboBox.FormattingEnabled = true;
            this.launcherComboBox.Location = new System.Drawing.Point(171, 64);
            this.launcherComboBox.Name = "launcherComboBox";
            this.launcherComboBox.Size = new System.Drawing.Size(303, 24);
            this.launcherComboBox.TabIndex = 34;
            // 
            // AUSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(587, 147);
            this.ControlBox = false;
            this.Controls.Add(this.launcherComboBox);
            this.Controls.Add(this.selectLauncherLabel);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AUSettingForm";
            this.Load += new System.EventHandler(this.AUSettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label selectLauncherLabel;
        private System.Windows.Forms.ComboBox launcherComboBox;
    }
}
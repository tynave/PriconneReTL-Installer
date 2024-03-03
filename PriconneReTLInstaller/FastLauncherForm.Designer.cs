namespace PriconneReTLInstaller
{
    partial class FastLauncherForm
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
            this.setFastLauncherLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.shortcutLabel = new System.Windows.Forms.Label();
            this.shortcutAddButton = new System.Windows.Forms.Button();
            this.shortcutRemoveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.shortcutPathLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // setFastLauncherLabel
            // 
            this.setFastLauncherLabel.AutoSize = true;
            this.setFastLauncherLabel.BackColor = System.Drawing.Color.Transparent;
            this.setFastLauncherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.setFastLauncherLabel.Location = new System.Drawing.Point(12, 12);
            this.setFastLauncherLabel.Name = "setFastLauncherLabel";
            this.setFastLauncherLabel.Size = new System.Drawing.Size(235, 16);
            this.setFastLauncherLabel.TabIndex = 6;
            this.setFastLauncherLabel.Text = "Set DMMGameFastLauncher shortcut: ";
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
            this.backButton.Location = new System.Drawing.Point(605, 6);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(39, 28);
            this.backButton.TabIndex = 5;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // shortcutLabel
            // 
            this.shortcutLabel.AutoSize = true;
            this.shortcutLabel.BackColor = System.Drawing.Color.Transparent;
            this.shortcutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.shortcutLabel.Location = new System.Drawing.Point(12, 50);
            this.shortcutLabel.Name = "shortcutLabel";
            this.shortcutLabel.Size = new System.Drawing.Size(87, 16);
            this.shortcutLabel.TabIndex = 7;
            this.shortcutLabel.Text = "Shortcut path:";
            // 
            // shortcutAddButton
            // 
            this.shortcutAddButton.BackColor = System.Drawing.Color.Transparent;
            this.shortcutAddButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.shortcutadd_button;
            this.shortcutAddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.shortcutAddButton.FlatAppearance.BorderSize = 0;
            this.shortcutAddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.shortcutAddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.shortcutAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shortcutAddButton.Location = new System.Drawing.Point(31, 92);
            this.shortcutAddButton.Name = "shortcutAddButton";
            this.shortcutAddButton.Size = new System.Drawing.Size(152, 48);
            this.shortcutAddButton.TabIndex = 8;
            this.shortcutAddButton.UseVisualStyleBackColor = false;
            this.shortcutAddButton.EnabledChanged += new System.EventHandler(this.shortcutAddButton_EnabledChanged);
            this.shortcutAddButton.Click += new System.EventHandler(this.shortcutAddButton_Click);
            // 
            // shortcutRemoveButton
            // 
            this.shortcutRemoveButton.BackColor = System.Drawing.Color.Transparent;
            this.shortcutRemoveButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.shortcutremove_button_disabled;
            this.shortcutRemoveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.shortcutRemoveButton.Enabled = false;
            this.shortcutRemoveButton.FlatAppearance.BorderSize = 0;
            this.shortcutRemoveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.shortcutRemoveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.shortcutRemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shortcutRemoveButton.Location = new System.Drawing.Point(203, 92);
            this.shortcutRemoveButton.Name = "shortcutRemoveButton";
            this.shortcutRemoveButton.Size = new System.Drawing.Size(152, 48);
            this.shortcutRemoveButton.TabIndex = 9;
            this.shortcutRemoveButton.UseVisualStyleBackColor = false;
            this.shortcutRemoveButton.EnabledChanged += new System.EventHandler(this.shortcutRemoveButton_EnabledChanged);
            this.shortcutRemoveButton.Click += new System.EventHandler(this.shortcutRemoveButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Shortcut files (*.lnk)|*.lnk";
            // 
            // shortcutPathLabel
            // 
            this.shortcutPathLabel.AutoSize = true;
            this.shortcutPathLabel.BackColor = System.Drawing.Color.Transparent;
            this.shortcutPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.shortcutPathLabel.Location = new System.Drawing.Point(143, 50);
            this.shortcutPathLabel.Name = "shortcutPathLabel";
            this.shortcutPathLabel.Size = new System.Drawing.Size(65, 16);
            this.shortcutPathLabel.TabIndex = 10;
            this.shortcutPathLabel.Text = "<Not Set>";
            // 
            // FastLauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(653, 161);
            this.ControlBox = false;
            this.Controls.Add(this.shortcutPathLabel);
            this.Controls.Add(this.shortcutRemoveButton);
            this.Controls.Add(this.shortcutAddButton);
            this.Controls.Add(this.shortcutLabel);
            this.Controls.Add(this.setFastLauncherLabel);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FastLauncherForm";
            this.Load += new System.EventHandler(this.FastLauncherForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label setFastLauncherLabel;
        private System.Windows.Forms.Label shortcutLabel;
        private System.Windows.Forms.Button shortcutAddButton;
        private System.Windows.Forms.Button shortcutRemoveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label shortcutPathLabel;
    }
}
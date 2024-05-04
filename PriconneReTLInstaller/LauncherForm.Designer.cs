namespace PriconneReTLInstaller
{
    partial class LauncherForm
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
            this.setLauncherLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.shortcutLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.shortcutPathLabel = new System.Windows.Forms.Label();
            this.launcherComboBox = new System.Windows.Forms.ComboBox();
            this.setFastlauncherLinkLabel = new System.Windows.Forms.Label();
            this.dmmfastlauncherLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.launcherLabel = new System.Windows.Forms.Label();
            this.currentLauncherLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.shortcutAddButton = new System.Windows.Forms.Button();
            this.shortcutRemoveButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // setLauncherLabel
            // 
            this.setLauncherLabel.AutoSize = true;
            this.setLauncherLabel.BackColor = System.Drawing.Color.Transparent;
            this.setLauncherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.setLauncherLabel.Location = new System.Drawing.Point(11, 6);
            this.setLauncherLabel.Name = "setLauncherLabel";
            this.setLauncherLabel.Size = new System.Drawing.Size(141, 16);
            this.setLauncherLabel.TabIndex = 6;
            this.setLauncherLabel.Text = "Select launcher to use:";
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
            this.backButton.Location = new System.Drawing.Point(589, 7);
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
            this.shortcutLabel.Location = new System.Drawing.Point(10, 88);
            this.shortcutLabel.Name = "shortcutLabel";
            this.shortcutLabel.Size = new System.Drawing.Size(87, 16);
            this.shortcutLabel.TabIndex = 7;
            this.shortcutLabel.Text = "Shortcut path:";
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
            this.shortcutPathLabel.Location = new System.Drawing.Point(103, 88);
            this.shortcutPathLabel.Name = "shortcutPathLabel";
            this.shortcutPathLabel.Size = new System.Drawing.Size(65, 16);
            this.shortcutPathLabel.TabIndex = 10;
            this.shortcutPathLabel.Text = "<Not Set>";
            // 
            // launcherComboBox
            // 
            this.launcherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.launcherComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.launcherComboBox.FormattingEnabled = true;
            this.launcherComboBox.Location = new System.Drawing.Point(14, 29);
            this.launcherComboBox.Name = "launcherComboBox";
            this.launcherComboBox.Size = new System.Drawing.Size(303, 24);
            this.launcherComboBox.TabIndex = 34;
            this.launcherComboBox.SelectedIndexChanged += new System.EventHandler(this.launcherComboBox_SelectedIndexChanged);
            // 
            // setFastlauncherLinkLabel
            // 
            this.setFastlauncherLinkLabel.AutoSize = true;
            this.setFastlauncherLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.setFastlauncherLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.setFastlauncherLinkLabel.Location = new System.Drawing.Point(10, 5);
            this.setFastlauncherLinkLabel.Name = "setFastlauncherLinkLabel";
            this.setFastlauncherLinkLabel.Size = new System.Drawing.Size(271, 16);
            this.setFastlauncherLinkLabel.TabIndex = 35;
            this.setFastlauncherLinkLabel.Text = "Set DMMGamePlayerFastLauncher shortcut:";
            // 
            // dmmfastlauncherLabel
            // 
            this.dmmfastlauncherLabel.BackColor = System.Drawing.Color.Transparent;
            this.dmmfastlauncherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dmmfastlauncherLabel.ForeColor = System.Drawing.Color.Red;
            this.dmmfastlauncherLabel.Location = new System.Drawing.Point(12, 110);
            this.dmmfastlauncherLabel.Name = "dmmfastlauncherLabel";
            this.dmmfastlauncherLabel.Size = new System.Drawing.Size(570, 22);
            this.dmmfastlauncherLabel.TabIndex = 36;
            this.dmmfastlauncherLabel.Text = "DMMGamePlayerFastLauncher not installed! Falling back to DMMGamePlayer!";
            this.dmmfastlauncherLabel.Visible = false;
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
            this.saveButton.Location = new System.Drawing.Point(351, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(152, 48);
            this.saveButton.TabIndex = 37;
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.EnabledChanged += new System.EventHandler(this.saveButton_EnabledChanged);
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // launcherLabel
            // 
            this.launcherLabel.AutoSize = true;
            this.launcherLabel.BackColor = System.Drawing.Color.Transparent;
            this.launcherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.launcherLabel.Location = new System.Drawing.Point(11, 61);
            this.launcherLabel.Name = "launcherLabel";
            this.launcherLabel.Size = new System.Drawing.Size(127, 16);
            this.launcherLabel.TabIndex = 38;
            this.launcherLabel.Text = "Current launcher set:";
            // 
            // currentLauncherLabel
            // 
            this.currentLauncherLabel.AutoSize = true;
            this.currentLauncherLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentLauncherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currentLauncherLabel.Location = new System.Drawing.Point(144, 61);
            this.currentLauncherLabel.Name = "currentLauncherLabel";
            this.currentLauncherLabel.Size = new System.Drawing.Size(115, 16);
            this.currentLauncherLabel.TabIndex = 39;
            this.currentLauncherLabel.Text = "DMMGamePlayer";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.setLauncherLabel);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.launcherLabel);
            this.panel1.Controls.Add(this.currentLauncherLabel);
            this.panel1.Controls.Add(this.launcherComboBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 90);
            this.panel1.TabIndex = 40;
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
            this.shortcutAddButton.Location = new System.Drawing.Point(13, 31);
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
            this.shortcutRemoveButton.Location = new System.Drawing.Point(177, 31);
            this.shortcutRemoveButton.Name = "shortcutRemoveButton";
            this.shortcutRemoveButton.Size = new System.Drawing.Size(152, 48);
            this.shortcutRemoveButton.TabIndex = 9;
            this.shortcutRemoveButton.UseVisualStyleBackColor = false;
            this.shortcutRemoveButton.EnabledChanged += new System.EventHandler(this.shortcutRemoveButton_EnabledChanged);
            this.shortcutRemoveButton.Click += new System.EventHandler(this.shortcutRemoveButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.shortcutPathLabel);
            this.panel2.Controls.Add(this.shortcutLabel);
            this.panel2.Controls.Add(this.setFastlauncherLinkLabel);
            this.panel2.Controls.Add(this.shortcutRemoveButton);
            this.panel2.Controls.Add(this.shortcutAddButton);
            this.panel2.Location = new System.Drawing.Point(12, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 112);
            this.panel2.TabIndex = 41;
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(640, 261);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dmmfastlauncherLabel);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LauncherForm";
            this.Load += new System.EventHandler(this.FastLauncherForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label setLauncherLabel;
        private System.Windows.Forms.Label shortcutLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label shortcutPathLabel;
        private System.Windows.Forms.ComboBox launcherComboBox;
        private System.Windows.Forms.Label setFastlauncherLinkLabel;
        private System.Windows.Forms.Label dmmfastlauncherLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label launcherLabel;
        private System.Windows.Forms.Label currentLauncherLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button shortcutAddButton;
        private System.Windows.Forms.Button shortcutRemoveButton;
        private System.Windows.Forms.Panel panel2;
    }
}
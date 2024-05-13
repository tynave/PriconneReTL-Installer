namespace PriconneReTLInstaller
{
    partial class AutoUpdateForm
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
            this.components = new System.ComponentModel.Container();
            this.localVersionLabel = new System.Windows.Forms.Label();
            this.gamePathLinkLabel = new System.Windows.Forms.LinkLabel();
            this.newPictureBox = new System.Windows.Forms.PictureBox();
            this.latestVersionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gameVersionLabel = new System.Windows.Forms.Label();
            this.progressPicture = new System.Windows.Forms.PictureBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.newPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // localVersionLabel
            // 
            this.localVersionLabel.AutoSize = true;
            this.localVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.localVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.localVersionLabel.Location = new System.Drawing.Point(12, 58);
            this.localVersionLabel.Name = "localVersionLabel";
            this.localVersionLabel.Size = new System.Drawing.Size(366, 18);
            this.localVersionLabel.TabIndex = 1;
            this.localVersionLabel.Text = "Current (Local) TL Patch Version: YYYYMMDDx";
            // 
            // gamePathLinkLabel
            // 
            this.gamePathLinkLabel.AutoSize = true;
            this.gamePathLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.gamePathLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gamePathLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gamePathLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.gamePathLinkLabel.Location = new System.Drawing.Point(12, 9);
            this.gamePathLinkLabel.Name = "gamePathLinkLabel";
            this.gamePathLinkLabel.Size = new System.Drawing.Size(163, 18);
            this.gamePathLinkLabel.TabIndex = 3;
            this.gamePathLinkLabel.TabStop = true;
            this.gamePathLinkLabel.Text = "Game Path: Not Set!";
            this.gamePathLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gamePathLinkLabel_LinkClicked);
            // 
            // newPictureBox
            // 
            this.newPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.newPictureBox.Image = global::PriconneReTLInstaller.Properties.Resources._new;
            this.newPictureBox.Location = new System.Drawing.Point(277, 86);
            this.newPictureBox.Name = "newPictureBox";
            this.newPictureBox.Size = new System.Drawing.Size(44, 18);
            this.newPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.newPictureBox.TabIndex = 4;
            this.newPictureBox.TabStop = false;
            this.newPictureBox.Visible = false;
            // 
            // latestVersionLinkLabel
            // 
            this.latestVersionLinkLabel.AutoSize = true;
            this.latestVersionLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.latestVersionLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.latestVersionLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.latestVersionLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.latestVersionLinkLabel.Location = new System.Drawing.Point(12, 85);
            this.latestVersionLinkLabel.Name = "latestVersionLinkLabel";
            this.latestVersionLinkLabel.Size = new System.Drawing.Size(302, 18);
            this.latestVersionLinkLabel.TabIndex = 5;
            this.latestVersionLinkLabel.TabStop = true;
            this.latestVersionLinkLabel.Text = "Latest TL Patch Release: YYYYMMDDx";
            this.latestVersionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.latestVersionLinkLabel_LinkClicked);
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusLabel.Location = new System.Drawing.Point(12, 111);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(642, 22);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "<installer status text>";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelButton.Location = new System.Drawing.Point(415, 43);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(202, 40);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // gameVersionLabel
            // 
            this.gameVersionLabel.AutoSize = true;
            this.gameVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gameVersionLabel.Location = new System.Drawing.Point(12, 33);
            this.gameVersionLabel.Name = "gameVersionLabel";
            this.gameVersionLabel.Size = new System.Drawing.Size(120, 18);
            this.gameVersionLabel.TabIndex = 9;
            this.gameVersionLabel.Text = "Game Version:";
            // 
            // progressPicture
            // 
            this.progressPicture.BackColor = System.Drawing.Color.Transparent;
            this.progressPicture.Image = global::PriconneReTLInstaller.Properties.Resources.pecorun;
            this.progressPicture.Location = new System.Drawing.Point(30, 164);
            this.progressPicture.Name = "progressPicture";
            this.progressPicture.Size = new System.Drawing.Size(64, 64);
            this.progressPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.progressPicture.TabIndex = 11;
            this.progressPicture.TabStop = false;
            this.progressPicture.Visible = false;
            this.progressPicture.VisibleChanged += new System.EventHandler(this.progressPicture_VisibleChanged);
            // 
            // progressLabel
            // 
            this.progressLabel.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.progressLabel.Location = new System.Drawing.Point(27, 139);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(67, 22);
            this.progressLabel.TabIndex = 12;
            this.progressLabel.Text = "<prog>";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exitButton.Location = new System.Drawing.Point(415, 43);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(202, 40);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "Exit AutoUpdater";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Visible = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // AutoUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(668, 238);
            this.ControlBox = false;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.progressPicture);
            this.Controls.Add(this.gameVersionLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.latestVersionLinkLabel);
            this.Controls.Add(this.newPictureBox);
            this.Controls.Add(this.gamePathLinkLabel);
            this.Controls.Add(this.localVersionLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.progressLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AutoUpdateForm";
            this.Opacity = 0.8D;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoUpdateForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.newPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label localVersionLabel;
        private System.Windows.Forms.LinkLabel gamePathLinkLabel;
        private System.Windows.Forms.PictureBox newPictureBox;
        private System.Windows.Forms.LinkLabel latestVersionLinkLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label gameVersionLabel;
        private System.Windows.Forms.PictureBox progressPicture;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button exitButton;
    }
}


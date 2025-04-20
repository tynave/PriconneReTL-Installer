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
            this.statusLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressPicture = new System.Windows.Forms.PictureBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.patchInfoPanel = new System.Windows.Forms.Panel();
            this.modExPicture = new System.Windows.Forms.PictureBox();
            this.latestModloaderVersionLabel = new System.Windows.Forms.Label();
            this.localModloaderVersionLabel = new System.Windows.Forms.Label();
            this.tlLatestLabel = new System.Windows.Forms.Label();
            this.tlInstalledLabel = new System.Windows.Forms.Label();
            this.latestModloaderLabel = new System.Windows.Forms.Label();
            this.installedModloaderLabel = new System.Windows.Forms.Label();
            this.patchLabel = new System.Windows.Forms.Label();
            this.modloaderLabel = new System.Windows.Forms.Label();
            this.patchInfoLabel = new System.Windows.Forms.Label();
            this.localVersionLabel = new System.Windows.Forms.Label();
            this.latestVersionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.newPatchPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoPanel = new System.Windows.Forms.Panel();
            this.gamePathLinkLabel = new System.Windows.Forms.LinkLabel();
            this.gameVersionLabel = new System.Windows.Forms.Label();
            this.gameInfoLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.progressPicture)).BeginInit();
            this.patchInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modExPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newPatchPictureBox)).BeginInit();
            this.gameInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusLabel.Location = new System.Drawing.Point(12, 197);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(642, 49);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "<installer status text>";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelButton.Location = new System.Drawing.Point(235, 249);
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
            // progressPicture
            // 
            this.progressPicture.BackColor = System.Drawing.Color.Transparent;
            this.progressPicture.Image = global::PriconneReTLInstaller.Properties.Resources.pecorun;
            this.progressPicture.Location = new System.Drawing.Point(30, 266);
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
            this.progressLabel.Location = new System.Drawing.Point(30, 241);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(64, 22);
            this.progressLabel.TabIndex = 12;
            this.progressLabel.Text = "<prog>";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exitButton.Location = new System.Drawing.Point(235, 249);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(202, 40);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "Exit AutoUpdater";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Visible = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // patchInfoPanel
            // 
            this.patchInfoPanel.BackColor = System.Drawing.Color.Transparent;
            this.patchInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.patchInfoPanel.Controls.Add(this.modExPicture);
            this.patchInfoPanel.Controls.Add(this.latestModloaderVersionLabel);
            this.patchInfoPanel.Controls.Add(this.localModloaderVersionLabel);
            this.patchInfoPanel.Controls.Add(this.tlLatestLabel);
            this.patchInfoPanel.Controls.Add(this.tlInstalledLabel);
            this.patchInfoPanel.Controls.Add(this.latestModloaderLabel);
            this.patchInfoPanel.Controls.Add(this.installedModloaderLabel);
            this.patchInfoPanel.Controls.Add(this.patchLabel);
            this.patchInfoPanel.Controls.Add(this.modloaderLabel);
            this.patchInfoPanel.Controls.Add(this.patchInfoLabel);
            this.patchInfoPanel.Controls.Add(this.localVersionLabel);
            this.patchInfoPanel.Controls.Add(this.latestVersionLinkLabel);
            this.patchInfoPanel.Controls.Add(this.newPatchPictureBox);
            this.patchInfoPanel.Location = new System.Drawing.Point(12, 88);
            this.patchInfoPanel.Name = "patchInfoPanel";
            this.patchInfoPanel.Size = new System.Drawing.Size(640, 99);
            this.patchInfoPanel.TabIndex = 45;
            // 
            // modExPicture
            // 
            this.modExPicture.BackColor = System.Drawing.Color.Transparent;
            this.modExPicture.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.exclamation_t;
            this.modExPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.modExPicture.Location = new System.Drawing.Point(574, 46);
            this.modExPicture.Name = "modExPicture";
            this.modExPicture.Size = new System.Drawing.Size(25, 25);
            this.modExPicture.TabIndex = 52;
            this.modExPicture.TabStop = false;
            this.modExPicture.Visible = false;
            // 
            // latestModloaderVersionLabel
            // 
            this.latestModloaderVersionLabel.AutoSize = true;
            this.latestModloaderVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.latestModloaderVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latestModloaderVersionLabel.Location = new System.Drawing.Point(470, 64);
            this.latestModloaderVersionLabel.Name = "latestModloaderVersionLabel";
            this.latestModloaderVersionLabel.Size = new System.Drawing.Size(84, 18);
            this.latestModloaderVersionLabel.TabIndex = 51;
            this.latestModloaderVersionLabel.Text = "XX.XX.XX";
            // 
            // localModloaderVersionLabel
            // 
            this.localModloaderVersionLabel.AutoSize = true;
            this.localModloaderVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.localModloaderVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localModloaderVersionLabel.Location = new System.Drawing.Point(470, 39);
            this.localModloaderVersionLabel.Name = "localModloaderVersionLabel";
            this.localModloaderVersionLabel.Size = new System.Drawing.Size(84, 18);
            this.localModloaderVersionLabel.TabIndex = 50;
            this.localModloaderVersionLabel.Text = "XX.XX.XX";
            // 
            // tlLatestLabel
            // 
            this.tlLatestLabel.AutoSize = true;
            this.tlLatestLabel.BackColor = System.Drawing.Color.Transparent;
            this.tlLatestLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlLatestLabel.Location = new System.Drawing.Point(8, 64);
            this.tlLatestLabel.Name = "tlLatestLabel";
            this.tlLatestLabel.Size = new System.Drawing.Size(121, 18);
            this.tlLatestLabel.TabIndex = 49;
            this.tlLatestLabel.Text = "Latest Version:";
            // 
            // tlInstalledLabel
            // 
            this.tlInstalledLabel.AutoSize = true;
            this.tlInstalledLabel.BackColor = System.Drawing.Color.Transparent;
            this.tlInstalledLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlInstalledLabel.Location = new System.Drawing.Point(8, 39);
            this.tlInstalledLabel.Name = "tlInstalledLabel";
            this.tlInstalledLabel.Size = new System.Drawing.Size(80, 18);
            this.tlInstalledLabel.TabIndex = 48;
            this.tlInstalledLabel.Text = "Installed :";
            // 
            // latestModloaderLabel
            // 
            this.latestModloaderLabel.AutoSize = true;
            this.latestModloaderLabel.BackColor = System.Drawing.Color.Transparent;
            this.latestModloaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latestModloaderLabel.Location = new System.Drawing.Point(322, 64);
            this.latestModloaderLabel.Name = "latestModloaderLabel";
            this.latestModloaderLabel.Size = new System.Drawing.Size(126, 18);
            this.latestModloaderLabel.TabIndex = 46;
            this.latestModloaderLabel.Text = "Latest Version :";
            // 
            // installedModloaderLabel
            // 
            this.installedModloaderLabel.AutoSize = true;
            this.installedModloaderLabel.BackColor = System.Drawing.Color.Transparent;
            this.installedModloaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installedModloaderLabel.Location = new System.Drawing.Point(322, 39);
            this.installedModloaderLabel.Name = "installedModloaderLabel";
            this.installedModloaderLabel.Size = new System.Drawing.Size(80, 18);
            this.installedModloaderLabel.TabIndex = 45;
            this.installedModloaderLabel.Text = "Installed :";
            // 
            // patchLabel
            // 
            this.patchLabel.AutoSize = true;
            this.patchLabel.BackColor = System.Drawing.Color.Transparent;
            this.patchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patchLabel.Location = new System.Drawing.Point(8, 17);
            this.patchLabel.Name = "patchLabel";
            this.patchLabel.Size = new System.Drawing.Size(151, 18);
            this.patchLabel.TabIndex = 44;
            this.patchLabel.Text = "TL Patch Versions:";
            // 
            // modloaderLabel
            // 
            this.modloaderLabel.AutoSize = true;
            this.modloaderLabel.BackColor = System.Drawing.Color.Transparent;
            this.modloaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modloaderLabel.Location = new System.Drawing.Point(322, 17);
            this.modloaderLabel.Name = "modloaderLabel";
            this.modloaderLabel.Size = new System.Drawing.Size(164, 18);
            this.modloaderLabel.TabIndex = 43;
            this.modloaderLabel.Text = "Modloader Versions:";
            // 
            // patchInfoLabel
            // 
            this.patchInfoLabel.AutoSize = true;
            this.patchInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.patchInfoLabel.Location = new System.Drawing.Point(6, 1);
            this.patchInfoLabel.Name = "patchInfoLabel";
            this.patchInfoLabel.Size = new System.Drawing.Size(109, 17);
            this.patchInfoLabel.TabIndex = 42;
            this.patchInfoLabel.Text = "TL Patch Information";
            this.patchInfoLabel.UseCompatibleTextRendering = true;
            // 
            // localVersionLabel
            // 
            this.localVersionLabel.AutoSize = true;
            this.localVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.localVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localVersionLabel.Location = new System.Drawing.Point(130, 39);
            this.localVersionLabel.Name = "localVersionLabel";
            this.localVersionLabel.Size = new System.Drawing.Size(109, 18);
            this.localVersionLabel.TabIndex = 5;
            this.localVersionLabel.Text = "YYYYMMDDa";
            // 
            // latestVersionLinkLabel
            // 
            this.latestVersionLinkLabel.AutoSize = true;
            this.latestVersionLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.latestVersionLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.latestVersionLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.latestVersionLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.latestVersionLinkLabel.Location = new System.Drawing.Point(130, 64);
            this.latestVersionLinkLabel.Name = "latestVersionLinkLabel";
            this.latestVersionLinkLabel.Size = new System.Drawing.Size(109, 18);
            this.latestVersionLinkLabel.TabIndex = 23;
            this.latestVersionLinkLabel.TabStop = true;
            this.latestVersionLinkLabel.Text = "YYYYMMDDa";
            this.latestVersionLinkLabel.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // newPatchPictureBox
            // 
            this.newPatchPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.newPatchPictureBox.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources._new;
            this.newPatchPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newPatchPictureBox.Location = new System.Drawing.Point(245, 53);
            this.newPatchPictureBox.Name = "newPatchPictureBox";
            this.newPatchPictureBox.Size = new System.Drawing.Size(50, 18);
            this.newPatchPictureBox.TabIndex = 19;
            this.newPatchPictureBox.TabStop = false;
            this.toolTip.SetToolTip(this.newPatchPictureBox, "New TL patch version available!");
            this.newPatchPictureBox.Visible = false;
            // 
            // gameInfoPanel
            // 
            this.gameInfoPanel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameInfoPanel.Controls.Add(this.gamePathLinkLabel);
            this.gameInfoPanel.Controls.Add(this.gameVersionLabel);
            this.gameInfoPanel.Controls.Add(this.gameInfoLabel);
            this.gameInfoPanel.Location = new System.Drawing.Point(12, 12);
            this.gameInfoPanel.Name = "gameInfoPanel";
            this.gameInfoPanel.Size = new System.Drawing.Size(641, 68);
            this.gameInfoPanel.TabIndex = 44;
            // 
            // gamePathLinkLabel
            // 
            this.gamePathLinkLabel.AutoSize = true;
            this.gamePathLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.gamePathLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gamePathLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gamePathLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.gamePathLinkLabel.Location = new System.Drawing.Point(8, 17);
            this.gamePathLinkLabel.Name = "gamePathLinkLabel";
            this.gamePathLinkLabel.Size = new System.Drawing.Size(199, 18);
            this.gamePathLinkLabel.TabIndex = 22;
            this.gamePathLinkLabel.TabStop = true;
            this.gamePathLinkLabel.Text = "Game Path: priconnepath";
            this.gamePathLinkLabel.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // gameVersionLabel
            // 
            this.gameVersionLabel.AutoSize = true;
            this.gameVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameVersionLabel.Location = new System.Drawing.Point(8, 41);
            this.gameVersionLabel.Name = "gameVersionLabel";
            this.gameVersionLabel.Size = new System.Drawing.Size(125, 18);
            this.gameVersionLabel.TabIndex = 40;
            this.gameVersionLabel.Text = "Game Version: ";
            // 
            // gameInfoLabel
            // 
            this.gameInfoLabel.AutoSize = true;
            this.gameInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoLabel.Location = new System.Drawing.Point(6, 0);
            this.gameInfoLabel.Name = "gameInfoLabel";
            this.gameInfoLabel.Size = new System.Drawing.Size(95, 17);
            this.gameInfoLabel.TabIndex = 41;
            this.gameInfoLabel.Text = "Game Information";
            this.gameInfoLabel.UseCompatibleTextRendering = true;
            // 
            // AutoUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(668, 338);
            this.ControlBox = false;
            this.Controls.Add(this.patchInfoPanel);
            this.Controls.Add(this.gameInfoPanel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.progressPicture);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.progressLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AutoUpdateForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoUpdateForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.progressPicture)).EndInit();
            this.patchInfoPanel.ResumeLayout(false);
            this.patchInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modExPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newPatchPictureBox)).EndInit();
            this.gameInfoPanel.ResumeLayout(false);
            this.gameInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox progressPicture;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Panel patchInfoPanel;
        private System.Windows.Forms.PictureBox modExPicture;
        private System.Windows.Forms.Label latestModloaderVersionLabel;
        private System.Windows.Forms.Label localModloaderVersionLabel;
        private System.Windows.Forms.Label tlLatestLabel;
        private System.Windows.Forms.Label tlInstalledLabel;
        private System.Windows.Forms.Label latestModloaderLabel;
        private System.Windows.Forms.Label installedModloaderLabel;
        private System.Windows.Forms.Label patchLabel;
        private System.Windows.Forms.Label modloaderLabel;
        private System.Windows.Forms.Label patchInfoLabel;
        private System.Windows.Forms.Label localVersionLabel;
        private System.Windows.Forms.LinkLabel latestVersionLinkLabel;
        private System.Windows.Forms.PictureBox newPatchPictureBox;
        private System.Windows.Forms.Panel gameInfoPanel;
        private System.Windows.Forms.LinkLabel gamePathLinkLabel;
        private System.Windows.Forms.Label gameVersionLabel;
        private System.Windows.Forms.Label gameInfoLabel;
        private System.Windows.Forms.ToolTip toolTip;
    }
}


namespace PriconneReTLInstaller
{
    partial class MainForm
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
            this.reinstallCheckBox = new System.Windows.Forms.CheckBox();
            this.uninstallCheckBox = new System.Windows.Forms.CheckBox();
            this.startButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.operationsPanel = new System.Windows.Forms.Panel();
            this.currentLauncherLinkLabel = new System.Windows.Forms.LinkLabel();
            this.launchCheckBox = new System.Windows.Forms.CheckBox();
            this.installCheckBox = new System.Windows.Forms.CheckBox();
            this.operationsLabel = new System.Windows.Forms.Label();
            this.removeIgnoredCheckBox = new System.Windows.Forms.CheckBox();
            this.removeConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.showLogCheckBox = new System.Windows.Forms.CheckBox();
            this.newPatchPictureBox = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gamePathLinkLabel = new System.Windows.Forms.LinkLabel();
            this.latestVersionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.configListBox = new System.Windows.Forms.CheckedListBox();
            this.versionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.modExPicture = new System.Windows.Forms.PictureBox();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.helpMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkForInstallerUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubAPIRateLimitInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikiMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsButton = new System.Windows.Forms.Button();
            this.settingsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editIgnoredFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setLauncherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExportSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubAPISettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.operationLabel = new System.Windows.Forms.Label();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsLabel = new System.Windows.Forms.Label();
            this.operationToolTipPicture = new System.Windows.Forms.PictureBox();
            this.menuButtonLabel = new System.Windows.Forms.Label();
            this.gameVersionLabel = new System.Windows.Forms.Label();
            this.gameInfoPanel = new System.Windows.Forms.Panel();
            this.gameInfoLabel = new System.Windows.Forms.Label();
            this.patchInfoPanel = new System.Windows.Forms.Panel();
            this.latestModloaderVersionLabel = new System.Windows.Forms.Label();
            this.localModloaderVersionLabel = new System.Windows.Forms.Label();
            this.tlLatestLabel = new System.Windows.Forms.Label();
            this.tlInstalledLabel = new System.Windows.Forms.Label();
            this.latestModloaderLabel = new System.Windows.Forms.Label();
            this.installedModloaderLabel = new System.Windows.Forms.Label();
            this.patchLabel = new System.Windows.Forms.Label();
            this.modloaderLabel = new System.Windows.Forms.Label();
            this.patchInfoLabel = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.operationsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newPatchPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modExPicture)).BeginInit();
            this.helpMenuStrip.SuspendLayout();
            this.settingsMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationToolTipPicture)).BeginInit();
            this.gameInfoPanel.SuspendLayout();
            this.patchInfoPanel.SuspendLayout();
            this.SuspendLayout();
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
            // reinstallCheckBox
            // 
            this.reinstallCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.reinstallCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.reinstallCheckBox.FlatAppearance.BorderSize = 0;
            this.reinstallCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.reinstallCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.reinstallCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.reinstallCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reinstallCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reinstallCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.reinstallCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.reinstallCheckBox.Location = new System.Drawing.Point(6, 50);
            this.reinstallCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.reinstallCheckBox.Name = "reinstallCheckBox";
            this.reinstallCheckBox.Size = new System.Drawing.Size(207, 36);
            this.reinstallCheckBox.TabIndex = 2;
            this.reinstallCheckBox.Text = " Reinstall";
            this.reinstallCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.reinstallCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reinstallCheckBox.UseVisualStyleBackColor = false;
            // 
            // uninstallCheckBox
            // 
            this.uninstallCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.uninstallCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.uninstallCheckBox.FlatAppearance.BorderSize = 0;
            this.uninstallCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.uninstallCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.uninstallCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.uninstallCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uninstallCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uninstallCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.uninstallCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.uninstallCheckBox.Location = new System.Drawing.Point(6, 81);
            this.uninstallCheckBox.Name = "uninstallCheckBox";
            this.uninstallCheckBox.Size = new System.Drawing.Size(126, 36);
            this.uninstallCheckBox.TabIndex = 1;
            this.uninstallCheckBox.Text = " Uninstall";
            this.uninstallCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.uninstallCheckBox.UseVisualStyleBackColor = false;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Transparent;
            this.startButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.start_idle;
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Location = new System.Drawing.Point(410, 475);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(207, 58);
            this.startButton.TabIndex = 0;
            this.startButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.startButton, "Start selected operation(s) with currently selected options");
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.EnabledChanged += new System.EventHandler(this.startButton_EnabledChanged);
            this.startButton.Click += new System.EventHandler(this.startButton_Click_1);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.outputTextBox.HideSelection = false;
            this.outputTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.outputTextBox.Location = new System.Drawing.Point(12, 576);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(685, 246);
            this.outputTextBox.TabIndex = 13;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 829);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(714, 29);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 14;
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(542, 24);
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
            // operationsPanel
            // 
            this.operationsPanel.BackColor = System.Drawing.Color.Transparent;
            this.operationsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.operationsPanel.Controls.Add(this.currentLauncherLinkLabel);
            this.operationsPanel.Controls.Add(this.launchCheckBox);
            this.operationsPanel.Controls.Add(this.installCheckBox);
            this.operationsPanel.Controls.Add(this.uninstallCheckBox);
            this.operationsPanel.Controls.Add(this.reinstallCheckBox);
            this.operationsPanel.Controls.Add(this.operationsLabel);
            this.operationsPanel.Location = new System.Drawing.Point(17, 278);
            this.operationsPanel.Name = "operationsPanel";
            this.operationsPanel.Size = new System.Drawing.Size(310, 184);
            this.operationsPanel.TabIndex = 16;
            // 
            // currentLauncherLinkLabel
            // 
            this.currentLauncherLinkLabel.AutoSize = true;
            this.currentLauncherLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentLauncherLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currentLauncherLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.currentLauncherLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.currentLauncherLinkLabel.Location = new System.Drawing.Point(7, 152);
            this.currentLauncherLinkLabel.Name = "currentLauncherLinkLabel";
            this.currentLauncherLinkLabel.Size = new System.Drawing.Size(326, 18);
            this.currentLauncherLinkLabel.TabIndex = 41;
            this.currentLauncherLinkLabel.TabStop = true;
            this.currentLauncherLinkLabel.Text = "Launcher:  DMMGamePlayerFastLauncher";
            this.toolTip.SetToolTip(this.currentLauncherLinkLabel, "Click to change launcher to be used.");
            this.currentLauncherLinkLabel.VisitedLinkColor = System.Drawing.Color.Black;
            this.currentLauncherLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.currentLauncherLinkLabel_LinkClicked);
            // 
            // launchCheckBox
            // 
            this.launchCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.launchCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.launchCheckBox.Checked = true;
            this.launchCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.launchCheckBox.FlatAppearance.BorderSize = 0;
            this.launchCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.launchCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.launchCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.launchCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.launchCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_checked_24x24_2;
            this.launchCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.launchCheckBox.Location = new System.Drawing.Point(6, 113);
            this.launchCheckBox.Name = "launchCheckBox";
            this.launchCheckBox.Size = new System.Drawing.Size(177, 36);
            this.launchCheckBox.TabIndex = 19;
            this.launchCheckBox.Text = " Launch Game";
            this.launchCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.launchCheckBox.UseVisualStyleBackColor = false;
            this.launchCheckBox.CheckedChanged += new System.EventHandler(this.launchCheckBox_CheckedChanged);
            // 
            // installCheckBox
            // 
            this.installCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.installCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.installCheckBox.FlatAppearance.BorderSize = 0;
            this.installCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.installCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.installCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.installCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.installCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.installCheckBox.Location = new System.Drawing.Point(6, 20);
            this.installCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.installCheckBox.Name = "installCheckBox";
            this.installCheckBox.Size = new System.Drawing.Size(207, 36);
            this.installCheckBox.TabIndex = 18;
            this.installCheckBox.Text = " Install / Update";
            this.installCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.installCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.installCheckBox.UseVisualStyleBackColor = false;
            // 
            // operationsLabel
            // 
            this.operationsLabel.AutoSize = true;
            this.operationsLabel.BackColor = System.Drawing.Color.Transparent;
            this.operationsLabel.Location = new System.Drawing.Point(3, 0);
            this.operationsLabel.Name = "operationsLabel";
            this.operationsLabel.Size = new System.Drawing.Size(62, 17);
            this.operationsLabel.TabIndex = 17;
            this.operationsLabel.Text = "Operations";
            this.operationsLabel.UseCompatibleTextRendering = true;
            // 
            // removeIgnoredCheckBox
            // 
            this.removeIgnoredCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.removeIgnoredCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.removeIgnoredCheckBox.FlatAppearance.BorderSize = 0;
            this.removeIgnoredCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.removeIgnoredCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.removeIgnoredCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.removeIgnoredCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeIgnoredCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeIgnoredCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.removeIgnoredCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.removeIgnoredCheckBox.Location = new System.Drawing.Point(7, 20);
            this.removeIgnoredCheckBox.Name = "removeIgnoredCheckBox";
            this.removeIgnoredCheckBox.Size = new System.Drawing.Size(284, 36);
            this.removeIgnoredCheckBox.TabIndex = 29;
            this.removeIgnoredCheckBox.Text = " Remove Ignored Patch Files";
            this.removeIgnoredCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.removeIgnoredCheckBox, "Removes the currently set ignored files also.");
            this.removeIgnoredCheckBox.UseVisualStyleBackColor = false;
            // 
            // removeConfigCheckBox
            // 
            this.removeConfigCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.removeConfigCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.removeConfigCheckBox.FlatAppearance.BorderSize = 0;
            this.removeConfigCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.removeConfigCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.removeConfigCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.removeConfigCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeConfigCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeConfigCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.removeConfigCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.removeConfigCheckBox.Location = new System.Drawing.Point(7, 50);
            this.removeConfigCheckBox.Name = "removeConfigCheckBox";
            this.removeConfigCheckBox.Size = new System.Drawing.Size(218, 36);
            this.removeConfigCheckBox.TabIndex = 17;
            this.removeConfigCheckBox.Text = " Remove Config Files";
            this.removeConfigCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.removeConfigCheckBox, "Removes the selected config files.");
            this.removeConfigCheckBox.UseVisualStyleBackColor = false;
            this.removeConfigCheckBox.CheckedChanged += new System.EventHandler(this.removeConfigCheckBox_CheckedChanged);
            // 
            // showLogCheckBox
            // 
            this.showLogCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.showLogCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.showLogCheckBox.FlatAppearance.BorderSize = 0;
            this.showLogCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.showLogCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.showLogCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.showLogCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showLogCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.showLogCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.showLogCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.showLogCheckBox.Location = new System.Drawing.Point(29, 506);
            this.showLogCheckBox.Name = "showLogCheckBox";
            this.showLogCheckBox.Size = new System.Drawing.Size(144, 36);
            this.showLogCheckBox.TabIndex = 17;
            this.showLogCheckBox.Text = " Show Logs";
            this.showLogCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showLogCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.showLogCheckBox, "Show / hide logs.");
            this.showLogCheckBox.UseVisualStyleBackColor = false;
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
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.door_closed;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitButton.Location = new System.Drawing.Point(648, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(62, 32);
            this.exitButton.TabIndex = 20;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 1000;
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 1000;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 500;
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
            this.toolTip.SetToolTip(this.gamePathLinkLabel, "Click to open game folder in file explorer.");
            this.gamePathLinkLabel.VisitedLinkColor = System.Drawing.Color.Black;
            this.gamePathLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.priconnePathLinkLabel_LinkClicked);
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
            this.toolTip.SetToolTip(this.latestVersionLinkLabel, "Click to open latest TL patch release on GitHub.");
            this.latestVersionLinkLabel.VisitedLinkColor = System.Drawing.Color.Black;
            this.latestVersionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.latestReleaseLinkLabel_LinkClicked);
            // 
            // configListBox
            // 
            this.configListBox.BackColor = System.Drawing.Color.White;
            this.configListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configListBox.CheckOnClick = true;
            this.configListBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.configListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.configListBox.FormattingEnabled = true;
            this.configListBox.Location = new System.Drawing.Point(15, 85);
            this.configListBox.Name = "configListBox";
            this.configListBox.Size = new System.Drawing.Size(290, 68);
            this.configListBox.TabIndex = 32;
            this.toolTip.SetToolTip(this.configListBox, "Select config file to remove.");
            this.configListBox.Visible = false;
            // 
            // versionLinkLabel
            // 
            this.versionLinkLabel.AutoSize = true;
            this.versionLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.versionLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.versionLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.versionLinkLabel.Location = new System.Drawing.Point(657, 526);
            this.versionLinkLabel.Name = "versionLinkLabel";
            this.versionLinkLabel.Size = new System.Drawing.Size(45, 16);
            this.versionLinkLabel.TabIndex = 41;
            this.versionLinkLabel.TabStop = true;
            this.versionLinkLabel.Text = "<ver>";
            this.toolTip.SetToolTip(this.versionLinkLabel, "Click to view the latest installer release on GitHub.");
            this.versionLinkLabel.VisitedLinkColor = System.Drawing.Color.Black;
            this.versionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.versionLinkLabel_LinkClicked);
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
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.Transparent;
            this.minimizeButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.arrow_blue;
            this.minimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.minimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Location = new System.Drawing.Point(616, 7);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(27, 30);
            this.minimizeButton.TabIndex = 25;
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.BackColor = System.Drawing.Color.Transparent;
            this.aboutButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.i_bubble;
            this.aboutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aboutButton.ContextMenuStrip = this.helpMenuStrip;
            this.aboutButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.aboutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Location = new System.Drawing.Point(571, 5);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(32, 32);
            this.aboutButton.TabIndex = 26;
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // helpMenuStrip
            // 
            this.helpMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.helpMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForInstallerUpdatesToolStripMenuItem,
            this.githubAPIRateLimitInfoToolStripMenuItem,
            this.wikiMenuItem,
            this.aboutMenuItem});
            this.helpMenuStrip.Name = "contextMenuStrip1";
            this.helpMenuStrip.Size = new System.Drawing.Size(299, 92);
            // 
            // checkForInstallerUpdatesToolStripMenuItem
            // 
            this.checkForInstallerUpdatesToolStripMenuItem.Checked = true;
            this.checkForInstallerUpdatesToolStripMenuItem.CheckOnClick = true;
            this.checkForInstallerUpdatesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkForInstallerUpdatesToolStripMenuItem.Name = "checkForInstallerUpdatesToolStripMenuItem";
            this.checkForInstallerUpdatesToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.checkForInstallerUpdatesToolStripMenuItem.Text = "Check for Installer Updates on Startup";
            this.checkForInstallerUpdatesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.checkForInstallerUpdatesToolStripMenuItem_CheckedChanged);
            // 
            // githubAPIRateLimitInfoToolStripMenuItem
            // 
            this.githubAPIRateLimitInfoToolStripMenuItem.Name = "githubAPIRateLimitInfoToolStripMenuItem";
            this.githubAPIRateLimitInfoToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.githubAPIRateLimitInfoToolStripMenuItem.Text = "Github API Rate Limit Info";
            this.githubAPIRateLimitInfoToolStripMenuItem.Click += new System.EventHandler(this.githubAPIRateLimitInfoToolStripMenuItem_Click);
            // 
            // wikiMenuItem
            // 
            this.wikiMenuItem.Name = "wikiMenuItem";
            this.wikiMenuItem.Size = new System.Drawing.Size(298, 22);
            this.wikiMenuItem.Text = "GitHub Wiki page";
            this.wikiMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(298, 22);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.Transparent;
            this.settingsButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.scroll_closed_res2;
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsButton.ContextMenuStrip = this.settingsMenuStrip;
            this.settingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.settingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.ForeColor = System.Drawing.Color.Transparent;
            this.settingsButton.Location = new System.Drawing.Point(469, 8);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(44, 30);
            this.settingsButton.TabIndex = 35;
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.EnabledChanged += new System.EventHandler(this.settingsButton_EnabledChanged);
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // settingsMenuStrip
            // 
            this.settingsMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.settingsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editIgnoredFilesToolStripMenuItem,
            this.setLauncherToolStripMenuItem,
            this.importExportSettingsToolStripMenuItem,
            this.gitHubAPISettingsToolStripMenuItem});
            this.settingsMenuStrip.Name = "settingsMenuStrip";
            this.settingsMenuStrip.Size = new System.Drawing.Size(248, 114);
            // 
            // editIgnoredFilesToolStripMenuItem
            // 
            this.editIgnoredFilesToolStripMenuItem.Name = "editIgnoredFilesToolStripMenuItem";
            this.editIgnoredFilesToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.editIgnoredFilesToolStripMenuItem.Text = "Edit Ignored Files";
            this.editIgnoredFilesToolStripMenuItem.Click += new System.EventHandler(this.editIgnoredFilesToolStripMenuItem_Click);
            // 
            // setLauncherToolStripMenuItem
            // 
            this.setLauncherToolStripMenuItem.Name = "setLauncherToolStripMenuItem";
            this.setLauncherToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.setLauncherToolStripMenuItem.Text = "Launcher Settings";
            this.setLauncherToolStripMenuItem.Click += new System.EventHandler(this.launcherSettingsToolStripMenuItem_Click);
            // 
            // importExportSettingsToolStripMenuItem
            // 
            this.importExportSettingsToolStripMenuItem.Name = "importExportSettingsToolStripMenuItem";
            this.importExportSettingsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.importExportSettingsToolStripMenuItem.Text = "Import / Export User Settings";
            this.importExportSettingsToolStripMenuItem.Click += new System.EventHandler(this.importExportSettingsToolStripMenuItem_Click);
            // 
            // gitHubAPISettingsToolStripMenuItem
            // 
            this.gitHubAPISettingsToolStripMenuItem.Name = "gitHubAPISettingsToolStripMenuItem";
            this.gitHubAPISettingsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.gitHubAPISettingsToolStripMenuItem.Text = "GitHub API Settings";
            this.gitHubAPISettingsToolStripMenuItem.Click += new System.EventHandler(this.gitHubAPISettingsToolStripMenuItem_Click);
            // 
            // auButton
            // 
            this.auButton.BackColor = System.Drawing.Color.Transparent;
            this.auButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.crystal_normal_res;
            this.auButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.auButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.auButton.FlatAppearance.BorderSize = 0;
            this.auButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.auButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.auButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.auButton.Location = new System.Drawing.Point(515, 6);
            this.auButton.Name = "auButton";
            this.auButton.Size = new System.Drawing.Size(53, 32);
            this.auButton.TabIndex = 36;
            this.auButton.UseVisualStyleBackColor = false;
            this.auButton.EnabledChanged += new System.EventHandler(this.auButton_EnabledChanged);
            this.auButton.Click += new System.EventHandler(this.auButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.ReTLlogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(15, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 79);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // operationLabel
            // 
            this.operationLabel.AutoSize = true;
            this.operationLabel.BackColor = System.Drawing.Color.Transparent;
            this.operationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.operationLabel.Location = new System.Drawing.Point(26, 477);
            this.operationLabel.Name = "operationLabel";
            this.operationLabel.Size = new System.Drawing.Size(153, 18);
            this.operationLabel.TabIndex = 27;
            this.operationLabel.Text = "Current Operation: ";
            this.operationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.operationLabel.TextChanged += new System.EventHandler(this.modeLabel_TextChanged);
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = System.Drawing.Color.Transparent;
            this.optionsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.optionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsPanel.Controls.Add(this.configListBox);
            this.optionsPanel.Controls.Add(this.optionsLabel);
            this.optionsPanel.Controls.Add(this.removeConfigCheckBox);
            this.optionsPanel.Controls.Add(this.removeIgnoredCheckBox);
            this.optionsPanel.Location = new System.Drawing.Point(341, 278);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(317, 184);
            this.optionsPanel.TabIndex = 30;
            // 
            // optionsLabel
            // 
            this.optionsLabel.AutoSize = true;
            this.optionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.optionsLabel.Location = new System.Drawing.Point(3, 0);
            this.optionsLabel.Name = "optionsLabel";
            this.optionsLabel.Size = new System.Drawing.Size(50, 13);
            this.optionsLabel.TabIndex = 31;
            this.optionsLabel.Text = "Options";
            // 
            // operationToolTipPicture
            // 
            this.operationToolTipPicture.BackColor = System.Drawing.Color.Transparent;
            this.operationToolTipPicture.Image = global::PriconneReTLInstaller.Properties.Resources.q_bubble;
            this.operationToolTipPicture.Location = new System.Drawing.Point(348, 469);
            this.operationToolTipPicture.Name = "operationToolTipPicture";
            this.operationToolTipPicture.Size = new System.Drawing.Size(32, 32);
            this.operationToolTipPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.operationToolTipPicture.TabIndex = 34;
            this.operationToolTipPicture.TabStop = false;
            // 
            // menuButtonLabel
            // 
            this.menuButtonLabel.BackColor = System.Drawing.Color.Transparent;
            this.menuButtonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuButtonLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuButtonLabel.Location = new System.Drawing.Point(472, 51);
            this.menuButtonLabel.Name = "menuButtonLabel";
            this.menuButtonLabel.Size = new System.Drawing.Size(228, 19);
            this.menuButtonLabel.TabIndex = 37;
            this.menuButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.menuButtonLabel.Visible = false;
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
            // gameInfoPanel
            // 
            this.gameInfoPanel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameInfoPanel.Controls.Add(this.gamePathLinkLabel);
            this.gameInfoPanel.Controls.Add(this.gameVersionLabel);
            this.gameInfoPanel.Controls.Add(this.gameInfoLabel);
            this.gameInfoPanel.Location = new System.Drawing.Point(17, 92);
            this.gameInfoPanel.Name = "gameInfoPanel";
            this.gameInfoPanel.Size = new System.Drawing.Size(641, 68);
            this.gameInfoPanel.TabIndex = 42;
            // 
            // gameInfoLabel
            // 
            this.gameInfoLabel.AutoSize = true;
            this.gameInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoLabel.Location = new System.Drawing.Point(6, 0);
            this.gameInfoLabel.Name = "gameInfoLabel";
            this.gameInfoLabel.Size = new System.Drawing.Size(98, 17);
            this.gameInfoLabel.TabIndex = 41;
            this.gameInfoLabel.Text = "Game Information";
            this.gameInfoLabel.UseCompatibleTextRendering = true;
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
            this.patchInfoPanel.Location = new System.Drawing.Point(17, 168);
            this.patchInfoPanel.Name = "patchInfoPanel";
            this.patchInfoPanel.Size = new System.Drawing.Size(640, 99);
            this.patchInfoPanel.TabIndex = 43;
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
            this.patchInfoLabel.Size = new System.Drawing.Size(113, 17);
            this.patchInfoLabel.TabIndex = 42;
            this.patchInfoLabel.Text = "TL Patch Information";
            this.patchInfoLabel.UseCompatibleTextRendering = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg_enlarged;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(714, 858);
            this.ControlBox = false;
            this.Controls.Add(this.patchInfoPanel);
            this.Controls.Add(this.gameInfoPanel);
            this.Controls.Add(this.versionLinkLabel);
            this.Controls.Add(this.menuButtonLabel);
            this.Controls.Add(this.auButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.operationToolTipPicture);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.operationLabel);
            this.Controls.Add(this.showLogCheckBox);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.operationsPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.startButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.operationsPanel.ResumeLayout(false);
            this.operationsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newPatchPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modExPicture)).EndInit();
            this.helpMenuStrip.ResumeLayout(false);
            this.settingsMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationToolTipPicture)).EndInit();
            this.gameInfoPanel.ResumeLayout(false);
            this.gameInfoPanel.PerformLayout();
            this.patchInfoPanel.ResumeLayout(false);
            this.patchInfoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox reinstallCheckBox;
        private System.Windows.Forms.Label localVersionLabel;
        private System.Windows.Forms.CheckBox uninstallCheckBox;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel operationsPanel;
        private System.Windows.Forms.Label operationsLabel;
        private System.Windows.Forms.CheckBox removeConfigCheckBox;
        private System.Windows.Forms.CheckBox showLogCheckBox;
        private System.Windows.Forms.PictureBox newPatchPictureBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel gamePathLinkLabel;
        private System.Windows.Forms.LinkLabel latestVersionLinkLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ContextMenuStrip helpMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem wikiMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Label operationLabel;
        private System.Windows.Forms.CheckBox removeIgnoredCheckBox;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Label optionsLabel;
        private System.Windows.Forms.CheckBox installCheckBox;
        private System.Windows.Forms.CheckBox launchCheckBox;
        private System.Windows.Forms.PictureBox operationToolTipPicture;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button auButton;
        private System.Windows.Forms.Label menuButtonLabel;
        private System.Windows.Forms.ContextMenuStrip settingsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editIgnoredFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setLauncherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importExportSettingsToolStripMenuItem;
        private System.Windows.Forms.Label gameVersionLabel;
        private System.Windows.Forms.CheckedListBox configListBox;
        private System.Windows.Forms.LinkLabel currentLauncherLinkLabel;
        private System.Windows.Forms.ToolStripMenuItem checkForInstallerUpdatesToolStripMenuItem;
        private System.Windows.Forms.LinkLabel versionLinkLabel;
        private System.Windows.Forms.Panel gameInfoPanel;
        private System.Windows.Forms.Label gameInfoLabel;
        private System.Windows.Forms.Panel patchInfoPanel;
        private System.Windows.Forms.Label patchInfoLabel;
        private System.Windows.Forms.Label modloaderLabel;
        private System.Windows.Forms.Label patchLabel;
        private System.Windows.Forms.Label installedModloaderLabel;
        private System.Windows.Forms.Label latestModloaderLabel;
        private System.Windows.Forms.Label tlInstalledLabel;
        private System.Windows.Forms.Label tlLatestLabel;
        private System.Windows.Forms.Label localModloaderVersionLabel;
        private System.Windows.Forms.Label latestModloaderVersionLabel;
        private System.Windows.Forms.PictureBox modExPicture;
        private System.Windows.Forms.ToolStripMenuItem githubAPIRateLimitInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubAPISettingsToolStripMenuItem;
    }
}


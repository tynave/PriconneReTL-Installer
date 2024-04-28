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
            this.launchCheckBox = new System.Windows.Forms.CheckBox();
            this.installCheckBox = new System.Windows.Forms.CheckBox();
            this.operationsLabel = new System.Windows.Forms.Label();
            this.removeIgnoredCheckBox = new System.Windows.Forms.CheckBox();
            this.removeConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.showLogCheckBox = new System.Windows.Forms.CheckBox();
            this.newPictureBox = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gamePathLinkLabel = new System.Windows.Forms.LinkLabel();
            this.latestVersionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.configListBox = new System.Windows.Forms.CheckedListBox();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.auButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.helpMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationLabel = new System.Windows.Forms.Label();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsLabel = new System.Windows.Forms.Label();
            this.operationToolTipPicture = new System.Windows.Forms.PictureBox();
            this.menuButtonLabel = new System.Windows.Forms.Label();
            this.settingsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editIgnoredFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDMMGameFastLauncherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExportSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionLabel = new System.Windows.Forms.Label();
            this.tlPatchVersionsLabel = new System.Windows.Forms.Label();
            this.gameVersionLabel = new System.Windows.Forms.Label();
            this.currentLauncherLinkLabel = new System.Windows.Forms.LinkLabel();
            this.statusStrip1.SuspendLayout();
            this.operationsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.helpMenuStrip.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationToolTipPicture)).BeginInit();
            this.settingsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // localVersionLabel
            // 
            this.localVersionLabel.AutoSize = true;
            this.localVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.localVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localVersionLabel.Location = new System.Drawing.Point(157, 136);
            this.localVersionLabel.Name = "localVersionLabel";
            this.localVersionLabel.Size = new System.Drawing.Size(238, 18);
            this.localVersionLabel.TabIndex = 5;
            this.localVersionLabel.Text = "Current (Local) : YYYYMMDDa";
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
            this.startButton.Location = new System.Drawing.Point(410, 364);
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
            this.outputTextBox.Location = new System.Drawing.Point(15, 460);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 719);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(718, 29);
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(546, 24);
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
            this.operationsPanel.Location = new System.Drawing.Point(17, 175);
            this.operationsPanel.Name = "operationsPanel";
            this.operationsPanel.Size = new System.Drawing.Size(310, 184);
            this.operationsPanel.TabIndex = 16;
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
            this.removeConfigCheckBox.Location = new System.Drawing.Point(8, 50);
            this.removeConfigCheckBox.Name = "removeConfigCheckBox";
            this.removeConfigCheckBox.Size = new System.Drawing.Size(218, 36);
            this.removeConfigCheckBox.TabIndex = 17;
            this.removeConfigCheckBox.Text = " Remove Config Files";
            this.removeConfigCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.showLogCheckBox.Location = new System.Drawing.Point(24, 412);
            this.showLogCheckBox.Name = "showLogCheckBox";
            this.showLogCheckBox.Size = new System.Drawing.Size(144, 36);
            this.showLogCheckBox.TabIndex = 17;
            this.showLogCheckBox.Text = " Show Logs";
            this.showLogCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showLogCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.showLogCheckBox, "Show / hide logs.");
            this.showLogCheckBox.UseVisualStyleBackColor = false;
            // 
            // newPictureBox
            // 
            this.newPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.newPictureBox.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources._new;
            this.newPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newPictureBox.Location = new System.Drawing.Point(643, 138);
            this.newPictureBox.Name = "newPictureBox";
            this.newPictureBox.Size = new System.Drawing.Size(50, 18);
            this.newPictureBox.TabIndex = 19;
            this.newPictureBox.TabStop = false;
            this.toolTip.SetToolTip(this.newPictureBox, "New version available!");
            this.newPictureBox.Visible = false;
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
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 200;
            // 
            // gamePathLinkLabel
            // 
            this.gamePathLinkLabel.AutoSize = true;
            this.gamePathLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.gamePathLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gamePathLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gamePathLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.gamePathLinkLabel.Location = new System.Drawing.Point(14, 89);
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
            this.latestVersionLinkLabel.Location = new System.Drawing.Point(427, 136);
            this.latestVersionLinkLabel.Name = "latestVersionLinkLabel";
            this.latestVersionLinkLabel.Size = new System.Drawing.Size(231, 18);
            this.latestVersionLinkLabel.TabIndex = 23;
            this.latestVersionLinkLabel.TabStop = true;
            this.latestVersionLinkLabel.Text = "Latest Release: YYYYMMDDa";
            this.toolTip.SetToolTip(this.latestVersionLinkLabel, "Click to open latest release on GitHub.");
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
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.Transparent;
            this.settingsButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.scroll_closed_res2;
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            // helpMenuStrip
            // 
            this.helpMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpMenuItem,
            this.aboutMenuItem});
            this.helpMenuStrip.Name = "contextMenuStrip1";
            this.helpMenuStrip.Size = new System.Drawing.Size(108, 48);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(107, 22);
            this.helpMenuItem.Text = "Help";
            this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // operationLabel
            // 
            this.operationLabel.AutoSize = true;
            this.operationLabel.BackColor = System.Drawing.Color.Transparent;
            this.operationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.operationLabel.Location = new System.Drawing.Point(21, 382);
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
            this.optionsPanel.Location = new System.Drawing.Point(341, 175);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(317, 154);
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
            this.operationToolTipPicture.Location = new System.Drawing.Point(343, 374);
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
            // settingsMenuStrip
            // 
            this.settingsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editIgnoredFilesToolStripMenuItem,
            this.setDMMGameFastLauncherToolStripMenuItem,
            this.importExportSettingsToolStripMenuItem});
            this.settingsMenuStrip.Name = "settingsMenuStrip";
            this.settingsMenuStrip.Size = new System.Drawing.Size(304, 70);
            // 
            // editIgnoredFilesToolStripMenuItem
            // 
            this.editIgnoredFilesToolStripMenuItem.Name = "editIgnoredFilesToolStripMenuItem";
            this.editIgnoredFilesToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.editIgnoredFilesToolStripMenuItem.Text = "Edit Ignored Files";
            this.editIgnoredFilesToolStripMenuItem.Click += new System.EventHandler(this.editIgnoredFilesToolStripMenuItem_Click);
            // 
            // setDMMGameFastLauncherToolStripMenuItem
            // 
            this.setDMMGameFastLauncherToolStripMenuItem.Name = "setDMMGameFastLauncherToolStripMenuItem";
            this.setDMMGameFastLauncherToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.setDMMGameFastLauncherToolStripMenuItem.Text = "Set DMMGamePlayerFastLauncher shortcut";
            this.setDMMGameFastLauncherToolStripMenuItem.Click += new System.EventHandler(this.setDMMGameFastLauncherToolStripMenuItem_Click);
            // 
            // importExportSettingsToolStripMenuItem
            // 
            this.importExportSettingsToolStripMenuItem.Name = "importExportSettingsToolStripMenuItem";
            this.importExportSettingsToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.importExportSettingsToolStripMenuItem.Text = "Import / Export User Settings";
            this.importExportSettingsToolStripMenuItem.Click += new System.EventHandler(this.importExportSettingsToolStripMenuItem_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.versionLabel.Location = new System.Drawing.Point(659, 427);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(45, 16);
            this.versionLabel.TabIndex = 38;
            this.versionLabel.Text = "<ver>";
            // 
            // tlPatchVersionsLabel
            // 
            this.tlPatchVersionsLabel.AutoSize = true;
            this.tlPatchVersionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.tlPatchVersionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlPatchVersionsLabel.Location = new System.Drawing.Point(14, 136);
            this.tlPatchVersionsLabel.Name = "tlPatchVersionsLabel";
            this.tlPatchVersionsLabel.Size = new System.Drawing.Size(151, 18);
            this.tlPatchVersionsLabel.TabIndex = 39;
            this.tlPatchVersionsLabel.Text = "TL Patch Versions:";
            // 
            // gameVersionLabel
            // 
            this.gameVersionLabel.AutoSize = true;
            this.gameVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameVersionLabel.Location = new System.Drawing.Point(14, 112);
            this.gameVersionLabel.Name = "gameVersionLabel";
            this.gameVersionLabel.Size = new System.Drawing.Size(125, 18);
            this.gameVersionLabel.TabIndex = 40;
            this.gameVersionLabel.Text = "Game Version: ";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(718, 748);
            this.ControlBox = false;
            this.Controls.Add(this.gameVersionLabel);
            this.Controls.Add(this.tlPatchVersionsLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.menuButtonLabel);
            this.Controls.Add(this.auButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.operationToolTipPicture);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.operationLabel);
            this.Controls.Add(this.showLogCheckBox);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.latestVersionLinkLabel);
            this.Controls.Add(this.gamePathLinkLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.newPictureBox);
            this.Controls.Add(this.operationsPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.localVersionLabel);
            this.Controls.Add(this.startButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.operationsPanel.ResumeLayout(false);
            this.operationsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.helpMenuStrip.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationToolTipPicture)).EndInit();
            this.settingsMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox newPictureBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel gamePathLinkLabel;
        private System.Windows.Forms.LinkLabel latestVersionLinkLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ContextMenuStrip helpMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem setDMMGameFastLauncherToolStripMenuItem;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ToolStripMenuItem importExportSettingsToolStripMenuItem;
        private System.Windows.Forms.Label tlPatchVersionsLabel;
        private System.Windows.Forms.Label gameVersionLabel;
        private System.Windows.Forms.CheckedListBox configListBox;
        private System.Windows.Forms.LinkLabel currentLauncherLinkLabel;
    }
}


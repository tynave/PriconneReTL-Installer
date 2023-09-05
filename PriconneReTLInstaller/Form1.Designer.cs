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
            this.gamePathLabel = new System.Windows.Forms.Label();
            this.latestVersionLabel = new System.Windows.Forms.Label();
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
            this.operationsLabel = new System.Windows.Forms.Label();
            this.removeInteropsCheckBox = new System.Windows.Forms.CheckBox();
            this.removeIgnoredCheckBox = new System.Windows.Forms.CheckBox();
            this.removeConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.showLogCheckBox = new System.Windows.Forms.CheckBox();
            this.newPictureBox = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.minimizeButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gamePathLinkLabel = new System.Windows.Forms.LinkLabel();
            this.latestVersionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.option1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.option2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeLabel = new System.Windows.Forms.Label();
            this.modeDescritpionLabel = new System.Windows.Forms.Label();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsLabel = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.operationsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // localVersionLabel
            // 
            this.localVersionLabel.AutoSize = true;
            this.localVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.localVersionLabel.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localVersionLabel.Location = new System.Drawing.Point(12, 112);
            this.localVersionLabel.Name = "localVersionLabel";
            this.localVersionLabel.Size = new System.Drawing.Size(209, 24);
            this.localVersionLabel.TabIndex = 5;
            this.localVersionLabel.Text = "Current (Local) Version:";
            // 
            // gamePathLabel
            // 
            this.gamePathLabel.AutoSize = true;
            this.gamePathLabel.BackColor = System.Drawing.Color.Transparent;
            this.gamePathLabel.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gamePathLabel.Location = new System.Drawing.Point(13, 88);
            this.gamePathLabel.Name = "gamePathLabel";
            this.gamePathLabel.Size = new System.Drawing.Size(107, 24);
            this.gamePathLabel.TabIndex = 6;
            this.gamePathLabel.Text = "Game Path:";
            // 
            // latestVersionLabel
            // 
            this.latestVersionLabel.AutoSize = true;
            this.latestVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.latestVersionLabel.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.latestVersionLabel.Location = new System.Drawing.Point(13, 136);
            this.latestVersionLabel.Name = "latestVersionLabel";
            this.latestVersionLabel.Size = new System.Drawing.Size(210, 24);
            this.latestVersionLabel.TabIndex = 7;
            this.latestVersionLabel.Text = "Latest Release Version: ";
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
            this.reinstallCheckBox.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reinstallCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.reinstallCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.reinstallCheckBox.Location = new System.Drawing.Point(6, 16);
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
            this.uninstallCheckBox.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uninstallCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.uninstallCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.uninstallCheckBox.Location = new System.Drawing.Point(6, 49);
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
            this.startButton.Location = new System.Drawing.Point(399, 359);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(236, 66);
            this.startButton.TabIndex = 0;
            this.startButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.startButton, "Start operation with currently selected options");
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click_1);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.outputTextBox.HideSelection = false;
            this.outputTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.outputTextBox.Location = new System.Drawing.Point(15, 461);
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
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(62, 24);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(539, 24);
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
            this.operationsPanel.Controls.Add(this.uninstallCheckBox);
            this.operationsPanel.Controls.Add(this.reinstallCheckBox);
            this.operationsPanel.Controls.Add(this.operationsLabel);
            this.operationsPanel.Location = new System.Drawing.Point(17, 173);
            this.operationsPanel.Name = "operationsPanel";
            this.operationsPanel.Size = new System.Drawing.Size(307, 93);
            this.operationsPanel.TabIndex = 16;
            // 
            // operationsLabel
            // 
            this.operationsLabel.AutoSize = true;
            this.operationsLabel.BackColor = System.Drawing.Color.Transparent;
            this.operationsLabel.Location = new System.Drawing.Point(3, 0);
            this.operationsLabel.Name = "operationsLabel";
            this.operationsLabel.Size = new System.Drawing.Size(75, 17);
            this.operationsLabel.TabIndex = 17;
            this.operationsLabel.Text = "Operations";
            // 
            // removeInteropsCheckBox
            // 
            this.removeInteropsCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.removeInteropsCheckBox.AutoSize = true;
            this.removeInteropsCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.removeInteropsCheckBox.Enabled = false;
            this.removeInteropsCheckBox.FlatAppearance.BorderSize = 0;
            this.removeInteropsCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.removeInteropsCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.removeInteropsCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.removeInteropsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeInteropsCheckBox.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeInteropsCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.removeInteropsCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.removeInteropsCheckBox.Location = new System.Drawing.Point(6, 84);
            this.removeInteropsCheckBox.Name = "removeInteropsCheckBox";
            this.removeInteropsCheckBox.Size = new System.Drawing.Size(188, 34);
            this.removeInteropsCheckBox.TabIndex = 29;
            this.removeInteropsCheckBox.Text = " Remove Interops";
            this.removeInteropsCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.removeInteropsCheckBox, "Removes the generated interop assemblies at:\r\n%appdata%\\BepInEx");
            this.removeInteropsCheckBox.UseVisualStyleBackColor = false;
            // 
            // removeIgnoredCheckBox
            // 
            this.removeIgnoredCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.removeIgnoredCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.removeIgnoredCheckBox.Enabled = false;
            this.removeIgnoredCheckBox.FlatAppearance.BorderSize = 0;
            this.removeIgnoredCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.removeIgnoredCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.removeIgnoredCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.removeIgnoredCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeIgnoredCheckBox.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeIgnoredCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.removeIgnoredCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.removeIgnoredCheckBox.Location = new System.Drawing.Point(6, 52);
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
            this.removeConfigCheckBox.Enabled = false;
            this.removeConfigCheckBox.FlatAppearance.BorderSize = 0;
            this.removeConfigCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.removeConfigCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.removeConfigCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.removeConfigCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeConfigCheckBox.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeConfigCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.removeConfigCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.removeConfigCheckBox.Location = new System.Drawing.Point(6, 20);
            this.removeConfigCheckBox.Name = "removeConfigCheckBox";
            this.removeConfigCheckBox.Size = new System.Drawing.Size(218, 36);
            this.removeConfigCheckBox.TabIndex = 17;
            this.removeConfigCheckBox.Text = " Remove Config Files";
            this.removeConfigCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.removeConfigCheckBox.UseVisualStyleBackColor = false;
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
            this.showLogCheckBox.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.showLogCheckBox.Image = global::PriconneReTLInstaller.Properties.Resources.check_empty_24x24_2;
            this.showLogCheckBox.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.showLogCheckBox.Location = new System.Drawing.Point(24, 419);
            this.showLogCheckBox.Name = "showLogCheckBox";
            this.showLogCheckBox.Size = new System.Drawing.Size(144, 36);
            this.showLogCheckBox.TabIndex = 17;
            this.showLogCheckBox.Text = " Show Logs";
            this.showLogCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showLogCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.showLogCheckBox, "Show / hide logs");
            this.showLogCheckBox.UseVisualStyleBackColor = false;
            // 
            // newPictureBox
            // 
            this.newPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.newPictureBox.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources._new;
            this.newPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newPictureBox.Location = new System.Drawing.Point(321, 139);
            this.newPictureBox.Name = "newPictureBox";
            this.newPictureBox.Size = new System.Drawing.Size(50, 18);
            this.newPictureBox.TabIndex = 19;
            this.newPictureBox.TabStop = false;
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
            this.exitButton.Location = new System.Drawing.Point(647, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(62, 32);
            this.exitButton.TabIndex = 20;
            this.toolTip.SetToolTip(this.exitButton, "Exit Application");
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 1000;
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
            this.minimizeButton.Location = new System.Drawing.Point(621, 7);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(27, 30);
            this.minimizeButton.TabIndex = 25;
            this.toolTip.SetToolTip(this.minimizeButton, "Minimize");
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.BackColor = System.Drawing.Color.Transparent;
            this.aboutButton.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.i_bubble;
            this.aboutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.aboutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Location = new System.Drawing.Point(578, 5);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(32, 32);
            this.aboutButton.TabIndex = 26;
            this.toolTip.SetToolTip(this.aboutButton, "Help / About");
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
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
            // gamePathLinkLabel
            // 
            this.gamePathLinkLabel.AutoSize = true;
            this.gamePathLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.gamePathLinkLabel.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gamePathLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gamePathLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.gamePathLinkLabel.Location = new System.Drawing.Point(117, 88);
            this.gamePathLinkLabel.Name = "gamePathLinkLabel";
            this.gamePathLinkLabel.Size = new System.Drawing.Size(120, 24);
            this.gamePathLinkLabel.TabIndex = 22;
            this.gamePathLinkLabel.TabStop = true;
            this.gamePathLinkLabel.Text = "priconnepath";
            this.gamePathLinkLabel.VisitedLinkColor = System.Drawing.Color.Black;
            this.gamePathLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.priconnePathLinkLabel_LinkClicked);
            // 
            // latestVersionLinkLabel
            // 
            this.latestVersionLinkLabel.AutoSize = true;
            this.latestVersionLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.latestVersionLinkLabel.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.latestVersionLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.latestVersionLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.latestVersionLinkLabel.Location = new System.Drawing.Point(216, 136);
            this.latestVersionLinkLabel.Name = "latestVersionLinkLabel";
            this.latestVersionLinkLabel.Size = new System.Drawing.Size(87, 24);
            this.latestVersionLinkLabel.TabIndex = 23;
            this.latestVersionLinkLabel.TabStop = true;
            this.latestVersionLinkLabel.Text = "<version>";
            this.latestVersionLinkLabel.VisitedLinkColor = System.Drawing.Color.Black;
            this.latestVersionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.latestReleaseLinkLabel_LinkClicked);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.option1ToolStripMenuItem,
            this.option2ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // option1ToolStripMenuItem
            // 
            this.option1ToolStripMenuItem.Name = "option1ToolStripMenuItem";
            this.option1ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.option1ToolStripMenuItem.Text = "Help";
            this.option1ToolStripMenuItem.Click += new System.EventHandler(this.option1ToolStripMenuItem_Click);
            // 
            // option2ToolStripMenuItem
            // 
            this.option2ToolStripMenuItem.Name = "option2ToolStripMenuItem";
            this.option2ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.option2ToolStripMenuItem.Text = "About";
            this.option2ToolStripMenuItem.Click += new System.EventHandler(this.option2ToolStripMenuItem_Click);
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.BackColor = System.Drawing.Color.Transparent;
            this.modeLabel.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.modeLabel.Location = new System.Drawing.Point(330, 173);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(172, 24);
            this.modeLabel.TabIndex = 27;
            this.modeLabel.Text = "Current Operation: ";
            this.modeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // modeDescritpionLabel
            // 
            this.modeDescritpionLabel.BackColor = System.Drawing.Color.Transparent;
            this.modeDescritpionLabel.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.modeDescritpionLabel.Location = new System.Drawing.Point(330, 200);
            this.modeDescritpionLabel.Name = "modeDescritpionLabel";
            this.modeDescritpionLabel.Size = new System.Drawing.Size(368, 149);
            this.modeDescritpionLabel.TabIndex = 28;
            this.modeDescritpionLabel.Text = "<operation description>";
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = System.Drawing.Color.Transparent;
            this.optionsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.optionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsPanel.Controls.Add(this.optionsLabel);
            this.optionsPanel.Controls.Add(this.removeConfigCheckBox);
            this.optionsPanel.Controls.Add(this.removeInteropsCheckBox);
            this.optionsPanel.Controls.Add(this.removeIgnoredCheckBox);
            this.optionsPanel.Location = new System.Drawing.Point(17, 274);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(307, 139);
            this.optionsPanel.TabIndex = 30;
            // 
            // optionsLabel
            // 
            this.optionsLabel.AutoSize = true;
            this.optionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.optionsLabel.Location = new System.Drawing.Point(3, 0);
            this.optionsLabel.Name = "optionsLabel";
            this.optionsLabel.Size = new System.Drawing.Size(56, 17);
            this.optionsLabel.TabIndex = 31;
            this.optionsLabel.Text = "Options";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::PriconneReTLInstaller.Properties.Resources.bg2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(718, 748);
            this.ControlBox = false;
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.modeDescritpionLabel);
            this.Controls.Add(this.modeLabel);
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
            this.Controls.Add(this.latestVersionLabel);
            this.Controls.Add(this.gamePathLabel);
            this.Controls.Add(this.localVersionLabel);
            this.Controls.Add(this.startButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("nintendoP_Humming-E_002pr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.operationsPanel.ResumeLayout(false);
            this.operationsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox reinstallCheckBox;
        private System.Windows.Forms.Label localVersionLabel;
        private System.Windows.Forms.Label gamePathLabel;
        private System.Windows.Forms.Label latestVersionLabel;
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem option1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem option2ToolStripMenuItem;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Label modeDescritpionLabel;
        private System.Windows.Forms.CheckBox removeIgnoredCheckBox;
        private System.Windows.Forms.CheckBox removeInteropsCheckBox;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Label optionsLabel;
    }
}


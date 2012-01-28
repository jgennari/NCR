namespace NCR
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbSupress = new System.Windows.Forms.CheckBox();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cbOpenWithWindows = new System.Windows.Forms.CheckBox();
            this.cbHideOnStart = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.domConcurrent = new System.Windows.Forms.DomainUpDown();
            this.cbDisableAutorun = new System.Windows.Forms.CheckBox();
            this.cbOCRDrives = new System.Windows.Forms.ComboBox();
            this.btnNCROff = new System.Windows.Forms.Button();
            this.btnNCROn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOCR = new System.Windows.Forms.Button();
            this.cblDrives = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbAskNotFound = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cbDVDID = new System.Windows.Forms.ComboBox();
            this.cbProtect = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblArgs = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbQuality = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbContainer = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbEjectDuplicates = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbHandbrakeArgs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGetWorkingDirectory = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbWorkingDirectory = new System.Windows.Forms.TextBox();
            this.btnHandbrakeDir = new System.Windows.Forms.Button();
            this.tbHandBrakeDirectory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCleanDVDXML = new System.Windows.Forms.CheckBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbXMLDVDPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tbXMLDVDUsername = new System.Windows.Forms.TextBox();
            this.rbDVDSupplied = new System.Windows.Forms.RadioButton();
            this.rbUserSupplied = new System.Windows.Forms.RadioButton();
            this.rbDVDXML = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbCleanUp = new System.Windows.Forms.CheckBox();
            this.lblProcessDir = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbCoverName = new System.Windows.Forms.TextBox();
            this.cbExportCover = new System.Windows.Forms.CheckBox();
            this.cbExportDVDID = new System.Windows.Forms.CheckBox();
            this.cbMoveToFinal = new System.Windows.Forms.CheckBox();
            this.cbEjectOnCompletion = new System.Windows.Forms.CheckBox();
            this.btnFinalDir = new System.Windows.Forms.Button();
            this.tbFinalDirectory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.lvQueue = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label19 = new System.Windows.Forms.Label();
            this.lvRips = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnKillRip = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.lbConsole = new System.Windows.Forms.ListBox();
            this.timerQueue = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.fbdWorking = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdHandbrake = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdFinal = new System.Windows.Forms.FolderBrowserDialog();
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNoClickRipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerHide = new System.Windows.Forms.Timer(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.cmTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(374, 421);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbSupress);
            this.tabPage1.Controls.Add(this.cbMode);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.cbOpenWithWindows);
            this.tabPage1.Controls.Add(this.cbHideOnStart);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.domConcurrent);
            this.tabPage1.Controls.Add(this.cbDisableAutorun);
            this.tabPage1.Controls.Add(this.cbOCRDrives);
            this.tabPage1.Controls.Add(this.btnNCROff);
            this.tabPage1.Controls.Add(this.btnNCROn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnOCR);
            this.tabPage1.Controls.Add(this.cblDrives);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(366, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbSupress
            // 
            this.cbSupress.AutoSize = true;
            this.cbSupress.Checked = true;
            this.cbSupress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSupress.Location = new System.Drawing.Point(10, 264);
            this.cbSupress.Name = "cbSupress";
            this.cbSupress.Size = new System.Drawing.Size(154, 17);
            this.cbSupress.TabIndex = 31;
            this.cbSupress.Text = "Supress All Error Messages";
            this.cbSupress.UseVisualStyleBackColor = true;
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.Enabled = false;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "HandBrake Encode",
            "ISO",
            "Direct to Folder"});
            this.cbMode.Location = new System.Drawing.Point(10, 21);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(347, 21);
            this.cbMode.TabIndex = 30;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(7, 5);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(38, 13);
            this.label24.TabIndex = 24;
            this.label24.Text = "Mode";
            // 
            // cbOpenWithWindows
            // 
            this.cbOpenWithWindows.AutoSize = true;
            this.cbOpenWithWindows.Location = new System.Drawing.Point(10, 195);
            this.cbOpenWithWindows.Name = "cbOpenWithWindows";
            this.cbOpenWithWindows.Size = new System.Drawing.Size(149, 17);
            this.cbOpenWithWindows.TabIndex = 23;
            this.cbOpenWithWindows.Text = "Open on Windows startup";
            this.cbOpenWithWindows.UseVisualStyleBackColor = true;
            this.cbOpenWithWindows.CheckedChanged += new System.EventHandler(this.cbOpenWithWindows_CheckedChanged);
            // 
            // cbHideOnStart
            // 
            this.cbHideOnStart.AutoSize = true;
            this.cbHideOnStart.Location = new System.Drawing.Point(10, 218);
            this.cbHideOnStart.Name = "cbHideOnStart";
            this.cbHideOnStart.Size = new System.Drawing.Size(114, 17);
            this.cbHideOnStart.TabIndex = 22;
            this.cbHideOnStart.Text = "Start in system tray";
            this.cbHideOnStart.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(231, 196);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Concurrent Rips";
            // 
            // domConcurrent
            // 
            this.domConcurrent.Enabled = false;
            this.domConcurrent.Items.Add("1");
            this.domConcurrent.Items.Add("2");
            this.domConcurrent.Items.Add("3");
            this.domConcurrent.Items.Add("4");
            this.domConcurrent.Items.Add("5");
            this.domConcurrent.Items.Add("6");
            this.domConcurrent.Items.Add("7");
            this.domConcurrent.Items.Add("8");
            this.domConcurrent.Items.Add("9");
            this.domConcurrent.Location = new System.Drawing.Point(320, 192);
            this.domConcurrent.Name = "domConcurrent";
            this.domConcurrent.Size = new System.Drawing.Size(37, 20);
            this.domConcurrent.TabIndex = 10;
            this.domConcurrent.Text = "1";
            this.domConcurrent.SelectedItemChanged += new System.EventHandler(this.domConcurrent_SelectedItemChanged);
            // 
            // cbDisableAutorun
            // 
            this.cbDisableAutorun.AutoSize = true;
            this.cbDisableAutorun.Checked = true;
            this.cbDisableAutorun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDisableAutorun.Location = new System.Drawing.Point(10, 241);
            this.cbDisableAutorun.Name = "cbDisableAutorun";
            this.cbDisableAutorun.Size = new System.Drawing.Size(160, 17);
            this.cbDisableAutorun.TabIndex = 9;
            this.cbDisableAutorun.Text = "Disable Autorun while active";
            this.cbDisableAutorun.UseVisualStyleBackColor = true;
            // 
            // cbOCRDrives
            // 
            this.cbOCRDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOCRDrives.FormattingEnabled = true;
            this.cbOCRDrives.Location = new System.Drawing.Point(9, 163);
            this.cbOCRDrives.Name = "cbOCRDrives";
            this.cbOCRDrives.Size = new System.Drawing.Size(219, 21);
            this.cbOCRDrives.TabIndex = 8;
            // 
            // btnNCROff
            // 
            this.btnNCROff.Enabled = false;
            this.btnNCROff.Location = new System.Drawing.Point(192, 366);
            this.btnNCROff.Name = "btnNCROff";
            this.btnNCROff.Size = new System.Drawing.Size(166, 23);
            this.btnNCROff.TabIndex = 7;
            this.btnNCROff.Text = "Stop No Click Rip ™";
            this.btnNCROff.UseVisualStyleBackColor = true;
            this.btnNCROff.Click += new System.EventHandler(this.btnNCROff_Click);
            // 
            // btnNCROn
            // 
            this.btnNCROn.Location = new System.Drawing.Point(7, 366);
            this.btnNCROn.Name = "btnNCROn";
            this.btnNCROn.Size = new System.Drawing.Size(179, 23);
            this.btnNCROn.TabIndex = 6;
            this.btnNCROn.Text = "Start No Click Rip ™";
            this.btnNCROn.UseVisualStyleBackColor = true;
            this.btnNCROn.Click += new System.EventHandler(this.btnNCROn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enabled Drives";
            // 
            // btnOCR
            // 
            this.btnOCR.Location = new System.Drawing.Point(234, 160);
            this.btnOCR.Name = "btnOCR";
            this.btnOCR.Size = new System.Drawing.Size(126, 25);
            this.btnOCR.TabIndex = 4;
            this.btnOCR.Text = "One Click Rip ™";
            this.btnOCR.UseVisualStyleBackColor = true;
            this.btnOCR.Click += new System.EventHandler(this.btnOCR_Click);
            // 
            // cblDrives
            // 
            this.cblDrives.FormattingEnabled = true;
            this.cblDrives.Location = new System.Drawing.Point(9, 63);
            this.cblDrives.Name = "cblDrives";
            this.cblDrives.Size = new System.Drawing.Size(351, 94);
            this.cblDrives.TabIndex = 3;
            this.cblDrives.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cblDrives_ItemCheck);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbAskNotFound);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.cbDVDID);
            this.tabPage2.Controls.Add(this.cbProtect);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lblArgs);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.cbQuality);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.cbContainer);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.cbEjectDuplicates);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tbHandbrakeArgs);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnGetWorkingDirectory);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbWorkingDirectory);
            this.tabPage2.Controls.Add(this.btnHandbrakeDir);
            this.tabPage2.Controls.Add(this.tbHandBrakeDirectory);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cbCleanDVDXML);
            this.tabPage2.Controls.Add(this.lblPassword);
            this.tabPage2.Controls.Add(this.tbXMLDVDPassword);
            this.tabPage2.Controls.Add(this.lblUserName);
            this.tabPage2.Controls.Add(this.tbXMLDVDUsername);
            this.tabPage2.Controls.Add(this.rbDVDSupplied);
            this.tabPage2.Controls.Add(this.rbUserSupplied);
            this.tabPage2.Controls.Add(this.rbDVDXML);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(366, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbAskNotFound
            // 
            this.cbAskNotFound.AutoSize = true;
            this.cbAskNotFound.Checked = true;
            this.cbAskNotFound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAskNotFound.Location = new System.Drawing.Point(35, 96);
            this.cbAskNotFound.Name = "cbAskNotFound";
            this.cbAskNotFound.Size = new System.Drawing.Size(232, 17);
            this.cbAskNotFound.TabIndex = 39;
            this.cbAskNotFound.Text = "User supplied if not found on DVDXML.com";
            this.cbAskNotFound.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(6, 163);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 13);
            this.label23.TabIndex = 38;
            this.label23.Text = "DVDID Method";
            // 
            // cbDVDID
            // 
            this.cbDVDID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVDID.FormattingEnabled = true;
            this.cbDVDID.Items.AddRange(new object[] {
            "DirectX",
            "DVDID.exe",
            "None"});
            this.cbDVDID.Location = new System.Drawing.Point(89, 159);
            this.cbDVDID.Name = "cbDVDID";
            this.cbDVDID.Size = new System.Drawing.Size(93, 21);
            this.cbDVDID.TabIndex = 37;
            // 
            // cbProtect
            // 
            this.cbProtect.AutoSize = true;
            this.cbProtect.Location = new System.Drawing.Point(188, 163);
            this.cbProtect.Name = "cbProtect";
            this.cbProtect.Size = new System.Drawing.Size(174, 17);
            this.cbProtect.TabIndex = 36;
            this.cbProtect.Text = "Protect from AnyDVD (required)";
            this.cbProtect.UseVisualStyleBackColor = true;
            this.cbProtect.CheckedChanged += new System.EventHandler(this.cbProtect_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(277, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "%q - Quality";
            // 
            // lblArgs
            // 
            this.lblArgs.AutoSize = true;
            this.lblArgs.Location = new System.Drawing.Point(6, 356);
            this.lblArgs.Name = "lblArgs";
            this.lblArgs.Size = new System.Drawing.Size(328, 13);
            this.lblArgs.TabIndex = 34;
            this.lblArgs.Text = "-i \"%s\" -o \"%w\\%d\\%d.%c\" --main-feature -m -e x264 -a 1 %q -E faac";
            this.lblArgs.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(214, 306);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Quality";
            // 
            // cbQuality
            // 
            this.cbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuality.FormattingEnabled = true;
            this.cbQuality.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low",
            "Ultra High",
            "None"});
            this.cbQuality.Location = new System.Drawing.Point(259, 303);
            this.cbQuality.Name = "cbQuality";
            this.cbQuality.Size = new System.Drawing.Size(93, 21);
            this.cbQuality.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(277, 263);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "%c - Container";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 306);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Container Format";
            // 
            // cbContainer
            // 
            this.cbContainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContainer.FormattingEnabled = true;
            this.cbContainer.Items.AddRange(new object[] {
            "MKV",
            "M4V",
            "None"});
            this.cbContainer.Location = new System.Drawing.Point(96, 303);
            this.cbContainer.Name = "cbContainer";
            this.cbContainer.Size = new System.Drawing.Size(93, 21);
            this.cbContainer.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(134, 278);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "%f - Final Directory";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(134, 263);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "%w - Working Directory";
            // 
            // cbEjectDuplicates
            // 
            this.cbEjectDuplicates.AutoSize = true;
            this.cbEjectDuplicates.Checked = true;
            this.cbEjectDuplicates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEjectDuplicates.Location = new System.Drawing.Point(6, 372);
            this.cbEjectDuplicates.Name = "cbEjectDuplicates";
            this.cbEjectDuplicates.Size = new System.Drawing.Size(156, 17);
            this.cbEjectDuplicates.TabIndex = 26;
            this.cbEjectDuplicates.Text = "Eject Duplicate Immediately";
            this.cbEjectDuplicates.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "%d - DVD Title";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 263);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "%s - Source Drive";
            // 
            // tbHandbrakeArgs
            // 
            this.tbHandbrakeArgs.Location = new System.Drawing.Point(121, 240);
            this.tbHandbrakeArgs.Name = "tbHandbrakeArgs";
            this.tbHandbrakeArgs.Size = new System.Drawing.Size(210, 20);
            this.tbHandbrakeArgs.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "HandBrake Arguments";
            // 
            // btnGetWorkingDirectory
            // 
            this.btnGetWorkingDirectory.Location = new System.Drawing.Point(335, 186);
            this.btnGetWorkingDirectory.Name = "btnGetWorkingDirectory";
            this.btnGetWorkingDirectory.Size = new System.Drawing.Size(27, 23);
            this.btnGetWorkingDirectory.TabIndex = 21;
            this.btnGetWorkingDirectory.Text = "...";
            this.btnGetWorkingDirectory.UseVisualStyleBackColor = true;
            this.btnGetWorkingDirectory.Click += new System.EventHandler(this.btnGetWorkingDirectory_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Working Directory";
            // 
            // tbWorkingDirectory
            // 
            this.tbWorkingDirectory.Location = new System.Drawing.Point(121, 188);
            this.tbWorkingDirectory.Name = "tbWorkingDirectory";
            this.tbWorkingDirectory.Size = new System.Drawing.Size(210, 20);
            this.tbWorkingDirectory.TabIndex = 19;
            // 
            // btnHandbrakeDir
            // 
            this.btnHandbrakeDir.Location = new System.Drawing.Point(335, 211);
            this.btnHandbrakeDir.Name = "btnHandbrakeDir";
            this.btnHandbrakeDir.Size = new System.Drawing.Size(27, 25);
            this.btnHandbrakeDir.TabIndex = 18;
            this.btnHandbrakeDir.Text = "...";
            this.btnHandbrakeDir.UseVisualStyleBackColor = true;
            this.btnHandbrakeDir.Click += new System.EventHandler(this.btnHandbrakeDir_Click);
            // 
            // tbHandBrakeDirectory
            // 
            this.tbHandBrakeDirectory.Location = new System.Drawing.Point(121, 214);
            this.tbHandBrakeDirectory.Name = "tbHandBrakeDirectory";
            this.tbHandBrakeDirectory.Size = new System.Drawing.Size(210, 20);
            this.tbHandBrakeDirectory.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "HandBrake Directory";
            // 
            // cbCleanDVDXML
            // 
            this.cbCleanDVDXML.AutoSize = true;
            this.cbCleanDVDXML.Checked = true;
            this.cbCleanDVDXML.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCleanDVDXML.Enabled = false;
            this.cbCleanDVDXML.Location = new System.Drawing.Point(35, 77);
            this.cbCleanDVDXML.Name = "cbCleanDVDXML";
            this.cbCleanDVDXML.Size = new System.Drawing.Size(242, 17);
            this.cbCleanDVDXML.TabIndex = 10;
            this.cbCleanDVDXML.Text = "Remove DVDXML Extra Characters (ie: [WS])";
            this.cbCleanDVDXML.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Enabled = false;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(32, 58);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password";
            // 
            // tbXMLDVDPassword
            // 
            this.tbXMLDVDPassword.Enabled = false;
            this.tbXMLDVDPassword.Location = new System.Drawing.Point(96, 55);
            this.tbXMLDVDPassword.Name = "tbXMLDVDPassword";
            this.tbXMLDVDPassword.PasswordChar = '*';
            this.tbXMLDVDPassword.Size = new System.Drawing.Size(206, 20);
            this.tbXMLDVDPassword.TabIndex = 7;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Enabled = false;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(32, 32);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(58, 13);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "User name";
            // 
            // tbXMLDVDUsername
            // 
            this.tbXMLDVDUsername.Enabled = false;
            this.tbXMLDVDUsername.Location = new System.Drawing.Point(96, 29);
            this.tbXMLDVDUsername.Name = "tbXMLDVDUsername";
            this.tbXMLDVDUsername.Size = new System.Drawing.Size(206, 20);
            this.tbXMLDVDUsername.TabIndex = 3;
            // 
            // rbDVDSupplied
            // 
            this.rbDVDSupplied.AutoSize = true;
            this.rbDVDSupplied.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDVDSupplied.Location = new System.Drawing.Point(6, 136);
            this.rbDVDSupplied.Name = "rbDVDSupplied";
            this.rbDVDSupplied.Size = new System.Drawing.Size(183, 17);
            this.rbDVDSupplied.TabIndex = 2;
            this.rbDVDSupplied.Text = "Use information provided on DVD";
            this.rbDVDSupplied.UseVisualStyleBackColor = true;
            this.rbDVDSupplied.Click += new System.EventHandler(this.rbDVDXML_Click);
            // 
            // rbUserSupplied
            // 
            this.rbUserSupplied.AutoSize = true;
            this.rbUserSupplied.Checked = true;
            this.rbUserSupplied.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUserSupplied.Location = new System.Drawing.Point(6, 113);
            this.rbUserSupplied.Name = "rbUserSupplied";
            this.rbUserSupplied.Size = new System.Drawing.Size(143, 17);
            this.rbUserSupplied.TabIndex = 1;
            this.rbUserSupplied.TabStop = true;
            this.rbUserSupplied.Text = "User supplied information";
            this.rbUserSupplied.UseVisualStyleBackColor = true;
            this.rbUserSupplied.Click += new System.EventHandler(this.rbDVDXML_Click);
            // 
            // rbDVDXML
            // 
            this.rbDVDXML.AutoSize = true;
            this.rbDVDXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDVDXML.Location = new System.Drawing.Point(6, 6);
            this.rbDVDXML.Name = "rbDVDXML";
            this.rbDVDXML.Size = new System.Drawing.Size(296, 17);
            this.rbDVDXML.TabIndex = 0;
            this.rbDVDXML.Text = "Use DVDXML.com Web Service (recommended)";
            this.rbDVDXML.UseVisualStyleBackColor = true;
            this.rbDVDXML.CheckedChanged += new System.EventHandler(this.rbDVDXML_CheckedChanged);
            this.rbDVDXML.Click += new System.EventHandler(this.rbDVDXML_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbCleanUp);
            this.tabPage3.Controls.Add(this.lblProcessDir);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.tbCoverName);
            this.tabPage3.Controls.Add(this.cbExportCover);
            this.tabPage3.Controls.Add(this.cbExportDVDID);
            this.tabPage3.Controls.Add(this.cbMoveToFinal);
            this.tabPage3.Controls.Add(this.cbEjectOnCompletion);
            this.tabPage3.Controls.Add(this.btnFinalDir);
            this.tabPage3.Controls.Add(this.tbFinalDirectory);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(366, 395);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Export";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbCleanUp
            // 
            this.cbCleanUp.AutoSize = true;
            this.cbCleanUp.Location = new System.Drawing.Point(43, 57);
            this.cbCleanUp.Name = "cbCleanUp";
            this.cbCleanUp.Size = new System.Drawing.Size(143, 17);
            this.cbCleanUp.TabIndex = 34;
            this.cbCleanUp.Text = "Empty Working Directory";
            this.cbCleanUp.UseVisualStyleBackColor = true;
            // 
            // lblProcessDir
            // 
            this.lblProcessDir.AutoSize = true;
            this.lblProcessDir.Location = new System.Drawing.Point(6, 379);
            this.lblProcessDir.Name = "lblProcessDir";
            this.lblProcessDir.Size = new System.Drawing.Size(24, 13);
            this.lblProcessDir.TabIndex = 33;
            this.lblProcessDir.Text = "pdir";
            this.lblProcessDir.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(43, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "File Name";
            // 
            // tbCoverName
            // 
            this.tbCoverName.Location = new System.Drawing.Point(43, 163);
            this.tbCoverName.Name = "tbCoverName";
            this.tbCoverName.Size = new System.Drawing.Size(210, 20);
            this.tbCoverName.TabIndex = 31;
            this.tbCoverName.Text = "cover.jpg";
            // 
            // cbExportCover
            // 
            this.cbExportCover.AutoSize = true;
            this.cbExportCover.Checked = true;
            this.cbExportCover.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExportCover.Location = new System.Drawing.Point(6, 126);
            this.cbExportCover.Name = "cbExportCover";
            this.cbExportCover.Size = new System.Drawing.Size(119, 17);
            this.cbExportCover.TabIndex = 30;
            this.cbExportCover.Text = "Export Cover Image";
            this.cbExportCover.UseVisualStyleBackColor = true;
            // 
            // cbExportDVDID
            // 
            this.cbExportDVDID.AutoSize = true;
            this.cbExportDVDID.Checked = true;
            this.cbExportDVDID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExportDVDID.Location = new System.Drawing.Point(6, 103);
            this.cbExportDVDID.Name = "cbExportDVDID";
            this.cbExportDVDID.Size = new System.Drawing.Size(111, 17);
            this.cbExportDVDID.TabIndex = 29;
            this.cbExportDVDID.Text = "Export DVDID.xml";
            this.cbExportDVDID.UseVisualStyleBackColor = true;
            // 
            // cbMoveToFinal
            // 
            this.cbMoveToFinal.AutoSize = true;
            this.cbMoveToFinal.Location = new System.Drawing.Point(6, 34);
            this.cbMoveToFinal.Name = "cbMoveToFinal";
            this.cbMoveToFinal.Size = new System.Drawing.Size(135, 17);
            this.cbMoveToFinal.TabIndex = 28;
            this.cbMoveToFinal.Text = "Move to Final Directory";
            this.cbMoveToFinal.UseVisualStyleBackColor = true;
            // 
            // cbEjectOnCompletion
            // 
            this.cbEjectOnCompletion.AutoSize = true;
            this.cbEjectOnCompletion.Checked = true;
            this.cbEjectOnCompletion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEjectOnCompletion.Location = new System.Drawing.Point(6, 11);
            this.cbEjectOnCompletion.Name = "cbEjectOnCompletion";
            this.cbEjectOnCompletion.Size = new System.Drawing.Size(122, 17);
            this.cbEjectOnCompletion.TabIndex = 27;
            this.cbEjectOnCompletion.Text = "Eject On Completion";
            this.cbEjectOnCompletion.UseVisualStyleBackColor = true;
            // 
            // btnFinalDir
            // 
            this.btnFinalDir.Location = new System.Drawing.Point(331, 75);
            this.btnFinalDir.Name = "btnFinalDir";
            this.btnFinalDir.Size = new System.Drawing.Size(27, 23);
            this.btnFinalDir.TabIndex = 12;
            this.btnFinalDir.Text = "...";
            this.btnFinalDir.UseVisualStyleBackColor = true;
            this.btnFinalDir.Click += new System.EventHandler(this.btnFinalDir_Click);
            // 
            // tbFinalDirectory
            // 
            this.tbFinalDirectory.Location = new System.Drawing.Point(118, 77);
            this.tbFinalDirectory.Name = "tbFinalDirectory";
            this.tbFinalDirectory.Size = new System.Drawing.Size(210, 20);
            this.tbFinalDirectory.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Final Directory";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label22);
            this.tabPage5.Controls.Add(this.lvQueue);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.lvRips);
            this.tabPage5.Controls.Add(this.btnKillRip);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(366, 395);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Activity";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 13);
            this.label22.TabIndex = 6;
            this.label22.Text = "Rip Queue";
            // 
            // lvQueue
            // 
            this.lvQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvQueue.FullRowSelect = true;
            this.lvQueue.Location = new System.Drawing.Point(3, 19);
            this.lvQueue.Name = "lvQueue";
            this.lvQueue.Size = new System.Drawing.Size(354, 161);
            this.lvQueue.TabIndex = 5;
            this.lvQueue.UseCompatibleStateImageBehavior = false;
            this.lvQueue.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Drive";
            this.columnHeader7.Width = 40;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Volume Name";
            this.columnHeader8.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Status";
            this.columnHeader9.Width = 110;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 183);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Active Rips";
            // 
            // lvRips
            // 
            this.lvRips.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvRips.FullRowSelect = true;
            this.lvRips.Location = new System.Drawing.Point(6, 199);
            this.lvRips.Name = "lvRips";
            this.lvRips.Size = new System.Drawing.Size(354, 161);
            this.lvRips.TabIndex = 2;
            this.lvRips.UseCompatibleStateImageBehavior = false;
            this.lvRips.View = System.Windows.Forms.View.Details;
            this.lvRips.SelectedIndexChanged += new System.EventHandler(this.lvRips_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Rip";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Percent";
            this.columnHeader3.Width = 90;
            // 
            // btnKillRip
            // 
            this.btnKillRip.Enabled = false;
            this.btnKillRip.Location = new System.Drawing.Point(6, 366);
            this.btnKillRip.Name = "btnKillRip";
            this.btnKillRip.Size = new System.Drawing.Size(136, 23);
            this.btnKillRip.TabIndex = 1;
            this.btnKillRip.Text = "Kill Rip";
            this.btnKillRip.UseVisualStyleBackColor = true;
            this.btnKillRip.Click += new System.EventHandler(this.btnKillRip_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Controls.Add(this.lblVersion);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(366, 395);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(174, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 184);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(6, 27);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(52, 13);
            this.lblVersion.TabIndex = 24;
            this.lblVersion.Text = "lblVersion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "No Click Rip";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.lbConsole);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(366, 395);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Console";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // lbConsole
            // 
            this.lbConsole.BackColor = System.Drawing.Color.Black;
            this.lbConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbConsole.ForeColor = System.Drawing.Color.Lime;
            this.lbConsole.FormattingEnabled = true;
            this.lbConsole.Location = new System.Drawing.Point(6, 6);
            this.lbConsole.Name = "lbConsole";
            this.lbConsole.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbConsole.Size = new System.Drawing.Size(354, 379);
            this.lbConsole.TabIndex = 0;
            // 
            // timerQueue
            // 
            this.timerQueue.Interval = 1000;
            this.timerQueue.Tick += new System.EventHandler(this.timerQueue_Tick);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(307, 435);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(226, 435);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(75, 23);
            this.btnHide.TabIndex = 5;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // niTray
            // 
            this.niTray.ContextMenuStrip = this.cmTray;
            this.niTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niTray.Icon")));
            this.niTray.Text = "No Click Rip";
            this.niTray.Visible = true;
            // 
            // cmTray
            // 
            this.cmTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.startNoClickRipToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.cmTray.Name = "cmTray";
            this.cmTray.Size = new System.Drawing.Size(167, 70);
            this.cmTray.DoubleClick += new System.EventHandler(this.cmTray_DoubleClick);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // startNoClickRipToolStripMenuItem
            // 
            this.startNoClickRipToolStripMenuItem.Name = "startNoClickRipToolStripMenuItem";
            this.startNoClickRipToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.startNoClickRipToolStripMenuItem.Text = "Start No Click Rip";
            this.startNoClickRipToolStripMenuItem.Click += new System.EventHandler(this.startNoClickRipToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timerHide
            // 
            this.timerHide.Tick += new System.EventHandler(this.timerHide_Tick);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 183);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 13);
            this.label21.TabIndex = 3;
            this.label21.Text = "Active Rips";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(6, 199);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(354, 161);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "PID";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Rip";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Percent";
            this.columnHeader6.Width = 90;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(6, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Kill Rip";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 463);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "No Click Rip ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.cmTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnNCROff;
        private System.Windows.Forms.Button btnNCROn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOCR;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbXMLDVDPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbXMLDVDUsername;
        private System.Windows.Forms.RadioButton rbDVDSupplied;
        private System.Windows.Forms.RadioButton rbUserSupplied;
        private System.Windows.Forms.RadioButton rbDVDXML;
        private System.Windows.Forms.CheckBox cbCleanDVDXML;
        private System.Windows.Forms.TextBox tbFinalDirectory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbHandbrakeArgs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGetWorkingDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbWorkingDirectory;
        private System.Windows.Forms.Button btnHandbrakeDir;
        private System.Windows.Forms.TextBox tbHandBrakeDirectory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnFinalDir;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbEjectDuplicates;
        private System.Windows.Forms.CheckBox cbExportDVDID;
        private System.Windows.Forms.CheckBox cbMoveToFinal;
        private System.Windows.Forms.CheckBox cbEjectOnCompletion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbCoverName;
        private System.Windows.Forms.CheckBox cbExportCover;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbContainer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbOCRDrives;
        private System.Windows.Forms.CheckBox cbDisableAutorun;
        public System.Windows.Forms.CheckedListBox cblDrives;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbQuality;
        private System.Windows.Forms.Label lblProcessDir;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DomainUpDown domConcurrent;
        private System.Windows.Forms.Timer timerQueue;
        private System.Windows.Forms.CheckBox cbHideOnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FolderBrowserDialog fbdWorking;
        private System.Windows.Forms.FolderBrowserDialog fbdHandbrake;
        private System.Windows.Forms.FolderBrowserDialog fbdFinal;
        private System.Windows.Forms.NotifyIcon niTray;
        private System.Windows.Forms.ContextMenuStrip cmTray;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNoClickRipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbCleanUp;
        private System.Windows.Forms.Timer timerHide;
        private System.Windows.Forms.Label lblArgs;
        private System.Windows.Forms.CheckBox cbOpenWithWindows;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnKillRip;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ListView lvQueue;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.CheckBox cbProtect;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbDVDID;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.ListView lvRips;
        private System.Windows.Forms.CheckBox cbAskNotFound;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ListBox lbConsole;
        private System.Windows.Forms.CheckBox cbSupress;
    }
}


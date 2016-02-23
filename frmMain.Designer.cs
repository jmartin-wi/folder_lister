namespace Folder_Lister
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
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtRootPath = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.chkFiles = new System.Windows.Forms.CheckBox();
            this.lblStat = new System.Windows.Forms.Label();
            this.dgvTreeList = new System.Windows.Forms.DataGridView();
            this.btnLoadFromDb = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnSaveDb = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTreeName = new System.Windows.Forms.TextBox();
            this.btnListPath = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblTreeId = new System.Windows.Forms.Label();
            this.txtTreeId = new System.Windows.Forms.TextBox();
            this.cboUTrees = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetUTrees = new System.Windows.Forms.Button();
            this.chkLeafViewed = new System.Windows.Forms.CheckBox();
            this.cboLeafCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboLeafSubCat = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLeafId = new System.Windows.Forms.TextBox();
            this.btnSaveLeaf = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLeafComment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLeafName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboLeafType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtLeafLocation = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cboSearchName = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cboSearchCategory = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtSrchKeyWrd = new System.Windows.Forms.TextBox();
            this.btnSrchKeyWrd = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chkRestrictToTreeId = new System.Windows.Forms.CheckBox();
            this.btnPrintSrchRslt = new System.Windows.Forms.Button();
            this.btnDelTree = new System.Windows.Forms.Button();
            this.btnDelLeaf = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtCreateDate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreeList)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(497, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder Lister";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(53, 71);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 40);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse For Root Folder";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtRootPath
            // 
            this.txtRootPath.Enabled = false;
            this.txtRootPath.Location = new System.Drawing.Point(20, 134);
            this.txtRootPath.Name = "txtRootPath";
            this.txtRootPath.Size = new System.Drawing.Size(248, 20);
            this.txtRootPath.TabIndex = 2;
            this.txtRootPath.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(976, 687);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(93, 62);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lvFiles
            // 
            this.lvFiles.Location = new System.Drawing.Point(288, 55);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(481, 348);
            this.lvFiles.TabIndex = 4;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            // 
            // chkFiles
            // 
            this.chkFiles.AutoSize = true;
            this.chkFiles.Enabled = false;
            this.chkFiles.Location = new System.Drawing.Point(134, 184);
            this.chkFiles.Name = "chkFiles";
            this.chkFiles.Size = new System.Drawing.Size(114, 17);
            this.chkFiles.TabIndex = 6;
            this.chkFiles.Text = "Show Only Folders";
            this.chkFiles.UseVisualStyleBackColor = true;
            this.chkFiles.CheckedChanged += new System.EventHandler(this.chkFiles_CheckedChanged);
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.ForeColor = System.Drawing.Color.Blue;
            this.lblStat.Location = new System.Drawing.Point(793, 660);
            this.lblStat.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(41, 13);
            this.lblStat.TabIndex = 7;
            this.lblStat.Text = "Ready.";
            // 
            // dgvTreeList
            // 
            this.dgvTreeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreeList.Location = new System.Drawing.Point(288, 440);
            this.dgvTreeList.Name = "dgvTreeList";
            this.dgvTreeList.Size = new System.Drawing.Size(481, 296);
            this.dgvTreeList.TabIndex = 8;
            this.dgvTreeList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTreeList_CellContentClick);
            // 
            // btnLoadFromDb
            // 
            this.btnLoadFromDb.Location = new System.Drawing.Point(20, 639);
            this.btnLoadFromDb.Name = "btnLoadFromDb";
            this.btnLoadFromDb.Size = new System.Drawing.Size(87, 83);
            this.btnLoadFromDb.TabIndex = 4;
            this.btnLoadFromDb.Text = "Load Grid From DB With TreeId";
            this.btnLoadFromDb.UseVisualStyleBackColor = true;
            this.btnLoadFromDb.Click += new System.EventHandler(this.btnLoadFromDb_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(23, 121);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(58, 13);
            this.lblPath.TabIndex = 10;
            this.lblPath.Text = "Root Path:";
            // 
            // btnSaveDb
            // 
            this.btnSaveDb.Location = new System.Drawing.Point(82, 353);
            this.btnSaveDb.Name = "btnSaveDb";
            this.btnSaveDb.Size = new System.Drawing.Size(96, 52);
            this.btnSaveDb.TabIndex = 3;
            this.btnSaveDb.Text = "Save Tree To Db With RootPath";
            this.btnSaveDb.UseVisualStyleBackColor = true;
            this.btnSaveDb.Click += new System.EventHandler(this.btnSaveDb_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tree Name:";
            // 
            // txtTreeName
            // 
            this.txtTreeName.Location = new System.Drawing.Point(20, 238);
            this.txtTreeName.Name = "txtTreeName";
            this.txtTreeName.Size = new System.Drawing.Size(248, 20);
            this.txtTreeName.TabIndex = 1;
            // 
            // btnListPath
            // 
            this.btnListPath.Location = new System.Drawing.Point(157, 71);
            this.btnListPath.Name = "btnListPath";
            this.btnListPath.Size = new System.Drawing.Size(75, 40);
            this.btnListPath.TabIndex = 16;
            this.btnListPath.Text = "List Path";
            this.btnListPath.UseVisualStyleBackColor = true;
            this.btnListPath.Click += new System.EventHandler(this.btnListPath_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(157, 639);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 83);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print With TreeId";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblTreeId
            // 
            this.lblTreeId.AutoSize = true;
            this.lblTreeId.Location = new System.Drawing.Point(17, 462);
            this.lblTreeId.Name = "lblTreeId";
            this.lblTreeId.Size = new System.Drawing.Size(44, 13);
            this.lblTreeId.TabIndex = 20;
            this.lblTreeId.Text = "Tree Id:";
            // 
            // txtTreeId
            // 
            this.txtTreeId.Enabled = false;
            this.txtTreeId.Location = new System.Drawing.Point(17, 481);
            this.txtTreeId.Name = "txtTreeId";
            this.txtTreeId.Size = new System.Drawing.Size(248, 20);
            this.txtTreeId.TabIndex = 19;
            this.txtTreeId.TabStop = false;
            // 
            // cboUTrees
            // 
            this.cboUTrees.FormattingEnabled = true;
            this.cboUTrees.Location = new System.Drawing.Point(17, 553);
            this.cboUTrees.Name = "cboUTrees";
            this.cboUTrees.Size = new System.Drawing.Size(248, 21);
            this.cboUTrees.TabIndex = 21;
            this.cboUTrees.SelectedIndexChanged += new System.EventHandler(this.cboUTrees_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Current Unique Trees:";
            // 
            // btnGetUTrees
            // 
            this.btnGetUTrees.Location = new System.Drawing.Point(17, 576);
            this.btnGetUTrees.Name = "btnGetUTrees";
            this.btnGetUTrees.Size = new System.Drawing.Size(122, 23);
            this.btnGetUTrees.TabIndex = 23;
            this.btnGetUTrees.Text = "Get Unique Trees";
            this.btnGetUTrees.UseVisualStyleBackColor = true;
            this.btnGetUTrees.Click += new System.EventHandler(this.btnGetUTrees_Click);
            // 
            // chkLeafViewed
            // 
            this.chkLeafViewed.AutoSize = true;
            this.chkLeafViewed.Location = new System.Drawing.Point(813, 370);
            this.chkLeafViewed.Name = "chkLeafViewed";
            this.chkLeafViewed.Size = new System.Drawing.Size(61, 17);
            this.chkLeafViewed.TabIndex = 10;
            this.chkLeafViewed.Text = "Viewed";
            this.chkLeafViewed.UseVisualStyleBackColor = true;
            // 
            // cboLeafCategory
            // 
            this.cboLeafCategory.Location = new System.Drawing.Point(810, 216);
            this.cboLeafCategory.Name = "cboLeafCategory";
            this.cboLeafCategory.Size = new System.Drawing.Size(283, 21);
            this.cboLeafCategory.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(816, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Category:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(816, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Sub-Category:";
            // 
            // cboLeafSubCat
            // 
            this.cboLeafSubCat.FormattingEnabled = true;
            this.cboLeafSubCat.Location = new System.Drawing.Point(810, 261);
            this.cboLeafSubCat.Name = "cboLeafSubCat";
            this.cboLeafSubCat.Size = new System.Drawing.Size(285, 21);
            this.cboLeafSubCat.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(810, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Leaf ID:";
            // 
            // txtLeafId
            // 
            this.txtLeafId.Enabled = false;
            this.txtLeafId.Location = new System.Drawing.Point(810, 87);
            this.txtLeafId.Name = "txtLeafId";
            this.txtLeafId.Size = new System.Drawing.Size(283, 20);
            this.txtLeafId.TabIndex = 66;
            this.txtLeafId.TabStop = false;
            // 
            // btnSaveLeaf
            // 
            this.btnSaveLeaf.Location = new System.Drawing.Point(840, 401);
            this.btnSaveLeaf.Name = "btnSaveLeaf";
            this.btnSaveLeaf.Size = new System.Drawing.Size(80, 51);
            this.btnSaveLeaf.TabIndex = 12;
            this.btnSaveLeaf.Text = "Save Leaf Info";
            this.btnSaveLeaf.UseVisualStyleBackColor = true;
            this.btnSaveLeaf.Click += new System.EventHandler(this.btnSaveLeaf_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(814, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Leaf Type:";
            // 
            // txtLeafComment
            // 
            this.txtLeafComment.Location = new System.Drawing.Point(810, 344);
            this.txtLeafComment.Name = "txtLeafComment";
            this.txtLeafComment.Size = new System.Drawing.Size(283, 20);
            this.txtLeafComment.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(816, 328);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Leaf Comment:";
            // 
            // txtLeafName
            // 
            this.txtLeafName.Enabled = false;
            this.txtLeafName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeafName.Location = new System.Drawing.Point(810, 134);
            this.txtLeafName.Multiline = true;
            this.txtLeafName.Name = "txtLeafName";
            this.txtLeafName.Size = new System.Drawing.Size(283, 43);
            this.txtLeafName.TabIndex = 6;
            this.txtLeafName.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(810, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Leaf Name:";
            // 
            // lblLine1
            // 
            this.lblLine1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine1.Location = new System.Drawing.Point(-8, 419);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(795, 2);
            this.lblLine1.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(785, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(2, 728);
            this.label11.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(1, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 17);
            this.label12.TabIndex = 40;
            this.label12.Text = "ROOT";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(1, 425);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 17);
            this.label13.TabIndex = 41;
            this.label13.Text = "TREE";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(793, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 17);
            this.label14.TabIndex = 42;
            this.label14.Text = "LEAF";
            // 
            // cboLeafType
            // 
            this.cboLeafType.FormattingEnabled = true;
            this.cboLeafType.Location = new System.Drawing.Point(810, 304);
            this.cboLeafType.Name = "cboLeafType";
            this.cboLeafType.Size = new System.Drawing.Size(283, 21);
            this.cboLeafType.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(877, 191);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(149, 2);
            this.label15.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(785, 650);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(325, 2);
            this.label16.TabIndex = 44;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(17, 163);
            this.label17.MaximumSize = new System.Drawing.Size(100, 200);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 33);
            this.label17.TabIndex = 46;
            this.label17.Text = "Location:  (3 letters)";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(20, 192);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(43, 20);
            this.txtLocation.TabIndex = 0;
            // 
            // txtLeafLocation
            // 
            this.txtLeafLocation.Location = new System.Drawing.Point(1052, 370);
            this.txtLeafLocation.Name = "txtLeafLocation";
            this.txtLeafLocation.Size = new System.Drawing.Size(43, 20);
            this.txtLeafLocation.TabIndex = 11;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(949, 377);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(97, 13);
            this.label19.TabIndex = 49;
            this.label19.Text = "Location (3 letters):";
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Location = new System.Drawing.Point(785, 462);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(325, 2);
            this.label18.TabIndex = 67;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Blue;
            this.label20.Location = new System.Drawing.Point(793, 464);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 17);
            this.label20.TabIndex = 68;
            this.label20.Text = "SEARCH";
            // 
            // cboSearchName
            // 
            this.cboSearchName.FormattingEnabled = true;
            this.cboSearchName.Location = new System.Drawing.Point(813, 569);
            this.cboSearchName.Name = "cboSearchName";
            this.cboSearchName.Size = new System.Drawing.Size(280, 21);
            this.cboSearchName.TabIndex = 69;
            this.cboSearchName.SelectedIndexChanged += new System.EventHandler(this.cboSearchName_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(814, 553);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(165, 13);
            this.label21.TabIndex = 70;
            this.label21.Text = "Search Leafs By Name (To Leaf):";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(814, 511);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(177, 13);
            this.label22.TabIndex = 72;
            this.label22.Text = "Search Leafs By Category (To Grid):";
            // 
            // cboSearchCategory
            // 
            this.cboSearchCategory.FormattingEnabled = true;
            this.cboSearchCategory.Location = new System.Drawing.Point(811, 527);
            this.cboSearchCategory.Name = "cboSearchCategory";
            this.cboSearchCategory.Size = new System.Drawing.Size(282, 21);
            this.cboSearchCategory.TabIndex = 71;
            this.cboSearchCategory.SelectedIndexChanged += new System.EventHandler(this.cboSearchCategory_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(813, 602);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(176, 13);
            this.label23.TabIndex = 74;
            this.label23.Text = "Search Leafs By Keyword (To Grid):";
            // 
            // txtSrchKeyWrd
            // 
            this.txtSrchKeyWrd.Location = new System.Drawing.Point(813, 618);
            this.txtSrchKeyWrd.Name = "txtSrchKeyWrd";
            this.txtSrchKeyWrd.Size = new System.Drawing.Size(233, 20);
            this.txtSrchKeyWrd.TabIndex = 84;
            // 
            // btnSrchKeyWrd
            // 
            this.btnSrchKeyWrd.Location = new System.Drawing.Point(1052, 615);
            this.btnSrchKeyWrd.Name = "btnSrchKeyWrd";
            this.btnSrchKeyWrd.Size = new System.Drawing.Size(41, 23);
            this.btnSrchKeyWrd.TabIndex = 76;
            this.btnSrchKeyWrd.Text = "Find";
            this.btnSrchKeyWrd.UseVisualStyleBackColor = true;
            this.btnSrchKeyWrd.Click += new System.EventHandler(this.btnSrchKeyWrd_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.mergeToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1109, 24);
            this.menuStrip1.TabIndex = 77;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.reportsToolStripMenuItem.Text = "Stats";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // mergeToolStripMenuItem1
            // 
            this.mergeToolStripMenuItem1.Name = "mergeToolStripMenuItem1";
            this.mergeToolStripMenuItem1.Size = new System.Drawing.Size(53, 20);
            this.mergeToolStripMenuItem1.Text = "Merge";
            this.mergeToolStripMenuItem1.Click += new System.EventHandler(this.mergeToolStripMenuItem1_Click);
            // 
            // chkRestrictToTreeId
            // 
            this.chkRestrictToTreeId.AutoSize = true;
            this.chkRestrictToTreeId.Location = new System.Drawing.Point(892, 483);
            this.chkRestrictToTreeId.Name = "chkRestrictToTreeId";
            this.chkRestrictToTreeId.Size = new System.Drawing.Size(146, 17);
            this.chkRestrictToTreeId.TabIndex = 78;
            this.chkRestrictToTreeId.Text = "Restrict Results to TreeId";
            this.chkRestrictToTreeId.UseVisualStyleBackColor = true;
            // 
            // btnPrintSrchRslt
            // 
            this.btnPrintSrchRslt.Location = new System.Drawing.Point(832, 687);
            this.btnPrintSrchRslt.Name = "btnPrintSrchRslt";
            this.btnPrintSrchRslt.Size = new System.Drawing.Size(88, 62);
            this.btnPrintSrchRslt.TabIndex = 79;
            this.btnPrintSrchRslt.Text = "Print From Grid";
            this.btnPrintSrchRslt.UseVisualStyleBackColor = true;
            this.btnPrintSrchRslt.Click += new System.EventHandler(this.btnPrintSrchRslt_Click);
            // 
            // btnDelTree
            // 
            this.btnDelTree.Location = new System.Drawing.Point(157, 501);
            this.btnDelTree.Name = "btnDelTree";
            this.btnDelTree.Size = new System.Drawing.Size(108, 23);
            this.btnDelTree.TabIndex = 80;
            this.btnDelTree.Text = "Delete This Tree";
            this.btnDelTree.UseVisualStyleBackColor = true;
            this.btnDelTree.Click += new System.EventHandler(this.btnDelTree_Click);
            // 
            // btnDelLeaf
            // 
            this.btnDelLeaf.Location = new System.Drawing.Point(976, 401);
            this.btnDelLeaf.Name = "btnDelLeaf";
            this.btnDelLeaf.Size = new System.Drawing.Size(80, 51);
            this.btnDelLeaf.TabIndex = 81;
            this.btnDelLeaf.Text = "Delete This Leaf";
            this.btnDelLeaf.UseVisualStyleBackColor = true;
            this.btnDelLeaf.Click += new System.EventHandler(this.btnDelLeaf_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(20, 280);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(248, 20);
            this.txtComment.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tree Comment:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(23, 309);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(92, 13);
            this.label24.TabIndex = 83;
            this.label24.Text = "Tree Create Date:";
            // 
            // txtCreateDate
            // 
            this.txtCreateDate.Enabled = false;
            this.txtCreateDate.Location = new System.Drawing.Point(20, 325);
            this.txtCreateDate.Name = "txtCreateDate";
            this.txtCreateDate.Size = new System.Drawing.Size(248, 20);
            this.txtCreateDate.TabIndex = 82;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 766);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtCreateDate);
            this.Controls.Add(this.btnDelLeaf);
            this.Controls.Add(this.btnDelTree);
            this.Controls.Add(this.btnPrintSrchRslt);
            this.Controls.Add(this.chkRestrictToTreeId);
            this.Controls.Add(this.btnSrchKeyWrd);
            this.Controls.Add(this.txtSrchKeyWrd);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cboSearchCategory);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cboSearchName);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtLeafLocation);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboLeafType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtLeafName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtLeafComment);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSaveLeaf);
            this.Controls.Add(this.txtLeafId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboLeafSubCat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboLeafCategory);
            this.Controls.Add(this.chkLeafViewed);
            this.Controls.Add(this.btnGetUTrees);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboUTrees);
            this.Controls.Add(this.lblTreeId);
            this.Controls.Add(this.txtTreeId);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnListPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTreeName);
            this.Controls.Add(this.btnSaveDb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnLoadFromDb);
            this.Controls.Add(this.dgvTreeList);
            this.Controls.Add(this.lblStat);
            this.Controls.Add(this.chkFiles);
            this.Controls.Add(this.lvFiles);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtRootPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLine1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folder Lister";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreeList)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtRootPath;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.CheckBox chkFiles;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.DataGridView dgvTreeList;
        private System.Windows.Forms.Button btnLoadFromDb;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnSaveDb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTreeName;
        private System.Windows.Forms.Button btnListPath;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblTreeId;
        private System.Windows.Forms.TextBox txtTreeId;
        private System.Windows.Forms.ComboBox cboUTrees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetUTrees;
        private System.Windows.Forms.CheckBox chkLeafViewed;
        private System.Windows.Forms.ComboBox cboLeafCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboLeafSubCat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLeafId;
        private System.Windows.Forms.Button btnSaveLeaf;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLeafComment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLeafName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboLeafType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtLeafLocation;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboSearchName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cboSearchCategory;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtSrchKeyWrd;
        private System.Windows.Forms.Button btnSrchKeyWrd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkRestrictToTreeId;
        private System.Windows.Forms.Button btnPrintSrchRslt;
        private System.Windows.Forms.Button btnDelTree;
        private System.Windows.Forms.Button btnDelLeaf;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtCreateDate;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeToolStripMenuItem1;
    }
}


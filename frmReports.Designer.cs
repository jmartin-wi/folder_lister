namespace Folder_Lister
{
    partial class frmReports
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDupLeafNameByTreeId = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTreeId = new System.Windows.Forms.Label();
            this.cboUTrees = new System.Windows.Forms.ComboBox();
            this.dgvTreeList = new System.Windows.Forms.DataGridView();
            this.label24 = new System.Windows.Forms.Label();
            this.txtCreateDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTreeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblStat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lvLeafSizes = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumLeafs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(630, 502);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 41);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDupLeafNameByTreeId
            // 
            this.btnDupLeafNameByTreeId.Location = new System.Drawing.Point(113, 101);
            this.btnDupLeafNameByTreeId.Name = "btnDupLeafNameByTreeId";
            this.btnDupLeafNameByTreeId.Size = new System.Drawing.Size(98, 41);
            this.btnDupLeafNameByTreeId.TabIndex = 1;
            this.btnDupLeafNameByTreeId.Text = "Show";
            this.btnDupLeafNameByTreeId.UseVisualStyleBackColor = true;
            this.btnDupLeafNameByTreeId.Click += new System.EventHandler(this.btnDupLeafNameByTreeId_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(43, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Duplicate Leaf Name from Tree Id above:";
            // 
            // lblTreeId
            // 
            this.lblTreeId.AutoSize = true;
            this.lblTreeId.Location = new System.Drawing.Point(43, 55);
            this.lblTreeId.Name = "lblTreeId";
            this.lblTreeId.Size = new System.Drawing.Size(44, 13);
            this.lblTreeId.TabIndex = 4;
            this.lblTreeId.Text = "Tree Id:";
            // 
            // cboUTrees
            // 
            this.cboUTrees.FormattingEnabled = true;
            this.cboUTrees.Location = new System.Drawing.Point(43, 71);
            this.cboUTrees.Name = "cboUTrees";
            this.cboUTrees.Size = new System.Drawing.Size(248, 21);
            this.cboUTrees.TabIndex = 22;
            this.cboUTrees.SelectedIndexChanged += new System.EventHandler(this.cboUTrees_SelectedIndexChanged);
            // 
            // dgvTreeList
            // 
            this.dgvTreeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreeList.Location = new System.Drawing.Point(25, 186);
            this.dgvTreeList.Name = "dgvTreeList";
            this.dgvTreeList.Size = new System.Drawing.Size(685, 137);
            this.dgvTreeList.TabIndex = 71;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(399, 101);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(92, 13);
            this.label24.TabIndex = 91;
            this.label24.Text = "Tree Create Date:";
            // 
            // txtCreateDate
            // 
            this.txtCreateDate.Enabled = false;
            this.txtCreateDate.Location = new System.Drawing.Point(396, 117);
            this.txtCreateDate.Name = "txtCreateDate";
            this.txtCreateDate.Size = new System.Drawing.Size(248, 20);
            this.txtCreateDate.TabIndex = 90;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "Tree Name:";
            // 
            // txtTreeName
            // 
            this.txtTreeName.Enabled = false;
            this.txtTreeName.Location = new System.Drawing.Point(396, 30);
            this.txtTreeName.Name = "txtTreeName";
            this.txtTreeName.Size = new System.Drawing.Size(248, 20);
            this.txtTreeName.TabIndex = 85;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "Tree Comment:";
            // 
            // txtComment
            // 
            this.txtComment.Enabled = false;
            this.txtComment.Location = new System.Drawing.Point(396, 71);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(248, 20);
            this.txtComment.TabIndex = 86;
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.ForeColor = System.Drawing.Color.Blue;
            this.lblStat.Location = new System.Drawing.Point(22, 533);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(41, 13);
            this.lblStat.TabIndex = 92;
            this.lblStat.Text = "Ready.";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(-1, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(721, 2);
            this.label2.TabIndex = 93;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 13);
            this.label5.TabIndex = 94;
            this.label5.Text = "Smallest 5 Leaf\'s from Tree Id above:";
            // 
            // lvLeafSizes
            // 
            this.lvLeafSizes.FullRowSelect = true;
            this.lvLeafSizes.GridLines = true;
            this.lvLeafSizes.Location = new System.Drawing.Point(25, 380);
            this.lvLeafSizes.Name = "lvLeafSizes";
            this.lvLeafSizes.Size = new System.Drawing.Size(556, 137);
            this.lvLeafSizes.TabIndex = 96;
            this.lvLeafSizes.UseCompatibleStateImageBehavior = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 98;
            this.label6.Text = "Number Of Leaf\'s:";
            // 
            // txtNumLeafs
            // 
            this.txtNumLeafs.Enabled = false;
            this.txtNumLeafs.Location = new System.Drawing.Point(497, 147);
            this.txtNumLeafs.Name = "txtNumLeafs";
            this.txtNumLeafs.Size = new System.Drawing.Size(58, 20);
            this.txtNumLeafs.TabIndex = 97;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(90, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 20);
            this.label7.TabIndex = 99;
            this.label7.Text = "Folder Lister - Statistics";
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 555);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumLeafs);
            this.Controls.Add(this.lvLeafSizes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStat);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtCreateDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTreeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.dgvTreeList);
            this.Controls.Add(this.cboUTrees);
            this.Controls.Add(this.lblTreeId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDupLeafNameByTreeId);
            this.Controls.Add(this.btnClose);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folder Lister Reports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDupLeafNameByTreeId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTreeId;
        private System.Windows.Forms.ComboBox cboUTrees;
        private System.Windows.Forms.DataGridView dgvTreeList;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtCreateDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTreeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvLeafSizes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumLeafs;
        private System.Windows.Forms.Label label7;
    }
}
namespace Folder_Lister
{
    partial class frmMerge
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
            this.clbTreesToMerge = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStat = new System.Windows.Forms.Label();
            this.btnMerge = new System.Windows.Forms.Button();
            this.txtMergeTreeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMergeTreeComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMergeCreateDT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumLeafs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNewTreCom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNewTreNam = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(422, 289);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 50);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // clbTreesToMerge
            // 
            this.clbTreesToMerge.FormattingEnabled = true;
            this.clbTreesToMerge.Location = new System.Drawing.Point(12, 79);
            this.clbTreesToMerge.Name = "clbTreesToMerge";
            this.clbTreesToMerge.Size = new System.Drawing.Size(305, 94);
            this.clbTreesToMerge.TabIndex = 1;
            this.clbTreesToMerge.SelectedIndexChanged += new System.EventHandler(this.clbTreesToMerge_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Trees To Merge:";
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.ForeColor = System.Drawing.Color.Blue;
            this.lblStat.Location = new System.Drawing.Point(9, 326);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(41, 13);
            this.lblStat.TabIndex = 3;
            this.lblStat.Text = "Ready.";
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(47, 277);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(120, 39);
            this.btnMerge.TabIndex = 4;
            this.btnMerge.Text = "Merge These Trees";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // txtMergeTreeName
            // 
            this.txtMergeTreeName.Enabled = false;
            this.txtMergeTreeName.Location = new System.Drawing.Point(344, 79);
            this.txtMergeTreeName.Name = "txtMergeTreeName";
            this.txtMergeTreeName.Size = new System.Drawing.Size(191, 20);
            this.txtMergeTreeName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tree Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tree Comment:";
            // 
            // txtMergeTreeComment
            // 
            this.txtMergeTreeComment.Enabled = false;
            this.txtMergeTreeComment.Location = new System.Drawing.Point(344, 128);
            this.txtMergeTreeComment.Name = "txtMergeTreeComment";
            this.txtMergeTreeComment.Size = new System.Drawing.Size(191, 20);
            this.txtMergeTreeComment.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tree Create Date:";
            // 
            // txtMergeCreateDT
            // 
            this.txtMergeCreateDT.Enabled = false;
            this.txtMergeCreateDT.Location = new System.Drawing.Point(344, 179);
            this.txtMergeCreateDT.Name = "txtMergeCreateDT";
            this.txtMergeCreateDT.Size = new System.Drawing.Size(191, 20);
            this.txtMergeCreateDT.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(139, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Folder Lister - Merge Trees";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 100;
            this.label6.Text = "Number Of Leaf\'s:";
            // 
            // txtNumLeafs
            // 
            this.txtNumLeafs.Enabled = false;
            this.txtNumLeafs.Location = new System.Drawing.Point(439, 221);
            this.txtNumLeafs.Name = "txtNumLeafs";
            this.txtNumLeafs.Size = new System.Drawing.Size(58, 20);
            this.txtNumLeafs.TabIndex = 99;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 104;
            this.label7.Text = "New Tree Comment:";
            // 
            // txtNewTreCom
            // 
            this.txtNewTreCom.Location = new System.Drawing.Point(12, 244);
            this.txtNewTreCom.Name = "txtNewTreCom";
            this.txtNewTreCom.Size = new System.Drawing.Size(191, 20);
            this.txtNewTreCom.TabIndex = 103;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 102;
            this.label8.Text = "New Tree Name:";
            // 
            // txtNewTreNam
            // 
            this.txtNewTreNam.Location = new System.Drawing.Point(12, 202);
            this.txtNewTreNam.Name = "txtNewTreNam";
            this.txtNewTreNam.Size = new System.Drawing.Size(191, 20);
            this.txtNewTreNam.TabIndex = 101;
            // 
            // frmMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 361);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNewTreCom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNewTreNam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumLeafs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMergeCreateDT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMergeTreeComment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMergeTreeName);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.lblStat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clbTreesToMerge);
            this.Controls.Add(this.btnClose);
            this.Name = "frmMerge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merge Trees";
            this.Load += new System.EventHandler(this.frmMerge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckedListBox clbTreesToMerge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.TextBox txtMergeTreeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMergeTreeComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMergeCreateDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumLeafs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNewTreCom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNewTreNam;
    }
}
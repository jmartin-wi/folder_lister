using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Folder_Lister
{
    public partial class frmMerge : Form
    {
        public frmMerge()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //close
            //FormMain.Visible = true;
            this.Close();
        }

        private void frmMerge_Load(object sender, EventArgs e)
        {
            lblStat.Text = load_CLB();

        }

        private string load_CLB()
        {
            string strRetMsg = "Load CheckListBox failed. Ready.";
            //fill TREE cbo with current unique trees
            List<DTO.cboItem> lstUTrees = DAL.get_Unique_Trees();
            if (lstUTrees.Count() < 1)
            {
                lstUTrees.Insert(0, new DTO.cboItem("None", "0"));
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = lstUTrees;
            clbTreesToMerge.DataSource = bs;
            clbTreesToMerge.DisplayMember = "Name";
            clbTreesToMerge.ValueMember = "Id";
            strRetMsg = "Load CheckListBox succeeded. Ready.";
            return strRetMsg;
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            //merge these trees
            if (clbTreesToMerge.CheckedItems.Count > 0)
            {
                btnMerge.Text = "Merge These Trees (" + clbTreesToMerge.CheckedItems.Count.ToString() + ")";
                Application.DoEvents();
                List<string> lstTreeIds = new List<string>();
                DTO.cboItem CboItem = new DTO.cboItem("","");
                List<DTO.cboItem> lstDboItem = new List<DTO.cboItem>();
                lstTreeIds.Add(txtNewTreNam.Text);
                lstTreeIds.Add(txtNewTreCom.Text);
                foreach (DTO.cboItem lvItem in clbTreesToMerge.CheckedItems)
                {
                    lstTreeIds.Add(lvItem.Id.ToString());
                }
                lblStat.Text = DAL.merge_Trees(lstTreeIds);
            }
            else
            {
                lblStat.Text = "No Trees checked. Ready.";
            }
        }

        private void clbTreesToMerge_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load text boxes with tree-to-merge info
            try
            {
                List<DTO.DocTree> mergeDocTree = DAL.get_Tree_By_TreeId(clbTreesToMerge.SelectedValue.ToString());
                txtMergeTreeName.Text = mergeDocTree[0].TreeName.ToString();
                txtMergeTreeComment.Text = mergeDocTree[0].TreeComment.ToString();
                txtMergeCreateDT.Text = mergeDocTree[0].TreeCreateDate.ToString();
                txtNumLeafs.Text = mergeDocTree.Count.ToString();
            }
            catch (Exception ex)
            {
                lblStat.Text = "Error loading Leaf (" + ex.Message.ToString() + "). Ready.";
            }
        }
    }
}

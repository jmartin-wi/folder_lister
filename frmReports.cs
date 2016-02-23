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
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            fill_Cbo();
        }

        private void get_Small_Leafs()
        {
            if(cboUTrees.SelectedValue.ToString() == "0") { return; };
            List<Tuple<string, string, string>> lstTplLeafs = DAL.get_Smallest_Leaf(cboUTrees.SelectedValue.ToString());
            lvLeafSizes.View = View.Details;
            lvLeafSizes.Columns.Add("Size b", 100, HorizontalAlignment.Left);
            lvLeafSizes.Columns.Add("Size MB", 75, HorizontalAlignment.Left);
            lvLeafSizes.Columns.Add("Name", 500, HorizontalAlignment.Left);
            lvLeafSizes.Columns.Add("Area", 50, HorizontalAlignment.Left);

            foreach (Tuple<string, string, string> tpl in lstTplLeafs)
            {
                long lngOut;
                long.TryParse(tpl.Item1, out lngOut);
                string strSiz = Util.GetBytesReadable(lngOut);
                string strCom = lngOut.ToString("#,###,###,###,##0");
                var item1 = new ListViewItem(new[] { strCom, strSiz, tpl.Item2, tpl.Item3 });
                lvLeafSizes.Items.Add(item1);
            }
        }

        private void fill_Cbo()
        {
            //fill TREE cbo with current unique trees
            List<DTO.cboItem> lstUTrees = DAL.get_Unique_Trees();
            if (lstUTrees.Count() > 0)
            {
                lstUTrees.Insert(0, new DTO.cboItem("Please select a Tree", "0"));
            }
            else
            {
                lstUTrees.Insert(0, new DTO.cboItem("None", "0"));
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = lstUTrees;
            cboUTrees.DataSource = bs;
            cboUTrees.DisplayMember = "Name";
            cboUTrees.ValueMember = "Id";
            //cboUTrees.SelectionChanged += new SelectionChangedEventHandler(cboUTrees_SelectionChanged);
        }

        private void btnDupLeafNameByTreeId_Click(object sender, EventArgs e)
        {
            //tree id selected, populate TreeId text box
            dgvTreeList.DataSource = null;
            dgvTreeList.Rows.Clear();
            dgvTreeList.Columns.Clear();
            dgvTreeList.Refresh();
            string strTreeId = cboUTrees.SelectedValue.ToString();
            if (strTreeId.Length == 36)
            {
                    //lblTreeId.Text = "Tree Id (" + strCnt + "):";
                //load dvg
                DataTable dt = DAL.rtp_Get_Dup_Leaf_Names_By_TreeId(strTreeId);
                if (dt.Rows.Count > 0)
                {
                    dgvTreeList.DataSource = dt;
                    dgvTreeList.Refresh();
                    lblTreeId.Text = string.Format("Tree ID ({0}):", dt.Rows.Count.ToString());
                    lblStat.Text = "Load from DB complete (" + dt.Rows.Count.ToString() + "). Ready.";
                }
                else
                {
                    dgvTreeList.Columns.Add("Result", "Result");
                    dgvTreeList.Columns[0].Width = 100;
                    dgvTreeList.Rows.Add();
                    dgvTreeList.Rows[0].Cells[0].Value = "None";
                    lblStat.Text = "Load from DB complete (0). Ready.";
                }
                get_Small_Leafs();
                Application.DoEvents();
            }
            else
            {
                lblStat.Text = "Must first select a Tree. Ready.";
            }
    }

        private void cboUTrees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUTrees.SelectedValue.ToString().Length == 36)
            {
                DataTable dt = DAL.get_Tree_By_TreeId_DataTable(cboUTrees.SelectedValue.ToString());
                txtTreeName.Text = dt.Rows[0]["treeName"].ToString();
                txtComment.Text = dt.Rows[0]["treeComment"].ToString();
                txtCreateDate.Text = dt.Rows[0]["treeCreateDate"].ToString();
                txtNumLeafs.Text = dt.Rows.Count.ToString();
            }
            dgvTreeList.DataSource = null;
            dgvTreeList.Refresh();
            lvLeafSizes.Clear();
        }
    }
}

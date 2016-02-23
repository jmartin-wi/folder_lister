using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Folder_Lister
{
    public partial class frmMain : Form
    {
        DTO.DocTree editLeaf = new DTO.DocTree();

        public frmMain()
        {
            InitializeComponent();
            editLeaf = null;
        }

        /// <summary>
        /// Import files from filesystem to the database
        /// </summary>
        /// <remarks>This is a heavy one-time operation. If used on a job, it should run off-peak</remarks>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //browse for tree-to-view's root folder
            FolderBrowserDialog diag = new FolderBrowserDialog();
            diag.Description = "Select a folder for Tree root.";
            diag.SelectedPath = Application.StartupPath;

            if (DialogResult.OK == diag.ShowDialog())
            {
                string selectedPath = diag.SelectedPath;
                txtRootPath.Text = selectedPath;
                string[] filesToImport;
                if (chkFiles.Checked)
                {
                    filesToImport = Directory.GetFiles(selectedPath, "*", SearchOption.AllDirectories);
                }
                else
                {
                    filesToImport = Directory.GetDirectories(selectedPath, "*", SearchOption.AllDirectories);
                }
                string strCnt = filesToImport.Count().ToString();
                Application.DoEvents();
                lblStat.Text = "Done getting folder list (" + strCnt + "). Ready.";
                lblPath.Text = "Path (" + strCnt + ")";
            }
        }

        private string loadGridViewFromDB()
        {
            //get all trees from db
            string strMsg = "Folder Document Insert failed.";
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblTrees"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dgvTreeList.DataSource = dt;
                                dgvTreeList.Refresh();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return strMsg;
        }

        private static long GetDirectorySize(string parentDirectory)
        {
            return new DirectoryInfo(parentDirectory).GetFiles("*.*", SearchOption.AllDirectories).Sum(file => file.Length);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void chkFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiles.Checked)
            {
                chkFiles.Text = "Show Also Files";
            }
            else
            {
                chkFiles.Text = "Show Only Folders";
            }
        }

        private void btnLoadFromDb_Click(object sender, EventArgs e)
        {
            try
            {
                dgvTreeList.DataSource = null;
                dgvTreeList.Refresh();
                if (!string.IsNullOrEmpty(txtTreeId.Text))
                {
                    DataTable dt = DAL.get_Tree_By_TreeId_DataTable(txtTreeId.Text);
                    //sort the dataview (can't sort datatable)
                    DataView dv = dt.DefaultView;
                    dv.Sort = "leafName asc";
                    DataTable sortedDT = dv.ToTable();
                    //bind the DataGridView
                    dgvTreeList.DataSource = sortedDT;
                    dgvTreeList.Refresh();
                    txtTreeName.Text = dt.Rows[0]["treeName"].ToString();
                    txtComment.Text = dt.Rows[0]["treeComment"].ToString();
                    txtCreateDate.Text = dt.Rows[0]["treeCreateDate"].ToString();
                    lblTreeId.Text = string.Format("Tree ID ({0}):", dt.Rows.Count.ToString());
                    Application.DoEvents();
                    lblStat.Text = "Load from DB complete. Ready.";
                }
                else
                {
                    lblStat.Text = "Error loading from DB. Ready.";
                }
            }
            catch (Exception ex)
            {
                lblStat.Text = "Error loading from DB (" + ex.Message.ToString() + "). Ready.";
            }
        }

        private void btnSaveDb_Click(object sender, EventArgs e)
        {
            lblStat.Text = saveTreeToDb();
        }

        private string saveTreeToDb()
        {
            //save tree to db
            string strRetMsg = "Save to DB failed.";
            string[] filesToImport;
            try
            {
                //set up treeview

                //now do listview stuff
                int iCnt = 0;
                //set up the list view
                lvFiles.Clear();
                lvFiles.Columns.Add("Name", -2, HorizontalAlignment.Left);
                lvFiles.Columns[0].Width = 300;
                //lvFiles.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvFiles.Columns.Add("Size", -2, HorizontalAlignment.Left);
                if (!Util.FileOrDirectoryExists(txtRootPath.Text))
                {
                    strRetMsg = String.Format("Invalid tree root path (" + txtRootPath.Text + "). Ready.");
                    return strRetMsg;
                }
                if (string.IsNullOrEmpty(txtTreeName.Text))
                {
                    DateTime dt = DateTime.UtcNow;
                    txtTreeName.Text = String.Format("Default Tree Name_{0}", dt.ToString("yyyyMMddHHMMss"));
                }
                string selectedPath = txtRootPath.Text.Replace("'", "");
                txtRootPath.Text = selectedPath;
                if (chkFiles.Checked)
                {
                    filesToImport = Directory.GetFiles(selectedPath, "*", SearchOption.AllDirectories);
                }
                else
                {
                    filesToImport = Directory.GetDirectories(selectedPath, "*", SearchOption.AllDirectories);
                }
                string strTreeId = Guid.NewGuid().ToString();
                string strTreeCreateDate = DateTime.UtcNow.ToString();
                txtTreeId.Text = strTreeId;
                //first save the new tree
                DTO.DocTree inDocTree = new DTO.DocTree
                    {
                        TreeId = strTreeId,
                        TreeName = txtTreeName.Text,
                        TreeRoot = selectedPath,
                        TreeCreateDate = strTreeCreateDate,
                        TreeComment = txtComment.Text,
                        TreeType = "Video"
                    };
                lblStat.Text = "Saving Tree to db . . .";
                Application.DoEvents();
                strRetMsg = DAL.save_One_New_Tree(inDocTree);
                //got path, iterate folders
                foreach (var filePath in filesToImport)
                {
                    iCnt++;
                    var file = new FileInfo(filePath);

                    string[] treePath = filePath.Replace(selectedPath, "").Split('\\');
                    var folderSize = GetDirectorySize(filePath);
                    var folderName = file.Name.Replace("'", "").Replace(",", "_");

                    DTO.DocTree newDocFold = new DTO.DocTree
                    {
                        TreeId = strTreeId,
                        TreeName = txtTreeName.Text,
                        TreeCreateDate = strTreeCreateDate,
                        TreeComment = txtComment.Text,
                        TreeType = Guid.NewGuid().ToString(),
                        TreeRoot = selectedPath.Replace("'", ""),
                        LeafId = Guid.NewGuid().ToString(),
                        LeafName = folderName,
                        LeafCreated = file.CreationTime.ToString(),
                        LeafCreatUser = file.FullName.Replace("'", ""),
                        LeafPath = file.Directory.ToString().Replace("'", ""),
                        LeafSize = folderSize.ToString(),
                        LeafCategory = "Imported",
                        LeafSubCategory = "None",
                        LeafLocation = txtLocation.Text,
                        LeafType = "Video",
                        LeafViewed = "false",
                        LeafComment = txtLeafComment.Text
                    };
                    //save the new leaf
                    strRetMsg = DAL.save_One_New_Leaf(newDocFold);
                    //add the leaf to the listview
                    var lvFolder = new ListViewItem(new[] { newDocFold.LeafName, newDocFold.LeafSize });
                    lvFolder.Tag = newDocFold;
                    lvFiles.Items.Add(lvFolder);
                    lblStat.Text = lblStat.Text + " .";
                    Application.DoEvents();
                }
                //completed tree & leaf save operation
                Application.DoEvents();
                lblStat.Text = "Done saving Tree and Leaf's (" + iCnt.ToString() + "). Ready.";
            }
            catch (Exception ex)
            {
                lblStat.Text = "Error saving tree to DB: " + ex.Message + ".";
            }
            return strRetMsg;
        }

        private void btnListPath_Click(object sender, EventArgs e)
        {
            //list path to listview
            load_Lv(txtRootPath.Text);
        }

        private void load_Lv(string inTreePath)
        {
            string[] filesToImport;
            try
            {
                int iCnt = 0;
                //set up the list view
                lvFiles.Clear();
                lvFiles.Columns.Add("Name", -2, HorizontalAlignment.Left);
                lvFiles.Columns[0].Width = 300;
                //lvFiles.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvFiles.Columns.Add("Size", -2, HorizontalAlignment.Right);
                if (!Util.FileOrDirectoryExists(txtRootPath.Text))
                {
                    lblStat.Text = string.Format("Invalid tree root path (" + txtRootPath.Text + "). Ready.");
                    return;
                }
                string selectedPath = txtRootPath.Text;
                txtRootPath.Text = selectedPath;
                if (chkFiles.Checked)
                {
                    filesToImport = Directory.GetFiles(selectedPath, "*", SearchOption.AllDirectories);
                }
                else
                {
                    filesToImport = Directory.GetDirectories(selectedPath, "*", SearchOption.AllDirectories);
                }
                Array.Sort(filesToImport);

                if (filesToImport.Count() > 100)
                {
                    if (MessageBox.Show("Tree size very big (" + filesToImport.Count().ToString() + "). Are you sure you want to save ALL these?", "File Lister", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                }
                string strTreeId = Guid.NewGuid().ToString();
                string strTreeCreateDate = DateTime.UtcNow.ToString();
                //got path, iterate folders
                foreach (var filePath in filesToImport)
                {
                    iCnt++;
                    var file = new FileInfo(filePath);

                    string[] treePath = filePath.Replace(selectedPath, "").Split('\\');

                    var folderSize = GetDirectorySize(filePath);
                    long len = GetDirectorySize(filePath);
                    string readableSize = Util.GetBytesReadable(len);

                    DTO.DocTree newDocFold = new DTO.DocTree
                    {
                        TreeId = strTreeId,
                        TreeName = txtTreeName.Text,
                        TreeCreateDate = strTreeCreateDate,
                        TreeComment = txtComment.Text,
                        TreeRoot = selectedPath,
                        LeafId = Guid.NewGuid().ToString(),
                        LeafName = file.Name.Replace("'",""),
                        LeafCreated = file.CreationTime.ToString(),
                        LeafCreatUser = file.FullName,
                        LeafPath = file.Directory.ToString(),
                        LeafSize = readableSize,
                        LeafCategory = "Imported",
                        LeafType = "Folder",
                        LeafComment = "Autogen"
                    };

                    var lvFolder = new ListViewItem(new[] { newDocFold.LeafName, newDocFold.LeafSize });
                    lvFolder.Tag = newDocFold;
                    lvFiles.Items.Add(lvFolder);
                }
                Application.DoEvents();
                lblStat.Text = "Done getting folder list (" + iCnt.ToString() + "). Ready.";
            }
            catch (Exception ex)
            {
                lblStat.Text = "Error saving tree to DB: " + ex.Message + ".";
            }

        }

        private void load_tv_from_diag()
        {
            //fill the treeview from dialog selection

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //send_To_Word();
            List<DTO.DocTree> SortedList = DAL.get_Tree_By_TreeId(txtTreeId.Text);
            List<DTO.DocTree> dtoLeaves = SortedList.OrderBy(o => o.LeafName).ToList();
            Util.send_To_Word(dtoLeaves);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //fill cbo with current unique trees
                this.cboSearchName.SelectedIndexChanged -= new System.EventHandler(this.cboSearchName_SelectedIndexChanged);
                this.cboSearchCategory.SelectedIndexChanged -= new System.EventHandler(this.cboSearchCategory_SelectedIndexChanged);
                fill_Cbo();
                this.cboSearchName.SelectedIndexChanged += new System.EventHandler(this.cboSearchName_SelectedIndexChanged);
                this.cboSearchCategory.SelectedIndexChanged += new System.EventHandler(this.cboSearchCategory_SelectedIndexChanged);
                lblStat.Text = "Ready.";
            }
            catch (Exception ex)
            {
                lblStat.Text = "Form load error: " + ex.Message + ". Ready.";
            }
        }

        private void fill_Cbo()
        {
            try
            {
                //fill TREE cbo with current unique trees
                List<DTO.cboItem> lstUTrees = DAL.get_Unique_Trees();
                if (lstUTrees.Count() > 0)
                {
                    lstUTrees.Insert(0, new DTO.cboItem("Please select a Tree to get TreeId", "0"));
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

                //fill CATEGORY cbo with unique categories from DB
                List<DTO.cboItem> lstUCats = DAL.get_Unique_Leaf_Categories();
                if (lstUCats.Count() > 0)
                {
                    lstUCats.Insert(0, new DTO.cboItem("Please select a Category", "0"));
                }
                else
                {
                    lstUCats.Insert(0, new DTO.cboItem("None", "0"));
                }
                BindingSource bs2 = new BindingSource();
                bs2.DataSource = lstUCats;
                cboLeafCategory.DataSource = bs2;
                cboLeafCategory.DisplayMember = "Name";
                cboLeafCategory.ValueMember = "Id";

                //fill SUB-CATEGORY cbo with unique sub-categories from DB
                List<DTO.cboItem> lstUSubCats = DAL.get_Unique_Sub_Categories();
                if (lstUSubCats.Count() > 0)
                {
                    lstUSubCats.Insert(0, new DTO.cboItem("Please select a Sub-Category", "0"));
                }
                else
                {
                    lstUSubCats.Insert(0, new DTO.cboItem("None", "0"));
                }
                BindingSource bs3 = new BindingSource();
                bs3.DataSource = lstUSubCats;
                cboLeafSubCat.DataSource = bs3;
                cboLeafSubCat.DisplayMember = "Name";
                cboLeafSubCat.ValueMember = "Id";

                //fill LEAF TYPE cbo with unique leaf Types from DB
                List<DTO.cboItem> lstLeafTypes = DAL.get_Unique_Leaf_Types();
                if (lstLeafTypes.Count() > 0)
                {
                    lstLeafTypes.Insert(0, new DTO.cboItem("Please select a Leaf Type", "0"));
                }
                else
                {
                    lstLeafTypes.Insert(0, new DTO.cboItem("None", "0"));
                }
                BindingSource bs4 = new BindingSource();
                bs4.DataSource = lstLeafTypes;
                cboLeafType.DataSource = bs4;
                cboLeafType.DisplayMember = "Name";
                cboLeafType.ValueMember = "Id";

                //fill SEARCH cbo with unique leaf NAME from DB
                List<DTO.cboItem> lstLeafNames = DAL.get_Unique_Leaf_Names();
                if (lstLeafNames.Count() > 0)
                {
                    lstLeafNames.Insert(0, new DTO.cboItem("Please select a Leaf Name", "0"));
                }
                else
                {
                    lstLeafNames.Insert(0, new DTO.cboItem("None", "0"));
                }
                BindingSource bs5 = new BindingSource();
                bs5.DataSource = lstLeafNames;
                cboSearchName.DisplayMember = "Name";
                cboSearchName.ValueMember = "Id";
                cboSearchName.DataSource = bs5;

                //fill SEARCH cbo with unique leaf CATEGORY from DB
                List<DTO.cboItem> lstLeafCategory = DAL.get_Unique_Leaf_Categories();
                if (lstLeafCategory.Count() > 0)
                {
                    lstLeafCategory.Insert(0, new DTO.cboItem("Please select a Leaf Category", "0"));
                }
                else
                {
                    lstLeafCategory.Insert(0, new DTO.cboItem("None", "0"));
                }
                BindingSource bs6 = new BindingSource();
                bs6.DataSource = lstLeafCategory;
                cboSearchCategory.DisplayMember = "Name";
                cboSearchCategory.ValueMember = "Id";
                cboSearchCategory.DataSource = bs6;
            }
            catch (Exception ex)
            {
                string crap = "yup";
            }
            txtTreeId.Text = "";
        }

        private void btnGetUTrees_Click(object sender, EventArgs e)
        {
            try
            {
                //fill cbo with current unique trees
                fill_Cbo();
                lblStat.Text = "Unique Trees retrieved. Ready.";
            }
            catch (Exception ex)
            {
                lblStat.Text = "Unique Trees load error: " + ex.Message + ". Ready.";
            }
        }

        private void cboUTrees_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tree id selected, populate TreeId text box
            txtTreeId.Text = cboUTrees.SelectedValue.ToString();
            string strCnt = DAL.get_Leaf_Count_For_Tree_By_TreeId(txtTreeId.Text);
            if (!string.IsNullOrEmpty(strCnt))
            {
                lblTreeId.Text = "Tree Id (" + strCnt + "):";
            }
            else
            {
                lblTreeId.Text = "Tree Id:";
            }
        }

        private void dgvTreeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string viewLeafId = dgvTreeList[12, e.RowIndex].Value.ToString();
                editLeaf = DAL.get_Leaf_By_LeafId(viewLeafId);
                if (!string.IsNullOrEmpty(viewLeafId))
                {
                    txtLeafId.Text = editLeaf.LeafId.ToString();
                    if (!string.IsNullOrEmpty(editLeaf.LeafViewed))
                    {
                        if (editLeaf.LeafViewed == "false")
                        {
                            chkLeafViewed.Checked = false;
                        }
                        else
                        {
                            chkLeafViewed.Checked = true;
                        }
                    }
                    else
                    {
                        chkLeafViewed.Checked = false;
                    }
                    cboLeafCategory.Text = editLeaf.LeafCategory;
                    cboLeafSubCat.Text = editLeaf.LeafSubCategory;
                    txtLeafLocation.Text = editLeaf.LeafLocation;
                    cboLeafType.Text = editLeaf.LeafType;
                    txtLeafComment.Text = editLeaf.LeafComment;
                    txtLeafName.Text = editLeaf.LeafName;
                }
            }
            catch (Exception ex)
            {
                string crap = "yup";
            }
        }

        private void btnSaveLeaf_Click(object sender, EventArgs e)
        {
            lblStat.Text = update_Leaf();
            fill_Cbo();
        }

        private string update_Leaf()
        {
            string strRetMsg = "Update Leaf failed. Ready.";
            if (editLeaf == null)
            {
                return strRetMsg;
            }
            try
            {
                //save leaf info from text boxes
                //put new info into DTO
                editLeaf.LeafViewed = chkLeafViewed.Checked.ToString();
                editLeaf.LeafComment = txtLeafComment.Text;
                editLeaf.LeafType = cboLeafType.Text;
                editLeaf.LeafCategory = cboLeafCategory.Text;
                editLeaf.LeafSubCategory = cboLeafSubCat.Text;
                editLeaf.LeafLocation = txtLocation.Text;

                //send new info'd DTO to DAL
                lblStat.Text = DAL.update_Leaf(editLeaf);

                strRetMsg = "Update Leaf completed. Ready.";
            }
            catch (Exception ex)
            {
                lblStat.Text = "Error updating new Leaf info (" + ex.Message + "). Ready.";
            }
            Application.DoEvents();
            return strRetMsg;
        }

        private void cboSearchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //search for single leaf by Leaf Name
            string srchId = cboSearchName.SelectedValue.ToString();
            DTO.DocTree dtoLeaf;
            if (chkRestrictToTreeId.Checked)
            {
                dtoLeaf = DAL.get_Leaf_By_LeafId_By_TreeId(srchId, txtTreeId.Text);
            }
            else
            {
                dtoLeaf = DAL.get_Leaf_By_LeafId(srchId);
            }
            
            if (dtoLeaf.TreeId != null)
            {
                //got part/leaf name to edit, fill editable text boxes
                txtLeafId.Text = dtoLeaf.TreeId.ToString();
                if (!string.IsNullOrEmpty(dtoLeaf.LeafViewed))
                {
                    chkLeafViewed.Checked = true;
                }
                else
                {
                    chkLeafViewed.Checked = false;
                }
                cboLeafCategory.Text = dtoLeaf.LeafCategory;
                cboLeafSubCat.Text = dtoLeaf.LeafSubCategory;
                txtLeafLocation.Text = dtoLeaf.LeafLocation;
                cboLeafType.Text = dtoLeaf.LeafType;
                txtLeafComment.Text = dtoLeaf.LeafComment;
                txtLeafName.Text = dtoLeaf.LeafName;
                lblStat.Text = "NAME search completed. Ready.";
            }
            else
            {
                lblStat.Text = "Error NAME search, invalid Leaf from DB. Ready.";
            }
        }

        private void cboSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load grid from db for CATEGORY search
            if (cboSearchCategory.Text == "Please select a Leaf Category") { return; }
            DataTable dt;
            try
            {
                if (chkRestrictToTreeId.Checked)
                {
                    dt = DAL.get_Leafs_By_Category_DataTable_By_Tree(cboSearchCategory.Text, txtTreeId.Text);
                }
                else
                {
                    dt = DAL.get_Leafs_By_Category_DataTable(cboSearchCategory.Text);
                }
                dgvTreeList.DataSource = dt;
                dgvTreeList.Refresh();
                txtTreeId.Text = dt.Rows[0]["treeId"].ToString();
                txtTreeName.Text = dt.Rows[0]["treeName"].ToString();
                txtComment.Text = dt.Rows[0]["treeComment"].ToString();
                txtCreateDate.Text = dt.Rows[0]["treeCreateDate"].ToString();
                lblTreeId.Text = string.Format("Tree ID: ({0})", dt.Rows.Count.ToString());
                Application.DoEvents();
                lblStat.Text = "Load from Search DB complete. Ready.";
            }
            catch (Exception ex)
            {
                lblStat.Text = "Error loading from Search DB (" + ex.Message.ToString() + "). Ready.";
            }
        }

        private void btnSrchKeyWrd_Click(object sender, EventArgs e)
        {
            //search for leaf group by KEYWORD in Leaf Name
            try
            {
                DataTable dt;
                if (chkRestrictToTreeId.Checked)
                {
                    dt = DAL.get_Leaf_By_Keyword_Datatable_By_TreeId(txtSrchKeyWrd.Text, txtTreeId.Text);
                }
                else
                {
                    dt = DAL.get_Leafs_By_Keyword_Datatable(txtSrchKeyWrd.Text);
                }
                if (string.IsNullOrEmpty(txtSrchKeyWrd.Text)) { return; }
                dgvTreeList.DataSource = dt;
                dgvTreeList.Refresh();
                txtTreeId.Text = dt.Rows[0]["treeId"].ToString();
                txtTreeName.Text = dt.Rows[0]["treeName"].ToString();
                txtComment.Text = dt.Rows[0]["treeComment"].ToString();
                txtCreateDate.Text = dt.Rows[0]["treeCreateDate"].ToString();
                lblTreeId.Text = string.Format("Tree ID: ({0})", dt.Rows.Count.ToString());
                Application.DoEvents();
                lblStat.Text = "Load from Keyword Search DB complete. Ready.";
            }
            catch (Exception ex)
            {
                lblStat.Text = "Error loading from Keyword Search DB (" + ex.Message.ToString() + "). Ready.";
            }
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //merge
            frmMerge FormMerge = new frmMerge();
            if (FormMerge.ShowDialog() == DialogResult.OK)
            {
                frmMain fm = new frmMain();
                fm.Show();
            }
        }

        private void btnPrintSrchRslt_Click(object sender, EventArgs e)
        {
            //print search results from gridview
            //put dt into dto
            List<DTO.DocTree> lstDocTree = new List<DTO.DocTree>();
            try
            {
                if (dgvTreeList.Rows.Count > 0)
                {
                    DTO.DocTree docTree;
                    foreach (DataGridViewRow row in dgvTreeList.Rows)
                    {
                        DataRow myRow = (row.DataBoundItem as DataRowView).Row;
                        docTree = DAL.build_Tree_Row(myRow);
                        lstDocTree.Add(docTree);
                    }
                }
            }
            catch (Exception ex)
            {
                lblStat.Text = "Error in grid print: " + ex.Message + ". Ready.";
            }
            finally
            {
                if (lstDocTree.Count > 0)
                {
                    List<DTO.DocTree> dtoLeaves = lstDocTree.OrderBy(o => o.LeafName).ToList();
                    Util.send_To_Word(dtoLeaves);
                }
            }
        }

        private void btnDelTree_Click(object sender, EventArgs e)
        {
            //delete this tree
            lblStat.Text = DAL.delete_Tree(txtTreeId.Text);
        }

        private void btnDelLeaf_Click(object sender, EventArgs e)
        {
            //delete this leaf
            lblStat.Text = DAL.delete_Leaf(txtLeafId.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reports
            frmReports FormReports = new frmReports();
            if (FormReports.ShowDialog() == DialogResult.OK)
            {
                frmMain fm = new frmMain();
                fm.Show();
            }
        }

        private void mergeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //merge
            frmMerge FormMerge = new frmMerge();
            if (FormMerge.ShowDialog() == DialogResult.OK)
            {
                frmMain fm = new frmMain();
                fm.Show();
            }
        }
    }
}

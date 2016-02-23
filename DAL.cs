using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace Folder_Lister
{
    class DAL
    {

        #region Save

        public static String save_One_New_Tree(DTO.DocTree inDocFolder)
        {
            int i = 0;
            //save one folder document object/row to the database
            string strMsg = "Folder Document Insert failed.";
            inDocFolder.TreeRoot = inDocFolder.TreeRoot.Replace("\\", "\\\\");
            //first check if tree (id) already exists, if so just save leaf with existing tree id
            if (!tree_Exists(inDocFolder.TreeId))
            {
                //tree not exist, create new tree
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                    using (MySqlConnection conn = new MySqlConnection(constr))
                    {
                        MySqlCommand cmd = new MySqlCommand("save_one_new_tree", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("ivarTreeId", inDocFolder.TreeId);
                        cmd.Parameters.AddWithValue("ivarTreeName", inDocFolder.TreeName);
                        cmd.Parameters.AddWithValue("ivarRootPath", inDocFolder.TreeRoot);
                        cmd.Parameters.AddWithValue("ivarTreeCreateDate", inDocFolder.TreeCreateDate);
                        cmd.Parameters.AddWithValue("ivarTreeComment", inDocFolder.TreeComment);
                        cmd.Parameters.AddWithValue("ivarTreeType", inDocFolder.TreeType);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException sex)
                {
                    strMsg = "Save Tree SQL error: " + sex.Message + ".";
                }
                catch (Exception ex)
                {
                    strMsg = "Save Tree error: " + ex.Message + ".";
                }
            }
            return strMsg;
        }

        public static String save_One_New_Leaf(DTO.DocTree inDocFolder)
        {
            //save one new Leaf to the database
            string strMsg = "Leaf Insert failed.";
            inDocFolder.LeafPath = inDocFolder.LeafPath.Replace("\\", "\\\\");
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    MySqlCommand cmd = new MySqlCommand("save_one_new_leaf", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ivarTreeId", inDocFolder.TreeId);
                    cmd.Parameters.AddWithValue("ivarLeafId", inDocFolder.LeafId);
                    cmd.Parameters.AddWithValue("ivarLeafName", inDocFolder.LeafName);
                    cmd.Parameters.AddWithValue("ivarLeafSize", inDocFolder.LeafSize);
                    cmd.Parameters.AddWithValue("ivarLeafPath", inDocFolder.LeafPath);
                    cmd.Parameters.AddWithValue("ivarLeafCreateDate", inDocFolder.LeafCreated);
                    cmd.Parameters.AddWithValue("ivarLeafCreateUser", inDocFolder.LeafCreatUser);
                    cmd.Parameters.AddWithValue("ivarLeafCategory", inDocFolder.LeafCategory);
                    cmd.Parameters.AddWithValue("ivarLeafSubCategory", inDocFolder.LeafSubCategory);
                    cmd.Parameters.AddWithValue("ivarLeafLocation", inDocFolder.LeafLocation);
                    cmd.Parameters.AddWithValue("ivarLeafType", inDocFolder.LeafType);
                    cmd.Parameters.AddWithValue("ivarLeafComment", inDocFolder.LeafComment);
                    cmd.Parameters.AddWithValue("ivarLeafViewed", inDocFolder.LeafViewed);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException sex)
            {
                strMsg = "Save Leaf SQL error: " + sex.Message + ".";
            }
            catch (Exception ex)
            {
                strMsg = "Save Leaf error: " + ex.Message + ".";
            }
            return strMsg;
        }

        #endregion

        #region Update

        /// <summary>
        /// Updates 1 leaf by leafId
        /// </summary>
        /// <param name="inDocFolder" type="DTO.DocTree">
        /// <returns String>
        public static String update_Leaf(DTO.DocTree inDocFolder)
        {
            int i = 0;
            //save one folder document object/row to the database
            string strMsg = "Leaf Update failed (Leaf Id: " + inDocFolder.LeafId + ").";
            inDocFolder.LeafPath = inDocFolder.LeafPath.Replace("\\", "\\\\");
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    MySqlCommand cmd = new MySqlCommand("update_leaf", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ivarTreeId", inDocFolder.TreeId);
                    cmd.Parameters.AddWithValue("ivarLeafId", inDocFolder.LeafId);
                    cmd.Parameters.AddWithValue("ivarLeafName", inDocFolder.LeafName);
                    cmd.Parameters.AddWithValue("ivarLeafSize", inDocFolder.LeafSize);
                    cmd.Parameters.AddWithValue("ivarLeafPath", inDocFolder.LeafPath);
                    cmd.Parameters.AddWithValue("ivarLeafCreateDate", inDocFolder.LeafCreated);
                    cmd.Parameters.AddWithValue("ivarLeafCreateUser", inDocFolder.LeafCreatUser);
                    cmd.Parameters.AddWithValue("ivarLeafCategory", inDocFolder.LeafCategory);
                    cmd.Parameters.AddWithValue("ivarLeafSubCategory", inDocFolder.LeafSubCategory);
                    cmd.Parameters.AddWithValue("ivarLeafLocation", inDocFolder.LeafLocation);
                    cmd.Parameters.AddWithValue("ivarLeafType", inDocFolder.LeafType);
                    cmd.Parameters.AddWithValue("ivarLeafComment", inDocFolder.LeafComment);
                    cmd.Parameters.AddWithValue("ivarLeafViewed", inDocFolder.LeafViewed);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException sex)
            {
                strMsg = "Update Leaf SQL error: " + sex.Message + ".";
            }
            catch (Exception ex)
            {
                strMsg = "Update Leaf error: " + ex.Message + ".";
            }
            return strMsg;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes one Tree, and it's leaf's, by TreeId
        /// </summary>
        /// <param name="inLeafId" type="String">
        /// <returns String>
        public static String delete_Tree(string inTreeId)
        {
            //delete one tree from db by treeId
            string strMsg = "Delete Tree failed (" + inTreeId + "). Ready.";
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    MySqlCommand cmd = new MySqlCommand("delete_tree", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ivarTreeId", inTreeId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //TODO: delete this tree's leaf's

                    strMsg = "Delete Tree succeeded (" + inTreeId + "). Ready.";
                }
            }
            catch (MySqlException sex)
            {
                strMsg = "Delete Tree SQL error: " + sex.Message + ".";
            }
            catch (Exception ex)
            {
                strMsg = "Delete Tree error: " + ex.Message + ".";
            }
            return strMsg;
        }

        /// <summary>
        /// Deletes one Leaf by LeafId
        /// </summary>
        /// <param name="inLeafId" type="String">
        /// <returns String>
        public static String delete_Leaf(string inLeafId)
        {
            //delete one tree from db by treeId
            string strMsg = "Delete Leaf succeeded (" + inLeafId + "). Ready.";
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    MySqlCommand cmd = new MySqlCommand("delete_leaf", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ivarLeafId", inLeafId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException sex)
            {
                strMsg = "Delete Leaf SQL error: " + sex.Message + ".";
            }
            catch (Exception ex)
            {
                strMsg = "Delete Leaf error: " + ex.Message + ".";
            }
            return strMsg;
        }

        #endregion

        #region Get

        /// <summary>
        /// Gets one complete tree, with all its leaf's by TreeId
        /// </summary>
        /// <param name="inTreeId" type="String">
        /// <returns List<DTO.DocTree>>
        public static List<DTO.DocTree> get_Tree_By_TreeId(string inTreeId)
        {
            //get only 1 tree from db by Tree Id
            string strMsg = "Error: Get tree (" + inTreeId + ") failed.";
            List<DTO.DocTree> lstDocTree = new List<DTO.DocTree>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Tree_By_TreeId", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ivarTreeId", inTreeId);
                            sda.SelectCommand = cmd;
                            using (DataTable treeDT = new DataTable())
                            {
                                sda.Fill(treeDT);
                                if (treeDT.Rows.Count > 0)
                                {
                                    DTO.DocTree docTree;
                                    foreach (DataRow treeRow in treeDT.Rows)  // for each tree
                                    {
                                        //get all leaf's for this one tree
                                        DataTable leafDT = get_Leafs_By_TreeId(treeRow["treeId"].ToString());
                                        //build dto
                                        foreach (DataRow leafRow in leafDT.Rows)
                                        {
                                            docTree = build_Tree(treeRow, leafRow);
                                            lstDocTree.Add(docTree);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return lstDocTree;
        }

        /// <summary>
        /// Gets one complete tree, with all its leaf's by TreeId into DataTable
        /// </summary>
        /// <param name="inTreeId" type="String">
        /// <returns DataTable>
        public static DataTable get_Tree_By_TreeId_DataTable(string inTreeId)
        {
            //get only 1 tree from db by Tree Id
            string strMsg = "Error: Get tree (" + inTreeId + ") failed.";
            DataTable dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Tree_By_TreeId_DataTable", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ivarTreeId", inTreeId);
                            sda.SelectCommand = cmd;
                            using (dt)
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    return dt;
                                 }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return dt;
        }

        /// <summary>
        /// Gets one Leaf by leafId
        /// </summary>
        /// <param name="inLeafId" type="String">
        /// <returns DTO.DocTree>
        public static DTO.DocTree get_Leaf_By_LeafId(string inLeafId)
        {
            //get only 1 leaf from db by leafId
            string strMsg = "Error: Get Leaf (" + inLeafId + ") failed.";
            DTO.DocTree docTree = new DTO.DocTree();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Leaf_By_LeafId", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ivarLeafId", inLeafId);
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        docTree = build_Leaf_Row(row);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return docTree;
        }

        /// <summary>
        /// Gets count of leaf's for treeId
        /// </summary>
        /// <param name="inTreeId" type="String">
        /// <returns String>
        public static String get_Leaf_Count_For_Tree_By_TreeId(string inTreeId)
        {
            //get only 1 tree from db by Tree Id
            string strMsg = "0";
            DataTable dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Leaf_Count_For_Tree_By_TreeId", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ivarTreeId", inTreeId);
                            sda.SelectCommand = cmd;
                            using (dt)
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    strMsg = dt.Rows[0].ToString();
                                }
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

        /// <summary>
        /// Get 5 smallest size Leafs from db by treeId
        /// </summary>
        /// <param name="inTreeId" type="String">
        /// <returns List<Tuple<string, string, string>>>
        public static List<Tuple<string, string, string>> get_Smallest_Leaf(string inTreeId)
        {
            //get 5 smallest size Leafs from db by Tree Id
            List<Tuple<string, string, string>> tplRetLeafs = new List<Tuple<string, string, string>>();
            DataTable dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Smallest_Leaf", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ivarTreeId", inTreeId);
                            sda.SelectCommand = cmd;
                            using (dt)
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    foreach(DataRow dr in dt.Rows)
                                    {
                                        Tuple<string, string, string> newTpl = Tuple.Create(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                                        tplRetLeafs.Add(newTpl);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return tplRetLeafs;
        }

        /// <summary>
        /// Get only 1 tree (and leafs) from db by treeId
        /// </summary>
        /// <param name="inTreeId" type="String">
        /// <param name="inLeafId" type="String">
        /// <returns DTO.DocTree>
        public static DTO.DocTree get_Leaf_By_LeafId_By_TreeId(string inLeafId, string inTreeId)
        {
            //get only 1 tree from db by Tree Id
            string strMsg = "Error: Get Leaf (" + inLeafId + ") failed.";
            DTO.DocTree docTree = new DTO.DocTree();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Leaf_By_LeafId_By_TreeId", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ivarLeafId", inLeafId);
                            cmd.Parameters.AddWithValue("ivarTreeId", inTreeId);
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        docTree = build_Tree_Row(row);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return docTree;
        }

        /// <summary>
        /// Get leafs of all trees by KeyWord
        /// </summary>
        /// <param name="inKeyWrd" type="String">
        /// <returns DataTable>
        public static DataTable get_Leafs_By_Keyword_Datatable(string inKeyWrd)
        {
            //get leafs of all trees by KeyWord
            string strMsg = "Error: Get Leafs (" + inKeyWrd + ") failed.";
            DataTable dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Leafs_By_Keyword_Datatable", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ivarLeafKeyWrd", inKeyWrd);
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return dt;
        }

        /// <summary>
        /// Get leafs of one tree by KeyWord
        /// </summary>
        /// <param name="inKeyWrd" type="String">
        /// <returns DataTable>
        public static DataTable get_Leaf_By_Keyword_Datatable_By_TreeId(string inKeyWrd, string inTreeId)
        {
            //get leafs of one tree by KeyWord
            string strMsg = "Error: Get Leaf (" + inKeyWrd + ") failed.";
            DataTable dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Leaf_By_Keyword_Datatable_By_TreeId", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ivarLeafKeyWrd", inKeyWrd);
                            cmd.Parameters.AddWithValue("ivarTreeId", inTreeId);
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return dt;
        }

        /// <summary>
        /// Get all leafs for one Tree by treeId
        /// </summary>
        /// <param name="inTreeId" type="String">
        /// <returns DataTable>
        public static DataTable get_Leafs_By_TreeId(string inTreeId)
        {
            //get all leafs for one Tree by Tree Id
            string strMsg = "Error: get_Leafs_By_TreeId (" + inTreeId + ") failed.";
            DataTable dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Leafs_By_TreeId", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ivarTreeId", inTreeId);
                            sda.SelectCommand = cmd;
                            using (dt)
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    return dt;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return dt;
        }

        /// <summary>
        /// Get leafs from all trees by leaf Category
        /// </summary>
        /// <param name="inCat" type="String">
        /// <returns DataTable>
        public static DataTable get_Leafs_By_Category_DataTable(string inCat)
        {
            //get leafs from all trees by leaf Category
            string strMsg = "Error: get_Leafs_By_Category (" + inCat + ") failed.";
            DataTable dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Leafs_By_Category_DataTable", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ivarLeafCat", inCat);
                            sda.SelectCommand = cmd;
                            using (dt)
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    return dt;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return dt;
        }

        /// <summary>
        /// Get leafs of 1 tree by leaf Category
        /// </summary>
        /// <param name="inCat" type="String">
        /// <param name="inTreeId" type="String">
        /// <returns DataTable>
        public static DataTable get_Leafs_By_Category_DataTable_By_Tree(string inCat, string inTreeId)
        {
            //get leafs of 1 tree by leaf Category
            string strMsg = "Error: get_Leafs_By_Category (" + inCat + ") failed.";
            DataTable dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Leafs_By_Category_DataTable_By_Tree", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ivarTreeId", inTreeId);
                            cmd.Parameters.AddWithValue("ivarLeafCat", inCat);
                            sda.SelectCommand = cmd;
                            using (dt)
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    return dt;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return dt;
        }

        /// <summary>
        /// Get all unique tree Id's and their Names from db
        /// </summary>
        /// <returns List<DTO.cboItem>>
        public static List<DTO.cboItem> get_Unique_Trees()
        {
            //get all unique tree id's from db
            string strMsg = "Error: Get tree failed.";
            List<DTO.cboItem> lstDocTree = new List<DTO.cboItem>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Unique_Trees", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        lstDocTree.Add(new DTO.cboItem(row[1].ToString(), row[0].ToString()));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return lstDocTree;
        }

        /// <summary>
        /// Get all unique leaf Categories from db
        /// </summary>
        /// <returns List<DTO.cboItem>>
        public static List<DTO.cboItem> get_Unique_Leaf_Categories()
        {
            //get all unique leaf categories from db
            string strMsg = "Error: get_Unique_Categories failed.";
            List<DTO.cboItem> lstDocTree = new List<DTO.cboItem>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Unique_Categories", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    int i = 1;
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        lstDocTree.Add(new DTO.cboItem(row[0].ToString(), i.ToString()));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return lstDocTree;
        }

        /// <summary>
        /// Get all unique leaf Sub Categories from db
        /// </summary>
        /// <returns List<DTO.cboItem>>
        public static List<DTO.cboItem> get_Unique_Sub_Categories()
        {
            //get all unique tree id's from db
            string strMsg = "Error: get_Unique_Categories failed.";
            List<DTO.cboItem> lstDocTree = new List<DTO.cboItem>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Unique_Sub_Categories", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    int i = 1;
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        lstDocTree.Add(new DTO.cboItem(row[0].ToString(), i.ToString()));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return lstDocTree;
        }

        /// <summary>
        /// Get all unique leaf Types from db
        /// </summary>
        /// <returns List<DTO.cboItem>>
        public static List<DTO.cboItem> get_Unique_Leaf_Types()
        {
            //get all unique leaf Types from db
            string strMsg = "Error: get_Unique_Leaf_Types failed.";
            List<DTO.cboItem> lstDocTree = new List<DTO.cboItem>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Unique_Leaf_Types", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    int i = 1;
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        lstDocTree.Add(new DTO.cboItem(row[0].ToString(), i.ToString()));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return lstDocTree;
        }

        /// <summary>
        /// Get all unique leaf Names from db
        /// </summary>
        /// <returns List<DTO.cboItem>>
        public static List<DTO.cboItem> get_Unique_Leaf_Names()
        {
            //get all unique leaf Names from db
            string strMsg = "Error: get_Unique_Leaf_Names failed.";
            List<DTO.cboItem> lstDocTree = new List<DTO.cboItem>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Unique_Leaf_Names", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        lstDocTree.Add(new DTO.cboItem(row[0].ToString(), row[1].ToString()));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return lstDocTree;
        }

        #endregion

        #region Merge

        /// <summary>
        /// Merge trees in the database to new tree, return new tree Name
        /// </summary>
        /// <param name="inLstTreeIds" type="List<string>">
        /// <returns String>
        public static String merge_Trees(List<string> inLstTreeIds)
        {
            int i = 0;
            //merge trees in the database to new tree, return new tree Name
            string strMsg = "Error: Tree Merge failed.";
            //generate new guid for new tree
            string strNewTreeId = Guid.NewGuid().ToString();
            try
            {
                DTO.DocTree outDocFolder = new DTO.DocTree();
                //first 2 items are New tree name & New tree comment
                outDocFolder.TreeName = inLstTreeIds[0];
                outDocFolder.TreeComment = inLstTreeIds[1];
                outDocFolder.TreeId = strNewTreeId;
                outDocFolder.TreeCreateDate = DateTime.Now.ToString();
                //first save tree, then all leafs
                save_One_New_Tree(outDocFolder);
                //copy all old tree leafs to new tree id in db
                //foreach (String strTId in inLstTreeIds)
                for(i=2;i<inLstTreeIds.Count;i++)  //loop through each string old-tree id
                {
                    if (inLstTreeIds[i].Length == 36)
                    {
                        //get all leafs for this old-tree
                        DataTable dtTreeLeafs = get_Leafs_By_TreeId(inLstTreeIds[i].ToString());
                        //loop through leafs
                        foreach(DataRow dr in dtTreeLeafs.Rows)
                        {
                            //change to new-tree id
                            dr["treeId"] = strNewTreeId;
                            //build dto from dt
                            DTO.DocTree newDocTree = build_Tree_Row(dr);
                            //save this leaf for the new-tree to new-tree id with new dto
                            strMsg = save_One_New_Leaf(newDocTree);
                        }
                    }
                }
                strMsg = string.Format("Tree merge successful ({0}). Ready.", strNewTreeId);
            }
            catch (Exception ex)
            {
                strMsg = "Save error (" + i.ToString() + "): " + ex.Message + ".";
            }
            return strMsg;
        }

        #endregion

        #region Reports

        /// <summary>
        /// Get Duplicate leaf names by Tree Id
        /// </summary>
        /// <param name="inTreeId" type="String">
        /// <returns DataTable>
        public static DataTable rtp_Get_Dup_Leaf_Names_By_TreeId(string inTreeId)
        {
            //get Duplicate leaf names by Tree Id
            string strMsg = "Error: Get tree (" + inTreeId + ") failed.";
            DataTable dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("rtp_Get_Dup_Leaf_Names_By_TreeId", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("ivarTreeId", inTreeId);
                            sda.SelectCommand = cmd;
                            using (dt)
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    return dt;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strMsg = "Fetch & view error: " + ex.Message + ".";
            }
            return dt;
        }

        #endregion

        #region Utility Build

        public static DTO.DocTree build_Tree(DataRow inTreeDr, DataRow inLeafDr)
        {
            DTO.DocTree newDocFold = new DTO.DocTree
            {
                TreeId = inTreeDr["treeId"].ToString() ?? string.Empty,
                TreeName = inTreeDr["treeName"].ToString() ?? string.Empty,
                TreeCreateDate = inTreeDr["treeCreateDate"].ToString() ?? string.Empty,
                TreeComment = inTreeDr["treeComment"].ToString() ?? string.Empty,
                TreeRoot = inTreeDr["treeRoot"].ToString() ?? string.Empty,
                LeafId = inLeafDr["leafId"].ToString() ?? string.Empty,
                LeafName = inLeafDr["leafName"].ToString() ?? string.Empty,
                LeafCreated = inLeafDr["leafCreateDate"].ToString() ?? string.Empty,
                LeafCreatUser = inLeafDr["leafCreateUser"].ToString() ?? string.Empty,
                LeafPath = inLeafDr["leafPath"].ToString() ?? string.Empty,
                LeafSize = inLeafDr["leafSize"].ToString() ?? string.Empty,
                LeafCategory = inLeafDr["leafCategory"].ToString() ?? string.Empty,
                LeafSubCategory = inLeafDr["leafSubCategory"].ToString() ?? string.Empty,
                LeafLocation = inLeafDr["leafLocation"].ToString() ?? string.Empty,
                LeafType = inLeafDr["leafType"].ToString() ?? string.Empty,
                LeafComment = inLeafDr["leafComment"].ToString() ?? string.Empty,
                LeafViewed = inLeafDr["leafViewed"].ToString() ?? string.Empty
            };
            return newDocFold;
        }

        public static DTO.DocTree build_Tree_Row(DataRow inTreeDr)
        {
            DTO.DocTree newDocFold = new DTO.DocTree
            {
                TreeId = inTreeDr["treeId"].ToString() ?? string.Empty,
                TreeName = inTreeDr["treeName"].ToString() ?? string.Empty,
                TreeCreateDate = inTreeDr["treeCreateDate"].ToString() ?? string.Empty,
                TreeComment = inTreeDr["treeComment"].ToString() ?? string.Empty,
                TreeRoot = inTreeDr["treeRoot"].ToString() ?? string.Empty,
                LeafId = inTreeDr["leafId"].ToString() ?? string.Empty,
                LeafName = inTreeDr["leafName"].ToString() ?? string.Empty,
                LeafCreated = inTreeDr["leafCreateDate"].ToString() ?? string.Empty,
                LeafCreatUser = inTreeDr["leafCreateUser"].ToString() ?? string.Empty,
                LeafPath = inTreeDr["leafPath"].ToString() ?? string.Empty,
                LeafSize = inTreeDr["leafSize"].ToString() ?? string.Empty,
                LeafCategory = inTreeDr["leafCategory"].ToString() ?? string.Empty,
                LeafSubCategory = inTreeDr["leafSubCategory"].ToString() ?? string.Empty,
                LeafLocation = inTreeDr["leafLocation"].ToString() ?? string.Empty,
                LeafType = inTreeDr["leafType"].ToString() ?? string.Empty,
                LeafComment = inTreeDr["leafComment"].ToString() ?? string.Empty,
                LeafViewed = inTreeDr["leafViewed"].ToString() ?? string.Empty
            };
            return newDocFold;
        }

        public static DTO.DocTree build_Leaf_Row(DataRow inLeafDr)
        {
            DTO.DocTree newDocFold = new DTO.DocTree
            {
                TreeId = inLeafDr["treeId"].ToString() ?? string.Empty,
                LeafId = inLeafDr["leafId"].ToString() ?? string.Empty,
                LeafName = inLeafDr["leafName"].ToString() ?? string.Empty,
                LeafCreated = inLeafDr["leafCreateDate"].ToString() ?? string.Empty,
                LeafCreatUser = inLeafDr["leafCreateUser"].ToString() ?? string.Empty,
                LeafPath = inLeafDr["leafPath"].ToString() ?? string.Empty,
                LeafSize = inLeafDr["leafSize"].ToString() ?? string.Empty,
                LeafCategory = inLeafDr["leafCategory"].ToString() ?? string.Empty,
                LeafSubCategory = inLeafDr["leafSubCategory"].ToString() ?? string.Empty,
                LeafLocation = inLeafDr["leafLocation"].ToString() ?? string.Empty,
                LeafType = inLeafDr["leafType"].ToString() ?? string.Empty,
                LeafComment = inLeafDr["leafComment"].ToString() ?? string.Empty,
                LeafViewed = inLeafDr["leafViewed"].ToString() ?? string.Empty
            };
            return newDocFold;
        }

        /// <summary>
        /// Get tree Count from db by Tree Id
        /// </summary>
        /// <param name="inTreeId" type="String">
        /// <returns Boolean>
        internal static Boolean tree_Exists(string inTreeId)
        {
            //get tree Count from db by Tree Id
            Boolean isTree = false;
            DataTable dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["flMySql"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("get_Tree_Count_By_TreeId", conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (dt)
                            {
                                sda.Fill(dt);
                                if ((dt.Rows.Count > 0) && (dt.Rows[0][0].ToString() != "0"))
                                {
                                    isTree = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                isTree = false;
            }
            return isTree;
        }

        #endregion

    }
}

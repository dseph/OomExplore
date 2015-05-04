using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OomExplore
{
    public partial class SelectFolder : Form
    {

        Microsoft.Office.Interop.Outlook._NameSpace _oNS = null;
        public string _CurrentStoreId = string.Empty;
        public string _CurrentFolderId = string.Empty;
        public bool ChoseOK = false;

        //public SelectFolder()
        //{
        //    InitializeComponent();
        //}

        public SelectFolder(ref Microsoft.Office.Interop.Outlook._NameSpace oNS)
        {
            InitializeComponent();

            _oNS = oNS;
            TreeHelper.LoadStoresIntoTreeView(ref _oNS, ref tvFolders);

        }

        public string CurrentStoreId
        {
            get { return _CurrentStoreId; }
            set { _CurrentStoreId = value; }
        }

        public string CurrentFolderId
        {
            get { return _CurrentFolderId; }
            set { _CurrentFolderId = value; }
        }	

        private void tvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                FolderTag oFolderTag = (FolderTag)e.Node.Tag;
                _CurrentStoreId = oFolderTag.StoreID;
                _CurrentFolderId = oFolderTag.EntryID;

            }
        }

        private void tvFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                if ((e.Node.GetNodeCount(false) == 1) && (e.Node.Nodes[0].Text == ""))
                {
                    e.Node.Nodes[0].Remove();
                    FolderTag oFolderTag = (FolderTag)e.Node.Tag;
                    _CurrentStoreId = oFolderTag.StoreID;
                    _CurrentFolderId = oFolderTag.EntryID;

                    TreeNode oNode = e.Node;
                    TreeHelper.AddFolderToTreeNode(ref _oNS, ref oNode, _CurrentStoreId, _CurrentFolderId);
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format("Unable to expand the list {0}: {1}", e.Node.FullPath, ex.ToString()));
            }
        }

        private void SelectFolder_Load(object sender, EventArgs e)
        {
             
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _CurrentFolderId = string.Empty;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_CurrentFolderId.Length != 0)
            {
                ChoseOK = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Select Folder", "Folder not selected.");
            }
        }
    }
}
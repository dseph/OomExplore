using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Outlook;
 
using System.Runtime.InteropServices;

// TODO: Add a reference to the Microsoft Outlook 12.0 Object Library 

namespace OomExplore
{
    public partial class Main : Form
    {
        Microsoft.Office.Interop.Outlook._Application _oApp = null;
        Microsoft.Office.Interop.Outlook._NameSpace _oNS = null;
        string _CurrentStoreId = string.Empty;
        string _CurrentFolderId = string.Empty;

        //string _DefaultMessageFilter = "";
        
        string _DefaultMessageFilter = "[MessageClass]>='IPM.Note' AND [MessageClass]<='IPM.Note.ZZZ'";
        string _DefaultContactFilter = "[MessageClass]>='IPM.Contact' AND [MessageClass]<='IPM.Contact.ZZZ'";
        string _DefaultAppointmentFilter = "[MessageClass]>='IPM.Appointment' AND [MessageClass]<='IPM.Appointment.ZZZ'";
       // string _DefaultTaskFilter = "[MessageClass]>='IPM.Appointment' AND [MessageClass]<='IPM.Task.ZZZ'";
        string _UseMessageFilter = string.Empty;
        string _UseContactFilter = string.Empty;
        string _UseAppointmentFilter = string.Empty; 

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            _UseMessageFilter = _DefaultMessageFilter;
            _UseContactFilter = _DefaultContactFilter;
            _UseAppointmentFilter = _DefaultAppointmentFilter;

            _oApp = new Microsoft.Office.Interop.Outlook.Application();
            _oNS = _oApp.GetNamespace("mapi");
            _oNS.Logon("Outlook",null,false,true);
            TreeHelper.LoadStoresIntoTreeView(ref _oNS, ref tvFolders);

            //Marshal.ReleaseComObject(oNS);
            //oNS = null;
        }

                     
                    
        private void LoadTreeNodes()
        {

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

        private void tvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            if (e.Node.Tag != null)
            {

                    FolderTag oFolderTag = (FolderTag)e.Node.Tag;
                    _CurrentStoreId = oFolderTag.StoreID;
                    _CurrentFolderId = oFolderTag.EntryID;

                    LoadViewForFolder(e.Node.SelectedImageIndex, ref listView1);
                    //LoadViewForFolder(oFolderTag.DefaultMessageClass, ref listView1);
                    if (e.Node.SelectedImageIndex != 1)
                    listView1.ContextMenu = null;
                else
                    listView1.ContextMenuStrip = cmsItems;
            }

            this.Cursor = System.Windows.Forms.Cursors.Default;
 
        }

        //private void LoadViewForFolder(string sDefaultFolderClass, ref ListView oListView)
        //{

        //    //if (sDefaultFolderClass == "xxxx")
        //    //{
        //    //    LoadViewForStoreFolder(ref oListView);
        //    //}

        //    if (sDefaultFolderClass == "IPM.Note")
        //    {
        //        string sUseFilter = string.Empty;
        //        //sUseFilter = "@SQL=[MessageClass] like 'IPM.Note%";
        //        //sUseFilter = "[MessageClass]>='IPM.Note' AND [MessageClass]<='IPM.Note.ZZZ'";
        //        LoadViewForMessageFolder(ref oListView, _UseMessageFilter);

        //    }

        //    if (sDefaultFolderClass == "IPM.Contact")
        //    {
        //        LoadViewForContactFolder(ref oListView, _UseContactFilter);

        //    }
        //}


        private void LoadViewForFolder(int iFolderType, ref ListView oListView)
        {
            switch(iFolderType)
            {
                case 1:
                    LoadViewForStoreFolder(ref oListView);
                    break;
                case 2:     // "IPM.Note"
                    LoadViewForMessageFolder(ref oListView, _UseMessageFilter);
                    break;
                case 3:     // "IPM.Contact"
                    LoadViewForContactFolder(ref oListView, _UseContactFilter);
                    break;
                case 4:     // "IPM.Appointment"
                   LoadViewForAppointmentFolder(ref oListView, _UseAppointmentFilter);
                    break;
                case 5:     // "IPM.Task"
                    LoadViewForDefault(ref oListView);
                    break;
                case 6:     // "IPM.StickyNote"
                    LoadViewForDefault(ref oListView);
                    break;
                case 7:     // "IPM.Activity"
                    LoadViewForDefault(ref oListView);
                    break;
                default:
                    LoadViewForDefault(ref oListView);
                    break;
            }
             

      
        }
        private void LoadViewForDefault(ref ListView oListView )
        {
            oListView.Visible = false;
        }

        private void LoadViewForAppointmentFolder(ref ListView oListView, string sUseFilter)
        {
            //oListView.Visible = false;
            oListView.Visible = false;

            // Generic Items List.
            Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = _oNS.GetFolderFromID(_CurrentFolderId, _CurrentStoreId);

            if (oFolder.DefaultItemType == Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem)
            {
                oListView.Clear();
                oListView.View = System.Windows.Forms.View.Details;
                oListView.GridLines = true;
                //oListView.Dock = DockStyle.Fill;
 
                oListView.Columns.Add("Subject", 300, HorizontalAlignment.Left);
                oListView.Columns.Add("Location", 200, HorizontalAlignment.Left);
                oListView.Columns.Add("Start", 200, HorizontalAlignment.Left);
                oListView.Columns.Add("StartTimeZone", 2100, HorizontalAlignment.Left);
                oListView.Columns.Add("End", 200, HorizontalAlignment.Left);
                oListView.Columns.Add("EndTimeZone", 200, HorizontalAlignment.Left);
                oListView.Columns.Add("Organizer", 300, HorizontalAlignment.Left);
                oListView.Columns.Add("RequiredAttendees", 300, HorizontalAlignment.Left);
                oListView.Columns.Add("OptionalAttendees", 300, HorizontalAlignment.Left);
                oListView.Columns.Add("IsRecurring", 100, HorizontalAlignment.Left);
                oListView.Columns.Add("MeetingStatus", 100, HorizontalAlignment.Left);
                oListView.Columns.Add("Size", 200, HorizontalAlignment.Left);
                oListView.Columns.Add("EntryId", 100, HorizontalAlignment.Left);


 

                Microsoft.Office.Interop.Outlook.AppointmentItem oAppointmentItem = null;
             

                string sFilter = string.Empty;
                sUseFilter = _DefaultAppointmentFilter;
                
                Microsoft.Office.Interop.Outlook.Items oItems = null;
                if (sUseFilter.Trim().Length != 0)
                {
                    oItems = oFolder.Items.Restrict(sUseFilter);
                }
                else
                {
                    oItems = oFolder.Items;
                }

                int iMax = oItems.Count;
                toolStripProgressBar1.ProgressBar.Maximum = 100;
                int iMod = (int)(iMax / 100);
                if (iMod == 0)
                    iMod = 1;
                int iAt = 0;
                for (int iCount = 1; iCount <= iMax; iCount++)
                {

                    if (iCount % iMod == 0)
                    {
                        iAt = (iCount / iMod);
                        if (iAt <= 100)
                            toolStripProgressBar1.ProgressBar.Value = (iCount / iMod);
                    }
                    
 
                        oAppointmentItem = (AppointmentItem)oItems[iCount];

                        if (oAppointmentItem.MessageClass == "IPM.Appointment")
                            {
                                try
                                {

                                // oContactItem = (Microsoft.Office.Interop.Outlook.ContactItem)oItems[iCount];
                                //oContactItem = (Microsoft.Office.Interop.Outlook.ContactItem)oItem;

                                ListViewItem oListItem = null;


                                oListItem = new ListViewItem(oAppointmentItem.Subject, 0);
                                oListItem.SubItems.Add(oAppointmentItem.Location);
                                oListItem.SubItems.Add(oAppointmentItem.Start.ToString());

                                if (oAppointmentItem.StartTimeZone != null)
                                    oListItem.SubItems.Add(oAppointmentItem.StartTimeZone.ToString());
                                else
                                    oListItem.SubItems.Add("");

                                if (oAppointmentItem.End != null)
                                    oListItem.SubItems.Add(oAppointmentItem.End.ToString());
                                else
                                    oListItem.SubItems.Add("");

                                if (oAppointmentItem.EndTimeZone != null)
                                    oListItem.SubItems.Add(oAppointmentItem.EndTimeZone.ToString());
                                else
                                    oListItem.SubItems.Add("");

                                if (oAppointmentItem.Organizer != null)
                                    oListItem.SubItems.Add(oAppointmentItem.Organizer);
                                else
                                    oListItem.SubItems.Add("");

                                if (oAppointmentItem.RequiredAttendees != null)
                                    oListItem.SubItems.Add(oAppointmentItem.RequiredAttendees.ToString());
                                else
                                    oListItem.SubItems.Add("");

                                if (oAppointmentItem.OptionalAttendees != null)
                                    oListItem.SubItems.Add(oAppointmentItem.OptionalAttendees.ToString());
                                else
                                    oListItem.SubItems.Add("");
                                 
                                oListItem.SubItems.Add(oAppointmentItem.IsRecurring.ToString());


                                if (oAppointmentItem.MeetingStatus != null)
                                    oListItem.SubItems.Add(oAppointmentItem.MeetingStatus.ToString());
                                else
                                    oListItem.SubItems.Add("");

                                oListItem.SubItems.Add(oAppointmentItem.Size.ToString());

                                if (oAppointmentItem.EntryID != null)
                                    oListItem.SubItems.Add(oAppointmentItem.EntryID.ToString());
                                else
                                    oListItem.SubItems.Add("");

 
                                 

                                ItemTag oItemTag = new ItemTag(_CurrentStoreId, oAppointmentItem.EntryID, oAppointmentItem.MessageClass);
                                oListItem.Tag = oItemTag;
                                oListView.Items.AddRange(new ListViewItem[] { oListItem });
                            }
                            catch (System.Exception Ex)
                            {
                                MessageBox.Show("Error", Ex.Message);
                            }

                            Marshal.ReleaseComObject(oAppointmentItem);
                            oAppointmentItem = null;
                        }
                }

                Marshal.ReleaseComObject(oItems);
                Marshal.ReleaseComObject(oFolder);
                oItems = null;
                oFolder = null;
            }

            oListView.Visible = true;
            toolStripProgressBar1.ProgressBar.Value = 0;

        }

        private string StringIfNull(string sString)
        {
            if (sString == null)
                return "";
            else
                return sString;
        }


        private void LoadViewForContactFolder(ref ListView oListView, string sUseFilter)
        {
            //oListView.Visible = false;
            oListView.Visible = false;

            // Generic Items List.
            Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = _oNS.GetFolderFromID(_CurrentFolderId, _CurrentStoreId);

            if (oFolder.DefaultItemType == Microsoft.Office.Interop.Outlook.OlItemType.olContactItem)
            {
                oListView.Clear();
                oListView.View = System.Windows.Forms.View.Details;
                oListView.GridLines = true;
                //oListView.Dock = DockStyle.Fill;

                oListView.Columns.Add("FullName", 3000, HorizontalAlignment.Left);
                oListView.Columns.Add("ManagerName", 200, HorizontalAlignment.Left);
                oListView.Columns.Add("Title", 200, HorizontalAlignment.Left);
                oListView.Columns.Add("Department", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("PrimaryTelephoneNumber", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("Email1Address", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("MessageClass", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("Size", 150, HorizontalAlignment.Left);

                Microsoft.Office.Interop.Outlook.ContactItem oContactItem = null;
           

                string sFilter = string.Empty;
                sUseFilter = _DefaultContactFilter;
                
                Microsoft.Office.Interop.Outlook.Items oItems = null;
                if (sUseFilter.Trim().Length != 0)
                {
                    oItems = oFolder.Items.Restrict(sUseFilter);
                }
                else
                {
                    oItems = oFolder.Items;
                }

                int iMax = oItems.Count;
                toolStripProgressBar1.ProgressBar.Maximum = 100;
                int iMod = (int)(iMax / 100);
                if (iMod == 0)
                    iMod = 1;
                int iAt = 0;
                for (int iCount = 1; iCount <= iMax; iCount++)
                {

                    if (iCount % iMod == 0)
                    {
                        iAt = (iCount / iMod);
                        if (iAt <= 100)
                            toolStripProgressBar1.ProgressBar.Value = (iCount / iMod);
                    }
                    
 
                    oContactItem = (ContactItem)oItems[iCount];

                    if (oContactItem.MessageClass == "IPM.Contact")
                    {

                        try
                        {
                            // oContactItem = (Microsoft.Office.Interop.Outlook.ContactItem)oItems[iCount];
                            //oContactItem = (Microsoft.Office.Interop.Outlook.ContactItem)oItem;

                            ListViewItem oListItem = null;


                            oListItem = new ListViewItem(oContactItem.FullName, 0);
                            oListItem.SubItems.Add(oContactItem.ManagerName);
                            oListItem.SubItems.Add(oContactItem.Title);
                            oListItem.SubItems.Add(oContactItem.Department);
                            oListItem.SubItems.Add(oContactItem.PrimaryTelephoneNumber);
                            oListItem.SubItems.Add(oContactItem.Email1Address);
                            oListItem.SubItems.Add(oContactItem.MessageClass);
                            oListItem.SubItems.Add(oContactItem.Size.ToString());
                            ItemTag oItemTag = new ItemTag(_CurrentStoreId, oContactItem.EntryID, oContactItem.MessageClass);
                            oListItem.Tag = oItemTag;
                            oListView.Items.AddRange(new ListViewItem[] { oListItem });
                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show("Error", ex.Message);
                            //}

                            Marshal.ReleaseComObject(oContactItem);
                            oContactItem = null;

                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("Error", ex.Message);
                        }
                    }
                }

                Marshal.ReleaseComObject(oItems);
                Marshal.ReleaseComObject(oFolder);
                oItems = null;
                oFolder = null;
            }

            oListView.Visible = true;
            toolStripProgressBar1.ProgressBar.Value = 0;

        }


 
        private void LoadViewForStoreFolder(ref ListView oListView)
        {
            //oListView.Visible = false;
            oListView.Visible = false;
 
            oListView.Clear();
            oListView.View = System.Windows.Forms.View.Details;
            oListView.GridLines = true;
            //oListView.Dock = DockStyle.Fill;

            oListView.Columns.Add("Property", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("Value", 150, HorizontalAlignment.Left);


            Microsoft.Office.Interop.Outlook._Store oStore = _oNS.GetStoreFromID(_CurrentStoreId);

            ListViewItem oListItem = null;

            oListItem = new ListViewItem("ExchangeStoreType", 0);
            oListItem.SubItems.Add(oStore.ExchangeStoreType.ToString());
            oListView.Items.AddRange(new ListViewItem[] { oListItem });

            oListItem = new ListViewItem("Class", 0);
            oListItem.SubItems.Add(oStore.Class.ToString());
            oListView.Items.AddRange(new ListViewItem[] { oListItem });

            oListItem = new ListViewItem("DisplayName", 0);
            oListItem.SubItems.Add(oStore.DisplayName);
            oListView.Items.AddRange(new ListViewItem[] { oListItem });

            oListItem = new ListViewItem("FilePath", 0);
            oListItem.SubItems.Add(oStore.FilePath);
            oListView.Items.AddRange(new ListViewItem[] { oListItem });


            oListItem = new ListViewItem("IsCachedExchange", 0);
            oListItem.SubItems.Add(oStore.IsCachedExchange.ToString());
            oListView.Items.AddRange(new ListViewItem[] { oListItem });


            oListItem = new ListViewItem("IsDataFileStore", 0);
            oListItem.SubItems.Add(oStore.IsDataFileStore.ToString());
            oListView.Items.AddRange(new ListViewItem[] { oListItem });

            oListItem = new ListViewItem("IsInstantSearchEnabled", 0);
            oListItem.SubItems.Add(oStore.IsInstantSearchEnabled.ToString());
            oListView.Items.AddRange(new ListViewItem[] { oListItem });

            oListItem = new ListViewItem("IsDataFileStore", 0);
            oListItem.SubItems.Add(oStore.IsDataFileStore.ToString());
            oListView.Items.AddRange(new ListViewItem[] { oListItem });

            oListItem = new ListViewItem("IsOpen", 0);
            oListItem.SubItems.Add(oStore.IsOpen.ToString());
            oListView.Items.AddRange(new ListViewItem[] { oListItem });

            oListItem = new ListViewItem("MAPIOBJECT", 0);
            oListItem.SubItems.Add(oStore.MAPIOBJECT.ToString());
            oListView.Items.AddRange(new ListViewItem[] { oListItem });

            oListItem = new ListViewItem("StoreID", 0);
            oListItem.SubItems.Add(oStore.StoreID);
            oListView.Items.AddRange(new ListViewItem[] { oListItem });

            oListItem = null;
            Marshal.ReleaseComObject(oStore);
            oStore = null;
            oListView.Visible = true;
        }


        private void LoadViewForMessageFolder(ref ListView oListView, string sUseFilter)
        {
            //oListView.Visible = false;
            oListView.Visible = false;

             // Generic Items List.
            Microsoft.Office.Interop.Outlook.MAPIFolder oFolder =  _oNS.GetFolderFromID(_CurrentFolderId, _CurrentStoreId);

            if (oFolder.DefaultItemType == Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
            {
                oListView.Clear();
                oListView.View = System.Windows.Forms.View.Details;
                oListView.GridLines = true;
                //oListView.Dock = DockStyle.Fill;

                oListView.Columns.Add("Subject", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("From", 50, HorizontalAlignment.Left);
                oListView.Columns.Add("To", 50, HorizontalAlignment.Left);
                oListView.Columns.Add("SentOn", 50, HorizontalAlignment.Left);
                oListView.Columns.Add("Recieved", 50, HorizontalAlignment.Left);
                oListView.Columns.Add("MessageClass", 50, HorizontalAlignment.Left);
                oListView.Columns.Add("Size", 50, HorizontalAlignment.Left);

                Microsoft.Office.Interop.Outlook.MailItem oMailItem = null;
                string sFilter = string.Empty;
                //sUseFilter = "@SQL=[MessageClass] like 'IPM.Note%";
                //sUseFilter = "[MessageClass]>='IPM.Note' AND [MessageClass]<='IPM.Note.ZZZ'";
                Microsoft.Office.Interop.Outlook.Items oItems = null;
                if (sUseFilter.Trim().Length != 0)
                {
                    oItems = oFolder.Items.Restrict(sUseFilter);
                }
                else
                {
                    oItems = oFolder.Items;
                }

                int iMax = oItems.Count;
                toolStripProgressBar1.ProgressBar.Maximum = 100;
                int iMod = (int)(iMax/100);
                if (iMod == 0)
                    iMod = 1;
                int iAt = 0;
                for (int iCount = 1; iCount <= iMax; iCount++)
                {
                     
                    if (iCount % iMod == 0)
                    {
                        iAt = (iCount / iMod);
                        if (iAt <= 100) 
                            toolStripProgressBar1.ProgressBar.Value = (iCount / iMod  );
                    }
                    oMailItem = (Microsoft.Office.Interop.Outlook.MailItem)oItems[iCount];
                    
                    ListViewItem oListItem = null;

                    oListItem = new ListViewItem(oMailItem.Subject, 0);
                    oListItem.SubItems.Add(oMailItem.SenderName);
                    oListItem.SubItems.Add(oMailItem.To);
                    oListItem.SubItems.Add(oMailItem.SentOn.ToString());
                    oListItem.SubItems.Add(oMailItem.ReceivedTime.ToString());
                    oListItem.SubItems.Add(oMailItem.MessageClass);
                    oListItem.SubItems.Add(oMailItem.Size.ToString());
                    ItemTag oItemTag = new ItemTag(_CurrentStoreId, oMailItem.EntryID, oMailItem.MessageClass);
                    oListItem.Tag = oItemTag;
                    oListView.Items.AddRange(new ListViewItem[] { oListItem });
                     
                    Marshal.ReleaseComObject(oMailItem);
                    oMailItem = null;

                }
                 
                Marshal.ReleaseComObject(oItems);
                Marshal.ReleaseComObject(oFolder);
                oItems = null;
                oFolder = null;
            }

            oListView.Visible = true;
            toolStripProgressBar1.ProgressBar.Value = 0;
 
        }



        private string GetRootFolderEntryIdOfStore(string sStoreId)
        {
            Microsoft.Office.Interop.Outlook._Store oStore = _oNS.GetStoreFromID(_CurrentStoreId);
            Microsoft.Office.Interop.Outlook.Folder oRootFolder = (Microsoft.Office.Interop.Outlook.Folder)oStore.GetRootFolder();
            string sReturn = oRootFolder.EntryID;
            Marshal.ReleaseComObject(oStore);
            Marshal.ReleaseComObject(oRootFolder);
            oStore = null;
            oRootFolder = null;
            return sReturn;
        }

        private void cmsFoldersCopyToFolder_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            //FolderTag oFolderTag = (FolderTag) tvFolders.SelectedNode.Tag;
            if (tvFolders.SelectedNode.SelectedImageIndex == 1)
            {
                MessageBox.Show("Copy cannot be performed on a Store Node.  Select a folder in the store.", "Not supported");
            }
            else
                {
                SelectFolder oForm = new SelectFolder(ref _oNS);
                oForm.ShowDialog();
                if (oForm.ChoseOK == true)
                {
                    Microsoft.Office.Interop.Outlook.MAPIFolder oFromFolder = _oNS.GetFolderFromID(_CurrentFolderId, _CurrentStoreId);
                    Microsoft.Office.Interop.Outlook.MAPIFolder oToFolder = _oNS.GetFolderFromID(oForm.CurrentFolderId, oForm.CurrentStoreId);
                    oFromFolder.CopyTo(oToFolder);
                    //mailCopy = (Outlook.MailItem)mailItem.Copy();
                    //mailCopy.Move(destFolder);
                    //mailItem.Delete();
                    Marshal.ReleaseComObject(oFromFolder);
                    Marshal.ReleaseComObject(oToFolder);
                    oFromFolder = null;
                    oToFolder = null;


                }
                oForm = null;
            }

            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void cmsFoldersMoveToFolder_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            if (tvFolders.SelectedNode.SelectedImageIndex == 1)
            {
                MessageBox.Show("Move cannot be performed on a Store Node.  Select a folder in the store.", "Not supported");
            }
            else
                {
                SelectFolder oForm = new SelectFolder(ref _oNS);
                oForm.ShowDialog();
                if (oForm.ChoseOK == true)
                {
                    Microsoft.Office.Interop.Outlook.MAPIFolder oFromFolder = _oNS.GetFolderFromID(_CurrentFolderId, _CurrentStoreId);
                    Microsoft.Office.Interop.Outlook.MAPIFolder oToFolder = _oNS.GetFolderFromID(oForm.CurrentFolderId, oForm.CurrentStoreId);
                    oFromFolder.MoveTo(oToFolder);
                    //mailCopy = (Outlook.MailItem)mailItem.Copy();
                    //mailCopy.Move(destFolder);
                    //mailItem.Delete();
                    Marshal.ReleaseComObject(oFromFolder);
                    Marshal.ReleaseComObject(oToFolder);
                    oFromFolder = null;
                    oToFolder = null;

                    //FolderTag oFolderTag = (FolderTag) tvFolders.SelectedNode.Tag;
                    //LoadViewForFolder(2, tvFolders.SelectedNode.Tag);

                    // Refresh folder and item view:  
                    TreeNode oParentNode = tvFolders.SelectedNode.Parent;
                    tvFolders.SelectedNode.Remove();
                    tvFolders.SelectedNode = oParentNode; // GO down one.
                    FolderTag oFolderTag = (FolderTag)tvFolders.SelectedNode.Tag;
                    oParentNode = null;

                    _CurrentStoreId = oFolderTag.StoreID;
                    _CurrentFolderId = oFolderTag.EntryID;
                    LoadViewForFolder(tvFolders.SelectedNode.SelectedImageIndex, ref listView1);

 
                }
                oForm = null;
            }

            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void cmsFoldersNewFolder_Click(object sender, EventArgs e)
        {
            TreeNode oNode = tvFolders.SelectedNode;

            TreeHelper.AddNewFolder(ref _oNS, ref oNode);

            oNode = null;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmsItems_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmsItemsCopyToFolder_Click(object sender, EventArgs e)
        {

        }

        private void cmsFoldersCopyAllIItems_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cmsItemsSaveToFile_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string sItemEntryId = string.Empty;
                string sStoreId = string.Empty;
                string sFilePath = string.Empty;

                sFilePath = "c:\\test\\test.msg";
                ItemTag oItemTag = (ItemTag) listView1.SelectedItems[0].Tag;
 
                OomFileHelper.SaveMsgFile(
                            ref _oNS,
                            oItemTag.EntryID, 
                            oItemTag.StoreID, 
                            sFilePath, 
                            Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSGUnicode
                        );
            }
            else
            {
                MessageBox.Show("An item was not selected.", "No items selected");
            }
        }

        private void mnuMainAvailabilityInformation_Click(object sender, EventArgs e)
        {

        }

        private void cmsFoldersProperties_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            //Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = _oNS.GetFolderFromID(_CurrentFolderId, _CurrentStoreId);
            // Refresh folder and item view:  
            TreeNode oParentNode = tvFolders.SelectedNode.Parent;
            FolderTag oFolderTag = (FolderTag)tvFolders.SelectedNode.Tag;
            //_CurrentStoreId = oFolderTag.StoreID;
            //_CurrentFolderId = oFolderTag.EntryID;
            Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = _oNS.GetFolderFromID(oFolderTag.EntryID, oFolderTag.StoreID);
            Microsoft.Office.Interop.Outlook.Folder oOlFolder = oFolder as Microsoft.Office.Interop.Outlook.Folder;

            string sInfo = string.Empty;

            sInfo += "Name: " + oFolder.Name + "\r\n";
            sInfo += "Default folder class: " + OomFolders.GetDefaultMessageClass(oOlFolder) + "\r\n";

            sInfo += "AddressBookName: " + oFolder.AddressBookName + "\r\n";
            sInfo += "Class: " + oFolder.Class + "\r\n";
            sInfo += "DefaultItemType: " + oFolder.DefaultItemType.ToString() + "\r\n";
            sInfo += "DefaultMessageClass: " + oFolder.DefaultMessageClass + "\r\n";
            sInfo += "Description: " + oFolder.Description + "\r\n";
            sInfo += "EntryID: " + oFolder.EntryID + "\r\n";
            sInfo += "FolderPath: " + oFolder.FolderPath + "\r\n";
            sInfo += "FullFolderPath: " + oFolder.FullFolderPath + "\r\n";
            //sInfo += "InAppFolderSyncObject: " + oFolder.InAppFolderSyncObject.ToString() + "\r\n";
            sInfo += "IsSharePointFolder: " + oFolder.IsSharePointFolder.ToString() + "\r\n";
            sInfo += "Items.Count: " + oFolder.Items.Count.ToString() + "\r\n";
            sInfo += "InAppFolderSyncObject: " + oFolder.Name + "\r\n";
            sInfo += "ShowAsOutlookAB: " + oFolder.ShowAsOutlookAB.ToString() + "\r\n";
            sInfo += "StoreID: " + oFolder.StoreID + "\r\n";
            sInfo += "UnReadItemCount: " + oFolder.UnReadItemCount.ToString() + "\r\n";
            sInfo += "WebViewOn: " + oFolder.WebViewOn.ToString() + "\r\n";
            sInfo += "WebViewURL: " + oFolder.WebViewURL + "\r\n";
             

            Marshal.ReleaseComObject(oFolder);
            oFolder = null;

            this.Cursor = System.Windows.Forms.Cursors.Default;

            ShowInformation oForm = new ShowInformation();
            oForm.WindowTitle = "Folders Properties";
            oForm.txtInformation.Text = sInfo;
            oForm.ShowDialog();
            oForm = null;

             
        }

        private void cmsFoldersStoreProperties_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            //Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = _oNS.GetFolderFromID(_CurrentFolderId, _CurrentStoreId);
            // Refresh folder and item view:  
            TreeNode oParentNode = tvFolders.SelectedNode.Parent;
            FolderTag oFolderTag = (FolderTag)tvFolders.SelectedNode.Tag;
            _CurrentStoreId = oFolderTag.StoreID;
            //_CurrentFolderId = oFolderTag.EntryID;
            //Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = _oNS.GetFolderFromID(_CurrentFolderId, _CurrentStoreId);
            Microsoft.Office.Interop.Outlook.Store oStore = _oNS.GetStoreFromID(_CurrentStoreId);

            string sInfo = string.Empty;


            sInfo += "ExchangeStoreType: " + oStore.Class + "\r\n";
            sInfo += "ExchangeStoreType: " + oStore.DisplayName + "\r\n";
            sInfo += "ExchangeStoreType: " + oStore.ExchangeStoreType + "\r\n";
            sInfo += "FilePath: " + oStore.FilePath + "\r\n";
            sInfo += "IsCachedExchange: " + oStore.IsCachedExchange.ToString() + "\r\n";
            sInfo += "IsDataFileStore: " + oStore.IsDataFileStore.ToString() + "\r\n";
            sInfo += "IsInstantSearchEnabled: " + oStore.IsInstantSearchEnabled.ToString() + "\r\n";
            sInfo += "IsOpen: " + oStore.IsOpen.ToString() + "\r\n";
            sInfo += "ExchangeStoreType: " + oStore.StoreID + "\r\n";



            Marshal.ReleaseComObject(oStore);
            oStore = null;

            this.Cursor = System.Windows.Forms.Cursors.Default;

            ShowInformation oForm = new ShowInformation();
            oForm.WindowTitle = "Folders Store Properties";
            oForm.txtInformation.Text = sInfo;
            oForm.ShowDialog();
            oForm = null;
        }

        private void cmsItemsProperties_Click(object sender, EventArgs e)
        {
            ViewItemPropertiesByClass_AsText();
            // ViewItemPropertiesByClass();
        }

        private void ViewItemPropertiesByClass_AsText()
        {

            string sItem = string.Empty;
            ItemTag oItemTag = null;
            string sInfo = string.Empty;

            if (listView1.SelectedItems.Count > 0)
            {

                oItemTag = (ItemTag)listView1.SelectedItems[0].Tag;
            


                if (oItemTag != null)
                {
                    sInfo += "DefaultMessageClass: " + oItemTag.DefaultMessageClass + "\r\n";
                    sInfo += "EntryID: " + oItemTag.EntryID + "\r\n";
                    sInfo += "StoreID: " + oItemTag.StoreID + "\r\n";


                    //sInfo += GetPropertiesByItemType(oItemTag.DefaultMessageClass);
                    switch (oItemTag.DefaultMessageClass)
                    {
                        case "IPM.Note":
                            sInfo += Get_IpmNoteProperties();

                            break;
                        case "IPM.Appointment":
                            sInfo += Get_IpmAppointmentProperties();


                            break;

 
                        default:
                            break;
                    }
                }

                ShowInformation oForm = new ShowInformation();
                oForm.WindowTitle = "Item Properties";
                oForm.txtInformation.Text = sInfo;
                oForm.ShowDialog();
                oForm = null;
            }
            else
            {
                MessageBox.Show("Nothing Selected", "Selection Required ");
            }

           

        }

        private string Get_IpmNoteProperties()
        {  
            string sItem = string.Empty;
            ItemTag oItemTag = null;
            string sInfo = string.Empty;


            oItemTag = (ItemTag)listView1.SelectedItems[0].Tag;

            Microsoft.Office.Interop.Outlook.MailItem oItem = (Microsoft.Office.Interop.Outlook.MailItem)_oNS.GetItemFromID(oItemTag.EntryID, oItemTag.StoreID);

            sInfo += "AutoForwarded: " + oItem.AutoForwarded.ToString() + "\r\n";
            sInfo += "AutoResolvedWinner: " + oItem.AutoResolvedWinner.ToString() + "\r\n";
            sInfo += "BCC: " + oItem.BCC + "\r\n";
            if (oItem.BillingInformation != null) sInfo += "BillingInformation: " + oItem.BillingInformation + "\r\n";
            if (oItem.Body != null)
                sInfo += "Body: " + oItem.Body + "\r\n";
            sInfo += "BodyFormat: " + oItem.BodyFormat.ToString() + "\r\n";
            //sInfo += "Categories: " + oItem.Categories + "\r\n";
            if (oItem.Categories != null)
                sInfo += "Categories: " + oItem.Categories.ToString() + "\r\n";
            if (oItem.CC != null)
                sInfo += "CC: " + oItem.CC.ToString() + "\r\n";

            sInfo += "Class: " + oItem.Class.ToString() + "\r\n";
            if (oItem.Companies != null)
                sInfo += "Companies: " + oItem.Companies + "\r\n";
            if (oItem.ConversationIndex != null)
                sInfo += "ConversationIndex: " + oItem.ConversationIndex + "\r\n";
            if (oItem.ConversationTopic != null)
                sInfo += "ConversationTopic: " + oItem.ConversationTopic + "\r\n";
            if (oItem.CreationTime != null)
                sInfo += "CreationTime: " + oItem.CreationTime.ToString() + "\r\n";
            if (oItem.DeferredDeliveryTime != null) sInfo += "DeferredDeliveryTime: " + oItem.DeferredDeliveryTime.ToString() + "\r\n";
            sInfo += "DeleteAfterSubmit: " + oItem.DeleteAfterSubmit.ToString() + "\r\n";
            sInfo += "DownloadState: " + oItem.DownloadState.ToString() + "\r\n";
            sInfo += "EnableSharedAttachments: " + oItem.EnableSharedAttachments.ToString() + "\r\n";

            if (oItem.EntryID != null)
                sInfo += "EntryID: " + oItem.EntryID + "\r\n";
            if (oItem.ExpiryTime != null)
                sInfo += "ExpiryTime: " + oItem.ExpiryTime.ToString() + "\r\n";
            if (oItem.FlagDueBy != null)
                sInfo += "FlagDueBy: " + oItem.FlagDueBy.ToString() + "\r\n";
            if (oItem.FlagRequest != null)
                sInfo += "FlagRequest: " + oItem.FlagRequest + "\r\n";
            sInfo += "FlagStatus: " + oItem.FlagStatus.ToString() + "\r\n";
            if (oItem.FormDescription != null)
                sInfo += "FormDescription.DisplayName " + oItem.FormDescription.DisplayName + "\r\n";
            sInfo += "HasCoverSheet: " + oItem.HasCoverSheet.ToString() + "\r\n";
            if (oItem.HTMLBody != null)
                sInfo += "AddressBookNameHTMLBody " + oItem.HTMLBody + "\r\n";
            sInfo += "Importance: " + oItem.Importance.ToString() + "\r\n";
            sInfo += "InternetCodepage: " + oItem.InternetCodepage.ToString() + "\r\n";
            if (oItem.ItemProperties != null)
                sInfo += "ItemProperties: " + oItem.ItemProperties.ToString() + "\r\n";
            if (oItem.LastModificationTime != null)
                sInfo += "LastModificationTime: " + oItem.LastModificationTime.ToString() + "\r\n";
            if (oItem.MessageClass != null)
                sInfo += "MessageClass: " + oItem.MessageClass + "\r\n";
            sInfo += "Mileage: " + oItem.Mileage + "\r\n";
            sInfo += "OriginatorDeliveryReportRequested: " + oItem.OriginatorDeliveryReportRequested.ToString() + "\r\n";
            sInfo += "OutlookInternalVersion: " + oItem.OutlookInternalVersion.ToString() + "\r\n";
            if (oItem.OutlookVersion != null)
                sInfo += "OutlookVersion: " + oItem.OutlookVersion + "\r\n";
            if (oItem.ReceivedByName != null) sInfo += "ReceivedByName: " + oItem.ReceivedByName + "\r\n";
            if (oItem.ReceivedOnBehalfOfName != null)
                sInfo += "ReceivedOnBehalfOfName: " + oItem.ReceivedOnBehalfOfName + "\r\n";
            if (oItem.ReceivedTime != null)
                sInfo += "ReceivedTime: " + oItem.ReceivedTime + "\r\n";
            sInfo += "RecipientReassignmentProhibited: " + oItem.RecipientReassignmentProhibited.ToString() + "\r\n";
            if (oItem.Recipients != null)
                sInfo += "Recipients: " + oItem.Recipients.ToString() + "\r\n";
            sInfo += "ReminderPlaySound: " + oItem.ReminderPlaySound.ToString() + "\r\n";
            sInfo += "ReminderSet: " + oItem.ReminderSet.ToString() + "\r\n";
            if (oItem.ReminderTime != null)
                sInfo += "ReminderTime: " + oItem.ReminderTime.ToString() + "\r\n";
            sInfo += "RemoteStatus: " + oItem.RemoteStatus.ToString() + "\r\n";
            if (oItem.ReplyRecipientNames != null)
                sInfo += "ReplyRecipientNames: " + oItem.ReplyRecipientNames + "\r\n";
            if (oItem.ReplyRecipients != null)
                sInfo += "ReplyRecipients: " + oItem.ReplyRecipients.ToString() + "\r\n";
            sInfo += "Saved: " + oItem.Saved.ToString() + "\r\n";
            if (oItem.SaveSentMessageFolder != null) sInfo += "SaveSentMessageFolder: " + oItem.SaveSentMessageFolder.ToString() + "\r\n";
            if (oItem.SenderEmailAddress != null) sInfo += "SenderEmailAddress: " + oItem.SenderEmailAddress + "\r\n";
            if (oItem.SenderEmailType != null)
                sInfo += "SenderEmailType: " + oItem.SenderEmailType + "\r\n";


            if (oItem.SenderName != null) sInfo += "SenderName: " + oItem.SenderName + "\r\n";
            if (oItem.SendUsingAccount != null)
                sInfo += "SendUsingAccount: " + oItem.SendUsingAccount.ToString() + "\r\n";
            sInfo += "Sensitivity: " + oItem.Sensitivity.ToString() + "\r\n";
            sInfo += "Sent: " + oItem.Sent.ToString() + "\r\n";
            sInfo += "SentOn: " + oItem.SentOn.ToString() + "\r\n";
            if (oItem.SentOnBehalfOfName != null) sInfo += "SentOnBehalfOfName: " + oItem.SentOnBehalfOfName + "\r\n";
            sInfo += "Size: " + oItem.Size.ToString() + "\r\n";
            if (oItem.Subject != null)
                sInfo += "Subject: " + oItem.Subject + "\r\n";
            sInfo += "Submitted: " + oItem.Submitted.ToString() + "\r\n";
            if (oItem.TaskSubject != null)
                sInfo += "TaskSubject: " + oItem.TaskSubject + "\r\n";
            if (oItem.To != null)
                sInfo += "To: " + oItem.To + "\r\n";
            sInfo += "UnRead: " + oItem.UnRead.ToString() + "\r\n";
            sInfo += "UserProperties: " + oItem.UserProperties.ToString() + "\r\n";
            sInfo += "VotingOptions: " + oItem.VotingOptions + "\r\n";
            sInfo += "VotingResponse: " + oItem.VotingResponse + "\r\n";

            return sInfo;
        }

        private string Get_IpmAppointmentProperties()
        {

            {
                string sItem = string.Empty;
                ItemTag oItemTag = null;
                string sInfo = string.Empty;

                oItemTag = (ItemTag)listView1.SelectedItems[0].Tag;

                Microsoft.Office.Interop.Outlook.AppointmentItem oItem = (Microsoft.Office.Interop.Outlook.AppointmentItem)_oNS.GetItemFromID(oItemTag.EntryID, oItemTag.StoreID);

                sInfo += "AutoResolvedWinner: " + oItem.AutoResolvedWinner.ToString() + "\r\n";
                if (oItem.Organizer != null) sInfo += "Organizer: " + oItem.Organizer + "\r\n";

                if (oItem.RequiredAttendees != null) sInfo += "RequiredAttendees: " + oItem.RequiredAttendees + "\r\n";
                if (oItem.OptionalAttendees != null) sInfo += "OptionalAttendees: " + oItem.OptionalAttendees + "\r\n";
                if (oItem.BillingInformation != null) sInfo += "BillingInformation: " + oItem.BillingInformation + "\r\n";

                if (oItem.Body != null)
                    sInfo += "Body: " + oItem.Body + "\r\n";

                //sInfo += "Categories: " + oItem.Categories + "\r\n";
                if (oItem.Categories != null)
                    sInfo += "Categories: " + oItem.Categories.ToString() + "\r\n";

                sInfo += "Class: " + oItem.Class.ToString() + "\r\n";
                if (oItem.Companies != null)
                    sInfo += "Companies: " + oItem.Companies + "\r\n";
                if (oItem.ConversationIndex != null)
                    sInfo += "ConversationIndex: " + oItem.ConversationIndex + "\r\n";
                if (oItem.ConversationTopic != null)
                    sInfo += "ConversationTopic: " + oItem.ConversationTopic + "\r\n";
                if (oItem.CreationTime != null)
                    sInfo += "CreationTime: " + oItem.CreationTime.ToString() + "\r\n";


                sInfo += "DownloadState: " + oItem.DownloadState.ToString() + "\r\n";


                if (oItem.EntryID != null)
                    sInfo += "EntryID: " + oItem.EntryID + "\r\n";


                if (oItem.FormDescription != null)
                    sInfo += "FormDescription.DisplayName " + oItem.FormDescription.DisplayName + "\r\n";

                sInfo += "Importance: " + oItem.Importance.ToString() + "\r\n";
                sInfo += "InternetCodepage: " + oItem.InternetCodepage.ToString() + "\r\n";
                if (oItem.ItemProperties != null)
                    sInfo += "ItemProperties: " + oItem.ItemProperties.ToString() + "\r\n";
                if (oItem.LastModificationTime != null)
                    sInfo += "LastModificationTime: " + oItem.LastModificationTime.ToString() + "\r\n";
                if (oItem.MessageClass != null)
                    sInfo += "MessageClass: " + oItem.MessageClass + "\r\n";
                sInfo += "Mileage: " + oItem.Mileage + "\r\n";

                sInfo += "OutlookInternalVersion: " + oItem.OutlookInternalVersion.ToString() + "\r\n";
                if (oItem.OutlookVersion != null)
                    sInfo += "OutlookVersion: " + oItem.OutlookVersion + "\r\n";

                sInfo += "Recipients: " + oItem.Recipients.ToString() + "\r\n";
                sInfo += "ReminderPlaySound: " + oItem.ReminderPlaySound.ToString() + "\r\n";


                sInfo += "Saved: " + oItem.Saved.ToString() + "\r\n";




                if (oItem.SendUsingAccount != null)
                    sInfo += "SendUsingAccount: " + oItem.SendUsingAccount.ToString() + "\r\n";
                sInfo += "Sensitivity: " + oItem.Sensitivity.ToString() + "\r\n";

                sInfo += "Size: " + oItem.Size.ToString() + "\r\n";
                if (oItem.Subject != null)
                    sInfo += "Subject: " + oItem.Subject + "\r\n";

                sInfo += "UnRead: " + oItem.UnRead.ToString() + "\r\n";
                sInfo += "UserProperties: " + oItem.UserProperties.ToString() + "\r\n";


                return sInfo;
            }
        }
        private void ItemPropertiesLV_Default()
        {

        }

        private void ViewItemPropertiesByClass()
        {
            string sItem = string.Empty;
            ItemTag oItemTag = null;
            string sInfo = string.Empty;

            if (listView1.SelectedItems.Count > 0)
            {

                oItemTag = (ItemTag)listView1.SelectedItems[0].Tag;

                if (oItemTag != null)
                {

                    ListView oListView = new ListView();
                    ItemPropertiesForm oItemPropertiesForm = new ItemPropertiesForm();

                    //sInfo += GetPropertiesByItemType(oItemTag.DefaultMessageClass);
                    switch (oItemTag.DefaultMessageClass)
                    {
                        case "IPM.Note":
                            Add_ItemPropertiesLV_IPM_Note(ref oListView);
                             
                            oItemPropertiesForm.SetListView(ref oListView);

                            oListView.Visible = true;

                            oItemPropertiesForm.ShowDialog();
                            break;
                        default:
                            Add_ItemPropertiesLV_IPM_Unknown(ref oListView);
                            oItemPropertiesForm.SetListView(ref oListView);

                            oListView.Visible = true;
                            oItemPropertiesForm.ShowDialog();
                            break;
                    }
                }
            }
            else
                MessageBox.Show("Nothing selected.");
        }

   
        private void Add_ItemPropertiesLV_IPM_Unknown(ref ListView oListView)
        {
 
            //oListView.Visible = false;
 
            oListView.Clear();
            oListView.View = System.Windows.Forms.View.Details;
            oListView.GridLines = true;
            //oListView.Dock = DockStyle.Fill;
 
            oListView.Columns.Add("Property", 700, HorizontalAlignment.Left);
            oListView.Columns.Add("Value", 700, HorizontalAlignment.Left);
 
            string sItem = string.Empty;
            ItemTag oItemTag = null;
            string sInfo = string.Empty;

 
            oItemTag = (ItemTag)listView1.SelectedItems[0].Tag;
 
            if (oItemTag != null)
            {

                Microsoft.Office.Interop.Outlook.MailItem oItem = (Microsoft.Office.Interop.Outlook.MailItem)_oNS.GetItemFromID(oItemTag.EntryID, oItemTag.StoreID);
   
                oListView.Items.Add("Subject").SubItems.Add(oItem.Subject.ToString());
                oListView.Items.Add("MessageClass").SubItems.Add(oItem.MessageClass.ToString());
                oListView.Items.Add("EntryID").SubItems.Add(oItemTag.EntryID.ToString());
                oListView.Items.Add("StoreID").SubItems.Add(oItemTag.StoreID.ToString());
                if (oItem.BCC != null)
                    oListView.Items.Add("BCC").SubItems.Add(oItem.BCC.ToString());
                if (oItem.Body != null) oListView.Items.Add("Body").SubItems.Add(oItem.Body.ToString());
                oListView.Items.Add("BodyFormat").SubItems.Add(oItem.BodyFormat.ToString());
                if (oItem.Categories != null)
                    oListView.Items.Add("Categories").SubItems.Add(oItem.Categories.ToString());
                if (oItem.CC != null)
                    oListView.Items.Add("CC").SubItems.Add(oItem.CC.ToString());

                if (oItem.ConversationIndex != null) oListView.Items.Add("ConversationIndex").SubItems.Add(oItem.ConversationIndex.ToString());
                if (oItem.ConversationTopic != null) oListView.Items.Add("ConversationTopic").SubItems.Add(oItem.ConversationTopic.ToString());

                oListView.Items.Add("CreationTime").SubItems.Add(oItem.CreationTime.ToString());
              
                oListView.Items.Add("EntryID").SubItems.Add(oItem.EntryID.ToString());
                oListView.Items.Add("Importance").SubItems.Add(oItem.Importance.ToString());
                if (oItem.ItemProperties != null) oListView.Items.Add("ItemProperties").SubItems.Add(oItem.ItemProperties.ToString());
                if (oItem.LastModificationTime != null) oListView.Items.Add("LastModificationTime").SubItems.Add(oItem.LastModificationTime.ToString());
                if (oItem.MessageClass != null) oListView.Items.Add("MessageClass").SubItems.Add(oItem.MessageClass.ToString());
                oListView.Items.Add("OutlookInternalVersion").SubItems.Add(oItem.MessageClass.ToString());
                if (oItem.SendUsingAccount != null)
                    oListView.Items.Add("SendUsingAccount").SubItems.Add(oItem.SendUsingAccount.ToString());

                oListView.Items.Add("Sensitivity").SubItems.Add(oItem.Sensitivity.ToString());
                oListView.Items.Add("Sent").SubItems.Add(oItem.Sent.ToString());
                if (oItem.SentOn != null) oListView.Items.Add("SentOn").SubItems.Add(oItem.SentOn.ToString());
                oListView.Items.Add("Size").SubItems.Add(oItem.Size.ToString());
                if (oItem.SentOn != null) oListView.Items.Add("SentOn").SubItems.Add(oItem.SentOn.ToString());
                if (oItem.SentOnBehalfOfName != null) oListView.Items.Add("SentOnBehalfOfName").SubItems.Add(oItem.SentOnBehalfOfName.ToString());
                if (oItem.Subject != null) oListView.Items.Add("Subject").SubItems.Add(oItem.Subject.ToString());
                oListView.Items.Add("Submitted").SubItems.Add(oItem.Submitted.ToString());
                if (oItem.To != null) oListView.Items.Add("To").SubItems.Add(oItem.To.ToString());
                oListView.Items.Add("UnRead").SubItems.Add(oItem.UnRead.ToString());
                if (oItem.UserProperties != null) oListView.Items.Add("UserProperties").SubItems.Add(oItem.UserProperties.ToString());
 

            }


        }

        private void Add_ItemPropertiesLV_IPM_Note(ref ListView oListView)
        {
 
            //oListView.Visible = false;
 
            oListView.Clear();
            oListView.View = System.Windows.Forms.View.Details;
            oListView.GridLines = true;
            //oListView.Dock = DockStyle.Fill;
 
            oListView.Columns.Add("Property", 700, HorizontalAlignment.Left);
            oListView.Columns.Add("Value", 700, HorizontalAlignment.Left);
 
            string sItem = string.Empty;
            ItemTag oItemTag = null;
            string sInfo = string.Empty;

 
            oItemTag = (ItemTag)listView1.SelectedItems[0].Tag;
 
            if (oItemTag != null)
            {

                Microsoft.Office.Interop.Outlook.MailItem oItem = (Microsoft.Office.Interop.Outlook.MailItem)_oNS.GetItemFromID(oItemTag.EntryID, oItemTag.StoreID);
   
                oListView.Items.Add("Subject").SubItems.Add(oItem.Subject.ToString());
                oListView.Items.Add("MessageClass").SubItems.Add(oItem.MessageClass.ToString());
                oListView.Items.Add("EntryID").SubItems.Add(oItemTag.EntryID.ToString());
                oListView.Items.Add("StoreID").SubItems.Add(oItemTag.StoreID.ToString());

                
                oListView.Items.Add("AutoForwarded").SubItems.Add(oItem.AutoForwarded.ToString() );
                oListView.Items.Add("Subject").SubItems.Add(oItem.Subject.ToString());
                if (oItem.BCC != null)
                    oListView.Items.Add("BCC").SubItems.Add(oItem.BCC.ToString());
                if (oItem.BillingInformation != null)
                    oListView.Items.Add("BillingInformation").SubItems.Add(oItem.BillingInformation.ToString());
                oListView.Items.Add("Body").SubItems.Add(oItem.Body.ToString());
                if (oItem.BillingInformation != null) 
                    oListView.Items.Add("BillingInformation").SubItems.Add(oItem.BillingInformation.ToString());
                 
                oListView.Items.Add("BodyFormat").SubItems.Add(oItem.BodyFormat.ToString());
            
                if (oItem.Categories != null)
                    oListView.Items.Add("Categories").SubItems.Add(oItem.Categories.ToString());
                if (oItem.CC != null)
                    oListView.Items.Add("CC").SubItems.Add(oItem.CC.ToString());
  
                oListView.Items.Add("Class").SubItems.Add(oItem.Class.ToString());
                if (oItem.Companies != null) oListView.Items.Add("Companies").SubItems.Add(oItem.Companies.ToString());
                if (oItem.ConversationIndex != null) 
                    oListView.Items.Add("ConversationIndex").SubItems.Add(oItem.ConversationIndex.ToString());
                if (oItem.ConversationTopic != null) oListView.Items.Add("ConversationTopic").SubItems.Add(oItem.ConversationTopic.ToString());

                if (oItem.CreationTime != null) oListView.Items.Add("CreationTime").SubItems.Add(oItem.CreationTime.ToString());
                if (oItem.DeferredDeliveryTime != null) oListView.Items.Add("DeferredDeliveryTime").SubItems.Add(oItem.DeferredDeliveryTime.ToString());
                oListView.Items.Add("DeleteAfterSubmit").SubItems.Add(oItem.DeleteAfterSubmit.ToString());
                oListView.Items.Add("DownloadState").SubItems.Add(oItem.DownloadState.ToString());
                oListView.Items.Add("EnableSharedAttachments").SubItems.Add(oItem.EnableSharedAttachments.ToString());
                if (oItem.EntryID != null) oListView.Items.Add("EntryID").SubItems.Add(oItem.EntryID.ToString());
                if (oItem.ExpiryTime != null) oListView.Items.Add("ExpiryTime").SubItems.Add(oItem.ExpiryTime.ToString());
                if (oItem.FlagDueBy != null) oListView.Items.Add("FlagDueBy").SubItems.Add(oItem.FlagDueBy.ToString());
                if (oItem.FlagRequest != null) oListView.Items.Add("FlagRequest").SubItems.Add(oItem.FlagRequest.ToString());
                if (oItem.FormDescription != null)
                    if (oItem.FormDescription.DisplayName != null) 
                        oListView.Items.Add("FormDescription.DisplayName ").SubItems.Add(oItem.FormDescription.DisplayName.ToString());
                oListView.Items.Add("HasCoverSheet").SubItems.Add(oItem.HasCoverSheet.ToString());
                oListView.Items.Add("Importance").SubItems.Add(oItem.Importance.ToString());
                oListView.Items.Add("InternetCodepage").SubItems.Add(oItem.InternetCodepage.ToString());
                if (oItem.ItemProperties != null) oListView.Items.Add("ItemProperties").SubItems.Add(oItem.ItemProperties.ToString());
                if (oItem.LastModificationTime != null) oListView.Items.Add("LastModificationTime").SubItems.Add(oItem.LastModificationTime.ToString());
                if (oItem.MessageClass != null) oListView.Items.Add("MessageClass").SubItems.Add(oItem.MessageClass.ToString());
                if (oItem.Mileage != null) oListView.Items.Add("Mileage").SubItems.Add(oItem.Mileage.ToString());
                oListView.Items.Add("OriginatorDeliveryReportRequested").SubItems.Add(oItem.OriginatorDeliveryReportRequested.ToString());
                oListView.Items.Add("OutlookInternalVersion").SubItems.Add(oItem.MessageClass.ToString());
                if (oItem.ReceivedByName != null) oListView.Items.Add("ReceivedByName").SubItems.Add(oItem.ReceivedByName.ToString());
                if (oItem.ReceivedOnBehalfOfName != null) oListView.Items.Add("ReceivedOnBehalfOfName").SubItems.Add(oItem.ReceivedOnBehalfOfName.ToString());
                if (oItem.ReceivedTime != null) oListView.Items.Add("ReceivedTime").SubItems.Add(oItem.ReceivedTime.ToString());
                oListView.Items.Add("RecipientReassignmentProhibited").SubItems.Add(oItem.RecipientReassignmentProhibited.ToString());
                if (oItem.Recipients != null) oListView.Items.Add("Recipients").SubItems.Add(oItem.Recipients.ToString());
                oListView.Items.Add("ReminderPlaySound").SubItems.Add(oItem.ReminderPlaySound.ToString());
                oListView.Items.Add("ReminderSet").SubItems.Add(oItem.ReminderSet.ToString());
                if (oItem.ReminderTime != null) oListView.Items.Add("ReminderTime").SubItems.Add(oItem.ReminderTime.ToString());
                oListView.Items.Add("RemoteStatus").SubItems.Add(oItem.RemoteStatus.ToString());
                if (oItem.ReplyRecipientNames != null) oListView.Items.Add("ReplyRecipientNames").SubItems.Add(oItem.ReplyRecipientNames.ToString());
                if (oItem.ReplyRecipients != null) oListView.Items.Add("ReplyRecipients").SubItems.Add(oItem.ReplyRecipients.ToString());
                oListView.Items.Add("Saved").SubItems.Add(oItem.Saved.ToString());
                if (oItem.SaveSentMessageFolder != null) oListView.Items.Add("SaveSentMessageFolder").SubItems.Add(oItem.SaveSentMessageFolder.ToString());
                if (oItem.SenderEmailAddress != null) oListView.Items.Add("SenderEmailAddress").SubItems.Add(oItem.SenderEmailAddress.ToString());
                if (oItem.SenderEmailType != null) oListView.Items.Add("SenderEmailType").SubItems.Add(oItem.SenderEmailType.ToString());
                if (oItem.SenderName != null) oListView.Items.Add("SenderName").SubItems.Add(oItem.SenderName.ToString());
                if (oItem.SendUsingAccount != null) oListView.Items.Add("SendUsingAccount").SubItems.Add(oItem.SendUsingAccount.ToString());

                oListView.Items.Add("Sensitivity").SubItems.Add(oItem.Sensitivity.ToString());
                oListView.Items.Add("Sent").SubItems.Add(oItem.Sent.ToString());
                if (oItem.SentOn != null) oListView.Items.Add("SentOn").SubItems.Add(oItem.SentOn.ToString());
                if (oItem.SentOnBehalfOfName != null) oListView.Items.Add("SentOnBehalfOfName").SubItems.Add(oItem.SentOnBehalfOfName.ToString());
                oListView.Items.Add("Size").SubItems.Add(oItem.Size.ToString());
                if (oItem.SentOn != null) oListView.Items.Add("SentOn").SubItems.Add(oItem.SentOn.ToString());
                if (oItem.SentOnBehalfOfName != null) oListView.Items.Add("SentOnBehalfOfName").SubItems.Add(oItem.SentOnBehalfOfName.ToString());
                oListView.Items.Add("Size").SubItems.Add(oItem.Size.ToString());
                if (oItem.Subject != null) oListView.Items.Add("Subject").SubItems.Add(oItem.Subject.ToString());
                oListView.Items.Add("Submitted").SubItems.Add(oItem.Submitted.ToString());
                if (oItem.To != null) oListView.Items.Add("To").SubItems.Add(oItem.To.ToString());
                oListView.Items.Add("UnRead").SubItems.Add(oItem.UnRead.ToString());
                if (oItem.UserProperties != null) oListView.Items.Add("UserProperties").SubItems.Add(oItem.UserProperties.ToString());
                if (oItem.VotingOptions != null) oListView.Items.Add("VotingOptions").SubItems.Add(oItem.VotingOptions.ToString());
                if (oItem.VotingResponse != null) oListView.Items.Add("VotingResponse").SubItems.Add(oItem.VotingResponse.ToString());
                if (oItem.MessageClass != null) oListView.Items.Add("MessageClass").SubItems.Add(oItem.MessageClass.ToString());

            }


        }

 

        private void mnuInfoAccountInformation_Click(object sender, EventArgs e)
        {

            //Microsoft.Office.Interop.Outlook._Application _oApp = null;
            string sInfo = GetAccountInformation(_oApp);

            ShowInformation oForm = new ShowInformation();
            oForm.WindowTitle = "Account Information";
            oForm.txtInformation.Text = sInfo;
            oForm.ShowDialog();
            oForm = null;
        }

        private string GetAccountInformation(Microsoft.Office.Interop.Outlook._Application application)
        {

            // The Namespace Object (Session) has a collection of accounts.
            Microsoft.Office.Interop.Outlook.Accounts accounts = application.Session.Accounts;

            // Concatenate a message with information about all accounts.
            StringBuilder builder = new StringBuilder();

            // Loop over all accounts and print detail account information.
            // All properties of the Account object are read-only.
            foreach (Microsoft.Office.Interop.Outlook.Account account in accounts)
            {

                // The DisplayName property represents the friendly name of the account.
                builder.AppendFormat("DisplayName: {0}    \n", account.DisplayName);

                // The UserName property provides an account-based context to determine identity.
                builder.AppendFormat("UserName: {0}    \n", account.UserName);

                // The SmtpAddress property provides the SMTP address for the account.
                builder.AppendFormat("SmtpAddress: {0}    \n", account.SmtpAddress);

                // The AccountType property indicates the type of the account.
                builder.Append("AccountType: ");
                switch (account.AccountType)
                {

                    case Microsoft.Office.Interop.Outlook.OlAccountType.olExchange:
                        builder.AppendLine("Exchange");
                        break;

                    case Microsoft.Office.Interop.Outlook.OlAccountType.olHttp:
                        builder.AppendLine("Http");
                        break;

                    case Microsoft.Office.Interop.Outlook.OlAccountType.olImap:
                        builder.AppendLine("Imap");
                        break;

                    case Microsoft.Office.Interop.Outlook.OlAccountType.olOtherAccount:
                        builder.AppendLine("Other");
                        break;

                    case Microsoft.Office.Interop.Outlook.OlAccountType.olPop3:
                        builder.AppendLine("Pop3");
                        break;
                }

                builder.AppendLine("\r\n--\r\n");

                Marshal.ReleaseComObject(account);

                builder.AppendLine();
            }

          
            return builder.ToString();
        }

        private void cmsItemsMoveToFolder_Click(object sender, EventArgs e)
        {

        }

        private void cmsItemsMoveAllItems_Click(object sender, EventArgs e)
        {

        }

        private void cmsItemsCopyAllItems_Click(object sender, EventArgs e)
        {

        }

        private void cmsFoldersDelete_Click(object sender, EventArgs e)
        {

        }

        private void cmsFoldersRenameFolder_Click(object sender, EventArgs e)
        {

        }

        private void cmsFoldersMoveAllItems_Click(object sender, EventArgs e)
        {

        }

        private void cmsFoldersCopyMoveDeleteAllItems_Click(object sender, EventArgs e)
        {

        }

        private void cmsItemsRename_Click(object sender, EventArgs e)
        {

        }

        private void cmsItemsDelete_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cmsFolderAccountForFolder_Click(object sender, EventArgs e)
        {
            DisplayAccountForCurrentFolder();
        }

        // https://msdn.microsoft.com/EN-US/library/office/ff184600.aspx
        private void DisplayAccountForCurrentFolder()
        {
            
            Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = _oNS.GetFolderFromID(_CurrentFolderId, _CurrentStoreId);

            // TODO: Finish 4/16/2015

            Microsoft.Office.Interop.Outlook.Folder myFolder = oFolder
                as Microsoft.Office.Interop.Outlook.Folder;
            string msg = "Account for Current Folder:" + "\n" +
                GetAccountForFolder(myFolder).DisplayName;

            MessageBox.Show(msg,
                "GetAccountForFolder",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // https://msdn.microsoft.com/EN-US/library/office/ff184600.aspx
        Microsoft.Office.Interop.Outlook.Account GetAccountForFolder(Microsoft.Office.Interop.Outlook.Folder folder)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            // Obtain the store on which the folder resides.
            Microsoft.Office.Interop.Outlook.Store store = folder.Store;

            // Enumerate the accounts defined for the session.
            foreach (Microsoft.Office.Interop.Outlook.Account account in _oApp.Session.Accounts)
            {

                // Match the DefaultStore.StoreID of the account
                // with the Store.StoreID for the currect folder.
                if (account.DeliveryStore.StoreID == store.StoreID)
                {
                    // Return the account whose default delivery store
                    // matches the store of the given folder.

                    this.Cursor = System.Windows.Forms.Cursors.Default;
                    return account;
                }
            }

            this.Cursor = System.Windows.Forms.Cursors.Default;

            // No account matches, so return null.
            return null;
        }

        private void mnuInfoExchUsersCurrentUser_Click(object sender, EventArgs e)
        {
            string sInfo = ExchangeUsers.GetCurrentUserInfo(_oApp);

            ShowInformation oForm = new ShowInformation();
            oForm.WindowTitle = "Current User";
            oForm.txtInformation.Text = sInfo;
            oForm.ShowDialog();
            oForm = null;
        }

        private void mnuInfoExchUsersManager_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuInfoExchUsersCurrentUserMemberOfDl_Click(object sender, EventArgs e)
        {
            string sInfo = ExchangeUsers.GetCurrentUserMembership(_oApp);

            ShowInformation oForm = new ShowInformation();
            oForm.WindowTitle = "Current User DL Membership";
            oForm.txtInformation.Text = sInfo;
            oForm.ShowDialog();
            oForm = null;
        }

        private void frmInfoCategories_Click(object sender, EventArgs e)
        {
            string sInfo = OomColorCategories.EnumerateCategories(_oApp);

            ShowInformation oForm = new ShowInformation();
            oForm.WindowTitle = "Categories";
            oForm.txtInformation.Text = sInfo;
            oForm.ShowDialog();
            oForm = null;
        }

        private void mnuInfoStores_Click(object sender, EventArgs e)
        {
  
            string sInfo = OomStores.EnumerateStores(_oApp);

            ShowInformation oForm = new ShowInformation();
            oForm.WindowTitle = "Stores";
            oForm.txtInformation.Text = sInfo;
            oForm.ShowDialog();
            oForm = null;
        }

        private void mnuInfoAddressListsForProfile_Click(object sender, EventArgs e)
        {
            string sInfo = OomAddressBook.EnumerateAddressLists(_oApp);

            ShowInformation oForm = new ShowInformation();
            oForm.WindowTitle = "Address Lists for Profile";
            oForm.txtInformation.Text = sInfo;
            oForm.ShowDialog();
            oForm = null;
        }

        private void mnuInfoAddressListsEnumerateGal_Click(object sender, EventArgs e)
        {
            string sInfo = OomAddressBook.EnumerateGAL(_oApp);

            ShowInformation oForm = new ShowInformation();
            oForm.WindowTitle = "Enumerate GAL";
            oForm.txtInformation.Text = sInfo;
            oForm.ShowDialog();
            oForm = null;
        }

        private void mnuInfoHiddenItemsCalendarWorkingHours_Click(object sender, EventArgs e)
        {
            string sInfo = OomHiddenItems.GetCalendarWorkHoursXML(_oApp);

            ShowInformation oForm = new ShowInformation();
            oForm.WindowTitle = "Calendar Working Hours";
            oForm.txtInformation.Text = sInfo;
            oForm.ShowDialog();
            oForm = null;
        }

        private void cmsItemsOpen_Click(object sender, EventArgs e)
        {
            OutlookItem oOutlookItem = GetCurrentItemObjectAsOutlookItem();

            if (oOutlookItem != null)
            {
                //if (oOutlookItem.MessageClass == "IPM.Appointment")
                //{
                //    AppointmentItem oApptItem = (Microsoft.Office.Interop.Outlook.AppointmentItem)oOutlookItem;
                //    oApptItem.Display();
                //}
                //else
                oOutlookItem.Display();
            }

        }

        private OutlookItem GetCurrentItemObjectAsOutlookItem()
        {
            ItemTag oItemTag = null;
            oItemTag = (ItemTag)listView1.SelectedItems[0].Tag;
            OutlookItem oRet = null;

            if (oItemTag != null)
            {
 
                oRet = new OutlookItem(_oNS.GetItemFromID(oItemTag.EntryID, oItemTag.StoreID));
            }
            else
            {
                oRet = null;
            }
            return oRet;
        }

        private void mnuInfoApplicationInformation_Click(object sender, EventArgs e)
        {
            string sInfo = OomApplication.GetInfo(_oApp);

            ShowInformation oForm = new ShowInformation();
            oForm.WindowTitle = "Application Information";
            oForm.txtInformation.Text = sInfo;
            oForm.ShowDialog();
            oForm = null;
             
        }

        private void mnuInfoExchUsers_Click(object sender, EventArgs e)
        {

        }

        private void mnuToolsSearch_Click(object sender, EventArgs e)
        {
            FindItems oForm = new FindItems(_oApp, _oNS);

            oForm.ShowDialog();
            oForm = null;
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Old EmailForm oForm = new EmailForm(ref _oApp, ref  _oNS);

            MessageForm oForm = new MessageForm(ref _oApp, ref  _oNS);
            oForm.ShowDialog();

        }


//    Sub ProcessStoreItemsMove()
 
//    Dim oStores As outlook.Stores
//    Dim oStore As outlook.Store
//    Dim oRoot As outlook.Folder
    
//    Dim oFromFolder As outlook.Folder
//    Dim oToFolder As outlook.Folder
    
//    Dim sFromFolder As String
//    Dim sToFolder As String
    
//    sFromFolder = "MyOutlookPst" ' TODO: Change
//    sToFolder = "Mailbox - Dan Bagley"  ' TODO: Change
     
//    'On Error Resume Next
//    Set oStores = Application.Session.Stores
//    For Each oStore In oStores
//        Set oRoot = oStore.GetRootFolder
//        If oRoot.Name = sFromFolder Then
//            Set oFromFolder = oRoot.Folders("Inbox")
//        End If

//        If oRoot.Name = sToFolder Then
//            Set oToFolder = oRoot.Folders("Inbox")
//        End If
//    Next
    
//    ProcessMove oFromFolder, oToFolder  ' TODO: Call whatever processing routine you use
    
//    Set oFromFolder = Nothing
//    Set oToFolder = Nothing
//    Set oRoot = Nothing
//    Set oStore = Nothing
//    Set oStores = Nothing
    
 
//End Sub

//Sub ProcessMove(oFromFolder As outlook.Folder, oToFolder As outlook.Folder)
//    Dim oItems As outlook.Items
//    Dim sFilter As String
//    Dim oOrigItem As outlook.MailItem
//    Dim oCopiedItem As outlook.MailItem
     
//    sFilter = "[MessageClass]='IPM.Note'"
//    'sFilter = "[MessageClass]='IPM.Note' AND [LastModificationTime] > '03/9/2010'"
//    Set oItems = oFromFolder.Items.Restrict(sFilter)
    
//    Dim iItemCount As Integer
//    Dim iCount As Integer
//    iItemCount = oItems.Count
    
//    For iCount = iItemCount To 1 Step -1
         
//        Debug.Print oItems(iCount).Subject
        
//        Set oOrigItem = oItems(iCount)
//        Set oCopiedItem = oOrigItem.Copy
//        oCopiedItem.Move oToFolder
//        oOrigItem.Delete
        
//        Set oOrigItem = Nothing
//        Set oCopiedItem = Nothing
//    Next
    
//    Set oOrigItem = Nothing
//    Set oCopiedItem = Nothing
//    Set oItems = Nothing
     
//End Sub
    }

}
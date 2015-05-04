using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using System.Runtime.InteropServices;

namespace OomExplore
{
    public class TreeHelper
    {

        public static void LoadStoresIntoTreeView(ref Microsoft.Office.Interop.Outlook._NameSpace oNS, ref TreeView oTreeView)
        {
            Microsoft.Office.Interop.Outlook._Stores oStores;
            Microsoft.Office.Interop.Outlook._Store oStore;
            Microsoft.Office.Interop.Outlook.Folder oRootFolder;

            oStores = oNS.Stores;
            int iTotal = oStores.Count;
            for (int iCount = iTotal; iCount != 0; iCount--)
            {
                oStore = oStores[iCount];
                oRootFolder = (Microsoft.Office.Interop.Outlook.Folder)oStore.GetRootFolder();
                TreeNode oNode = oTreeView.Nodes.Add(oStore.DisplayName);
                oNode.Tag = new FolderTag(oStore.StoreID, oRootFolder.EntryID, oRootFolder.DefaultMessageClass);
                oNode.SelectedImageIndex = 1;
                oNode.Nodes.Add("");
                 
                oNode = null;
                Marshal.ReleaseComObject(oRootFolder);
                Marshal.ReleaseComObject(oStore);
                oRootFolder = null;
                oStore = null;
            }
            Marshal.ReleaseComObject(oStores);
            oStores = null;
        }

        public static void AddFolderToTreeNode(ref Microsoft.Office.Interop.Outlook._NameSpace oNS, ref TreeNode oNode, string sStoreId, string sFolderId)
        {
            try
            {

                TreeNode xNode = null;
                Microsoft.Office.Interop.Outlook.MAPIFolder oParentFolder = oNS.GetFolderFromID(sFolderId, sStoreId);
                Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = null;
                int iMax = oParentFolder.Folders.Count;
                for (int iCount = 1; iCount <= iMax; iCount++)
                {
                    oFolder = oParentFolder.Folders[iCount];
                    xNode = new TreeNode(oFolder.Name);
                    xNode.Tag = new FolderTag(oFolder.StoreID, oFolder.EntryID, oFolder.DefaultMessageClass);
                    xNode.SelectedImageIndex = 2;
                    System.Diagnostics.Debug.WriteLine(oFolder.DefaultMessageClass);
                    switch (oFolder.DefaultMessageClass)
                    {
                        case "IPM.Note":
                            xNode.SelectedImageIndex = 2;
                            break;
                        case "IPM.Contact":
                            xNode.SelectedImageIndex = 3;
                            break;
                       case "IPM.Appointment":
                            xNode.SelectedImageIndex = 4;
                            break;
                       case "IPM.Task":
                            xNode.SelectedImageIndex = 5;
                            break;
                       case "IPM.StickyNote":
                            xNode.SelectedImageIndex = 6;
                            break;
                       case "IPM.Activity":
                            xNode.SelectedImageIndex = 7;
                            break;
                        default:
                            break;
                    }

                    oNode.Nodes.Add(xNode);
                    xNode.Nodes.Add("");
                    xNode = null;
                    Marshal.ReleaseComObject(oFolder);
                    oFolder = null;
                }

                Marshal.ReleaseComObject(oParentFolder);
                oParentFolder = null;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format("Unable to expand the list {0}", ex.ToString()));
            }

        }

        public static TreeNode AddNewFolder(ref Microsoft.Office.Interop.Outlook._NameSpace oNS, ref TreeNode oNode)
        {
            TreeNode oNewNode = null;

            if (oNode != null)
            {

                NewFolder oForm = new NewFolder();

                oForm.ShowDialog();
                if (oForm.ChoseOK == true)
                {

                    FolderTag oFolderTag = (FolderTag)oNode.Tag;
                    Microsoft.Office.Interop.Outlook.MAPIFolder oParentFolder = oNS.GetFolderFromID(oFolderTag.EntryID, oFolderTag.StoreID);

                    Microsoft.Office.Interop.Outlook.MAPIFolder oNewFolder = null;
                    int iFolderType = oForm.GetFolderOlFolderType();
                    if (iFolderType != 0)
                        oNewFolder = oParentFolder.Folders.Add(oForm.txtEntry.Text.Trim(), oForm.GetFolderOlFolderType());
                    else
                        oNewFolder = oParentFolder.Folders.Add(oForm.txtEntry.Text.Trim(), null);

                    oNewNode = new TreeNode(oNewFolder.Name);
                    oNewNode.Tag = new FolderTag(oNewFolder.StoreID, oNewFolder.EntryID, oNewFolder.DefaultMessageClass);
                    oNode.Nodes.Add(oNewNode);

                    oFolderTag = null;
                }

                oForm = null;
            }
            return oNewNode;
        }
    }
}

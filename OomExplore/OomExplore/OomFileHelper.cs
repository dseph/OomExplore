using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop;
using System.IO;
using System.Windows.Forms;

namespace OomExplore
{
    class OomFileHelper
    {
       //save and load a message to a folder.
        public static bool LoadMsgFile(ref Microsoft.Office.Interop.Outlook._NameSpace oNS, string sFolderEntryId, string sFilePath)
        {
            bool bRet = false;

            try
            {

                if (File.Exists(sFilePath) == true)
                {
                    oNS.Application.CreateItemFromTemplate(sFilePath, sFolderEntryId);
                }
                else
                {
                    MessageBox.Show("File does not exist.", "File not found");
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error", Ex.Message);
            }

            return bRet;
       
       }

       //save and load a message to a folder.
       public static void SaveMsgFile(ref Microsoft.Office.Interop.Outlook._NameSpace oNS, string sItemEntryId, string sStoreId, 
                    string sFilePath, Microsoft.Office.Interop.Outlook.OlSaveAsType oSaveType)
       {
            try
            {
                string sFolder = Path.GetDirectoryName(sFilePath);
                if (Directory.Exists(sFolder) == true)
                {

                    // Need to determine what the object is in order to use the correct type for saving the item.
                    // The code below only works on message items for now.
                    object oItem = null;
                    oItem = oNS.GetItemFromID(sItemEntryId, sStoreId);

                    Microsoft.Office.Interop.Outlook.OlObjectClass oItemClass = Microsoft.Office.Interop.Outlook.OlObjectClass.olMail;

                    // oItemClass.HasValue && 
                    if (OomHelper.TryGetOutlookObjectClass(oItem, out oItemClass))
                    {
                        if (oItemClass == Microsoft.Office.Interop.Outlook.OlObjectClass.olMail)
                        {
                            Microsoft.Office.Interop.Outlook.MailItem oMailItem = null;
                            oMailItem = (Microsoft.Office.Interop.Outlook.MailItem)oItem;
                            oMailItem.SaveAs(sFilePath, oSaveType);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(oMailItem);
                            oMailItem = null;
                        }
                        if (oItemClass == Microsoft.Office.Interop.Outlook.OlObjectClass.olContact)
                        {
                            Microsoft.Office.Interop.Outlook.ContactItem oContact = null;
                            oContact = (Microsoft.Office.Interop.Outlook.ContactItem)oItem;
                            oContact.SaveAs(sFilePath, oSaveType);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(oContact);
                            oContact = null;
                        }
                        if (oItemClass == Microsoft.Office.Interop.Outlook.OlObjectClass.olTask)
                        {
                            Microsoft.Office.Interop.Outlook.MailItem oTask = null;
                            oTask = (Microsoft.Office.Interop.Outlook.MailItem)oItem;
                            oTask.SaveAs(sFilePath, oSaveType);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(oTask);
                            oTask = null;
                        }
                        if (oItemClass == Microsoft.Office.Interop.Outlook.OlObjectClass.olAppointment)
                        {
                            Microsoft.Office.Interop.Outlook.MeetingItem oMeetingItem = null;
                            oMeetingItem = (Microsoft.Office.Interop.Outlook.MeetingItem)oItem;
                            oMeetingItem.SaveAs(sFilePath, oSaveType);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(oMeetingItem);
                            oMeetingItem = null;
                        }
                        if (oItemClass == Microsoft.Office.Interop.Outlook.OlObjectClass.olNote)
                        {
                            Microsoft.Office.Interop.Outlook.NoteItem oNoteItem = null;
                            oNoteItem = (Microsoft.Office.Interop.Outlook.NoteItem)oItem;
                            oNoteItem.SaveAs(sFilePath, oSaveType);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(oNoteItem);
                            oNoteItem = null;
                        }
                    }
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oItem);
                    oItem = null;
 
                }
                else
                {
                    MessageBox.Show("Directory does not exist.", "Directory not found");
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error", Ex.Message);
            }
 
       }
    }
}

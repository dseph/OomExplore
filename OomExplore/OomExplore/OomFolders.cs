using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop;

namespace OomExplore
{
    public class OomFolders
    {
        //https://msdn.microsoft.com/EN-US/library/office/ff184594.aspx
        public static string GetDefaultMessageClass(Microsoft.Office.Interop.Outlook.Folder folder)
        {
            if (folder == null)
                throw new ArgumentNullException();
            try
            {
                const string PR_DEF_POST_MSGCLASS =
                    @"http://schemas.microsoft.com/mapi/proptag/0x36E5001E";
                string messageClass =
                    folder.PropertyAccessor.GetProperty(
                    PR_DEF_POST_MSGCLASS).ToString();
                return messageClass;
            }
            catch
            {
                return folder.DefaultMessageClass;
            }
        }

        // Returns Folder object based on folder path
        // https://msdn.microsoft.com/EN-US/library/office/ff184612.aspx
        public static Outlook.Folder GetFolder(string folderPath, Microsoft.Office.Interop.Outlook._Application oApp)
        {
            Outlook.Folder folder;
            string backslash = @"\";
            try
            {
                if (folderPath.StartsWith(@"\\"))
                {
                    folderPath = folderPath.Remove(0, 2);
                }
                String[] folders =
                    folderPath.Split(backslash.ToCharArray());
                folder = oApp.Session.Folders[folders[0]] as Outlook.Folder;
                if (folder != null)
                {
                    for (int i = 1; i <= folders.GetUpperBound(0); i++)
                    {
                        Outlook.Folders subFolders = folder.Folders;
                        folder = subFolders[folders[i]]
                            as Outlook.Folder;
                        if (folder == null)
                        {
                            return null;
                        }
                    }
                }
                return folder;
            }
            catch { return null; }
        }        

    }
}

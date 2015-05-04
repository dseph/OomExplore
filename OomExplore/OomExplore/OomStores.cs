using System;
using System.Collections.Generic;
using System.Text;

using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop;

namespace OomExplore
{
    public class OomStores
    {

        //https://msdn.microsoft.com/EN-US/library/office/ff184648.aspx
        public static string EnumerateStores(Microsoft.Office.Interop.Outlook._Application oApp)
        {
            StringBuilder oSB = new StringBuilder();

            Outlook.Stores stores = oApp.Session.Stores;
            foreach (Outlook.Store store in stores)
            {
                if (store.IsDataFileStore == true)
                {
                    oSB.AppendLine("Store: " + store.DisplayName + "\r\n" +
                        "    StoreID: " + store.StoreID + "\r\n" +
                        "    FilePath: " + store.FilePath + "\r\n" +
                        "    ExchangeStoreType: " + store.ExchangeStoreType.ToString() + "\r\n" +
                        "    Class: " + store.Class.ToString() + "\r\n" +
                        "    IsCachedExchange: " + store.IsCachedExchange.ToString() + "\r\n" +
                        "    IsConversationEnabled: " + store.IsConversationEnabled.ToString() + "\r\n" +
                        "    IsDataFileStore: " + store.IsDataFileStore.ToString() + "\r\n" +
                        "    IsInstantSearchEnabled: " + store.IsInstantSearchEnabled.ToString() + "\r\n" +
                        "    IsOpen: " + store.IsOpen.ToString() + "\r\n"  
                        );
                   oSB.AppendLine();
                }
            }
            return oSB.ToString();
        }


        // http://msdn.microsoft.com/en-us/library/bb612380(v=office.12).aspx
        public static void CreateUnicodePST()
        {
        //    string path = Environment.GetFolderPath(
        //        Environment.SpecialFolder.LocalApplicationData)
        //        + @"\Microsoft\Outlook\MyUnicodeStore.pst";
        //    try
        //    {
        //        Application.Session.AddStoreEx(
        //            path, Outlook.OlStoreType.olStoreUnicode);
        //        Outlook.Stores stores = Application.Session.Stores;
        //        foreach (Outlook.Store store in stores)
        //        {
        //            if (store.FilePath == path)
        //            {
        //               Outlook.Folder folder =
        //                    store.GetRootFolder() as Outlook.Folder;
        //               // Remove the store
        //               Application.Session.RemoveStore(folder);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }
        }

    }
}

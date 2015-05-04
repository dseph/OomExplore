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
    public class OomHiddenItems
    {
        public static string GetCalendarWorkHoursXML(Microsoft.Office.Interop.Outlook._Application oApp)
        {
            try
            {
                Outlook.StorageItem storage = oApp.Session.GetDefaultFolder(
                    Outlook.OlDefaultFolders.olFolderCalendar).GetStorage("IPM.Configuration.WorkHours",
                    Outlook.OlStorageIdentifierType.olIdentifyByMessageClass);

                Outlook.PropertyAccessor pa = storage.PropertyAccessor;
                // PropertyAccessor will return a byte array for this property
                byte[] rawXmlBytes = (byte[])pa.GetProperty(
                    "http://schemas.microsoft.com/mapi/proptag/0x7C080102");
                // Use Encoding to convert the array to a string
                return System.Text.Encoding.ASCII.GetString(rawXmlBytes);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}

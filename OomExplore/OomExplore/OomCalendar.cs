using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop;

namespace OomExplore
{
    class OomCalendar
    {

        // http://msdn.microsoft.com/en-us/library/bb646996(v=office.12).aspx
        private static void ShowAvailability()
        {
            //    const int slotLength = 60;
            //    Outlook.AddressEntry addrEntry =
            //        Application.Session.CurrentUser.AddressEntry;
            //    if (addrEntry.Type == "EX")
            //    {
            //        Outlook.ExchangeUser manager =
            //            Application.Session.CurrentUser.
            //            AddressEntry.GetExchangeUser().GetExchangeUserManager();
            //        if (manager != null)
            //        {
            //            string freeBusy = manager.GetFreeBusy(
            //                DateTime.Now, slotLength, true);
            //            for (int i = 1; i < freeBusy.Length; i++)
            //            {
            //                if (freeBusy.Substring(i, 1) == "0")
            //                {
            //                    // Get number of minutes into
            //                    // the day for free interval
            //                    double busySlot = (i - 1) * slotLength;
            //                    // Get an actual date/time
            //                    DateTime dateBusySlot =
            //                        DateTime.Now.Date.AddMinutes(busySlot);
            //                    if (dateBusySlot.TimeOfDay >=
            //                        DateTime.Parse("8:00 AM").TimeOfDay &
            //                        dateBusySlot.TimeOfDay <=
            //                        DateTime.Parse("5:00 PM").TimeOfDay &
            //                        !(dateBusySlot.DayOfWeek ==
            //                        DayOfWeek.Saturday |
            //                        dateBusySlot.DayOfWeek == DayOfWeek.Sunday))
            //                    {
            //                        StringBuilder sb = new StringBuilder();
            //                        sb.AppendLine(manager.Name
            //                            + " first open interval:");
            //                        sb.AppendLine(dateBusySlot.ToString("f"));
            //                        Debug.WriteLine(sb.ToString());
            //                    }
            //                }
            //            }
            //        }
            //    }
        }
    }
}

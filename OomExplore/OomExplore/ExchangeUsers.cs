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
    public class ExchangeUsers
    {

        public static string GetCurrentUserMembership(Microsoft.Office.Interop.Outlook._Application oApp)
        {
            StringBuilder oSB = new StringBuilder();
            Outlook.AddressEntry currentUser =
                oApp.Session.CurrentUser.AddressEntry;
            if (currentUser.Type == "EX")
            {
                Outlook.ExchangeUser exchUser =
                    currentUser.GetExchangeUser();
                if (exchUser != null)
                {
                    Outlook.AddressEntries addrEntries =
                        exchUser.GetMemberOfList();
                    if (addrEntries != null)
                    {
                        foreach (Outlook.AddressEntry addrEntry
                            in addrEntries)
                        {
                            oSB.AppendLine("Name: " + addrEntry.Name +
                                "   AddressEntryUserType: " + addrEntry.AddressEntryUserType.ToString() +
                                "   DisplayType: " + addrEntry.DisplayType.ToString() +
                                "   Type: " + addrEntry.Type  +
                                "   ID: " + addrEntry.ID
                                 
                                );
                        }
                    }
                }
            }
            return oSB.ToString();
        }


        // https://msdn.microsoft.com/EN-US/library/office/ff184601.aspx
        public static string GetCurrentUserInfo(Microsoft.Office.Interop.Outlook._Application oApp)
        {
            Microsoft.Office.Interop.Outlook.AddressEntry addrEntry =
                oApp.Session.CurrentUser.AddressEntry;

            StringBuilder sb = new StringBuilder();

            if (addrEntry.Type == "EX")
            {
                Outlook.ExchangeUser currentUser =
                    oApp.Session.CurrentUser.AddressEntry.GetExchangeUser();
                if (currentUser != null)
                {
                     
                    sb.AppendLine("Name: "
                        + currentUser.Name);
                    sb.AppendLine("STMP address: "
                        + currentUser.PrimarySmtpAddress);
                    sb.AppendLine("Title: "
                        + currentUser.JobTitle);
                    sb.AppendLine("Department: "
                        + currentUser.Department);
                    sb.AppendLine("Location: "
                        + currentUser.OfficeLocation);
                    sb.AppendLine("Business phone: "
                        + currentUser.BusinessTelephoneNumber);
                    sb.AppendLine("Mobile phone: "
                        + currentUser.MobileTelephoneNumber);


                    
                }
                 
            }
            return (sb.ToString());
        }

        public static string GetManagerInfo(Microsoft.Office.Interop.Outlook._Application oApp)
        {
            Outlook.AddressEntry currentUser =
                oApp.Session.CurrentUser.AddressEntry;

            StringBuilder sb = new StringBuilder();

            if (currentUser.Type == "EX")
            {
                Outlook.ExchangeUser manager =
                    currentUser.GetExchangeUser().GetExchangeUserManager();
                if (manager != null)
                {
                     
                    sb.AppendLine("Name: "
                        + manager.Name);
                    sb.AppendLine("STMP address: "
                        + manager.PrimarySmtpAddress);
                    sb.AppendLine("Title: "
                        + manager.JobTitle);
                    sb.AppendLine("Department: "
                        + manager.Department);
                    sb.AppendLine("Location: "
                        + manager.OfficeLocation);
                    sb.AppendLine("Business phone: "
                        + manager.BusinessTelephoneNumber);
                    sb.AppendLine("Mobile phone: "
                        + manager.MobileTelephoneNumber);
                     
                }
            }
            return(sb.ToString());
        }


        // https://msdn.microsoft.com/EN-US/library/office/bb646996.aspx
        public static string GetManagerOpenInterval(Microsoft.Office.Interop.Outlook._Application oApp)
        {
            const int slotLength = 60;
            StringBuilder sb = new StringBuilder();

            Outlook.AddressEntry addrEntry =
                oApp.Session.CurrentUser.AddressEntry;
            if (addrEntry.Type == "EX")
            {
                Outlook.ExchangeUser manager =
                    oApp.Session.CurrentUser.AddressEntry.GetExchangeUser().GetExchangeUserManager();
                if (manager != null)
                {
                    string freeBusy = manager.GetFreeBusy(
                        DateTime.Now, slotLength, true);
                    for (int i = 1; i < freeBusy.Length; i++)
                    {
                        if (freeBusy.Substring(i, 1) == "0")
                        {
                            // Get number of minutes into
                            // the day for free interval
                            double busySlot = (i - 1) * slotLength;
                            // Get an actual date/time
                            DateTime dateBusySlot =
                                DateTime.Now.Date.AddMinutes(busySlot);
                            if (dateBusySlot.TimeOfDay >=
                                DateTime.Parse("8:00 AM").TimeOfDay &
                                dateBusySlot.TimeOfDay <=
                                DateTime.Parse("5:00 PM").TimeOfDay &
                                !(dateBusySlot.DayOfWeek ==
                                DayOfWeek.Saturday |
                                dateBusySlot.DayOfWeek == DayOfWeek.Sunday))
                            {
                                 
                                sb.AppendLine(manager.Name
                                    + " first open interval:");
                                sb.AppendLine(dateBusySlot.ToString("f"));
                                 
                            }
                        }
                    }
                }
            }
            return(sb.ToString());
        }

        // https://msdn.microsoft.com/EN-US/library/office/ff184617.aspx
        public static string  GetManagerDirectReports(Microsoft.Office.Interop.Outlook._Application oApp)
        {
            StringBuilder sb = new StringBuilder();
            Outlook.AddressEntry currentUser =
                oApp.Session.CurrentUser.AddressEntry;
            if (currentUser.Type == "EX")
            {
                Outlook.ExchangeUser manager =
                    currentUser.GetExchangeUser().GetExchangeUserManager();
                if (manager != null)
                {
                    Outlook.AddressEntries addrEntries =
                        manager.GetDirectReports();
                    if (addrEntries != null)
                    {
                        foreach (Outlook.AddressEntry addrEntry
                            in addrEntries)
                        {
                            Outlook.ExchangeUser exchUser =
                                addrEntry.GetExchangeUser();
                             
                            sb.AppendLine("Name: "
                                + exchUser.Name);
                            sb.AppendLine("Title: "
                                + exchUser.JobTitle);
                            sb.AppendLine("Department: "
                                + exchUser.Department);
                            sb.AppendLine("Location: "
                                + exchUser.OfficeLocation);
                             
                        }
                    }
                }
            }
            return(sb.ToString());
        }
 

    }
}

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
    public class OomAddressBook
    {
        public static string EnumerateAddressLists(Microsoft.Office.Interop.Outlook._Application oApp)
        {
            StringBuilder sb = new StringBuilder();

            Outlook.AddressLists addrLists = oApp.Session.AddressLists;
             
            foreach (Outlook.AddressList addrList in addrLists)
            {
                 
                sb.AppendLine("Display Name: " + addrList.Name);
                sb.AppendLine("    Resolution Order: " + addrList.ResolutionOrder.ToString());
                sb.AppendLine("    Read-only : " + addrList.IsReadOnly.ToString());
                sb.AppendLine("    Initial Address List: "  + addrList.IsInitialAddressList.ToString());
                sb.AppendLine("");
                 
            }

            return sb.ToString();
        }


        public static string EnumerateGAL(Microsoft.Office.Interop.Outlook._Application oApp)
        {
            StringBuilder oSB = new StringBuilder();
            Outlook.AddressList gal =
                oApp.Session.GetGlobalAddressList();

            oSB.AppendLine("This shows the first 100 entries from the GAL.");
            oSB.AppendLine("");

            if (gal != null)
            {
                for (int i = 1;
                    i <= Math.Min(100, gal.AddressEntries.Count - 1); i++)
                {
                    Outlook.AddressEntry addrEntry = gal.AddressEntries[i];

                    if (addrEntry.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry
                        || addrEntry.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeRemoteUserAddressEntry)
                    {
                        Outlook.ExchangeUser exchUser = addrEntry.GetExchangeUser();
                        oSB.AppendLine("User: " + exchUser.Name  +
                             "  PrimarySmtpAddress:  " + exchUser.PrimarySmtpAddress +
                             "  AddressEntryUserType: " + addrEntry.AddressEntryUserType);
                    }
                    if (addrEntry.AddressEntryUserType ==
                        Outlook.OlAddressEntryUserType.olExchangeDistributionListAddressEntry)
                    {
                        Outlook.ExchangeDistributionList exchDL =
                            addrEntry.GetExchangeDistributionList();
                        oSB.AppendLine("User: " + exchDL.Name +
                            "  PrimarySmtpAddress:  " + exchDL.PrimarySmtpAddress +
                            "  AddressEntryUserType: " + addrEntry.AddressEntryUserType);
                    }
                }
            }
            return oSB.ToString();
        }
    }
}

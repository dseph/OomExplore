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
    class OomApplication
    {
        public static string GetInfo(Microsoft.Office.Interop.Outlook._Application oApp)
        {
            StringBuilder oSB = new StringBuilder();

            oSB.AppendFormat("Name: {0}\r\n", oApp.Name);
            oSB.AppendFormat("Version: {0}\r\n", oApp.Version);
            oSB.AppendFormat("ProductCode: {0}\r\n", oApp.ProductCode);
            oSB.AppendFormat("Class: {0}\r\n", oApp.Class.ToString());
            oSB.AppendFormat("DefaultProfileName: {0}\r\n", oApp.DefaultProfileName);
            oSB.AppendFormat("IsTrusted: {0}\r\n", oApp.IsTrusted.ToString());

            oSB.AppendLine();
            oSB.AppendFormat("COM Add-ins: \r\n" );
            foreach (Microsoft.Office.Core.COMAddIn oAddin in oApp.COMAddIns)
            {
 
                oSB.AppendFormat("    Description: {0}\r\n", oAddin.Description.ToString());
                oSB.AppendFormat("    Guid: {0}\r\n", oAddin.Guid.ToString());
                oSB.AppendFormat("    ProgId: {0}\r\n", oAddin.ProgId.ToString());
                oSB.AppendFormat("    Connect: {0}\r\n", oAddin.Connect.ToString());
                oSB.AppendFormat("    Creator: {0}\r\n", oAddin.Creator.ToString());
                oSB.AppendLine();
             
            }

            oSB.AppendLine();
            oSB.AppendFormat("TimeZones: \r\n");
            foreach (Microsoft.Office.Interop.Outlook.TimeZone oTimezone in oApp.TimeZones)
            {
                oSB.AppendFormat("    Name: {0}\r\n", oTimezone.Name);
                oSB.AppendFormat("    ID: {0}\r\n", oTimezone.ID);
                oSB.AppendFormat("    StandardDesignation {0}\r\n", oTimezone.StandardDesignation);
                oSB.AppendFormat("    StandardDesignation {0}\r\n", oTimezone.StandardDate.ToString());
                oSB.AppendFormat("    StandardBias {0}\r\n", oTimezone.StandardBias.ToString());
                oSB.AppendFormat("    Bias {0}\r\n", oTimezone.Bias.ToString());
                oSB.AppendFormat("    DaylightBias {0}\r\n", oTimezone.DaylightBias.ToString());
                oSB.AppendFormat("    DaylightDate {0}\r\n", oTimezone.DaylightDate.ToString());
                oSB.AppendFormat("    DaylightBias {0}\r\n", oTimezone.DaylightDesignation.ToString());
             
                oSB.AppendLine();
          
            }

            return oSB.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Office.Interop;
//using Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
 
using System.ComponentModel;
using System.Data;
using System.Drawing;
 

namespace OomExplore
{
    public class OomHelper
    {

        public static string GetTypeOfOutlookObject(object oOutlookObject)
        {
            Type t = oOutlookObject.GetType();
            string sMessageClass = t.InvokeMember("MessageClass", 
		          BindingFlags.Public |  
		          BindingFlags.GetField |  
		          BindingFlags.GetProperty, 
		          null, 
		          oOutlookObject, 
		          new object[]{}).ToString(); 
	        Marshal.ReleaseComObject(oOutlookObject);
	        oOutlookObject  = null;

            return sMessageClass;  
        }

        /// <summary>
        /// Tries to get the Outlook.OlObjectClass from the given Outlook item 
        /// without casting or leaking an item reference.
        /// </summary>
        /// <param name="item">
        /// Object to try to pull the property value from.  This should be an
        /// Outlook object model item type.
        /// </param>
        /// <param name="objectClass">
        /// Output parameter returns a nullable Outlook.OlObjectClass if the 
        /// property was found on the item passed to this function.  If it could 
        /// not be retrieved from the item or there was an exception it 
        /// returns null.
        /// </param>
        /// <returns>
        /// Returns true if the property was found and returned.  Returns false
        /// if the property was not found or there was an error.
        /// </returns>
        /// <remarks>
        /// Usage:
        ///     Microsoft.Office.Interop.Outlook.OlObjectClass oItemClass = Microsoft.Office.Interop.Outlook.OlObjectClass.olMail;
        ///    if (OomHelper.TryGetOutlookObjectClass(pstInbox.Items[i], out itemClass) &&
        ///    itemClass.HasValue && itemClass.Value == Outlook.OlObjectClass.olMail)
        ///    {
        ///        mailItem = (Outlook.MailItem)pstInbox.Items[i];
        ///    }
        /// </remarks>
        public static bool TryGetOutlookObjectClass(
            object item,
            out Microsoft.Office.Interop.Outlook.OlObjectClass objectClass)
        {
            const string ObjectClassPropertyName = "Class";
            //objectClass = null;
            objectClass = Microsoft.Office.Interop.Outlook.OlObjectClass.olMail;

            try
            {

                if (item == null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "TryGetOutlookObjectClass Leave: item is null.");
                    return false;
                }

                Type itemType = item.GetType();

                if (itemType == null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "TryGetOutlookObjectClass Leave: itemType is null.");
                    return false;
                }

                object propValue = itemType.InvokeMember(
                                       ObjectClassPropertyName,
                                       System.Reflection.BindingFlags.GetProperty,
                                       null,
                                       item,
                                       null);

                // If the parsed property value is not defined in Outlook.OlObjectClass
                // then it is a bogus value - return null instead.
                if (!System.Enum.IsDefined(
                        typeof(Microsoft.Office.Interop.Outlook.OlObjectClass),
                        System.Enum.Parse(typeof(Microsoft.Office.Interop.Outlook.OlObjectClass),
                        propValue.ToString())))
                {
                    System.Diagnostics.Debug.WriteLine(
                        String.Concat("TryGetOutlookObjectClass Leave: '",
                                        propValue.ToString(),
                                        "' is not defined in Outlook.OlObjectClass"));
                    return false;
                }

                // If we got here then everything is good, return results
                objectClass = (Microsoft.Office.Interop.Outlook.OlObjectClass)propValue;
                return true;
            }
            catch ( Exception ex1)
            {
                // If there is an error, return null.
                System.Diagnostics.Debug.WriteLine(
                    String.Concat("TryGetOutlookObjectClass Leave: Exception: Type='",
                                    ex1.GetType().FullName,
                                    "' Message='", ex1.Message));
                return false;
            }
 
        }


    }
}

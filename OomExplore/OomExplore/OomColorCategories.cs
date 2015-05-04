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

    // https://msdn.microsoft.com/EN-US/library/office/ff424467.aspx
    public class OomColorCategories
    {
        public static string EnumerateCategories(Microsoft.Office.Interop.Outlook._Application oApp)
        {
            StringBuilder oSB = new StringBuilder();

            Outlook.Categories categories =
                oApp.Session.Categories;
            foreach (Outlook.Category category in categories)
            {
                oSB.AppendLine("Name: " + category.Name);
                oSB.AppendLine("   CategoryId: " + category.CategoryID);
                oSB.AppendLine("   Color: " + category.Color.ToString());
                oSB.AppendLine("   CategoryBorderColor: " + category.CategoryBorderColor.ToString());
                oSB.AppendLine("   CategoryGradientBottomColor: " + category.CategoryGradientBottomColor.ToString());
                oSB.AppendLine("   CategoryGradientTopColor: " + category.CategoryGradientTopColor.ToString());
                oSB.AppendLine("   ShortcutKey: " + category.ShortcutKey.ToString());
                oSB.AppendLine("");
            }

            return (oSB.ToString());
        }

        public static void AddACategory(Microsoft.Office.Interop.Outlook._Application oApp)
        {
            Outlook.Categories categories =
                oApp.Session.Categories;

            if (!CategoryExists("ISV", oApp))
            {
                Outlook.Category category = categories.Add("ISV",
                    Outlook.OlCategoryColor.olCategoryColorDarkBlue,
                    Outlook.OlCategoryShortcutKey.olCategoryShortcutKeyCtrlF11);
            }
        }

        public static bool CategoryExists(string categoryName, Microsoft.Office.Interop.Outlook._Application oApp)
        {
            try
            {
                Outlook.Category category =
                    oApp.Session.Categories[categoryName];
                if (category != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop;


namespace OomExplore
{
    public partial class FindItems : Form
    {
        Microsoft.Office.Interop.Outlook._Application _oApp = null;
        Microsoft.Office.Interop.Outlook._NameSpace _oNS = null;

        string[] sFields = { "",
                "urn:schemas:httpmail:fromemail",
                "urn:schemas:httpmail:fromname",
                "urn:schemas:httpmail:to",
                "urn:schemas:httpmail:displayto",         
                "urn:schemas:httpmail:cc",
                "urn:schemas:httpmail:displaycc",
                "urn:schemas:httpmail:bcc",
                "urn:schemas:httpmail:displaybcc",
                "urn:schemas:httpmail:subject",
                "urn:schemas:httpmail:textdescription"
                          };

        string[] sComparrison = { "",
                "LIKE"
                          };
        string[] sJoin = { "",
                "OR",
                "AND"
                          };

        public FindItems()
        {
            InitializeComponent();
        }

        public FindItems(Microsoft.Office.Interop.Outlook._Application oApp, Microsoft.Office.Interop.Outlook._NameSpace oNS)
        {
            InitializeComponent();
            _oApp = oApp;
            _oNS = oNS;
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            // https://msdn.microsoft.com/en-us/library/aa581347(v=exchg.80).aspx
            //Microsoft.Office.Interop.Outlook._NameSpace _oNS = null;

            string sFolderScope = txtFolders.Text.Trim();
            string sSearch = txtSearchString.Text.Trim();

            if (sFolderScope.Length == 0)
                MessageBox.Show("Folders need to be specified before searching.", "Entry required.");
            else 
                if (sSearch.Length == 0)
                    MessageBox.Show("Search criteria needs to be specified before searching.", "Entry required.");
                else
                {
                    DateTime _StartTime = DateTime.Now;

                    // https://msdn.microsoft.com/en-us/library/office/ff866933.aspx
                    Search advancedSearch = _oApp.AdvancedSearch(sFolderScope, txtSearchString.Text, btnSearchSubfolders.Checked, Type.Missing);

                    if (advancedSearch.Results.Count > 0)
                    {

                        DateTime _EndTime = DateTime.Now;
                        TimeSpan _objTime = _EndTime.Subtract(_StartTime);
                        MessageBox.Show("Search Completed. Total Email Records: " + advancedSearch.Results.Count.ToString() + ", Total Time in seconds : " + _objTime.TotalSeconds.ToString());

                    }
                    else
                        MessageBox.Show("No results found.");

                }

 

        }

        private string GetCriteriaString(string sField, string sComparrison, string sSearchText, string sJoin)
        {
            string sReturn = "";
            if (sField != "")
            {
                sReturn = sField + " " + sComparrison + " '%" + sSearchText + "%'";
                if (sJoin != "")
                    sReturn += " " + sJoin + " ";
            }
            return sReturn;
        }

        private void FindItems_Load(object sender, EventArgs e)
        {
            LoadItems(ref this.cmbo1, sFields);
            LoadItems(ref this.cmbo2, sFields);
            LoadItems(ref this.cmbo3, sFields);
            LoadItems(ref this.cmbo4, sFields);
            LoadItems(ref this.cmbo5, sFields);

            LoadItems(ref this.cmboComparrison1, sComparrison);
            LoadItems(ref this.cmboComparrison2, sComparrison);
            LoadItems(ref this.cmboComparrison3, sComparrison);
            LoadItems(ref this.cmboComparrison4, sComparrison);
            LoadItems(ref this.cmboComparrison5, sComparrison);

            LoadItems(ref this.cmboJoin1, sJoin);
            LoadItems(ref this.cmboJoin2, sJoin);
            LoadItems(ref this.cmboJoin3, sJoin);
            LoadItems(ref this.cmboJoin4, sJoin);
            LoadItems(ref this.cmboJoin5, sJoin);
        }

        private void LoadItems(ref ComboBox oCB, string[] sContents)
        {

            oCB.Items.AddRange(sContents);
        }

        private void btnBuildSearchString_Click(object sender, EventArgs e)
        {
            string sFilter = string.Empty;

            sFilter += GetCriteriaString(cmbo1.Text, cmboComparrison1.Text, txt1.Text.Trim(), cmboJoin1.Text);
            sFilter += GetCriteriaString(cmbo2.Text, cmboComparrison2.Text, txt2.Text.Trim(), cmboJoin2.Text);
            sFilter += GetCriteriaString(cmbo3.Text, cmboComparrison3.Text, txt3.Text.Trim(), cmboJoin3.Text);
            sFilter += GetCriteriaString(cmbo4.Text, cmboComparrison4.Text, txt4.Text.Trim(), cmboJoin4.Text);
            sFilter += GetCriteriaString(cmbo5.Text, cmboComparrison5.Text, txt5.Text.Trim(), cmboJoin5.Text);

            this.txtSearchString.Text = sFilter;

        }

        private void btnFoldersList_Click(object sender, EventArgs e)
        {
            Folder folderInbox = (Folder)_oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            Folder folderSentMail = (Folder)_oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail);
            string sScope = "'" + folderInbox.FolderPath + "','" + folderSentMail.FolderPath + "'";

            // OR:  string sScope = "'Inbox', 'Sent Items'"

            txtFolders.Text = sScope;
        }

        //https://msdn.microsoft.com/en-us/library/cc513841(v=office.12).aspx
 

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnInstantSearch_Click(object sender, EventArgs e)
        {
            if (_oApp.Session.DefaultStore.IsInstantSearchEnabled)
            {
                Outlook.Explorer explorer = _oApp.Explorers.Add(
                    _oApp.Session.GetDefaultFolder(
                    Outlook.OlDefaultFolders.olFolderInbox)
                    as Outlook.Folder,
                    Outlook.OlFolderDisplayMode.olFolderDisplayNormal);
                string filter = txtInstantSearchCriteria.Text;

                explorer.Search(filter, Outlook.OlSearchScope.olSearchScopeAllFolders);
                explorer.Display();
            }
            else
            {
                MessageBox.Show("Instant Search is not enabled for the mailbox store.");

            }
        }

 

        private void cmboJoin1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnInstantSearchInbox_Click(object sender, EventArgs e)
        {
            if (_oApp.Session.DefaultStore.IsInstantSearchEnabled)
            {
                Outlook.Explorer explorer = _oApp.Explorers.Add(
                    _oApp.Session.GetDefaultFolder(
                    Outlook.OlDefaultFolders.olFolderInbox)
                    as Outlook.Folder,
                    Outlook.OlFolderDisplayMode.olFolderDisplayNormal);
                string filter = txtInstantSearchCriteria.Text;

                explorer.Search(filter, Outlook.OlSearchScope.olSearchScopeCurrentFolder);
                explorer.Display();
            }
            else
            {
                MessageBox.Show("Instant Search is not enabled for the mailbox store.");

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OomExplore
{
    public partial class NewFolder : Form
    {
        public bool ChoseOK = false;

        public NewFolder()
        {
            InitializeComponent();

            lbEntry.Items.Add("Parent Folder Type"); // 0
            lbEntry.Items.Add("olFolderInbox");     //6
            lbEntry.Items.Add("olFolderContacts");  // 10
            lbEntry.Items.Add("olFolderCalendar");  // 9
            lbEntry.Items.Add("olFolderNotes");     // 12
            lbEntry.Items.Add("olFolderTasks");     // 13
            lbEntry.Items.Add("olFolderJournal");     // 11
            lbEntry.SelectedIndex = 0;
        }

        public int GetFolderOlFolderType()
        {
            int iRet = 0;
            switch (lbEntry.Text)
            {
                case "Parent Folder Type":
                    iRet = 0;
                    break;
                case "olFolderInbox":
                    iRet = 6;
                    break;
                case "olFolderContacts":
                    iRet = 10;
                    break;
                case "olFolderCalendar":
                    iRet = 9;
                    break;
                case "olFolderNotes":
                    iRet = 12;
                    break;
                case "olFolderTasks":
                    iRet = 13;
                    break;
                case "olFolderJournal":
                    iRet = 11;

                    break;
                default:
                    iRet = 0;
                    break;
            }

            return iRet;
        }

        private void NewFolder_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtEntry.Text.Trim().Length != 0)
            {
                ChoseOK = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter folder name.", "Entry Missing");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChoseOK = false;
            this.Close();
        }
    }
}
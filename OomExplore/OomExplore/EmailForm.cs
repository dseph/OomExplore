using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop;

namespace OomExplore
{
    public partial class EmailForm : Form

 
    {   
        private bool _IsExistingEmail = false;
        private bool _CanEdit = false;
        private bool _CanSend = false;
        private bool _CanReply = false;

        private Outlook.MailItem _EmailMessage = null;

        private Outlook.MailItem _ResponseMessage = null;

        Microsoft.Office.Interop.Outlook._Application _oApp = null;
        Microsoft.Office.Interop.Outlook._NameSpace _oNS = null;

 
        public enum EditMessageType
        {
            IsExistingDraft,
            IsExistingSent,
            IsNew,
            IsResponding
        }

        public enum ResponseMessageType
        {
            Forward,
            Reply,
            ReplyAll 
        }
 


        public EmailForm( )
        {
            InitializeComponent();
   
        }

 
 
        // New Message
        public EmailForm(ref Microsoft.Office.Interop.Outlook._Application oApp, ref Microsoft.Office.Interop.Outlook._NameSpace oNS)
        {
            InitializeComponent( );

            _oApp = oApp;
            _oNS = oNS;

             Outlook.MailItem _EmailMessage = (Outlook.MailItem) _oApp.CreateItem(Outlook.OlItemType.olMailItem);

   
            //_EmailMessage = LoadEmailMessageForEdit(oEwsCaller, oItemId);
            _IsExistingEmail = false;
           
 
            //if (_EmailMessage.IsNew)  // is stored?
            //{
                // _EditMessageType = EditMessageType.IsNew;
                _CanEdit = true;
                _CanSend = true;
                _CanReply = false;
            //}
           System.Diagnostics.Debug.WriteLine("1 _EmailMessage is null: " + (_EmailMessage == null).ToString());

 
            SetFormFromMessage(_EmailMessage, _CanEdit, _CanSend, _CanReply);


            System.Diagnostics.Debug.WriteLine("2 _EmailMessage is null: " + (_EmailMessage == null).ToString());
        }


        //// New Message
        //public MessageForm(ExchangeService CurrentService, FolderId oFolderId)
        //{
        //    InitializeComponent();

        //    _CurrentService = CurrentService;
        //    _EmailMessage = new EmailMessage(_CurrentService);
        //    //_EmailMessage = LoadEmailMessageForEdit(oEwsCaller, oItemId);
        //    _IsExistingEmail = false;
           
 
        //    if (_EmailMessage.IsNew)  // is stored?
        //    {
        //        // _EditMessageType = EditMessageType.IsNew;
        //        _CanEdit = true;
        //        _CanSend = true;
        //        _CanReply = false;
        //    }
 
        //    SetFormFromMessage(_EmailMessage, _CanEdit, _CanSend, _CanReply);
        //}

        // Existing Message
        public void MessageForm(ref Microsoft.Office.Interop.Outlook._Application oApp, ref Microsoft.Office.Interop.Outlook._NameSpace oNS, ref Outlook.MailItem oEmailMessage )
        {
            InitializeComponent();
 
            _oApp = oApp;
            _oNS = oNS;


            _EmailMessage = oEmailMessage;

            _IsExistingEmail = true;

            _CanEdit = false;
            _CanSend = false;
            _CanReply = true;
            if (_EmailMessage.Sent)  // is stored?
            {
               // _EditMessageType = EditMessageType.IsNew;
                _CanEdit = true;
                _CanSend = true;
                _CanReply = false;
            }

            System.Diagnostics.Debug.WriteLine("3 _EmailMessage is null: " + (_EmailMessage == null).ToString());

            SetFormFromMessage(oEmailMessage, _CanEdit, _CanSend, _CanReply);

            System.Diagnostics.Debug.WriteLine("4 _EmailMessage is null: " + (_EmailMessage == null).ToString());
        }


        private void btnAttachments_Click(object sender, EventArgs e)
        {
            //Item oItem = (Item)_EmailMessage;
            //AddRemoveAttachments oAddRemoveAttachments = new AddRemoveAttachments(ref oItem, _IsExistingEmail);
            //oAddRemoveAttachments.ShowDialog();
            //if (oAddRemoveAttachments.IsDirty == true)
            //    _isDirty = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("5 _EmailMessage is null: " + (_EmailMessage == null).ToString());

            SaveCurrentMessage();

            System.Diagnostics.Debug.WriteLine("6 _EmailMessage is null: " + (_EmailMessage == null).ToString());

            this.Close();
        }

        private void EmailForm_Load(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            txtTo.Text = string.Empty;
            txtBCC.Text = string.Empty;
            txtCC.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtBody.Text = string.Empty;
            chkDeliveryReceipt.Checked = false;
            chkReadReceipt.Checked = false;
            cmboBodyType.Text = string.Empty;
        }

        private bool SetFormFromMessage(Outlook.MailItem oEmailMessage, bool CanEdit, bool CanSend, bool CanReply)
        {
            bool bRet = false;
            int iNothing = 0;
            iNothing = iNothing + 0;

            // Outlook.MailItem _EmailMessage = (Outlook.MailItem) _oApp.CreateItem(Outlook.OlItemType.olMailItem);
            System.Diagnostics.Debug.WriteLine("7 _EmailMessage is null: " + (_EmailMessage == null).ToString());

            ClearForm();

            System.Diagnostics.Debug.WriteLine("8 _EmailMessage is null: " + (_EmailMessage == null).ToString());

            if (_IsExistingEmail == false)
            {
                btnForward.Enabled = false;
                btnReply.Enabled = false;
                btnReplyAll.Enabled = false;
            }


            if (_IsExistingEmail == true)
            {
                if (oEmailMessage.Sent == false)  // Draft?
                {
                    txtFrom.Text = oEmailMessage.Sender.Address;
                    btnForward.Enabled = false;
                    btnReply.Enabled = false;
                    btnReplyAll.Enabled = false;
                }

                txtTo.Text = oEmailMessage.To;
                txtBCC.Text = oEmailMessage.CC;
                txtCC.Text= oEmailMessage.BCC;
                 
               

                txtSubject.Text = oEmailMessage.Subject;
               
                if (oEmailMessage.BodyFormat == OlBodyFormat.olFormatHTML)
                { 
                    cmboBodyType.Text = "HTML";
                    txtBody.Text = oEmailMessage.HTMLBody;
                }
                if (oEmailMessage.BodyFormat == OlBodyFormat.olFormatPlain)
                { 
                    cmboBodyType.Text = "Plain";
                    txtBody.Text = oEmailMessage.Body;
                }
                if (oEmailMessage.BodyFormat == OlBodyFormat.olFormatRichText)
                { 
                    cmboBodyType.Text = "RichText";
                    txtBody.Text = ""; //oEmailMessage.RTFBody;
               }
               if (oEmailMessage.BodyFormat == OlBodyFormat.olFormatUnspecified)
               { 
                    cmboBodyType.Text = "Unspecified";
                   txtBody.Text = oEmailMessage.Body;
               }


                 

                try
                {
                    chkDeliveryReceipt.Checked = oEmailMessage.OriginatorDeliveryReportRequested;

                }
                catch (System.Exception ex_IsDeliveryReceiptRequested)
                {

                    chkDeliveryReceipt.Checked = false;
                    { if (ex_IsDeliveryReceiptRequested != null) iNothing = 0; }
                }

                try
                {

                    chkReadReceipt.Checked = oEmailMessage.ReadReceiptRequested;

                }
                catch (System.Exception ex_IsReadReceiptRequested)
                {
                    chkReadReceipt.Checked = false;
                    { if (ex_IsReadReceiptRequested != null) iNothing = 0; }
                }


                btnSend.Enabled = CanSend;


                if (CanEdit == true)
                {

                    btnSave.Enabled = true;
                    chkReadReceipt.Enabled = true;
                    chkDeliveryReceipt.Enabled = true;
                }
                else
                {

                    btnSave.Enabled = false;
                }

                btnReply.Enabled = CanReply;
                btnReplyAll.Enabled = CanReply;
                btnForward.Enabled = CanReply;
             }
            else
            {
                btnSend.Enabled = CanSend;
                btnSave.Enabled = true;
                chkReadReceipt.Enabled = true;
                chkDeliveryReceipt.Enabled = true;
                cmboBodyType.Text = "Text";
              }

            System.Diagnostics.Debug.WriteLine("9 _EmailMessage is null: " + (_EmailMessage == null).ToString());

            return bRet;
        }



        private bool SetMessageFromForm(ref Outlook.MailItem oEmailMessage)
        {
            bool bRet = true;

            System.Diagnostics.Debug.WriteLine("10 _EmailMessage is null: " + (_EmailMessage == null).ToString());
 
            oEmailMessage.To = txtTo.Text;
            oEmailMessage.CC = txtCC.Text;
            oEmailMessage.BCC = txtBCC.Text;




            if (bRet)
            {
                try
                {
                    oEmailMessage.Subject = txtSubject.Text.Trim();


                    if (cmboBodyType.Text == "HTML")
                    {
                        oEmailMessage.Body = txtBody.Text;
                    }
                    if (cmboBodyType.Text == "Plain")
                    {
                        oEmailMessage.Body = txtBody.Text;
                    }
                    if (cmboBodyType.Text == "RichText")
                    {
                        oEmailMessage.Body = txtBody.Text;
                    }
                    if (cmboBodyType.Text == "Unspecified")
                    {
                        oEmailMessage.Body = txtBody.Text;
                    }
 
 
                    oEmailMessage.ReadReceiptRequested = chkReadReceipt.Checked;

                    oEmailMessage.OriginatorDeliveryReportRequested = chkDeliveryReceipt.Checked;

                    if (txtAttachment.Text.Trim().Length != 0)
                    {
                        OlAttachmentType oType = OlAttachmentType.olByValue;
                        // OlAttachmentType oType = OlAttachmentType.olByReference;
                        //OlAttachmentType oType = OlAttachmentType.olByValue;
                        //OlAttachmentType oType = OlAttachmentType.olEmbeddeditem;
                        //OlAttachmentType oType = OlAttachmentType.olOLE;
                        if (chkSpecifyAttachByValue.Checked == true)
                            oEmailMessage.Attachments.Add(txtAttachment.Text.Trim(), oType);
                        else
                            oEmailMessage.Attachments.Add(txtAttachment.Text.Trim());
                    }
                }

                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error setting properties on message");
                    bRet = false;
                }

            }

            System.Diagnostics.Debug.WriteLine("11 _EmailMessage is null: " + (_EmailMessage == null).ToString());

            return bRet;

        }

          

        private bool SaveCurrentMessage()
        {
            bool bRet = false;
            try
            {
                System.Diagnostics.Debug.WriteLine("13 _EmailMessage is null: " + (_EmailMessage == null).ToString());

                if (SetMessageFromForm(ref _EmailMessage))
                {

                    if (_IsExistingEmail == false)
                    {
                        //_EmailMessage.Save(WellKnownFolderName.Drafts);

                        System.Diagnostics.Debug.WriteLine("14 _EmailMessage is null: " + (_EmailMessage == null).ToString());

                        _EmailMessage.Save();

                        System.Diagnostics.Debug.WriteLine("15 _EmailMessage is null: " + (_EmailMessage == null).ToString());

                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("16 _EmailMessage is null: " + (_EmailMessage == null).ToString());
                        _EmailMessage.Save();
                        //_EmailMessage.Update(ConflictResolutionMode.AutoResolve);
                        System.Diagnostics.Debug.WriteLine("17 _EmailMessage is null: " + (_EmailMessage == null).ToString());
                    }

                }
                bRet = true;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("18 _EmailMessage is null: " + (_EmailMessage == null).ToString());
                MessageBox.Show(ex.Message, "Error Saving Message");
                System.Diagnostics.Debug.WriteLine("19 _EmailMessage is null: " + (_EmailMessage == null).ToString());
            }
            return bRet;
        }


        private bool SendMessage(bool bSaveCopy)
        {
            bool bRet = false;

            //if (_ResponseMessage == null)
            // {
            System.Diagnostics.Debug.WriteLine("27 _EmailMessage is null: " + (_EmailMessage == null).ToString());
            bRet = SetMessageFromForm(ref _EmailMessage);
            System.Diagnostics.Debug.WriteLine("28 _EmailMessage is null: " + (_EmailMessage == null).ToString());
            if (_ResponseMessage == null)
            {
                try
                {
                    if (bSaveCopy)
                    {
                        ((Outlook._MailItem)_EmailMessage).Send();
                        System.Diagnostics.Debug.WriteLine("29 _EmailMessage is null: " + (_EmailMessage == null).ToString());
                    }
                    else
                    {
                        ((Outlook._MailItem)_EmailMessage).Send();
                        System.Diagnostics.Debug.WriteLine("30 _EmailMessage is null: " + (_EmailMessage == null).ToString());
                    }
                    bRet = true;
                }
                catch (System.Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("31 _EmailMessage is null: " + (_EmailMessage == null).ToString());
                    MessageBox.Show(ex.Message, "Error Sending Message");
                    bRet = false;
                }
            }

            return bRet;
        }

        private bool MakeResponseMessage(ResponseMessageType oResponseMessageType)
        {
            bool bRet = false;

            System.Diagnostics.Debug.WriteLine("20 _EmailMessage is null: " + (_EmailMessage == null).ToString());

            Outlook.MailItem  oResponseMessage = null;

            System.Diagnostics.Debug.WriteLine("21 _EmailMessage is null: " + (_EmailMessage == null).ToString());

            string sWindowTitle = string.Empty;
            try
            {
                if (oResponseMessageType == ResponseMessageType.Reply)
                {
                    oResponseMessage = ((Outlook.MailItem)_EmailMessage).Reply(); 
                    sWindowTitle = "Reply Message";
                }
                if (oResponseMessageType == ResponseMessageType.ReplyAll)
                {
                    oResponseMessage = ((Outlook.MailItem)_EmailMessage).ReplyAll(); 
                    sWindowTitle = "Reply All Message";
                }
                if (oResponseMessageType == ResponseMessageType.Forward)
                {
                    oResponseMessage = ((Outlook.MailItem)_EmailMessage).Forward(); 
                    sWindowTitle = "Forward Message";

                }

                 

                // Save as drafts AND set as new current message.
                //_EmailMessage = oResponseMessage.Save(WellKnownFolderName.Drafts);
                //_EmailMessage.Load();

                System.Diagnostics.Debug.WriteLine("22 _EmailMessage is null: " + (_EmailMessage == null).ToString());
                SetFormFromMessage(_EmailMessage, true, true, false);

                System.Diagnostics.Debug.WriteLine("23 _EmailMessage is null: " + (_EmailMessage == null).ToString());

                bRet = true;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("24 _EmailMessage is null: " + (_EmailMessage == null).ToString());
                MessageBox.Show(ex.Message, "Error creating message");
                bRet = false;
            }
            return bRet;
        }
        private void btnForward_Click(object sender, EventArgs e)
        {
            //bool bRet = false;

            //bRet = MakeResponseMessage(ResponseMessageType.Forward);
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            //bool bRet = false;

            //bRet = MakeResponseMessage(ResponseMessageType.Reply);
        }


        private void btnReplyAll_Click(object sender, EventArgs e)
        {
            //bool bRet = false;
            //bRet = MakeResponseMessage(ResponseMessageType.ReplyAll);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_ResponseMessage == null)
            {
                System.Diagnostics.Debug.WriteLine("25 _EmailMessage is null: " + (_EmailMessage == null).ToString());
                SendMessage(true);
                System.Diagnostics.Debug.WriteLine("26 _EmailMessage is null: " + (_EmailMessage == null).ToString());

                this.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (_ResponseMessage == null)
            {
                System.Diagnostics.Debug.WriteLine("25 _EmailMessage is null: " + (_EmailMessage == null).ToString());
                SendMessage(true);
                System.Diagnostics.Debug.WriteLine("26 _EmailMessage is null: " + (_EmailMessage == null).ToString());

                this.Close();
            }
        }


    }

}

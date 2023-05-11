namespace OomExplore
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvFolders = new System.Windows.Forms.TreeView();
            this.cmsFolders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsFoldersProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFoldersCopyToFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFoldersMoveToFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFoldersNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFoldersStoreProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFolderAccountForFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cmsItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsItemsProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsCopyToFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsMoveToFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsMoveAllItems = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsCopyAllItems = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsSaveToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mnuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMainAvailabilityInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfoAccountInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfoExchUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfoExchUsersCurrentUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfoExchUsersCurrentUserMemberOfDl = new System.Windows.Forms.ToolStripMenuItem();
            this.frmInfoCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfoStores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfoAddressLists = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfoAddressListsForProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfoAddressListsEnumerateGal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfoHiddenItems = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfoHiddenItemsCalendarWorkingHours = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfoApplicationInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFolders.SuspendLayout();
            this.cmsItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvFolders
            // 
            this.tvFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFolders.ContextMenuStrip = this.cmsFolders;
            this.tvFolders.FullRowSelect = true;
            this.tvFolders.HideSelection = false;
            this.tvFolders.Location = new System.Drawing.Point(6, 0);
            this.tvFolders.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.Size = new System.Drawing.Size(467, 638);
            this.tvFolders.TabIndex = 0;
            this.tvFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvFolders_BeforeExpand);
            this.tvFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolders_AfterSelect);
            // 
            // cmsFolders
            // 
            this.cmsFolders.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsFolders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsFoldersProperties,
            this.cmsFoldersCopyToFolder,
            this.cmsFoldersMoveToFolder,
            this.cmsFoldersNewFolder,
            this.cmsFoldersStoreProperties,
            this.cmsFolderAccountForFolder});
            this.cmsFolders.Name = "cmsFolders";
            this.cmsFolders.Size = new System.Drawing.Size(371, 232);
            // 
            // cmsFoldersProperties
            // 
            this.cmsFoldersProperties.Name = "cmsFoldersProperties";
            this.cmsFoldersProperties.Size = new System.Drawing.Size(370, 38);
            this.cmsFoldersProperties.Text = "Properties";
            this.cmsFoldersProperties.Click += new System.EventHandler(this.cmsFoldersProperties_Click);
            // 
            // cmsFoldersCopyToFolder
            // 
            this.cmsFoldersCopyToFolder.Name = "cmsFoldersCopyToFolder";
            this.cmsFoldersCopyToFolder.Size = new System.Drawing.Size(370, 38);
            this.cmsFoldersCopyToFolder.Text = "Copy To Folder";
            this.cmsFoldersCopyToFolder.Click += new System.EventHandler(this.cmsFoldersCopyToFolder_Click);
            // 
            // cmsFoldersMoveToFolder
            // 
            this.cmsFoldersMoveToFolder.Name = "cmsFoldersMoveToFolder";
            this.cmsFoldersMoveToFolder.Size = new System.Drawing.Size(370, 38);
            this.cmsFoldersMoveToFolder.Text = "MoveTo Folder";
            this.cmsFoldersMoveToFolder.Click += new System.EventHandler(this.cmsFoldersMoveToFolder_Click);
            // 
            // cmsFoldersNewFolder
            // 
            this.cmsFoldersNewFolder.Name = "cmsFoldersNewFolder";
            this.cmsFoldersNewFolder.Size = new System.Drawing.Size(370, 38);
            this.cmsFoldersNewFolder.Text = "New Folder";
            this.cmsFoldersNewFolder.Click += new System.EventHandler(this.cmsFoldersNewFolder_Click);
            // 
            // cmsFoldersStoreProperties
            // 
            this.cmsFoldersStoreProperties.Name = "cmsFoldersStoreProperties";
            this.cmsFoldersStoreProperties.Size = new System.Drawing.Size(370, 38);
            this.cmsFoldersStoreProperties.Text = "Store Properties";
            this.cmsFoldersStoreProperties.Click += new System.EventHandler(this.cmsFoldersStoreProperties_Click);
            // 
            // cmsFolderAccountForFolder
            // 
            this.cmsFolderAccountForFolder.Name = "cmsFolderAccountForFolder";
            this.cmsFolderAccountForFolder.Size = new System.Drawing.Size(370, 38);
            this.cmsFolderAccountForFolder.Text = "Display Account for Folder";
            this.cmsFolderAccountForFolder.Click += new System.EventHandler(this.cmsFolderAccountForFolder_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.ContextMenuStrip = this.cmsItems;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 6);
            this.listView1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(952, 632);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // cmsItems
            // 
            this.cmsItems.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItemsProperties,
            this.cmsItemsCopyToFolder,
            this.cmsItemsMoveToFolder,
            this.cmsItemsRename,
            this.cmsItemsMoveAllItems,
            this.cmsItemsCopyAllItems,
            this.cmsItemsSaveToFile,
            this.cmsItemsOpen});
            this.cmsItems.Name = "cmsFolders";
            this.cmsItems.Size = new System.Drawing.Size(250, 308);
            this.cmsItems.Opening += new System.ComponentModel.CancelEventHandler(this.cmsItems_Opening);
            // 
            // cmsItemsProperties
            // 
            this.cmsItemsProperties.Name = "cmsItemsProperties";
            this.cmsItemsProperties.Size = new System.Drawing.Size(249, 38);
            this.cmsItemsProperties.Text = "Properties";
            this.cmsItemsProperties.Click += new System.EventHandler(this.cmsItemsProperties_Click);
            // 
            // cmsItemsCopyToFolder
            // 
            this.cmsItemsCopyToFolder.Enabled = false;
            this.cmsItemsCopyToFolder.Name = "cmsItemsCopyToFolder";
            this.cmsItemsCopyToFolder.Size = new System.Drawing.Size(249, 38);
            this.cmsItemsCopyToFolder.Text = "Copy To Folder";
            this.cmsItemsCopyToFolder.Visible = false;
            this.cmsItemsCopyToFolder.Click += new System.EventHandler(this.cmsItemsCopyToFolder_Click);
            // 
            // cmsItemsMoveToFolder
            // 
            this.cmsItemsMoveToFolder.Enabled = false;
            this.cmsItemsMoveToFolder.Name = "cmsItemsMoveToFolder";
            this.cmsItemsMoveToFolder.Size = new System.Drawing.Size(249, 38);
            this.cmsItemsMoveToFolder.Text = "MoveTo Folder";
            this.cmsItemsMoveToFolder.Visible = false;
            this.cmsItemsMoveToFolder.Click += new System.EventHandler(this.cmsItemsMoveToFolder_Click);
            // 
            // cmsItemsRename
            // 
            this.cmsItemsRename.Enabled = false;
            this.cmsItemsRename.Name = "cmsItemsRename";
            this.cmsItemsRename.Size = new System.Drawing.Size(249, 38);
            this.cmsItemsRename.Text = "Rename";
            this.cmsItemsRename.Visible = false;
            this.cmsItemsRename.Click += new System.EventHandler(this.cmsItemsRename_Click);
            // 
            // cmsItemsMoveAllItems
            // 
            this.cmsItemsMoveAllItems.Enabled = false;
            this.cmsItemsMoveAllItems.Name = "cmsItemsMoveAllItems";
            this.cmsItemsMoveAllItems.Size = new System.Drawing.Size(249, 38);
            this.cmsItemsMoveAllItems.Text = "Move Items";
            this.cmsItemsMoveAllItems.Visible = false;
            this.cmsItemsMoveAllItems.Click += new System.EventHandler(this.cmsItemsMoveAllItems_Click);
            // 
            // cmsItemsCopyAllItems
            // 
            this.cmsItemsCopyAllItems.Enabled = false;
            this.cmsItemsCopyAllItems.Name = "cmsItemsCopyAllItems";
            this.cmsItemsCopyAllItems.Size = new System.Drawing.Size(249, 38);
            this.cmsItemsCopyAllItems.Text = "Copy All Items";
            this.cmsItemsCopyAllItems.Visible = false;
            this.cmsItemsCopyAllItems.Click += new System.EventHandler(this.cmsItemsCopyAllItems_Click);
            // 
            // cmsItemsSaveToFile
            // 
            this.cmsItemsSaveToFile.Name = "cmsItemsSaveToFile";
            this.cmsItemsSaveToFile.Size = new System.Drawing.Size(249, 38);
            this.cmsItemsSaveToFile.Text = "Save To File";
            this.cmsItemsSaveToFile.Click += new System.EventHandler(this.cmsItemsSaveToFile_Click);
            // 
            // cmsItemsOpen
            // 
            this.cmsItemsOpen.Name = "cmsItemsOpen";
            this.cmsItemsOpen.Size = new System.Drawing.Size(249, 38);
            this.cmsItemsOpen.Text = "Open";
            this.cmsItemsOpen.Click += new System.EventHandler(this.cmsItemsOpen_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(24, 83);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvFolders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(1468, 647);
            this.splitContainer1.SplitterDistance = 482;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ContextMenuStrip = this.mnuMain;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 743);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1516, 34);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // mnuMain
            // 
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainAvailabilityInformation});
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(336, 42);
            // 
            // mnuMainAvailabilityInformation
            // 
            this.mnuMainAvailabilityInformation.Name = "mnuMainAvailabilityInformation";
            this.mnuMainAvailabilityInformation.Size = new System.Drawing.Size(335, 38);
            this.mnuMainAvailabilityInformation.Text = "Availability Information";
            this.mnuMainAvailabilityInformation.Click += new System.EventHandler(this.mnuMainAvailabilityInformation_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 22);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuInfo,
            this.mnuTools,
            this.newToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1516, 44);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(71, 36);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(359, 44);
            this.mnuFileExit.Text = "E&xit";
            // 
            // mnuInfo
            // 
            this.mnuInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInfoAccountInformation,
            this.mnuInfoExchUsers,
            this.frmInfoCategories,
            this.mnuInfoStores,
            this.mnuInfoAddressLists,
            this.mnuInfoHiddenItems,
            this.mnuInfoApplicationInformation});
            this.mnuInfo.Name = "mnuInfo";
            this.mnuInfo.Size = new System.Drawing.Size(76, 36);
            this.mnuInfo.Text = "&Info";
            // 
            // mnuInfoAccountInformation
            // 
            this.mnuInfoAccountInformation.Name = "mnuInfoAccountInformation";
            this.mnuInfoAccountInformation.Size = new System.Drawing.Size(399, 44);
            this.mnuInfoAccountInformation.Text = "&Account Information";
            this.mnuInfoAccountInformation.Click += new System.EventHandler(this.mnuInfoAccountInformation_Click);
            // 
            // mnuInfoExchUsers
            // 
            this.mnuInfoExchUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInfoExchUsersCurrentUser,
            this.mnuInfoExchUsersCurrentUserMemberOfDl});
            this.mnuInfoExchUsers.Name = "mnuInfoExchUsers";
            this.mnuInfoExchUsers.Size = new System.Drawing.Size(399, 44);
            this.mnuInfoExchUsers.Text = "Exchange Users";
            this.mnuInfoExchUsers.Click += new System.EventHandler(this.mnuInfoExchUsers_Click);
            // 
            // mnuInfoExchUsersCurrentUser
            // 
            this.mnuInfoExchUsersCurrentUser.Name = "mnuInfoExchUsersCurrentUser";
            this.mnuInfoExchUsersCurrentUser.Size = new System.Drawing.Size(458, 44);
            this.mnuInfoExchUsersCurrentUser.Text = "Current &User";
            this.mnuInfoExchUsersCurrentUser.Click += new System.EventHandler(this.mnuInfoExchUsersCurrentUser_Click);
            // 
            // mnuInfoExchUsersCurrentUserMemberOfDl
            // 
            this.mnuInfoExchUsersCurrentUserMemberOfDl.Name = "mnuInfoExchUsersCurrentUserMemberOfDl";
            this.mnuInfoExchUsersCurrentUserMemberOfDl.Size = new System.Drawing.Size(458, 44);
            this.mnuInfoExchUsersCurrentUserMemberOfDl.Text = "Current User DL Membership";
            this.mnuInfoExchUsersCurrentUserMemberOfDl.Click += new System.EventHandler(this.mnuInfoExchUsersCurrentUserMemberOfDl_Click);
            // 
            // frmInfoCategories
            // 
            this.frmInfoCategories.Name = "frmInfoCategories";
            this.frmInfoCategories.Size = new System.Drawing.Size(399, 44);
            this.frmInfoCategories.Text = "Categories";
            this.frmInfoCategories.Click += new System.EventHandler(this.frmInfoCategories_Click);
            // 
            // mnuInfoStores
            // 
            this.mnuInfoStores.Name = "mnuInfoStores";
            this.mnuInfoStores.Size = new System.Drawing.Size(399, 44);
            this.mnuInfoStores.Text = "Stores";
            this.mnuInfoStores.Click += new System.EventHandler(this.mnuInfoStores_Click);
            // 
            // mnuInfoAddressLists
            // 
            this.mnuInfoAddressLists.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInfoAddressListsForProfile,
            this.mnuInfoAddressListsEnumerateGal});
            this.mnuInfoAddressLists.Name = "mnuInfoAddressLists";
            this.mnuInfoAddressLists.Size = new System.Drawing.Size(399, 44);
            this.mnuInfoAddressLists.Text = "Address Lists";
            // 
            // mnuInfoAddressListsForProfile
            // 
            this.mnuInfoAddressListsForProfile.Name = "mnuInfoAddressListsForProfile";
            this.mnuInfoAddressListsForProfile.Size = new System.Drawing.Size(395, 44);
            this.mnuInfoAddressListsForProfile.Text = "Address Lists for Profile";
            this.mnuInfoAddressListsForProfile.Click += new System.EventHandler(this.mnuInfoAddressListsForProfile_Click);
            // 
            // mnuInfoAddressListsEnumerateGal
            // 
            this.mnuInfoAddressListsEnumerateGal.Name = "mnuInfoAddressListsEnumerateGal";
            this.mnuInfoAddressListsEnumerateGal.Size = new System.Drawing.Size(395, 44);
            this.mnuInfoAddressListsEnumerateGal.Text = "Enumerate GAL";
            this.mnuInfoAddressListsEnumerateGal.Click += new System.EventHandler(this.mnuInfoAddressListsEnumerateGal_Click);
            // 
            // mnuInfoHiddenItems
            // 
            this.mnuInfoHiddenItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInfoHiddenItemsCalendarWorkingHours});
            this.mnuInfoHiddenItems.Name = "mnuInfoHiddenItems";
            this.mnuInfoHiddenItems.Size = new System.Drawing.Size(399, 44);
            this.mnuInfoHiddenItems.Text = "Hidden Items";
            // 
            // mnuInfoHiddenItemsCalendarWorkingHours
            // 
            this.mnuInfoHiddenItemsCalendarWorkingHours.Name = "mnuInfoHiddenItemsCalendarWorkingHours";
            this.mnuInfoHiddenItemsCalendarWorkingHours.Size = new System.Drawing.Size(400, 44);
            this.mnuInfoHiddenItemsCalendarWorkingHours.Text = "Calendar WorkingHours";
            this.mnuInfoHiddenItemsCalendarWorkingHours.Click += new System.EventHandler(this.mnuInfoHiddenItemsCalendarWorkingHours_Click);
            // 
            // mnuInfoApplicationInformation
            // 
            this.mnuInfoApplicationInformation.Name = "mnuInfoApplicationInformation";
            this.mnuInfoApplicationInformation.Size = new System.Drawing.Size(399, 44);
            this.mnuInfoApplicationInformation.Text = "Application Information";
            this.mnuInfoApplicationInformation.Click += new System.EventHandler(this.mnuInfoApplicationInformation_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsSearch});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(89, 36);
            this.mnuTools.Text = "&Tools";
            // 
            // mnuToolsSearch
            // 
            this.mnuToolsSearch.Name = "mnuToolsSearch";
            this.mnuToolsSearch.Size = new System.Drawing.Size(359, 44);
            this.mnuToolsSearch.Text = "Search";
            this.mnuToolsSearch.Click += new System.EventHandler(this.mnuToolsSearch_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(82, 36);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.emailToolStripMenuItem.Text = "&Email";
            this.emailToolStripMenuItem.Click += new System.EventHandler(this.emailToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1516, 777);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Main";
            this.Text = "OOM Explore";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cmsFolders.ResumeLayout(false);
            this.cmsItems.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvFolders;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ContextMenuStrip cmsFolders;
        private System.Windows.Forms.ToolStripMenuItem cmsFoldersProperties;
        private System.Windows.Forms.ToolStripMenuItem cmsFoldersCopyToFolder;
        private System.Windows.Forms.ToolStripMenuItem cmsFoldersMoveToFolder;
        private System.Windows.Forms.ToolStripMenuItem cmsFoldersNewFolder;
        private System.Windows.Forms.ContextMenuStrip cmsItems;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsProperties;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsCopyToFolder;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsMoveToFolder;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsRename;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsMoveAllItems;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsCopyAllItems;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsSaveToFile;
        private System.Windows.Forms.ContextMenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuMainAvailabilityInformation;
        private System.Windows.Forms.ToolStripMenuItem cmsFoldersStoreProperties;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuInfoAccountInformation;
        private System.Windows.Forms.ToolStripMenuItem cmsFolderAccountForFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuInfoExchUsers;
        private System.Windows.Forms.ToolStripMenuItem mnuInfoExchUsersCurrentUser;
        private System.Windows.Forms.ToolStripMenuItem mnuInfoExchUsersCurrentUserMemberOfDl;
        private System.Windows.Forms.ToolStripMenuItem frmInfoCategories;
        private System.Windows.Forms.ToolStripMenuItem mnuInfoStores;
        private System.Windows.Forms.ToolStripMenuItem mnuInfoAddressLists;
        private System.Windows.Forms.ToolStripMenuItem mnuInfoAddressListsForProfile;
        private System.Windows.Forms.ToolStripMenuItem mnuInfoAddressListsEnumerateGal;
        private System.Windows.Forms.ToolStripMenuItem mnuInfoHiddenItems;
        private System.Windows.Forms.ToolStripMenuItem mnuInfoHiddenItemsCalendarWorkingHours;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuInfoApplicationInformation;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsSearch;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
    }
}


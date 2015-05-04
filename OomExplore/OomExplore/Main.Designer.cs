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
            this.cmsFoldersDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFoldersNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFoldersRenameFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFoldersMoveAllItems = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFoldersCopyAllIItems = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFoldersCopyMoveDeleteAllItems = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFoldersStoreProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFolderAccountForFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cmsItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsItemsProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsCopyToFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsMoveToFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsDelete = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnuInfoExchUsersManager = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tvFolders.Location = new System.Drawing.Point(3, 0);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.Size = new System.Drawing.Size(234, 280);
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
            this.cmsFoldersDelete,
            this.cmsFoldersNewFolder,
            this.cmsFoldersRenameFolder,
            this.cmsFoldersMoveAllItems,
            this.cmsFoldersCopyAllIItems,
            this.cmsFoldersCopyMoveDeleteAllItems,
            this.cmsFoldersStoreProperties,
            this.cmsFolderAccountForFolder});
            this.cmsFolders.Name = "cmsFolders";
            this.cmsFolders.Size = new System.Drawing.Size(215, 246);
            // 
            // cmsFoldersProperties
            // 
            this.cmsFoldersProperties.Name = "cmsFoldersProperties";
            this.cmsFoldersProperties.Size = new System.Drawing.Size(214, 22);
            this.cmsFoldersProperties.Text = "Properties";
            this.cmsFoldersProperties.Click += new System.EventHandler(this.cmsFoldersProperties_Click);
            // 
            // cmsFoldersCopyToFolder
            // 
            this.cmsFoldersCopyToFolder.Name = "cmsFoldersCopyToFolder";
            this.cmsFoldersCopyToFolder.Size = new System.Drawing.Size(214, 22);
            this.cmsFoldersCopyToFolder.Text = "Copy To Folder";
            this.cmsFoldersCopyToFolder.Click += new System.EventHandler(this.cmsFoldersCopyToFolder_Click);
            // 
            // cmsFoldersMoveToFolder
            // 
            this.cmsFoldersMoveToFolder.Name = "cmsFoldersMoveToFolder";
            this.cmsFoldersMoveToFolder.Size = new System.Drawing.Size(214, 22);
            this.cmsFoldersMoveToFolder.Text = "MoveTo Folder";
            this.cmsFoldersMoveToFolder.Click += new System.EventHandler(this.cmsFoldersMoveToFolder_Click);
            // 
            // cmsFoldersDelete
            // 
            this.cmsFoldersDelete.Enabled = false;
            this.cmsFoldersDelete.Name = "cmsFoldersDelete";
            this.cmsFoldersDelete.Size = new System.Drawing.Size(214, 22);
            this.cmsFoldersDelete.Text = "Delete";
            this.cmsFoldersDelete.Visible = false;
            this.cmsFoldersDelete.Click += new System.EventHandler(this.cmsFoldersDelete_Click);
            // 
            // cmsFoldersNewFolder
            // 
            this.cmsFoldersNewFolder.Name = "cmsFoldersNewFolder";
            this.cmsFoldersNewFolder.Size = new System.Drawing.Size(214, 22);
            this.cmsFoldersNewFolder.Text = "New Folder";
            this.cmsFoldersNewFolder.Click += new System.EventHandler(this.cmsFoldersNewFolder_Click);
            // 
            // cmsFoldersRenameFolder
            // 
            this.cmsFoldersRenameFolder.Enabled = false;
            this.cmsFoldersRenameFolder.Name = "cmsFoldersRenameFolder";
            this.cmsFoldersRenameFolder.Size = new System.Drawing.Size(214, 22);
            this.cmsFoldersRenameFolder.Text = "Rename Folder";
            this.cmsFoldersRenameFolder.Visible = false;
            this.cmsFoldersRenameFolder.Click += new System.EventHandler(this.cmsFoldersRenameFolder_Click);
            // 
            // cmsFoldersMoveAllItems
            // 
            this.cmsFoldersMoveAllItems.Enabled = false;
            this.cmsFoldersMoveAllItems.Name = "cmsFoldersMoveAllItems";
            this.cmsFoldersMoveAllItems.Size = new System.Drawing.Size(214, 22);
            this.cmsFoldersMoveAllItems.Text = "Move All Items";
            this.cmsFoldersMoveAllItems.Visible = false;
            this.cmsFoldersMoveAllItems.Click += new System.EventHandler(this.cmsFoldersMoveAllItems_Click);
            // 
            // cmsFoldersCopyAllIItems
            // 
            this.cmsFoldersCopyAllIItems.Enabled = false;
            this.cmsFoldersCopyAllIItems.Name = "cmsFoldersCopyAllIItems";
            this.cmsFoldersCopyAllIItems.Size = new System.Drawing.Size(214, 22);
            this.cmsFoldersCopyAllIItems.Text = "Copy All Items";
            this.cmsFoldersCopyAllIItems.Visible = false;
            this.cmsFoldersCopyAllIItems.Click += new System.EventHandler(this.cmsFoldersCopyAllIItems_Click);
            // 
            // cmsFoldersCopyMoveDeleteAllItems
            // 
            this.cmsFoldersCopyMoveDeleteAllItems.Enabled = false;
            this.cmsFoldersCopyMoveDeleteAllItems.Name = "cmsFoldersCopyMoveDeleteAllItems";
            this.cmsFoldersCopyMoveDeleteAllItems.Size = new System.Drawing.Size(214, 22);
            this.cmsFoldersCopyMoveDeleteAllItems.Text = "CopyMoveDelete All Items";
            this.cmsFoldersCopyMoveDeleteAllItems.Visible = false;
            this.cmsFoldersCopyMoveDeleteAllItems.Click += new System.EventHandler(this.cmsFoldersCopyMoveDeleteAllItems_Click);
            // 
            // cmsFoldersStoreProperties
            // 
            this.cmsFoldersStoreProperties.Name = "cmsFoldersStoreProperties";
            this.cmsFoldersStoreProperties.Size = new System.Drawing.Size(214, 22);
            this.cmsFoldersStoreProperties.Text = "Store Properties";
            this.cmsFoldersStoreProperties.Click += new System.EventHandler(this.cmsFoldersStoreProperties_Click);
            // 
            // cmsFolderAccountForFolder
            // 
            this.cmsFolderAccountForFolder.Name = "cmsFolderAccountForFolder";
            this.cmsFolderAccountForFolder.Size = new System.Drawing.Size(214, 22);
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
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(474, 277);
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
            this.cmsItemsDelete,
            this.cmsItemsRename,
            this.cmsItemsMoveAllItems,
            this.cmsItemsCopyAllItems,
            this.cmsItemsSaveToFile,
            this.cmsItemsOpen});
            this.cmsItems.Name = "cmsFolders";
            this.cmsItems.Size = new System.Drawing.Size(156, 224);
            this.cmsItems.Opening += new System.ComponentModel.CancelEventHandler(this.cmsItems_Opening);
            // 
            // cmsItemsProperties
            // 
            this.cmsItemsProperties.Name = "cmsItemsProperties";
            this.cmsItemsProperties.Size = new System.Drawing.Size(155, 22);
            this.cmsItemsProperties.Text = "Properties";
            this.cmsItemsProperties.Click += new System.EventHandler(this.cmsItemsProperties_Click);
            // 
            // cmsItemsCopyToFolder
            // 
            this.cmsItemsCopyToFolder.Enabled = false;
            this.cmsItemsCopyToFolder.Name = "cmsItemsCopyToFolder";
            this.cmsItemsCopyToFolder.Size = new System.Drawing.Size(155, 22);
            this.cmsItemsCopyToFolder.Text = "Copy To Folder";
            this.cmsItemsCopyToFolder.Visible = false;
            this.cmsItemsCopyToFolder.Click += new System.EventHandler(this.cmsItemsCopyToFolder_Click);
            // 
            // cmsItemsMoveToFolder
            // 
            this.cmsItemsMoveToFolder.Enabled = false;
            this.cmsItemsMoveToFolder.Name = "cmsItemsMoveToFolder";
            this.cmsItemsMoveToFolder.Size = new System.Drawing.Size(155, 22);
            this.cmsItemsMoveToFolder.Text = "MoveTo Folder";
            this.cmsItemsMoveToFolder.Visible = false;
            this.cmsItemsMoveToFolder.Click += new System.EventHandler(this.cmsItemsMoveToFolder_Click);
            // 
            // cmsItemsDelete
            // 
            this.cmsItemsDelete.Enabled = false;
            this.cmsItemsDelete.Name = "cmsItemsDelete";
            this.cmsItemsDelete.Size = new System.Drawing.Size(155, 22);
            this.cmsItemsDelete.Text = "Delete";
            this.cmsItemsDelete.Visible = false;
            this.cmsItemsDelete.Click += new System.EventHandler(this.cmsItemsDelete_Click);
            // 
            // cmsItemsRename
            // 
            this.cmsItemsRename.Enabled = false;
            this.cmsItemsRename.Name = "cmsItemsRename";
            this.cmsItemsRename.Size = new System.Drawing.Size(155, 22);
            this.cmsItemsRename.Text = "Rename";
            this.cmsItemsRename.Visible = false;
            this.cmsItemsRename.Click += new System.EventHandler(this.cmsItemsRename_Click);
            // 
            // cmsItemsMoveAllItems
            // 
            this.cmsItemsMoveAllItems.Enabled = false;
            this.cmsItemsMoveAllItems.Name = "cmsItemsMoveAllItems";
            this.cmsItemsMoveAllItems.Size = new System.Drawing.Size(155, 22);
            this.cmsItemsMoveAllItems.Text = "Move Items";
            this.cmsItemsMoveAllItems.Visible = false;
            this.cmsItemsMoveAllItems.Click += new System.EventHandler(this.cmsItemsMoveAllItems_Click);
            // 
            // cmsItemsCopyAllItems
            // 
            this.cmsItemsCopyAllItems.Enabled = false;
            this.cmsItemsCopyAllItems.Name = "cmsItemsCopyAllItems";
            this.cmsItemsCopyAllItems.Size = new System.Drawing.Size(155, 22);
            this.cmsItemsCopyAllItems.Text = "Copy All Items";
            this.cmsItemsCopyAllItems.Visible = false;
            this.cmsItemsCopyAllItems.Click += new System.EventHandler(this.cmsItemsCopyAllItems_Click);
            // 
            // cmsItemsSaveToFile
            // 
            this.cmsItemsSaveToFile.Name = "cmsItemsSaveToFile";
            this.cmsItemsSaveToFile.Size = new System.Drawing.Size(155, 22);
            this.cmsItemsSaveToFile.Text = "Save To File";
            this.cmsItemsSaveToFile.Click += new System.EventHandler(this.cmsItemsSaveToFile_Click);
            // 
            // cmsItemsOpen
            // 
            this.cmsItemsOpen.Name = "cmsItemsOpen";
            this.cmsItemsOpen.Size = new System.Drawing.Size(155, 22);
            this.cmsItemsOpen.Text = "Open";
            this.cmsItemsOpen.Click += new System.EventHandler(this.cmsItemsOpen_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 43);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvFolders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(728, 283);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ContextMenuStrip = this.mnuMain;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 354);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(752, 22);
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
            this.mnuMain.Size = new System.Drawing.Size(199, 26);
            // 
            // mnuMainAvailabilityInformation
            // 
            this.mnuMainAvailabilityInformation.Name = "mnuMainAvailabilityInformation";
            this.mnuMainAvailabilityInformation.Size = new System.Drawing.Size(198, 22);
            this.mnuMainAvailabilityInformation.Text = "Availability Information";
            this.mnuMainAvailabilityInformation.Click += new System.EventHandler(this.mnuMainAvailabilityInformation_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuInfo,
            this.mnuTools});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(92, 22);
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
            this.mnuInfo.Size = new System.Drawing.Size(40, 20);
            this.mnuInfo.Text = "&Info";
            // 
            // mnuInfoAccountInformation
            // 
            this.mnuInfoAccountInformation.Name = "mnuInfoAccountInformation";
            this.mnuInfoAccountInformation.Size = new System.Drawing.Size(201, 22);
            this.mnuInfoAccountInformation.Text = "&Account Information";
            this.mnuInfoAccountInformation.Click += new System.EventHandler(this.mnuInfoAccountInformation_Click);
            // 
            // mnuInfoExchUsers
            // 
            this.mnuInfoExchUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInfoExchUsersCurrentUser,
            this.mnuInfoExchUsersManager,
            this.mnuInfoExchUsersCurrentUserMemberOfDl});
            this.mnuInfoExchUsers.Name = "mnuInfoExchUsers";
            this.mnuInfoExchUsers.Size = new System.Drawing.Size(201, 22);
            this.mnuInfoExchUsers.Text = "Exchange Users";
            this.mnuInfoExchUsers.Click += new System.EventHandler(this.mnuInfoExchUsers_Click);
            // 
            // mnuInfoExchUsersCurrentUser
            // 
            this.mnuInfoExchUsersCurrentUser.Name = "mnuInfoExchUsersCurrentUser";
            this.mnuInfoExchUsersCurrentUser.Size = new System.Drawing.Size(227, 22);
            this.mnuInfoExchUsersCurrentUser.Text = "Current &User";
            this.mnuInfoExchUsersCurrentUser.Click += new System.EventHandler(this.mnuInfoExchUsersCurrentUser_Click);
            // 
            // mnuInfoExchUsersManager
            // 
            this.mnuInfoExchUsersManager.Name = "mnuInfoExchUsersManager";
            this.mnuInfoExchUsersManager.Size = new System.Drawing.Size(227, 22);
            this.mnuInfoExchUsersManager.Text = "User\'s Manager";
            this.mnuInfoExchUsersManager.Click += new System.EventHandler(this.mnuInfoExchUsersManager_Click);
            // 
            // mnuInfoExchUsersCurrentUserMemberOfDl
            // 
            this.mnuInfoExchUsersCurrentUserMemberOfDl.Name = "mnuInfoExchUsersCurrentUserMemberOfDl";
            this.mnuInfoExchUsersCurrentUserMemberOfDl.Size = new System.Drawing.Size(227, 22);
            this.mnuInfoExchUsersCurrentUserMemberOfDl.Text = "Current User DL Membership";
            this.mnuInfoExchUsersCurrentUserMemberOfDl.Click += new System.EventHandler(this.mnuInfoExchUsersCurrentUserMemberOfDl_Click);
            // 
            // frmInfoCategories
            // 
            this.frmInfoCategories.Name = "frmInfoCategories";
            this.frmInfoCategories.Size = new System.Drawing.Size(201, 22);
            this.frmInfoCategories.Text = "Categories";
            this.frmInfoCategories.Click += new System.EventHandler(this.frmInfoCategories_Click);
            // 
            // mnuInfoStores
            // 
            this.mnuInfoStores.Name = "mnuInfoStores";
            this.mnuInfoStores.Size = new System.Drawing.Size(201, 22);
            this.mnuInfoStores.Text = "Stores";
            this.mnuInfoStores.Click += new System.EventHandler(this.mnuInfoStores_Click);
            // 
            // mnuInfoAddressLists
            // 
            this.mnuInfoAddressLists.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInfoAddressListsForProfile,
            this.mnuInfoAddressListsEnumerateGal});
            this.mnuInfoAddressLists.Name = "mnuInfoAddressLists";
            this.mnuInfoAddressLists.Size = new System.Drawing.Size(201, 22);
            this.mnuInfoAddressLists.Text = "Address Lists";
            // 
            // mnuInfoAddressListsForProfile
            // 
            this.mnuInfoAddressListsForProfile.Name = "mnuInfoAddressListsForProfile";
            this.mnuInfoAddressListsForProfile.Size = new System.Drawing.Size(197, 22);
            this.mnuInfoAddressListsForProfile.Text = "Address Lists for Profile";
            this.mnuInfoAddressListsForProfile.Click += new System.EventHandler(this.mnuInfoAddressListsForProfile_Click);
            // 
            // mnuInfoAddressListsEnumerateGal
            // 
            this.mnuInfoAddressListsEnumerateGal.Name = "mnuInfoAddressListsEnumerateGal";
            this.mnuInfoAddressListsEnumerateGal.Size = new System.Drawing.Size(197, 22);
            this.mnuInfoAddressListsEnumerateGal.Text = "Enumerate GAL";
            this.mnuInfoAddressListsEnumerateGal.Click += new System.EventHandler(this.mnuInfoAddressListsEnumerateGal_Click);
            // 
            // mnuInfoHiddenItems
            // 
            this.mnuInfoHiddenItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInfoHiddenItemsCalendarWorkingHours});
            this.mnuInfoHiddenItems.Name = "mnuInfoHiddenItems";
            this.mnuInfoHiddenItems.Size = new System.Drawing.Size(201, 22);
            this.mnuInfoHiddenItems.Text = "Hidden Items";
            // 
            // mnuInfoHiddenItemsCalendarWorkingHours
            // 
            this.mnuInfoHiddenItemsCalendarWorkingHours.Name = "mnuInfoHiddenItemsCalendarWorkingHours";
            this.mnuInfoHiddenItemsCalendarWorkingHours.Size = new System.Drawing.Size(201, 22);
            this.mnuInfoHiddenItemsCalendarWorkingHours.Text = "Calendar WorkingHours";
            this.mnuInfoHiddenItemsCalendarWorkingHours.Click += new System.EventHandler(this.mnuInfoHiddenItemsCalendarWorkingHours_Click);
            // 
            // mnuInfoApplicationInformation
            // 
            this.mnuInfoApplicationInformation.Name = "mnuInfoApplicationInformation";
            this.mnuInfoApplicationInformation.Size = new System.Drawing.Size(201, 22);
            this.mnuInfoApplicationInformation.Text = "Application Information";
            this.mnuInfoApplicationInformation.Click += new System.EventHandler(this.mnuInfoApplicationInformation_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsSearch});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(48, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuToolsSearch
            // 
            this.mnuToolsSearch.Name = "mnuToolsSearch";
            this.mnuToolsSearch.Size = new System.Drawing.Size(109, 22);
            this.mnuToolsSearch.Text = "Search";
            this.mnuToolsSearch.Click += new System.EventHandler(this.mnuToolsSearch_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 376);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
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
        private System.Windows.Forms.ToolStripMenuItem cmsFoldersDelete;
        private System.Windows.Forms.ToolStripMenuItem cmsFoldersNewFolder;
        private System.Windows.Forms.ToolStripMenuItem cmsFoldersRenameFolder;
        private System.Windows.Forms.ContextMenuStrip cmsItems;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsProperties;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsCopyToFolder;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsMoveToFolder;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsDelete;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsRename;
        private System.Windows.Forms.ToolStripMenuItem cmsFoldersMoveAllItems;
        private System.Windows.Forms.ToolStripMenuItem cmsFoldersCopyAllIItems;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsMoveAllItems;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsCopyAllItems;
        private System.Windows.Forms.ToolStripMenuItem cmsFoldersCopyMoveDeleteAllItems;
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
        private System.Windows.Forms.ToolStripMenuItem mnuInfoExchUsersManager;
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
    }
}


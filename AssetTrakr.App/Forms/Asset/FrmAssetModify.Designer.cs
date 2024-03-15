namespace AssetTrakr.App.Forms.Asset
{
    partial class FrmAssetModify
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAssetModify));
            tabControl1 = new TabControl();
            tabInformation = new TabPage();
            lblType = new Label();
            cmbAssetType = new ComboBox();
            lnkModifyOS = new LinkLabel();
            lnkAddOS = new LinkLabel();
            cmbOperatingSystems = new ComboBox();
            txtOrderRef = new TextBox();
            lblOrderRef = new Label();
            lnkModifyContract = new LinkLabel();
            lnkAddContract = new LinkLabel();
            lblContract = new Label();
            cmbContracts = new ComboBox();
            lnkAddPlatform = new LinkLabel();
            lblPlatform = new Label();
            cmbPlatforms = new ComboBox();
            lblOperatingSystem = new Label();
            txtModel = new TextBox();
            lblModel = new Label();
            lnkAddManufacturer = new LinkLabel();
            gbInfoContact = new GroupBox();
            txtInfoContactEmail = new TextBox();
            lblInfoContactEmail = new Label();
            txtInfoContactName = new TextBox();
            lblInfoContactName = new Label();
            txtLicenseKey = new TextBox();
            lblLicenseKey = new Label();
            lblPurchaseCost = new Label();
            numCost = new NumericUpDown();
            cmbManufacturers = new ComboBox();
            lblManufacturer = new Label();
            txtName = new TextBox();
            lblName = new Label();
            lblPurchaseDate = new Label();
            dtPurchaseDate = new DateTimePicker();
            tabHardware = new TabPage();
            btnAddHardDrive = new Button();
            btnAddNetworkAdapter = new Button();
            lblHardDrives = new Label();
            dgvHardDrives = new DataGridView();
            cmsDgvRightClick = new ContextMenuStrip(components);
            columnSelectorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            lblNetworkAdapters = new Label();
            dgvNetworkAdapters = new DataGridView();
            txtBiosSerialNumber = new TextBox();
            lblBiosSerialNumber = new Label();
            lblRamSticks = new Label();
            numRamSticks = new NumericUpDown();
            lblRamSizeInGB = new Label();
            numRamSizeInGB = new NumericUpDown();
            txtProcessor = new TextBox();
            lblProcessor = new Label();
            tabWarranty = new TabPage();
            btnAddWarranty = new Button();
            dgvWarrantyPeriods = new DataGridView();
            cbHasWarranty = new CheckBox();
            tabAttachments = new TabPage();
            dgvAttachments = new DataGridView();
            btnAddAttachment = new Button();
            tabNotes = new TabPage();
            txtDescription = new TextBox();
            btnAddUpdate = new Button();
            tabControl1.SuspendLayout();
            tabInformation.SuspendLayout();
            gbInfoContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
            tabHardware.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHardDrives).BeginInit();
            cmsDgvRightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNetworkAdapters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRamSticks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRamSizeInGB).BeginInit();
            tabWarranty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWarrantyPeriods).BeginInit();
            tabAttachments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttachments).BeginInit();
            tabNotes.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabInformation);
            tabControl1.Controls.Add(tabHardware);
            tabControl1.Controls.Add(tabWarranty);
            tabControl1.Controls.Add(tabAttachments);
            tabControl1.Controls.Add(tabNotes);
            tabControl1.Location = new Point(20, 20);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(955, 570);
            tabControl1.TabIndex = 0;
            // 
            // tabInformation
            // 
            tabInformation.Controls.Add(lblType);
            tabInformation.Controls.Add(cmbAssetType);
            tabInformation.Controls.Add(lnkModifyOS);
            tabInformation.Controls.Add(lnkAddOS);
            tabInformation.Controls.Add(cmbOperatingSystems);
            tabInformation.Controls.Add(txtOrderRef);
            tabInformation.Controls.Add(lblOrderRef);
            tabInformation.Controls.Add(lnkModifyContract);
            tabInformation.Controls.Add(lnkAddContract);
            tabInformation.Controls.Add(lblContract);
            tabInformation.Controls.Add(cmbContracts);
            tabInformation.Controls.Add(lnkAddPlatform);
            tabInformation.Controls.Add(lblPlatform);
            tabInformation.Controls.Add(cmbPlatforms);
            tabInformation.Controls.Add(lblOperatingSystem);
            tabInformation.Controls.Add(txtModel);
            tabInformation.Controls.Add(lblModel);
            tabInformation.Controls.Add(lnkAddManufacturer);
            tabInformation.Controls.Add(gbInfoContact);
            tabInformation.Controls.Add(txtLicenseKey);
            tabInformation.Controls.Add(lblLicenseKey);
            tabInformation.Controls.Add(lblPurchaseCost);
            tabInformation.Controls.Add(numCost);
            tabInformation.Controls.Add(cmbManufacturers);
            tabInformation.Controls.Add(lblManufacturer);
            tabInformation.Controls.Add(txtName);
            tabInformation.Controls.Add(lblName);
            tabInformation.Controls.Add(lblPurchaseDate);
            tabInformation.Controls.Add(dtPurchaseDate);
            tabInformation.Location = new Point(4, 29);
            tabInformation.Name = "tabInformation";
            tabInformation.Padding = new Padding(3);
            tabInformation.Size = new Size(947, 537);
            tabInformation.TabIndex = 0;
            tabInformation.Text = "Information";
            tabInformation.UseVisualStyleBackColor = true;
            // 
            // lblType
            // 
            lblType.Location = new Point(440, 194);
            lblType.Name = "lblType";
            lblType.Size = new Size(65, 20);
            lblType.TabIndex = 57;
            lblType.Text = "Type";
            lblType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbAssetType
            // 
            cmbAssetType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssetType.FormattingEnabled = true;
            cmbAssetType.Items.AddRange(new object[] { "Laptop", "Desktop", "Server", "Mobile", "Tablet", "Monitor", "Peripherals", "Other" });
            cmbAssetType.Location = new Point(511, 191);
            cmbAssetType.Name = "cmbAssetType";
            cmbAssetType.Size = new Size(235, 28);
            cmbAssetType.TabIndex = 56;
            // 
            // lnkModifyOS
            // 
            lnkModifyOS.AutoSize = true;
            lnkModifyOS.Location = new Point(795, 113);
            lnkModifyOS.Name = "lnkModifyOS";
            lnkModifyOS.Size = new Size(56, 20);
            lnkModifyOS.TabIndex = 55;
            lnkModifyOS.TabStop = true;
            lnkModifyOS.Text = "Modify";
            lnkModifyOS.Visible = false;
            lnkModifyOS.LinkClicked += lnkModifyOS_LinkClicked;
            // 
            // lnkAddOS
            // 
            lnkAddOS.AutoSize = true;
            lnkAddOS.Location = new Point(752, 113);
            lnkAddOS.Name = "lnkAddOS";
            lnkAddOS.Size = new Size(37, 20);
            lnkAddOS.TabIndex = 54;
            lnkAddOS.TabStop = true;
            lnkAddOS.Text = "Add";
            lnkAddOS.LinkClicked += lnkAddOS_LinkClicked;
            // 
            // cmbOperatingSystems
            // 
            cmbOperatingSystems.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOperatingSystems.FormattingEnabled = true;
            cmbOperatingSystems.Location = new Point(511, 110);
            cmbOperatingSystems.Name = "cmbOperatingSystems";
            cmbOperatingSystems.Size = new Size(235, 28);
            cmbOperatingSystems.TabIndex = 53;
            cmbOperatingSystems.SelectedIndexChanged += cmbOperatingSystems_SelectedIndexChanged;
            // 
            // txtOrderRef
            // 
            txtOrderRef.Location = new Point(511, 67);
            txtOrderRef.Name = "txtOrderRef";
            txtOrderRef.Size = new Size(235, 27);
            txtOrderRef.TabIndex = 52;
            // 
            // lblOrderRef
            // 
            lblOrderRef.Location = new Point(402, 72);
            lblOrderRef.Name = "lblOrderRef";
            lblOrderRef.Size = new Size(103, 20);
            lblOrderRef.TabIndex = 51;
            lblOrderRef.Text = "Order Ref.";
            lblOrderRef.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lnkModifyContract
            // 
            lnkModifyContract.AutoSize = true;
            lnkModifyContract.Location = new Point(795, 155);
            lnkModifyContract.Name = "lnkModifyContract";
            lnkModifyContract.Size = new Size(56, 20);
            lnkModifyContract.TabIndex = 50;
            lnkModifyContract.TabStop = true;
            lnkModifyContract.Text = "Modify";
            lnkModifyContract.Visible = false;
            lnkModifyContract.LinkClicked += lnkModifyContract_LinkClicked;
            // 
            // lnkAddContract
            // 
            lnkAddContract.AutoSize = true;
            lnkAddContract.Location = new Point(752, 155);
            lnkAddContract.Name = "lnkAddContract";
            lnkAddContract.Size = new Size(37, 20);
            lnkAddContract.TabIndex = 49;
            lnkAddContract.TabStop = true;
            lnkAddContract.Text = "Add";
            lnkAddContract.LinkClicked += lnkAddContract_LinkClicked;
            // 
            // lblContract
            // 
            lblContract.Location = new Point(402, 155);
            lblContract.Name = "lblContract";
            lblContract.Size = new Size(103, 20);
            lblContract.TabIndex = 48;
            lblContract.Text = "Contract";
            lblContract.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbContracts
            // 
            cmbContracts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbContracts.FormattingEnabled = true;
            cmbContracts.Location = new Point(511, 152);
            cmbContracts.Name = "cmbContracts";
            cmbContracts.Size = new Size(235, 28);
            cmbContracts.TabIndex = 47;
            cmbContracts.SelectedIndexChanged += cmbContracts_SelectedIndexChanged;
            // 
            // lnkAddPlatform
            // 
            lnkAddPlatform.AutoSize = true;
            lnkAddPlatform.Location = new Point(371, 239);
            lnkAddPlatform.Name = "lnkAddPlatform";
            lnkAddPlatform.Size = new Size(63, 20);
            lnkAddPlatform.TabIndex = 46;
            lnkAddPlatform.TabStop = true;
            lnkAddPlatform.Text = "Manage";
            lnkAddPlatform.LinkClicked += lnkAddPlatform_LinkClicked;
            // 
            // lblPlatform
            // 
            lblPlatform.Location = new Point(21, 239);
            lblPlatform.Name = "lblPlatform";
            lblPlatform.Size = new Size(103, 20);
            lblPlatform.TabIndex = 45;
            lblPlatform.Text = "Platform";
            lblPlatform.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbPlatforms
            // 
            cmbPlatforms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlatforms.FormattingEnabled = true;
            cmbPlatforms.Location = new Point(130, 236);
            cmbPlatforms.Name = "cmbPlatforms";
            cmbPlatforms.Size = new Size(235, 28);
            cmbPlatforms.TabIndex = 44;
            // 
            // lblOperatingSystem
            // 
            lblOperatingSystem.Location = new Point(371, 112);
            lblOperatingSystem.Name = "lblOperatingSystem";
            lblOperatingSystem.Size = new Size(134, 20);
            lblOperatingSystem.TabIndex = 43;
            lblOperatingSystem.Text = "Operating System";
            lblOperatingSystem.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(130, 153);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(235, 27);
            txtModel.TabIndex = 41;
            // 
            // lblModel
            // 
            lblModel.Location = new Point(21, 155);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(103, 20);
            lblModel.TabIndex = 39;
            lblModel.Text = "Model";
            lblModel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lnkAddManufacturer
            // 
            lnkAddManufacturer.AutoSize = true;
            lnkAddManufacturer.Location = new Point(371, 199);
            lnkAddManufacturer.Name = "lnkAddManufacturer";
            lnkAddManufacturer.Size = new Size(63, 20);
            lnkAddManufacturer.TabIndex = 40;
            lnkAddManufacturer.TabStop = true;
            lnkAddManufacturer.Text = "Manage";
            lnkAddManufacturer.LinkClicked += lnkAddManufacturer_LinkClicked;
            // 
            // gbInfoContact
            // 
            gbInfoContact.Controls.Add(txtInfoContactEmail);
            gbInfoContact.Controls.Add(lblInfoContactEmail);
            gbInfoContact.Controls.Add(txtInfoContactName);
            gbInfoContact.Controls.Add(lblInfoContactName);
            gbInfoContact.Location = new Point(21, 422);
            gbInfoContact.Name = "gbInfoContact";
            gbInfoContact.Size = new Size(907, 77);
            gbInfoContact.TabIndex = 38;
            gbInfoContact.TabStop = false;
            gbInfoContact.Text = "Registered Information";
            // 
            // txtInfoContactEmail
            // 
            txtInfoContactEmail.Location = new Point(597, 27);
            txtInfoContactEmail.Name = "txtInfoContactEmail";
            txtInfoContactEmail.Size = new Size(274, 27);
            txtInfoContactEmail.TabIndex = 3;
            // 
            // lblInfoContactEmail
            // 
            lblInfoContactEmail.AutoSize = true;
            lblInfoContactEmail.Location = new Point(470, 30);
            lblInfoContactEmail.Name = "lblInfoContactEmail";
            lblInfoContactEmail.Size = new Size(121, 20);
            lblInfoContactEmail.TabIndex = 2;
            lblInfoContactEmail.Text = "Registered Email";
            // 
            // txtInfoContactName
            // 
            txtInfoContactName.Location = new Point(139, 26);
            txtInfoContactName.Name = "txtInfoContactName";
            txtInfoContactName.Size = new Size(274, 27);
            txtInfoContactName.TabIndex = 1;
            // 
            // lblInfoContactName
            // 
            lblInfoContactName.AutoSize = true;
            lblInfoContactName.Location = new Point(20, 30);
            lblInfoContactName.Name = "lblInfoContactName";
            lblInfoContactName.Size = new Size(113, 20);
            lblInfoContactName.TabIndex = 0;
            lblInfoContactName.Text = "Registered User";
            // 
            // txtLicenseKey
            // 
            txtLicenseKey.Location = new Point(511, 27);
            txtLicenseKey.Name = "txtLicenseKey";
            txtLicenseKey.Size = new Size(235, 27);
            txtLicenseKey.TabIndex = 37;
            // 
            // lblLicenseKey
            // 
            lblLicenseKey.Location = new Point(402, 27);
            lblLicenseKey.Name = "lblLicenseKey";
            lblLicenseKey.Size = new Size(103, 20);
            lblLicenseKey.TabIndex = 36;
            lblLicenseKey.Text = "License Key";
            lblLicenseKey.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPurchaseCost
            // 
            lblPurchaseCost.Location = new Point(21, 112);
            lblPurchaseCost.Name = "lblPurchaseCost";
            lblPurchaseCost.Size = new Size(103, 20);
            lblPurchaseCost.TabIndex = 35;
            lblPurchaseCost.Text = "Price";
            lblPurchaseCost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numCost
            // 
            numCost.Location = new Point(130, 110);
            numCost.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numCost.Name = "numCost";
            numCost.Size = new Size(235, 27);
            numCost.TabIndex = 34;
            // 
            // cmbManufacturers
            // 
            cmbManufacturers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbManufacturers.FormattingEnabled = true;
            cmbManufacturers.Location = new Point(130, 196);
            cmbManufacturers.Name = "cmbManufacturers";
            cmbManufacturers.Size = new Size(235, 28);
            cmbManufacturers.TabIndex = 33;
            // 
            // lblManufacturer
            // 
            lblManufacturer.Location = new Point(21, 199);
            lblManufacturer.Name = "lblManufacturer";
            lblManufacturer.Size = new Size(103, 20);
            lblManufacturer.TabIndex = 32;
            lblManufacturer.Text = "Manufacturer";
            lblManufacturer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 24);
            txtName.Name = "txtName";
            txtName.Size = new Size(235, 27);
            txtName.TabIndex = 27;
            // 
            // lblName
            // 
            lblName.Location = new Point(21, 27);
            lblName.Name = "lblName";
            lblName.Size = new Size(103, 20);
            lblName.TabIndex = 26;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPurchaseDate
            // 
            lblPurchaseDate.Location = new Point(21, 72);
            lblPurchaseDate.Name = "lblPurchaseDate";
            lblPurchaseDate.Size = new Size(103, 20);
            lblPurchaseDate.TabIndex = 30;
            lblPurchaseDate.Text = "Purchase Date";
            lblPurchaseDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtPurchaseDate
            // 
            dtPurchaseDate.Location = new Point(130, 67);
            dtPurchaseDate.MinDate = new DateTime(1975, 1, 1, 0, 0, 0, 0);
            dtPurchaseDate.Name = "dtPurchaseDate";
            dtPurchaseDate.Size = new Size(235, 27);
            dtPurchaseDate.TabIndex = 31;
            // 
            // tabHardware
            // 
            tabHardware.Controls.Add(btnAddHardDrive);
            tabHardware.Controls.Add(btnAddNetworkAdapter);
            tabHardware.Controls.Add(lblHardDrives);
            tabHardware.Controls.Add(dgvHardDrives);
            tabHardware.Controls.Add(lblNetworkAdapters);
            tabHardware.Controls.Add(dgvNetworkAdapters);
            tabHardware.Controls.Add(txtBiosSerialNumber);
            tabHardware.Controls.Add(lblBiosSerialNumber);
            tabHardware.Controls.Add(lblRamSticks);
            tabHardware.Controls.Add(numRamSticks);
            tabHardware.Controls.Add(lblRamSizeInGB);
            tabHardware.Controls.Add(numRamSizeInGB);
            tabHardware.Controls.Add(txtProcessor);
            tabHardware.Controls.Add(lblProcessor);
            tabHardware.Location = new Point(4, 29);
            tabHardware.Name = "tabHardware";
            tabHardware.Padding = new Padding(3);
            tabHardware.Size = new Size(947, 537);
            tabHardware.TabIndex = 1;
            tabHardware.Text = "Hardware";
            tabHardware.UseVisualStyleBackColor = true;
            // 
            // btnAddHardDrive
            // 
            btnAddHardDrive.Location = new Point(814, 328);
            btnAddHardDrive.Name = "btnAddHardDrive";
            btnAddHardDrive.Size = new Size(109, 29);
            btnAddHardDrive.TabIndex = 24;
            btnAddHardDrive.Text = "Add Drive";
            btnAddHardDrive.UseVisualStyleBackColor = true;
            btnAddHardDrive.Click += btnAddHardDrive_Click;
            // 
            // btnAddNetworkAdapter
            // 
            btnAddNetworkAdapter.Location = new Point(814, 146);
            btnAddNetworkAdapter.Name = "btnAddNetworkAdapter";
            btnAddNetworkAdapter.Size = new Size(109, 29);
            btnAddNetworkAdapter.TabIndex = 23;
            btnAddNetworkAdapter.Text = "Add Adapter";
            btnAddNetworkAdapter.UseVisualStyleBackColor = true;
            btnAddNetworkAdapter.Click += btnAddNetworkAdapter_Click;
            // 
            // lblHardDrives
            // 
            lblHardDrives.Location = new Point(21, 336);
            lblHardDrives.Name = "lblHardDrives";
            lblHardDrives.Size = new Size(134, 20);
            lblHardDrives.TabIndex = 22;
            lblHardDrives.Text = "Hard Drives";
            lblHardDrives.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvHardDrives
            // 
            dgvHardDrives.AllowUserToAddRows = false;
            dgvHardDrives.AllowUserToDeleteRows = false;
            dgvHardDrives.AllowUserToResizeColumns = false;
            dgvHardDrives.AllowUserToResizeRows = false;
            dgvHardDrives.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHardDrives.BackgroundColor = Color.White;
            dgvHardDrives.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHardDrives.ContextMenuStrip = cmsDgvRightClick;
            dgvHardDrives.Location = new Point(21, 363);
            dgvHardDrives.MultiSelect = false;
            dgvHardDrives.Name = "dgvHardDrives";
            dgvHardDrives.ReadOnly = true;
            dgvHardDrives.RowHeadersVisible = false;
            dgvHardDrives.RowHeadersWidth = 51;
            dgvHardDrives.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvHardDrives.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHardDrives.ShowCellErrors = false;
            dgvHardDrives.ShowCellToolTips = false;
            dgvHardDrives.ShowEditingIcon = false;
            dgvHardDrives.ShowRowErrors = false;
            dgvHardDrives.Size = new Size(902, 140);
            dgvHardDrives.TabIndex = 21;
            // 
            // cmsDgvRightClick
            // 
            cmsDgvRightClick.ImageScalingSize = new Size(20, 20);
            cmsDgvRightClick.Items.AddRange(new ToolStripItem[] { columnSelectorToolStripMenuItem, toolStripSeparator1, deleteToolStripMenuItem });
            cmsDgvRightClick.Name = "contextMenuStrip1";
            cmsDgvRightClick.Size = new Size(188, 58);
            // 
            // columnSelectorToolStripMenuItem
            // 
            columnSelectorToolStripMenuItem.Name = "columnSelectorToolStripMenuItem";
            columnSelectorToolStripMenuItem.Size = new Size(187, 24);
            columnSelectorToolStripMenuItem.Text = "Column Selector";
            columnSelectorToolStripMenuItem.Click += columnSelectorToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(184, 6);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(187, 24);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // lblNetworkAdapters
            // 
            lblNetworkAdapters.Location = new Point(21, 155);
            lblNetworkAdapters.Name = "lblNetworkAdapters";
            lblNetworkAdapters.Size = new Size(134, 20);
            lblNetworkAdapters.TabIndex = 20;
            lblNetworkAdapters.Text = "Network Adapters";
            lblNetworkAdapters.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvNetworkAdapters
            // 
            dgvNetworkAdapters.AllowUserToAddRows = false;
            dgvNetworkAdapters.AllowUserToDeleteRows = false;
            dgvNetworkAdapters.AllowUserToResizeColumns = false;
            dgvNetworkAdapters.AllowUserToResizeRows = false;
            dgvNetworkAdapters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNetworkAdapters.BackgroundColor = Color.White;
            dgvNetworkAdapters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNetworkAdapters.ContextMenuStrip = cmsDgvRightClick;
            dgvNetworkAdapters.Location = new Point(21, 182);
            dgvNetworkAdapters.MultiSelect = false;
            dgvNetworkAdapters.Name = "dgvNetworkAdapters";
            dgvNetworkAdapters.ReadOnly = true;
            dgvNetworkAdapters.RowHeadersVisible = false;
            dgvNetworkAdapters.RowHeadersWidth = 51;
            dgvNetworkAdapters.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvNetworkAdapters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNetworkAdapters.ShowCellErrors = false;
            dgvNetworkAdapters.ShowCellToolTips = false;
            dgvNetworkAdapters.ShowEditingIcon = false;
            dgvNetworkAdapters.ShowRowErrors = false;
            dgvNetworkAdapters.Size = new Size(902, 140);
            dgvNetworkAdapters.TabIndex = 19;
            // 
            // txtBiosSerialNumber
            // 
            txtBiosSerialNumber.Location = new Point(539, 24);
            txtBiosSerialNumber.Name = "txtBiosSerialNumber";
            txtBiosSerialNumber.Size = new Size(235, 27);
            txtBiosSerialNumber.TabIndex = 18;
            // 
            // lblBiosSerialNumber
            // 
            lblBiosSerialNumber.Location = new Point(382, 27);
            lblBiosSerialNumber.Name = "lblBiosSerialNumber";
            lblBiosSerialNumber.Size = new Size(151, 20);
            lblBiosSerialNumber.TabIndex = 17;
            lblBiosSerialNumber.Text = "Bios Serial Number";
            lblBiosSerialNumber.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblRamSticks
            // 
            lblRamSticks.Location = new Point(21, 112);
            lblRamSticks.Name = "lblRamSticks";
            lblRamSticks.Size = new Size(103, 20);
            lblRamSticks.TabIndex = 15;
            lblRamSticks.Text = "RAM Sticks";
            lblRamSticks.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numRamSticks
            // 
            numRamSticks.Location = new Point(130, 110);
            numRamSticks.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numRamSticks.Name = "numRamSticks";
            numRamSticks.Size = new Size(235, 27);
            numRamSticks.TabIndex = 14;
            // 
            // lblRamSizeInGB
            // 
            lblRamSizeInGB.Location = new Point(21, 72);
            lblRamSizeInGB.Name = "lblRamSizeInGB";
            lblRamSizeInGB.Size = new Size(103, 20);
            lblRamSizeInGB.TabIndex = 13;
            lblRamSizeInGB.Text = "RAM (GB)";
            lblRamSizeInGB.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numRamSizeInGB
            // 
            numRamSizeInGB.Location = new Point(130, 67);
            numRamSizeInGB.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numRamSizeInGB.Name = "numRamSizeInGB";
            numRamSizeInGB.Size = new Size(235, 27);
            numRamSizeInGB.TabIndex = 12;
            // 
            // txtProcessor
            // 
            txtProcessor.Location = new Point(130, 24);
            txtProcessor.Name = "txtProcessor";
            txtProcessor.Size = new Size(235, 27);
            txtProcessor.TabIndex = 3;
            // 
            // lblProcessor
            // 
            lblProcessor.Location = new Point(21, 27);
            lblProcessor.Name = "lblProcessor";
            lblProcessor.Size = new Size(103, 20);
            lblProcessor.TabIndex = 2;
            lblProcessor.Text = "Processor";
            lblProcessor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabWarranty
            // 
            tabWarranty.Controls.Add(btnAddWarranty);
            tabWarranty.Controls.Add(dgvWarrantyPeriods);
            tabWarranty.Controls.Add(cbHasWarranty);
            tabWarranty.Location = new Point(4, 29);
            tabWarranty.Name = "tabWarranty";
            tabWarranty.Size = new Size(947, 537);
            tabWarranty.TabIndex = 2;
            tabWarranty.Text = "Warranty";
            tabWarranty.UseVisualStyleBackColor = true;
            // 
            // btnAddWarranty
            // 
            btnAddWarranty.Enabled = false;
            btnAddWarranty.Location = new Point(787, 20);
            btnAddWarranty.Name = "btnAddWarranty";
            btnAddWarranty.Size = new Size(138, 29);
            btnAddWarranty.TabIndex = 18;
            btnAddWarranty.Text = "Add Warranty";
            btnAddWarranty.UseVisualStyleBackColor = true;
            btnAddWarranty.Click += btnAddWarranty_Click;
            // 
            // dgvWarrantyPeriods
            // 
            dgvWarrantyPeriods.AllowUserToAddRows = false;
            dgvWarrantyPeriods.AllowUserToDeleteRows = false;
            dgvWarrantyPeriods.AllowUserToResizeColumns = false;
            dgvWarrantyPeriods.AllowUserToResizeRows = false;
            dgvWarrantyPeriods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWarrantyPeriods.BackgroundColor = Color.White;
            dgvWarrantyPeriods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWarrantyPeriods.ContextMenuStrip = cmsDgvRightClick;
            dgvWarrantyPeriods.Location = new Point(20, 64);
            dgvWarrantyPeriods.MultiSelect = false;
            dgvWarrantyPeriods.Name = "dgvWarrantyPeriods";
            dgvWarrantyPeriods.ReadOnly = true;
            dgvWarrantyPeriods.RowHeadersVisible = false;
            dgvWarrantyPeriods.RowHeadersWidth = 51;
            dgvWarrantyPeriods.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvWarrantyPeriods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWarrantyPeriods.ShowCellErrors = false;
            dgvWarrantyPeriods.ShowCellToolTips = false;
            dgvWarrantyPeriods.ShowEditingIcon = false;
            dgvWarrantyPeriods.ShowRowErrors = false;
            dgvWarrantyPeriods.Size = new Size(905, 450);
            dgvWarrantyPeriods.TabIndex = 17;
            // 
            // cbHasWarranty
            // 
            cbHasWarranty.AutoSize = true;
            cbHasWarranty.Location = new Point(20, 20);
            cbHasWarranty.Name = "cbHasWarranty";
            cbHasWarranty.Size = new Size(119, 24);
            cbHasWarranty.TabIndex = 11;
            cbHasWarranty.Text = "Has Warranty";
            cbHasWarranty.UseVisualStyleBackColor = true;
            cbHasWarranty.CheckedChanged += cbHasWarranty_CheckedChanged;
            // 
            // tabAttachments
            // 
            tabAttachments.Controls.Add(dgvAttachments);
            tabAttachments.Controls.Add(btnAddAttachment);
            tabAttachments.Location = new Point(4, 29);
            tabAttachments.Name = "tabAttachments";
            tabAttachments.Size = new Size(947, 537);
            tabAttachments.TabIndex = 4;
            tabAttachments.Text = "Attachments";
            tabAttachments.UseVisualStyleBackColor = true;
            // 
            // dgvAttachments
            // 
            dgvAttachments.AllowUserToAddRows = false;
            dgvAttachments.AllowUserToDeleteRows = false;
            dgvAttachments.AllowUserToResizeColumns = false;
            dgvAttachments.AllowUserToResizeRows = false;
            dgvAttachments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttachments.BackgroundColor = Color.White;
            dgvAttachments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttachments.ContextMenuStrip = cmsDgvRightClick;
            dgvAttachments.Location = new Point(20, 64);
            dgvAttachments.MultiSelect = false;
            dgvAttachments.Name = "dgvAttachments";
            dgvAttachments.ReadOnly = true;
            dgvAttachments.RowHeadersVisible = false;
            dgvAttachments.RowHeadersWidth = 51;
            dgvAttachments.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvAttachments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttachments.ShowCellErrors = false;
            dgvAttachments.ShowCellToolTips = false;
            dgvAttachments.ShowEditingIcon = false;
            dgvAttachments.ShowRowErrors = false;
            dgvAttachments.Size = new Size(905, 450);
            dgvAttachments.TabIndex = 14;
            // 
            // btnAddAttachment
            // 
            btnAddAttachment.Location = new Point(787, 20);
            btnAddAttachment.Name = "btnAddAttachment";
            btnAddAttachment.Size = new Size(138, 29);
            btnAddAttachment.TabIndex = 13;
            btnAddAttachment.Text = "Add Attachment";
            btnAddAttachment.UseVisualStyleBackColor = true;
            btnAddAttachment.Click += btnAddAttachment_Click;
            // 
            // tabNotes
            // 
            tabNotes.Controls.Add(txtDescription);
            tabNotes.Location = new Point(4, 29);
            tabNotes.Name = "tabNotes";
            tabNotes.Size = new Size(947, 537);
            tabNotes.TabIndex = 3;
            tabNotes.Text = "Notes";
            tabNotes.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Location = new Point(0, 0);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(947, 537);
            txtDescription.TabIndex = 10;
            // 
            // btnAddUpdate
            // 
            btnAddUpdate.Location = new Point(877, 592);
            btnAddUpdate.Name = "btnAddUpdate";
            btnAddUpdate.Size = new Size(94, 29);
            btnAddUpdate.TabIndex = 12;
            btnAddUpdate.Text = "Save";
            btnAddUpdate.UseVisualStyleBackColor = true;
            btnAddUpdate.Click += btnAddUpdate_Click;
            // 
            // FrmAssetModify
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 629);
            Controls.Add(btnAddUpdate);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAssetModify";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add New Asset";
            tabControl1.ResumeLayout(false);
            tabInformation.ResumeLayout(false);
            tabInformation.PerformLayout();
            gbInfoContact.ResumeLayout(false);
            gbInfoContact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
            tabHardware.ResumeLayout(false);
            tabHardware.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHardDrives).EndInit();
            cmsDgvRightClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNetworkAdapters).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRamSticks).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRamSizeInGB).EndInit();
            tabWarranty.ResumeLayout(false);
            tabWarranty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWarrantyPeriods).EndInit();
            tabAttachments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttachments).EndInit();
            tabNotes.ResumeLayout(false);
            tabNotes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabInformation;
        private TabPage tabHardware;
        private Button btnAddUpdate;
        private TabPage tabWarranty;
        private TabPage tabNotes;
        private TabPage tabAttachments;
        private Button btnAddAttachment;
        private DataGridView dgvAttachments;
        private CheckBox cbHasWarranty;
        private DataGridView dgvWarrantyPeriods;
        private Button btnAddWarranty;
        private TextBox txtProcessor;
        private Label lblProcessor;
        private Label lblRamSizeInGB;
        private NumericUpDown numRamSizeInGB;
        private NumericUpDown numRamSticks;
        private Label lblRamSticks;
        private TextBox txtBiosSerialNumber;
        private Label lblBiosSerialNumber;
        private Label lblNetworkAdapters;
        private DataGridView dgvNetworkAdapters;
        private Label lblHardDrives;
        private DataGridView dgvHardDrives;
        private TextBox txtDescription;
        private LinkLabel lnkModifyContract;
        private LinkLabel lnkAddContract;
        private Label lblContract;
        private ComboBox cmbContracts;
        private LinkLabel lnkAddPlatform;
        private Label lblPlatform;
        private ComboBox cmbPlatforms;
        private TextBox txtModel;
        private Label lblModel;
        private LinkLabel lnkAddManufacturer;
        private GroupBox gbInfoContact;
        private TextBox txtInfoContactEmail;
        private Label lblInfoContactEmail;
        private TextBox txtInfoContactName;
        private Label lblInfoContactName;
        private TextBox txtLicenseKey;
        private Label lblLicenseKey;
        private Label lblPurchaseCost;
        private NumericUpDown numCost;
        private ComboBox cmbManufacturers;
        private Label lblManufacturer;
        private TextBox txtName;
        private Label lblName;
        private Label lblPurchaseDate;
        private DateTimePicker dtPurchaseDate;
        private TextBox txtOrderRef;
        private Label lblOrderRef;
        private Label lblOperatingSystem;
        private ComboBox cmbOperatingSystems;
        private LinkLabel lnkAddOS;
        private LinkLabel lnkModifyOS;
        private ContextMenuStrip cmsDgvRightClick;
        private ToolStripMenuItem columnSelectorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Button btnAddNetworkAdapter;
        private Button btnAddHardDrive;
        private Label lblType;
        private ComboBox cmbAssetType;
    }
}
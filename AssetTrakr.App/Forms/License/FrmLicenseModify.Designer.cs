namespace AssetTrakr.App.Forms.License
{
    partial class FrmLicenseModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLicenseModify));
            lblName = new Label();
            txtName = new TextBox();
            lblCount = new Label();
            numCount = new NumericUpDown();
            lblPurchaseDate = new Label();
            dtPurchaseDate = new DateTimePicker();
            cbIsSubscription = new CheckBox();
            btnAddUpdate = new Button();
            btnAddAttachment = new Button();
            tabControl1 = new TabControl();
            tabInformation = new TabPage();
            txtVendor = new TextBox();
            lblVendor = new Label();
            lblPaymentFrequency = new Label();
            cmbPaymentFrequency = new ComboBox();
            lnkModifyContract = new LinkLabel();
            lnkAddContract = new LinkLabel();
            lblContract = new Label();
            cmbContracts = new ComboBox();
            lnkAddPlatform = new LinkLabel();
            lblPlatform = new Label();
            cmbPlatforms = new ComboBox();
            lblVersion = new Label();
            txtVersion = new TextBox();
            txtLicenseKey = new TextBox();
            lblLicenseKey = new Label();
            lnkAddManufacturer = new LinkLabel();
            gbInfoContact = new GroupBox();
            txtInfoContactEmail = new TextBox();
            lblInfoContactEmail = new Label();
            txtInfoContactName = new TextBox();
            lblInfoContactName = new Label();
            txtOrderRef = new TextBox();
            lblOrderRef = new Label();
            lblPurchaseCost = new Label();
            numCost = new NumericUpDown();
            cmbManufacturers = new ComboBox();
            lblManufacturer = new Label();
            tabSubscription = new TabPage();
            dgvSubscriptionPeriods = new DataGridView();
            cmsDgvRightClick = new ContextMenuStrip(components);
            columnSelectorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            viewToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            btnAddSubPeriod = new Button();
            tabAttachments = new TabPage();
            dgvAttachments = new DataGridView();
            tabDescription = new TabPage();
            txtDescription = new TextBox();
            notifyIcon1 = new NotifyIcon(components);
            ((System.ComponentModel.ISupportInitialize)numCount).BeginInit();
            tabControl1.SuspendLayout();
            tabInformation.SuspendLayout();
            gbInfoContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
            tabSubscription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubscriptionPeriods).BeginInit();
            cmsDgvRightClick.SuspendLayout();
            tabAttachments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttachments).BeginInit();
            tabDescription.SuspendLayout();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Location = new Point(21, 27);
            lblName.Name = "lblName";
            lblName.Size = new Size(103, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 24);
            txtName.Name = "txtName";
            txtName.Size = new Size(235, 27);
            txtName.TabIndex = 1;
            // 
            // lblCount
            // 
            lblCount.Location = new Point(21, 199);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(103, 20);
            lblCount.TabIndex = 2;
            lblCount.Text = "License Count";
            lblCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numCount
            // 
            numCount.Location = new Point(130, 194);
            numCount.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCount.Name = "numCount";
            numCount.Size = new Size(235, 27);
            numCount.TabIndex = 5;
            numCount.ThousandsSeparator = true;
            numCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPurchaseDate
            // 
            lblPurchaseDate.Location = new Point(21, 72);
            lblPurchaseDate.Name = "lblPurchaseDate";
            lblPurchaseDate.Size = new Size(103, 20);
            lblPurchaseDate.TabIndex = 4;
            lblPurchaseDate.Text = "Purchase Date";
            lblPurchaseDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtPurchaseDate
            // 
            dtPurchaseDate.Location = new Point(130, 67);
            dtPurchaseDate.MinDate = new DateTime(1975, 1, 1, 0, 0, 0, 0);
            dtPurchaseDate.Name = "dtPurchaseDate";
            dtPurchaseDate.Size = new Size(235, 27);
            dtPurchaseDate.TabIndex = 2;
            // 
            // cbIsSubscription
            // 
            cbIsSubscription.AutoSize = true;
            cbIsSubscription.Location = new Point(20, 20);
            cbIsSubscription.Name = "cbIsSubscription";
            cbIsSubscription.Size = new Size(142, 24);
            cbIsSubscription.TabIndex = 10;
            cbIsSubscription.Text = "Has Subscription";
            cbIsSubscription.UseVisualStyleBackColor = true;
            cbIsSubscription.CheckedChanged += cbIsSubscription_CheckedChanged;
            // 
            // btnAddUpdate
            // 
            btnAddUpdate.Location = new Point(877, 592);
            btnAddUpdate.Name = "btnAddUpdate";
            btnAddUpdate.Size = new Size(94, 29);
            btnAddUpdate.TabIndex = 15;
            btnAddUpdate.Text = "Save";
            btnAddUpdate.UseVisualStyleBackColor = true;
            btnAddUpdate.Click += btnAddUpdate_Click;
            // 
            // btnAddAttachment
            // 
            btnAddAttachment.Location = new Point(787, 20);
            btnAddAttachment.Name = "btnAddAttachment";
            btnAddAttachment.Size = new Size(138, 29);
            btnAddAttachment.TabIndex = 12;
            btnAddAttachment.Text = "Add Attachment";
            btnAddAttachment.UseVisualStyleBackColor = true;
            btnAddAttachment.Click += btnAddAttachment_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabInformation);
            tabControl1.Controls.Add(tabSubscription);
            tabControl1.Controls.Add(tabAttachments);
            tabControl1.Controls.Add(tabDescription);
            tabControl1.Location = new Point(20, 20);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(955, 570);
            tabControl1.TabIndex = 13;
            // 
            // tabInformation
            // 
            tabInformation.Controls.Add(txtVendor);
            tabInformation.Controls.Add(lblVendor);
            tabInformation.Controls.Add(lblPaymentFrequency);
            tabInformation.Controls.Add(cmbPaymentFrequency);
            tabInformation.Controls.Add(lnkModifyContract);
            tabInformation.Controls.Add(lnkAddContract);
            tabInformation.Controls.Add(lblContract);
            tabInformation.Controls.Add(cmbContracts);
            tabInformation.Controls.Add(lnkAddPlatform);
            tabInformation.Controls.Add(lblPlatform);
            tabInformation.Controls.Add(cmbPlatforms);
            tabInformation.Controls.Add(lblVersion);
            tabInformation.Controls.Add(txtVersion);
            tabInformation.Controls.Add(txtLicenseKey);
            tabInformation.Controls.Add(lblLicenseKey);
            tabInformation.Controls.Add(lnkAddManufacturer);
            tabInformation.Controls.Add(gbInfoContact);
            tabInformation.Controls.Add(txtOrderRef);
            tabInformation.Controls.Add(lblOrderRef);
            tabInformation.Controls.Add(lblPurchaseCost);
            tabInformation.Controls.Add(numCost);
            tabInformation.Controls.Add(cmbManufacturers);
            tabInformation.Controls.Add(lblManufacturer);
            tabInformation.Controls.Add(txtName);
            tabInformation.Controls.Add(lblName);
            tabInformation.Controls.Add(lblCount);
            tabInformation.Controls.Add(numCount);
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
            // txtVendor
            // 
            txtVendor.Location = new Point(511, 194);
            txtVendor.Name = "txtVendor";
            txtVendor.Size = new Size(235, 27);
            txtVendor.TabIndex = 12;
            // 
            // lblVendor
            // 
            lblVendor.Location = new Point(402, 199);
            lblVendor.Name = "lblVendor";
            lblVendor.Size = new Size(103, 20);
            lblVendor.TabIndex = 28;
            lblVendor.Text = "Vendor";
            lblVendor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPaymentFrequency
            // 
            lblPaymentFrequency.Location = new Point(21, 155);
            lblPaymentFrequency.Name = "lblPaymentFrequency";
            lblPaymentFrequency.Size = new Size(103, 20);
            lblPaymentFrequency.TabIndex = 27;
            lblPaymentFrequency.Text = "Pay Frequency";
            lblPaymentFrequency.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbPaymentFrequency
            // 
            cmbPaymentFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentFrequency.FormattingEnabled = true;
            cmbPaymentFrequency.Location = new Point(130, 152);
            cmbPaymentFrequency.Name = "cmbPaymentFrequency";
            cmbPaymentFrequency.Size = new Size(235, 28);
            cmbPaymentFrequency.TabIndex = 4;
            cmbPaymentFrequency.SelectedIndexChanged += cmbPaymentFrequency_SelectedIndexChanged;
            // 
            // lnkModifyContract
            // 
            lnkModifyContract.AutoSize = true;
            lnkModifyContract.Location = new Point(795, 155);
            lnkModifyContract.Name = "lnkModifyContract";
            lnkModifyContract.Size = new Size(56, 20);
            lnkModifyContract.TabIndex = 25;
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
            lnkAddContract.TabIndex = 24;
            lnkAddContract.TabStop = true;
            lnkAddContract.Text = "Add";
            lnkAddContract.LinkClicked += lnkAddContract_LinkClicked;
            // 
            // lblContract
            // 
            lblContract.Location = new Point(402, 155);
            lblContract.Name = "lblContract";
            lblContract.Size = new Size(103, 20);
            lblContract.TabIndex = 23;
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
            cmbContracts.TabIndex = 11;
            cmbContracts.SelectedIndexChanged += cmbContracts_SelectedIndexChanged;
            // 
            // lnkAddPlatform
            // 
            lnkAddPlatform.AutoSize = true;
            lnkAddPlatform.Location = new Point(371, 280);
            lnkAddPlatform.Name = "lnkAddPlatform";
            lnkAddPlatform.Size = new Size(63, 20);
            lnkAddPlatform.TabIndex = 21;
            lnkAddPlatform.TabStop = true;
            lnkAddPlatform.Text = "Manage";
            lnkAddPlatform.LinkClicked += lnkAddPlatform_LinkClicked;
            // 
            // lblPlatform
            // 
            lblPlatform.Location = new Point(21, 280);
            lblPlatform.Name = "lblPlatform";
            lblPlatform.Size = new Size(103, 20);
            lblPlatform.TabIndex = 20;
            lblPlatform.Text = "Platform";
            lblPlatform.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbPlatforms
            // 
            cmbPlatforms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlatforms.FormattingEnabled = true;
            cmbPlatforms.Location = new Point(130, 277);
            cmbPlatforms.Name = "cmbPlatforms";
            cmbPlatforms.Size = new Size(235, 28);
            cmbPlatforms.TabIndex = 7;
            // 
            // lblVersion
            // 
            lblVersion.Location = new Point(402, 112);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(103, 20);
            lblVersion.TabIndex = 18;
            lblVersion.Text = "Version";
            lblVersion.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtVersion
            // 
            txtVersion.Location = new Point(511, 110);
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(235, 27);
            txtVersion.TabIndex = 10;
            // 
            // txtLicenseKey
            // 
            txtLicenseKey.Location = new Point(511, 24);
            txtLicenseKey.Name = "txtLicenseKey";
            txtLicenseKey.Size = new Size(235, 27);
            txtLicenseKey.TabIndex = 8;
            // 
            // lblLicenseKey
            // 
            lblLicenseKey.Location = new Point(402, 27);
            lblLicenseKey.Name = "lblLicenseKey";
            lblLicenseKey.Size = new Size(103, 20);
            lblLicenseKey.TabIndex = 14;
            lblLicenseKey.Text = "License Key";
            lblLicenseKey.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lnkAddManufacturer
            // 
            lnkAddManufacturer.AutoSize = true;
            lnkAddManufacturer.Location = new Point(371, 240);
            lnkAddManufacturer.Name = "lnkAddManufacturer";
            lnkAddManufacturer.Size = new Size(63, 20);
            lnkAddManufacturer.TabIndex = 15;
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
            gbInfoContact.TabIndex = 14;
            gbInfoContact.TabStop = false;
            gbInfoContact.Text = "Registered Information";
            // 
            // txtInfoContactEmail
            // 
            txtInfoContactEmail.Location = new Point(597, 27);
            txtInfoContactEmail.Name = "txtInfoContactEmail";
            txtInfoContactEmail.Size = new Size(274, 27);
            txtInfoContactEmail.TabIndex = 14;
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
            txtInfoContactName.TabIndex = 13;
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
            // txtOrderRef
            // 
            txtOrderRef.Location = new Point(511, 67);
            txtOrderRef.Name = "txtOrderRef";
            txtOrderRef.Size = new Size(235, 27);
            txtOrderRef.TabIndex = 9;
            // 
            // lblOrderRef
            // 
            lblOrderRef.Location = new Point(402, 72);
            lblOrderRef.Name = "lblOrderRef";
            lblOrderRef.Size = new Size(103, 20);
            lblOrderRef.TabIndex = 12;
            lblOrderRef.Text = "Order Ref.";
            lblOrderRef.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPurchaseCost
            // 
            lblPurchaseCost.Location = new Point(21, 112);
            lblPurchaseCost.Name = "lblPurchaseCost";
            lblPurchaseCost.Size = new Size(103, 20);
            lblPurchaseCost.TabIndex = 11;
            lblPurchaseCost.Text = "Price";
            lblPurchaseCost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numCost
            // 
            numCost.DecimalPlaces = 2;
            numCost.Location = new Point(130, 110);
            numCost.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numCost.Name = "numCost";
            numCost.Size = new Size(235, 27);
            numCost.TabIndex = 3;
            // 
            // cmbManufacturers
            // 
            cmbManufacturers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbManufacturers.FormattingEnabled = true;
            cmbManufacturers.Location = new Point(130, 237);
            cmbManufacturers.Name = "cmbManufacturers";
            cmbManufacturers.Size = new Size(235, 28);
            cmbManufacturers.TabIndex = 6;
            // 
            // lblManufacturer
            // 
            lblManufacturer.Location = new Point(21, 240);
            lblManufacturer.Name = "lblManufacturer";
            lblManufacturer.Size = new Size(103, 20);
            lblManufacturer.TabIndex = 8;
            lblManufacturer.Text = "Manufacturer";
            lblManufacturer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabSubscription
            // 
            tabSubscription.Controls.Add(dgvSubscriptionPeriods);
            tabSubscription.Controls.Add(btnAddSubPeriod);
            tabSubscription.Controls.Add(cbIsSubscription);
            tabSubscription.Location = new Point(4, 29);
            tabSubscription.Name = "tabSubscription";
            tabSubscription.Padding = new Padding(3);
            tabSubscription.Size = new Size(947, 537);
            tabSubscription.TabIndex = 2;
            tabSubscription.Text = "Subscription";
            tabSubscription.UseVisualStyleBackColor = true;
            // 
            // dgvSubscriptionPeriods
            // 
            dgvSubscriptionPeriods.AllowUserToAddRows = false;
            dgvSubscriptionPeriods.AllowUserToDeleteRows = false;
            dgvSubscriptionPeriods.AllowUserToResizeColumns = false;
            dgvSubscriptionPeriods.AllowUserToResizeRows = false;
            dgvSubscriptionPeriods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubscriptionPeriods.BackgroundColor = Color.White;
            dgvSubscriptionPeriods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubscriptionPeriods.ContextMenuStrip = cmsDgvRightClick;
            dgvSubscriptionPeriods.Location = new Point(20, 64);
            dgvSubscriptionPeriods.MultiSelect = false;
            dgvSubscriptionPeriods.Name = "dgvSubscriptionPeriods";
            dgvSubscriptionPeriods.ReadOnly = true;
            dgvSubscriptionPeriods.RowHeadersVisible = false;
            dgvSubscriptionPeriods.RowHeadersWidth = 51;
            dgvSubscriptionPeriods.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvSubscriptionPeriods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubscriptionPeriods.ShowCellErrors = false;
            dgvSubscriptionPeriods.ShowCellToolTips = false;
            dgvSubscriptionPeriods.ShowEditingIcon = false;
            dgvSubscriptionPeriods.ShowRowErrors = false;
            dgvSubscriptionPeriods.Size = new Size(905, 450);
            dgvSubscriptionPeriods.TabIndex = 16;
            // 
            // cmsDgvRightClick
            // 
            cmsDgvRightClick.ImageScalingSize = new Size(20, 20);
            cmsDgvRightClick.Items.AddRange(new ToolStripItem[] { columnSelectorToolStripMenuItem, toolStripSeparator1, viewToolStripMenuItem, deleteToolStripMenuItem });
            cmsDgvRightClick.Name = "contextMenuStrip1";
            cmsDgvRightClick.Size = new Size(211, 110);
            cmsDgvRightClick.Opening += cmsDgvRightClick_Opening;
            // 
            // columnSelectorToolStripMenuItem
            // 
            columnSelectorToolStripMenuItem.Name = "columnSelectorToolStripMenuItem";
            columnSelectorToolStripMenuItem.Size = new Size(210, 24);
            columnSelectorToolStripMenuItem.Text = "Column Selector";
            columnSelectorToolStripMenuItem.Click += columnSelectorToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(207, 6);
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(210, 24);
            viewToolStripMenuItem.Text = "View";
            viewToolStripMenuItem.Click += viewToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(210, 24);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // btnAddSubPeriod
            // 
            btnAddSubPeriod.Enabled = false;
            btnAddSubPeriod.Location = new Point(787, 20);
            btnAddSubPeriod.Name = "btnAddSubPeriod";
            btnAddSubPeriod.Size = new Size(138, 29);
            btnAddSubPeriod.TabIndex = 15;
            btnAddSubPeriod.Text = "Add Period";
            btnAddSubPeriod.UseVisualStyleBackColor = true;
            btnAddSubPeriod.Click += btnAddSubPeriod_Click;
            // 
            // tabAttachments
            // 
            tabAttachments.Controls.Add(dgvAttachments);
            tabAttachments.Controls.Add(btnAddAttachment);
            tabAttachments.Location = new Point(4, 29);
            tabAttachments.Name = "tabAttachments";
            tabAttachments.Padding = new Padding(3);
            tabAttachments.Size = new Size(947, 537);
            tabAttachments.TabIndex = 1;
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
            dgvAttachments.TabIndex = 13;
            // 
            // tabDescription
            // 
            tabDescription.Controls.Add(txtDescription);
            tabDescription.Location = new Point(4, 29);
            tabDescription.Name = "tabDescription";
            tabDescription.Padding = new Padding(3);
            tabDescription.Size = new Size(947, 537);
            tabDescription.TabIndex = 3;
            tabDescription.Text = "Notes";
            tabDescription.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Location = new Point(3, 3);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(941, 531);
            txtDescription.TabIndex = 8;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // FrmLicenseModify
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 629);
            Controls.Add(tabControl1);
            Controls.Add(btnAddUpdate);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLicenseModify";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add New License";
            ((System.ComponentModel.ISupportInitialize)numCount).EndInit();
            tabControl1.ResumeLayout(false);
            tabInformation.ResumeLayout(false);
            tabInformation.PerformLayout();
            gbInfoContact.ResumeLayout(false);
            gbInfoContact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
            tabSubscription.ResumeLayout(false);
            tabSubscription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubscriptionPeriods).EndInit();
            cmsDgvRightClick.ResumeLayout(false);
            tabAttachments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttachments).EndInit();
            tabDescription.ResumeLayout(false);
            tabDescription.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblCount;
        private NumericUpDown numCount;
        private Label lblPurchaseDate;
        private DateTimePicker dtPurchaseDate;
        private CheckBox cbIsSubscription;
        private Button btnAddUpdate;
        private Button btnAddAttachment;
        private TabControl tabControl1;
        private TabPage tabInformation;
        private TabPage tabAttachments;
        private TabPage tabSubscription;
        private DataGridView dgvAttachments;
        private Label lblManufacturer;
        private ComboBox cmbManufacturers;
        private TabPage tabDescription;
        private TextBox txtDescription;
        private Label lblPurchaseCost;
        private NumericUpDown numCost;
        private TextBox txtOrderRef;
        private Label lblOrderRef;
        private Button btnAddSubPeriod;
        private ContextMenuStrip cmsDgvRightClick;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private DataGridView dgvSubscriptionPeriods;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem columnSelectorToolStripMenuItem;
        private GroupBox gbInfoContact;
        private TextBox txtInfoContactName;
        private Label lblInfoContactName;
        private TextBox txtInfoContactEmail;
        private Label lblInfoContactEmail;
        private LinkLabel lnkAddManufacturer;
        private TextBox txtLicenseKey;
        private Label lblLicenseKey;
        private Label lblVersion;
        private TextBox txtVersion;
        private ComboBox cmbPlatforms;
        private Label lblPlatform;
        private LinkLabel lnkAddPlatform;
        private Label lblContract;
        private ComboBox cmbContracts;
        private LinkLabel lnkAddContract;
        private LinkLabel lnkModifyContract;
        private Label lblPaymentFrequency;
        private ComboBox cmbPaymentFrequency;
        private NotifyIcon notifyIcon1;
        private TextBox txtVendor;
        private Label lblVendor;
        private ToolStripMenuItem viewToolStripMenuItem;
    }
}
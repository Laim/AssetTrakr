namespace AssetTrakr.App.Forms
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            menuStripMain = new MenuStrip();
            licensesToolStripMenuItem = new ToolStripMenuItem();
            addLicenseToolStripMenuItem = new ToolStripMenuItem();
            viewLicensesToolStripMenuItem = new ToolStripMenuItem();
            assetsToolStripMenuItem = new ToolStripMenuItem();
            addAssetToolStripMenuItem = new ToolStripMenuItem();
            viewAssetsToolStripMenuItem = new ToolStripMenuItem();
            contractsToolStripMenuItem = new ToolStripMenuItem();
            addContractToolStripMenuItem = new ToolStripMenuItem();
            viewContractsToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            administrationToolStripMenuItem = new ToolStripMenuItem();
            actionLogToolStripMenuItem = new ToolStripMenuItem();
            manufacturerManagerToolStripMenuItem = new ToolStripMenuItem();
            platformManagerToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            systemSettingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            reportBugToolStripMenuItem = new ToolStripMenuItem();
            featureRequestToolStripMenuItem = new ToolStripMenuItem();
            documentationToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            gbLicenseCount = new GroupBox();
            lblLicenseCount = new Label();
            gbAssetsCount = new GroupBox();
            lblAssetCount = new Label();
            gbManufacturers = new GroupBox();
            lblManufacturerCount = new Label();
            gbContracts = new GroupBox();
            lblContractCount = new Label();
            lblAlertList = new Label();
            dgvAlerts = new DataGridView();
            cmsDgvRightClick = new ContextMenuStrip(components);
            columnSelectorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exportToolStripMenuItem = new ToolStripMenuItem();
            gbPlatforms = new GroupBox();
            lblPlatformsCount = new Label();
            lnkRefreshDashboard = new LinkLabel();
            toolStripSeparator4 = new ToolStripSeparator();
            dataToolStripMenuItem = new ToolStripMenuItem();
            menuStripMain.SuspendLayout();
            gbLicenseCount.SuspendLayout();
            gbAssetsCount.SuspendLayout();
            gbManufacturers.SuspendLayout();
            gbContracts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlerts).BeginInit();
            cmsDgvRightClick.SuspendLayout();
            gbPlatforms.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripMain
            // 
            menuStripMain.ImageScalingSize = new Size(20, 20);
            menuStripMain.Items.AddRange(new ToolStripItem[] { licensesToolStripMenuItem, assetsToolStripMenuItem, contractsToolStripMenuItem, reportsToolStripMenuItem, administrationToolStripMenuItem, helpToolStripMenuItem });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(1262, 28);
            menuStripMain.TabIndex = 0;
            menuStripMain.Text = "Menu Strip";
            // 
            // licensesToolStripMenuItem
            // 
            licensesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addLicenseToolStripMenuItem, viewLicensesToolStripMenuItem });
            licensesToolStripMenuItem.Name = "licensesToolStripMenuItem";
            licensesToolStripMenuItem.Size = new Size(77, 24);
            licensesToolStripMenuItem.Text = "Licenses";
            // 
            // addLicenseToolStripMenuItem
            // 
            addLicenseToolStripMenuItem.Name = "addLicenseToolStripMenuItem";
            addLicenseToolStripMenuItem.Size = new Size(182, 26);
            addLicenseToolStripMenuItem.Text = "Add License";
            addLicenseToolStripMenuItem.Click += addLicenseToolStripMenuItem_Click;
            // 
            // viewLicensesToolStripMenuItem
            // 
            viewLicensesToolStripMenuItem.Name = "viewLicensesToolStripMenuItem";
            viewLicensesToolStripMenuItem.Size = new Size(182, 26);
            viewLicensesToolStripMenuItem.Text = "View Licenses";
            viewLicensesToolStripMenuItem.Click += viewLicensesToolStripMenuItem_Click;
            // 
            // assetsToolStripMenuItem
            // 
            assetsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addAssetToolStripMenuItem, viewAssetsToolStripMenuItem });
            assetsToolStripMenuItem.Name = "assetsToolStripMenuItem";
            assetsToolStripMenuItem.Size = new Size(64, 24);
            assetsToolStripMenuItem.Text = "Assets";
            // 
            // addAssetToolStripMenuItem
            // 
            addAssetToolStripMenuItem.Name = "addAssetToolStripMenuItem";
            addAssetToolStripMenuItem.Size = new Size(169, 26);
            addAssetToolStripMenuItem.Text = "Add Asset";
            addAssetToolStripMenuItem.Click += addAssetToolStripMenuItem_Click;
            // 
            // viewAssetsToolStripMenuItem
            // 
            viewAssetsToolStripMenuItem.Name = "viewAssetsToolStripMenuItem";
            viewAssetsToolStripMenuItem.Size = new Size(169, 26);
            viewAssetsToolStripMenuItem.Text = "View Assets";
            viewAssetsToolStripMenuItem.Click += viewAssetsToolStripMenuItem_Click;
            // 
            // contractsToolStripMenuItem
            // 
            contractsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addContractToolStripMenuItem, viewContractsToolStripMenuItem });
            contractsToolStripMenuItem.Name = "contractsToolStripMenuItem";
            contractsToolStripMenuItem.Size = new Size(85, 24);
            contractsToolStripMenuItem.Text = "Contracts";
            // 
            // addContractToolStripMenuItem
            // 
            addContractToolStripMenuItem.Name = "addContractToolStripMenuItem";
            addContractToolStripMenuItem.Size = new Size(190, 26);
            addContractToolStripMenuItem.Text = "Add Contract";
            addContractToolStripMenuItem.Click += addContractToolStripMenuItem_Click;
            // 
            // viewContractsToolStripMenuItem
            // 
            viewContractsToolStripMenuItem.Enabled = false;
            viewContractsToolStripMenuItem.Name = "viewContractsToolStripMenuItem";
            viewContractsToolStripMenuItem.Size = new Size(190, 26);
            viewContractsToolStripMenuItem.Text = "View Contracts";
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(74, 24);
            reportsToolStripMenuItem.Text = "Reports";
            reportsToolStripMenuItem.Click += reportsToolStripMenuItem_Click;
            // 
            // administrationToolStripMenuItem
            // 
            administrationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { actionLogToolStripMenuItem, manufacturerManagerToolStripMenuItem, platformManagerToolStripMenuItem, toolStripSeparator3, systemSettingsToolStripMenuItem });
            administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            administrationToolStripMenuItem.Size = new Size(121, 24);
            administrationToolStripMenuItem.Text = "Administration";
            // 
            // actionLogToolStripMenuItem
            // 
            actionLogToolStripMenuItem.Name = "actionLogToolStripMenuItem";
            actionLogToolStripMenuItem.Size = new Size(243, 26);
            actionLogToolStripMenuItem.Text = "Action Log";
            actionLogToolStripMenuItem.Click += actionLogToolStripMenuItem_Click;
            // 
            // manufacturerManagerToolStripMenuItem
            // 
            manufacturerManagerToolStripMenuItem.Name = "manufacturerManagerToolStripMenuItem";
            manufacturerManagerToolStripMenuItem.Size = new Size(243, 26);
            manufacturerManagerToolStripMenuItem.Text = "Manufacturer Manager";
            manufacturerManagerToolStripMenuItem.Click += manufacturerManagerToolStripMenuItem_Click;
            // 
            // platformManagerToolStripMenuItem
            // 
            platformManagerToolStripMenuItem.Name = "platformManagerToolStripMenuItem";
            platformManagerToolStripMenuItem.Size = new Size(243, 26);
            platformManagerToolStripMenuItem.Text = "Platform Manager";
            platformManagerToolStripMenuItem.Click += platformManagerToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(240, 6);
            // 
            // systemSettingsToolStripMenuItem
            // 
            systemSettingsToolStripMenuItem.Name = "systemSettingsToolStripMenuItem";
            systemSettingsToolStripMenuItem.Size = new Size(243, 26);
            systemSettingsToolStripMenuItem.Text = "System Settings";
            systemSettingsToolStripMenuItem.Click += systemSettingsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reportBugToolStripMenuItem, featureRequestToolStripMenuItem, documentationToolStripMenuItem, toolStripSeparator2, aboutToolStripMenuItem, toolStripSeparator4, dataToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // reportBugToolStripMenuItem
            // 
            reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            reportBugToolStripMenuItem.Size = new Size(224, 26);
            reportBugToolStripMenuItem.Text = "Report Bug";
            reportBugToolStripMenuItem.Click += reportBugToolStripMenuItem_Click;
            // 
            // featureRequestToolStripMenuItem
            // 
            featureRequestToolStripMenuItem.Name = "featureRequestToolStripMenuItem";
            featureRequestToolStripMenuItem.Size = new Size(224, 26);
            featureRequestToolStripMenuItem.Text = "Feature Request";
            featureRequestToolStripMenuItem.Click += featureRequestToolStripMenuItem_Click;
            // 
            // documentationToolStripMenuItem
            // 
            documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            documentationToolStripMenuItem.Size = new Size(224, 26);
            documentationToolStripMenuItem.Text = "Documentation";
            documentationToolStripMenuItem.Click += documentationToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(221, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(224, 26);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // gbLicenseCount
            // 
            gbLicenseCount.Controls.Add(lblLicenseCount);
            gbLicenseCount.Location = new Point(20, 40);
            gbLicenseCount.Name = "gbLicenseCount";
            gbLicenseCount.Size = new Size(200, 200);
            gbLicenseCount.TabIndex = 3;
            gbLicenseCount.TabStop = false;
            gbLicenseCount.Text = "Licenses";
            // 
            // lblLicenseCount
            // 
            lblLicenseCount.Dock = DockStyle.Fill;
            lblLicenseCount.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLicenseCount.ForeColor = Color.Red;
            lblLicenseCount.Location = new Point(3, 23);
            lblLicenseCount.Name = "lblLicenseCount";
            lblLicenseCount.Size = new Size(194, 174);
            lblLicenseCount.TabIndex = 0;
            lblLicenseCount.Text = "0";
            lblLicenseCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbAssetsCount
            // 
            gbAssetsCount.Controls.Add(lblAssetCount);
            gbAssetsCount.Location = new Point(226, 40);
            gbAssetsCount.Name = "gbAssetsCount";
            gbAssetsCount.Size = new Size(200, 200);
            gbAssetsCount.TabIndex = 4;
            gbAssetsCount.TabStop = false;
            gbAssetsCount.Text = "Assets";
            // 
            // lblAssetCount
            // 
            lblAssetCount.Dock = DockStyle.Fill;
            lblAssetCount.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAssetCount.ForeColor = Color.Red;
            lblAssetCount.Location = new Point(3, 23);
            lblAssetCount.Name = "lblAssetCount";
            lblAssetCount.Size = new Size(194, 174);
            lblAssetCount.TabIndex = 1;
            lblAssetCount.Text = "0";
            lblAssetCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbManufacturers
            // 
            gbManufacturers.Controls.Add(lblManufacturerCount);
            gbManufacturers.Location = new Point(638, 40);
            gbManufacturers.Name = "gbManufacturers";
            gbManufacturers.Size = new Size(200, 200);
            gbManufacturers.TabIndex = 5;
            gbManufacturers.TabStop = false;
            gbManufacturers.Text = "Manufacturers";
            // 
            // lblManufacturerCount
            // 
            lblManufacturerCount.Dock = DockStyle.Fill;
            lblManufacturerCount.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManufacturerCount.ForeColor = Color.Red;
            lblManufacturerCount.Location = new Point(3, 23);
            lblManufacturerCount.Name = "lblManufacturerCount";
            lblManufacturerCount.Size = new Size(194, 174);
            lblManufacturerCount.TabIndex = 1;
            lblManufacturerCount.Text = "0";
            lblManufacturerCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbContracts
            // 
            gbContracts.Controls.Add(lblContractCount);
            gbContracts.Location = new Point(432, 40);
            gbContracts.Name = "gbContracts";
            gbContracts.Size = new Size(200, 200);
            gbContracts.TabIndex = 6;
            gbContracts.TabStop = false;
            gbContracts.Text = "Contracts";
            // 
            // lblContractCount
            // 
            lblContractCount.Dock = DockStyle.Fill;
            lblContractCount.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContractCount.ForeColor = Color.Red;
            lblContractCount.Location = new Point(3, 23);
            lblContractCount.Name = "lblContractCount";
            lblContractCount.Size = new Size(194, 174);
            lblContractCount.TabIndex = 1;
            lblContractCount.Text = "0";
            lblContractCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAlertList
            // 
            lblAlertList.AutoSize = true;
            lblAlertList.Location = new Point(20, 252);
            lblAlertList.Name = "lblAlertList";
            lblAlertList.Size = new Size(47, 20);
            lblAlertList.TabIndex = 8;
            lblAlertList.Text = "Alerts";
            // 
            // dgvAlerts
            // 
            dgvAlerts.AllowUserToAddRows = false;
            dgvAlerts.AllowUserToDeleteRows = false;
            dgvAlerts.AllowUserToOrderColumns = true;
            dgvAlerts.AllowUserToResizeRows = false;
            dgvAlerts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlerts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAlerts.BackgroundColor = Color.White;
            dgvAlerts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlerts.ContextMenuStrip = cmsDgvRightClick;
            dgvAlerts.Location = new Point(20, 288);
            dgvAlerts.MultiSelect = false;
            dgvAlerts.Name = "dgvAlerts";
            dgvAlerts.ReadOnly = true;
            dgvAlerts.RowHeadersVisible = false;
            dgvAlerts.RowHeadersWidth = 51;
            dgvAlerts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvAlerts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlerts.ShowCellErrors = false;
            dgvAlerts.ShowCellToolTips = false;
            dgvAlerts.ShowEditingIcon = false;
            dgvAlerts.ShowRowErrors = false;
            dgvAlerts.Size = new Size(609, 351);
            dgvAlerts.TabIndex = 19;
            // 
            // cmsDgvRightClick
            // 
            cmsDgvRightClick.ImageScalingSize = new Size(20, 20);
            cmsDgvRightClick.Items.AddRange(new ToolStripItem[] { columnSelectorToolStripMenuItem, toolStripSeparator1, exportToolStripMenuItem });
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
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(187, 24);
            exportToolStripMenuItem.Text = "Export List";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // gbPlatforms
            // 
            gbPlatforms.Controls.Add(lblPlatformsCount);
            gbPlatforms.Location = new Point(844, 40);
            gbPlatforms.Name = "gbPlatforms";
            gbPlatforms.Size = new Size(200, 200);
            gbPlatforms.TabIndex = 6;
            gbPlatforms.TabStop = false;
            gbPlatforms.Text = "Platforms";
            // 
            // lblPlatformsCount
            // 
            lblPlatformsCount.Dock = DockStyle.Fill;
            lblPlatformsCount.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlatformsCount.ForeColor = Color.Red;
            lblPlatformsCount.Location = new Point(3, 23);
            lblPlatformsCount.Name = "lblPlatformsCount";
            lblPlatformsCount.Size = new Size(194, 174);
            lblPlatformsCount.TabIndex = 1;
            lblPlatformsCount.Text = "0";
            lblPlatformsCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lnkRefreshDashboard
            // 
            lnkRefreshDashboard.AutoSize = true;
            lnkRefreshDashboard.Location = new Point(1192, 40);
            lnkRefreshDashboard.Name = "lnkRefreshDashboard";
            lnkRefreshDashboard.Size = new Size(58, 20);
            lnkRefreshDashboard.TabIndex = 20;
            lnkRefreshDashboard.TabStop = true;
            lnkRefreshDashboard.Text = "Refresh";
            lnkRefreshDashboard.LinkClicked += lnkRefreshDashboard_LinkClicked;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(221, 6);
            // 
            // dataToolStripMenuItem
            // 
            dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            dataToolStripMenuItem.Size = new Size(224, 26);
            dataToolStripMenuItem.Text = "Data";
            dataToolStripMenuItem.Click += dataToolStripMenuItem_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1262, 673);
            Controls.Add(lnkRefreshDashboard);
            Controls.Add(gbPlatforms);
            Controls.Add(dgvAlerts);
            Controls.Add(lblAlertList);
            Controls.Add(gbContracts);
            Controls.Add(gbManufacturers);
            Controls.Add(gbAssetsCount);
            Controls.Add(gbLicenseCount);
            Controls.Add(menuStripMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStripMain;
            MinimumSize = new Size(1280, 720);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AssetTrakr • Dashboard";
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            gbLicenseCount.ResumeLayout(false);
            gbAssetsCount.ResumeLayout(false);
            gbManufacturers.ResumeLayout(false);
            gbContracts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAlerts).EndInit();
            cmsDgvRightClick.ResumeLayout(false);
            gbPlatforms.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem licensesToolStripMenuItem;
        private ToolStripMenuItem addLicenseToolStripMenuItem;
        private ToolStripMenuItem viewLicensesToolStripMenuItem;
        private ToolStripMenuItem assetsToolStripMenuItem;
        private ToolStripMenuItem addAssetToolStripMenuItem;
        private GroupBox gbLicenseCount;
        private Label lblLicenseCount;
        private GroupBox gbAssetsCount;
        private Label lblAssetCount;
        private ToolStripMenuItem administrationToolStripMenuItem;
        private ToolStripMenuItem actionLogToolStripMenuItem;
        private ToolStripMenuItem viewAssetsToolStripMenuItem;
        private GroupBox gbManufacturers;
        private Label lblManufacturerCount;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem manufacturerManagerToolStripMenuItem;
        private ToolStripMenuItem platformManagerToolStripMenuItem;
        private ToolStripMenuItem contractsToolStripMenuItem;
        private ToolStripMenuItem addContractToolStripMenuItem;
        private GroupBox gbContracts;
        private Label lblContractCount;
        private Label lblAlertList;
        private DataGridView dgvAlerts;
        private GroupBox gbPlatforms;
        private Label lblPlatformsCount;
        private LinkLabel lnkRefreshDashboard;
        private ContextMenuStrip cmsDgvRightClick;
        private ToolStripMenuItem columnSelectorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem viewContractsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem reportBugToolStripMenuItem;
        private ToolStripMenuItem featureRequestToolStripMenuItem;
        private ToolStripMenuItem documentationToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem systemSettingsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem dataToolStripMenuItem;
    }
}
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
            menuStripMain = new MenuStrip();
            licensesToolStripMenuItem = new ToolStripMenuItem();
            addLicenseToolStripMenuItem = new ToolStripMenuItem();
            viewLicensesToolStripMenuItem = new ToolStripMenuItem();
            assetsToolStripMenuItem = new ToolStripMenuItem();
            addAssetToolStripMenuItem = new ToolStripMenuItem();
            administrationToolStripMenuItem = new ToolStripMenuItem();
            actionLogToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            textBox1 = new TextBox();
            gbLicenseCount = new GroupBox();
            lblLicenseCount = new Label();
            gbAssetsCount = new GroupBox();
            lblAssetCount = new Label();
            menuStripMain.SuspendLayout();
            gbLicenseCount.SuspendLayout();
            gbAssetsCount.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripMain
            // 
            menuStripMain.ImageScalingSize = new Size(20, 20);
            menuStripMain.Items.AddRange(new ToolStripItem[] { licensesToolStripMenuItem, assetsToolStripMenuItem, administrationToolStripMenuItem });
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
            assetsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addAssetToolStripMenuItem });
            assetsToolStripMenuItem.Name = "assetsToolStripMenuItem";
            assetsToolStripMenuItem.Size = new Size(64, 24);
            assetsToolStripMenuItem.Text = "Assets";
            // 
            // addAssetToolStripMenuItem
            // 
            addAssetToolStripMenuItem.Name = "addAssetToolStripMenuItem";
            addAssetToolStripMenuItem.Size = new Size(159, 26);
            addAssetToolStripMenuItem.Text = "Add Asset";
            addAssetToolStripMenuItem.Click += addAssetToolStripMenuItem_Click;
            // 
            // administrationToolStripMenuItem
            // 
            administrationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { actionLogToolStripMenuItem });
            administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            administrationToolStripMenuItem.Size = new Size(121, 24);
            administrationToolStripMenuItem.Text = "Administration";
            // 
            // actionLogToolStripMenuItem
            // 
            actionLogToolStripMenuItem.Name = "actionLogToolStripMenuItem";
            actionLogToolStripMenuItem.Size = new Size(164, 26);
            actionLogToolStripMenuItem.Text = "Action Log";
            actionLogToolStripMenuItem.Click += actionLogToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Location = new Point(574, 547);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(674, 547);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
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
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1262, 673);
            Controls.Add(gbAssetsCount);
            Controls.Add(gbLicenseCount);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(menuStripMain);
            MainMenuStrip = menuStripMain;
            MinimumSize = new Size(1280, 720);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AssetTrakr • Dashboard";
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            gbLicenseCount.ResumeLayout(false);
            gbAssetsCount.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem licensesToolStripMenuItem;
        private ToolStripMenuItem addLicenseToolStripMenuItem;
        private ToolStripMenuItem viewLicensesToolStripMenuItem;
        private Button button1;
        private TextBox textBox1;
        private ToolStripMenuItem assetsToolStripMenuItem;
        private ToolStripMenuItem addAssetToolStripMenuItem;
        private GroupBox gbLicenseCount;
        private Label lblLicenseCount;
        private GroupBox gbAssetsCount;
        private Label lblAssetCount;
        private ToolStripMenuItem administrationToolStripMenuItem;
        private ToolStripMenuItem actionLogToolStripMenuItem;
    }
}
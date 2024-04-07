namespace AssetTrakr.App.Forms.Miscellaneous
{
    partial class FrmDataExporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataExporter));
            lblTitle = new Label();
            lblHr = new Label();
            txtDescription = new TextBox();
            lblExportOptions = new Label();
            cbLicenses = new CheckBox();
            cbContracts = new CheckBox();
            cbAssets = new CheckBox();
            cbPlatforms = new CheckBox();
            cbManufacturers = new CheckBox();
            cbActionLog = new CheckBox();
            btnExport = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(215, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Data Exporter";
            // 
            // lblHr
            // 
            lblHr.AutoSize = true;
            lblHr.Location = new Point(-96, 63);
            lblHr.Name = "lblHr";
            lblHr.Size = new Size(981, 20);
            lblHr.TabIndex = 1;
            lblHr.Text = "__________________________________________________________________________________________________________________________________________________________________";
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Location = new Point(20, 93);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(610, 128);
            txtDescription.TabIndex = 2;
            txtDescription.Text = resources.GetString("txtDescription.Text");
            // 
            // lblExportOptions
            // 
            lblExportOptions.AutoSize = true;
            lblExportOptions.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExportOptions.Location = new Point(20, 231);
            lblExportOptions.Name = "lblExportOptions";
            lblExportOptions.Size = new Size(155, 28);
            lblExportOptions.TabIndex = 3;
            lblExportOptions.Text = "Export Options";
            // 
            // cbLicenses
            // 
            cbLicenses.AutoSize = true;
            cbLicenses.Location = new Point(27, 270);
            cbLicenses.Name = "cbLicenses";
            cbLicenses.Size = new Size(85, 24);
            cbLicenses.TabIndex = 4;
            cbLicenses.Text = "Licenses";
            cbLicenses.UseVisualStyleBackColor = true;
            // 
            // cbContracts
            // 
            cbContracts.AutoSize = true;
            cbContracts.Location = new Point(118, 270);
            cbContracts.Name = "cbContracts";
            cbContracts.Size = new Size(93, 24);
            cbContracts.TabIndex = 5;
            cbContracts.Text = "Contracts";
            cbContracts.UseVisualStyleBackColor = true;
            // 
            // cbAssets
            // 
            cbAssets.AutoSize = true;
            cbAssets.Location = new Point(217, 270);
            cbAssets.Name = "cbAssets";
            cbAssets.Size = new Size(72, 24);
            cbAssets.TabIndex = 6;
            cbAssets.Text = "Assets";
            cbAssets.UseVisualStyleBackColor = true;
            // 
            // cbPlatforms
            // 
            cbPlatforms.AutoSize = true;
            cbPlatforms.Location = new Point(295, 270);
            cbPlatforms.Name = "cbPlatforms";
            cbPlatforms.Size = new Size(94, 24);
            cbPlatforms.TabIndex = 7;
            cbPlatforms.Text = "Platforms";
            cbPlatforms.UseVisualStyleBackColor = true;
            // 
            // cbManufacturers
            // 
            cbManufacturers.AutoSize = true;
            cbManufacturers.Location = new Point(395, 270);
            cbManufacturers.Name = "cbManufacturers";
            cbManufacturers.Size = new Size(125, 24);
            cbManufacturers.TabIndex = 8;
            cbManufacturers.Text = "Manufacturers";
            cbManufacturers.UseVisualStyleBackColor = true;
            // 
            // cbActionLog
            // 
            cbActionLog.AutoSize = true;
            cbActionLog.Location = new Point(526, 270);
            cbActionLog.Name = "cbActionLog";
            cbActionLog.Size = new Size(103, 24);
            cbActionLog.TabIndex = 9;
            cbActionLog.Text = "Action Log";
            cbActionLog.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(536, 323);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(94, 29);
            btnExport.TabIndex = 10;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // FrmDataExporter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(650, 372);
            Controls.Add(btnExport);
            Controls.Add(cbActionLog);
            Controls.Add(cbManufacturers);
            Controls.Add(cbPlatforms);
            Controls.Add(cbAssets);
            Controls.Add(cbContracts);
            Controls.Add(cbLicenses);
            Controls.Add(lblExportOptions);
            Controls.Add(txtDescription);
            Controls.Add(lblHr);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmDataExporter";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Data Exporter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblHr;
        private TextBox txtDescription;
        private Label lblExportOptions;
        private CheckBox cbLicenses;
        private CheckBox cbContracts;
        private CheckBox cbAssets;
        private CheckBox cbPlatforms;
        private CheckBox cbManufacturers;
        private CheckBox cbActionLog;
        private Button btnExport;
    }
}
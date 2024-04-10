namespace AssetTrakr.App.Setup
{
    partial class FrmDatabaseUpgrade
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
            lblTitle = new Label();
            lblHr = new Label();
            lblNotice = new Label();
            btnMigrate = new Button();
            btnData = new Button();
            btnBackupDatabase = new Button();
            btnVersionFix = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(414, 38);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "AssetTrakr Database Upgrader";
            // 
            // lblHr
            // 
            lblHr.AutoSize = true;
            lblHr.Location = new Point(-137, 58);
            lblHr.Name = "lblHr";
            lblHr.Size = new Size(1089, 20);
            lblHr.TabIndex = 2;
            lblHr.Text = "____________________________________________________________________________________________________________________________________________________________________________________";
            // 
            // lblNotice
            // 
            lblNotice.Location = new Point(20, 96);
            lblNotice.Name = "lblNotice";
            lblNotice.Size = new Size(768, 139);
            lblNotice.TabIndex = 3;
            lblNotice.Text = "No migrations required, database is up to date.";
            // 
            // btnMigrate
            // 
            btnMigrate.Location = new Point(694, 265);
            btnMigrate.Name = "btnMigrate";
            btnMigrate.Size = new Size(94, 29);
            btnMigrate.TabIndex = 4;
            btnMigrate.Text = "Migrate";
            btnMigrate.UseVisualStyleBackColor = true;
            btnMigrate.Click += btnMigrate_Click;
            // 
            // btnData
            // 
            btnData.Location = new Point(20, 265);
            btnData.Name = "btnData";
            btnData.Size = new Size(94, 29);
            btnData.TabIndex = 5;
            btnData.Text = "Data";
            btnData.UseVisualStyleBackColor = true;
            btnData.Click += btnData_Click;
            // 
            // btnBackupDatabase
            // 
            btnBackupDatabase.Location = new Point(120, 265);
            btnBackupDatabase.Name = "btnBackupDatabase";
            btnBackupDatabase.Size = new Size(157, 29);
            btnBackupDatabase.TabIndex = 6;
            btnBackupDatabase.Text = "Backup Database";
            btnBackupDatabase.UseVisualStyleBackColor = true;
            btnBackupDatabase.Click += btnBackupDatabase_Click;
            // 
            // btnVersionFix
            // 
            btnVersionFix.Location = new Point(594, 265);
            btnVersionFix.Name = "btnVersionFix";
            btnVersionFix.Size = new Size(94, 29);
            btnVersionFix.TabIndex = 7;
            btnVersionFix.Text = "Fix Version";
            btnVersionFix.UseVisualStyleBackColor = true;
            btnVersionFix.Click += btnVersionFix_Click;
            // 
            // FrmDatabaseUpgrade
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 306);
            Controls.Add(btnVersionFix);
            Controls.Add(btnBackupDatabase);
            Controls.Add(btnData);
            Controls.Add(btnMigrate);
            Controls.Add(lblNotice);
            Controls.Add(lblHr);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmDatabaseUpgrade";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AssetTrakr - Database Upgrader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTitle;
        private Label lblHr;
        private Label lblNotice;
        private Button btnMigrate;
        private Button btnData;
        private Button btnBackupDatabase;
        private Button btnVersionFix;
    }
}
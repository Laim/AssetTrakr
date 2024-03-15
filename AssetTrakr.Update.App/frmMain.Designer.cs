namespace AssetTrakr.Update.App
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            btnInstall = new Button();
            lblAppName = new Label();
            lbReleases = new ListBox();
            lblNewVersion = new Label();
            lblChangeLog = new Label();
            lblCurVer = new Label();
            lblUnderscore = new Label();
            SuspendLayout();
            // 
            // btnInstall
            // 
            btnInstall.Enabled = false;
            btnInstall.Location = new Point(456, 493);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new Size(127, 29);
            btnInstall.TabIndex = 0;
            btnInstall.Text = "Install Update";
            btnInstall.UseVisualStyleBackColor = true;
            btnInstall.Click += btnInstall_ClickAsync;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.Location = new Point(20, 20);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(258, 62);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "AssetTrakr";
            // 
            // lbReleases
            // 
            lbReleases.FormattingEnabled = true;
            lbReleases.Location = new Point(20, 118);
            lbReleases.Name = "lbReleases";
            lbReleases.Size = new Size(258, 404);
            lbReleases.TabIndex = 2;
            lbReleases.SelectedIndexChanged += lbReleases_SelectedIndexChanged;
            // 
            // lblNewVersion
            // 
            lblNewVersion.AutoSize = true;
            lblNewVersion.Location = new Point(284, 118);
            lblNewVersion.Name = "lblNewVersion";
            lblNewVersion.Size = new Size(116, 20);
            lblNewVersion.TabIndex = 3;
            lblNewVersion.Text = "New Version: {0}";
            // 
            // lblChangeLog
            // 
            lblChangeLog.Location = new Point(284, 156);
            lblChangeLog.Name = "lblChangeLog";
            lblChangeLog.Size = new Size(299, 318);
            lblChangeLog.TabIndex = 4;
            lblChangeLog.Text = resources.GetString("lblChangeLog.Text");
            // 
            // lblCurVer
            // 
            lblCurVer.AutoSize = true;
            lblCurVer.Location = new Point(284, 43);
            lblCurVer.Name = "lblCurVer";
            lblCurVer.Size = new Size(186, 20);
            lblCurVer.TabIndex = 5;
            lblCurVer.Text = "You're currently running {0}";
            // 
            // lblUnderscore
            // 
            lblUnderscore.AutoSize = true;
            lblUnderscore.BackColor = Color.Transparent;
            lblUnderscore.Location = new Point(-117, 79);
            lblUnderscore.Name = "lblUnderscore";
            lblUnderscore.Size = new Size(837, 20);
            lblUnderscore.TabIndex = 6;
            lblUnderscore.Text = "__________________________________________________________________________________________________________________________________________";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(595, 544);
            Controls.Add(lblCurVer);
            Controls.Add(lblChangeLog);
            Controls.Add(lblNewVersion);
            Controls.Add(lbReleases);
            Controls.Add(lblAppName);
            Controls.Add(btnInstall);
            Controls.Add(lblUnderscore);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AssetTrakr Updater";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInstall;
        private Label lblAppName;
        private ListBox lbReleases;
        private Label lblNewVersion;
        private Label lblChangeLog;
        private Label lblCurVer;
        private Label lblUnderscore;
    }
}

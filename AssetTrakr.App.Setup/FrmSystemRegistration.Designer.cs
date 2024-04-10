namespace AssetTrakr.App.Forms.Miscellaneous
{
    partial class FrmSystemRegistration
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
            lblFullName = new Label();
            txtFullName = new TextBox();
            txtProductVersion = new TextBox();
            lblProductVersion = new Label();
            txtDatabaseCreationDate = new TextBox();
            lblCreationDate = new Label();
            gbNote = new GroupBox();
            lblNotice = new Label();
            btnRegister = new Button();
            txtRunDirectory = new TextBox();
            lblRunDirectory = new Label();
            gbNote.SuspendLayout();
            SuspendLayout();
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(56, 20);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(76, 20);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full Name";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(138, 17);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(294, 27);
            txtFullName.TabIndex = 1;
            // 
            // txtProductVersion
            // 
            txtProductVersion.Location = new Point(138, 50);
            txtProductVersion.Name = "txtProductVersion";
            txtProductVersion.ReadOnly = true;
            txtProductVersion.Size = new Size(294, 27);
            txtProductVersion.TabIndex = 2;
            txtProductVersion.TabStop = false;
            // 
            // lblProductVersion
            // 
            lblProductVersion.AutoSize = true;
            lblProductVersion.Location = new Point(20, 53);
            lblProductVersion.Name = "lblProductVersion";
            lblProductVersion.Size = new Size(112, 20);
            lblProductVersion.TabIndex = 3;
            lblProductVersion.Text = "Product Version";
            // 
            // txtDatabaseCreationDate
            // 
            txtDatabaseCreationDate.Location = new Point(138, 83);
            txtDatabaseCreationDate.Name = "txtDatabaseCreationDate";
            txtDatabaseCreationDate.ReadOnly = true;
            txtDatabaseCreationDate.Size = new Size(294, 27);
            txtDatabaseCreationDate.TabIndex = 4;
            txtDatabaseCreationDate.TabStop = false;
            // 
            // lblCreationDate
            // 
            lblCreationDate.AutoSize = true;
            lblCreationDate.Location = new Point(7, 86);
            lblCreationDate.Name = "lblCreationDate";
            lblCreationDate.Size = new Size(125, 20);
            lblCreationDate.TabIndex = 5;
            lblCreationDate.Text = "Registration Date";
            // 
            // gbNote
            // 
            gbNote.Controls.Add(lblNotice);
            gbNote.Location = new Point(12, 146);
            gbNote.Name = "gbNote";
            gbNote.Size = new Size(420, 125);
            gbNote.TabIndex = 6;
            gbNote.TabStop = false;
            gbNote.Text = "Notice";
            // 
            // lblNotice
            // 
            lblNotice.Dock = DockStyle.Fill;
            lblNotice.Location = new Point(3, 23);
            lblNotice.Name = "lblNotice";
            lblNotice.Size = new Size(414, 99);
            lblNotice.TabIndex = 0;
            lblNotice.Text = "This information is not shared.  This is used purely for ensuring that updates are installed correctly, you can leave your name blank if you want.";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(12, 277);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(420, 29);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtRunDirectory
            // 
            txtRunDirectory.Location = new Point(138, 116);
            txtRunDirectory.Name = "txtRunDirectory";
            txtRunDirectory.ReadOnly = true;
            txtRunDirectory.Size = new Size(294, 27);
            txtRunDirectory.TabIndex = 8;
            txtRunDirectory.TabStop = false;
            // 
            // lblRunDirectory
            // 
            lblRunDirectory.AutoSize = true;
            lblRunDirectory.Location = new Point(33, 119);
            lblRunDirectory.Name = "lblRunDirectory";
            lblRunDirectory.Size = new Size(99, 20);
            lblRunDirectory.TabIndex = 9;
            lblRunDirectory.Text = "Run Directory";
            // 
            // FrmSystemRegistration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(446, 318);
            Controls.Add(lblRunDirectory);
            Controls.Add(txtRunDirectory);
            Controls.Add(btnRegister);
            Controls.Add(gbNote);
            Controls.Add(lblCreationDate);
            Controls.Add(txtDatabaseCreationDate);
            Controls.Add(lblProductVersion);
            Controls.Add(txtProductVersion);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmSystemRegistration";
            StartPosition = FormStartPosition.CenterParent;
            Text = "System Registration";
            gbNote.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFullName;
        private TextBox txtFullName;
        private TextBox txtProductVersion;
        private Label lblProductVersion;
        private TextBox txtDatabaseCreationDate;
        private Label lblCreationDate;
        private GroupBox gbNote;
        private Label lblNotice;
        private Button btnRegister;
        private TextBox txtRunDirectory;
        private Label lblRunDirectory;
    }
}
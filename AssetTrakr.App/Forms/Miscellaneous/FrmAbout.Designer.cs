namespace AssetTrakr.App.Forms.Miscellaneous
{
    partial class FrmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            pictureBox1 = new PictureBox();
            lblProductName = new Label();
            lblVersion = new Label();
            lblVersionValue = new Label();
            lblCopyright = new Label();
            lblCopyrightValue = new Label();
            lblDescription = new Label();
            lblDescriptionValue = new Label();
            btnOK = new Button();
            btnLicenses = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(15, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(175, 397);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductName.Location = new Point(196, 14);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(198, 38);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "ProductName";
            // 
            // lblVersion
            // 
            lblVersion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVersion.Location = new Point(195, 110);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(102, 25);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Version";
            lblVersion.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblVersionValue
            // 
            lblVersionValue.AutoSize = true;
            lblVersionValue.Location = new Point(303, 112);
            lblVersionValue.Name = "lblVersionValue";
            lblVersionValue.Size = new Size(50, 20);
            lblVersionValue.TabIndex = 3;
            lblVersionValue.Text = "0.0.0.0";
            // 
            // lblCopyright
            // 
            lblCopyright.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCopyright.Location = new Point(195, 140);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(102, 25);
            lblCopyright.TabIndex = 4;
            lblCopyright.Text = "Copyright";
            lblCopyright.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCopyrightValue
            // 
            lblCopyrightValue.AutoSize = true;
            lblCopyrightValue.Location = new Point(303, 142);
            lblCopyrightValue.Name = "lblCopyrightValue";
            lblCopyrightValue.Size = new Size(231, 20);
            lblCopyrightValue.TabIndex = 5;
            lblCopyrightValue.Text = "Copyright (c) Year Laim McKenzie";
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(195, 170);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(102, 25);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Description";
            lblDescription.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDescriptionValue
            // 
            lblDescriptionValue.Location = new Point(303, 196);
            lblDescriptionValue.Name = "lblDescriptionValue";
            lblDescriptionValue.Size = new Size(231, 134);
            lblDescriptionValue.TabIndex = 7;
            lblDescriptionValue.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(440, 382);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 8;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnLicenses
            // 
            btnLicenses.Location = new Point(340, 382);
            btnLicenses.Name = "btnLicenses";
            btnLicenses.Size = new Size(94, 29);
            btnLicenses.TabIndex = 9;
            btnLicenses.Text = "Licenses";
            btnLicenses.UseVisualStyleBackColor = true;
            btnLicenses.Click += btnLicenses_Click;
            // 
            // FrmAbout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(580, 427);
            Controls.Add(btnLicenses);
            Controls.Add(btnOK);
            Controls.Add(lblDescriptionValue);
            Controls.Add(lblDescription);
            Controls.Add(lblCopyrightValue);
            Controls.Add(lblCopyright);
            Controls.Add(lblVersionValue);
            Controls.Add(lblVersion);
            Controls.Add(lblProductName);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAbout";
            Padding = new Padding(12, 14, 12, 14);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmAbout";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblProductName;
        private Label lblVersion;
        private Label lblVersionValue;
        private Label lblCopyright;
        private Label lblCopyrightValue;
        private Label lblDescription;
        private Label lblDescriptionValue;
        private Button btnOK;
        private Button btnLicenses;
    }
}

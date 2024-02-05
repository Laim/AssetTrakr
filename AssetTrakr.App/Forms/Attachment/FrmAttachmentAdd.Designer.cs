namespace AssetTrakr.App.Forms.Attachment
{
    partial class FrmAttachmentAdd
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
            lblName = new Label();
            txtName = new TextBox();
            cbIsUrl = new CheckBox();
            gbAttachmentFile = new GroupBox();
            btnAttachmentFileBrowse = new Button();
            txtAttachmentFilePath = new TextBox();
            lblAttachmentFilePath = new Label();
            gbAttachmentUrl = new GroupBox();
            txtAttachmentUrl = new TextBox();
            lblAttachmentUrl = new Label();
            btnAdd = new Button();
            txtDescription = new TextBox();
            lblDescription = new Label();
            gbAttachmentFile.SuspendLayout();
            gbAttachmentUrl.SuspendLayout();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(75, 17);
            txtName.Name = "txtName";
            txtName.Size = new Size(333, 27);
            txtName.TabIndex = 1;
            // 
            // cbIsUrl
            // 
            cbIsUrl.AutoSize = true;
            cbIsUrl.Location = new Point(20, 159);
            cbIsUrl.Name = "cbIsUrl";
            cbIsUrl.Size = new Size(164, 24);
            cbIsUrl.TabIndex = 2;
            cbIsUrl.Text = "Attachment is a URL";
            cbIsUrl.UseVisualStyleBackColor = true;
            cbIsUrl.CheckedChanged += cbIsUrl_CheckedChanged;
            // 
            // gbAttachmentFile
            // 
            gbAttachmentFile.Controls.Add(btnAttachmentFileBrowse);
            gbAttachmentFile.Controls.Add(txtAttachmentFilePath);
            gbAttachmentFile.Controls.Add(lblAttachmentFilePath);
            gbAttachmentFile.Location = new Point(20, 189);
            gbAttachmentFile.Name = "gbAttachmentFile";
            gbAttachmentFile.Size = new Size(388, 74);
            gbAttachmentFile.TabIndex = 3;
            gbAttachmentFile.TabStop = false;
            gbAttachmentFile.Text = "File Attachment";
            // 
            // btnAttachmentFileBrowse
            // 
            btnAttachmentFileBrowse.Location = new Point(325, 28);
            btnAttachmentFileBrowse.Name = "btnAttachmentFileBrowse";
            btnAttachmentFileBrowse.Size = new Size(57, 29);
            btnAttachmentFileBrowse.TabIndex = 2;
            btnAttachmentFileBrowse.Text = "...";
            btnAttachmentFileBrowse.UseVisualStyleBackColor = true;
            btnAttachmentFileBrowse.Click += btnAttachmentFileBrowse_Click;
            // 
            // txtAttachmentFilePath
            // 
            txtAttachmentFilePath.Location = new Point(55, 30);
            txtAttachmentFilePath.Name = "txtAttachmentFilePath";
            txtAttachmentFilePath.Size = new Size(264, 27);
            txtAttachmentFilePath.TabIndex = 1;
            // 
            // lblAttachmentFilePath
            // 
            lblAttachmentFilePath.AutoSize = true;
            lblAttachmentFilePath.Location = new Point(12, 33);
            lblAttachmentFilePath.Name = "lblAttachmentFilePath";
            lblAttachmentFilePath.Size = new Size(37, 20);
            lblAttachmentFilePath.TabIndex = 0;
            lblAttachmentFilePath.Text = "Path";
            // 
            // gbAttachmentUrl
            // 
            gbAttachmentUrl.Controls.Add(txtAttachmentUrl);
            gbAttachmentUrl.Controls.Add(lblAttachmentUrl);
            gbAttachmentUrl.Enabled = false;
            gbAttachmentUrl.Location = new Point(20, 269);
            gbAttachmentUrl.Name = "gbAttachmentUrl";
            gbAttachmentUrl.Size = new Size(388, 74);
            gbAttachmentUrl.TabIndex = 4;
            gbAttachmentUrl.TabStop = false;
            gbAttachmentUrl.Text = "URL Attachment";
            // 
            // txtAttachmentUrl
            // 
            txtAttachmentUrl.Location = new Point(55, 30);
            txtAttachmentUrl.Name = "txtAttachmentUrl";
            txtAttachmentUrl.Size = new Size(327, 27);
            txtAttachmentUrl.TabIndex = 1;
            // 
            // lblAttachmentUrl
            // 
            lblAttachmentUrl.AutoSize = true;
            lblAttachmentUrl.Location = new Point(12, 33);
            lblAttachmentUrl.Name = "lblAttachmentUrl";
            lblAttachmentUrl.Size = new Size(35, 20);
            lblAttachmentUrl.TabIndex = 0;
            lblAttachmentUrl.Text = "URL";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(314, 349);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Save";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(75, 60);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(333, 93);
            txtDescription.TabIndex = 9;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(20, 60);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(48, 20);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "Notes";
            // 
            // FrmAttachmentAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 390);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(btnAdd);
            Controls.Add(gbAttachmentUrl);
            Controls.Add(gbAttachmentFile);
            Controls.Add(cbIsUrl);
            Controls.Add(txtName);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmAttachmentAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Attachment";
            gbAttachmentFile.ResumeLayout(false);
            gbAttachmentFile.PerformLayout();
            gbAttachmentUrl.ResumeLayout(false);
            gbAttachmentUrl.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private CheckBox cbIsUrl;
        private GroupBox gbAttachmentFile;
        private Button btnAttachmentFileBrowse;
        private TextBox txtAttachmentFilePath;
        private Label lblAttachmentFilePath;
        private GroupBox gbAttachmentUrl;
        private TextBox txtAttachmentUrl;
        private Label lblAttachmentUrl;
        private Button btnAdd;
        private TextBox txtDescription;
        private Label lblDescription;
    }
}
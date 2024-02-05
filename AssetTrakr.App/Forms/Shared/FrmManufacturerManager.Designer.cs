namespace AssetTrakr.App.Forms.Shared
{
    partial class FrmManufacturerManager
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
            lbManufacturers = new ListBox();
            contextMenuStripListbx = new ContextMenuStrip(components);
            deselectToolStripMenuItem = new ToolStripMenuItem();
            lblName = new Label();
            txtName = new TextBox();
            txtUrl = new TextBox();
            lblUrl = new Label();
            txtSupportUrl = new TextBox();
            lblSupportUrl = new Label();
            txtSupportEmail = new TextBox();
            txtSupportPhone = new TextBox();
            txtNotes = new TextBox();
            lblSupportEmail = new Label();
            lblSupportPhone = new Label();
            lblNotes = new Label();
            btnDelete = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            contextMenuStripListbx.SuspendLayout();
            SuspendLayout();
            // 
            // lbManufacturers
            // 
            lbManufacturers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbManufacturers.ContextMenuStrip = contextMenuStripListbx;
            lbManufacturers.FormattingEnabled = true;
            lbManufacturers.Location = new Point(20, 20);
            lbManufacturers.Name = "lbManufacturers";
            lbManufacturers.Size = new Size(299, 364);
            lbManufacturers.TabIndex = 2;
            lbManufacturers.SelectedIndexChanged += lbManufacturers_SelectedIndexChanged;
            // 
            // contextMenuStripListbx
            // 
            contextMenuStripListbx.ImageScalingSize = new Size(20, 20);
            contextMenuStripListbx.Items.AddRange(new ToolStripItem[] { deselectToolStripMenuItem });
            contextMenuStripListbx.Name = "contextMenuStripListbx";
            contextMenuStripListbx.Size = new Size(136, 28);
            // 
            // deselectToolStripMenuItem
            // 
            deselectToolStripMenuItem.Name = "deselectToolStripMenuItem";
            deselectToolStripMenuItem.Size = new Size(135, 24);
            deselectToolStripMenuItem.Text = "Deselect";
            deselectToolStripMenuItem.Click += deselectToolStripMenuItem_Click;
            // 
            // lblName
            // 
            lblName.Location = new Point(334, 23);
            lblName.Name = "lblName";
            lblName.Size = new Size(118, 20);
            lblName.TabIndex = 3;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Location = new Point(458, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(319, 27);
            txtName.TabIndex = 4;
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(458, 60);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(319, 27);
            txtUrl.TabIndex = 5;
            // 
            // lblUrl
            // 
            lblUrl.Location = new Point(334, 63);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(118, 25);
            lblUrl.TabIndex = 6;
            lblUrl.Text = "URL";
            lblUrl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSupportUrl
            // 
            txtSupportUrl.Location = new Point(458, 100);
            txtSupportUrl.Name = "txtSupportUrl";
            txtSupportUrl.Size = new Size(319, 27);
            txtSupportUrl.TabIndex = 7;
            // 
            // lblSupportUrl
            // 
            lblSupportUrl.Location = new Point(333, 103);
            lblSupportUrl.Name = "lblSupportUrl";
            lblSupportUrl.Size = new Size(119, 25);
            lblSupportUrl.TabIndex = 8;
            lblSupportUrl.Text = "Support Url";
            lblSupportUrl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSupportEmail
            // 
            txtSupportEmail.Location = new Point(458, 140);
            txtSupportEmail.Name = "txtSupportEmail";
            txtSupportEmail.Size = new Size(319, 27);
            txtSupportEmail.TabIndex = 9;
            // 
            // txtSupportPhone
            // 
            txtSupportPhone.Location = new Point(458, 180);
            txtSupportPhone.Name = "txtSupportPhone";
            txtSupportPhone.Size = new Size(319, 27);
            txtSupportPhone.TabIndex = 10;
            // 
            // txtNotes
            // 
            txtNotes.AcceptsReturn = true;
            txtNotes.Location = new Point(458, 220);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(319, 165);
            txtNotes.TabIndex = 11;
            // 
            // lblSupportEmail
            // 
            lblSupportEmail.Location = new Point(334, 141);
            lblSupportEmail.Name = "lblSupportEmail";
            lblSupportEmail.Size = new Size(119, 25);
            lblSupportEmail.TabIndex = 13;
            lblSupportEmail.Text = "Support Email";
            lblSupportEmail.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSupportPhone
            // 
            lblSupportPhone.Location = new Point(334, 181);
            lblSupportPhone.Name = "lblSupportPhone";
            lblSupportPhone.Size = new Size(119, 25);
            lblSupportPhone.TabIndex = 14;
            lblSupportPhone.Text = "Support Phone";
            lblSupportPhone.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNotes
            // 
            lblNotes.Location = new Point(334, 221);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(119, 25);
            lblNotes.TabIndex = 15;
            lblNotes.Text = "Notes";
            lblNotes.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(20, 390);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.Location = new Point(683, 391);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdate.Enabled = false;
            btnUpdate.Location = new Point(583, 391);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmManufacturerManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 426);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(lblNotes);
            Controls.Add(lblSupportPhone);
            Controls.Add(lblSupportEmail);
            Controls.Add(txtNotes);
            Controls.Add(txtSupportPhone);
            Controls.Add(txtSupportEmail);
            Controls.Add(lblSupportUrl);
            Controls.Add(txtSupportUrl);
            Controls.Add(lblUrl);
            Controls.Add(txtUrl);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(lbManufacturers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(818, 836);
            MinimizeBox = false;
            MinimumSize = new Size(818, 473);
            Name = "FrmManufacturerManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manufacturer Manager";
            contextMenuStripListbx.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox lbManufacturers;
        private Label lblName;
        private TextBox txtName;
        private TextBox txtUrl;
        private Label lblUrl;
        private TextBox txtSupportUrl;
        private Label lblSupportUrl;
        private TextBox txtSupportEmail;
        private TextBox txtSupportPhone;
        private TextBox txtNotes;
        private Label lblSupportEmail;
        private Label lblSupportPhone;
        private Label lblNotes;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnUpdate;
        private ContextMenuStrip contextMenuStripListbx;
        private ToolStripMenuItem deselectToolStripMenuItem;
    }
}
namespace AssetTrakr.App.Forms.Shared
{
    partial class FrmPlatformManager
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
            lbPlatforms = new ListBox();
            contextMenuStripListbx = new ContextMenuStrip(components);
            deselectToolStripMenuItem = new ToolStripMenuItem();
            lblName = new Label();
            txtName = new TextBox();
            btnDelete = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            lblNotes = new Label();
            txtNotes = new TextBox();
            lblManufacturer = new Label();
            cmbManufacturersList = new ComboBox();
            contextMenuStripListbx.SuspendLayout();
            SuspendLayout();
            // 
            // lbPlatforms
            // 
            lbPlatforms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbPlatforms.ContextMenuStrip = contextMenuStripListbx;
            lbPlatforms.FormattingEnabled = true;
            lbPlatforms.Location = new Point(20, 20);
            lbPlatforms.Name = "lbPlatforms";
            lbPlatforms.Size = new Size(299, 364);
            lbPlatforms.TabIndex = 2;
            lbPlatforms.SelectedIndexChanged += lbPlatforms_SelectedIndexChanged;
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
            // lblNotes
            // 
            lblNotes.Location = new Point(334, 106);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(119, 25);
            lblNotes.TabIndex = 15;
            lblNotes.Text = "Notes";
            lblNotes.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNotes
            // 
            txtNotes.AcceptsReturn = true;
            txtNotes.Location = new Point(458, 106);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(319, 165);
            txtNotes.TabIndex = 11;
            // 
            // lblManufacturer
            // 
            lblManufacturer.Location = new Point(334, 63);
            lblManufacturer.Name = "lblManufacturer";
            lblManufacturer.Size = new Size(118, 25);
            lblManufacturer.TabIndex = 6;
            lblManufacturer.Text = "Manufacturer";
            lblManufacturer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbManufacturersList
            // 
            cmbManufacturersList.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbManufacturersList.FormattingEnabled = true;
            cmbManufacturersList.Location = new Point(458, 62);
            cmbManufacturersList.Name = "cmbManufacturersList";
            cmbManufacturersList.Size = new Size(319, 28);
            cmbManufacturersList.TabIndex = 19;
            // 
            // FrmPlatformManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 426);
            Controls.Add(cmbManufacturersList);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(lblNotes);
            Controls.Add(txtNotes);
            Controls.Add(lblManufacturer);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(lbPlatforms);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(818, 836);
            MinimizeBox = false;
            MinimumSize = new Size(818, 473);
            Name = "FrmPlatformManager";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Platform Manager";
            contextMenuStripListbx.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox lbPlatforms;
        private Label lblName;
        private TextBox txtName;
        private Label lblUrl;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnUpdate;
        private ContextMenuStrip contextMenuStripListbx;
        private ToolStripMenuItem deselectToolStripMenuItem;
        private Label lblNotes;
        private TextBox txtNotes;
        private Label lblManufacturer;
        private ComboBox cmbManufacturersList;
    }
}
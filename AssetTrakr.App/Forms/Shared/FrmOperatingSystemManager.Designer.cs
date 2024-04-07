﻿namespace AssetTrakr.App.Forms.Shared
{
    partial class FrmOperatingSystemManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOperatingSystemManager));
            btnUpdate = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            lbOperatingSystems = new ListBox();
            contextMenuStripListbx = new ContextMenuStrip(components);
            deselectToolStripMenuItem = new ToolStripMenuItem();
            cmbManufacturers = new ComboBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            lblManufacturer = new Label();
            txtName = new TextBox();
            lblName = new Label();
            contextMenuStripListbx.SuspendLayout();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdate.Enabled = false;
            btnUpdate.Location = new Point(585, 390);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 25;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.Location = new Point(683, 391);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 24;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(20, 390);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lbOperatingSystems
            // 
            lbOperatingSystems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbOperatingSystems.ContextMenuStrip = contextMenuStripListbx;
            lbOperatingSystems.FormattingEnabled = true;
            lbOperatingSystems.Location = new Point(20, 20);
            lbOperatingSystems.Name = "lbOperatingSystems";
            lbOperatingSystems.Size = new Size(299, 364);
            lbOperatingSystems.TabIndex = 20;
            lbOperatingSystems.SelectedIndexChanged += lbOperatingSystems_SelectedIndexChanged;
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
            // cmbManufacturers
            // 
            cmbManufacturers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbManufacturers.FormattingEnabled = true;
            cmbManufacturers.Location = new Point(458, 62);
            cmbManufacturers.Name = "cmbManufacturers";
            cmbManufacturers.Size = new Size(319, 28);
            cmbManufacturers.TabIndex = 31;
            // 
            // lblNotes
            // 
            lblNotes.Location = new Point(334, 106);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(119, 25);
            lblNotes.TabIndex = 30;
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
            txtNotes.TabIndex = 29;
            // 
            // lblManufacturer
            // 
            lblManufacturer.Location = new Point(334, 63);
            lblManufacturer.Name = "lblManufacturer";
            lblManufacturer.Size = new Size(118, 25);
            lblManufacturer.TabIndex = 28;
            lblManufacturer.Text = "Manufacturer";
            lblManufacturer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Location = new Point(458, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(319, 27);
            txtName.TabIndex = 27;
            // 
            // lblName
            // 
            lblName.Location = new Point(334, 23);
            lblName.Name = "lblName";
            lblName.Size = new Size(118, 20);
            lblName.TabIndex = 26;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FrmOperatingSystemManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 426);
            Controls.Add(cmbManufacturers);
            Controls.Add(lblNotes);
            Controls.Add(txtNotes);
            Controls.Add(lblManufacturer);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(lbOperatingSystems);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(818, 473);
            MinimizeBox = false;
            Name = "FrmOperatingSystemManager";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Operating Systems Manager";
            contextMenuStripListbx.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnDelete;
        private ListBox lbOperatingSystems;
        private ComboBox cmbManufacturers;
        private Label lblNotes;
        private TextBox txtNotes;
        private Label lblManufacturer;
        private TextBox txtName;
        private Label lblName;
        private ContextMenuStrip contextMenuStripListbx;
        private ToolStripMenuItem deselectToolStripMenuItem;
    }
}
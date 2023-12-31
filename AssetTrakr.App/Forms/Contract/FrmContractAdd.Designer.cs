namespace AssetTrakr.App.Forms.Contract
{
    partial class FrmContractAdd
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
            tabControlContract = new TabControl();
            tabInformation = new TabPage();
            txtOrderRef = new TextBox();
            lblOrderRef = new Label();
            txtName = new TextBox();
            lblName = new Label();
            tabPeriods = new TabPage();
            btnAddSubPeriod = new Button();
            dgvPeriods = new DataGridView();
            cmsDgvRightClick = new ContextMenuStrip(components);
            columnSelectorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            tabNotes = new TabPage();
            txtDescription = new TextBox();
            tabAttachments = new TabPage();
            btnAddAttachment = new Button();
            dgvAttachments = new DataGridView();
            btnAdd = new Button();
            tabControlContract.SuspendLayout();
            tabInformation.SuspendLayout();
            tabPeriods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeriods).BeginInit();
            cmsDgvRightClick.SuspendLayout();
            tabNotes.SuspendLayout();
            tabAttachments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttachments).BeginInit();
            SuspendLayout();
            // 
            // tabControlContract
            // 
            tabControlContract.Controls.Add(tabInformation);
            tabControlContract.Controls.Add(tabPeriods);
            tabControlContract.Controls.Add(tabNotes);
            tabControlContract.Controls.Add(tabAttachments);
            tabControlContract.Location = new Point(20, 20);
            tabControlContract.Name = "tabControlContract";
            tabControlContract.SelectedIndex = 0;
            tabControlContract.Size = new Size(720, 426);
            tabControlContract.TabIndex = 0;
            // 
            // tabInformation
            // 
            tabInformation.Controls.Add(txtOrderRef);
            tabInformation.Controls.Add(lblOrderRef);
            tabInformation.Controls.Add(txtName);
            tabInformation.Controls.Add(lblName);
            tabInformation.Location = new Point(4, 29);
            tabInformation.Name = "tabInformation";
            tabInformation.Padding = new Padding(3);
            tabInformation.Size = new Size(712, 393);
            tabInformation.TabIndex = 0;
            tabInformation.Text = "Information";
            tabInformation.UseVisualStyleBackColor = true;
            // 
            // txtOrderRef
            // 
            txtOrderRef.Location = new Point(130, 64);
            txtOrderRef.Name = "txtOrderRef";
            txtOrderRef.Size = new Size(235, 27);
            txtOrderRef.TabIndex = 15;
            // 
            // lblOrderRef
            // 
            lblOrderRef.Location = new Point(21, 67);
            lblOrderRef.Name = "lblOrderRef";
            lblOrderRef.Size = new Size(103, 20);
            lblOrderRef.TabIndex = 14;
            lblOrderRef.Text = "Order Ref.";
            lblOrderRef.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 24);
            txtName.Name = "txtName";
            txtName.Size = new Size(235, 27);
            txtName.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.Location = new Point(21, 27);
            lblName.Name = "lblName";
            lblName.Size = new Size(103, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabPeriods
            // 
            tabPeriods.Controls.Add(btnAddSubPeriod);
            tabPeriods.Controls.Add(dgvPeriods);
            tabPeriods.Location = new Point(4, 29);
            tabPeriods.Name = "tabPeriods";
            tabPeriods.Padding = new Padding(3);
            tabPeriods.Size = new Size(712, 393);
            tabPeriods.TabIndex = 2;
            tabPeriods.Text = "Periods";
            tabPeriods.UseVisualStyleBackColor = true;
            // 
            // btnAddSubPeriod
            // 
            btnAddSubPeriod.Location = new Point(551, 20);
            btnAddSubPeriod.Name = "btnAddSubPeriod";
            btnAddSubPeriod.Size = new Size(138, 29);
            btnAddSubPeriod.TabIndex = 18;
            btnAddSubPeriod.Text = "Add Period";
            btnAddSubPeriod.UseVisualStyleBackColor = true;
            btnAddSubPeriod.Click += btnAddSubPeriod_Click;
            // 
            // dgvPeriods
            // 
            dgvPeriods.AllowUserToAddRows = false;
            dgvPeriods.AllowUserToDeleteRows = false;
            dgvPeriods.AllowUserToResizeColumns = false;
            dgvPeriods.AllowUserToResizeRows = false;
            dgvPeriods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPeriods.BackgroundColor = Color.White;
            dgvPeriods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeriods.ContextMenuStrip = cmsDgvRightClick;
            dgvPeriods.Location = new Point(20, 64);
            dgvPeriods.MultiSelect = false;
            dgvPeriods.Name = "dgvPeriods";
            dgvPeriods.ReadOnly = true;
            dgvPeriods.RowHeadersVisible = false;
            dgvPeriods.RowHeadersWidth = 51;
            dgvPeriods.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPeriods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeriods.ShowCellErrors = false;
            dgvPeriods.ShowCellToolTips = false;
            dgvPeriods.ShowEditingIcon = false;
            dgvPeriods.ShowRowErrors = false;
            dgvPeriods.Size = new Size(669, 300);
            dgvPeriods.TabIndex = 17;
            // 
            // cmsDgvRightClick
            // 
            cmsDgvRightClick.ImageScalingSize = new Size(20, 20);
            cmsDgvRightClick.Items.AddRange(new ToolStripItem[] { columnSelectorToolStripMenuItem, toolStripSeparator1, deleteToolStripMenuItem });
            cmsDgvRightClick.Name = "contextMenuStrip1";
            cmsDgvRightClick.Size = new Size(188, 58);
            // 
            // columnSelectorToolStripMenuItem
            // 
            columnSelectorToolStripMenuItem.Name = "columnSelectorToolStripMenuItem";
            columnSelectorToolStripMenuItem.Size = new Size(187, 24);
            columnSelectorToolStripMenuItem.Text = "Column Selector";
            columnSelectorToolStripMenuItem.Click += columnSelectorToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(184, 6);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(187, 24);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // tabNotes
            // 
            tabNotes.Controls.Add(txtDescription);
            tabNotes.Location = new Point(4, 29);
            tabNotes.Name = "tabNotes";
            tabNotes.Padding = new Padding(3);
            tabNotes.Size = new Size(712, 393);
            tabNotes.TabIndex = 1;
            tabNotes.Text = "Notes";
            tabNotes.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Location = new Point(3, 3);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(706, 387);
            txtDescription.TabIndex = 9;
            // 
            // tabAttachments
            // 
            tabAttachments.Controls.Add(btnAddAttachment);
            tabAttachments.Controls.Add(dgvAttachments);
            tabAttachments.Location = new Point(4, 29);
            tabAttachments.Name = "tabAttachments";
            tabAttachments.Padding = new Padding(3);
            tabAttachments.Size = new Size(712, 393);
            tabAttachments.TabIndex = 3;
            tabAttachments.Text = "Attachments";
            tabAttachments.UseVisualStyleBackColor = true;
            // 
            // btnAddAttachment
            // 
            btnAddAttachment.Location = new Point(551, 20);
            btnAddAttachment.Name = "btnAddAttachment";
            btnAddAttachment.Size = new Size(138, 29);
            btnAddAttachment.TabIndex = 15;
            btnAddAttachment.Text = "Add Attachment";
            btnAddAttachment.UseVisualStyleBackColor = true;
            btnAddAttachment.Click += btnAddAttachment_Click;
            // 
            // dgvAttachments
            // 
            dgvAttachments.AllowUserToAddRows = false;
            dgvAttachments.AllowUserToDeleteRows = false;
            dgvAttachments.AllowUserToResizeColumns = false;
            dgvAttachments.AllowUserToResizeRows = false;
            dgvAttachments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttachments.BackgroundColor = Color.White;
            dgvAttachments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttachments.ContextMenuStrip = cmsDgvRightClick;
            dgvAttachments.Location = new Point(20, 64);
            dgvAttachments.MultiSelect = false;
            dgvAttachments.Name = "dgvAttachments";
            dgvAttachments.ReadOnly = true;
            dgvAttachments.RowHeadersVisible = false;
            dgvAttachments.RowHeadersWidth = 51;
            dgvAttachments.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvAttachments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttachments.ShowCellErrors = false;
            dgvAttachments.ShowCellToolTips = false;
            dgvAttachments.ShowEditingIcon = false;
            dgvAttachments.ShowRowErrors = false;
            dgvAttachments.Size = new Size(669, 300);
            dgvAttachments.TabIndex = 14;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(642, 452);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Save";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // FrmContractAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 491);
            Controls.Add(btnAdd);
            Controls.Add(tabControlContract);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmContractAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add New Contract";
            tabControlContract.ResumeLayout(false);
            tabInformation.ResumeLayout(false);
            tabInformation.PerformLayout();
            tabPeriods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPeriods).EndInit();
            cmsDgvRightClick.ResumeLayout(false);
            tabNotes.ResumeLayout(false);
            tabNotes.PerformLayout();
            tabAttachments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttachments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlContract;
        private TabPage tabInformation;
        private TabPage tabNotes;
        private Button btnAdd;
        private TextBox txtDescription;
        private TabPage tabPeriods;
        private TabPage tabAttachments;
        private Label lblName;
        private TextBox txtName;
        private TextBox txtOrderRef;
        private Label lblOrderRef;
        private ContextMenuStrip cmsDgvRightClick;
        private ToolStripMenuItem columnSelectorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private DataGridView dgvPeriods;
        private DataGridView dgvAttachments;
        private Button btnAddSubPeriod;
        private Button btnAddAttachment;
    }
}
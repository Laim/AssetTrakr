namespace AssetTrakr.App.Forms.Contract
{
    partial class FrmContractModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContractModify));
            tabControlContract = new TabControl();
            tabInformation = new TabPage();
            txtAgreementId = new TextBox();
            lblAgreementId = new Label();
            cmbPaymentFrequency = new ComboBox();
            lblPaymentFrequency = new Label();
            lblPurchaseCost = new Label();
            txtOrderRef = new TextBox();
            numCost = new NumericUpDown();
            lblOrderRef = new Label();
            txtName = new TextBox();
            lblName = new Label();
            tabPeriods = new TabPage();
            btnAddSubPeriod = new Button();
            dgvPeriods = new DataGridView();
            cmsDgvRightClick = new ContextMenuStrip(components);
            columnSelectorToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            tabAttachments = new TabPage();
            btnAddAttachment = new Button();
            dgvAttachments = new DataGridView();
            tabNotes = new TabPage();
            txtDescription = new TextBox();
            btnAddUpdate = new Button();
            tabControlContract.SuspendLayout();
            tabInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
            tabPeriods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeriods).BeginInit();
            cmsDgvRightClick.SuspendLayout();
            tabAttachments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttachments).BeginInit();
            tabNotes.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlContract
            // 
            tabControlContract.Controls.Add(tabInformation);
            tabControlContract.Controls.Add(tabPeriods);
            tabControlContract.Controls.Add(tabAttachments);
            tabControlContract.Controls.Add(tabNotes);
            tabControlContract.Location = new Point(20, 20);
            tabControlContract.Name = "tabControlContract";
            tabControlContract.SelectedIndex = 0;
            tabControlContract.Size = new Size(732, 426);
            tabControlContract.TabIndex = 0;
            // 
            // tabInformation
            // 
            tabInformation.Controls.Add(txtAgreementId);
            tabInformation.Controls.Add(lblAgreementId);
            tabInformation.Controls.Add(cmbPaymentFrequency);
            tabInformation.Controls.Add(lblPaymentFrequency);
            tabInformation.Controls.Add(lblPurchaseCost);
            tabInformation.Controls.Add(txtOrderRef);
            tabInformation.Controls.Add(numCost);
            tabInformation.Controls.Add(lblOrderRef);
            tabInformation.Controls.Add(txtName);
            tabInformation.Controls.Add(lblName);
            tabInformation.Location = new Point(4, 29);
            tabInformation.Name = "tabInformation";
            tabInformation.Padding = new Padding(3);
            tabInformation.Size = new Size(724, 393);
            tabInformation.TabIndex = 0;
            tabInformation.Text = "Information";
            tabInformation.UseVisualStyleBackColor = true;
            // 
            // txtAgreementId
            // 
            txtAgreementId.Location = new Point(130, 64);
            txtAgreementId.Name = "txtAgreementId";
            txtAgreementId.Size = new Size(235, 27);
            txtAgreementId.TabIndex = 42;
            // 
            // lblAgreementId
            // 
            lblAgreementId.Location = new Point(21, 67);
            lblAgreementId.Name = "lblAgreementId";
            lblAgreementId.Size = new Size(103, 20);
            lblAgreementId.TabIndex = 41;
            lblAgreementId.Text = "Agreement ID";
            lblAgreementId.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbPaymentFrequency
            // 
            cmbPaymentFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentFrequency.FormattingEnabled = true;
            cmbPaymentFrequency.Location = new Point(130, 156);
            cmbPaymentFrequency.Name = "cmbPaymentFrequency";
            cmbPaymentFrequency.Size = new Size(235, 28);
            cmbPaymentFrequency.TabIndex = 40;
            // 
            // lblPaymentFrequency
            // 
            lblPaymentFrequency.Location = new Point(21, 159);
            lblPaymentFrequency.Name = "lblPaymentFrequency";
            lblPaymentFrequency.Size = new Size(103, 20);
            lblPaymentFrequency.TabIndex = 38;
            lblPaymentFrequency.Text = "Pay Frequency";
            lblPaymentFrequency.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPurchaseCost
            // 
            lblPurchaseCost.Location = new Point(21, 112);
            lblPurchaseCost.Name = "lblPurchaseCost";
            lblPurchaseCost.Size = new Size(103, 20);
            lblPurchaseCost.TabIndex = 37;
            lblPurchaseCost.Text = "Price";
            lblPurchaseCost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtOrderRef
            // 
            txtOrderRef.Location = new Point(477, 24);
            txtOrderRef.Name = "txtOrderRef";
            txtOrderRef.Size = new Size(235, 27);
            txtOrderRef.TabIndex = 15;
            // 
            // numCost
            // 
            numCost.DecimalPlaces = 2;
            numCost.Location = new Point(130, 110);
            numCost.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numCost.Name = "numCost";
            numCost.Size = new Size(235, 27);
            numCost.TabIndex = 36;
            // 
            // lblOrderRef
            // 
            lblOrderRef.Location = new Point(371, 27);
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
            tabPeriods.Size = new Size(724, 393);
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
            cmsDgvRightClick.Items.AddRange(new ToolStripItem[] { columnSelectorToolStripMenuItem, viewToolStripMenuItem, toolStripSeparator1, deleteToolStripMenuItem });
            cmsDgvRightClick.Name = "contextMenuStrip1";
            cmsDgvRightClick.Size = new Size(188, 82);
            cmsDgvRightClick.Opening += cmsDgvRightClick_Opening;
            // 
            // columnSelectorToolStripMenuItem
            // 
            columnSelectorToolStripMenuItem.Name = "columnSelectorToolStripMenuItem";
            columnSelectorToolStripMenuItem.Size = new Size(187, 24);
            columnSelectorToolStripMenuItem.Text = "Column Selector";
            columnSelectorToolStripMenuItem.Click += columnSelectorToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(187, 24);
            viewToolStripMenuItem.Text = "View";
            viewToolStripMenuItem.Click += viewToolStripMenuItem_Click;
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
            // tabAttachments
            // 
            tabAttachments.Controls.Add(btnAddAttachment);
            tabAttachments.Controls.Add(dgvAttachments);
            tabAttachments.Location = new Point(4, 29);
            tabAttachments.Name = "tabAttachments";
            tabAttachments.Padding = new Padding(3);
            tabAttachments.Size = new Size(724, 393);
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
            // tabNotes
            // 
            tabNotes.Controls.Add(txtDescription);
            tabNotes.Location = new Point(4, 29);
            tabNotes.Name = "tabNotes";
            tabNotes.Padding = new Padding(3);
            tabNotes.Size = new Size(724, 393);
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
            txtDescription.Size = new Size(718, 387);
            txtDescription.TabIndex = 9;
            // 
            // btnAddUpdate
            // 
            btnAddUpdate.Location = new Point(658, 452);
            btnAddUpdate.Name = "btnAddUpdate";
            btnAddUpdate.Size = new Size(94, 29);
            btnAddUpdate.TabIndex = 12;
            btnAddUpdate.Text = "Save";
            btnAddUpdate.UseVisualStyleBackColor = true;
            btnAddUpdate.Click += btnAddUpdate_Click;
            // 
            // FrmContractModify
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 491);
            Controls.Add(btnAddUpdate);
            Controls.Add(tabControlContract);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmContractModify";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add New Contract";
            tabControlContract.ResumeLayout(false);
            tabInformation.ResumeLayout(false);
            tabInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
            tabPeriods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPeriods).EndInit();
            cmsDgvRightClick.ResumeLayout(false);
            tabAttachments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttachments).EndInit();
            tabNotes.ResumeLayout(false);
            tabNotes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlContract;
        private TabPage tabInformation;
        private TabPage tabNotes;
        private Button btnAddUpdate;
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
        private Label lblPurchaseCost;
        private NumericUpDown numCost;
        private Label lblPaymentFrequency;
        private ComboBox cmbPaymentFrequency;
        private ToolStripMenuItem viewToolStripMenuItem;
        private TextBox txtAgreementId;
        private Label lblAgreementId;
    }
}
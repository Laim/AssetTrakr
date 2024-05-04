namespace AssetTrakr.App.Forms.License
{
    partial class FrmLicenseViewAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLicenseViewAll));
            cmsDgvRightClick = new ContextMenuStrip(components);
            columnSelectorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exportToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            viewToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            archiveOrUnarchiveToolStripMenuItem = new ToolStripMenuItem();
            dgvViewAll = new DataGridView();
            lblNoLicensesDescription = new Label();
            lblNoLicensesTitle = new Label();
            cmsDgvRightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvViewAll).BeginInit();
            SuspendLayout();
            // 
            // cmsDgvRightClick
            // 
            cmsDgvRightClick.ImageScalingSize = new Size(20, 20);
            cmsDgvRightClick.Items.AddRange(new ToolStripItem[] { columnSelectorToolStripMenuItem, toolStripSeparator1, exportToolStripMenuItem, toolStripSeparator2, viewToolStripMenuItem, editToolStripMenuItem, toolStripSeparator3, deleteToolStripMenuItem, archiveOrUnarchiveToolStripMenuItem });
            cmsDgvRightClick.Name = "contextMenuStrip1";
            cmsDgvRightClick.Size = new Size(188, 166);
            cmsDgvRightClick.Opening += cmsDgvRightClick_Opening;
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
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(187, 24);
            exportToolStripMenuItem.Text = "Export List";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(184, 6);
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(187, 24);
            viewToolStripMenuItem.Text = "View";
            viewToolStripMenuItem.Click += viewToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(187, 24);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(184, 6);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(187, 24);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // archiveOrUnarchiveToolStripMenuItem
            // 
            archiveOrUnarchiveToolStripMenuItem.Name = "archiveOrUnarchiveToolStripMenuItem";
            archiveOrUnarchiveToolStripMenuItem.Size = new Size(187, 24);
            archiveOrUnarchiveToolStripMenuItem.Text = "Archive";
            archiveOrUnarchiveToolStripMenuItem.Click += archiveOrUnarchiveToolStripMenuItem_Click;
            // 
            // dgvViewAll
            // 
            dgvViewAll.AllowUserToAddRows = false;
            dgvViewAll.AllowUserToDeleteRows = false;
            dgvViewAll.AllowUserToOrderColumns = true;
            dgvViewAll.AllowUserToResizeRows = false;
            dgvViewAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViewAll.BackgroundColor = Color.White;
            dgvViewAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvViewAll.ContextMenuStrip = cmsDgvRightClick;
            dgvViewAll.Dock = DockStyle.Fill;
            dgvViewAll.Location = new Point(0, 0);
            dgvViewAll.MultiSelect = false;
            dgvViewAll.Name = "dgvViewAll";
            dgvViewAll.ReadOnly = true;
            dgvViewAll.RowHeadersVisible = false;
            dgvViewAll.RowHeadersWidth = 51;
            dgvViewAll.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvViewAll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvViewAll.ShowCellErrors = false;
            dgvViewAll.ShowCellToolTips = false;
            dgvViewAll.ShowEditingIcon = false;
            dgvViewAll.ShowRowErrors = false;
            dgvViewAll.Size = new Size(1098, 661);
            dgvViewAll.TabIndex = 18;
            // 
            // lblNoLicensesDescription
            // 
            lblNoLicensesDescription.AutoSize = true;
            lblNoLicensesDescription.BackColor = Color.White;
            lblNoLicensesDescription.Location = new Point(286, 346);
            lblNoLicensesDescription.Name = "lblNoLicensesDescription";
            lblNoLicensesDescription.Size = new Size(553, 20);
            lblNoLicensesDescription.TabIndex = 23;
            lblNoLicensesDescription.Text = "No Licenses have been added to the system.  Add some Licenses to see them here.";
            // 
            // lblNoLicensesTitle
            // 
            lblNoLicensesTitle.AutoSize = true;
            lblNoLicensesTitle.BackColor = Color.White;
            lblNoLicensesTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoLicensesTitle.Location = new Point(471, 295);
            lblNoLicensesTitle.Name = "lblNoLicensesTitle";
            lblNoLicensesTitle.Size = new Size(182, 41);
            lblNoLicensesTitle.TabIndex = 22;
            lblNoLicensesTitle.Text = "No Licenses";
            // 
            // FrmLicenseViewAll
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1098, 661);
            Controls.Add(lblNoLicensesDescription);
            Controls.Add(lblNoLicensesTitle);
            Controls.Add(dgvViewAll);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1116, 708);
            Name = "FrmLicenseViewAll";
            StartPosition = FormStartPosition.CenterParent;
            Text = "View All Licenses";
            cmsDgvRightClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvViewAll).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip cmsDgvRightClick;
        private ToolStripMenuItem columnSelectorToolStripMenuItem;
        private DataGridView dgvViewAll;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exportToolStripMenuItem;
        private Label lblNoLicensesDescription;
        private Label lblNoLicensesTitle;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem archiveOrUnarchiveToolStripMenuItem;
    }
}
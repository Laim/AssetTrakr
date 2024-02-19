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
            cmsDgvRightClick = new ContextMenuStrip(components);
            columnSelectorToolStripMenuItem = new ToolStripMenuItem();
            dgvViewAll = new DataGridView();
            toolStripSeparator1 = new ToolStripSeparator();
            deleteLicenseToolStripMenuItem = new ToolStripMenuItem();
            cmsDgvRightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvViewAll).BeginInit();
            SuspendLayout();
            // 
            // cmsDgvRightClick
            // 
            cmsDgvRightClick.ImageScalingSize = new Size(20, 20);
            cmsDgvRightClick.Items.AddRange(new ToolStripItem[] { columnSelectorToolStripMenuItem, toolStripSeparator1, deleteLicenseToolStripMenuItem });
            cmsDgvRightClick.Name = "contextMenuStrip1";
            cmsDgvRightClick.Size = new Size(211, 86);
            // 
            // columnSelectorToolStripMenuItem
            // 
            columnSelectorToolStripMenuItem.Name = "columnSelectorToolStripMenuItem";
            columnSelectorToolStripMenuItem.Size = new Size(210, 24);
            columnSelectorToolStripMenuItem.Text = "Column Selector";
            columnSelectorToolStripMenuItem.Click += columnSelectorToolStripMenuItem_Click;
            // 
            // dgvViewAll
            // 
            dgvViewAll.AllowUserToAddRows = false;
            dgvViewAll.AllowUserToDeleteRows = false;
            dgvViewAll.AllowUserToResizeColumns = false;
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(207, 6);
            // 
            // deleteLicenseToolStripMenuItem
            // 
            deleteLicenseToolStripMenuItem.Name = "deleteLicenseToolStripMenuItem";
            deleteLicenseToolStripMenuItem.Size = new Size(210, 24);
            deleteLicenseToolStripMenuItem.Text = "Delete License";
            // 
            // FrmLicenseViewAll
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 661);
            Controls.Add(dgvViewAll);
            Name = "FrmLicenseViewAll";
            StartPosition = FormStartPosition.CenterParent;
            Text = "View All Licenses";
            cmsDgvRightClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvViewAll).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip cmsDgvRightClick;
        private ToolStripMenuItem columnSelectorToolStripMenuItem;
        private DataGridView dgvViewAll;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem deleteLicenseToolStripMenuItem;
    }
}
namespace AssetTrakr.App.Forms.Contract
{
    partial class FrmContractViewAll
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
            lblNoContractsDescription = new Label();
            lblNoContractsTitle = new Label();
            dgvViewAll = new DataGridView();
            cmsDgvRightClick = new ContextMenuStrip(components);
            columnSelectorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exportToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            viewToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvViewAll).BeginInit();
            cmsDgvRightClick.SuspendLayout();
            SuspendLayout();
            // 
            // lblNoContractsDescription
            // 
            lblNoContractsDescription.AutoSize = true;
            lblNoContractsDescription.BackColor = Color.Transparent;
            lblNoContractsDescription.Location = new Point(265, 346);
            lblNoContractsDescription.Name = "lblNoContractsDescription";
            lblNoContractsDescription.Size = new Size(569, 20);
            lblNoContractsDescription.TabIndex = 26;
            lblNoContractsDescription.Text = "No Contracts have been added to the system.  Add some Contracts to see them here.";
            // 
            // lblNoContractsTitle
            // 
            lblNoContractsTitle.AutoSize = true;
            lblNoContractsTitle.BackColor = Color.Transparent;
            lblNoContractsTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoContractsTitle.Location = new Point(448, 295);
            lblNoContractsTitle.Name = "lblNoContractsTitle";
            lblNoContractsTitle.Size = new Size(202, 41);
            lblNoContractsTitle.TabIndex = 25;
            lblNoContractsTitle.Text = "No Contracts";
            // 
            // dgvViewAll
            // 
            dgvViewAll.AllowUserToAddRows = false;
            dgvViewAll.AllowUserToDeleteRows = false;
            dgvViewAll.AllowUserToOrderColumns = true;
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
            dgvViewAll.TabIndex = 24;
            // 
            // cmsDgvRightClick
            // 
            cmsDgvRightClick.ImageScalingSize = new Size(20, 20);
            cmsDgvRightClick.Items.AddRange(new ToolStripItem[] { columnSelectorToolStripMenuItem, toolStripSeparator1, exportToolStripMenuItem, toolStripSeparator2, viewToolStripMenuItem, editToolStripMenuItem });
            cmsDgvRightClick.Name = "contextMenuStrip1";
            cmsDgvRightClick.Size = new Size(188, 112);
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
            // FrmContractViewAll
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1098, 661);
            Controls.Add(lblNoContractsDescription);
            Controls.Add(lblNoContractsTitle);
            Controls.Add(dgvViewAll);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmContractViewAll";
            StartPosition = FormStartPosition.CenterParent;
            Text = "View All Contracts";
            ((System.ComponentModel.ISupportInitialize)dgvViewAll).EndInit();
            cmsDgvRightClick.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNoContractsDescription;
        private Label lblNoContractsTitle;
        private DataGridView dgvViewAll;
        private ContextMenuStrip cmsDgvRightClick;
        private ToolStripMenuItem columnSelectorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
    }
}
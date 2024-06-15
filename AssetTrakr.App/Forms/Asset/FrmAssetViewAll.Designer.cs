namespace AssetTrakr.App.Forms.Asset
{
    partial class FrmAssetViewAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAssetViewAll));
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
            lblNoAssetsTitle = new Label();
            lblNoAssetsDescription = new Label();
            sfDgViewAll = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            cmsDgvRightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDgViewAll).BeginInit();
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
            // lblNoAssetsTitle
            // 
            lblNoAssetsTitle.AutoSize = true;
            lblNoAssetsTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoAssetsTitle.Location = new Point(471, 295);
            lblNoAssetsTitle.Name = "lblNoAssetsTitle";
            lblNoAssetsTitle.Size = new Size(156, 41);
            lblNoAssetsTitle.TabIndex = 20;
            lblNoAssetsTitle.Text = "No Assets";
            // 
            // lblNoAssetsDescription
            // 
            lblNoAssetsDescription.AutoSize = true;
            lblNoAssetsDescription.Location = new Point(286, 346);
            lblNoAssetsDescription.Name = "lblNoAssetsDescription";
            lblNoAssetsDescription.Size = new Size(527, 20);
            lblNoAssetsDescription.TabIndex = 21;
            lblNoAssetsDescription.Text = "No Assets have been added to the system.  Add some Assets to see them here.";
            // 
            // sfDgViewAll
            // 
            sfDgViewAll.AccessibleName = "Table";
            sfDgViewAll.AllowEditing = false;
            sfDgViewAll.AllowFiltering = true;
            sfDgViewAll.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            sfDgViewAll.ContextMenuStrip = cmsDgvRightClick;
            sfDgViewAll.Dock = DockStyle.Fill;
            sfDgViewAll.Location = new Point(0, 0);
            sfDgViewAll.Name = "sfDgViewAll";
            sfDgViewAll.PreviewRowHeight = 35;
            sfDgViewAll.ShowBusyIndicator = true;
            sfDgViewAll.ShowGroupDropArea = true;
            sfDgViewAll.ShowHeaderToolTip = true;
            sfDgViewAll.Size = new Size(1098, 661);
            sfDgViewAll.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDgViewAll.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDgViewAll.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDgViewAll.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDgViewAll.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDgViewAll.TabIndex = 28;
            sfDgViewAll.Text = "sfDataGrid1";
            sfDgViewAll.SelectionChanged += sfDgViewAll_SelectionChanged;
            sfDgViewAll.DataSourceChanged += sfDgViewAll_DataSourceChanged;
            // 
            // FrmAssetViewAll
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1098, 661);
            Controls.Add(sfDgViewAll);
            Controls.Add(lblNoAssetsDescription);
            Controls.Add(lblNoAssetsTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "FrmAssetViewAll";
            StartPosition = FormStartPosition.CenterParent;
            Text = "View All Assets";
            cmsDgvRightClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sfDgViewAll).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip cmsDgvRightClick;
        private ToolStripMenuItem columnSelectorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private Label lblNoAssetsTitle;
        private Label lblNoAssetsDescription;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem archiveOrUnarchiveToolStripMenuItem;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDgViewAll;
    }
}
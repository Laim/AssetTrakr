namespace AssetTrakr.App.Forms.Miscellaneous
{
    partial class FrmActionLog
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
            dgvActionLog = new DataGridView();
            cmsDgvRightClick = new ContextMenuStrip(components);
            columnSelectorToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvActionLog).BeginInit();
            cmsDgvRightClick.SuspendLayout();
            SuspendLayout();
            // 
            // dgvActionLog
            // 
            dgvActionLog.AllowUserToAddRows = false;
            dgvActionLog.AllowUserToDeleteRows = false;
            dgvActionLog.AllowUserToResizeColumns = false;
            dgvActionLog.AllowUserToResizeRows = false;
            dgvActionLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActionLog.BackgroundColor = Color.White;
            dgvActionLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActionLog.ContextMenuStrip = cmsDgvRightClick;
            dgvActionLog.Dock = DockStyle.Fill;
            dgvActionLog.Location = new Point(0, 0);
            dgvActionLog.MultiSelect = false;
            dgvActionLog.Name = "dgvActionLog";
            dgvActionLog.ReadOnly = true;
            dgvActionLog.RowHeadersVisible = false;
            dgvActionLog.RowHeadersWidth = 51;
            dgvActionLog.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvActionLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActionLog.ShowCellErrors = false;
            dgvActionLog.ShowCellToolTips = false;
            dgvActionLog.ShowEditingIcon = false;
            dgvActionLog.ShowRowErrors = false;
            dgvActionLog.Size = new Size(800, 450);
            dgvActionLog.TabIndex = 19;
            // 
            // cmsDgvRightClick
            // 
            cmsDgvRightClick.ImageScalingSize = new Size(20, 20);
            cmsDgvRightClick.Items.AddRange(new ToolStripItem[] { columnSelectorToolStripMenuItem });
            cmsDgvRightClick.Name = "contextMenuStrip1";
            cmsDgvRightClick.Size = new Size(188, 28);
            // 
            // columnSelectorToolStripMenuItem
            // 
            columnSelectorToolStripMenuItem.Name = "columnSelectorToolStripMenuItem";
            columnSelectorToolStripMenuItem.Size = new Size(187, 24);
            columnSelectorToolStripMenuItem.Text = "Column Selector";
            // 
            // frmActionLog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvActionLog);
            MinimizeBox = false;
            Name = "frmActionLog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Action Log";
            ((System.ComponentModel.ISupportInitialize)dgvActionLog).EndInit();
            cmsDgvRightClick.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvActionLog;
        private ContextMenuStrip cmsDgvRightClick;
        private ToolStripMenuItem columnSelectorToolStripMenuItem;
    }
}
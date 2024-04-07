namespace AssetTrakr.App.Forms.Shared
{
    partial class FrmReportRunner
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
            dgvReportOutput = new DataGridView();
            cmsDgvRightClick = new ContextMenuStrip(components);
            columnSelectorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exportToolStripMenuItem = new ToolStripMenuItem();
            cmbReports = new ComboBox();
            lblReportPicker = new Label();
            btnRunReport = new Button();
            cmbCritera = new ComboBox();
            lblCritera = new Label();
            lblDescription = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReportOutput).BeginInit();
            cmsDgvRightClick.SuspendLayout();
            SuspendLayout();
            // 
            // dgvReportOutput
            // 
            dgvReportOutput.AllowUserToAddRows = false;
            dgvReportOutput.AllowUserToDeleteRows = false;
            dgvReportOutput.AllowUserToOrderColumns = true;
            dgvReportOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReportOutput.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportOutput.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvReportOutput.BackgroundColor = Color.White;
            dgvReportOutput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportOutput.ContextMenuStrip = cmsDgvRightClick;
            dgvReportOutput.Location = new Point(0, 85);
            dgvReportOutput.MultiSelect = false;
            dgvReportOutput.Name = "dgvReportOutput";
            dgvReportOutput.ReadOnly = true;
            dgvReportOutput.RowHeadersVisible = false;
            dgvReportOutput.RowHeadersWidth = 51;
            dgvReportOutput.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvReportOutput.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReportOutput.ShowCellErrors = false;
            dgvReportOutput.ShowCellToolTips = false;
            dgvReportOutput.ShowEditingIcon = false;
            dgvReportOutput.ShowRowErrors = false;
            dgvReportOutput.Size = new Size(1169, 586);
            dgvReportOutput.TabIndex = 19;
            // 
            // cmsDgvRightClick
            // 
            cmsDgvRightClick.ImageScalingSize = new Size(20, 20);
            cmsDgvRightClick.Items.AddRange(new ToolStripItem[] { columnSelectorToolStripMenuItem, toolStripSeparator1, exportToolStripMenuItem });
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
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(187, 24);
            exportToolStripMenuItem.Text = "Export List";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // cmbReports
            // 
            cmbReports.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReports.FormattingEnabled = true;
            cmbReports.Location = new Point(80, 17);
            cmbReports.Name = "cmbReports";
            cmbReports.Size = new Size(472, 28);
            cmbReports.TabIndex = 20;
            cmbReports.SelectedIndexChanged += cmbReports_SelectedIndexChanged;
            // 
            // lblReportPicker
            // 
            lblReportPicker.AutoSize = true;
            lblReportPicker.Location = new Point(20, 20);
            lblReportPicker.Name = "lblReportPicker";
            lblReportPicker.Size = new Size(54, 20);
            lblReportPicker.TabIndex = 21;
            lblReportPicker.Text = "Report";
            // 
            // btnRunReport
            // 
            btnRunReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRunReport.Location = new Point(1063, 16);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new Size(94, 29);
            btnRunReport.TabIndex = 22;
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = true;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // cmbCritera
            // 
            cmbCritera.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCritera.Enabled = false;
            cmbCritera.FormattingEnabled = true;
            cmbCritera.Location = new Point(80, 51);
            cmbCritera.Name = "cmbCritera";
            cmbCritera.Size = new Size(472, 28);
            cmbCritera.TabIndex = 23;
            // 
            // lblCritera
            // 
            lblCritera.AutoSize = true;
            lblCritera.Location = new Point(21, 54);
            lblCritera.Name = "lblCritera";
            lblCritera.Size = new Size(53, 20);
            lblCritera.TabIndex = 24;
            lblCritera.Text = "Critera";
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(558, 20);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(399, 59);
            lblDescription.TabIndex = 25;
            // 
            // FrmReportRunner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 671);
            Controls.Add(lblDescription);
            Controls.Add(lblCritera);
            Controls.Add(cmbCritera);
            Controls.Add(btnRunReport);
            Controls.Add(lblReportPicker);
            Controls.Add(cmbReports);
            Controls.Add(dgvReportOutput);
            Name = "FrmReportRunner";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Report Runner";
            ((System.ComponentModel.ISupportInitialize)dgvReportOutput).EndInit();
            cmsDgvRightClick.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReportOutput;
        private ComboBox cmbReports;
        private Label lblReportPicker;
        private Button btnRunReport;
        private ComboBox cmbCritera;
        private Label lblCritera;
        private Label lblDescription;
        private ContextMenuStrip cmsDgvRightClick;
        private ToolStripMenuItem columnSelectorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exportToolStripMenuItem;
    }
}
namespace AssetTrakr.App.Forms.Shared
{
    partial class FrmColumnSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmColumnSelector));
            lblSelectedColumns = new Label();
            lblAvailableColumns = new Label();
            lbSelectedColumns = new ListBox();
            lbAvailableColumns = new ListBox();
            btnRemoveFromSelected = new Button();
            btnAddToSelected = new Button();
            SuspendLayout();
            // 
            // lblSelectedColumns
            // 
            lblSelectedColumns.AutoSize = true;
            lblSelectedColumns.Location = new Point(20, 20);
            lblSelectedColumns.Name = "lblSelectedColumns";
            lblSelectedColumns.Size = new Size(127, 20);
            lblSelectedColumns.TabIndex = 0;
            lblSelectedColumns.Text = "Selected Columns";
            // 
            // lblAvailableColumns
            // 
            lblAvailableColumns.AutoSize = true;
            lblAvailableColumns.Location = new Point(280, 20);
            lblAvailableColumns.Name = "lblAvailableColumns";
            lblAvailableColumns.Size = new Size(132, 20);
            lblAvailableColumns.TabIndex = 1;
            lblAvailableColumns.Text = "Available Columns";
            // 
            // lbSelectedColumns
            // 
            lbSelectedColumns.FormattingEnabled = true;
            lbSelectedColumns.Location = new Point(20, 57);
            lbSelectedColumns.Name = "lbSelectedColumns";
            lbSelectedColumns.Size = new Size(218, 144);
            lbSelectedColumns.TabIndex = 2;
            // 
            // lbAvailableColumns
            // 
            lbAvailableColumns.FormattingEnabled = true;
            lbAvailableColumns.Location = new Point(280, 57);
            lbAvailableColumns.Name = "lbAvailableColumns";
            lbAvailableColumns.Size = new Size(218, 144);
            lbAvailableColumns.TabIndex = 3;
            // 
            // btnRemoveFromSelected
            // 
            btnRemoveFromSelected.Location = new Point(244, 96);
            btnRemoveFromSelected.Name = "btnRemoveFromSelected";
            btnRemoveFromSelected.Size = new Size(30, 29);
            btnRemoveFromSelected.TabIndex = 4;
            btnRemoveFromSelected.Text = ">";
            btnRemoveFromSelected.UseVisualStyleBackColor = true;
            btnRemoveFromSelected.Click += btnRemoveFromSelected_Click;
            // 
            // btnAddToSelected
            // 
            btnAddToSelected.Location = new Point(244, 131);
            btnAddToSelected.Name = "btnAddToSelected";
            btnAddToSelected.Size = new Size(30, 29);
            btnAddToSelected.TabIndex = 5;
            btnAddToSelected.Text = "<";
            btnAddToSelected.UseVisualStyleBackColor = true;
            btnAddToSelected.Click += btnAddToSelected_Click;
            // 
            // FrmColumnSelector
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 220);
            Controls.Add(btnAddToSelected);
            Controls.Add(btnRemoveFromSelected);
            Controls.Add(lbAvailableColumns);
            Controls.Add(lbSelectedColumns);
            Controls.Add(lblAvailableColumns);
            Controls.Add(lblSelectedColumns);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmColumnSelector";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Column Selector";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSelectedColumns;
        private Label lblAvailableColumns;
        private ListBox lbSelectedColumns;
        private ListBox lbAvailableColumns;
        private Button btnRemoveFromSelected;
        private Button btnAddToSelected;
    }
}
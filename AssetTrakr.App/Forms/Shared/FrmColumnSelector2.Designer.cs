namespace AssetTrakr.App.Forms.Shared
{
    partial class FrmColumnSelector2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmColumnSelector2));
            chkLbColumns = new CheckedListBox();
            SuspendLayout();
            // 
            // chkLbColumns
            // 
            chkLbColumns.CheckOnClick = true;
            chkLbColumns.FormattingEnabled = true;
            chkLbColumns.Location = new Point(20, 20);
            chkLbColumns.Name = "chkLbColumns";
            chkLbColumns.Size = new Size(240, 356);
            chkLbColumns.TabIndex = 0;
            chkLbColumns.ThreeDCheckBoxes = true;
            // 
            // FrmColumnSelector2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(281, 394);
            Controls.Add(chkLbColumns);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmColumnSelector2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Column Selector";
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox chkLbColumns;
    }
}
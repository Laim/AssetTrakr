namespace AssetTrakr.App.Forms.Asset
{
    partial class FrmAssetHardDriveAdd
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
            lblName = new Label();
            lblSizeInBytes = new Label();
            lblManufacturer = new Label();
            lnkAddManufacturer = new LinkLabel();
            cmbManufacturers = new ComboBox();
            txtName = new TextBox();
            numSizeBytes = new NumericUpDown();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)numSizeBytes).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(106, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSizeInBytes
            // 
            lblSizeInBytes.Location = new Point(20, 54);
            lblSizeInBytes.Name = "lblSizeInBytes";
            lblSizeInBytes.Size = new Size(106, 20);
            lblSizeInBytes.TabIndex = 1;
            lblSizeInBytes.Text = "Size (GB)";
            lblSizeInBytes.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblManufacturer
            // 
            lblManufacturer.Location = new Point(20, 86);
            lblManufacturer.Name = "lblManufacturer";
            lblManufacturer.Size = new Size(106, 20);
            lblManufacturer.TabIndex = 2;
            lblManufacturer.Text = "Manufacturer";
            lblManufacturer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lnkAddManufacturer
            // 
            lnkAddManufacturer.AutoSize = true;
            lnkAddManufacturer.Location = new Point(363, 86);
            lnkAddManufacturer.Name = "lnkAddManufacturer";
            lnkAddManufacturer.Size = new Size(63, 20);
            lnkAddManufacturer.TabIndex = 42;
            lnkAddManufacturer.TabStop = true;
            lnkAddManufacturer.Text = "Manage";
            lnkAddManufacturer.Visible = false;
            lnkAddManufacturer.LinkClicked += lnkAddManufacturer_LinkClicked;
            // 
            // cmbManufacturers
            // 
            cmbManufacturers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbManufacturers.FormattingEnabled = true;
            cmbManufacturers.Location = new Point(132, 83);
            cmbManufacturers.Name = "cmbManufacturers";
            cmbManufacturers.Size = new Size(225, 28);
            cmbManufacturers.TabIndex = 41;
            // 
            // txtName
            // 
            txtName.Location = new Point(132, 17);
            txtName.Name = "txtName";
            txtName.Size = new Size(225, 27);
            txtName.TabIndex = 43;
            // 
            // numSizeBytes
            // 
            numSizeBytes.Location = new Point(132, 50);
            numSizeBytes.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numSizeBytes.Name = "numSizeBytes";
            numSizeBytes.Size = new Size(225, 27);
            numSizeBytes.TabIndex = 44;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(263, 118);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 45;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // FrmAssetHardDriveAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 159);
            Controls.Add(btnAdd);
            Controls.Add(numSizeBytes);
            Controls.Add(txtName);
            Controls.Add(lnkAddManufacturer);
            Controls.Add(cmbManufacturers);
            Controls.Add(lblManufacturer);
            Controls.Add(lblSizeInBytes);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAssetHardDriveAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add New Hard Drive";
            ((System.ComponentModel.ISupportInitialize)numSizeBytes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblSizeInBytes;
        private Label lblManufacturer;
        private LinkLabel lnkAddManufacturer;
        private ComboBox cmbManufacturers;
        private TextBox txtName;
        private NumericUpDown numSizeBytes;
        private Button btnAdd;
    }
}
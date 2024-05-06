namespace AssetTrakr.App.Forms.Asset
{
    partial class FrmAssetNetworkAdapterAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAssetNetworkAdapterAdd));
            lblName = new Label();
            txtName = new TextBox();
            lblIpAddress = new Label();
            txtIpAddress = new TextBox();
            txtMacAddress = new TextBox();
            lblMacAddress = new Label();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(96, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Location = new Point(122, 17);
            txtName.Name = "txtName";
            txtName.Size = new Size(225, 27);
            txtName.TabIndex = 1;
            // 
            // lblIpAddress
            // 
            lblIpAddress.Location = new Point(20, 53);
            lblIpAddress.Name = "lblIpAddress";
            lblIpAddress.Size = new Size(96, 20);
            lblIpAddress.TabIndex = 2;
            lblIpAddress.Text = "IP Address";
            lblIpAddress.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtIpAddress
            // 
            txtIpAddress.Location = new Point(122, 50);
            txtIpAddress.Name = "txtIpAddress";
            txtIpAddress.Size = new Size(225, 27);
            txtIpAddress.TabIndex = 3;
            // 
            // txtMacAddress
            // 
            txtMacAddress.Location = new Point(122, 83);
            txtMacAddress.Name = "txtMacAddress";
            txtMacAddress.Size = new Size(225, 27);
            txtMacAddress.TabIndex = 4;
            // 
            // lblMacAddress
            // 
            lblMacAddress.Location = new Point(20, 86);
            lblMacAddress.Name = "lblMacAddress";
            lblMacAddress.Size = new Size(96, 20);
            lblMacAddress.TabIndex = 5;
            lblMacAddress.Text = "Mac Address";
            lblMacAddress.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(253, 116);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // FrmAssetNetworkAdapterAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 152);
            Controls.Add(btnAdd);
            Controls.Add(lblMacAddress);
            Controls.Add(txtMacAddress);
            Controls.Add(txtIpAddress);
            Controls.Add(lblIpAddress);
            Controls.Add(txtName);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAssetNetworkAdapterAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add New Network Adapter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblIpAddress;
        private TextBox txtIpAddress;
        private TextBox txtMacAddress;
        private Label lblMacAddress;
        private Button btnAdd;
    }
}
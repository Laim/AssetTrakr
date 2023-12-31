namespace AssetTrakr.App.Forms
{
    partial class FrmMain
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
            menuStrip1 = new MenuStrip();
            licensesToolStripMenuItem = new ToolStripMenuItem();
            addLicenseToolStripMenuItem = new ToolStripMenuItem();
            viewLicensesToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            textBox1 = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { licensesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1262, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // licensesToolStripMenuItem
            // 
            licensesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addLicenseToolStripMenuItem, viewLicensesToolStripMenuItem });
            licensesToolStripMenuItem.Name = "licensesToolStripMenuItem";
            licensesToolStripMenuItem.Size = new Size(77, 24);
            licensesToolStripMenuItem.Text = "Licenses";
            // 
            // addLicenseToolStripMenuItem
            // 
            addLicenseToolStripMenuItem.Name = "addLicenseToolStripMenuItem";
            addLicenseToolStripMenuItem.Size = new Size(182, 26);
            addLicenseToolStripMenuItem.Text = "Add License";
            addLicenseToolStripMenuItem.Click += addLicenseToolStripMenuItem_Click;
            // 
            // viewLicensesToolStripMenuItem
            // 
            viewLicensesToolStripMenuItem.Name = "viewLicensesToolStripMenuItem";
            viewLicensesToolStripMenuItem.Size = new Size(182, 26);
            viewLicensesToolStripMenuItem.Text = "View Licenses";
            viewLicensesToolStripMenuItem.Click += viewLicensesToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Location = new Point(188, 219);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(288, 219);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1280, 720);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AssetTrakr &bullet; Dashboard";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem licensesToolStripMenuItem;
        private ToolStripMenuItem addLicenseToolStripMenuItem;
        private ToolStripMenuItem viewLicensesToolStripMenuItem;
        private Button button1;
        private TextBox textBox1;
    }
}
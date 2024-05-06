namespace AssetTrakr.App.Forms.Shared
{
    partial class FrmPeriodAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPeriodAdd));
            dtSubEnd = new DateTimePicker();
            lblSubEndDate = new Label();
            dtSubStart = new DateTimePicker();
            lblSubStartDate = new Label();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // dtSubEnd
            // 
            dtSubEnd.Location = new Point(366, 26);
            dtSubEnd.MinDate = new DateTime(1975, 1, 1, 0, 0, 0, 0);
            dtSubEnd.Name = "dtSubEnd";
            dtSubEnd.Size = new Size(181, 27);
            dtSubEnd.TabIndex = 18;
            // 
            // lblSubEndDate
            // 
            lblSubEndDate.AutoSize = true;
            lblSubEndDate.Location = new Point(290, 29);
            lblSubEndDate.Name = "lblSubEndDate";
            lblSubEndDate.Size = new Size(70, 20);
            lblSubEndDate.TabIndex = 17;
            lblSubEndDate.Text = "End Date";
            // 
            // dtSubStart
            // 
            dtSubStart.Location = new Point(94, 26);
            dtSubStart.MinDate = new DateTime(1975, 1, 1, 0, 0, 0, 0);
            dtSubStart.Name = "dtSubStart";
            dtSubStart.Size = new Size(181, 27);
            dtSubStart.TabIndex = 16;
            // 
            // lblSubStartDate
            // 
            lblSubStartDate.AutoSize = true;
            lblSubStartDate.Location = new Point(12, 29);
            lblSubStartDate.Name = "lblSubStartDate";
            lblSubStartDate.Size = new Size(76, 20);
            lblSubStartDate.TabIndex = 15;
            lblSubStartDate.Text = "Start Date";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(453, 68);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 20;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // FrmPeriodAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(567, 113);
            Controls.Add(btnAdd);
            Controls.Add(dtSubEnd);
            Controls.Add(lblSubEndDate);
            Controls.Add(dtSubStart);
            Controls.Add(lblSubStartDate);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPeriodAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add New Period";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dtSubEnd;
        private Label lblSubEndDate;
        private DateTimePicker dtSubStart;
        private Label lblSubStartDate;
        private Button btnAdd;
    }
}
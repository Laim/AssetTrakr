namespace AssetTrakr.App.Forms.Miscellaneous
{
    partial class FrmSystemSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSystemSettings));
            dgvSystemSettings = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            categoryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            settingParentTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
            settingValueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            defaultSettingValueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            systemSettingBindingSource = new BindingSource(components);
            btnSave = new Button();
            cmbCategory = new ComboBox();
            lblCategory = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSystemSettings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)systemSettingBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvSystemSettings
            // 
            dgvSystemSettings.AllowUserToAddRows = false;
            dgvSystemSettings.AllowUserToDeleteRows = false;
            dgvSystemSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSystemSettings.AutoGenerateColumns = false;
            dgvSystemSettings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSystemSettings.BackgroundColor = Color.White;
            dgvSystemSettings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSystemSettings.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, categoryDataGridViewTextBoxColumn, settingParentTypeDataGridViewTextBoxColumn, dataGridViewCheckBoxColumn1, dataGridViewCheckBoxColumn2, settingValueDataGridViewTextBoxColumn, defaultSettingValueDataGridViewTextBoxColumn });
            dgvSystemSettings.DataSource = systemSettingBindingSource;
            dgvSystemSettings.Location = new Point(0, 56);
            dgvSystemSettings.Name = "dgvSystemSettings";
            dgvSystemSettings.RowHeadersWidth = 51;
            dgvSystemSettings.Size = new Size(1010, 435);
            dgvSystemSettings.TabIndex = 0;
            dgvSystemSettings.CellValueChanged += dgvSystemSettings_CellValueChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            dataGridViewTextBoxColumn1.HeaderText = "Name";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 78;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Description";
            dataGridViewTextBoxColumn2.HeaderText = "Description";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 114;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            categoryDataGridViewTextBoxColumn.MinimumWidth = 6;
            categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            categoryDataGridViewTextBoxColumn.ReadOnly = true;
            categoryDataGridViewTextBoxColumn.Visible = false;
            categoryDataGridViewTextBoxColumn.Width = 98;
            // 
            // settingParentTypeDataGridViewTextBoxColumn
            // 
            settingParentTypeDataGridViewTextBoxColumn.DataPropertyName = "SettingParentType";
            settingParentTypeDataGridViewTextBoxColumn.HeaderText = "Type";
            settingParentTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            settingParentTypeDataGridViewTextBoxColumn.Name = "settingParentTypeDataGridViewTextBoxColumn";
            settingParentTypeDataGridViewTextBoxColumn.ReadOnly = true;
            settingParentTypeDataGridViewTextBoxColumn.Width = 69;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "Enabled";
            dataGridViewCheckBoxColumn1.HeaderText = "Enabled";
            dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.Width = 69;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            dataGridViewCheckBoxColumn2.DataPropertyName = "DefaultEnabled";
            dataGridViewCheckBoxColumn2.HeaderText = "Default Enabled";
            dataGridViewCheckBoxColumn2.MinimumWidth = 6;
            dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            dataGridViewCheckBoxColumn2.ReadOnly = true;
            dataGridViewCheckBoxColumn2.Visible = false;
            dataGridViewCheckBoxColumn2.Width = 122;
            // 
            // settingValueDataGridViewTextBoxColumn
            // 
            settingValueDataGridViewTextBoxColumn.DataPropertyName = "SettingValue";
            settingValueDataGridViewTextBoxColumn.HeaderText = "Setting Value";
            settingValueDataGridViewTextBoxColumn.MinimumWidth = 6;
            settingValueDataGridViewTextBoxColumn.Name = "settingValueDataGridViewTextBoxColumn";
            settingValueDataGridViewTextBoxColumn.Width = 125;
            // 
            // defaultSettingValueDataGridViewTextBoxColumn
            // 
            defaultSettingValueDataGridViewTextBoxColumn.DataPropertyName = "DefaultSettingValue";
            defaultSettingValueDataGridViewTextBoxColumn.HeaderText = "Default Setting Value";
            defaultSettingValueDataGridViewTextBoxColumn.MinimumWidth = 6;
            defaultSettingValueDataGridViewTextBoxColumn.Name = "defaultSettingValueDataGridViewTextBoxColumn";
            defaultSettingValueDataGridViewTextBoxColumn.ReadOnly = true;
            defaultSettingValueDataGridViewTextBoxColumn.Visible = false;
            defaultSettingValueDataGridViewTextBoxColumn.Width = 178;
            // 
            // systemSettingBindingSource
            // 
            systemSettingBindingSource.DataSource = typeof(Models.System.SystemSetting);
            // 
            // btnSave
            // 
            btnSave.Location = new Point(904, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(155, 17);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(267, 28);
            cmbCategory.TabIndex = 2;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(20, 20);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(129, 20);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Settings Category:";
            // 
            // FrmSystemSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1010, 491);
            Controls.Add(lblCategory);
            Controls.Add(cmbCategory);
            Controls.Add(btnSave);
            Controls.Add(dgvSystemSettings);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "FrmSystemSettings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "System Settings";
            ((System.ComponentModel.ISupportInitialize)dgvSystemSettings).EndInit();
            ((System.ComponentModel.ISupportInitialize)systemSettingBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSystemSettings;
        private Button btnSave;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn defaultEnabledDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn nonBoolValueDataGridViewTextBoxColumn;
        private ComboBox cmbCategory;
        private Label lblCategory;
        private BindingSource systemSettingBindingSource;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn settingParentTypeDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private DataGridViewTextBoxColumn settingValueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn defaultSettingValueDataGridViewTextBoxColumn;
    }
}
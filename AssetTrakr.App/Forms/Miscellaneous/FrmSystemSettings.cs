using AssetTrakr.Database;
using AssetTrakr.Logging;
using AssetTrakr.Models.System;
using AssetTrakr.Utils.Enums;
using AssetTrakr.WinForms.ActionLog;
using Microsoft.EntityFrameworkCore;

namespace AssetTrakr.App.Forms.Miscellaneous
{
    public partial class FrmSystemSettings : Form
    {

        private DatabaseContext _dbContext;
        private SystemSettingsCategory _category;

        public FrmSystemSettings()
        {
            InitializeComponent();

            _dbContext ??= new();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cmbCategory.DataSource = _dbContext.SystemSettings.GroupBy(a => a.Category).Select(x => x.First()).ToList();
            cmbCategory.DisplayMember = "Category";
            cmbCategory.ValueMember = "Category";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                _dbContext.ChangeTracker.DetectChanges();
                ActionLogMethods.Updated(_dbContext, ActionAlertCategory.System, "System Settings");

                if (_dbContext.SaveChanges() > 0)
                {
                    MessageBox.Show($"Settings Saved", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmSystemSettings>($"{ex}");
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            _category = SystemSettingsCategory.Alert;

            if (sender is ComboBox cmb && cmb.SelectedItem != null)
            {
                if (cmb.SelectedItem != null)
                {
                    var temp = (SystemSetting)cmb.SelectedItem;

                    _category = temp.Category;
                }

            }

            _dbContext = new();

            // need to load the data before binding it otherwise it never appears lol
            _dbContext.SystemSettings.Where(c => c.Category == _category).Load();

            dgvSystemSettings.DataSource = _dbContext.SystemSettings.Local.ToBindingList();

            CategoryColumnHider(_category);
        }

        private void CategoryColumnHider(SystemSettingsCategory category)
        {
            switch (category)
            {
                case SystemSettingsCategory.Alert:
                case SystemSettingsCategory.User:
                    // get the name of the column from the datagridview column properties
                    // because its using a datasource the names are diff to usual
                    dgvSystemSettings.Columns["settingValueDataGridViewTextBoxColumn"].Visible = false;
                    return;
            }
            dgvSystemSettings.Columns["settingValueDataGridViewTextBoxColumn"].Visible = true;
        }

        private void dgvSystemSettings_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || !dgvSystemSettings.Columns[e.ColumnIndex].Name.Equals($"{nameof(SystemSetting.SettingValue)}DataGridViewTextBoxColumn", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            int row = e.RowIndex;
            string settingName = (string)dgvSystemSettings.Rows[row].Cells[0].Value;
            var modifiedCell = dgvSystemSettings.Rows[row].Cells[e.ColumnIndex];

            if (settingName == nameof(SystemSettings.CheckForUpdates))
            {
                List<string> options = ["stable", "beta"];
                if (!options.Contains(modifiedCell.Value))
                {
                    modifiedCell.Value = options[0];
                    MessageBox.Show($"Invalid setting value for {settingName}, please use one of the supported values:\r\n\r\n{string.Join(", ", options)}", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

using AssetTrakr.App.Forms.Asset;
using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Logging;
using AssetTrakr.Utils.Enums;
using AssetTrakr.WinForms.ActionLog;
using Microsoft.EntityFrameworkCore;

namespace AssetTrakr.App.Forms.Contract
{
    public partial class FrmContractViewAll : Form
    {
        private readonly DatabaseContext _dbContext;
        private readonly bool _includeArchived = false;

        public FrmContractViewAll()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();

            _includeArchived = _dbContext.SystemSettings.WhereEnabled(nameof(SystemSettings.IncludeArchivedInViewAll));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadData();
        }

        /// <summary>
        /// Loads all of the Contracts data into the DataGridView
        /// </summary>
        /// <param name="needReload">
        /// True or False, true resets the datasource to NULL before loading data
        /// </param>
        /// <param name="includeArchived">
        /// True or False, true includes archived entities in the result
        /// </param>
        private void LoadData(bool needReload = false)
        {
            if (needReload)
            {
                dgvViewAll.DataSource = null;
            }

            dgvViewAll.Visible = true;
            lblNoContractsDescription.Visible = false;
            lblNoContractsTitle.Visible = false;

            var contracts = _dbContext.Contracts.Where(c => _includeArchived || !c.IsArchived).ToList();

            dgvViewAll.DataSource = contracts;

            // Rename columns since it's an anonymous type and ignores [DisplayName] attribute in the License model
            dgvViewAll.Columns[nameof(Models.Contract.OrderRef)].HeaderText = "Order Reference";
            dgvViewAll.Columns[nameof(Models.Contract.PaymentFrequency)].HeaderText = "Pay Frequency";
            dgvViewAll.Columns[nameof(Models.Contract.ComboDisplayName)].HeaderText = "Name & User Agreement Id";
            dgvViewAll.Columns[nameof(Models.Contract.UserAgreementId)].HeaderText = "User Agreement Id";

            // hide columns
            dgvViewAll.Columns[nameof(Models.Contract.ContractId)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Contract.Description)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Contract.CreatedDate)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Contract.UpdatedDate)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Contract.UpdatedBy)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Contract.CreatedBy)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Contract.ComboDisplayName)].Visible = false;

            if (!contracts.Any())
            {
                dgvViewAll.Visible = false;
                lblNoContractsDescription.Visible = true;
                lblNoContractsTitle.Visible = true;
            }
        }

        private void columnSelectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            FrmColumnSelector2 frmColumnSelector = new(dgv);
            frmColumnSelector.ShowDialog();

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = frmColumnSelector.SelectedColumns.Contains(col.Name);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvViewAll.Export();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            FrmContractModify frmContractModify = new(contractId: (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
            frmContractModify.ShowDialog();
            LoadData(true);
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            FrmContractModify frmContractModify = new(contractId: (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value, isReadOnly: true);
            frmContractModify.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            string name = (string)dgv.Rows[dgv.SelectedRows[0].Index].Cells["Name"].Value;
            DialogResult dr = MessageBox.Show($"This action cannot be reversed, do you wish to delete {name}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                var contractId = (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value;

                try
                {
                    if (_dbContext.Contracts.Where(a => a.ContractId == contractId).ExecuteDelete() > 0)
                    {
                        ActionLogMethods.Deleted(_dbContext, ActionAlertCategory.Contract, name);

                        LoadData(true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.Error<FrmAssetModify>($"{ex}");
                }
            }
        }

        private void archiveOrUnarchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            string? tooltipName = archiveOrUnarchiveToolStripMenuItem.Text;

            string name = (string)dgv.Rows[dgv.SelectedRows[0].Index].Cells[nameof(Models.Contract.Name)].Value;
            DialogResult dr = MessageBox.Show($"Do you wish to {tooltipName} {name}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes) { return; }

            var contractId = (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[nameof(Models.Contract.ContractId)].Value;
            var contract = _dbContext.Contracts.FirstOrDefault(a => a.ContractId == contractId);

            if (contract == null) { return; }

            contract.IsArchived = tooltipName == "Archive";

            try
            {
                _dbContext.Contracts.Update(contract);
                _dbContext.SaveChanges();

                if (tooltipName == "Archive")
                {
                    ActionLogMethods.Archived(_dbContext, ActionAlertCategory.Contract, name);
                }
                else if (tooltipName == "Unarchive")
                {
                    ActionLogMethods.Unarchived(_dbContext, ActionAlertCategory.Contract, name);
                }

                LoadData(true);
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmAssetModify>($"{ex}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmAssetModify>($"{ex}");
            }
        }

        private void cmsDgvRightClick_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // If the item is already in the archive, change the archive tool item to unarchive and disable editing
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            var contractId = (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[nameof(Models.Contract.ContractId)].Value;
            var contract = _dbContext.Contracts.FirstOrDefault(c => c.ContractId == contractId);

            if (contract == null) { return; }

            editToolStripMenuItem.Enabled = editToolStripMenuItem.Visible = !contract.IsArchived;
            archiveOrUnarchiveToolStripMenuItem.Text = contract.IsArchived ? "Unarchive" : "Archive";

        }
    }
}

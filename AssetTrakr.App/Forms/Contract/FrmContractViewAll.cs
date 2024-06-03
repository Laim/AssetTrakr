using AssetTrakr.App.Forms.Asset;
using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Logging;
using AssetTrakr.Utils.Attributes;
using AssetTrakr.Utils.Enums;
using AssetTrakr.WinForms.ActionLog;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AssetTrakr.App.Forms.Contract
{
    public partial class FrmContractViewAll : Form
    {
        private DatabaseContext _dbContext;
        private readonly bool _includeArchived = false;
        private Models.Contract? _selectedContract;
        private bool _firstLoad = true;


        public FrmContractViewAll()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();

            _includeArchived = _dbContext.SystemSettings.WhereEnabled(nameof(SystemSettings.IncludeArchivedInViewAll));

            Activated += AfterLoading;
        }

        private async void AfterLoading(object? sender, EventArgs e)
        {
            if(_firstLoad)
            {
                await LoadData();
                _firstLoad = false;
            }
        }


        /// <summary>
        /// Loads all of the Contracts data into the DataGridView
        /// </summary>
        /// <param name="needReload">
        /// True or False, true resets the datasource to NULL before loading data
        /// </param>
        private async Task LoadData(bool needReload = false)
        {
            if (needReload)
            {
                sfDgViewAll.DataSource = null;
            }

            sfDgViewAll.Visible = true;
            lblNoContractsDescription.Visible = false;
            lblNoContractsTitle.Visible = false;

            //var contracts = await _dbContext.Contracts.Where(c => _includeArchived || !c.IsArchived).ToListAsync();

            var contracts = await _dbContext.Contracts
                .Select(c => new
                {
                    c.ContractId,
                    c.Name,
                    c.OrderRef,
                    c.UserAgreementId,
                    c.PaymentFrequency,
                    c.Price,
                    c.IsArchived,
                    c.ComboDisplayName,
                    c.Description,
                    c.CreatedDate,
                    c.UpdatedDate,
                    c.CreatedBy,
                    c.UpdatedBy,
                    c.ContractPeriods,
                    c.ContractAttachments
                })
                .Where(c => _includeArchived || !c.IsArchived)
                .ToListAsync();

            sfDgViewAll.DataSource = contracts;

            if (!contracts.Any())
            {
                sfDgViewAll.Visible = false;
                lblNoContractsDescription.Visible = true;
                lblNoContractsTitle.Visible = true;
            }

        }

        private void columnSelectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not SfDataGrid dgv)
            {
                return;
            }

            FrmColumnSelector2 frmColumnSelector = new(sfDgv: dgv);
            frmColumnSelector.ShowDialog();

            foreach (var col in dgv.Columns)
            {
                col.Visible = frmColumnSelector.SelectedColumns.Contains(col.HeaderText);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfDgViewAll.Export();
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedContract == null)
            {
                MessageBox.Show("Unable to open contract as it is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmContractModify frmContractModify = new(contractId: _selectedContract.ContractId);
            frmContractModify.ShowDialog();
            await LoadData(true);
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedContract == null)
            {
                MessageBox.Show("Unable to open contract as it is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmContractModify frmContractModify = new(contractId: _selectedContract.ContractId, isReadOnly: true);
            frmContractModify.ShowDialog();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedContract == null)
            {
                MessageBox.Show("Unable to open contract as it is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = _selectedContract.Name;
            DialogResult dr = MessageBox.Show($"This action cannot be reversed, do you wish to delete {name}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                var contractId = _selectedContract.ContractId;

                try
                {
                    if (_dbContext.Contracts.Where(a => a.ContractId == contractId).ExecuteDelete() > 0)
                    {
                        ActionLogMethods.Deleted(_dbContext, ActionAlertCategory.Contract, name);

                        await LoadData(true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.Error<FrmAssetModify>($"{ex}");
                }
            }
        }

        private async void archiveOrUnarchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedContract == null)
            {
                MessageBox.Show("Unable to open contract as it is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string? tooltipName = archiveOrUnarchiveToolStripMenuItem.Text;

            string name = _selectedContract.Name;
            DialogResult dr = MessageBox.Show($"Do you wish to {tooltipName} {name}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes) { return; }

            var contract = _selectedContract;

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

                await LoadData(true);
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
            if (_selectedContract == null)
            {
                cmsDgvRightClick.HideItems();
                return;
            }
            cmsDgvRightClick.ShowItems();

            // If the item is already in the archive, change the archive tool item to unarchive and disable editing
            var contract = _selectedContract;

            if (contract == null) { return; }

            editToolStripMenuItem.Enabled = editToolStripMenuItem.Visible = !contract.IsArchived;
            archiveOrUnarchiveToolStripMenuItem.Text = contract.IsArchived ? "Unarchive" : "Archive";

        }

        private void dgvViewAll_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            _selectedContract = sfDgViewAll.GetCurrentItemProperty<Models.Contract>(nameof(Models.Contract.ContractId), _dbContext);
        }

        private void dgvViewAll_DataSourceChanged(object sender, Syncfusion.WinForms.DataGrid.Events.DataSourceChangedEventArgs e)
        {
            sfDgViewAll.CustomColumnModifier<Models.Contract>(_includeArchived);
        }

    }
}

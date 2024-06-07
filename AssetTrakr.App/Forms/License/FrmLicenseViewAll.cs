using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Logging;
using AssetTrakr.Utils.Enums;
using AssetTrakr.WinForms.ActionLog;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Bson;
using Syncfusion.WinForms.DataGrid;
using System.Data;

namespace AssetTrakr.App.Forms.License
{
    public partial class FrmLicenseViewAll : Form
    {
        private readonly DatabaseContext _dbContext;
        private readonly bool _includeArchived = false;
        private Models.License? _selectedLicense;
        private bool _firstLoad = true;

        public FrmLicenseViewAll()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();

            _includeArchived = _dbContext.SystemSettings.WhereEnabled(nameof(SystemSettings.IncludeArchivedInViewAll));

            Activated += AfterLoading;
        }

        private async void AfterLoading(object? sender, EventArgs e)
        {
            if (_firstLoad)
            {
                await LoadData();
                _firstLoad = false;
            }
        }

        /// <summary>
        /// Loads all of the license data into the datagridview
        /// </summary>
        /// <param name="needReload">
        /// True or false, true resets the datasource to NULL before loading data
        /// </param>
        private async Task LoadData(bool needReload = false)
        {
            if (needReload)
            {
                sfDgViewAll.DataSource = null;
            }

            sfDgViewAll.Visible = true;
            lblNoLicensesDescription.Visible = false;
            lblNoLicensesTitle.Visible = false;

            var licenses = await _dbContext.Licenses
                .Include(l => l.Manufacturer)
                .Include(l => l.Contract)
                .Include(l => l.Platform)
                .Select(l => new
                {
                    l.Id,
                    l.Name,
                    l.Purchased,
                    l.Count,
                    l.IsSubscription,
                    l.IsSubscriptionContract,
                    Manufacturer = l.Manufacturer.Name ?? "",
                    Platform = l.Platform.Name ?? "",
                    Contract = l.Contract.Name ?? "",
                    l.Price,
                    l.Description,
                    l.Version,
                    l.LicenseKey,
                    l.OrderReference,
                    l.RegisteredUser,
                    l.RegisteredEmail,
                    l.CreatedBy,
                    l.CreatedDate,
                    l.UpdatedBy,
                    l.UpdatedDate,
                    l.IsArchived
                })
                .Where(l => _includeArchived || !l.IsArchived)
                .ToListAsync();

            sfDgViewAll.DataSource = licenses;

            if (!licenses.Any())
            {
                sfDgViewAll.Visible = false;
                lblNoLicensesDescription.Visible = true;
                lblNoLicensesTitle.Visible = true;
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedLicense == null)
            {
                MessageBox.Show("Unable to open license as it is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmLicenseModify frmLicenseModify = new(licenseId: _selectedLicense.Id, isReadOnly: true);
            frmLicenseModify.ShowDialog();
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedLicense == null)
            {
                MessageBox.Show("Unable to open license as it is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmLicenseModify frmLicenseModify = new(licenseId: _selectedLicense.Id);
            frmLicenseModify.ShowDialog();
            await LoadData(true);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfDgViewAll.Export();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedLicense == null)
            {
                MessageBox.Show("Unable to open license as it is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = _selectedLicense.Name;
            DialogResult dr = MessageBox.Show($"This action cannot be reversed, do you wish to delete {name}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                var licenseId = _selectedLicense.Id;

                try
                {
                    if (_dbContext.Contracts.Where(a => a.ContractId == licenseId).ExecuteDelete() > 0)
                    {
                        ActionLogMethods.Deleted(_dbContext, ActionAlertCategory.License, name);

                        await LoadData(true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.Error<FrmLicenseViewAll>($"{ex}");
                }
            }
        }

        private async void archiveOrUnarchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedLicense == null)
            {
                MessageBox.Show("Unable to open license as it is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string? tooltipName = archiveOrUnarchiveToolStripMenuItem.Text;

            string name = _selectedLicense.Name;
            DialogResult dr = MessageBox.Show($"Do you wish to {tooltipName} {name}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes) { return; }

            var license = _selectedLicense;

            if (license == null) { return; }

            license.IsArchived = tooltipName == "Archive";

            try
            {
                _dbContext.Licenses.Update(license);
                _dbContext.SaveChanges();

                if (tooltipName == "Archive")
                {
                    ActionLogMethods.Archived(_dbContext, ActionAlertCategory.License, name);
                }
                else if (tooltipName == "Unarchive")
                {
                    ActionLogMethods.Unarchived(_dbContext, ActionAlertCategory.License, name);
                }

                await LoadData(true);
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmLicenseViewAll>($"{ex}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmLicenseViewAll>($"{ex}");
            }
        }

        private void cmsDgvRightClick_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_selectedLicense == null)
            {
                cmsDgvRightClick.HideItems();
                return;
            }
            cmsDgvRightClick.ShowItems();

            // If the item is already in the archive, change the archive tool item to unarchive and disable editing
            var license = _selectedLicense;

            if (license == null) { return; }

            editToolStripMenuItem.Enabled = editToolStripMenuItem.Visible = !license.IsArchived;
            archiveOrUnarchiveToolStripMenuItem.Text = license.IsArchived ? "Unarchive" : "Archive";

        }

        private void sfDgViewAll_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            _selectedLicense = sfDgViewAll.GetCurrentItemProperty<Models.License>(nameof(Models.License.Id), _dbContext);
        }

        private void sfDgViewAll_DataSourceChanged(object sender, Syncfusion.WinForms.DataGrid.Events.DataSourceChangedEventArgs e)
        {
            sfDgViewAll.CustomColumnModifier<Models.License>(_includeArchived);
        }
    }
}

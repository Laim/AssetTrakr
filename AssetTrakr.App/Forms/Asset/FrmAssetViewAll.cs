using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Models.Assets;
using AssetTrakr.Database;
using AssetTrakr.Extensions;
using Microsoft.EntityFrameworkCore;
using AssetTrakr.Logging;
using AssetTrakr.Utils.Enums;
using AssetTrakr.WinForms.ActionLog;
using System.Xml.Linq;
using Syncfusion.WinForms.DataGrid;

namespace AssetTrakr.App.Forms.Asset
{
    public partial class FrmAssetViewAll : Form
    {

        private readonly DatabaseContext _dbContext;
        private readonly bool _includeArchived = false;
        private Models.Assets.Asset? _selectedAsset;
        private bool _firstLoad = true;

        public FrmAssetViewAll()
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
        /// Loads all of the asset data into the DataGridView
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
            lblNoAssetsDescription.Visible = false;
            lblNoAssetsTitle.Visible = false;

            var assets = await _dbContext.Assets
                .Include(a => a.Manufacturer)
                .Include(a => a.Contract)
                .Include(a => a.AssetAttachments)
                .Include(a => a.Platform)
                .Include(a => a.AssetPeriods)
                .Select(a => new
                {
                    a.AssetId,
                    a.Name,
                    a.Model,
                    a.Hardware.AssetType,
                    Manufacturer = a.Manufacturer.Name ?? "",
                    Platform = a.Platform.Name ?? "",
                    Contract = a.Contract.Name ?? "",
                    Attachments = a.AssetAttachments.Count,
                    a.IsUnderWarranty,
                    a.Hardware.RamSizeInGB,
                    a.Hardware.Processor,
                    a.Hardware.BiosSerialNumber,
                    a.LicenseKey,
                    OperatingSystem = a.OperatingSystem.Name,
                    a.OrderReference,
                    a.Price,
                    a.RegisteredUser,
                    a.RegisteredEmail,
                    WarrantyPeriodsFormatted = string.Join($",{Environment.NewLine}", a.AssetPeriods
                            .Where(ap => ap != null && ap.Period != null)
                            .Select(ap => ap.Period.StartDate.ToString("d") + " - " + ap.Period.EndDate.ToString("d"))),
                    a.CreatedBy,
                    a.CreatedDate,
                    a.UpdatedBy,
                    a.UpdatedDate,
                    a.IsArchived
                })
                .Where(a => _includeArchived || !a.IsArchived)
                .ToListAsync();

            sfDgViewAll.DataSource = assets;


            if (!assets.Any())
            {
                sfDgViewAll.Visible = false;
                lblNoAssetsDescription.Visible = true;
                lblNoAssetsTitle.Visible = true;
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedAsset == null)
            {
                MessageBox.Show("Unable to open asset as it is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmAssetModify FrmAssetModify = new(assetId: _selectedAsset.AssetId, isReadOnly: true);
            FrmAssetModify.ShowDialog();
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedAsset == null)
            {
                MessageBox.Show("Unable to open asset as it is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmAssetModify FrmAssetModify = new(assetId: _selectedAsset.AssetId);
            FrmAssetModify.ShowDialog();
            await LoadData(true);
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedAsset == null)
            {
                MessageBox.Show("Unable to open asset as it is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = _selectedAsset.Name;
            DialogResult dr = MessageBox.Show($"This action cannot be reversed, do you wish to delete {name}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                var assetId = _selectedAsset.AssetId;

                try
                {
                    if (_dbContext.Assets.Where(a => a.AssetId == assetId).ExecuteDelete() > 0)
                    {
                        ActionLogMethods.Deleted(_dbContext, ActionAlertCategory.Asset, name);

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
            if (_selectedAsset == null)
            {
                MessageBox.Show("Unable to open asset as it is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string? tooltipName = archiveOrUnarchiveToolStripMenuItem.Text;

            string name = _selectedAsset.Name;
            DialogResult dr = MessageBox.Show($"Do you wish to {tooltipName} {name}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes) { return; }

            var assetId = _selectedAsset.AssetId;
            var asset = _dbContext.Assets.FirstOrDefault(a => a.AssetId == assetId);

            if (asset == null) { return; }

            asset.IsArchived = tooltipName == "Archive";

            try
            {
                _dbContext.Assets.Update(asset);
                _dbContext.SaveChanges();

                if (tooltipName == "Archive")
                {
                    ActionLogMethods.Archived(_dbContext, ActionAlertCategory.Asset, name);
                }
                else if (tooltipName == "Unarchive")
                {
                    ActionLogMethods.Unarchived(_dbContext, ActionAlertCategory.Asset, name);
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
            if (_selectedAsset == null)
            {
                cmsDgvRightClick.HideItems();
                return;
            }
            cmsDgvRightClick.ShowItems();

            // If the item is already in the archive, change the archive tool item to unarchive and disable editing
            var asset = _selectedAsset;

            if (asset == null) { return; }

            editToolStripMenuItem.Enabled = editToolStripMenuItem.Visible = !asset.IsArchived;
            archiveOrUnarchiveToolStripMenuItem.Text = asset.IsArchived ? "Unarchive" : "Archive";
        }

        private void sfDgViewAll_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            _selectedAsset = sfDgViewAll.GetCurrentItemProperty<Models.Assets.Asset>(nameof(Models.Assets.Asset.AssetId), _dbContext);
        }

        private void sfDgViewAll_DataSourceChanged(object sender, Syncfusion.WinForms.DataGrid.Events.DataSourceChangedEventArgs e)
        {
            sfDgViewAll.CustomColumnModifier<Models.Assets.Asset>(_includeArchived);
        }
    }
}

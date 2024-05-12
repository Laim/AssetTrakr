using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Models.Assets;
using AssetTrakr.Database;
using AssetTrakr.Extensions;
using Microsoft.EntityFrameworkCore;
using AssetTrakr.Logging;
using AssetTrakr.Utils.Enums;
using AssetTrakr.WinForms.ActionLog;
using System.Xml.Linq;

namespace AssetTrakr.App.Forms.Asset
{
    public partial class FrmAssetViewAll : Form
    {

        private readonly DatabaseContext _dbContext;
        private readonly bool _includeArchived = false;

        public FrmAssetViewAll()
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
        /// Loads all of the asset data into the DataGridView
        /// </summary>
        /// <param name="needReload">
        /// True or False, true resets the datasource to NULL before loading data
        /// </param>
        private void LoadData(bool needReload = false)
        {
            if (needReload)
            {
                dgvViewAll.DataSource = null;
            }

            dgvViewAll.Visible = true;
            lblNoAssetsDescription.Visible = false;
            lblNoAssetsTitle.Visible = false;

            var assets = _dbContext.Assets
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
                    Type = a.Hardware.AssetType,
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
                .ToList();

            dgvViewAll.DataSource = assets;

            // Rename columns since it's an anonymous type and ignores the [DisplayName] attribute in the Asset Model
            dgvViewAll.Columns[nameof(AssetHardware.RamSizeInGB)].HeaderText = "RAM (GB)";
            dgvViewAll.Columns[nameof(AssetHardware.BiosSerialNumber)].HeaderText = "Bios Serial Number";
            dgvViewAll.Columns[nameof(Models.Assets.Asset.LicenseKey)].HeaderText = "License Key";
            dgvViewAll.Columns[nameof(Models.Assets.Asset.OperatingSystem)].HeaderText = "Operating System";
            dgvViewAll.Columns[nameof(Models.Assets.Asset.OrderReference)].HeaderText = "Order Reference";
            dgvViewAll.Columns[nameof(Models.Assets.Asset.RegisteredUser)].HeaderText = "User";
            dgvViewAll.Columns[nameof(Models.Assets.Asset.RegisteredEmail)].HeaderText = "Email";
            dgvViewAll.Columns[nameof(Models.Assets.Asset.IsArchived)].HeaderText = "Archived";
            dgvViewAll.Columns[nameof(Models.Assets.Asset.IsUnderWarranty)].HeaderText = "Has Warranty";
            dgvViewAll.Columns["WarrantyPeriodsFormatted"].HeaderText = "Warranty";

            // Hide Columns
            dgvViewAll.Columns[nameof(Models.Assets.Asset.AssetId)].Visible = false;
            dgvViewAll.Columns[nameof(AssetHardware.Processor)].Visible = false;
            dgvViewAll.Columns[nameof(AssetHardware.RamSizeInGB)].Visible = false;
            dgvViewAll.Columns[nameof(AssetHardware.BiosSerialNumber)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Assets.Asset.LicenseKey)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Assets.Asset.Contract)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Assets.Asset.OrderReference)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Assets.Asset.Price)].Visible = false;
            dgvViewAll.Columns["Attachments"].Visible = false;
            dgvViewAll.Columns[nameof(Models.Assets.Asset.RegisteredUser)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Assets.Asset.RegisteredEmail)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Assets.Asset.CreatedDate)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Assets.Asset.UpdatedDate)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Assets.Asset.UpdatedBy)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Assets.Asset.CreatedBy)].Visible = false;

            if(!_includeArchived)
            {
                dgvViewAll.Columns[nameof(Models.Assets.Asset.IsArchived)].Visible = false;
            }

            if (!assets.Any())
            {
                dgvViewAll.Visible = false;
                lblNoAssetsDescription.Visible = true;
                lblNoAssetsTitle.Visible = true;
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            FrmAssetModify FrmAssetModify = new((int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value, true);
            FrmAssetModify.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            FrmAssetModify FrmAssetModify = new((int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
            FrmAssetModify.ShowDialog();
            LoadData(true);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            string name = (string)dgv.Rows[dgv.SelectedRows[0].Index].Cells[nameof(Models.Assets.Asset.Name)].Value;
            DialogResult dr = MessageBox.Show($"This action cannot be reversed, do you wish to delete {name}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                var assetId = (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[nameof(Models.Assets.Asset.AssetId)].Value;

                try
                {
                    if (_dbContext.Assets.Where(a => a.AssetId == assetId).ExecuteDelete() > 0)
                    {
                        ActionLogMethods.Deleted(_dbContext, ActionAlertCategory.Asset, name);

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

            string name = (string)dgv.Rows[dgv.SelectedRows[0].Index].Cells[nameof(Models.Assets.Asset.Name)].Value;
            DialogResult dr = MessageBox.Show($"Do you wish to {tooltipName} {name}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes) { return; }

            var assetId = (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[nameof(Models.Assets.Asset.AssetId)].Value;
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

            var assetId = (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[nameof(Models.Assets.Asset.AssetId)].Value;
            var asset = _dbContext.Assets.FirstOrDefault(a => a.AssetId == assetId);

            if (asset == null) { return; }

            editToolStripMenuItem.Enabled = editToolStripMenuItem.Visible = !asset.IsArchived;
            archiveOrUnarchiveToolStripMenuItem.Text = asset.IsArchived ? "Unarchive" : "Archive";
        }
    
    }
}

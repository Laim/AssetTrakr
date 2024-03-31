using AssetTrakr.App.Forms.Shared;
using AssetTrakr.App.Helpers;
using AssetTrakr.Database;
using AssetTrakr.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AssetTrakr.App.Forms.Asset
{
    public partial class FrmAssetViewAll : Form
    {

        private readonly DatabaseContext _dbContext;

        public FrmAssetViewAll()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();
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
                    Warranty = a.IsUnderWarranty,
                    a.Hardware.RamSizeInGB,
                    a.Hardware.Processor,
                    a.Hardware.BiosSerialNumber,
                    a.LicenseKey,
                    OperatingSystem = a.OperatingSystem.Name,
                    a.OrderReference,
                    a.Price,
                    a.RegisteredUser,
                    a.RegisteredEmail,
                    a.CreatedBy,
                    a.CreatedDate,
                    a.UpdatedBy,
                    a.UpdatedDate
                })
                .ToList();

            dgvViewAll.DataSource = assets;

            // Rename columns since it's an anonymous type and ignores the [DisplayName] attribute in the Asset Model
            dgvViewAll.Columns["RamSizeInGB"].HeaderText = "RAM (GB)";
            dgvViewAll.Columns["BiosSerialNumber"].HeaderText = "Bios Serial Number";
            dgvViewAll.Columns["LicenseKey"].HeaderText = "License Key";
            dgvViewAll.Columns["OperatingSystem"].HeaderText = "Operating System";
            dgvViewAll.Columns["OrderReference"].HeaderText = "Order Reference";
            dgvViewAll.Columns["RegisteredUser"].HeaderText = "User";
            dgvViewAll.Columns["RegisteredEmail"].HeaderText = "Email";

            // Hide Columns
            dgvViewAll.Columns["AssetId"].Visible = false;
            dgvViewAll.Columns["Processor"].Visible = false;
            dgvViewAll.Columns["RamSizeInGB"].Visible = false;
            dgvViewAll.Columns["BiosSerialNumber"].Visible = false;
            dgvViewAll.Columns["LicenseKey"].Visible = false;
            dgvViewAll.Columns["Contract"].Visible = false;
            dgvViewAll.Columns["OrderReference"].Visible = false;
            dgvViewAll.Columns["Price"].Visible = false;
            dgvViewAll.Columns["Attachments"].Visible = false;
            dgvViewAll.Columns["RegisteredUser"].Visible = false;
            dgvViewAll.Columns["RegisteredEmail"].Visible = false;
            dgvViewAll.Columns["CreatedDate"].Visible = false;
            dgvViewAll.Columns["UpdatedDate"].Visible = false;
            dgvViewAll.Columns["UpdatedBy"].Visible = false;
            dgvViewAll.Columns["CreatedBy"].Visible = false;

            if(!assets.Any())
            {
                dgvViewAll.Visible = false;
                lblNoAssetsDescription.Visible = true;
                lblNoAssetsTitle.Visible = true;
            }

        }

        private void columnSelectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is DataGridView dgv)
            {
                FrmColumnSelector2 frmColumnSelector = new(dgv);
                frmColumnSelector.ShowDialog();

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    col.Visible = frmColumnSelector.SelectedColumns.Contains(col.Name);
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvViewAll.Export();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is DataGridView dgv)
            {
                FrmAssetModify FrmAssetModify = new((int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value, true);
                FrmAssetModify.ShowDialog();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is DataGridView dgv)
            {
                FrmAssetModify FrmAssetModify = new((int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
                FrmAssetModify.ShowDialog();
                LoadData(true);
            }
        }
    }
}

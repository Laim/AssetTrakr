using AssetTrakr.App.Forms.Asset;
using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Logging;
using AssetTrakr.Utils.Enums;
using AssetTrakr.WinForms.ActionLog;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AssetTrakr.App.Forms.License
{
    public partial class FrmLicenseViewAll : Form
    {
        private readonly DatabaseContext _dbContext;
        private readonly bool _includeArchived = false;

        public FrmLicenseViewAll()
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
        /// Loads all of the license data into the datagridview
        /// </summary>
        /// <param name="needReload">
        /// True or false, true resets the datasource to NULL before loading data
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
            lblNoLicensesDescription.Visible = false;
            lblNoLicensesTitle.Visible = false;

            var licenses = _dbContext.Licenses
                .Include(l => l.Manufacturer)
                .Include(l => l.Contract)
                .Include(l => l.Platform)
                .Select(l => new
                {
                    l.Id,
                    l.Name,
                    l.Count,
                    l.PurchaseDate, // Purchase Date
                    l.IsSubscription, // Subscription
                    l.IsSubscriptionContract, // Subscription via Contract
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
                .ToList();

            dgvViewAll.DataSource = licenses;

            // Rename columns since it's an anonymous type and ignores [DisplayName] attribute in the License model
            dgvViewAll.Columns[nameof(Models.License.PurchaseDate)].HeaderText = "Purchase Date";
            dgvViewAll.Columns[nameof(Models.License.IsSubscription)].HeaderText = "Subscription";
            dgvViewAll.Columns[nameof(Models.License.IsSubscriptionContract)].HeaderText = "Subscription via Contract";
            dgvViewAll.Columns[nameof(Models.License.LicenseKey)].HeaderText = "License Key";
            dgvViewAll.Columns[nameof(Models.License.OrderReference)].HeaderText = "Order Reference";
            dgvViewAll.Columns[nameof(Models.License.RegisteredUser)].HeaderText = "User";
            dgvViewAll.Columns[nameof(Models.License.RegisteredEmail)].HeaderText = "User Email";
            dgvViewAll.Columns[nameof(Models.License.IsArchived)].HeaderText = "Archived";

            // hide columns
            dgvViewAll.Columns[nameof(Models.License.Id)].Visible = false;
            dgvViewAll.Columns[nameof(Models.License.Description)].Visible = false;
            dgvViewAll.Columns[nameof(Models.License.Version)].Visible = false;
            dgvViewAll.Columns[nameof(Models.License.LicenseKey)].Visible = false;
            dgvViewAll.Columns[nameof(Models.License.IsSubscriptionContract)].Visible = false;
            dgvViewAll.Columns[nameof(Models.License.OrderReference)].Visible = false;
            dgvViewAll.Columns[nameof(Models.License.RegisteredUser)].Visible = false;
            dgvViewAll.Columns[nameof(Models.License.RegisteredEmail)].Visible = false;
            dgvViewAll.Columns[nameof(Models.License.CreatedDate)].Visible = false;
            dgvViewAll.Columns[nameof(Models.License.UpdatedDate)].Visible = false;
            dgvViewAll.Columns[nameof(Models.License.UpdatedBy)].Visible = false;
            dgvViewAll.Columns[nameof(Models.License.CreatedBy)].Visible = false;

            if (!_includeArchived)
            {
                dgvViewAll.Columns[nameof(Models.Assets.Asset.IsArchived)].Visible = false;
            }

            if (!licenses.Any())
            {
                dgvViewAll.Visible = false;
                lblNoLicensesDescription.Visible = true;
                lblNoLicensesTitle.Visible = true;
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            FrmLicenseModify frmLicenseModify = new((int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value, true);
            frmLicenseModify.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            FrmLicenseModify frmLicenseModify = new((int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
            frmLicenseModify.ShowDialog();
            LoadData(true);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvViewAll.Export();
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
                var licenseId = (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value;

                try
                {
                    if (_dbContext.Licenses.Where(a => a.Id == licenseId).ExecuteDelete() > 0)
                    {
                        ActionLogMethods.Deleted(_dbContext, ActionAlertCategory.License, name);

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

            var licenseId = (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[nameof(Models.License.Id)].Value;
            var license = _dbContext.Licenses.FirstOrDefault(a => a.Id == licenseId);

            if (license == null) { return; }

            license.IsArchived = tooltipName == "Archive";

            try
            {
                _dbContext.Licenses.Update(license);
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

            var licenseId = (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[nameof(Models.License.Id)].Value;
            var license = _dbContext.Licenses.FirstOrDefault(l => l.Id == licenseId);

            if (license == null) { return; }

            editToolStripMenuItem.Enabled = editToolStripMenuItem.Visible = !license.IsArchived;
            archiveOrUnarchiveToolStripMenuItem.Text = license.IsArchived ? "Unarchive" : "Archive";

        }
    }
}

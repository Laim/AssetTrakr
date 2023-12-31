using AssetTrakr.App.Forms.Attachments;
using AssetTrakr.App.Forms.Contract;
using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Database;
using AssetTrakr.Models.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AssetTrakr.App.Forms.License
{
    // TODO: Might be worth optimizing this to use PropertyChange events so that when SubscriptionPeriodIds or AttachmentIds
    // gets updated, it runs the relevant shit to update the DGV.  Might prevent some code stink?
    public partial class FrmLicenseModify : Form
    {
        private readonly DatabaseContext _dbContext;
        private List<int> _attachmentIds = [];
        private List<int> _subscriptionPeriodIds = [];
        private readonly int _licenseId;

        public FrmLicenseModify(DatabaseContext DbContext, int LicenseId = 0)
        {
            InitializeComponent();

            _dbContext ??= DbContext;
            _licenseId = LicenseId;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cmbManufacturers.DataSource = _dbContext.Manufacturers.Select(m => m.Name).ToComboList();
            cmbContracts.DataSource = _dbContext.Contracts.Select(c => c.Name).ToComboList();
            cmbPlatforms.DataSource = _dbContext.Platforms.Select(p => p.Name).ToComboList();

            // If modifying a license instead of adding it
            if(_licenseId != 0)
            {
                LoadLicenseData();
            }
        }

        private void cbIsSubscription_CheckedChanged(object sender, EventArgs e)
        {
            btnAddSubPeriod.Enabled = cbIsSubscription.Checked;
            dgvSubscriptionPeriods.Enabled = cbIsSubscription.Checked;
            cbInheritFromContract.Enabled = cbIsSubscription.Checked;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 155)
            {
                MessageBox.Show("Name must be be less than 156 characters", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Name is a required field", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get ids
            // TODO: There has to be a better way of doing this since we already populate the combobox
            var selectedManufacturer = _dbContext.Manufacturers.SingleOrDefault(x => x.Name == cmbManufacturers.Text);
            int? selectedContractId = _dbContext.Contracts.SingleOrDefault(x => x.Name == cmbContracts.Text)?.ContractId;
            int selectedPlatformId = _dbContext.Platforms.SingleOrDefault(x => x.Name == cmbPlatforms.Text).PlatformId;

            if (selectedManufacturer == null || selectedManufacturer.ManufacturerId == 0)
            {
                MessageBox.Show($"Manufacturer is a required field", "Manufacturer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // UR HERE 31/12/2023

            // TODO: Re-evaluate this, might need to make selectedPlatformId nullable?
            if(selectedPlatformId == 0)
            {
                return;
            }

            // add license
            _dbContext.Add(new Models.License
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Count = Convert.ToInt32(numCount.Value),
                IsSubscription = cbIsSubscription.Checked,
                IsSubscriptionContract = cbInheritFromContract.Checked,
                SubscriptionIds = _subscriptionPeriodIds,
                PurchaseDate = DateOnly.FromDateTime(dtPurchaseDate.Value),
                AttachmentIds = _attachmentIds,
                ManufacturerId = selectedManufacturer.ManufacturerId,
                Price = Convert.ToInt32(numCost.Value),
                OrderReference = txtOrderRef.Text,
                LicenseKey = txtLicenseKey.Text,
                Version = txtVersion.Text,
                PlatformId = selectedPlatformId,
                ContractId = selectedContractId ?? null,
                RegisteredEmail = txtInfoContactEmail.Text,
                RegisteredUser = txtInfoContactName.Text
            });

            if (_dbContext.SaveChanges() > 0)
            {
                MessageBox.Show($"{txtName.Text} saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            FrmAttachmentAdd frmAttachmentAdd = new(_dbContext, _attachmentIds);
            frmAttachmentAdd.ShowDialog();

            if (frmAttachmentAdd.AttachmentIds != null && frmAttachmentAdd.AttachmentIds.Count > 0)
            {
                _attachmentIds = frmAttachmentAdd.AttachmentIds;

                UpdateAttachmentDataGrid(_attachmentIds);
            }
        }

        private void btnAddSubPeriod_Click(object sender, EventArgs e)
        {
            FrmSubscriptionPeriodAdd frmSubscriptionPeriodAdd = new(_dbContext, _subscriptionPeriodIds);
            frmSubscriptionPeriodAdd.ShowDialog();

            if (frmSubscriptionPeriodAdd.PeriodIds != null && frmSubscriptionPeriodAdd.PeriodIds.Count > 0)
            {
                _subscriptionPeriodIds = frmSubscriptionPeriodAdd.PeriodIds;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is DataGridView dgv)
            {
                if (dgv.Rows.Count == 0)
                {
                    return;
                }

                int selectedId = (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells["Id"].Value;

                if (dgv.Name == nameof(dgvAttachments))
                {
                    var att = _dbContext.Attachments.SingleOrDefault(x => x.AttachmentId == selectedId);

                    if (att != null)
                    {
                        _dbContext.Attachments.Remove(att);
                        _attachmentIds.Remove(selectedId);
                    }
                    else
                    {
                        throw new Exception("Attachment has not been set or cannot be found");
                    }
                }
                else if (dgv.Name == nameof(dgvSubscriptionPeriods))
                {
                    // Only let the user delete if they haven't inherited the period dates
                    // from a contract
                    if(!cbInheritFromContract.Checked)
                    {
                        var period = _dbContext.Periods.SingleOrDefault(x => x.Id == selectedId);

                        if (period != null)
                        {
                            _dbContext.Periods.Remove(period);
                            _subscriptionPeriodIds.Remove(selectedId);
                        }
                        else
                        {
                            throw new Exception("Period has not been set or cannot be found");
                        }
                    } else
                    {
                        // if inherited from contract 
                        MessageBox.Show(
                            "Cannot delete period dates inherited from a contract.  Dates must be deleted from the " +
                            "contract directly.", 
                            "Period Delete", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);

                        return;
                    }
                }

                if (_dbContext.SaveChanges() > 0)
                {
                    foreach (DataGridViewRow item in dgv.SelectedRows)
                    {
                        dgv.Rows.RemoveAt(item.Index);
                    }
                }

                if (dgv.Rows.Count == 0)
                {
                    dgv.DataSource = null;
                }
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

        private void lnkAddContract_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmContractAdd frmContractAdd = new(_dbContext);
            frmContractAdd.ShowDialog();

            cmbContracts.DataSource = _dbContext.Contracts.Select(c => c.Name).ToComboList();
        }

        private void lnkAddManufacturer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmManufacturerManager frmManufacturerManager = new(_dbContext);
            frmManufacturerManager.ShowDialog();

            cmbManufacturers.DataSource = _dbContext.Manufacturers.Select(m => m.Name).ToComboList();
        }

        private void lnkAddPlatform_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPlatformManager frmPlatformManager = new(_dbContext);
            frmPlatformManager.ShowDialog();

            cmbPlatforms.DataSource = _dbContext.Platforms.Select(m => m.Name).ToComboList();
        }

        private void cbInheritFromContract_CheckedChanged(object sender, EventArgs e)
        {
            if(cmbContracts.SelectedIndex < 1 && cbInheritFromContract.Checked)
            {
                MessageBox.Show("You must assign a contract before inheriting it's Periods", "Inherit from Contract", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbInheritFromContract.Checked = false;
                return;
            }

            btnAddSubPeriod.Enabled = !cbInheritFromContract.Checked;

            if(cbInheritFromContract.Checked)
            {
                List<int>? contractPeriodIds = _dbContext.Contracts
                .Where(x => x.Name == cmbContracts.Text)
                .Select(x => x.SubscriptionIds).FirstOrDefault()?.ToList();

                if (contractPeriodIds != null)
                {
                    UpdatePeriodsDataGrid(contractPeriodIds);
                }
            } else
            {
                // clears out the dgv and removes the contract related dates to prevent the user 
                // accidentally wiping things out
                dgvSubscriptionPeriods.DataSource = null;
            }
        }

        /// <summary>
        /// Updates the DataGridView for Subscription Periods and hides the irrelevant columns
        /// </summary>
        /// <param name="periodList">
        /// Integer list of Subscription Period IDs, see <see cref="Models.Period"/>
        /// </param>
        void UpdatePeriodsDataGrid(List<int> periodList)
        {
            dgvSubscriptionPeriods.DataSource = _dbContext.Periods
                    .Where(l => periodList.Contains(l.Id))
                    .ToModelSubscriptionPeriod();

            // Hide the non-default columns from the end user
            dgvSubscriptionPeriods.Columns["Id"].Visible = false;
            dgvSubscriptionPeriods.Columns["CreatedDate"].Visible = false;
            dgvSubscriptionPeriods.Columns["UpdatedDate"].Visible = false;
            dgvSubscriptionPeriods.Columns["CreatedBy"].Visible = false;
            dgvSubscriptionPeriods.Columns["UpdatedBy"].Visible = false;
        }

        /// <summary>
        /// Updates the DataGridView for Attachments and hides the irrelevant columns
        /// </summary>
        /// <param name="attachmentList">
        /// Integer list of Attachment IDs, see <see cref="Models.Attachment"/>
        /// </param>
        void UpdateAttachmentDataGrid(List<int> attachmentList)
        {

            dgvAttachments.DataSource = _dbContext.Attachments
                .Where(l => attachmentList.Contains(l.AttachmentId))
                .ToModelAttachment();

            // Hide the non-default columns from the end user
            dgvAttachments.Columns["AttachmentId"].Visible = false;
            dgvAttachments.Columns["Data"].Visible = false;
            dgvAttachments.Columns["DataType"].Visible = false;
            dgvAttachments.Columns["Url"].Visible = false;
            dgvAttachments.Columns["IsUrl"].Visible = false;
            dgvAttachments.Columns["CreatedDate"].Visible = false;
            dgvAttachments.Columns["UpdatedDate"].Visible = false;
            dgvAttachments.Columns["CreatedBy"].Visible = false;
            dgvAttachments.Columns["UpdatedBy"].Visible = false;
        }

        /// <summary>
        /// Converts a string value from the database to the Index of the ComboBox.
        /// </summary>
        /// <param name="comboBox">Your ComboBox</param>
        /// <param name="value">Database String Value</param>
        /// <returns>
        /// ComboBox SelectedIndex for <paramref name="value"/> otherwise -1.
        /// </returns>
        private int ConvertDbStringToComboId(ComboBox comboBox, string value)
        {
            if(comboBox.Items.Count == 0)
            {
                throw new Exception("comboBox contains no items");
            }

            int index = -1;
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                var item = comboBox.Items[i]?.ToString();

                if (item != null && item == value)
                {
                    index = i;
                    break;
                }
            }
 
            return index;
        }

        /// <summary>
        /// This loads the license data from the SQLite database.  This runs if the LicenseId passed at run time is NOT 0, 
        /// i.e we are modifying a license instead of adding a new one. See Constructor for more info.
        /// </summary>
        void LoadLicenseData()
        {
            var data = _dbContext.Licenses
                        .Include(l => l.Contract)
                        .Include(l => l.Manufacturer)
                        .Include(l => l.Platform)
                        .Where(x => x.Id == _licenseId).FirstOrDefault();

            if (data == null)
            {
                MessageBox.Show($"Could not find License Data for LicenseID = {_licenseId}.", "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return; // just in case lol
            }

            // Update general form info
            btnAdd.Text = "Update";
            this.Text = "Modify License";

            // Info tab
            txtName.Text = data.Name;
            dtPurchaseDate.Value = data.PurchaseDate.ToDateTime(TimeOnly.MinValue);
            numCost.Value = (decimal)data.Price;
            numCount.Value = data.Count;

            cmbManufacturers.SelectedIndex = ConvertDbStringToComboId(cmbManufacturers, data.Manufacturer?.Name ?? "");
            cmbPlatforms.SelectedIndex = ConvertDbStringToComboId(cmbPlatforms, data.Platform?.Name ?? "");
            cmbContracts.SelectedIndex = ConvertDbStringToComboId(cmbContracts, data.Contract?.Name ?? "");
            
            txtLicenseKey.Text = data.LicenseKey;
            txtOrderRef.Text = data.OrderReference;
            txtVersion.Text = data.Version;
            txtInfoContactName.Text = data.RegisteredUser;
            txtInfoContactEmail.Text = data.RegisteredEmail;

            // Subscription Tab
            if(data.IsSubscription)
            {
                cbIsSubscription.Checked = data.IsSubscription;
                cbInheritFromContract.Checked = data.IsSubscriptionContract;

                List<int>? contractPeriodIds = _dbContext.Contracts
                    .Where(x => x.ContractId == data.ContractId)
                    .Select(x => x.SubscriptionIds).FirstOrDefault()?.ToList();

                if(contractPeriodIds != null)
                {
                    UpdatePeriodsDataGrid(contractPeriodIds);
                }
            }


            // Attachment Tab
            if(data.AttachmentIds != null)
            {
                List<int>? attachmentIds = _dbContext.Attachments
                    .Where(x => data.AttachmentIds.Contains(x.AttachmentId))
                    .Select(x => x.AttachmentId).ToList();

                if(attachmentIds != null)
                {
                    UpdateAttachmentDataGrid(attachmentIds);
                }
            }

        }
    }
}

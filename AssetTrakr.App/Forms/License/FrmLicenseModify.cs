using AssetTrakr.App.Forms.Attachment;
using AssetTrakr.App.Forms.Contract;
using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Database;
using AssetTrakr.Models;
using AssetTrakr.App.Helpers;
using System.ComponentModel;
using System.Data;
using Microsoft.EntityFrameworkCore;
using AssetTrakr.Logging;

namespace AssetTrakr.App.Forms.License
{
    public partial class FrmLicenseModify : Form
    {
        private readonly DatabaseContext _dbContext;
        private BindingList<Models.Attachment> _attachments = [];
        private BindingList<Period> _subscriptionPeriods = [];
        private readonly Models.License? _licenseData;
        private readonly bool _isEditingMode;

        public FrmLicenseModify(int licenseId = 0, bool isReadOnly = false)
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();

            if (licenseId <= 0)
            {
                return;
            }

            var license = _dbContext.Licenses
                    .Include(l => l.Contract)
                    .Include(l => l.Manufacturer)
                    .Include(l => l.Platform)
                    .Include(l => l.LicensePeriods)
                        .ThenInclude(lp => lp.Period)
                    .Include(l => l.LicenseAttachments)
                        .ThenInclude(la => la.Attachment)
                    .FirstOrDefault(l => l.Id == licenseId);

            if (license != null)
            {
                _licenseData = license;
                _isEditingMode = true;

                // Update general form info
                btnAddUpdate.Text = "Update";
                Text = $"Modify License - {_licenseData.Name}";
            }

            if(isReadOnly && _licenseData != null)
            {
                SetReadOnly(this);
                Text = $"Viewing License - {_licenseData.Name}";
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PopulateComboBoxes();

            if (_isEditingMode)
            {
                LoadLicenseData();
            }
        }

        private void cbIsSubscription_CheckedChanged(object sender, EventArgs e)
        {
            btnAddSubPeriod.Enabled = cbIsSubscription.Checked;
            dgvSubscriptionPeriods.Enabled = cbIsSubscription.Checked;

            // if we uncheck, remove all the periods
            if (!cbIsSubscription.Checked && dgvSubscriptionPeriods.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Unmarking this as a Subscription License will remove " +
                    "all of the existing periods.  Do you wish to continue?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    _subscriptionPeriods.Clear();
                }
                else if (dr == DialogResult.No)
                {
                    // recheck the checkbox
                    cbIsSubscription.Checked = true;
                }
            }
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 155 || txtName.Text.Length == 0)
            {
                MessageBox.Show("Name is a required field and must be be less than 156 characters", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedManufacturer = cmbManufacturers.SelectedItem as Manufacturer;
            int? selectedContractId = (cmbContracts.SelectedItem as Models.Contract)?.ContractId;
            var selectedPlatform = cmbPlatforms.SelectedItem as Platform;

            if (selectedManufacturer == null)
            {
                MessageBox.Show($"Manufacturer is a required field", "Manufacturer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedPlatform == null)
            {
                MessageBox.Show($"Platform is a required field", "Platform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_isEditingMode)
            {
                AddLicense(selectedManufacturer, selectedContractId, selectedPlatform);
            }
            else
            {
                UpdateLicense(selectedManufacturer, selectedContractId, selectedPlatform);
            }

            if (_dbContext.SaveChanges() > 0)
            {
                MessageBox.Show($"{txtName.Text} saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show($"Something has gone wrong during save of {txtName.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            FrmAttachmentAdd frmAttachmentAdd = new(_attachments);
            frmAttachmentAdd.ShowDialog();

            if (frmAttachmentAdd.Attachments != null && frmAttachmentAdd.Attachments.Count > 0)
            {
                _attachments = frmAttachmentAdd.Attachments;

                DataGridViewMethods.UpdateAttachmentDataGrid(_attachments, dgvAttachments);
            }
        }

        private void btnAddSubPeriod_Click(object sender, EventArgs e)
        {
            FrmPeriodAdd frmSubscriptionPeriodAdd = new(_subscriptionPeriods);
            frmSubscriptionPeriodAdd.ShowDialog();

            if (frmSubscriptionPeriodAdd.Periods != null && frmSubscriptionPeriodAdd.Periods.Count > 0)
            {
                _subscriptionPeriods = frmSubscriptionPeriodAdd.Periods;
                DataGridViewMethods.UpdatePeriodsDataGrid(_subscriptionPeriods, dgvSubscriptionPeriods);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (cmsDgvRightClick.SourceControl is not DataGridView dgv || dgv.Rows.Count == 0)
            {
                return;
            }

            var dataItem = dgv.Rows[dgv.SelectedRows[0].Index].DataBoundItem;

            // If attachment datagrid
            if (dataItem is Models.Attachment attachment)
            {
                _attachments.Remove(attachment);
            }

            // If subscription datagrid
            if (dataItem is Period subscription)
            {
                _subscriptionPeriods.Remove(subscription);
            }

            if (dgv.Rows.Count == 0)
            {
                dgv.DataSource = null;
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
            FrmContractModify frmContractModify = new();
            frmContractModify.ShowDialog();

            PopulateComboBoxes();
        }

        private void cmbContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is not ComboBox cmb)
            {
                return;
            }

            if (cmb.SelectedIndex == 0)
            {
                lnkModifyContract.Visible = false;
                return;
            }

            lnkModifyContract.Visible = true;
        }

        private void lnkModifyContract_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmContractModify frmContractModify = new(cmbContracts.SelectedItem?.ToString() ?? "");
            frmContractModify.ShowDialog();

            PopulateComboBoxes();
        }

        private void lnkAddManufacturer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmManufacturerManager frmManufacturerManager = new();
            frmManufacturerManager.ShowDialog();

            PopulateComboBoxes();
        }

        private void lnkAddPlatform_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPlatformManager frmPlatformManager = new();
            frmPlatformManager.ShowDialog();

            PopulateComboBoxes();
        }

        /// <summary>
        /// This loads the license data from the SQLite database.  This runs if the LicenseId passed at run time is NOT 0.
        /// </summary>
        private void LoadLicenseData()
        {
            if (_licenseData == null)
            {
                MessageBox.Show($"Could not find License Data.", "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return; // just in case lol
            }

            txtName.Text = _licenseData.Name;
            dtPurchaseDate.Value = _licenseData.PurchaseDate.ToDateTime(TimeOnly.MinValue);
            numCost.Value = _licenseData.Price;
            numCount.Value = _licenseData.Count;

            cmbManufacturers.SelectedIndex = cmbManufacturers.FindStringExact(_licenseData.Manufacturer?.Name);
            cmbPlatforms.SelectedIndex = cmbPlatforms.FindStringExact(_licenseData.Platform?.Name);
            cmbContracts.SelectedIndex = cmbContracts.FindStringExact(_licenseData.Contract?.Name);

            txtLicenseKey.Text = _licenseData.LicenseKey;
            txtOrderRef.Text = _licenseData.OrderReference;
            txtVersion.Text = _licenseData.Version;
            txtInfoContactName.Text = _licenseData.RegisteredUser;
            txtInfoContactEmail.Text = _licenseData.RegisteredEmail;
            txtDescription.Text = _licenseData.Description;

            // Load in Subscription Periods
            if (_licenseData.IsSubscription && _licenseData.LicensePeriods.Count > 0)
            {
                cbIsSubscription.Checked = _licenseData.IsSubscription;

                foreach (var period in _licenseData.LicensePeriods)
                {
                    _subscriptionPeriods.Add(period.Period);
                }

                DataGridViewMethods.UpdatePeriodsDataGrid(_subscriptionPeriods, dgvSubscriptionPeriods);
            }

            // Load in Attachments
            if (_licenseData.LicenseAttachments.Count > 0)
            {
                foreach (var attachment in _licenseData.LicenseAttachments)
                {
                    _attachments.Add(attachment.Attachment);
                }

                DataGridViewMethods.UpdateAttachmentDataGrid(_attachments, dgvAttachments);
            }

        }

        /// <summary>
        /// Adds a new license to the <see cref="DatabaseContext"/> but does not save it.
        /// </summary>
        /// <param name="manufacturer">
        /// Manufacturer of the license, <see cref="Manufacturer"/>
        /// </param>
        /// <param name="contractId">
        /// Id of the contract being assigned, <see cref="Models.Contract"/>
        /// </param>
        /// <param name="platform">
        /// Platform the license runs on, <see cref="Platform"/>
        /// </param>
        private void AddLicense(Manufacturer manufacturer, int? contractId, Platform platform)
        {
            // Ensure we don't mark it as having a Subscription if there are no periods
            if (_subscriptionPeriods.Count == 0)
            {
                cbIsSubscription.Checked = false;
            }

            var licenseData = new Models.License
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Count = Convert.ToInt32(numCount.Value),
                IsSubscription = cbIsSubscription.Checked,
                IsSubscriptionContract = false, // TODO: Implement
                PurchaseDate = DateOnly.FromDateTime(dtPurchaseDate.Value),
                ManufacturerId = manufacturer.ManufacturerId,
                Price = Convert.ToInt32(numCost.Value),
                OrderReference = txtOrderRef.Text,
                LicenseKey = txtLicenseKey.Text,
                Version = txtVersion.Text,
                PlatformId = platform.PlatformId,
                ContractId = contractId ?? null,
                RegisteredEmail = txtInfoContactEmail.Text,
                RegisteredUser = txtInfoContactName.Text
            };

            foreach (var period in _subscriptionPeriods)
            {
                LicensePeriod licensePeriod = new()
                {
                    License = licenseData,
                    Period = period
                };

                licenseData.LicensePeriods.Add(licensePeriod);
            }

            foreach (var attachment in _attachments)
            {
                LicenseAttachment licenseAttachment = new()
                {
                    License = licenseData,
                    Attachment = attachment
                };
                licenseData.LicenseAttachments.Add(licenseAttachment);
            }

            try
            {
                _dbContext.Licenses.Add(licenseData);

                ActionLogMethods.Added(_dbContext, Utils.Enums.ActionAlertCategory.License, txtName.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmLicenseModify>($"{ex}");
            }
        }

        /// <summary>
        /// Updates the license against the <see cref="DatabaseContext"/> but does not save it.
        /// </summary>
        /// <param name="manufacturer">
        /// Manufacturer of the license, <see cref="Manufacturer"/>
        /// </param>
        /// <param name="contractId">
        /// Id of the contract being assigned, <see cref="Models.Contract"/>
        /// </param>
        /// <param name="platform">
        /// Platform the license runs on, <see cref="Platform"/>
        /// </param>
        /// <exception cref="EntryPointNotFoundException">
        /// Exception thrown if _licenseData is null
        /// </exception>
        private void UpdateLicense(Manufacturer manufacturer, int? contractId, Platform platform)
        {
            if (_licenseData == null)
            {
                throw new Exception("LicenseData has not been populated");
            }

            if (_subscriptionPeriods.Count == 0)
            {
                cbIsSubscription.Checked = false;
            }

            _licenseData.Name = txtName.Text;
            _licenseData.Description = txtDescription.Text;
            _licenseData.Count = Convert.ToInt32(numCount.Value);
            _licenseData.IsSubscription = cbIsSubscription.Checked;
            _licenseData.IsSubscriptionContract = false; // TODO: Implement
            _licenseData.PurchaseDate = DateOnly.FromDateTime(dtPurchaseDate.Value);
            _licenseData.ManufacturerId = manufacturer.ManufacturerId;
            _licenseData.Price = Convert.ToInt32(numCost.Value);
            _licenseData.OrderReference = txtOrderRef.Text;
            _licenseData.LicenseKey = txtLicenseKey.Text;
            _licenseData.Version = txtVersion.Text;
            _licenseData.PlatformId = platform.PlatformId;
            _licenseData.ContractId = contractId ?? null;
            _licenseData.RegisteredUser = txtInfoContactName.Text;
            _licenseData.RegisteredEmail = txtInfoContactEmail.Text;
            _licenseData.Platform = platform;

            // Remove Subscription and Attachment associations that are no longer present
            var existingPeriods = _dbContext.LicensePeriods.Where(lp => lp.LicenseId == _licenseData.Id).ToList();
            var existingAttachments = _dbContext.LicenseAttachments.Where(la => la.LicenseId == _licenseData.Id).ToList();

            foreach (var existingPeriod in existingPeriods)
            {
                // Check if the existing period is in the updated list of periods
                bool isPeriodInUpdatedList = _subscriptionPeriods.Any(period => period.PeriodId == existingPeriod.PeriodId);

                if (!isPeriodInUpdatedList)
                {
                    _dbContext.Periods.Remove(existingPeriod.Period);
                }
            }

            foreach (var existingAttachment in existingAttachments)
            {
                bool isAttachmentInUpdatedList = _attachments.Any(attachment => attachment.AttachmentId == existingAttachment.AttachmentId);

                if (!isAttachmentInUpdatedList)
                {
                    _dbContext.Attachments.Remove(existingAttachment.Attachment);
                }
            }

            // Update the associated periods for the License
            foreach (var period in _subscriptionPeriods)
            {
                // Check if the period is already associated with the license
                bool isPeriodAssociated = _licenseData.LicensePeriods.Any(lp => lp.PeriodId == period.PeriodId);

                if (!isPeriodAssociated)
                {
                    // If the period is not associated, create a new PeriodLicenses entry
                    LicensePeriod licensePeriod = new()
                    {
                        LicenseId = _licenseData.Id,
                        License = _licenseData,
                        PeriodId = period.PeriodId,
                        Period = period
                    };

                    _dbContext.LicensePeriods.Add(licensePeriod);
                }
            }

            foreach (var attachment in _attachments)
            {
                bool isAttachmentAssociated = _licenseData.LicenseAttachments.Any(la => la.AttachmentId == attachment.AttachmentId);

                if (!isAttachmentAssociated)
                {
                    LicenseAttachment licenseAttachment = new()
                    {
                        LicenseId = _licenseData.Id,
                        License = _licenseData,
                        AttachmentId = attachment.AttachmentId,
                        Attachment = attachment,
                    };

                    _dbContext.LicenseAttachments.Add(licenseAttachment);
                }
            }

            try
            {
                _dbContext.Licenses.Update(_licenseData);

                ActionLogMethods.Updated(_dbContext, Utils.Enums.ActionAlertCategory.License, txtName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmLicenseModify>($"{ex}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            _dbContext.Dispose();
        }
    
        /// <summary>
        /// Populates the relevant ComboBoxes
        /// </summary>
        private void PopulateComboBoxes()
        {
            // Load Manufacturer Data into the ComboBox
            cmbManufacturers.DataSource = _dbContext.Manufacturers.ToList();
            cmbManufacturers.DisplayMember = "Name";
            cmbManufacturers.ValueMember = "ManufacturerId";

            // Load Contract Data into the ComboBox
            cmbContracts.DataSource = _dbContext.Contracts.ToList();
            cmbContracts.DisplayMember = "Name";
            cmbContracts.ValueMember = "ContractId";

            // Load the Platform Data into the ComboBox
            cmbPlatforms.DataSource = _dbContext.Platforms.ToList();
            cmbPlatforms.DisplayMember = "Name";
            cmbPlatforms.ValueMember = "PlatformId";
        }

        private void SetReadOnly(Control control)
        {
            foreach(Control ctrl in control.Controls)
            {
                switch (ctrl)
                {
                    case TextBox tbx:
                        tbx.ReadOnly = true;
                        break;

                    case ComboBox cbx:
                        cbx.Enabled = false;
                        break;

                    case Button btn:
                        btn.Visible = false;
                        break;

                    case DateTimePicker dtp:
                        dtp.Enabled = false;
                        break;

                    case LinkLabel ll:
                        ll.Visible = false;
                        break;

                    case CheckBox cbk:
                        cbk.Visible = false;
                        break;
                }

                if (ctrl.HasChildren)
                {
                    SetReadOnly(ctrl);
                }
            }

            deleteToolStripMenuItem.Enabled = false;
        }
    }
}

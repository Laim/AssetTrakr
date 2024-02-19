using AssetTrakr.App.Forms.Attachment;
using AssetTrakr.App.Forms.Contract;
using AssetTrakr.App.Forms.Shared;
using AssetTrakr.App.Helpers;
using AssetTrakr.Database;
using AssetTrakr.Models;
using AssetTrakr.Models.Assets;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Security.Policy;

namespace AssetTrakr.App.Forms.Asset
{
    public partial class FrmAssetModify : Form
    {
        private readonly DatabaseContext _dbContext;
        private BindingList<Models.Attachment> _attachments = [];
        private BindingList<Period> _warrantyPeriods = [];
        private BindingList<AssetNetworkAdapter> _networkAdapters = [];
        private BindingList<AssetHardDrive> _hardDrives = [];
        private readonly Models.Assets.Asset? _assetData;
        private readonly bool _isEditingMode;

        public FrmAssetModify(int assetId = 0)
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();

            if (assetId <= 0)
            {
                return;
            }

            var asset = _dbContext.Assets
                .Include(a => a.Contract)
                .Include(a => a.Manufacturer)
                .Include(a => a.Platform)
                .Include(a => a.OperatingSystem)
                .Include(a => a.Hardware)
                    .ThenInclude(aa => aa.NetworkAdapters)
                .Include(a => a.Hardware)
                    .ThenInclude(aa => aa.HardDrives)
                .Include(a => a.Warranties)
                    .ThenInclude(wp => wp.Period)
                .Include(a => a.AssetAttachments)
                    .ThenInclude(aa => aa.Attachment)
                .FirstOrDefault(l => l.Id == assetId);

            if (asset != null)
            {
                _assetData = asset;
                _isEditingMode = true;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PopulateComboBoxes();

            if (_isEditingMode)
            {
                LoadAssetData();
            }
        }

        /// <summary>
        /// This loads the asset data from the SQLite database.  This runs if the assetId passed at run time is NOT 0.
        /// </summary>
        private void LoadAssetData()
        {
            if (_assetData == null)
            {
                MessageBox.Show($"Could not find Asset Data.", "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // Update general form info
            btnAddUpdate.Text = "Update";
            Text = $"Modify Asset - {_assetData.Name}";

            txtName.Text = _assetData.Name;
            txtModel.Text = _assetData.Model;
            txtLicenseKey.Text = _assetData.LicenseKey;
            txtDescription.Text = _assetData.Description;
            dtPurchaseDate.Value = _assetData.PurchaseDate.ToDateTime(TimeOnly.MinValue);
            txtInfoContactName.Text = _assetData.RegisteredUser;
            txtInfoContactEmail.Text = _assetData.RegisteredEmail;

            cmbManufacturers.SelectedIndex = cmbManufacturers.FindStringExact(_assetData.Manufacturer?.Name);
            cmbPlatforms.SelectedIndex = cmbPlatforms.FindStringExact(_assetData.Platform?.Name);
            cmbContracts.SelectedIndex = cmbContracts.FindStringExact(_assetData.Contract?.Name);
            cmbOperatingSystems.SelectedIndex = cmbOperatingSystems.FindStringExact(_assetData.OperatingSystem?.Name);

            numCost.Value = _assetData.Price;
            txtOrderRef.Text = _assetData.OrderReference;

            txtBiosSerialNumber.Text = _assetData.Hardware.BiosSerialNumber;
            txtProcessor.Text = _assetData.Hardware.Processor;
            numRamSizeInGB.Value = _assetData.Hardware.RamSizeInGB;
            numRamSticks.Value = _assetData.Hardware.RamSticks;

            // Load in Network Adapters
            if (_assetData.Hardware.NetworkAdapters.Count > 0)
            {
                foreach(var adapter in _assetData.Hardware.NetworkAdapters)
                {
                    _networkAdapters.Add(adapter);
                }

                DataGridViewMethods.UpdateNetworkDataGrid(_networkAdapters, dgvNetworkAdapters);
            }

            // Load in Hard Drives
            if (_assetData.Hardware.HardDrives.Count > 0)
            {
                foreach(var drive in _assetData.Hardware.HardDrives)
                { 
                    _hardDrives.Add(drive);
                }

                DataGridViewMethods.UpdateDriveDataGrid(_hardDrives, dgvHardDrives);
            }

            // Load in Warranty Information
            if (_assetData.IsUnderWarranty && _assetData.Warranties.Count > 0)
            {
                cbHasWarranty.Checked = _assetData.IsUnderWarranty;

                foreach (var period in _assetData.Warranties)
                {
                    _warrantyPeriods.Add(period.Period);
                }

                DataGridViewMethods.UpdatePeriodsDataGrid(_warrantyPeriods, dgvWarrantyPeriods);
            }

            // Load in Attachments
            if (_assetData.AssetAttachments.Count > 0)
            {
                foreach (var attachment in _assetData.AssetAttachments)
                {
                    _attachments.Add(attachment.Attachment);
                }

                DataGridViewMethods.UpdateAttachmentDataGrid(_attachments, dgvAttachments);
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

        private void btnAddWarranty_Click(object sender, EventArgs e)
        {
            FrmPeriodAdd frmSubscriptionPeriodAdd = new(_warrantyPeriods);
            frmSubscriptionPeriodAdd.ShowDialog();

            if (frmSubscriptionPeriodAdd.Periods != null && frmSubscriptionPeriodAdd.Periods.Count > 0)
            {
                _warrantyPeriods = frmSubscriptionPeriodAdd.Periods;
                DataGridViewMethods.UpdatePeriodsDataGrid(_warrantyPeriods, dgvWarrantyPeriods);
            }
        }

        private void cbHasWarranty_CheckedChanged(object sender, EventArgs e)
        {
            btnAddWarranty.Enabled = cbHasWarranty.Checked;
            dgvWarrantyPeriods.Enabled = cbHasWarranty.Checked;

            // if we uncheck, remove all the periods
            if (!cbHasWarranty.Checked && dgvWarrantyPeriods.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Unmarking this as having Warranty will remove " +
                    "all of the existing periods.  Do you wish to continue?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    _warrantyPeriods.Clear();
                }
                else if (dr == DialogResult.No)
                {
                    // recheck the checkbox
                    cbHasWarranty.Checked = true;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv || dgv.Rows.Count == 0)
            {
                return;
            }

            if (dgv.Name == nameof(dgvAttachments))
            {
                var dataItem = dgv.Rows[dgv.SelectedRows[0].Index].DataBoundItem;

                if (dataItem is Models.Attachment selectedItem)
                {
                    _attachments.Remove(selectedItem);
                }
                else
                {
                    throw new Exception("Attachment has not been set or cannot be found");
                }
            }
            else if (dgv.Name == nameof(dgvWarrantyPeriods))
            {
                var dataItem = dgv.Rows[dgv.SelectedRows[0].Index].DataBoundItem;

                if (dataItem is Period selectedItem)
                {
                    _warrantyPeriods.Remove(selectedItem);
                }
                else
                {
                    throw new Exception("Period has not been set or cannot be found");
                }
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

        private void cmbOperatingSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is not ComboBox cmb)
            {
                return;
            }

            if (cmb.SelectedIndex == 0)
            {
                lnkModifyOS.Visible = false;
                return;
            }

            lnkModifyOS.Visible = true;
        }

        private void lnkAddOS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Not implemented"); // TODO: Implement
        }

        private void lnkModifyOS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Not implemented"); // TODO: Implement
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            _dbContext.Dispose();
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
            var selectedContract = cmbContracts.SelectedItem as Models.Contract;
            var selectedPlatform = cmbPlatforms.SelectedItem as Platform;
            var selectedOS = cmbOperatingSystems.SelectedItem as AssetOperatingSystem;

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

            if (selectedOS == null)
            {
                MessageBox.Show($"Operating System is a required field", "Operating System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_isEditingMode)
            {
                AddAsset(selectedManufacturer, selectedContractId, selectedPlatform, selectedOS, selectedContract);
            }
            else
            {
                UpdateAsset(selectedManufacturer, selectedContractId, selectedPlatform, selectedOS, selectedContract);
            }

            if (_dbContext.SaveChanges() > 0)
            {
                MessageBox.Show($"{txtName.Text} saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void UpdateAsset(Manufacturer manufacturer, int? contractId, Platform platform, AssetOperatingSystem operatingSystem, Models.Contract contract)
        {
            if (_assetData == null)
            {
                throw new Exception("AssetData has not been populated");
            }

            if (_warrantyPeriods.Count == 0)
            {
                cbHasWarranty.Checked = false;
            }

            if(_warrantyPeriods.Count == 0)
            {
                cbHasWarranty.Checked = false;
            }

            _assetData.Name = txtName.Text;
            _assetData.Description = txtDescription.Text;
            _assetData.PurchaseDate = DateOnly.FromDateTime(dtPurchaseDate.Value);
            _assetData.Price = Convert.ToInt32(numCost.Value);
            _assetData.Model = txtModel.Text;
            _assetData.Manufacturer = manufacturer;
            _assetData.ManufacturerId = manufacturer.ManufacturerId;
            _assetData.Platform = platform;
            _assetData.PlatformId = platform.PlatformId;
            _assetData.LicenseKey = txtLicenseKey.Text;
            _assetData.OrderReference = txtOrderRef.Text;
            _assetData.OperatingSystem = operatingSystem;
            _assetData.Contract = contract;
            _assetData.ContractId = contractId;
            _assetData.RegisteredEmail = txtInfoContactEmail.Text;
            _assetData.RegisteredUser = txtInfoContactName.Text;

            _assetData.Hardware.Processor = txtProcessor.Text;
            _assetData.Hardware.BiosSerialNumber = txtBiosSerialNumber.Text;
            _assetData.Hardware.RamSizeInGB = Convert.ToInt32(numRamSizeInGB.Value);
            _assetData.Hardware.RamSticks = Convert.ToInt32(numRamSticks.Value);

            // network adapaters -- existing
            var existingAdapters = _dbContext.AssetNetworkAdapters.Where(na => na.AssetHardwareId == _assetData.Hardware.AssetHardwareId).ToList();
            
            foreach(var existing in existingAdapters)
            {
                bool isAdapterInUpdatedList = _networkAdapters.Any(adapter => adapter.NetworkAdapterId == existing.NetworkAdapterId);

                if(!isAdapterInUpdatedList)
                {
                    _dbContext.AssetNetworkAdapters.Remove(existing);
                }
            }

            // hard drives -- existing
            var existingDrives = _dbContext.AssetHardDrives.Where(hd => hd.AssetHardwareId == _assetData.Hardware.AssetHardwareId).ToList();

            foreach(var existing in existingDrives)
            {
                bool isDriveInUpdatedList = _hardDrives.Any(drive => drive.HardDriveId == existing.HardDriveId);

                if(!isDriveInUpdatedList)
                {
                    _dbContext.AssetHardDrives.Remove(existing);
                }
            }

            // warranty -- existing
            var existingPeriods = _dbContext.AssetPeriods.Where(ap => ap.AssetId == _assetData.Id).ToList();

            foreach (var existing in existingPeriods)
            {
                bool isPeriodInUpdatedList = _warrantyPeriods.Any(period => period.PeriodId == existing.PeriodId);

                if (!isPeriodInUpdatedList)
                {
                    _dbContext.Periods.Remove(existing.Period);
                }
            }

            // network adapters -- new
            foreach (var adapter in _networkAdapters)
            {
                bool isAdapaterAssociated = _assetData.Hardware.NetworkAdapters.Any(na => na.NetworkAdapterId == adapter.NetworkAdapterId);

                if(!isAdapaterAssociated)
                {
                    AssetNetworkAdapter networkAdapter = new()
                    {
                        Name = adapter.Name,
                        IpAddress = adapter.IpAddress,
                        MacAddress = adapter.MacAddress,
                    };

                    _assetData.Hardware.NetworkAdapters.Add(networkAdapter);
                }
            }

            // hard drives -- new
            foreach(var drive in _hardDrives)
            {
                bool isDriveAssociated = _assetData.Hardware.HardDrives.Any(hd => hd.HardDriveId == drive.HardDriveId);

                if (!isDriveAssociated)
                {
                    AssetHardDrive hardDrive = new()
                    {
                        Name = drive.Name, 
                        Manufacturer = drive.Manufacturer,
                        ManufacturerId = drive.ManufacturerId,
                        SerialNumber = drive.SerialNumber,
                        SizeInGB = drive.SizeInGB                        
                    };

                    _assetData.Hardware.HardDrives.Add(hardDrive);
                }
            }


            try
            {
                _dbContext.Assets.Update(_assetData);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }

        }

        private void AddAsset(Manufacturer manufacturer, int? contractId, Platform platform, AssetOperatingSystem os, Models.Contract contract)
        {
            // Ensure that we don't accidentally mark it as having warranty if there are no warranty periods available
            if (_warrantyPeriods.Count == 0)
            {
                cbHasWarranty.Checked = false;
            }

            List<AssetHardDrive> driveList = [];
            foreach (var drive in _hardDrives)
            {
                driveList.Add(drive);
            }

            List<AssetNetworkAdapter> adapterList = [];
            foreach (var adapter in _networkAdapters)
            {
                adapterList.Add(adapter);
            }

            var assetData = new Models.Assets.Asset
            {
                Name = txtName.Text,
                Model = txtModel.Text,
                LicenseKey = txtLicenseKey.Text,
                Description = txtDescription.Text,
                PurchaseDate = DateOnly.FromDateTime(dtPurchaseDate.Value),
                RegisteredUser = txtInfoContactName.Text,
                RegisteredEmail = txtInfoContactEmail.Text,
                ContractId = contractId ?? null,
                PlatformId = platform.PlatformId,
                ManufacturerId = manufacturer.ManufacturerId,
                OperatingSystem = os,
                Price = Convert.ToInt32(numCost.Value),
                OrderReference = txtOrderRef.Text,
                IsUnderWarranty = cbHasWarranty.Checked,
                Hardware = new AssetHardware
                {
                    BiosSerialNumber = txtBiosSerialNumber.Text,
                    HardDrives = driveList,
                    NetworkAdapters = adapterList,
                    Processor = txtProcessor.Text,
                    RamSizeInGB = Convert.ToInt32(numRamSizeInGB.Value),
                    RamSticks = Convert.ToInt32(numRamSticks.Value)
                }
            };


            foreach (var period in _warrantyPeriods)
            {
                AssetPeriod assetPeriod = new()
                {
                    Asset = assetData,
                    Period = period
                };

                assetData.Warranties.Add(assetPeriod);
            }

            foreach (var attachment in _attachments)
            {
                AssetAttachment assetAttachment = new()
                {
                    Asset = assetData,
                    Attachment = attachment
                };

                assetData.AssetAttachments.Add(assetAttachment);
            }

            _dbContext.Assets.Add(assetData);
        }

        private void btnAddNetworkAdapter_Click(object sender, EventArgs e)
        {
            FrmAssetNetworkAdapterAdd frmAssetNetworkAdapter = new(_networkAdapters);
            frmAssetNetworkAdapter.ShowDialog();

            if (frmAssetNetworkAdapter.NetworkAdapters != null && frmAssetNetworkAdapter.NetworkAdapters.Count > 0)
            {
                _networkAdapters = frmAssetNetworkAdapter.NetworkAdapters;

                DataGridViewMethods.UpdateNetworkDataGrid(_networkAdapters, dgvNetworkAdapters);
            }
        }

        private void btnAddHardDrive_Click(object sender, EventArgs e)
        {
            FrmAssetHardDriveAdd frmAssetHardDriveAdd = new(_hardDrives);
            frmAssetHardDriveAdd.ShowDialog();

            if (frmAssetHardDriveAdd.HardDrives != null && frmAssetHardDriveAdd.HardDrives.Count > 0)
            {
                _hardDrives = frmAssetHardDriveAdd.HardDrives;

                DataGridViewMethods.UpdateDriveDataGrid(_hardDrives, dgvHardDrives);
            }
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

            // Load the OS Data into the ComboBox
            cmbOperatingSystems.DataSource = _dbContext.AssetOperatingSystems.ToList();
            cmbOperatingSystems.DisplayMember = "Name";
            cmbOperatingSystems.ValueMember = "OperatingSystemId";
        }
    }
}

using AssetTrakr.App.Forms.Attachment;
using AssetTrakr.App.Forms.Contract;
using AssetTrakr.App.Forms.Shared;
using AssetTrakr.App.Helpers;
using AssetTrakr.Database;
using AssetTrakr.Logging;
using AssetTrakr.Models;
using AssetTrakr.Models.Assets;
using AssetTrakr.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics;
using AssetTrakr.WinForms.ActionLog;

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

        public FrmAssetModify(int assetId = 0, bool isReadOnly = false)
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
                .Include(a => a.AssetPeriods)
                    .ThenInclude(wp => wp.Period)
                .Include(a => a.AssetAttachments)
                    .ThenInclude(aa => aa.Attachment)
                .FirstOrDefault(l => l.AssetId == assetId);

            if (asset != null)
            {
                _assetData = asset;
                _isEditingMode = true;

                // Update general form info
                btnAddUpdate.Text = "Update";
                Text = $"Modify Asset - {_assetData.Name}";
            }

            if (isReadOnly && _assetData != null)
            {
                Helpers.Utils.SetReadOnly(this, deleteToolStripMenuItem);
                Text = $"Viewing Asset - {_assetData.Name}";
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

            // this is dumb as shit.
            // every time i changed the link labels TabStop to false
            // visual studio reverted it back to true? piece of garbage
            lnkAddContract.TabStop = false;
            lnkAddManufacturer.TabStop = false;
            lnkAddPlatform.TabStop = false;
            lnkManageOS.TabStop = false;
            lnkModifyContract.TabStop = false;
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
            cmbAssetType.SelectedIndex = (int)_assetData.Hardware.AssetType;

            numCost.Value = _assetData.Price;
            txtOrderRef.Text = _assetData.OrderReference;

            txtBiosSerialNumber.Text = _assetData.Hardware.BiosSerialNumber;
            txtProcessor.Text = _assetData.Hardware.Processor;
            numRamSizeInGB.Value = _assetData.Hardware.RamSizeInGB;
            numRamSticks.Value = _assetData.Hardware.RamSticks;

            // Load in Network Adapters
            if (_assetData.Hardware.NetworkAdapters.Count > 0)
            {
                foreach (var adapter in _assetData.Hardware.NetworkAdapters)
                {
                    _networkAdapters.Add(adapter);
                }

                DataGridViewMethods.UpdateNetworkDataGrid(_networkAdapters, dgvNetworkAdapters);
            }

            // Load in Hard Drives
            if (_assetData.Hardware.HardDrives.Count > 0)
            {
                foreach (var drive in _assetData.Hardware.HardDrives)
                {
                    _hardDrives.Add(drive);
                }

                DataGridViewMethods.UpdateDriveDataGrid(_hardDrives, dgvHardDrives);
            }

            // Load in Warranty Information
            if (_assetData.IsUnderWarranty && _assetData.AssetPeriods.Count > 0)
            {
                cbHasWarranty.Checked = _assetData.IsUnderWarranty;

                foreach (var period in _assetData.AssetPeriods)
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

            var dataItem = dgv.Rows[dgv.SelectedRows[0].Index].DataBoundItem;

            // If attachments datagrid
            if (dataItem is Models.Attachment attachment)
            {
                _attachments.Remove(attachment);
                return;
            }

            // If warranty datagrid
            if (dataItem is Period warranty)
            {
                _warrantyPeriods.Remove(warranty);
                return;
            }

            // If network adapaters datagrid
            if (dataItem is AssetNetworkAdapter networkAdapter)
            {
                _networkAdapters.Remove(networkAdapter);
                return;
            }

            // If hard drives datagrid
            // we do this differently because the return item is not of type AssetHardDrive
            // see DataGridViewMethods.UpdateDriveDataGrid(..)
            if (dgv.Name == nameof(dgvHardDrives))
            {
                var drive = dgv.SelectedRows[0].Index;
                _hardDrives.RemoveAt(drive);
                DataGridViewMethods.UpdateDriveDataGrid(_hardDrives, dgvHardDrives);
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv || dgv.Rows.Count == 0)
            {
                return;
            }

            // this should never actually happen since view is only enabled on cms show if the dgv is dgvAttachments, but alas
            if (dgv.Name != nameof(dgvAttachments))
            {
                return;
            }

            var dataItem = dgv.Rows[dgv.SelectedRows[0].Index].DataBoundItem;

            if (dataItem is not Models.Attachment attachment)
            {
                return;
            }

            if(attachment.Type == AttachmentType.Url)
            {

                DialogResult dr = MessageBox.Show($"Do you wish to go to {attachment.Url}?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    Process.Start(
                        new ProcessStartInfo($"{attachment.Url}")
                        {
                            UseShellExecute = true
                        }
                    );
                }
                return;
            }

            if(attachment.Type == AttachmentType.File)
            {
                DialogResult dr = MessageBox.Show($"Do you wish to download and open {attachment.Name}{attachment.DataType}?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(dr == DialogResult.Yes)
                {
                    string filePath = Path.Combine(Path.GetTempPath(), $"{attachment.Name}{attachment.DataType}");

                    try
                    {
                        File.WriteAllBytes(filePath, attachment.Data);

                        Process.Start(
                            new ProcessStartInfo($"{filePath}")
                            {
                                UseShellExecute = true
                            }
                        );

                    } 
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.Error<FrmAssetModify>($"{ex}");
                    }
                }
            }

        }

        private void cmsDgvRightClick_Opening(object sender, CancelEventArgs e)
        {

            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            if (dgv.Name == nameof(dgvAttachments))
            {
                viewToolStripMenuItem.Visible = true;
            }
            else
            {
                viewToolStripMenuItem.Visible = false;
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

            if (cmb.SelectedIndex == -1)
            {
                lnkModifyContract.Visible = false;
                return;
            }

            lnkModifyContract.Visible = true;
        }

        private void lnkModifyContract_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmContractModify frmContractModify = new(Convert.ToInt32(cmbContracts.SelectedValue));
            frmContractModify.ShowDialog();

            PopulateComboBoxes();
        }

        private void lnkManageOS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmOperatingSystemManager FrmOperatingSystemManager = new();
            FrmOperatingSystemManager.ShowDialog();

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
                AddAsset(selectedManufacturer, selectedPlatform, selectedOS, selectedContract);
            }
            else
            {
                UpdateAsset(selectedManufacturer, selectedPlatform, selectedOS, selectedContract);
            }

            if (_dbContext.SaveChanges() > 0)
            {
                MessageBox.Show($"{txtName.Text} saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show($"Something has gone wrong during save of {txtName.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAsset(Manufacturer manufacturer, Platform platform, AssetOperatingSystem operatingSystem, Models.Contract contract)
        {
            if (_assetData == null)
            {
                throw new Exception("AssetData has not been populated");
            }

            if (_warrantyPeriods.Count == 0)
            {
                cbHasWarranty.Checked = false;
            }

            _assetData.Name = txtName.Text;
            _assetData.Description = txtDescription.Text;
            _assetData.PurchaseDate = DateOnly.FromDateTime(dtPurchaseDate.Value);
            _assetData.Price = Convert.ToInt32(numCost.Value);
            _assetData.Model = txtModel.Text;
            _assetData.Manufacturer = manufacturer;
            _assetData.Platform = platform;
            _assetData.LicenseKey = txtLicenseKey.Text;
            _assetData.OrderReference = txtOrderRef.Text;
            _assetData.OperatingSystem = operatingSystem;
            _assetData.Contract = contract;
            _assetData.RegisteredEmail = txtInfoContactEmail.Text;
            _assetData.RegisteredUser = txtInfoContactName.Text;

            _assetData.Hardware.Processor = txtProcessor.Text;
            _assetData.Hardware.BiosSerialNumber = txtBiosSerialNumber.Text;
            _assetData.Hardware.RamSizeInGB = Convert.ToInt32(numRamSizeInGB.Value);
            _assetData.Hardware.RamSticks = Convert.ToInt32(numRamSticks.Value);
            _assetData.Hardware.AssetType = (AssetType)cmbAssetType.SelectedIndex;

            // network adapaters -- existing
            var existingAdapters = _dbContext.AssetNetworkAdapters.Where(na => na.AssetHardwareId == _assetData.Hardware.AssetHardwareId).ToList();
            foreach (var existing in existingAdapters)
            {
                bool isAdapterInUpdatedList = _networkAdapters.Any(adapter => adapter.NetworkAdapterId == existing.NetworkAdapterId);

                if (!isAdapterInUpdatedList)
                {
                    _dbContext.AssetNetworkAdapters.Remove(existing);
                }
            }

            // hard drives -- existing
            var existingDrives = _dbContext.AssetHardDrives.Where(hd => hd.AssetHardwareId == _assetData.Hardware.AssetHardwareId).ToList();
            foreach (var existing in existingDrives)
            {
                bool isDriveInUpdatedList = _hardDrives.Any(drive => drive.HardDriveId == existing.HardDriveId);

                if (!isDriveInUpdatedList)
                {
                    _dbContext.AssetHardDrives.Remove(existing);
                }
            }

            // warranty -- existing
            var existingPeriods = _dbContext.AssetPeriods.Where(ap => ap.AssetId == _assetData.AssetId).ToList();
            foreach (var existing in existingPeriods)
            {
                bool isPeriodInUpdatedList = _warrantyPeriods.Any(period => period.PeriodId == existing.PeriodId);

                if (!isPeriodInUpdatedList)
                {
                    _dbContext.Periods.Remove(existing.Period);
                }
            }

            // attachments -- existing
            var existingAttachments = _dbContext.AssetAttachments.Where(aa => aa.AssetId == _assetData.AssetId).ToList();
            foreach (var existing in existingAttachments)
            {
                bool isAttachmentInUpdatedList = _attachments.Any(attach => attach.AttachmentId == existing.AttachmentId);

                if (!isAttachmentInUpdatedList)
                {
                    _dbContext.Attachments.Remove(existing.Attachment);
                }
            }

            // network adapters -- new
            foreach (var adapter in _networkAdapters)
            {
                bool isAdapaterAssociated = _assetData.Hardware.NetworkAdapters.Any(na => na.NetworkAdapterId == adapter.NetworkAdapterId);

                if (!isAdapaterAssociated)
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
            foreach (var drive in _hardDrives)
            {
                bool isDriveAssociated = _assetData.Hardware.HardDrives.Any(hd => hd.HardDriveId == drive.HardDriveId);

                if (!isDriveAssociated)
                {
                    AssetHardDrive hardDrive = new()
                    {
                        Name = drive.Name,
                        Manufacturer = drive.Manufacturer,
                        SerialNumber = drive.SerialNumber,
                        SizeInGB = drive.SizeInGB
                    };

                    _assetData.Hardware.HardDrives.Add(hardDrive);
                }
            }

            // attachments -- new
            foreach (var attachment in _attachments)
            {
                bool isAttachmentAssociated = _assetData.AssetAttachments.Any(aa => aa.AttachmentId == attachment.AttachmentId);

                if (!isAttachmentAssociated)
                {
                    AssetAttachment assetAttachment = new()
                    {
                        AssetId = _assetData.AssetId,
                        Asset = _assetData,
                        AttachmentId = attachment.AttachmentId,
                        Attachment = attachment,
                    };

                    _dbContext.AssetAttachments.Add(assetAttachment);

                }
            }

            // warranty -- new
            foreach (var warrantyPeriod in _warrantyPeriods)
            {
                bool isWarrantyAssociated = _assetData.AssetPeriods.Any(aw => aw.PeriodId == warrantyPeriod.PeriodId);

                if (!isWarrantyAssociated)
                {
                    AssetPeriod assetPeriod = new()
                    {
                        AssetId = _assetData.AssetId,
                        Asset = _assetData,
                        PeriodId = warrantyPeriod.PeriodId,
                        Period = warrantyPeriod
                    };

                    _dbContext.AssetPeriods.Add(assetPeriod);
                }
            }

            try
            {
                _dbContext.Assets.Update(_assetData);

                ActionLogMethods.Updated(_dbContext, ActionAlertCategory.Asset, txtName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmAssetModify>($"{ex}");
            }

        }

        private void AddAsset(Manufacturer manufacturer, Platform platform, AssetOperatingSystem os, Models.Contract contract)
        {
            // Ensure that we don't accidentally mark it as having warranty if there are no warranty periods available
            if (_warrantyPeriods.Count == 0)
            {
                cbHasWarranty.Checked = false;
                MessageBox.Show("No Warranty Periods added so HasWarranty will be unchecked", "Warranty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                Contract = contract,
                Platform = platform,
                Manufacturer = manufacturer,
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
                    RamSticks = Convert.ToInt32(numRamSticks.Value),
                    AssetType = (AssetType)cmbAssetType.SelectedIndex,
                }
            };


            foreach (var period in _warrantyPeriods)
            {
                AssetPeriod assetPeriod = new()
                {
                    Asset = assetData,
                    Period = period
                };

                assetData.AssetPeriods.Add(assetPeriod);
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

            try
            {
                _dbContext.Assets.Add(assetData);

                ActionLogMethods.Added(_dbContext, ActionAlertCategory.Asset, txtName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmAssetModify>($"{ex}");
            }
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
            FrmAssetHardDriveAdd frmAssetHardDriveAdd = new(_hardDrives, _dbContext.Manufacturers.ToList());
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

            if (_assetData == null)
            {
                cmbContracts.SelectedIndex = -1;
            }

            // Load the Platform Data into the ComboBox
            cmbPlatforms.DataSource = _dbContext.Platforms.ToList();
            cmbPlatforms.DisplayMember = "Name";
            cmbPlatforms.ValueMember = "PlatformId";

            // Load the OS Data into the ComboBox
            cmbOperatingSystems.DataSource = _dbContext.AssetOperatingSystems.ToList();
            cmbOperatingSystems.DisplayMember = "Name";
            cmbOperatingSystems.ValueMember = "OperatingSystemId";

            // Load the Asset Types into The ComboBox
            cmbAssetType.DataSource = Enum.GetNames(typeof(AssetType));
        }

    }
}

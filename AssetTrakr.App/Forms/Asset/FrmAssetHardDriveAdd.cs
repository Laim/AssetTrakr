using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Database;
using AssetTrakr.Models;
using AssetTrakr.Models.Assets;
using System.ComponentModel;

namespace AssetTrakr.App.Forms.Asset
{
    public partial class FrmAssetHardDriveAdd : Form
    {
        public BindingList<AssetHardDrive> HardDrives = [];

        public FrmAssetHardDriveAdd(BindingList<AssetHardDrive> Drives, List<Manufacturer> manufacturers)
        {
            InitializeComponent();

            HardDrives ??= [];

            // To account for previously added and prevent data loss on user end
            if (Drives != null)
            {
                HardDrives = Drives;
            }

            RefreshManufacturers(manufacturers);
        }

        private void lnkAddManufacturer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmManufacturerManager frmManufacturerManager = new();
            frmManufacturerManager.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbManufacturers.SelectedItem is not Manufacturer selectedManufacturer)
            {
                MessageBox.Show($"Manufacturer is required.", "Manufacturer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HardDrives.Add(new AssetHardDrive
            {
                Manufacturer = selectedManufacturer,
                Name = txtName.Text,
                SizeInGB = Convert.ToInt32(numSizeBytes.Value),
                SerialNumber = txtSerialNumber.Text,
            });

            MessageBox.Show($"Hard Drive added successfully", "Hard Drive", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
        private void RefreshManufacturers(List<Manufacturer> manufacturers)
        {
            // Ideally we'd pull these at run time and not just pass them through from another form
            // but EF Core change tracking goes well over my head apparently
            cmbManufacturers.DataSource = manufacturers;
            cmbManufacturers.DisplayMember = "Name";
            cmbManufacturers.ValueMember = "ManufacturerId";
        }
    
    }
}

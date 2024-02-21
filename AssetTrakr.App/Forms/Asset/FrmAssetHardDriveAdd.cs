using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Database;
using AssetTrakr.Models.Assets;
using AssetTrakr.Models.Extensions;
using System.ComponentModel;
using System.Configuration;
using System.Data;

namespace AssetTrakr.App.Forms.Asset
{
    public partial class FrmAssetHardDriveAdd : Form
    {
        private readonly DatabaseContext _dbContext;
        public BindingList<AssetHardDrive> HardDrives = [];

        public FrmAssetHardDriveAdd(BindingList<AssetHardDrive> Drives)
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();

            HardDrives ??= [];

            // To account for previously added and prevent data loss on user end
            if (Drives != null)
            {
                HardDrives = Drives;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cmbManufacturers.DataSource = _dbContext.Manufacturers.Select(m => m.Name).ToComboList();
        }

        private void lnkAddManufacturer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmManufacturerManager frmManufacturerManager = new();
            frmManufacturerManager.ShowDialog();

            cmbManufacturers.DataSource = _dbContext.Manufacturers.Select(m => m.Name).ToComboList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var selectedManufacturer = _dbContext.Manufacturers.SingleOrDefault(x => x.Name == cmbManufacturers.Text);

            if(selectedManufacturer == null)
            {
                MessageBox.Show($"Manufacturer is required.", "Manufacturer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HardDrives.Add(new AssetHardDrive
            {
                ManufacturerId = selectedManufacturer.ManufacturerId,
                Manufacturer = selectedManufacturer,
                Name = txtName.Text,
                SizeInGB = Convert.ToInt32(numSizeBytes.Value)
            });

            MessageBox.Show($"Hard Drive added successfully", "Hard Drive", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

using AssetTrakr.Database;
using AssetTrakr.Models;
using AssetTrakr.Models.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AssetTrakr.App.Forms.Shared
{
    public partial class FrmPlatformManager : Form
    {
        private readonly DatabaseContext _dbContext;
        private List<Platform> _platformList;
        private int _selectedPlatformId;

        public FrmPlatformManager()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();

            RefreshPlatformList();
        }

        /// <summary>
        /// Refresh the PlatformList with data from the SQLite database
        /// </summary>
        private void RefreshPlatformList()
        {
            if(_platformList != null)
            {
                if (_platformList.Count > 0)
                {
                    _platformList.Clear();
                }
            }

            _platformList = [.. _dbContext.Platforms];

            // populate the user visible listbox
            lbPlatforms.DataSource = _platformList;
            lbPlatforms.DisplayMember = "Name";
            lbPlatforms.ValueMember = "PlatformId";
        }

        protected override void OnLoad(EventArgs e)
        {
            _dbContext.Platforms.Load();

            RefreshPlatformList();

            cmbManufacturers.DataSource = _dbContext.Manufacturers.ToList();
            cmbManufacturers.DisplayMember = "Name";
            cmbManufacturers.ValueMember = "ManufacturerId";
        }

        private void lbPlatforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPlatforms.SelectedIndex < 0)
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnAdd.Enabled = true;
                return;
            }

            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;

            var platform = lbPlatforms.SelectedItem as Platform;

            _selectedPlatformId = platform.PlatformId;
            txtName.Text = platform.Name;
            cmbManufacturers.SelectedIndex = cmbManufacturers.FindStringExact(_dbContext.Manufacturers.SingleOrDefault(x => x.ManufacturerId == platform.ManufacturerId).Name);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var platform = lbPlatforms.SelectedItem as Platform;

            if (platform == null)
            {
                return;
            }

            if (txtName.Text.Length < 1)
            {
                MessageBox.Show("Name is a required field", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO: There has to be a better way of doing this since we already populate the combobox
            var selectedManufacturer = cmbManufacturers.SelectedItem as Manufacturer;

            if (selectedManufacturer == null)
            {
                MessageBox.Show($"Platform has not been updated as 'selectedManufacturer' is null", "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            platform.Name = txtName.Text;
            platform.Manufacturer = selectedManufacturer;

            if (_dbContext.SaveChanges() > 0)
            {
                MessageBox.Show("Platform updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshPlatformList();
                return;
            }
        }

        private void deselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // deselects the listbox, lets users add items
            lbPlatforms.SelectedIndex = -1;

            txtName.Text = string.Empty;
            cmbManufacturers.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtName.Text.Length < 1)
            {
                MessageBox.Show("Name is a required field", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_platformList.SingleOrDefault(x => x.Name == txtName.Text) != null)
            {
                MessageBox.Show($"Platform with the name {txtName.Text} already exists.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO: There has to be a better way of doing this since we already populate the combobox
            var selectedManufacturer = cmbManufacturers.SelectedItem as Manufacturer;

            if (selectedManufacturer == null)
            {
                MessageBox.Show($"Platform has not been added as Manufacturer is null", "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dbContext.Platforms.Add(new Platform
            {
                Name = txtName.Text,
                Manufacturer = selectedManufacturer,
            });

            if (_dbContext.SaveChanges() > 0)
            {
                MessageBox.Show($"{txtName.Text} added successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshPlatformList();
                return;
            };
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbPlatforms.SelectedIndex < 0)
            {
                return;
            }

            var platform = _platformList[lbPlatforms.SelectedIndex];

            if (platform == null)
            {
                return;
            }

            // TODO: Add 'Asset' ghost check later
            int licenseGhostCheck = _dbContext.Licenses.Where(x => x.PlatformId == platform.PlatformId).Count();
            //int contractGhostCheck = _dbContext.Contracts.Select(x => x.PlatformId == platform.Id).Count();

            if (licenseGhostCheck != 0)
            {
                MessageBox.Show(
                    $"Cannot delete {platform.Name} as it has {licenseGhostCheck} entities registered against it",
                    "Delete Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand
                );

                return;
            }

            DialogResult dr = MessageBox.Show($"Do you want to delete {platform.Name}?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                _dbContext.Platforms.Remove(platform);

                if (_dbContext.SaveChanges() > 0)
                {
                    MessageBox.Show($"{platform.Name} was deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshPlatformList();
                    return;
                }
            }
        }
    }
}

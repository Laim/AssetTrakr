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

        public FrmPlatformManager(DatabaseContext DbContext)
        {
            InitializeComponent();

            _dbContext ??= DbContext;

            // We load in all platforms here to prevent having to do multiple database calls
            // every time we want to pull the property data for each platform.
            // We can also refresh this each time something is added, deleted or edited w/ less.
            // load on the db, hopefully.
            // TODO:  This might need optimized later on. [See RefreshPlatformList also during review]
            _platformList ??= _dbContext.Platforms.ToList();
        }

        /// <summary>
        /// Refresh the PlatformList with data from the SQLite database
        /// </summary>
        private void RefreshPlatformList()
        {

            if (_platformList.Count > 0)
            {
                _platformList.Clear();
                lbPlatforms.Items.Clear();
            }

            _platformList = [.. _dbContext.Platforms];

            // populate the user visible listbox
            foreach (var platform in _platformList)
            {
                lbPlatforms.Items.Add(platform.Name);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            _dbContext.Platforms.Load();

            RefreshPlatformList();

            cmbManufacturersList.DataSource = _dbContext.Manufacturers.Select(m => m.Name).ToComboList();
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

            var platform = _platformList[lbPlatforms.SelectedIndex];

            _selectedPlatformId = platform.PlatformId;
            txtName.Text = platform.Name;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var platform = _dbContext.Platforms.SingleOrDefault(x => x.PlatformId == _selectedPlatformId);

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
            var selectedManufacturer = _dbContext.Manufacturers.SingleOrDefault(x => x.Name == cmbManufacturersList.Text);

            if(selectedManufacturer == null)
            {
                MessageBox.Show($"Platform has not been updated as 'selectedManufacturer' is null", "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            platform.Name = txtName.Text;
            platform.ManufacturerId = selectedManufacturer.ManufacturerId;

            if (_dbContext.SaveChanges() > 0)
            {
                MessageBox.Show("Manufacturer updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshPlatformList();
                return;
            }
        }

        private void deselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // deselects the listbox, lets users add items
            lbPlatforms.SelectedIndex = -1;

            txtName.Text = string.Empty;
            cmbManufacturersList.SelectedIndex = 0;
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
            var selectedManufacturer = _dbContext.Manufacturers.SingleOrDefault(x => x.Name == cmbManufacturersList.Text);
            if (selectedManufacturer == null)
            {
                MessageBox.Show($"Platform has not been added as Manufacturer is null", "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dbContext.Platforms.Add(new Platform
            {
                Name = txtName.Text,
                ManufacturerId = selectedManufacturer.ManufacturerId
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

using AssetTrakr.Database;
using AssetTrakr.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetTrakr.App.Forms.Shared
{
    public partial class FrmManufacturerManager : Form
    {
        private readonly DatabaseContext _dbContext;
        private List<Manufacturer> _manufacturerList;
        private int _selectedManufacturerId;

        public FrmManufacturerManager(DatabaseContext DbContext)
        {
            InitializeComponent();

            _dbContext ??= DbContext;

            // We load in all manufacturers here to prevent having to do multiple database calls
            // every time we want to pull the property data for each manufacturer.
            // We can also refresh this each time something is added, deleted or edited w/ less.
            // load on the db, hopefully.
            // TODO:  This might need optimized later on. [See RefreshManufacturerList also during review]
            _manufacturerList ??= _dbContext.Manufacturers.ToList();
        }

        /// <summary>
        /// Refresh the ManufacturerList with data from the SQLite database
        /// </summary>
        private void RefreshManufacturerList()
        {

            if (_manufacturerList.Count > 0)
            {
                _manufacturerList.Clear();
                lbManufacturers.Items.Clear();
            }

            _manufacturerList = [.. _dbContext.Manufacturers];

            // populate the user visible listbox
            foreach (var manufacturer in _manufacturerList)
            {
                lbManufacturers.Items.Add(manufacturer.Name);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            _dbContext.Manufacturers.Load();

            RefreshManufacturerList();
        }

        private void lbManufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbManufacturers.SelectedIndex < 0)
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnAdd.Enabled = true;
                return;
            }

            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;

            var manufacturer = _manufacturerList[lbManufacturers.SelectedIndex];

            _selectedManufacturerId = manufacturer.ManufacturerId;
            txtName.Text = manufacturer.Name;
            txtUrl.Text = manufacturer.Url;
            txtSupportUrl.Text = manufacturer.SupportUrl;
            txtSupportEmail.Text = manufacturer.SupportEmail;
            txtSupportPhone.Text = manufacturer.SupportPhone;
            txtNotes.Text = manufacturer.Notes;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var manufacturer = _dbContext.Manufacturers.SingleOrDefault(x => x.ManufacturerId == _selectedManufacturerId);

            if (manufacturer == null)
            {
                return;
            }

            if (txtName.Text.Length < 1)
            {
                MessageBox.Show("Name is a required field", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtUrl.Text.Length < 1)
            {
                MessageBox.Show("URL is a required field", "URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            manufacturer.Name = txtName.Text;
            manufacturer.Url = txtUrl.Text;
            manufacturer.SupportUrl = txtSupportUrl.Text;
            manufacturer.SupportPhone = txtSupportPhone.Text;
            manufacturer.SupportEmail = txtSupportEmail.Text;
            manufacturer.Notes = txtNotes.Text;

            if (_dbContext.SaveChanges() > 0)
            {
                MessageBox.Show("Manufacturer updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshManufacturerList();
                return;
            }
        }

        private void deselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // deselects the listbox, lets users add items
            lbManufacturers.SelectedIndex = -1;

            txtName.Text = string.Empty;
            txtUrl.Text = string.Empty;
            txtSupportEmail.Text = string.Empty;
            txtSupportPhone.Text = string.Empty;
            txtSupportUrl.Text = string.Empty;
            txtNotes.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtName.Text.Length < 1)
            {
                MessageBox.Show("Name is a required field", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtUrl.Text.Length < 1)
            {
                MessageBox.Show("URL is a required field", "URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_manufacturerList.SingleOrDefault(x => x.Name == txtName.Text) != null)
            {
                MessageBox.Show($"Manufacturer with the name {txtName.Text} already exists.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dbContext.Manufacturers.Add(new Manufacturer
            {
                Name = txtName.Text,
                Url = txtUrl.Text,
                SupportEmail = txtSupportEmail.Text,
                SupportPhone = txtSupportPhone.Text,
                SupportUrl = txtSupportUrl.Text,
                Notes = txtNotes.Text
            });

            if (_dbContext.SaveChanges() > 0)
            {
                MessageBox.Show($"{txtName.Text} added successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshManufacturerList();
                return;
            };
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbManufacturers.SelectedIndex < 0)
            {
                return;
            }

            var manufacturer = _manufacturerList[lbManufacturers.SelectedIndex];

            if (manufacturer == null)
            {
                return;
            }

            // TODO: Add 'Asset' ghost check later
            int licenseGhostCheck = _dbContext.Licenses.Where(x => x.ManufacturerId == manufacturer.ManufacturerId).Count();
            int platformGhostCheck = _dbContext.Platforms.Where(x => x.ManufacturerId == manufacturer.ManufacturerId).Count();

            if (licenseGhostCheck != 0)
            {
                MessageBox.Show(
                    $"Cannot delete {manufacturer.Name} as it has {licenseGhostCheck + platformGhostCheck} entities registered against it",
                    "Delete Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand
                );

                return;
            }

            DialogResult dr = MessageBox.Show($"Do you want to delete {manufacturer.Name}?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dr == DialogResult.Yes)
            {
                _dbContext.Manufacturers.Remove(manufacturer);

                if (_dbContext.SaveChanges() > 0)
                {
                    MessageBox.Show($"{manufacturer.Name} was deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshManufacturerList();
                    return;
                }
            }
        }
    }
}

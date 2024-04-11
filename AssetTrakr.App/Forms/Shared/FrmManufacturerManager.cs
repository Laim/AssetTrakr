using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Logging;
using AssetTrakr.Models;

namespace AssetTrakr.App.Forms.Shared
{
    public partial class FrmManufacturerManager : Form
    {
        private readonly DatabaseContext _dbContext;

        public FrmManufacturerManager()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();
        }

        /// <summary>
        /// Refresh the ManufacturerList with data from the SQLite database
        /// </summary>
        private void RefreshManufacturerList()
        {
            lbManufacturers.DataSource = _dbContext.Manufacturers.ToList();
            lbManufacturers.DisplayMember = "Name";
            lbManufacturers.ValueMember = "ManufacturerId";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshManufacturerList();
        }

        private void lbManufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = lbManufacturers.SelectedIndex < 0;
            btnDelete.Enabled = btnUpdate.Enabled = !btnAdd.Enabled;

            if(lbManufacturers.SelectedIndex < 0) { return; }

            if (lbManufacturers.SelectedItem is not Manufacturer manufacturer)
            {
                MessageBox.Show("Selected Item is not a manufacturer, this should never happen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtName.Text = manufacturer.Name;
            txtUrl.Text = manufacturer.Url;
            txtSupportUrl.Text = manufacturer.SupportUrl;
            txtSupportEmail.Text = manufacturer.SupportEmail;
            txtSupportPhone.Text = manufacturer.SupportPhone;
            txtNotes.Text = manufacturer.Notes;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lbManufacturers.SelectedItem is not Manufacturer manufacturer)
            {
                return;
            }

            if(txtName.IsEmpty("Name"))
            {
                return;
            }

            manufacturer.Name = txtName.Text;
            manufacturer.Url = txtUrl.Text;
            manufacturer.SupportUrl = txtSupportUrl.Text;
            manufacturer.SupportPhone = txtSupportPhone.Text;
            manufacturer.SupportEmail = txtSupportEmail.Text;
            manufacturer.Notes = txtNotes.Text;

            try
            {
                if (_dbContext.SaveChanges() > 0)
                {
                    MessageBox.Show("Manufacturer updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshManufacturerList();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmManufacturerManager>($"{ex}");
            }
        }

        private void deselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // deselects the listbox, lets users add items
            lbManufacturers.SelectedIndex = -1;

            foreach(Control control in this.Controls)
            {
                if(control is TextBox)
                {
                    control.Text = string.Empty;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtName.IsEmpty("Name"))
            {
                return;
            }

            if (lbManufacturers.Items.Cast<Manufacturer>().Any(m => m.Name == txtName.Text))
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

            try
            {

                if (_dbContext.SaveChanges() > 0)
                {
                    MessageBox.Show($"{txtName.Text} added successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshManufacturerList();
                    return;
                };
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmManufacturerManager>($"{ex}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbManufacturers.SelectedIndex < 0)
            {
                return;
            }

            if (lbManufacturers.SelectedItem is not Manufacturer manufacturer)
            {
                return;
            }

            // TODO: Remember to add a ghost check here if it relies on Manufacturer values
            List<Func<int>> ghostChecks =
            [
                () => _dbContext.Licenses.Count(l => l.Manufacturer == manufacturer),
                () => _dbContext.Platforms.Count(p => p.Manufacturer == manufacturer),
                () => _dbContext.Assets.Count(a => a.Manufacturer == manufacturer),
                () => _dbContext.AssetHardDrives.Count(ahd => ahd.Manufacturer == manufacturer),
                () => _dbContext.AssetOperatingSystems.Count(aos => aos.Manufacturer == manufacturer)
            ];

            int totalRecords = ghostChecks.Sum(check => check());

            if (totalRecords != 0)
            {
                string entityValue = (totalRecords < 2) ? "entity" : "entities";

                MessageBox.Show($"Cannot delete {manufacturer.Name} as it has {totalRecords} {entityValue} registered against it", "Dependency Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                return;
            }

            DialogResult dr = MessageBox.Show($"Do you want to delete {manufacturer.Name}?", "Confirmation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dr == DialogResult.Yes)
            {
                try
                {
                    _dbContext.Manufacturers.Remove(manufacturer);

                    if (_dbContext.SaveChanges() > 0)
                    {
                        MessageBox.Show($"{manufacturer.Name} was deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshManufacturerList();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.Error<FrmManufacturerManager>($"{ex}");
                }
            }
        }
    }
}

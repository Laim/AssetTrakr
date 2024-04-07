using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Logging;
using AssetTrakr.Models;

namespace AssetTrakr.App.Forms.Shared
{
    public partial class FrmPlatformManager : Form
    {
        private readonly DatabaseContext _dbContext;

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
            // populate the user visible listbox
            lbPlatforms.DataSource = _dbContext.Platforms.ToList();
            lbPlatforms.DisplayMember = "Name";
            lbPlatforms.ValueMember = "PlatformId";

            // Populate manufacturers too, we need those
            cmbManufacturers.DataSource = _dbContext.Manufacturers.ToList();
            cmbManufacturers.DisplayMember = "Name";
            cmbManufacturers.ValueMember = "ManufacturerId";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshPlatformList();
        }

        private void lbPlatforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = lbPlatforms.SelectedIndex < 0;
            btnDelete.Enabled = btnUpdate.Enabled = !btnAdd.Enabled;

            if (lbPlatforms.SelectedIndex < 0) { return; }

            if (lbPlatforms.SelectedItem is not Platform platform)
            {
                MessageBox.Show("Selected Item is not a platform, this should never happen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtName.Text = platform.Name;
            cmbManufacturers.SelectedIndex = cmbManufacturers.FindStringExact(platform.Manufacturer?.Name);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lbPlatforms.SelectedItem is not Platform platform)
            {
                return;
            }

            if (txtName.IsEmpty("Name"))
            {
                return;
            }

            if (cmbManufacturers.SelectedItem is not Manufacturer selectedManufacturer)
            {
                MessageBox.Show($"Platform has not been updated as Manufacturer is null", "Manufacturer Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            platform.Name = txtName.Text;
            platform.Manufacturer = selectedManufacturer;
            platform.Notes = txtNotes.Text;

            try
            {
                if (_dbContext.SaveChanges() > 0)
                {
                    MessageBox.Show("Platform updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshPlatformList();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmPlatformManager>($"{ex}");
            }
        }

        private void deselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // deselects the listbox, lets users add items
            lbPlatforms.SelectedIndex = -1;

            txtName.Text = string.Empty;
            cmbManufacturers.SelectedIndex = 0;
            txtNotes.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.IsEmpty("Name"))
            {
                return;
            }

            if (lbPlatforms.Items.Cast<Platform>().Any(m => m.Name == txtName.Text))
            {
                MessageBox.Show($"Platform with the name {txtName.Text} already exists.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO: There has to be a better way of doing this since we already populate the combobox

            if (cmbManufacturers.SelectedItem is not Manufacturer selectedManufacturer)
            {
                MessageBox.Show($"Platform has not been added as Manufacturer is null", "Manufacturer Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dbContext.Platforms.Add(new Platform
            {
                Name = txtName.Text,
                Manufacturer = selectedManufacturer,
                Notes = txtNotes.Text,
            });

            try
            {
                if (_dbContext.SaveChanges() > 0)
                {
                    MessageBox.Show($"{txtName.Text} added successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshPlatformList();
                    return;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmPlatformManager>($"{ex}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbPlatforms.SelectedIndex < 0)
            {
                return;
            }

            if (lbPlatforms.SelectedItem is not Platform platform)
            {
                return;
            }

            // TODO: Remember to add a ghost check here if it relies on any Entity values
            List<Func<int>> ghostChecks =
            [
                () => _dbContext.Assets.Count(a => a.Platform == platform),
                () => _dbContext.Licenses.Count(l => l.Platform == platform)
            ];

            int totalRecords = ghostChecks.Sum(check => check());

            if (totalRecords != 0)
            {
                string entityValue = (totalRecords < 2) ? "entity" : "entities";

                MessageBox.Show($"Cannot delete {platform.Name} as it has {totalRecords} {entityValue} registered against it", "Dependency Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                return;
            }

            DialogResult dr = MessageBox.Show($"Do you want to delete {platform.Name}?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    _dbContext.Platforms.Remove(platform);

                    if (_dbContext.SaveChanges() > 0)
                    {
                        MessageBox.Show($"{platform.Name} was deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshPlatformList();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.Error<FrmPlatformManager>($"{ex}");
                }
            } 
            else
            {
                MessageBox.Show("Deletion Cancelled by User", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

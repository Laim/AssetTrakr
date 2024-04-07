using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Logging;
using AssetTrakr.Models;
using AssetTrakr.Models.Assets;

namespace AssetTrakr.App.Forms.Shared
{
    public partial class FrmOperatingSystemManager : Form
    {

        private readonly DatabaseContext _dbContext;

        public FrmOperatingSystemManager()
        {
            InitializeComponent();

            _dbContext ??= new();

            RefreshOperatingSystems();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshOperatingSystems();
        }

        /// <summary>
        /// Refresh the Operating Systems Listbox with data from SQLite DB
        /// </summary>
        private void RefreshOperatingSystems()
        {
            lbOperatingSystems.DataSource = _dbContext.AssetOperatingSystems.ToList();
            lbOperatingSystems.DisplayMember = "Name";
            lbOperatingSystems.ValueMember = "OperatingSystemId";

            cmbManufacturers.DataSource = _dbContext.Manufacturers.ToList();
            cmbManufacturers.DisplayMember = "Name";
            cmbManufacturers.ValueMember = "ManufacturerId";
        }

        private void lbOperatingSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = lbOperatingSystems.SelectedIndex < 0;
            btnDelete.Enabled = btnUpdate.Enabled = !btnAdd.Enabled;

            if (lbOperatingSystems.SelectedIndex < 0) { return; }

            if (lbOperatingSystems.SelectedItem is not AssetOperatingSystem operatingSystem)
            {
                MessageBox.Show("Selected Item is not an Operating System, this should never happen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtName.Text = operatingSystem.Name;
            txtNotes.Text = operatingSystem.Notes;
            cmbManufacturers.SelectedIndex = cmbManufacturers.FindStringExact(operatingSystem.Manufacturer?.Name);
        }

        private void deselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // deselects the listbox, lets users add items
            lbOperatingSystems.SelectedIndex = -1;

            txtName.Text = string.Empty;
            cmbManufacturers.SelectedIndex = 0;
            txtNotes.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lbOperatingSystems.SelectedItem is not AssetOperatingSystem operatingSystem)
            {
                return;
            }

            if (txtName.IsEmpty("Name"))
            {
                return;
            }

            if (cmbManufacturers.SelectedItem is not Manufacturer selectedManufacturer)
            {
                MessageBox.Show($"Operating System has not been updated as Manufacturer is null", "Manufacturer Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            operatingSystem.Name = txtName.Text;
            operatingSystem.Manufacturer = selectedManufacturer;
            operatingSystem.Notes = txtNotes.Text;

            try
            {

                if (_dbContext.SaveChanges() > 0)
                {
                    MessageBox.Show("Operating System updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshOperatingSystems();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmOperatingSystemManager>($"{ex}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.IsEmpty("Name"))
            {
                return;
            }

            if (lbOperatingSystems.Items.Cast<AssetOperatingSystem>().Any(os => os.Name == txtName.Text))
            {
                MessageBox.Show($"Operating System with the name {txtName.Text} already exists.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbManufacturers.SelectedItem is not Manufacturer selectedManufacturer)
            {
                MessageBox.Show($"Operating System has not been added as Manufacturer is null", "Manufacturer Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dbContext.AssetOperatingSystems.Add(new AssetOperatingSystem
            {
                Name = txtName.Text,
                Manufacturer = selectedManufacturer,
                Notes = txtNotes.Text
            });

            try
            {
                if (_dbContext.SaveChanges() > 0)
                {
                    MessageBox.Show($"{txtName.Text} added successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshOperatingSystems();
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
            
            if(lbOperatingSystems.SelectedIndex < 0)
            {
                return;
            }

            if(lbOperatingSystems.SelectedItem is not AssetOperatingSystem operatingSystem)
            {
                return;
            }

            // Add any entities that depend on OS here
            List<Func<int>> ghostChecks =
            [
                () => _dbContext.Assets.Count(a => a.OperatingSystem == operatingSystem)
            ];

            int totalRecords = ghostChecks.Sum(check => check());

            if(totalRecords != 0)
            {
                string entityValue = (totalRecords < 2) ? "entity" : "entities";

                MessageBox.Show($"Cannot delete {operatingSystem.Name} as it has {totalRecords} {entityValue} registered against it", "Dependency Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                return;
            }

            DialogResult dr = MessageBox.Show($"Do you want to delete {operatingSystem.Name}?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dr == DialogResult.Yes)
            {
                try
                {

                    _dbContext.AssetOperatingSystems.Remove(operatingSystem);

                    if(_dbContext.SaveChanges() > 0)
                    {
                        MessageBox.Show($"{operatingSystem.Name} was deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshOperatingSystems();
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.Error<FrmOperatingSystemManager>($"{ex}");
                }
            } 
            else
            {
                MessageBox.Show("Deletion Cancelled by User", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}

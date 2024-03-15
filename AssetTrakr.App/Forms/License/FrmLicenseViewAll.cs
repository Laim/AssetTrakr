using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Database;
using AssetTrakr.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AssetTrakr.App.Forms.License
{
    public partial class FrmLicenseViewAll : Form
    {
        private readonly DatabaseContext _dbContext;

        public FrmLicenseViewAll()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadData();
        }

        /// <summary>
        /// Loads all of the license data into the datagridview
        /// </summary>
        /// <param name="needReload">
        /// True or false, true resets the datasource to NULL before loading data
        /// </param>
        private void LoadData(bool needReload = false)
        {
            if (needReload)
            {
                dgvViewAll.DataSource = null;
            }

            var licenses = _dbContext.Licenses
                .Include(l => l.Manufacturer)
                .Include(l => l.Contract)
                .Include(l => l.Platform)
                .Select(l => new
                {
                    l.Id,
                    l.Name,
                    l.Count,
                    l.PurchaseDate, // Purchase Date
                    l.IsSubscription, // Subscription
                    l.IsSubscriptionContract, // Subscription via Contract
                    Manufacturer = l.Manufacturer.Name ?? "",
                    Platform = l.Platform.Name ?? "",
                    Contract = l.Contract.Name ?? "",
                    l.Price,
                    l.Description,
                    l.Version,
                    l.LicenseKey,
                    l.OrderReference,
                    l.RegisteredUser,
                    l.RegisteredEmail,
                    l.CreatedBy,
                    l.CreatedDate,
                    l.UpdatedBy,
                    l.UpdatedDate
                })
                .ToList();

            dgvViewAll.DataSource = licenses;

            // Rename columns since it's an anonymous type and ignores [DisplayName] attribute in the License model
            dgvViewAll.Columns["PurchaseDate"].HeaderText = "Purchase Date";
            dgvViewAll.Columns["IsSubscription"].HeaderText = "Subscription";
            dgvViewAll.Columns["IsSubscriptionContract"].HeaderText = "Subscription via Contract";
            dgvViewAll.Columns["LicenseKey"].HeaderText = "License Key";
            dgvViewAll.Columns["OrderReference"].HeaderText = "Order Reference";
            dgvViewAll.Columns["RegisteredUser"].HeaderText = "User";
            dgvViewAll.Columns["RegisteredEmail"].HeaderText = "User Email";

            // hide columns
            dgvViewAll.Columns["Id"].Visible = false;
            dgvViewAll.Columns["Description"].Visible = false;
            dgvViewAll.Columns["Version"].Visible = false;
            dgvViewAll.Columns["LicenseKey"].Visible = false;
            dgvViewAll.Columns["IsSubscriptionContract"].Visible = false;
            dgvViewAll.Columns["OrderReference"].Visible = false;
            dgvViewAll.Columns["RegisteredUser"].Visible = false;
            dgvViewAll.Columns["RegisteredEmail"].Visible = false;
            dgvViewAll.Columns["CreatedDate"].Visible = false;
            dgvViewAll.Columns["UpdatedDate"].Visible = false;
            dgvViewAll.Columns["UpdatedBy"].Visible = false;
            dgvViewAll.Columns["CreatedBy"].Visible = false;
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
            if (cmsDgvRightClick.SourceControl is DataGridView dgv)
            {
                FrmLicenseModify frmLicenseModify = new((int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value, true);
                frmLicenseModify.ShowDialog();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is DataGridView dgv)
            {
                FrmLicenseModify frmLicenseModify = new((int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
                frmLicenseModify.ShowDialog();
                LoadData(true);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvViewAll.Export();
        }
    }
}

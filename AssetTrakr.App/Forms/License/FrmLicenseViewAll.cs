using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Database;
using Microsoft.EntityFrameworkCore;

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

            var licenses = _dbContext.Licenses
                .Include(l => l.Manufacturer)
                .Include(l => l.Contract)
                .Include(l => l.Platform)
                .Select(
                    l => new
                    {
                        l.Id,
                        l.Name,
                        l.Description,
                        l.Count,
                        Purchase_Date = l.PurchaseDate,
                        Subscription = l.IsSubscription,
                        Contract = l.Contract.Name ?? "",
                        Manufacturer = l.Manufacturer.Name ?? "",
                        l.Price,
                        Order_Ref = l.OrderReference,
                        l.Version,
                        Platform = l.Platform.Name ?? "",
                        Registered_User = l.RegisteredUser,
                        Registered_Email = l.RegisteredEmail,
                        License_Key = l.LicenseKey,
                        Created_Date = l.CreatedDate,
                        Created_By = l.CreatedBy,
                        Updated_By = l.UpdatedBy,
                        Updated_Date = l.UpdatedDate   
                    })
                .ToList();

            dgvViewAll.DataSource = licenses;

            foreach(DataGridViewColumn column in dgvViewAll.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("_", " ");
            }

            // hide columns
            dgvViewAll.Columns["Id"].Visible = false;
            dgvViewAll.Columns["Description"].Visible = false;
            dgvViewAll.Columns["Version"].Visible = false;
            dgvViewAll.Columns["License_Key"].Visible = false;
            dgvViewAll.Columns["Order_Ref"].Visible = false;
            dgvViewAll.Columns["Registered_User"].Visible = false;
            dgvViewAll.Columns["Registered_Email"].Visible = false;
            dgvViewAll.Columns["Created_Date"].Visible = false;
            dgvViewAll.Columns["Updated_Date"].Visible = false;
            dgvViewAll.Columns["Updated_By"].Visible = false;
            dgvViewAll.Columns["Created_By"].Visible = false;
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
    }
}

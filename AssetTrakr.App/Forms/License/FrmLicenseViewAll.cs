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
                .ToList();

            dgvViewAll.DataSource = licenses;

            // hide columns
            dgvViewAll.Columns["Id"].Visible = false;
            dgvViewAll.Columns["Description"].Visible = false;
            dgvViewAll.Columns["Version"].Visible = false;
            dgvViewAll.Columns["LicenseKey"].Visible = false;
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
    }
}

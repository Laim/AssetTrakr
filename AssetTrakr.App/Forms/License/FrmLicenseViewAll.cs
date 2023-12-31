using AssetTrakr.Database;

namespace AssetTrakr.App.Forms.License
{
    public partial class FrmLicenseViewAll : Form
    {
        private readonly DatabaseContext _dbContext;

        public FrmLicenseViewAll(DatabaseContext DbContext)
        {
            InitializeComponent();

            _dbContext ??= DbContext;
        }

        protected override void OnLoad(EventArgs e)
        {

            dataGridView1.DataSource = _dbContext.Licenses.ToList();

            base.OnLoad(e);
        }
    }
}

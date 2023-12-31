using AssetTrakr.App.Forms.License;
using AssetTrakr.Database;
using System.ComponentModel;

namespace AssetTrakr.App.Forms
{
    public partial class FrmMain : Form
    {

        private DatabaseContext dbContext;

        public FrmMain()
        {
            InitializeComponent();

            dbContext ??= new DatabaseContext();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Uncomment the line below to start fresh with a new database.
            // this.dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            //this.dbContext.Categories.Load();

            //dataGridViewCategories.DataSource = dbContext.Categories.ToList();
            //dataGridViewProducts.DataSource = dbContext.Products.ToList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            dbContext?.Dispose();
            dbContext = null;
        }

        private void addLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenseModify frmLicenseModify = new(dbContext);
            frmLicenseModify.ShowDialog();
        }

        private void viewLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenseViewAll frmLicenseViewAll = new(dbContext);
            frmLicenseViewAll.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLicenseModify frmLicenseModify = new(dbContext, Convert.ToInt32(textBox1.Text));
            frmLicenseModify.ShowDialog();
        }
    }
}

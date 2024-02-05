using AssetTrakr.App.Forms.Asset;
using AssetTrakr.App.Forms.License;
using AssetTrakr.Database;
using System.ComponentModel;

namespace AssetTrakr.App.Forms
{
    public partial class FrmMain : Form
    {

        private DatabaseContext _dbContext;

        public FrmMain()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                _dbContext.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Boot Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            _dbContext?.Dispose();
        }

        private void addLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenseModify frmLicenseModify = new();
            frmLicenseModify.ShowDialog();
        }

        private void viewLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenseViewAll frmLicenseViewAll = new();
            frmLicenseViewAll.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLicenseModify frmLicenseModify = new(Convert.ToInt32(textBox1.Text));
            FrmAssetModify FrmAssetModify = new(Convert.ToInt32(textBox1.Text));

            FrmAssetModify.ShowDialog();
        }

        private void addAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAssetModify frmAssetModify = new();
            frmAssetModify.ShowDialog();
        }
    }
}

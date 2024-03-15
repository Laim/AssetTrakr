using AssetTrakr.App.Helpers;
using AssetTrakr.Database;
using AssetTrakr.Utils.Enums;
using System.Reflection;

namespace AssetTrakr.App.Forms.Miscellaneous
{
    public partial class FrmSystemRegistration : Form
    {
        private DatabaseContext _dbContext;
        bool _isRegistered = false;

        public FrmSystemRegistration()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();

            txtDatabaseCreationDate.Text = DateTime.Now.ToString();
            txtProductVersion.Text = Application.ProductVersion;
            txtRunDirectory.Text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (!_isRegistered)
            {
                MessageBox.Show("Application can not be run without registration, application exiting...", "Product Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            _dbContext.SystemInfo.Add(
                    new Models.SystemInfo
                    {
                        FullName = txtFullName.Text ?? "",
                        ProductVersion = txtProductVersion.Text ?? Application.ProductVersion,
                        DatabaseCreationDate = Convert.ToDateTime(txtDatabaseCreationDate.Text),
                        RunDirectory = txtRunDirectory.Text
                    }
                );

            try
            {

                ActionLogMethods.Added(_dbContext, ActionAlertCategory.System, "Product Registration");

                _dbContext.SaveChanges();

                _isRegistered = true;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

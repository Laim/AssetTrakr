using AssetTrakr.Database;
using AssetTrakr.Utils.Enums;
using System.Reflection;
using AssetTrakr.WinForms.ActionLog;
using AssetTrakr.Logging;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AssetTrakr.App.Forms.Miscellaneous
{
    public partial class FrmSystemRegistration : Form
    {
        private DatabaseContext _dbContext;

        public FrmSystemRegistration()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();

            txtDatabaseCreationDate.Text = DateTime.Now.ToString();

#if DEBUG
            txtProductVersion.Text = FileVersionInfo.GetVersionInfo(@"C:\Development\Source Code\AssetTrakr\AssetTrakr\AssetTrakr.App\bin\Debug\net8.0-windows\win-x64\AssetTrakr.App.exe").ProductVersion;
#else
            txtProductVersion.Text = FileVersionInfo.GetVersionInfo(@"AssetTrakr.App.exe").ProductVersion;
#endif

            txtRunDirectory.Text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            _dbContext.Database.Migrate();

            var registrationInfo = new Models.System.SystemInfo
            {
                FullName = txtFullName.Text ?? "",
                ProductVersion = txtProductVersion.Text,
                DatabaseCreationDate = Convert.ToDateTime(txtDatabaseCreationDate.Text),
                RunDirectory = txtRunDirectory.Text
            };

            _dbContext.SystemInfo.Add(registrationInfo);

            try
            {

                ActionLogMethods.Added(_dbContext, ActionAlertCategory.System, "Product Registration");

                _dbContext.SaveChanges();

                LogManager.Information<FrmSystemRegistration>("Application registered");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\n See log for more details.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Fatal<FrmSystemRegistration>($"{ex}");
            }

        }
    }
}

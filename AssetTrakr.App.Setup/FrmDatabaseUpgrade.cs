using AssetTrakr.App.Forms.Miscellaneous;
using AssetTrakr.App.Helpers;
using AssetTrakr.Database;
using AssetTrakr.Logging;
using AssetTrakr.Utils.Enums;
using AssetTrakr.WinForms.ActionLog;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AssetTrakr.App.Setup
{
    public partial class FrmDatabaseUpgrade : Form
    {

        private DatabaseContext _dbContext;

        public FrmDatabaseUpgrade()
        {
            InitializeComponent();
            _dbContext ??= new();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // check if the db exists, if it does, skip registration
            if (!_dbContext.Database.CanConnect())
            {
                LogManager.Information<FrmDatabaseUpgrade>("Cannot connect to database, attempting registration.");
                this.Hide();
                FrmSystemRegistration FrmSystemRegistration = new();
                FrmSystemRegistration.ShowDialog();
                Application.Restart();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_dbContext.Database.GetPendingMigrations().Any())
            {
                lblNotice.Text = "Migrations are required.  Migrations must be run before running AssetTrakr to ensure that all features within" +
                    " the application work as expected.\r\n\r\n" +
                    "Ensure you take a database backup before proceeding, manually or with this tool.\r\n\r\n" +
                    "Once migrationed, the database cannot be reverted without a backup.";
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            Process.Start(
                new ProcessStartInfo($"{DatabaseSettings.directoryPath}")
                {
                    UseShellExecute = true
                }
            );
        }

        private void btnBackupDatabase_Click(object sender, EventArgs e)
        {
            BackupManager backupManager = new(0);
            string result = backupManager.MigrationBackup();

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Something has gone seriously wrong somewhere", "????", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result, "Backup Result", MessageBoxButtons.OK);
            LogManager.Information<FrmDatabaseUpgrade>($"Database Backup Result: {result}");
        }

        private void btnMigrate_Click(object sender, EventArgs e)
        {
            try
            {

                if (_dbContext.Database.GetPendingMigrations().Any())
                {
                    if (!File.Exists(DatabaseSettings.databaseFilePath))
                    {
                        MessageBox.Show("Database does not exist, cannot migrate.", "Migration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    LogManager.Information<FrmDatabaseUpgrade>("Starting migration...");


                    _dbContext.Database.Migrate();

                    LogManager.Information<FrmDatabaseUpgrade>("Migration complete, updating product versions...");

                    VersionUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Migration Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Fatal<FrmDatabaseUpgrade>($"{ex}");
            }
        }

        private void btnVersionFix_Click(object sender, EventArgs e)
        {
            LogManager.Information<FrmDatabaseUpgrade>("Attempting VersionFix");

            if (!_dbContext.Database.GetPendingMigrations().Any())
            {
                LogManager.Information<FrmDatabaseUpgrade>("VersionFix valid, running update");
                if(VersionUpdate())
                {
                    MessageBox.Show("Fix applied", "VersionFix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            MessageBox.Show("Version mismatch is due to missing migrations, run migrations instead.", "Version Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LogManager.Error<FrmDatabaseUpgrade>("Migrations pending, VersionFix cancelled as migrations need to be ran!");

        }

        private bool VersionUpdate()
        {
            try
            {
                LogManager.Information<FrmDatabaseUpgrade>("Trying to update product versions...");

                var sysInfo = _dbContext.SystemInfo.FirstOrDefault();

                if (sysInfo == null) { return false; }

                if (sysInfo.ProductVersion == Application.ProductVersion)
                {
                    LogManager.Information<FrmDatabaseUpgrade>("Product versions match, skipping.");

                    return false;
                }
                else
                {
                    sysInfo.ProductVersion = Application.ProductVersion;
                    _dbContext.SystemInfo.Update(sysInfo);

                    ActionLogMethods.Updated(_dbContext, ActionAlertCategory.System, "Product Upgrade", Environment.UserName);

                    _dbContext.SaveChanges();
                    LogManager.Information<FrmDatabaseUpgrade>("Product versions matched, changes saved.");
                    return true;
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", $"{nameof(VersionUpdate)} Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Fatal<FrmDatabaseUpgrade>($"{ex}");
                return false;
            }
        }
    }
}

using AssetTrakr.Database;
using AssetTrakr.Models.System;
using AssetTrakr.Utils.Updater;

namespace AssetTrakr.Update.App
{
    public partial class FrmMain : Form
    {

        private readonly DatabaseContext _dbContext;
        private readonly CheckForUpdates _checkForUpdates;
        private readonly string _currentProductVersion;
        private SystemInfo _currentSystemInfo;

        public FrmMain()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();
            _checkForUpdates ??= new("https://api.github.com/repos/laim/assetrakr/releases", false);
            _currentSystemInfo = _dbContext.SystemInfo.First();
            _currentProductVersion = _currentSystemInfo.ProductVersion;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            lblCurVer.Text = $"You are currently running {_currentProductVersion}";

            await CheckForUpdates();
            await GetReleases();
        }

        private async Task CheckForUpdates()
        {
            this.Enabled = false;

            bool isUpdateAvailable = await _checkForUpdates.IsUpdateAvailable(_currentProductVersion);

            if (!isUpdateAvailable)
            {
                this.Enabled = true;
                return;
            }

            Text = $"{Text} - Update Available";

            this.Enabled = true;
        }

        private async Task GetReleases()
        {
            var releaseInfo = await _checkForUpdates.GetReleases();

            if (releaseInfo == null)
            {
                MessageBox.Show("No releases found!", "Releases", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbReleases.DataSource = releaseInfo;
            lbReleases.DisplayMember = "tag_name";
            lbReleases.ValueMember = "tag_name";
        }

        private async void btnInstall_ClickAsync(object sender, EventArgs e)
        {
            if (lbReleases.SelectedItem is not ReleaseModel release)
            {
                return;
            }

            //this.Enabled = false;

            // download the release
            await _checkForUpdates.DownloadRelease(release);

            if (!File.Exists("efbundle.exe"))
            {
                MessageBox.Show("No efbundle.exe file has been found.", "efbundle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!File.Exists(DatabaseSettings.databaseFilePath))
            {
                MessageBox.Show($"No database with name {DatabaseSettings.databaseFileName} found at {DatabaseSettings.directoryPath}", "database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // backup current installation.  we do this after the file has been downloaded
            // and the checks have been completed to ensure we don't accidentally delete files we need
            _checkForUpdates.BackupCurrentInstallation(_currentSystemInfo.RunDirectory);

            // backup the database to the database backup location
            File.Copy(DatabaseSettings.databaseFilePath, DatabaseSettings.databaseFileBackupPath);

            // TODO: Replace our old files with new installation

            // Run our migrations executable
            System.Diagnostics.Process.Start("efbundle.exe");

            this.Enabled = true;
        }

        private void lbReleases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbReleases.SelectedItem is not ReleaseModel release)
            {
                return;
            }

            btnInstall.Enabled = true;

            if (new Version(release.tag_name) <= new Version(_currentProductVersion))
            {
                btnInstall.Enabled = false;
            }

            lblNewVersion.Text = $"New Version: {release.tag_name}";
            lblChangeLog.Text = release.body;
        }


    }
}

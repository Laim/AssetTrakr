using AssetTrakr.Alerts;
using AssetTrakr.App.Forms.Asset;
using AssetTrakr.App.Forms.Contract;
using AssetTrakr.App.Forms.License;
using AssetTrakr.App.Forms.Miscellaneous;
using AssetTrakr.App.Forms.Shared;
using AssetTrakr.App.Helpers;
using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Logging;
using AssetTrakr.Utils.Enums;
using Microsoft.Data.Sqlite;
using System.ComponentModel;
using System.Diagnostics;

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

#if DEBUG
            Text += " - Debug Build";
#endif

            try
            {

                if (!CanConnectDatabase())
                {
                    MessageBox.Show("Cannot connect to Database, have you ran AssetTrakr.App.Setup?", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    
                    // Return needed to stop blank db being created before app.exit finishes
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Boot Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Fatal<FrmMain>($"{ex}");
                Application.Exit();
            }

            Registration();

            // backup the database if setting is enabled
            if (_dbContext.SystemSettings.WhereEnabled(nameof(SystemSettings.AutomaticBackups)))
            {
                BackupManager backupManager = new(Convert.ToInt32(_dbContext.SystemSettings.FirstOrDefault(ss => ss.Name == nameof(SystemSettings.AutomaticBackups))?.SettingValue));
                if (!backupManager.Backup())
                {
                    MessageBox.Show("Backup failed, see log for more details.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadWidgets();
            RefreshAlerts();

            aboutToolStripMenuItem.Text = $"About {ProductName}";
        }

        private bool CanConnectDatabase()
        {
            return _dbContext.Database.CanConnect();
        }

        /// <summary>
        /// Checks if the application has been registered or not in the local database, and if it already has confirm the database
        /// and application versions are correct
        /// </summary>
        private void Registration()
        {
            try
            {
                var systemInformation = _dbContext.SystemInfo.FirstOrDefault();

                if(systemInformation == null)
                {
                    MessageBox.Show($"Unable to retrieve System Registration, run AssetTrakr.App.Setup!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.Fatal<FrmMain>("Application has not been registered, exiting out.");
                    Application.Exit();
                    return;
                }

                if(systemInformation.ProductVersion != Application.ProductVersion)
                {
                    MessageBox.Show("Stored product version does not match installed version, please run AssetTrakr.App.Setup to fix.", "Incompatible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

            }
            catch (SqliteException sqlEx)
            {
                MessageBox.Show($"{sqlEx.Message} \r\nSee log for more information.  The application will now close.", "Product Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Fatal<FrmMain>($"{sqlEx}");
                Application.Exit();
            }
        }

        /// <summary>
        /// Populates the Dashboard Widgets
        /// </summary>
        private void LoadWidgets()
        {
            LogManager.Information<FrmMain>($"Loading Dashboard Widgets");
            lblLicenseCount.Text = $"{_dbContext.Licenses.Count()}";
            lblAssetCount.Text = $"{_dbContext.Assets.Count()}";
            lblManufacturerCount.Text = $"{_dbContext.Manufacturers.Count()}";
            lblContractCount.Text = $"{_dbContext.Contracts.Count()}";
            lblPlatformsCount.Text = $"{_dbContext.Platforms.Count()}";
            LogManager.Information<FrmMain>($"Dashboard Widgets Loaded");

            // set colors
            SetTextColor(this);
        }

        /// <summary>
        /// Sets the color of the labels that contain 'Count' in their name to green if they contain anything other than 0
        /// </summary>
        /// <param name="control">The parent <see cref="Control"/></param>
        private static void SetTextColor(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is Label l && l.Name.EndsWith("Count"))
                {
                    if (int.TryParse(l.Text, out int value) && value != 0)
                    {
                        l.ForeColor = Color.Green;
                    }
                }

                if (ctrl.HasChildren)
                {
                    SetTextColor(ctrl);
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            _dbContext?.Dispose();
        }

        /// <summary>
        /// Creates the alerts for the AlertList for the User to view
        /// </summary>
        private void RefreshAlerts()
        {
            AlertGenerator alertGenerator = new();

            dgvAlerts.DataSource = alertGenerator.GetAlerts();
        }

        private void lnkRefreshDashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadWidgets();
            RefreshAlerts();
        }

        #region ToolStrip
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

        private void addAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAssetModify frmAssetModify = new();
            frmAssetModify.ShowDialog();
        }

        private void actionLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmActionLog frmActionLog = new();
            frmActionLog.ShowDialog();
        }

        private void viewAssetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAssetViewAll FrmAssetViewAll = new();
            FrmAssetViewAll.ShowDialog();
        }

        private void viewContractsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmContractViewAll FrmContractViewAll = new();
            FrmContractViewAll.ShowDialog();
        }

        private void manufacturerManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManufacturerManager frmManufacturerManager = new();
            frmManufacturerManager.ShowDialog();
        }

        private void platformManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlatformManager frmPlatformManager = new();
            frmPlatformManager.ShowDialog();
        }

        private void operatingSystemManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOperatingSystemManager FrmOperatingSystemManager = new();
            FrmOperatingSystemManager.ShowDialog();
        }

        private void addContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmContractModify frmContractModify = new();
            frmContractModify.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportRunner FrmReportRunner = new();
            FrmReportRunner.ShowDialog();
        }

        private void systemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSystemSettings frmSystemSettings = new FrmSystemSettings();
            frmSystemSettings.ShowDialog();
        }

        private void dataExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDataExporter FrmDataExporter = new();
            FrmDataExporter.ShowDialog();
        }

        #region Help
        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(
                new ProcessStartInfo($"https://github.com/Laim/AssetTrakr/issues/new?assignees=&labels=bug&projects=&template=bug_report.md&title=%5BBUG%5D+")
                {
                    UseShellExecute = true
                }
            );
        }

        private void featureRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(
                new ProcessStartInfo($"https://github.com/Laim/AssetTrakr/issues/new?assignees=&labels=enhancement&projects=&template=feature_request.md&title=%5BFR%5D+")
                {
                    UseShellExecute = true
                }
            );
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(
                new ProcessStartInfo($"https://github.com/Laim/AssetTrakr/wiki")
                {
                    UseShellExecute = true
                }
            );
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(
                new ProcessStartInfo($"{DatabaseSettings.directoryPath}")
                {
                    UseShellExecute = true
                }
            );
        }

        #endregion

        #endregion

        #region ToolStrip for DataGrids
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

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvAlerts.Export();
        }
        #endregion

    }
}

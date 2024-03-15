using AssetTrakr.App.Forms.Asset;
using AssetTrakr.App.Forms.Contract;
using AssetTrakr.App.Forms.License;
using AssetTrakr.App.Forms.Miscellaneous;
using AssetTrakr.App.Forms.Shared;
using AssetTrakr.App.Helpers;
using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Models;
using AssetTrakr.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Xml.Linq;

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
                Application.Exit();
            }

            LoadWidgets();
            RefreshAlerts();
            Registration();
        }

        private void Registration()
        {
            // ask user to register if not registered
            if (!_dbContext.SystemInfo.Select(si => si.DatabaseCreationDate).Any())
            {
                FrmSystemRegistration frmSystemRegistration = new();
                frmSystemRegistration.ShowDialog();
            }
            else
            {
                // user is already registered, check our product version is the same otherwise update it
                var sysInfo = _dbContext.SystemInfo.FirstOrDefault();

                if (sysInfo == null) { return; }

                if (sysInfo.ProductVersion == Application.ProductVersion)
                {
                    return;
                }
                else
                {
                    sysInfo.ProductVersion = Application.ProductVersion;
                    _dbContext.SystemInfo.Update(sysInfo);

                    ActionLogMethods.Updated(_dbContext, ActionAlertCategory.System, "Product Registration", "SYSTEM");

                    _dbContext.SaveChanges();
                }
            }
        }

        private void LoadWidgets()
        {
            lblLicenseCount.Text = $"{_dbContext.Licenses.Count()}";
            lblAssetCount.Text = $"{_dbContext.Assets.Count()}";
            lblManufacturerCount.Text = $"{_dbContext.Manufacturers.Count()}";
            lblContractCount.Text = $"{_dbContext.Contracts.Count()}";
            lblPlatformsCount.Text = $"{_dbContext.Platforms.Count()}";

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

        private void addContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmContractModify frmContractModify = new();
            frmContractModify.ShowDialog();
        }

        private void RefreshAlerts()
        {
            List<Alert> alerts = [];

            var currentDate = DateOnly.FromDateTime(DateTime.Now);
            int threshold = 30;
            var thresholdDate = currentDate.AddDays(threshold);

            #region License Alerts
            var licenses = _dbContext.Licenses
                .Include(l => l.LicensePeriods)
                    .ThenInclude(lp => lp.Period);

            if (!licenses.Any())
            {
                alerts.Add(new Alert
                {
                    Category = Utils.Enums.ActionAlertCategory.License,
                    Description = "No licenses added",
                    Severity = Utils.Enums.Severity.High
                });
            }

            // licenses with expired subscription periods
            var licensesWithExpiredSubscriptions = licenses
                .Where(l => l.IsSubscription && l.LicensePeriods.All(lp => lp.Period.EndDate < currentDate));

            if (licensesWithExpiredSubscriptions.Any())
            {
                int count = licensesWithExpiredSubscriptions.Count();
                string text = (count == 1) ? "license's subscription has" : "licenses' subscriptions have";

                alerts.Add(new Alert
                {
                    Category = Utils.Enums.ActionAlertCategory.License,
                    Description = $"{count} {text} expired",
                    Severity = Utils.Enums.Severity.High
                });
            }

            // licenses with subscription period end dates that are coming up soon
            var licensesWithExpiringWarranties = licenses
                .Where(a => a.LicensePeriods.Any(ap => ap.Period.EndDate >= currentDate && ap.Period.EndDate <= thresholdDate));

            if (licensesWithExpiringWarranties.Any())
            {
                int count = licensesWithExpiringWarranties.Count();
                string text = (count == 1) ? "license has" : "licenses have";

                alerts.Add(new Alert
                {
                    Category = Utils.Enums.ActionAlertCategory.License,
                    Description = $"{count} {text} subscriptions expiring within the next {threshold} days",
                    Severity = Utils.Enums.Severity.High
                });
            }

            // licenses without any attachments
            if (licenses.Any(l => l.LicenseAttachments.Count == 0))
            {
                int count = licenses.Count(l => l.LicenseAttachments.Count == 0);
                string text = (count < 2) ? "license" : "licenses";

                alerts.Add(new Alert
                {
                    Category = Utils.Enums.ActionAlertCategory.License,
                    Description = $"{count} {text} without attachments",
                    Severity = Utils.Enums.Severity.Medium
                });
            }

            #endregion

            #region Asset Alerts

            var assets = _dbContext.Assets
                .Include(a => a.AssetPeriods)
                    .ThenInclude(ap => ap.Period);

            if (!assets.Any())
            {
                alerts.Add(new Alert
                {
                    Category = Utils.Enums.ActionAlertCategory.Asset,
                    Description = "No assets added",
                    Severity = Utils.Enums.Severity.High
                });
            }

            // assets without any warranty
            if (assets.Any(a => a.IsUnderWarranty == false))
            {
                int count = assets.Count(a => a.IsUnderWarranty == false);
                string text = (count < 2) ? "asset" : "assets";

                alerts.Add(new Alert
                {
                    Category = Utils.Enums.ActionAlertCategory.Asset,
                    Description = $"{count} {text} without warranty",
                    Severity = Utils.Enums.Severity.High
                });
            }

            // assets with expired warranty
            var assetsWithExpiredWarranty = assets
                .Where(a => a.AssetPeriods.All(ap => ap.Period.EndDate < currentDate));

            if (assetsWithExpiredWarranty.Any())
            {
                int count = assetsWithExpiredWarranty.Count();
                string text = (count == 1) ? "asset's warranty has" : "assets' warranties have";

                alerts.Add(new Alert
                {
                    Category = Utils.Enums.ActionAlertCategory.Asset,
                    Description = $"{count} {text} expired",
                    Severity = Utils.Enums.Severity.High
                });
            }

            // assets with warranty end dates that are coming up soon (30 days)
            var assetsWithExpiringWarranties = assets
                .Where(a => a.AssetPeriods.Any(ap => ap.Period.EndDate >= currentDate && ap.Period.EndDate <= thresholdDate));

            if (assetsWithExpiringWarranties.Any())
            {
                int count = assetsWithExpiringWarranties.Count();
                string text = (count == 1) ? "asset has" : "assets have";

                alerts.Add(new Alert
                {
                    Category = Utils.Enums.ActionAlertCategory.Asset,
                    Description = $"{count} {text} warranties expiring within the next {threshold} days",
                    Severity = Utils.Enums.Severity.High
                });
            }

            // assets without any attachments
            if (assets.Any(a => a.AssetAttachments.Count == 0))
            {
                int count = assets.Count(l => l.AssetAttachments.Count == 0);
                string text = (count < 2) ? "asset" : "assets'";

                alerts.Add(new Alert
                {
                    Category = Utils.Enums.ActionAlertCategory.Asset,
                    Description = $"{count} {text} without attachments",
                    Severity = Utils.Enums.Severity.Medium
                });
            }


            #endregion

            dgvAlerts.DataSource = alerts;
        }

        private void lnkRefreshDashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadWidgets();
            RefreshAlerts();
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

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvAlerts.Export();
        }

        private void defaultReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportRunner FrmReportRunner = new();
            FrmReportRunner.ShowDialog();
        }
    }
}

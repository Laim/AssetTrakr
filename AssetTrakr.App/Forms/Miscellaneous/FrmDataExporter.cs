using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Logging;
using Microsoft.EntityFrameworkCore;

namespace AssetTrakr.App.Forms.Miscellaneous
{
    /// <summary>
    /// TODO: This is incomplete.  Licenses (below, not the model lol) needs to be changed completely to include data correctly, assets excludes attachment data.
    /// 
    /// Currently not user usable.
    /// </summary>
    public partial class FrmDataExporter : Form
    {

        private DatabaseContext _dbContext;

        public FrmDataExporter()
        {
            InitializeComponent();

            _dbContext ??= new();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var checkboxes = new CheckBox[]
            {
                cbLicenses, cbContracts, cbAssets, cbPlatforms, cbManufacturers, cbActionLog
            };

            int exportCount = 0;
            int expectedExportCount = checkboxes.Count(cb => cb.Checked);

            if (expectedExportCount == 0)
            {
                MessageBox.Show("At least one checkbox must be selected for data export.", "Data Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmDataExporter>($"{Environment.UserName} tried to data export without any checkboxes selected");
                return;
            }

            LogManager.Information<FrmDataExporter>($"Expecting {expectedExportCount} in export");

            foreach (var cb in checkboxes)
            {
                if (cb.Checked)
                {
                    switch (cb.Name)
                    {
                        case nameof(cbLicenses):
                            if (ExportLicenses()) { exportCount++; }
                            break;
                        case nameof(cbContracts):
                            if (ExportContracts()) { exportCount++; }
                            break;
                        case nameof(cbAssets):
                            if (ExportAssets()) { exportCount++; }
                            break;
                        case nameof(cbPlatforms):
                            if (ExportPlatforms()) { exportCount++; }
                            break;
                        case nameof(cbManufacturers):
                            if (ExportManufacturers()) { exportCount++; }
                            break;
                        case nameof(cbActionLog):
                            if (ExportActionLog()) { exportCount++; }
                            break;
                    }
                }
            }
        }

        private bool ExportLicenses()
        {
            LogManager.Information<FrmDataExporter>($"{Environment.UserName} has requested export via [{nameof(ExportLicenses)}]");

            try
            {
                var licenses = _dbContext.Licenses.Include(l => l.LicensePeriods).ThenInclude(lp => lp.Period);

                return licenses.Export(nameof(licenses));

            } 
            catch (Exception ex)
            {
                LogManager.Fatal<FrmDataExporter>($"{ex}");
                return false;
            }
        }

        private bool ExportContracts() 
        { 
            LogManager.Information<FrmDataExporter>($"{Environment.UserName} has requested export via [{nameof(ExportContracts)}]");

            try
            {

                return true;

            }
            catch (Exception ex)
            {
                LogManager.Fatal<FrmDataExporter>($"{ex}");
                return false;
            }
        }

        private bool ExportAssets() 
        { 
            LogManager.Information<FrmDataExporter>($"{Environment.UserName} has requested export via [{nameof(ExportAssets)}]");

            try
            {

                var assets = _dbContext.Assets
                    .Include(a => a.Manufacturer)
                    .Include(a => a.Contract)
                    .Include(a => a.AssetAttachments)
                    .Include(a => a.Platform)
                    .Include(a => a.AssetPeriods)
                    .Select(a => new
                    {
                        a.AssetId,
                        a.Name,
                        a.Model,
                        Type = a.Hardware.AssetType,
                        Manufacturer = a.Manufacturer.Name ?? "",
                        Platform = a.Platform.Name ?? "",
                        Contract = a.Contract.Name ?? "",
                        Attachments = a.AssetAttachments.Count,
                        Warranty = a.IsUnderWarranty,
                        a.Hardware.RamSizeInGB,
                        a.Hardware.Processor,
                        a.Hardware.BiosSerialNumber,
                        a.LicenseKey,
                        OperatingSystem = a.OperatingSystem.Name,
                        a.OrderReference,
                        a.Price,
                        a.RegisteredUser,
                        a.RegisteredEmail,
                        WarrantyPeriodsFormatted = string.Join($",{Environment.NewLine}", a.AssetPeriods
                                .Where(ap => ap != null && ap.Period != null)
                                .Select(ap => ap.Period.StartDate.ToString("d") + " - " + ap.Period.EndDate.ToString("d"))),
                        a.CreatedBy,
                        a.CreatedDate,
                        a.UpdatedBy,
                        a.UpdatedDate
                    });

                return assets.Export(nameof(assets));

            }
            catch (Exception ex)
            {
                LogManager.Fatal<FrmDataExporter>($"{ex}");
                return false;
            }
        }

        private bool ExportPlatforms() 
        { 
            LogManager.Information<FrmDataExporter>($"{Environment.UserName} has requested export via [{nameof(ExportPlatforms)}]");

            try
            {

                return true;

            }
            catch (Exception ex)
            {
                LogManager.Fatal<FrmDataExporter>($"{ex}");
                return false;
            }
        }

        private bool ExportManufacturers() 
        { 
            LogManager.Information<FrmDataExporter>($"{Environment.UserName} has requested export via [{nameof(ExportManufacturers)}]");

            try
            {

                return true;

            }
            catch (Exception ex)
            {
                LogManager.Fatal<FrmDataExporter>($"{ex}");
                return false;
            }
        }

        private bool ExportActionLog() 
        { 
            LogManager.Information<FrmDataExporter>($"{Environment.UserName} has requested export via [{nameof(ExportActionLog)}]");

            try
            {

                return true;

            }
            catch (Exception ex)
            {
                LogManager.Fatal<FrmDataExporter>($"{ex}");
                return false;
            }
        }
    }
}

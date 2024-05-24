using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Logging;
using OfficeOpenXml;
using Syncfusion.Licensing;

namespace AssetTrakr.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            LogManager logManager = new();
            LogManager.Information("Initialize...", typeof(Program));

#if DEBUG
            LogManager.Information("APPLICATION IS IN DEBUG MODE", typeof(Program));
#endif

            LogManager.Information("Registering Syncfusion with Community License!", typeof(Program));

            // SyncfusionInfo is generated during the build process.  If "GeneratedSyncfusionLicense.cs" does not exist in the AssetTrakr
            // project yet, ensure you build per https://github.com/McKenzie-Software/AssetTrakr/wiki/Build-from-Source#107-onwards
            SyncfusionLicenseProvider.RegisterLicense(SyncfusionInfo.LicenseKey);
            bool sfLicenseStatus = SyncfusionLicenseProvider.ValidateLicense(Platform.WindowsForms, out var sfLicenseStatusMsg);

            if (SyncfusionInfo.LicenseKey == "nullkey")
            {
                LogManager.Fatal("SyncfusionInfo.LicenseKey is set to nullkey, a validate Sf License must be provided during build! see " +
                    "https://github.com/McKenzie-Software/AssetTrakr/wiki/Build-from-Source#107-onwards", typeof(Program));
            }

            if (string.IsNullOrEmpty(sfLicenseStatusMsg))
            {
                LogManager.Information($"Syncfusion License Valid: {sfLicenseStatus}", typeof(Program));
            } 
            else
            {
                LogManager.Information($"Syncfusion Validate License Response: {sfLicenseStatusMsg}", typeof(Program));
            }

            LogManager.Information("Registering EPPlus LicenseContext", typeof(Program));
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            CreateDirectories();

            Application.Run(new Forms.FrmMain());
        }

        private static void CreateDirectories()
        {
            if (!Directory.Exists(DatabaseSettings.directoryPath))
            {
                Directory.CreateDirectory(DatabaseSettings.directoryPath);
            }

            if (!Directory.Exists(DatabaseSettings.directoryBackupPath))
            {
                Directory.CreateDirectory(DatabaseSettings.directoryBackupPath);
            }
        }
    }
}
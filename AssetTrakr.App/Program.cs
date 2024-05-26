using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Logging;
using OfficeOpenXml;
using Syncfusion.Licensing;
using Syncfusion.PdfViewer.Base;
using System.Runtime.Versioning;

namespace AssetTrakr.App
{
    [SupportedOSPlatform("windows")]
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
            LogManager.Information("Application Startup in progress...", typeof(Program));

#if DEBUG
            LogManager.Information("Build config: debug", typeof(Program));
#else
            LogManager.Information("Build config: release", typeof(Program));
#endif

            SyncfusionLicenseValidation();
            
            LogManager.Information("Registering EPPlus LicenseContext", typeof(Program));
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            CreateDirectories();

            Application.Run(new Forms.FrmMain());

            LogManager.Information("Application started", typeof(Program));
        }

        /// <summary>
        /// Creates the Database Directories, see <see cref="DatabaseSettings"/>
        /// </summary>
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

        /// <summary>
        /// Registers the Syncfusion License as well as checking if it is a valid license.  An invalid license does not prevent the program working
        /// however will show syncfusion forced pop-ups in-app and watermarks in exports.
        /// </summary>
        private static void SyncfusionLicenseValidation()
        {
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
        }
    }
}
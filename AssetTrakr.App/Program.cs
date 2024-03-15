using AssetTrakr.Database;
using OfficeOpenXml;

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
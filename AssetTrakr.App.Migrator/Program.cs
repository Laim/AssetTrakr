using AssetTrakr.App.Forms.Miscellaneous;
using AssetTrakr.Logging;

namespace AssetTrakr.App.Migrator
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

            LogManager logManager = new("setupApp.log");
            LogManager.Information("Initialize...", nameof(Program));

            Application.Run(new FrmDatabaseUpgrade());
        }
    }
}
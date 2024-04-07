namespace AssetTrakr.Database
{
    public static class DatabaseSettings
    {
        /// <summary>
        /// The directory that the database will be saved in
        /// C:\ProgramData\Laim\AssetTrakr\Database
        /// </summary>
        public static string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Laim", "AssetTrakr", "Database");

#if DEBUG

        /// <summary>
        /// The name of the actual database
        /// </summary>
        public static string databaseFileName = "AssetTrakr_DevDb.db";
#else
        /// <summary>
        /// The name of the actual database
        /// </summary>
        public static string databaseFileName = "AssetTrakr.db";
#endif

        /// <summary>
        /// The full path including the database name
        /// C:\ProgramData\Laim\AssetTrakr\Database\{databaseName}.db
        /// </summary>
        public static string databaseFilePath = Path.Combine(directoryPath, databaseFileName);

        /// <summary>
        /// The location of database backups that are run by AssetTrakr.Update.App
        /// C:\ProgramData\Laim\AssetTrakr\Database\Backup
        /// </summary>
        public static string directoryBackupPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Laim", "AssetTrakr", "Database", "Backup");

        /// <summary>
        /// The full path including the database name.  Backups have DateTime.Now() appended AFTER the extension
        /// C:\ProgramData\Laim\AssetTrakr\Database\{databaseName}.db-ddmmyyyhhmmss
        /// </summary>
        public static string databaseFileBackupPath = Path.Combine(directoryBackupPath, $"{databaseFileName}-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}");
    }
}

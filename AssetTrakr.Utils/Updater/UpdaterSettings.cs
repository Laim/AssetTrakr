namespace AssetTrakr.Utils.Updater
{
    internal static class UpdaterSettings
    {
        /// <summary>
        /// The directory that the upload will be saved in
        /// C:\ProgramData\Laim\AssetTrakr\Updates\Downloads
        /// </summary>
        internal static string directoryPathDownloads = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Laim", "AssetTrakr", "Updates", "Downloads");

        /// <summary>
        /// The directory that the upload will be saved in uncompressed from the zip
        /// C:\ProgramData\Laim\AssetTrakr\Updates\Uncompressed
        /// </summary>
        internal static string directoryPathUncompressed = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Laim", "AssetTrakr", "Updates", "Uncompressed");

        /// <summary>
        /// The directory that the existing installation will be saved in
        /// C:\ProgramData\Laim\AssetTrakr\Updates\Backup
        /// </summary>
        internal static string directoryPathBackup = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Laim", "AssetTrakr", "Updates", "Backup");
    }
}

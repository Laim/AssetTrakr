using AssetTrakr.App.Forms.Contract;
using AssetTrakr.Database;
using AssetTrakr.Logging;

namespace AssetTrakr.App.Helpers
{
    public class BackupManager(int backupLimit)
    {
        private readonly int _backupLimit = backupLimit;

        /// <summary>
        /// Backs the database up to <see cref="DatabaseSettings.databaseFileBackupPath"/>
        /// </summary>
        /// <returns>
        /// true if backup successful
        /// </returns>
        public bool Backup()
        {
            string backupPath = DatabaseSettings.databaseFileBackupPath;

            DeleteLegacyBackups();

            try
            {
                File.Copy(DatabaseSettings.databaseFilePath, backupPath);
            }
            catch (Exception ex)
            {
                LogManager.Error<BackupManager>($"{ex}");
                return false;
            }


            if(File.Exists(backupPath))
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// Deletes legacy backups based on the users backup limit specified in System Settings
        /// </summary>
        internal void DeleteLegacyBackups()
        {
            try
            {
                var backupFiles = Directory.GetFiles(DatabaseSettings.directoryBackupPath, $"{DatabaseSettings.databaseFileName}-*")
                                    .Select(f => new FileInfo(f))
                                    .OrderByDescending(f => f.CreationTime)
                                    .ToList();

                while (backupFiles.Count >= _backupLimit)
                {
                    var fileToDelete = backupFiles.Last();
                    fileToDelete.Delete();
                    backupFiles.Remove(fileToDelete);
                }

            } 
            catch (Exception ex)
            {
                LogManager.Error<BackupManager>($"{ex}");
            }
        }
    }
}

using AssetTrakr.Utils.Exceptions;
using Newtonsoft.Json;
using System.IO.Compression;

namespace AssetTrakr.Utils.Updater
{
    public class CheckForUpdates
    {
        internal string _updateUrl = string.Empty;
        internal bool _latestOnly = false;

        private HttpClient _httpClient;

        internal string _downloadedFilePath = string.Empty;

        public CheckForUpdates(string updateUrl, bool latestOnly = false)
        {
            _updateUrl = updateUrl;
            _latestOnly = latestOnly;

            if(_updateUrl == string.Empty)
            {
                throw new UpdateUrlEmptyException();
            }

            if (_latestOnly)
            {
                _updateUrl = $"{_updateUrl}/latest";
            }

            _httpClient ??= new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"AssetTrakr/{new Random().Next()}");

            CreateDirectories();
        }

        /// <summary>
        /// Returns release information
        /// </summary>
        /// <returns>
        /// <see cref="List{ReleaseModel}"/> of type <see cref="ReleaseModel"/>
        /// </returns>
        internal async Task<List<ReleaseModel>?> GetReleaseInformation()
        {
            string output;
            List<ReleaseModel>? data;

            try
            {
                var response = await _httpClient.GetAsync(_updateUrl);

                response.EnsureSuccessStatusCode();

                output = await response.Content.ReadAsStringAsync();
            } 
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
                return null;
            }

            try
            {
                data = JsonConvert.DeserializeObject<List<ReleaseModel>>(output);
            }
            catch (JsonReaderException ex)
            {
                // Handle invalid JSON format
                Console.WriteLine($"Invalid JSON format: {ex.Message} {ex.InnerException}");
                return null;
            }
            catch (JsonSerializationException ex)
            {
                // Handle deserialization problems (e.g., JSON structure doesn't match the MyClass structure)
                Console.WriteLine($"Deserialization error: {ex.Message} {ex.InnerException}");
                return null;
            }
            catch (Exception ex)
            {
                // Handle other unforeseen errors
                Console.WriteLine($"Unexpected error: {ex.Message} {ex.InnerException}");
                return null;
            }

            return data;
        }
    
        /// <summary>
        /// Checks to see if there is a version newer than the current version.
        /// </summary>
        /// <param name="currentProductVersion">Latest application version</param>
        /// <returns>
        /// true if newer update available
        /// </returns>
        public async Task<bool> IsUpdateAvailable(string currentProductVersion)
        {
            List<ReleaseModel>? releaseInfo = await GetReleaseInformation();

            if(releaseInfo == null) { return false; }

            if (releaseInfo.Any())
            {
                Version latestVersion = new(releaseInfo[0].tag_name);
                Version currentVersion = new(currentProductVersion);

                if(latestVersion > currentVersion)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets all available releases
        /// </summary>
        /// <returns>
        /// <see cref="List{T}"/> of type <see cref="ReleaseModel"/> or NULL if no releases
        /// </returns>
        public async Task<List<ReleaseModel>?> GetReleases()
        {
            return await GetReleaseInformation();
        }
    
        /// <summary>
        /// Downloads the current release and sets the public property 'downloadPath' value to be used in the form
        /// </summary>
        /// <param name="release">
        /// <see cref="ReleaseModel"/>
        /// </param>
        public async Task DownloadRelease(ReleaseModel release)
        {
            if (release == null) { return; }

            // TODO: This assumes there is only one file available for download, will need to be changed later probably
            string download = release.assets[0].browser_download_url;
            
            string downloadLocation = Path.Combine(UpdaterSettings.directoryPathDownloads, release.tag_name);
            
            _downloadedFilePath = Path.Combine(downloadLocation, release.assets[0].name);

            if (!Directory.Exists(downloadLocation))
            {
                Directory.CreateDirectory(downloadLocation);
            }

            try
            {
                var response = await _httpClient.GetAsync(download);

                response.EnsureSuccessStatusCode();

                using (var fileStream = new FileStream(_downloadedFilePath, FileMode.Create))
                {
                    await response.Content.CopyToAsync(fileStream);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error during download: {ex}");
            }

            UncompressDownloadedRelease(release);
        }

        /// <summary>
        /// Deletes the contents of the current backup directory and then backs up the current installation
        /// </summary>
        /// <param name="sourceDirectory">
        /// The directory where the app is running from and all of its libraries etc. are present
        /// </param>
        public void BackupCurrentInstallation(string sourceDirectory)
        {
            if (!DeleteCreateBackupDirectory(source: new DirectoryInfo(UpdaterSettings.directoryPathBackup)))
            {
                return;
            }

            DirectoryInfo directory = new(sourceDirectory);

            DeepCopy(directory, UpdaterSettings.directoryPathBackup);
        }

        /// <summary>
        /// Unzips the download file to the uncompressed directory <see cref="UpdaterSettings"/>
        /// </summary>
        /// <param name="release">
        /// Downloaded release per <see cref="ReleaseModel"/>
        /// </param>
        /// <returns>
        /// true if successful
        /// </returns>
        internal async Task<bool> UncompressDownloadedRelease(ReleaseModel release)
        {
            try
            {
                if(!Directory.Exists(UpdaterSettings.directoryPathUncompressed))
                {
                    return false;
                }

                var extractPath = Path.Combine(UpdaterSettings.directoryPathUncompressed, release.tag_name);
                Directory.CreateDirectory(extractPath);

                ZipFile.ExtractToDirectory(_downloadedFilePath, extractPath, false);

                return true;

            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Creates the directories required for updating the application
        /// </summary>
        internal void CreateDirectories()
        {
            if (!Directory.Exists(UpdaterSettings.directoryPathDownloads))
            {
                Directory.CreateDirectory(UpdaterSettings.directoryPathDownloads);
            }

            if (!Directory.Exists(UpdaterSettings.directoryPathBackup))
            {
                Directory.CreateDirectory(UpdaterSettings.directoryPathBackup);
            }

            if (!Directory.Exists(UpdaterSettings.directoryPathUncompressed))
            {
                Directory.CreateDirectory(UpdaterSettings.directoryPathUncompressed);
            }
        }

        /// <summary>
        /// Copies all of the files and directories from the source directory
        /// </summary>
        /// <param name="source">
        /// Directory where the app is running from and all of its libraries are present in
        /// </param>
        /// <param name="destinationDirectory">
        /// Directory where the backup will be stored
        /// </param>
        internal void DeepCopy(DirectoryInfo source, string destinationDirectory)
        {
            DirectoryInfo target;

            target = new DirectoryInfo(destinationDirectory);

            try
            {
                foreach (FileInfo fi in source.GetFiles())
                {
                    Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                }
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                    DeepCopy(diSourceSubDir, nextTargetSubDir.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.InnerException}");
            }
        }

        /// <summary>
        /// Deletes the existing Backup directory, re-creates it
        /// </summary>
        /// <param name="source">Backup directory path</param>
        /// <returns>
        /// true if successful else false
        /// </returns>
        internal bool DeleteCreateBackupDirectory(DirectoryInfo source)
        {
            try
            {
                Directory.Delete(source.FullName, true);

                if(!Directory.Exists(source.FullName))
                {
                    Directory.CreateDirectory(source.FullName);
                }

                return Directory.GetFiles(source.FullName).Length == 0
                       && Directory.GetDirectories(source.FullName).Length == 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.InnerException}");
                return false;
            }
        }
    }
}

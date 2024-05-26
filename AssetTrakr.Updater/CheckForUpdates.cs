using AssetTrakr.Database;
using AssetTrakr.Utils.Enums;
using AssetTrakr.Extensions;
using AssetTrakr.Models.Updater;
using Newtonsoft.Json;
using AssetTrakr.Logging;

namespace AssetTrakr.Updater
{
    public class CheckForUpdates
    {
        private readonly DatabaseContext _dbContext;
        private const string _updateUrl = "https://api.github.com/repos/laim/assettrakr/releases/latest";
        private readonly bool _checkForUpdates;

        public CheckForUpdates()
        {
            _dbContext ??= new();
            _checkForUpdates = _dbContext.SystemSettings.WhereEnabled(nameof(SystemSettings.CheckForUpdates));

            LogManager.Information<CheckForUpdates>($"Starting Updater Client");
        }

        /// <summary>
        /// Sends a <see cref="HttpClient"/> request to GitHub using <see cref="_updateUrl"/> and returns Release if available/successful
        /// </summary>
        /// <returns>
        /// <see cref="Release"/>
        /// </returns>
        internal async Task<Release?> GitHubResponseClient()
        {
            try
            {
                HttpClient client = new();
                client.DefaultRequestHeaders.UserAgent.ParseAdd($"AssetTrakr {new Random().Next()}");

                HttpResponseMessage response = await client.GetAsync(_updateUrl);
                if (response.IsSuccessStatusCode)
                {
                    LogManager.Information<CheckForUpdates>($"Successful response from GitHub");

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Release>(responseBody);

                    if (data == null)
                    {
                        return null;
                    }

                    return data;
                }

                LogManager.Error<CheckForUpdates>($"GitHub Response: {response.StatusCode}");
                return null;
            } 
            catch (Exception ex)
            {
                LogManager.Error<CheckForUpdates>($"{ex}");
                return null;
            }
        }

        /// <summary>
        /// Compares the latest version from <see cref="GitHubResponseClient"/> and returns true if new version available
        /// </summary>
        /// <param name="currentVersion">
        /// Current Version of the installed application
        /// </param>
        /// <returns>
        /// <see cref="bool"/>
        /// </returns>
        public async Task<bool> UpdateAvailable(Version currentVersion)
        {
            try
            {

                if(!_checkForUpdates)
                {
                    LogManager.Information<CheckForUpdates>($"Update Checking Disabled, cancelled check");
                    return false;
                }

                var data = await GitHubResponseClient();

                if (data == null)
                {
                    LogManager.Error<CheckForUpdates>($"Response Data is empty, cancelled.");
                    return false;
                }

                Version latestVersion = new(data.tag_name);
                LogManager.Information<CheckForUpdates>($"Installed Version: {currentVersion}");
                LogManager.Information<CheckForUpdates>($"Latest Version from GitHub: {latestVersion}");

                if(latestVersion > currentVersion)
                {
                    LogManager.Information<CheckForUpdates>($"New version available, alerting user");
                    return true;
                }

                LogManager.Information<CheckForUpdates>($"Latest version installed, cancelled");
                return false;

            }
            catch (Exception ex)
            {
                LogManager.Fatal<CheckForUpdates>($"{ex}");
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace iFruitAddon2
{
    internal static class Updater
    {
        private const string _urlVersionFile = "https://raw.githubusercontent.com/Bob74/iFruitAddon2/master/version";
        private readonly static Version _currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

        public static void CheckForUpdate()
        {
            // Non thread blocking check for update
            Logger.Debug("Starting update check Task...");
            Task.Run(() =>
            {
                Logger.Debug("Fetching version files...");
                Version latestVersion = FetchLatestVersionInfo();
                
                if (latestVersion != null)
                {
                    Logger.Debug("Version files fetched");
                    if (latestVersion > _currentVersion)
                    {
                        Logger.Debug("Update " + latestVersion + " available");
                        NotifyNewUpdate(latestVersion);
                    }
                    else
                    {
                        Logger.Debug("No update available");
                    }
                }
                else
                {
                    Logger.Debug("Error: Failed to fetch version files");
                }
            });
            Logger.Debug("Update checking Task is started");
        }

        /// <summary>
        /// Downloads the latest version info from the github repo
        /// </summary>
        /// <returns>MMIVersion object containing version number and changelog</returns>
        private static Version FetchLatestVersionInfo()
        {
            string version = "";

            try
            {
                using (WebClient wc = new WebClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    // Remove insecure protocols (SSL3, TLS 1.0, TLS 1.1)
                    ServicePointManager.SecurityProtocol &= ~SecurityProtocolType.Ssl3;
                    ServicePointManager.SecurityProtocol &= ~SecurityProtocolType.Tls;
                    ServicePointManager.SecurityProtocol &= ~SecurityProtocolType.Tls11;
                    // Add TLS 1.2
                    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

                    wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
                    wc.Headers.Add("Cache-Control", "no-cache");
                    wc.Encoding = Encoding.UTF8;
                    version = wc.DownloadString(_urlVersionFile).Replace("\r", "").Replace("\n", "");
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }

            if (version != "") return new Version(version);

            return null;
        }

        /// <summary>
        /// Notifies the user that a new update is available
        /// </summary>
        /// <param name="latestVersion">Object returned by FetchLatestVersionInfo</param>
        private static void NotifyNewUpdate(Version latestVersion)
        {
            GTA.UI.Notification.Show("iFruitAddon2: Update " + latestVersion + "is available!", true);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using GTA;

namespace iFruitAddon
{
    static class iFruitAddon2
    {
        private static string version = "2.0.0";
        private static bool updateChecked = false;

        private static int contactIndex = 40;
        public static int ContactIndex { get => contactIndex; internal set => contactIndex = value; }

        public static bool IsUpdateAvailable()
        {
            if (!updateChecked)
            {
                string downloadedString = "";

                try
                {
                    WebClient client = new WebClient();
                    downloadedString = client.DownloadString("https://raw.githubusercontent.com/Bob74/iFruitAddon2/master/version");

                    downloadedString = downloadedString.Replace("\r", "");
                    downloadedString = downloadedString.Replace("\n", "");

                    if (downloadedString == version)
                        return false;
                    else
                        return true;
                }
                catch (Exception e)
                {
                    Logger.Log("Error: IsUpdateAvailable - " + e.Message);
                }

                updateChecked = true;
            }

            return false;
        }

        public static void NotifyNewUpdate()
        {
            UI.Notify("iFruitAddon2: A new update is available!", true);
        }

    }
}

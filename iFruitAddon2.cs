using System;
using System.IO;
using System.Net;

using GTA;

namespace iFruitAddon2
{
    class iFruitAddon2 : Script
    {
        private static string version = "2.0.0";
        private static string _configDir = AppDomain.CurrentDomain.BaseDirectory + "\\iFruitAddon2";
        private static string _configFile = _configDir + "\\config.ini";

        private static int contactIndex = 40;
        public static int ContactIndex { get => contactIndex; internal set => contactIndex = value; }

        private static ScriptSettings _config;
        public static ScriptSettings Config { get => _config; private set => _config = value; }

        public iFruitAddon2()
        {
            Tick += Initialize;
        }

        private void Initialize(object sender, EventArgs e)
        {
            while (Game.IsLoading)
                Yield();

            LoadConfigValues();
            if (IsUpdateAvailable()) NotifyNewUpdate();

            Tick -= Initialize;
        }

        private void LoadConfigValues()
        {
            if (!Directory.Exists(_configDir))
            {
                Logger.Log("Creating config directory.");
                Directory.CreateDirectory(_configDir);
            }
            if (!File.Exists(_configFile))
            {
                Logger.Log("Creating config file.");
                File.WriteAllText(_configFile, Properties.Resources.config);
            }

            Config = ScriptSettings.Load(_configFile);
            contactIndex = Config.GetValue("General", "StartIndex", 40);
        }

        private bool IsUpdateAvailable()
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

            return false;
        }

        private void NotifyNewUpdate()
        {
            UI.Notify("iFruitAddon2: A new update is available!", true);
        }
    }
}

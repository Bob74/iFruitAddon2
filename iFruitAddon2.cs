using GTA;
using System;
using System.Diagnostics;
using System.IO;

namespace iFruitAddon2
{
    class iFruitAddon2 : Script
    {
        internal static bool IsDebug = false;

        private static bool _initialized = false;
        internal static bool Initialized { get => _initialized; }

        private static readonly string _mainDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "iFruitAddon2");
        private static readonly string _configFile = Path.Combine(_mainDir, "config.ini");

        private static string _tempFilePath;

        private static int contactIndex = 40;
        public static int ContactIndex { get => contactIndex; internal set => contactIndex = value; }

        private static ScriptSettings _config;
        public static ScriptSettings Config { get => _config; private set => _config = value; }

        private static bool _isEnhanced = false;
        public static bool IsEnhanced { get => _isEnhanced; private set => _isEnhanced = value; }


        public iFruitAddon2()
        {
#if DEBUG
            IsDebug = true;
#endif

            Tick += Initialize;
            Aborted += OnAborted;
        }

        internal static string GetTempFilePath()
        {
            if (!Directory.Exists(_mainDir))
            {
                Logger.Debug(_mainDir + " does not exists");
                Logger.Debug("Creating main directory");
                Directory.CreateDirectory(_mainDir);
            }

            // Must be unique for the session but common to all mods adding contacts
            return Path.Combine(_mainDir, Process.GetCurrentProcess().Id.ToString() + ".tmp");
        }

        private void Initialize(object sender, EventArgs e)
        {
            // Reset log file
            Logger.ResetLogFile();

            // Detecting Enhanced version
            _isEnhanced = Process.GetCurrentProcess().ProcessName.ToLower().Contains("enhanced");

            // Removing old temp files (if the game has crashed, the file were not deleted)
            Logger.Debug("Removing old temp files...");
            foreach (string file in Directory.GetFiles(_mainDir, "*.tmp"))
            {
                if (File.Exists(new FileInfo(file).FullName))
                {
                    // Remove old temp file
                    File.Delete(file);
                    Logger.Debug($"Removing {file}");
                }
            }

            // Get the process ID of the game and creating temp file
            Logger.Debug("Getting process ID and creating temp file...");
            FileInfo sessionTmpFileInfo = new FileInfo(GetTempFilePath());
            _tempFilePath = sessionTmpFileInfo.FullName;
            Logger.Debug("Temp file created: " + _tempFilePath);

            Logger.Debug("Begin loading config file...");
            LoadConfigValues();
            Logger.Debug("Config file loaded!");

            _initialized = true;

            Tick -= Initialize;
        }

        private void OnAborted(object sender, EventArgs e)
        {
            Logger.Debug("Closing...");
            if (File.Exists(_tempFilePath))
            {
                Logger.Debug("Removing " + _tempFilePath);
                File.Delete(_tempFilePath);
                Logger.Debug("File removed: " + _tempFilePath);
            }
        }

        private void LoadConfigValues()
        {
            if (!Directory.Exists(_mainDir))
            {
                Logger.Debug("Creating main directory");
                Directory.CreateDirectory(_mainDir);
            }
            if (!File.Exists(_configFile))
            {
                Logger.Debug("Creating config file");
                File.WriteAllText(_configFile, Properties.Resources.config);
            }

            Logger.Debug("Loading config file");
            Config = ScriptSettings.Load(_configFile);

            Logger.Debug("Reading contact index...");
            contactIndex = Config.GetValue("General", "StartIndex", 40);
            Logger.Debug("Contact index: " + contactIndex.ToString());
        }

    }
}

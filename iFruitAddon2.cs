using GTA;
using System;
using System.Diagnostics;
using System.IO;

namespace iFruitAddon2
{
    /// <summary>
    /// iFruitAddon2 main class.
    /// Initialize, load configuration and handle temp files.
    /// </summary>
    class iFruitAddon2 : Script
    {
        /// <summary>
        /// True if debug build. Used for logging debug level.
        /// </summary>
        internal static bool IsDebug = false;

        /// <summary>
        /// True if the script has finished initialisation.
        /// </summary>
        private static bool _initialized = false;
        internal static bool Initialized { get => _initialized; }

        /// <summary>
        /// Full path to the mod directory.
        /// </summary>
        private static readonly string _mainDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "iFruitAddon2");

        /// <summary>
        /// Full path to the mod config file.
        /// </summary>
        private static readonly string _configFile = Path.Combine(_mainDir, "config.ini");

        /// <summary>
        /// Current contact index.
        /// </summary>
        private static int _contactIndex = 40;
        public static int ContactIndex { get => _contactIndex; internal set => _contactIndex = value; }

        /// <summary>
        /// A synchronization object used to ensure thread-safe access to the contact index.
        /// </summary>
        /// <remarks>Prevent index duplication when creating contacts.</remarks>
        private static readonly object _contactIndexLock = new object();

        /// <summary>
        /// Represents the configuration settings for the script.
        /// </summary>
        private static ScriptSettings _config;
        public static ScriptSettings Config { get => _config; private set => _config = value; }

        /// <summary>
        /// Indicates whether the game is running the Enhanced version.
        /// </summary>
        private static bool _isEnhanced = false;
        public static bool IsEnhanced { get => _isEnhanced; private set => _isEnhanced = value; }


        public iFruitAddon2()
        {
#if DEBUG
            IsDebug = true;
#endif
            Logger.ResetLogFile();

            Logger.Debug("Initialization...");

            CheckGameVersion();

            LoadConfigValues();

            Logger.Debug("Initialization successfully completed.");
            _initialized = true;
        }

        /// <summary>
        /// Retrieves the next available contact index and increments the internal counter.
        /// </summary>
        /// <remarks>This method is thread-safe and ensures that the contact index is incremented
        /// atomically. This prevent index duplication across mods using iFruitAddon2.</remarks>
        /// <returns>The next available contact index as an integer.</returns>
        public static int GetNextAvailableContactIndex()
        {
            int result;
            lock (_contactIndexLock)
            {
                result = _contactIndex++;
            }
            return result;
        }

        /// <summary>
        /// Determines whether the current game version is the Enhanced version or the Legacy version.
        /// </summary>
        private void CheckGameVersion()
        {
            try
            {
                Logger.Debug("Detecting Enhanced version...");
                _isEnhanced = Process.GetCurrentProcess().ProcessName.ToLower().Contains("enhanced");
                Logger.Debug($"{(_isEnhanced ? "Enhanced" : "Legacy")} version detected");
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to read GTA V version. Exception : {ex.Message}\n{ex.StackTrace}");
            }
        }

        /// <summary>
        /// Loads configuration values from the specified configuration file.
        /// </summary>
        /// <remarks>This method ensures that the main directory exists and creates a default
        /// configuration file if one is not found.</remarks>
        private void LoadConfigValues()
        {
            try
            {
                // Checks if the directory and files need to be created.
                EnsureMainDirectoryExists();
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to ensure main directory exists. Exception : {ex.Message}\n{ex.StackTrace}");
                return;
            }

            try
            {
                // Ensuring that the config file is loaded. If not, create with default.
                if (!File.Exists(_configFile))
                {
                    File.WriteAllText(_configFile, Properties.Resources.config);
                    Logger.Debug("Config file did not exist; one has been created using defaults.");
                }

                Logger.Debug($"Loading configuration from {_configFile}...");
                Config = ScriptSettings.Load(_configFile);

                // Loading contact Index
                Logger.Debug("Reading contact index...");
                ContactIndex = Config.GetValue<int>("General", "StartIndex", 40);
                Logger.Debug($"Contact index: {ContactIndex}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to load configuration from {_configFile}. Exception : {ex.Message}\n{ex.StackTrace}");
            }
        }

        /// <summary>
        /// Ensures that the main mod directory exists, creating it if necessary.
        /// </summary>
        /// <remarks>If the directory does not exist, it is created.</remarks>
        private void EnsureMainDirectoryExists()
        {
            try
            {
                if (!Directory.Exists(_mainDir))
                {
                    Directory.CreateDirectory(_mainDir);
                    Logger.Debug($"Created directory {_mainDir} due to nonexistence.");
                }
                else
                {
                    Logger.Debug($"Directory {_mainDir} already exists. Skipping creation...");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error ensuring {nameof(_mainDir)} existence: {ex.Message}");
                throw;
            }
        }

    }
}

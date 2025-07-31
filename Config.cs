using GTA;
using System;
using System.IO;

namespace iFruitAddon2
{
    /// <summary>
    /// Loads and manages the configuration settings.
    /// </summary>
    internal class Config
    {
        /// <summary>
        /// Object to hold the configuration settings.
        /// </summary>
        private ScriptSettings _config;

        /// <summary>
        /// Full path to the mod config file.
        /// </summary>
        private static readonly string _configFile = Path.Combine(Tools.GetiFruitAddonDirectory(), "config.ini");

        public Config()
        {
            // Initialize the configuration settings
            LoadConfigFile();
        }

        /// <summary>
        /// Returns the contact start index from the configuration.
        /// It is used to determine where the first contact will be added in the phone.
        /// </summary>
        internal int GetContactStartIndex()
        {
            // Loading contact Index
            Logger.Debug("Reading contact index...");

            // Ensure index is positive
            int _value = Math.Max(_config.GetValue<int>("General", "StartIndex", 40), 0);

            Logger.Debug($"Contact config start index: {_value}");
            return _value;
        }

        /// <summary>
        /// Loads configuration values from the configuration file.
        /// </summary>
        private void LoadConfigFile()
        {
            try
            {
                // Ensure the mod directory exists
                EnsureMainDirectoryExists();

                // Ensuring that the config file is loaded. If not, create with default values.
                if (!File.Exists(_configFile))
                {
                    File.WriteAllText(_configFile, Properties.Resources.config);
                    Logger.Debug("Config file did not exist; one has been created using defaults.");
                }

                Logger.Debug($"Loading configuration from {_configFile}...");
                _config = ScriptSettings.Load(_configFile);
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to load configuration from {_configFile}: {ex.Message}");
            }
        }

        /// <summary>
        /// Ensures that the main mod directory exists, creating it if necessary.
        /// </summary>
        /// <remarks>If the directory does not exist, it is created.</remarks>
        private void EnsureMainDirectoryExists()
        {
            string mainDir = Tools.GetiFruitAddonDirectory();
            try
            {
                if (!Directory.Exists(mainDir))
                {
                    Directory.CreateDirectory(mainDir);
                    Logger.Debug($"Created directory {mainDir} due to nonexistence.");
                }
                else
                {
                    Logger.Debug($"Directory {mainDir} already exists. Skipping creation...");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error ensuring {nameof(mainDir)} existence: {ex.Message}");
                throw;
            }
        }

    }
}

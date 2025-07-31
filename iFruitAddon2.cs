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
        /// Indicates whether the game is running the Enhanced version.
        /// </summary>
        private static bool _isEnhanced = false;
        public static bool IsEnhanced { get => _isEnhanced; private set => _isEnhanced = value; }

        /// <summary>
        /// Config file handler.
        /// </summary>
        private readonly Config _config = new Config();

        public iFruitAddon2()
        {
#if DEBUG
            IsDebug = true;
#endif
            Logger.ResetLogFile();

            Logger.Debug("Initialization...");

            CheckGameVersion();
            ContactIndex = _config.GetContactStartIndex();

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

    }
}

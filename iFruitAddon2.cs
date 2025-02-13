﻿using GTA;
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

        private static int _gamePID;
        internal static int GamePID { get => _gamePID; }

        private static readonly string _mainDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "iFruitAddon2");
        private static readonly string _configFile = Path.Combine(_mainDir, "config.ini");

        private static string _tempFilePath;

        private static int contactIndex = 40;
        public static int ContactIndex { get => contactIndex; internal set => contactIndex = value; }

        private static ScriptSettings _config;
        public static ScriptSettings Config { get => _config; private set => _config = value; }


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
                Logger.Debug("Creating main directory.");
                Directory.CreateDirectory(_mainDir);
            }

            _gamePID = Process.GetProcessesByName("GTA5")[0]?.Id ?? 0;

            return Path.Combine(_mainDir, _gamePID.ToString() + ".tmp");
        }

        private void Initialize(object sender, EventArgs e)
        {
            // Reset log file
            Logger.ResetLogFile();

            // Get the process ID of the game and creating temp file
            FileInfo sessionTmpFileInfo = new FileInfo(GetTempFilePath());
            _tempFilePath = sessionTmpFileInfo.FullName;

            // Removing old temp files (if the game has crashed, the file were not deleted)
            Logger.Debug("Removing old temp files...");
            foreach (string file in Directory.GetFiles(_mainDir, "*.tmp"))
            {
                FileInfo oldTmpFileInfo = new FileInfo(file);

                // If the temp file is not the new one, delete it
                if ((sessionTmpFileInfo.Name != oldTmpFileInfo.Name) && File.Exists(oldTmpFileInfo.FullName))
                {
                    // Remove old temp file
                    File.Delete(file);
                    Logger.Debug($"Removing {oldTmpFileInfo.FullName}");
                }
            }

            Logger.Debug("Waiting for game to be loaded...");
            while (Game.IsLoading)
            {
                Yield();
            }

            Logger.Debug("Waiting for screen to fade...");
            while (GTA.UI.Screen.IsFadingIn)
            {
                Yield();
            }

            Logger.Debug("Loading config file");
            LoadConfigValues();

            _initialized = true;

            Tick -= Initialize;
        }

        private void OnAborted(object sender, EventArgs e)
        {
            if (File.Exists(_tempFilePath))
            {
                File.Delete(_tempFilePath);
            }
        }

        private void LoadConfigValues()
        {
            if (!Directory.Exists(_mainDir))
            {
                Logger.Debug("Creating main directory.");
                Directory.CreateDirectory(_mainDir);
            }
            if (!File.Exists(_configFile))
            {
                Logger.Debug("Creating config file.");
                File.WriteAllText(_configFile, Properties.Resources.config);
            }

            Config = ScriptSettings.Load(_configFile);
            contactIndex = Config.GetValue("General", "StartIndex", 40);
        }

    }
}

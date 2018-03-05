using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using GTA;



/*
    Changelog:
        2.1.0 (...): - Changed the way contact index is stored to allow multiple mods to share the value (it wasn't working as expected).
                            - New contacts font is not bold anymore. It is now the same as native contacts.

        2.0.1 (30/01/2018): - Possible to close the phone (if the contact opens a menu, avoid using controls to navigate in the menu AND in the phone)
                            - At the moment, it is mandatory to close the phone in order to be compatible with RPH

        2.0.0 (28/01/2018): Initial release


    TODO :
    ------
    - Supprimer la notification seulement si elle correspond à CELL_LEFT_SESS
    - Permettre de choisir de mettre le contact en "Bold" (= nom du textureDictionary en minuscule)
    
    X Utiliser Game.GetGXTEntry au lieu de _GET_LABEL_TEXT

    X Gérer les menus NativeUI en parallèle du téléphone => Possibilité de fermer le téléphone quand le script ouvre le menu
    X Ajouter un timer dans la fonction Close() pour éviter d'avoir à gérer ça côté script
    - Téléphone qui se ferme quand on appel (CELL_LEFT_SESS) :
        > Réouvrir le téléphone dans la foulée ?
        > Pour éviter qu'il ne se ferme, il faudrait kill "appcontacts" avant d'appeler mais dans ce cas on ne peut plus se déplacer dans les contacts
        > RPH : Reste ouvert sans icône de contact (appel d'un contact inconnu géré par RPH), impossible de fermer le téléphone sans le détruire et tuer les scripts
    
*/
namespace iFruitAddon2
{
    class iFruitAddon2 : Script
    {
        private static bool _initialized = false;
        internal static bool Initialized { get => _initialized; }

        private static int _gamePID;
        internal static int GamePID { get => _gamePID; }

        private static readonly string _mainDir = AppDomain.CurrentDomain.BaseDirectory + "\\iFruitAddon2";
        private static string _configFile = _mainDir + "\\config.ini";

        private static string _tempFilePath;

        private static int contactIndex = 40;
        public static int ContactIndex { get => contactIndex; internal set => contactIndex = value; }

        private static ScriptSettings _config;
        public static ScriptSettings Config { get => _config; private set => _config = value; }

        private bool CheckForUpdates = true;


        public iFruitAddon2()
        {
            Tick += Initialize;
        }

        public static string GetTempFilePath()
        {
            if (!Directory.Exists(_mainDir))
            {
                Logger.Log("Creating main directory.");
                Directory.CreateDirectory(_mainDir);
            }

            _gamePID = Process.GetProcessesByName("GTA5")[0]?.Id ?? 0;
            return _mainDir + "\\" + _gamePID.ToString() + ".tmp";
        }

        private void Initialize(object sender, EventArgs e)
        {
            // Get the process ID of the game and creating temp file
            _tempFilePath = GetTempFilePath();

            // Removing old temp files (if the game has crashed, the file were not deleted)
            foreach (string file in Directory.GetFiles(_mainDir, "*.tmp"))
            {
                FileInfo tempFileInfo = new FileInfo(_tempFilePath), fileInfo = new FileInfo(file);
                if ((tempFileInfo.Name != fileInfo.Name) && File.Exists(file))
                {
                    // Reset log file
                    Logger.ResetLogFile();

                    // Remove old temp file
                    File.Delete(file);
                }
            }

            while (Game.IsLoading)
                Yield();

            LoadConfigValues();
            if (CheckForUpdates)
                if (IsUpdateAvailable()) NotifyNewUpdate();

            _initialized = true;

            Tick -= Initialize;
        }

        // Dispose Event
        protected override void Dispose(bool A_0)
        {
            if (A_0)
            {
                if (File.Exists(_tempFilePath))
                    File.Delete(_tempFilePath);
            }
        }

        private void LoadConfigValues()
        {
            if (!Directory.Exists(_mainDir))
            {
                Logger.Log("Creating main directory.");
                Directory.CreateDirectory(_mainDir);
            }
            if (!File.Exists(_configFile))
            {
                Logger.Log("Creating config file.");
                File.WriteAllText(_configFile, Properties.Resources.config);
            }

            Config = ScriptSettings.Load(_configFile);
            contactIndex = Config.GetValue("General", "StartIndex", 40);
            CheckForUpdates = Config.GetValue("General", "CheckForUpdates", true);
        }

        private bool IsUpdateAvailable()
        {
            string downloadedString = "";
            Version onlineVersion;

            try
            {
                WebClient client = new WebClient();
                downloadedString = client.DownloadString("https://raw.githubusercontent.com/Bob74/iFruitAddon2/master/version");

                downloadedString = downloadedString.Replace("\r", "");
                downloadedString = downloadedString.Replace("\n", "");

                onlineVersion = new Version(downloadedString);

                client.Dispose();

                if (onlineVersion.CompareTo(Assembly.GetExecutingAssembly().GetName().Version) > 0)
                    return true;
                else
                    return false;
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

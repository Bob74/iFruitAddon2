using System;
using System.IO;
using System.Net;

using GTA;



/*
    Changelog:
        2.0.1 (30/01/2018): - Possible to close the phone (if the contact opens a menu, avoid using controls to navigate in the menu AND in the phone)
                            - At the moment, it is mandatory to close the phone in order to be compatible with RPH

        2.0.0 (28/01/2018): Initial release


    TODO :
    ------
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
        private static string version = "2.0.1"; // ! A CHANGER AUSSI DANS ASSEMBLY !

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

                client.Dispose();

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

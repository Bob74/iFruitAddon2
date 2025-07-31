using GTA;
using GTA.Native;
using System.Drawing;

namespace iFruitAddon2
{
    /// <summary>
    /// Represents the set of icons that can be displayed on a soft key.
    /// </summary>
    /// <remarks>
    /// Each value corresponds to a predefined icon, such as "Select", "Back", or "Call".
    /// </remarks>
    public enum SoftKeyIcon
    {
        /// <summary>
        /// Blank icon, no icon displayed.
        /// </summary>
        Blank = 1,
        /// <summary>
        /// +
        /// </summary>
        Select = 2,
        /// <summary>
        /// ●○
        /// </summary>
        Pages = 3,
        /// <summary>
        /// ←
        /// </summary>
        Back = 4,
        /// <summary>
        /// Phone icon.
        /// </summary>
        Call = 5,
        /// <summary>
        /// Hanged up phone icon.
        /// </summary>
        Hangup = 6,
        /// <summary>
        /// User hanged up phone icon.
        /// </summary>
        HangupHuman = 7,
        /// <summary>
        /// Hanging up phone icon.
        /// </summary>
        Week = 8,
        /// <summary>
        /// 9 dots grid icon.
        /// </summary>
        Keypad = 9,
        /// <summary>
        /// Opened letter icon.
        /// </summary>
        Open = 10,
        /// <summary>
        /// Opened letter with right arrow icon.
        /// </summary>
        Reply = 11,
        /// <summary>
        /// Trash icon.
        /// </summary>
        Delete = 12,
        /// <summary>
        /// Ok checkmark icon.
        /// </summary>
        Yes = 13,
        /// <summary>
        /// Cross mark icon.
        /// </summary>
        No = 14,
        /// <summary>
        /// ↓≡
        /// </summary>
        Sort = 15,
        /// <summary>
        /// World Wide Web icon.
        /// </summary>
        Website = 16,
        /// <summary>
        /// Star icon.
        /// </summary>
        Police = 17,
        /// <summary>
        /// Emergency star symbol.
        /// </summary>
        Ambulance = 18,
        /// <summary>
        /// Fire icon.
        /// </summary>
        Fire = 19,
        /// <summary>
        /// ○●
        /// </summary>
        Pages2 = 20
    }

    /// <summary>
    /// Event triggered when a contact has answered the phone.
    /// </summary>
    public delegate void ContactAnsweredEvent(iFruitContact contact);

    /// <summary>
    /// This class is used to manage the iFruit phone and contacts.
    /// </summary>
    public class CustomiFruit
    {
        internal static CustomiFruit Instance = null;
        private bool _shouldDraw = true;
        private PhoneImage _wallpaper;
        private iFruitContactCollection _contacts;
        private int _timerClose = -1;

        /// <summary>
        /// Left Button Color
        /// </summary>
        public Color LeftButtonColor { get; set; } = Color.Empty;

        /// <summary>
        /// Center Button Color
        /// </summary>
        public Color CenterButtonColor { get; set; } = Color.Empty;

        /// <summary>
        /// Right Button Color
        /// </summary>
        public Color RightButtonColor { get; set; } = Color.Empty;

        /// <summary>
        /// Left Button Icon
        /// </summary>
        public SoftKeyIcon LeftButtonIcon { get; set; } = SoftKeyIcon.Blank;

        /// <summary>
        /// Center Button Icon
        /// </summary>
        public SoftKeyIcon CenterButtonIcon { get; set; } = SoftKeyIcon.Blank;

        /// <summary>
        /// Right Button Icon
        /// </summary>
        public SoftKeyIcon RightButtonIcon { get; set; } = SoftKeyIcon.Blank;

        /// <summary>
        /// List of custom contacts in the phone
        /// </summary>
        public iFruitContactCollection Contacts
        {
            get { return _contacts; }
            set { _contacts = value; }
        }

        /// <summary>
        /// Initialize the class with an empty contact collection.
        /// </summary>
        public CustomiFruit() : this(new iFruitContactCollection())
        { }

        /// <summary>
        /// Initialize the class.
        /// </summary>
        /// <param name="contacts">Contact collection to initialize the phone with</param>
        public CustomiFruit(iFruitContactCollection contacts)
        {
            Instance = this;
            _contacts = contacts;
            Logger.Debug("CustomiFruit initialized with a contact collection containing " + contacts.Count + " contacts.");
        }

        /// <summary>
        /// Handle of the current scaleform.
        /// </summary>
        public int Handle
        {
            get
            {
                Scaleform currentPhoneScaleform = PhoneScript.GetCurrentScaleform();
                return currentPhoneScaleform.Handle;
            }
        }

        /// <summary>
        /// Set text displayed at the top of the phone interface. Must be called every update!
        /// </summary>
        /// <param name="text">Text to display</param>
        public void SetTextHeader(string text)
        {
            Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Handle, "SET_HEADER");
            Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "STRING");
            Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PHONE_NUMBER, text, -1);
            Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
            Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
        }

        /// <summary>
        /// Set icon of the soft key buttons directly. Must be called every update!
        /// </summary>
        /// <param name="buttonID">The button index</param>
        /// <param name="icon">Supplied icon</param>
        public void SetSoftKeyIcon(int buttonID, SoftKeyIcon icon)
        {
            PhoneScript.GetCurrentScaleform().CallFunction("SET_SOFT_KEYS", buttonID, true, (int)icon);
        }

        /// <summary>
        /// Set the color of the soft key buttons directly.
        /// </summary>
        /// <param name="buttonID">The button index</param>
        /// <param name="color">Supplied color</param>
        public void SetSoftKeyColor(int buttonID, Color color)
        {
            PhoneScript.GetCurrentScaleform().CallFunction("SET_SOFT_KEYS_COLOUR", buttonID, (int)color.R, (int)color.G, (int)color.B);
        }

        internal void SetWallpaperTXD(string textureDict)
        {
            Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Handle, "SET_BACKGROUND_CREW_IMAGE");
            Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "CELL_2000");
            Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, textureDict);
            Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
            Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
        }

        /// <summary>
        /// Set the wallpaper of the phone.
        /// </summary>
        /// <param name="phoneImage">Any PhoneImage</param>
        public void SetWallpaper(PhoneImage phoneImage)
        {
            _wallpaper = phoneImage;
        }

        /// <summary>
        /// Set the wallpaper of the phone by loading a texture dictionary.
        /// </summary>
        public void SetWallpaper(string textureDict)
        {
            _wallpaper = new Wallpaper(textureDict);
        }

        /// <summary>
        /// Update the phone UI and contacts calling.
        /// </summary>
        public void Update()
        {
            if (Function.Call<int>(Hash.GET_NUMBER_OF_THREADS_RUNNING_THE_SCRIPT_WITH_THIS_HASH, PhoneScript.CellphoneHandHash) > 0)
            {
                // Must always be called when the phone is on screen
                if (LeftButtonIcon != SoftKeyIcon.Blank) SetSoftKeyIcon(1, LeftButtonIcon);
                if (CenterButtonIcon != SoftKeyIcon.Blank) SetSoftKeyIcon(2, CenterButtonIcon);
                if (RightButtonIcon != SoftKeyIcon.Blank) SetSoftKeyIcon(3, RightButtonIcon);

                // Need to be called once when phone is on screen
                if (_shouldDraw)
                {
                    Script.Wait(0);
                    if (_wallpaper != null) SetWallpaperTXD(_wallpaper.Name);
                    if (LeftButtonColor != Color.Empty) SetSoftKeyColor(1, LeftButtonColor);
                    if (CenterButtonColor != Color.Empty) SetSoftKeyColor(2, CenterButtonColor);
                    if (RightButtonColor != Color.Empty) SetSoftKeyColor(3, RightButtonColor);

                    _shouldDraw = !_shouldDraw;
                }
            }
            else
            {
                // When the phone is closed, we set the next time it opens to draw custom elements
                _shouldDraw = true;
            }

            if (_timerClose != -1)
            {
                if (_timerClose <= Game.GameTime)
                {
                    Close();
                    _timerClose = -1;
                }
            }

            _contacts.Update(Handle);
        }

        /// <summary>
        /// Closes the phone.
        /// </summary>
        /// <param name="timer">Thread safe timer waiting before closing the phone. Time in ms.</param>
        public void Close(int timer = 0)
        {
            if (timer == 0)
            {
                Close();
            }
            else
            {
                _timerClose = Game.GameTime + timer;
            }
        }

        /// <summary>
        /// Closes the phone immediately.
        /// </summary>
        private void Close()
        {
            if (Function.Call<int>(Hash.GET_NUMBER_OF_THREADS_RUNNING_THE_SCRIPT_WITH_THIS_HASH, PhoneScript.CellphoneHandHash) > 0)
            {
                PhoneScript.GetCurrentScaleform().CallFunction("SHUTDOWN_MOVIE");

                Script.Yield();

                Tools.Scripts.DestroyPhone(Handle);
                Tools.Scripts.TerminateScript("cellphone_flashhand");
                Tools.Scripts.TerminateScript("cellphone_controller");

                Script.Yield();

                Tools.Scripts.StartScript("cellphone_flashhand", 1424);
                Tools.Scripts.StartScript("cellphone_controller", 1424);
            }
        }

    }
}

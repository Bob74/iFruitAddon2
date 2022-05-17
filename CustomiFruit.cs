using System.Drawing;
using System.Collections.Generic;

using GTA;
using GTA.Native;

namespace iFruitAddon2
{
    public enum SoftKeyIcon
    {
        Blank = 1,
        Select = 2,
        Pages = 3,
        Back = 4,
        Call = 5,
        Hangup = 6,
        HangupHuman = 7,
        Week = 8,
        Keypad = 9,
        Open = 10,
        Reply = 11,
        Delete = 12,
        Yes = 13,
        No = 14,
        Sort = 15,
        Website = 16,
        Police = 17,
        Ambulance = 18,
        Fire = 19,
        Pages2 = 20
    }

    //public delegate void ContactSelectedEvent(iFruitContactCollection sender, iFruitContact selectedItem);
    public delegate void ContactAnsweredEvent(iFruitContact contact);

    public class CustomiFruit
    {
        internal static CustomiFruit Instance = null;
        private bool _shouldDraw = true;
        private PhoneImage _wallpaper;
        private iFruitContactCollection _contacts;
        private readonly int _mScriptHash;
        private int _timerClose = -1;
        internal Scaleform CellphoneScaleform = null;

        private readonly Dictionary<uint, string> _characterScaleformDict = new Dictionary<uint, string>() {
            { (uint)PedHash.Michael, "cellphone_ifruit" },
            { (uint)PedHash.Franklin, "cellphone_badger" },
            { (uint)PedHash.Trevor, "cellphone_facade" }
        };

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

        public CustomiFruit() : this(new iFruitContactCollection())
        { }

        /// <summary>
        /// Initialize the class.
        /// </summary>
        /// <param name="contacts"></param>
        public CustomiFruit(iFruitContactCollection contacts)
        {
            Instance = this;
            _contacts = contacts;
            _mScriptHash = Game.GenerateHash("cellphone_flashhand");
        }

        /// <summary>
        /// Handle of the current scaleform.
        /// </summary>
        public int Handle
        {
            get
            {
                // If the scaleform is null, create it.
                if (CellphoneScaleform == null)
                {
                    if (_characterScaleformDict.ContainsKey((uint)Game.Player.Character.Model.Hash))
                    {
                        CellphoneScaleform = new Scaleform(_characterScaleformDict[(uint)Game.Player.Character.Model.Hash]);
                    }
                    else
                    {
                        CellphoneScaleform = new Scaleform("cellphone_ifruit");
                    }
                }
                return CellphoneScaleform.Handle;
            }
        }

        /// <summary>
        /// Set text displayed at the top of the phone interface. Must be called every update!
        /// </summary>
        /// <param name="text"></param>
        public void SetTextHeader(string text)
        {
            Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Handle, "SET_HEADER");
            Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "STRING");
            Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PHONE_NUMBER, text, -1);
            Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
            Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
        }

        /// <summary>
        /// Set icon of the soft key buttons directly.
        /// </summary>
        /// <param name="buttonID">The button index</param>
        /// <param name="icon">Supplied icon</param>
        public void SetSoftKeyIcon(int buttonID, SoftKeyIcon icon)
        {
            CellphoneScaleform.CallFunction("SET_SOFT_KEYS", buttonID, true, (int)icon);
        }

        /// <summary>
        /// Set the color of the soft key buttons directly.
        /// </summary>
        /// <param name="buttonID">The button index</param>
        /// <param name="color">Supplied color</param>
        public void SetSoftKeyColor(int buttonID, Color color)
        {
            CellphoneScaleform.CallFunction("SET_SOFT_KEYS_COLOUR", buttonID, color.R, color.G, color.B);
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
        /// <param name="wallpaper"></param>
        public void SetWallpaper(Wallpaper wallpaper)
        {
            _wallpaper = wallpaper;
        }
        public void SetWallpaper(ContactIcon icon)
        {
            _wallpaper = icon;
        }
        public void SetWallpaper(string textureDict)
        {
            _wallpaper = new Wallpaper(textureDict);
        }

        public void Update()
        {
            if (Function.Call<int>(Hash._GET_NUMBER_OF_REFERENCES_OF_SCRIPT_WITH_NAME_HASH, _mScriptHash) > 0)
            {
                if (_shouldDraw)
                {
                    //Script.Wait(0);

                    if (LeftButtonColor != Color.Empty) SetSoftKeyColor(1, LeftButtonColor);
                    if (CenterButtonColor != Color.Empty) SetSoftKeyColor(2, CenterButtonColor);
                    if (RightButtonColor != Color.Empty) SetSoftKeyColor(3, RightButtonColor);

                    //Script.Wait(0);

                    if (LeftButtonIcon != SoftKeyIcon.Blank) SetSoftKeyIcon(1, LeftButtonIcon);
                    if (CenterButtonIcon != SoftKeyIcon.Blank) SetSoftKeyIcon(2, CenterButtonIcon);
                    if (RightButtonIcon != SoftKeyIcon.Blank) SetSoftKeyIcon(3, RightButtonIcon);
                    
                    if (_wallpaper != null) SetWallpaperTXD(_wallpaper.Name);

                    _shouldDraw = !_shouldDraw;
                }  
            }
            else
            {
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
        private void Close()
        {
            if (Function.Call<int>(Hash._GET_NUMBER_OF_REFERENCES_OF_SCRIPT_WITH_NAME_HASH, _mScriptHash) > 0)
            {
                CellphoneScaleform.CallFunction("SHUTDOWN_MOVIE");

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

using System.Drawing;

using GTA;
using GTA.Native;

namespace iFruitAddon2
{
    //public delegate void ContactSelectedEvent(iFruitContactCollection sender, iFruitContact selectedItem);
    public delegate void ContactAnsweredEvent(iFruitContact contact);

    public class CustomiFruit
    {
        private static CustomiFruit _instance;
        private bool _shouldDraw = true;
        private PhoneImage _wallpaper;
        private iFruitContactCollection _contacts;
        private int _mScriptHash;
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

        public CustomiFruit() : this(new iFruitContactCollection())
        { }

        /// <summary>
        /// Initialize the class.
        /// </summary>
        /// <param name="contacts"></param>
        public CustomiFruit(iFruitContactCollection contacts)
        {
            _instance = this;
            _contacts = contacts;
            _mScriptHash = Game.GenerateHash("cellphone_flashhand");
        }

        /// <summary>
        /// Handle of the current scaleform.
        /// </summary>
        public static CustomiFruit GetCurrentInstance() { return _instance; }
        public int Handle
        {
            get
            {
                int h = 0;
                switch ((uint)Game.Player.Character.Model.Hash)
                {
                    case (uint)PedHash.Michael:
                        h = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "cellphone_ifruit");
                        while (!Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, h))
                            Script.Yield();
                        return h;
                    case (uint)PedHash.Franklin:
                        h = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "cellphone_badger");
                        while (!Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, h))
                            Script.Yield();
                        return h;
                    case (uint)PedHash.Trevor:
                        h = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "cellphone_facade");
                        while (!Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, h))
                            Script.Yield();
                        return h;
                    default:
                        h = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, "cellphone_ifruit");
                        while (!Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, h))
                            Script.Yield();
                        return h;
                }
            }
        }

        /// <summary>
        /// Set text displayed at the top of the phone interface. Must be called every update!
        /// </summary>
        /// <param name="text"></param>
        public void SetTextHeader(string text)
        {
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, Handle, "SET_HEADER");
            Function.Call(Hash._BEGIN_TEXT_COMPONENT, "STRING");
            Function.Call(Hash._0x761B77454205A61D, text, -1);
            Function.Call(Hash._END_TEXT_COMPONENT);
            Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);
        }

        /// <summary>
        /// Set icon of the soft key buttons directly.
        /// </summary>
        /// <param name="buttonID">The button index</param>
        /// <param name="icon">Supplied icon</param>
        public void SetSoftKeyIcon(int buttonID, SoftKeyIcon icon)
        {
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, Handle, "SET_SOFT_KEYS");
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, buttonID);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_BOOL, true);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, (int)icon);
            Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);
        }

        /// <summary>
        /// Set the color of the soft key buttons directly.
        /// </summary>
        /// <param name="buttonID">The button index</param>
        /// <param name="color">Supplied color</param>
        public void SetSoftKeyColor(int buttonID, Color color)
        {
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, Handle, "SET_SOFT_KEYS_COLOUR");
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, buttonID);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, color.R);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, color.G);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, color.B);
            Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);
        }

        internal void SetWallpaperTXD(string textureDict)
        {
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, Handle, "SET_BACKGROUND_CREW_IMAGE");
            Function.Call(Hash._BEGIN_TEXT_COMPONENT, "CELL_2000");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, textureDict);
            Function.Call(Hash._END_TEXT_COMPONENT);
            Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);
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
            if (Function.Call<int>(Hash._GET_NUMBER_OF_INSTANCES_OF_STREAMED_SCRIPT, _mScriptHash) > 0)
            {
                if (_shouldDraw)
                {
                    //Script.Wait(0);

                    if (LeftButtonColor != Color.Empty)
                        SetSoftKeyColor(1, LeftButtonColor);
                    if (CenterButtonColor != Color.Empty)
                        SetSoftKeyColor(2, CenterButtonColor);
                    if (RightButtonColor != Color.Empty)
                        SetSoftKeyColor(3, RightButtonColor);

                    //Script.Wait(0);

                    if (LeftButtonIcon != SoftKeyIcon.Blank)
                        SetSoftKeyIcon(1, LeftButtonIcon);
                    if (CenterButtonIcon != SoftKeyIcon.Blank)
                        SetSoftKeyIcon(2, CenterButtonIcon);
                    if (RightButtonIcon != SoftKeyIcon.Blank)
                        SetSoftKeyIcon(3, RightButtonIcon);

                    if (_wallpaper != null)
                        SetWallpaperTXD(_wallpaper.Name);

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
                Close();
            else
                _timerClose = Game.GameTime + timer;
        }
        private void Close()
        {
            if (Function.Call<int>(Hash._GET_NUMBER_OF_INSTANCES_OF_STREAMED_SCRIPT, _mScriptHash) > 0)
            {
                Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, Handle, "SHUTDOWN_MOVIE");
                Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);

                Script.Yield();

                //Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, CustomiFruit.GetCurrentInstance().Handle);
                Tools.Scripts.DestroyPhone(Handle);
                Tools.Scripts.TerminateScript("cellphone_flashhand");
                Tools.Scripts.TerminateScript("cellphone_controller");

                Script.Yield();

                Tools.Scripts.StartScript("cellphone_flashhand", 1424);
                Tools.Scripts.StartScript("cellphone_controller", 1424);
            }
        }

    }


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
}


namespace iFruitAddon
{
    public sealed class Wallpaper : PhoneImage
    {
        /// <summary>
        /// Initialize the class.
        /// </summary>
        /// <param name="txd"></param>
        public Wallpaper(string txd) : base(txd)
        { }

        public static Wallpaper iFruitDefault { get { return new Wallpaper("Phone_Wallpaper_ifruitdefault"); } }
        public static Wallpaper BadgerDefault { get { return new Wallpaper("Phone_Wallpaper_badgerdefault"); } }
        public static Wallpaper Bittersweet { get { return new Wallpaper("Phone_Wallpaper_bittersweet_b"); } }
        public static Wallpaper PurpleGlow { get { return new Wallpaper("Phone_Wallpaper_purpleglow"); } }
        public static Wallpaper GreenSquares { get { return new Wallpaper("Phone_Wallpaper_greensquares"); } }
        public static Wallpaper OrangeHerringBone { get { return new Wallpaper("Phone_Wallpaper_orangeherringbone"); } }
        public static Wallpaper OrangeHalftone { get { return new Wallpaper("Phone_Wallpaper_orangehalftone"); } }
        public static Wallpaper GreenTriangles { get { return new Wallpaper("Phone_Wallpaper_greentriangles"); } }
        public static Wallpaper GreenShards { get { return new Wallpaper("Phone_Wallpaper_greenshards"); } }
        public static Wallpaper BlueAngles { get { return new Wallpaper("Phone_Wallpaper_blueangles"); } }
        public static Wallpaper BlueShards { get { return new Wallpaper("Phone_Wallpaper_blueshards"); } }
        public static Wallpaper BlueTriangles { get { return new Wallpaper("Phone_Wallpaper_bluetriangles"); } }
        public static Wallpaper BlueCircles { get { return new Wallpaper("Phone_Wallpaper_bluecircles"); } }
        public static Wallpaper Diamonds { get { return new Wallpaper("Phone_Wallpaper_diamonds"); } }
        public static Wallpaper GreenGlow { get { return new Wallpaper("Phone_Wallpaper_greenglow"); } }
        public static Wallpaper Orange8Bit { get { return new Wallpaper("Phone_Wallpaper_orange8bit"); } }    
        public static Wallpaper OrangeTriangles { get { return new Wallpaper("Phone_Wallpaper_orangetriangles"); } }
        public static Wallpaper PurpleTartan { get { return new Wallpaper("Phone_Wallpaper_purpletartan"); } }
    }
}

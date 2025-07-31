
namespace iFruitAddon2
{
    /// <summary>
    /// Phone Wallpaper class.
    /// </summary>
    public sealed class Wallpaper : PhoneImage
    {
        /// <summary>
        /// Initialize the class.
        /// </summary>
        /// <param name="txd"></param>
        public Wallpaper(string txd) : base(txd)
        { }

        /// <summary>iFruitDefault</summary>
        public static Wallpaper iFruitDefault { get { return new Wallpaper("Phone_Wallpaper_ifruitdefault"); } }
        /// <summary>BadgerDefault</summary>
        public static Wallpaper BadgerDefault { get { return new Wallpaper("Phone_Wallpaper_badgerdefault"); } }
        /// <summary>Bittersweet</summary>
        public static Wallpaper Bittersweet { get { return new Wallpaper("Phone_Wallpaper_bittersweet_b"); } }
        /// <summary>PurpleGlow</summary>
        public static Wallpaper PurpleGlow { get { return new Wallpaper("Phone_Wallpaper_purpleglow"); } }
        /// <summary>GreenSquares</summary>
        public static Wallpaper GreenSquares { get { return new Wallpaper("Phone_Wallpaper_greensquares"); } }
        /// <summary>OrangeHerringBone</summary>
        public static Wallpaper OrangeHerringBone { get { return new Wallpaper("Phone_Wallpaper_orangeherringbone"); } }
        /// <summary>OrangeHalftone</summary>
        public static Wallpaper OrangeHalftone { get { return new Wallpaper("Phone_Wallpaper_orangehalftone"); } }
        /// <summary>OrangeTriangles</summary>
        public static Wallpaper GreenTriangles { get { return new Wallpaper("Phone_Wallpaper_greentriangles"); } }
        /// <summary>GreenShards</summary>
        public static Wallpaper GreenShards { get { return new Wallpaper("Phone_Wallpaper_greenshards"); } }
        /// <summary>BlueAngles</summary>
        public static Wallpaper BlueAngles { get { return new Wallpaper("Phone_Wallpaper_blueangles"); } }
        /// <summary>BlueShards</summary>
        public static Wallpaper BlueShards { get { return new Wallpaper("Phone_Wallpaper_blueshards"); } }
        /// <summary>BlueTriangles</summary>
        public static Wallpaper BlueTriangles { get { return new Wallpaper("Phone_Wallpaper_bluetriangles"); } }
        /// <summary>BlueCircles</summary>
        public static Wallpaper BlueCircles { get { return new Wallpaper("Phone_Wallpaper_bluecircles"); } }
        /// <summary>Diamonds</summary>
        public static Wallpaper Diamonds { get { return new Wallpaper("Phone_Wallpaper_diamonds"); } }
        /// <summary>GreenGlow</summary>
        public static Wallpaper GreenGlow { get { return new Wallpaper("Phone_Wallpaper_greenglow"); } }
        /// <summary>Orange8Bit</summary>
        public static Wallpaper Orange8Bit { get { return new Wallpaper("Phone_Wallpaper_orange8bit"); } }
        /// <summary>OrangeTriangles</summary>
        public static Wallpaper OrangeTriangles { get { return new Wallpaper("Phone_Wallpaper_orangetriangles"); } }
        /// <summary>PurpleTartan</summary>
        public static Wallpaper PurpleTartan { get { return new Wallpaper("Phone_Wallpaper_purpletartan"); } }
    }
}

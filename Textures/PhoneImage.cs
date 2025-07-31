
using GTA.Native;

namespace iFruitAddon2
{
    /// <summary>
    /// Represents a phone image asset (ie: contact icon, wallpaper, ...).
    /// </summary>
    public abstract class PhoneImage
    {
        /// <summary>
        /// Name of the image asset
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Initialize the class.
        /// </summary>
        /// <param name="name">Name of the texture dictionary.</param>
        public PhoneImage(string name)
        {
            LoadTextureDict(name);
            Name = name;
        }

        /// <summary>
        /// Load a texture dictionary by name.
        /// </summary>
        /// <param name="txd">Name of the texture dictionary.</param>
        private void LoadTextureDict(string txd)
        {
            if (!Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, txd))
                Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, txd, 0);
        }
    }
}

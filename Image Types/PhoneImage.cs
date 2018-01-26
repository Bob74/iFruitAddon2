
using GTA.Native;

namespace iFruitAddon
{
    public abstract class PhoneImage
    {
        /// <summary>
        /// Name of the image asset
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Initialize the class.
        /// </summary>
        /// <param name="name"></param>
        public PhoneImage(string name)
        {
            LoadTextureDict(name);
            Name = name;
        }

        /// <summary>
        /// Load a texture dictionary by name.
        /// </summary>
        /// <param name="txd"></param>
        private void LoadTextureDict(string txd)
        {
            if (!Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, txd))
                Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, txd, 0);
        }
    }
}

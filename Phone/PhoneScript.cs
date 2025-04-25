using GTA;
using System.Collections.Generic;

namespace iFruitAddon2
{
    internal static class PhoneScript
    {
        public static readonly int CellphoneHandHash = Game.GenerateHash("cellphone_flashhand");

        private static readonly Dictionary<PedHash, string> _characterScaleformDict = new Dictionary<PedHash, string>() {
            { PedHash.Michael, "cellphone_ifruit" },
            { PedHash.Franklin, "cellphone_badger" },
            { PedHash.Trevor, "cellphone_facade" }
        };

        internal static Scaleform GetCurrentScaleform()
        {
            Scaleform currentPhoneScaleform;
            PedHash currentPlayerHash = PedHash.Michael;

            currentPlayerHash = iFruitAddon2.IsEnhanced ? Tools.Game.GetPlayerPedModelHash() : (PedHash)Game.Player.Character.Model.Hash;

            if (_characterScaleformDict.ContainsKey(currentPlayerHash))
            {
                currentPhoneScaleform = new Scaleform(_characterScaleformDict[currentPlayerHash]);
            }
            else
            {
                currentPhoneScaleform = new Scaleform(_characterScaleformDict[PedHash.Michael]);
            }
            while (!currentPhoneScaleform.IsLoaded) Script.Yield();

            return currentPhoneScaleform;
        }

    }
}

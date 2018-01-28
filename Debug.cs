#if DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GTA;
using GTA.Native;

namespace iFruitAddon2
{
    static class Debug
    {
        public static void DrawText(string text, int font, bool centre, float x, float y, float scale, int r, int g, int b, int a)
        {
            Function.Call(Hash.SET_TEXT_FONT, font);
            Function.Call(Hash.SET_TEXT_PROPORTIONAL, 0);
            Function.Call(Hash.SET_TEXT_SCALE, scale, scale);
            Function.Call(Hash.SET_TEXT_COLOUR, r, g, b, a);
            Function.Call(Hash.SET_TEXT_DROPSHADOW, 0, 0, 0, 0, 255);
            Function.Call(Hash.SET_TEXT_EDGE, 1, 0, 0, 0, 255);
            Function.Call(Hash.SET_TEXT_DROP_SHADOW);
            Function.Call(Hash.SET_TEXT_OUTLINE);
            Function.Call(Hash.SET_TEXT_CENTRE, centre);
            Function.Call(Hash._SET_TEXT_ENTRY, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, text);
            Function.Call(Hash._DRAW_TEXT, x, y);
        }

        public static void DestroyPhone(int handle)
        {
            Function.Call(Hash.DESTROY_MOBILE_PHONE, handle);
        }

        public static void StartScript(string scriptName)
        {
            Function.Call(Hash.REQUEST_SCRIPT, scriptName);

            while (!Function.Call<bool>(Hash.HAS_SCRIPT_LOADED, scriptName))
            {
                Function.Call(Hash.REQUEST_SCRIPT, scriptName);
                Script.Yield();
            }

            Function.Call(Hash.START_NEW_SCRIPT, scriptName, 3800);
            Function.Call(Hash.SET_SCRIPT_AS_NO_LONGER_NEEDED, scriptName);
        }

        public static void TerminateScript(string scriptName)
        {
            Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, scriptName);
        }


    }
}
#endif
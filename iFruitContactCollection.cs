using System.Collections.Generic;

using GTA.Native;
using GTA;

namespace iFruitAddon2
{
    public class iFruitContactCollection : List<iFruitContact>
    {
        public static int _currentIndex = 40;
        private bool _shouldDraw = true;
        private int _mScriptHash;

        public iFruitContactCollection()
        {
            _mScriptHash = Game.GenerateHash("appcontacts");
        }

        
        internal void Update(int handle)
        {
            int _selectedIndex = 0;

            // If we are in the Contacts menu
            if (Function.Call<int>(Hash._GET_NUMBER_OF_INSTANCES_OF_STREAMED_SCRIPT, _mScriptHash) > 0)
            {
                _shouldDraw = true;

                if (Game.IsControlPressed(2, Control.PhoneSelect))
                    _selectedIndex = GetSelectedIndex(handle);  // We must use this function only when necessary since it contains Script.Wait(0)
            }
            else
                _selectedIndex = -1;

            // Browsing every added contacts
            foreach (iFruitContact contact in this)
            {
                contact.Update(); // Update sounds or Answer call when _callTimer has ended.

                if (_shouldDraw)
                    contact.Draw(handle);

                if (_selectedIndex != -1 && _selectedIndex == contact.Index)
                {
                    // Prevent original contact to be called
                    Tools.Scripts.TerminateScript("appcontacts");

                    contact.Call();
                    DisplayCallUI(handle, contact.Name, "CELL_211" ,contact.Icon.Name);

                    Script.Wait(10);
                    
                    RemoveActiveNotification();
                    
                }

            }
            _shouldDraw = false;
        }
       

        /// <summary>
        /// Display the current call on the phone.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="contactName"></param>
        /// <param name="statusText">CELL_211 = "DIALING..." / CELL_219 = "CONNECTED"</param>
        /// <param name="picName"></param>
        public static void DisplayCallUI(int handle, string contactName, string statusText = "CELL_211", string picName = "CELL_300")
        {
            string dialText = Function.Call<string>(Hash._GET_LABEL_TEXT, statusText); // "DIALING..." translated in current game's language
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, handle, "SET_DATA_SLOT");
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, 4);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, 0);
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, 3);

            Function.Call(Hash._BEGIN_TEXT_COMPONENT, "STRING");
            Function.Call(Hash._0x761B77454205A61D, contactName, -1);       //UI::_ADD_TEXT_COMPONENT_APP_TITLE
            Function.Call(Hash._END_TEXT_COMPONENT);

            Function.Call(Hash._BEGIN_TEXT_COMPONENT, "CELL_2000");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, picName);
            Function.Call(Hash._END_TEXT_COMPONENT);

            Function.Call(Hash._BEGIN_TEXT_COMPONENT, "STRING");
            Function.Call(Hash._0x761B77454205A61D, dialText, -1);      //UI::_ADD_TEXT_COMPONENT_APP_TITLE
            Function.Call(Hash._END_TEXT_COMPONENT);

            Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);

            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, handle, "DISPLAY_VIEW");
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, 4);
            Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID);
        }

        /// <summary>
        /// Get the index of the current highlighted contact.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal int GetSelectedIndex(int handle)
        {
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, handle, "GET_CURRENT_SELECTION");
            int num = Function.Call<int>(Hash._POP_SCALEFORM_MOVIE_FUNCTION);
            while (!Function.Call<bool>(Hash._0x768FF8961BA904D6, num))         //UI::_GET_SCALEFORM_MOVIE_FUNCTION_RETURN_BOOL
                Script.Wait(0);
            int data = Function.Call<int>(Hash._0x2DE7EFA66B906036, num);       //UI::_GET_SCALEFORM_MOVIE_FUNCTION_RETURN_INT
            return data;
        }

        /// <summary>
        /// Remove the current notification.
        /// Useful to remove "The selected contact is no longer available" when you try to call a contact that shouldn't exist (ie: contacts added by iFruitAddon).
        /// </summary>
        internal void RemoveActiveNotification()
        {
            Function.Call(Hash._SET_NOTIFICATION_TEXT_ENTRY, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, "temp");
            int temp = Function.Call<int>(Hash._DRAW_NOTIFICATION, false, 1);
            Function.Call(Hash._REMOVE_NOTIFICATION, temp);
            Function.Call(Hash._REMOVE_NOTIFICATION, temp - 1);
        }
    }
}
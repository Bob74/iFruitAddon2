﻿using GTA;
using GTA.Native;
using System.Collections.Generic;

namespace iFruitAddon2
{
    /// <summary>
    /// Collection of iFruit contacts.
    /// </summary>
    public class iFruitContactCollection : List<iFruitContact>
    {
        /// <summary>
        /// Internal index used to keep track of the current contact index.
        /// </summary>
        public static int _currentIndex = 40;
        
        private bool _shouldDraw = true;

        private readonly int _appContactScriptHash;

        /// <summary>
        /// Initializes a new instance of the <see cref="iFruitContactCollection"/> class.
        /// </summary>
        public iFruitContactCollection()
        {
            Logger.Debug("Initializing new iFruitContactCollection...");
            _appContactScriptHash = Game.GenerateHash("appcontacts");
            Logger.Debug("iFruitContactCollection initialized!");
        }

        /// <summary>
        /// Update all the contacts in the collection.
        /// </summary>
        /// <param name="handle">The handle of the phone scaleform.</param>
        internal void Update(int handle)
        {
            int _selectedIndex = 0;

            // If we are in the Contacts menu
            if (Function.Call<int>(Hash.GET_NUMBER_OF_THREADS_RUNNING_THE_SCRIPT_WITH_THIS_HASH, _appContactScriptHash) > 0)
            {
                _shouldDraw = true;

                // Debug log all contacts indexes in the form: [0, 1, 2, ...]
                Logger.Debug("Current contact indexes: [" + string.Join(", ", this.ConvertAll(c => c.Index)) + "]");



                if (Game.IsControlPressed(Control.PhoneSelect))
                {
                    Logger.Debug("Reading the index of the selected contact...");
                    _selectedIndex = GetSelectedIndex(handle);  // We must use this function only when necessary since it contains Script.Wait(0)
                    Logger.Debug("Selected contact: " + _selectedIndex);
                }
            }
            else
            {
                _selectedIndex = -1;
            }

            // Browsing every added contacts
            foreach (iFruitContact contact in this)
            {
                contact.Update(); // Update sounds or Answer call when _callTimer has ended.

                if (_shouldDraw)
                {
                    contact.Draw(handle);
                }

                if (_selectedIndex != -1 && _selectedIndex == contact.Index)
                {
                    Logger.Debug("Contact has been selected for calling");

                    // Prevent original contact to be called
                    Tools.Scripts.TerminateScript("appcontacts");
                    Logger.Debug("Script killed!");

                    Logger.Debug("Calling contact...");
                    contact.Call();
                    DisplayCallUI(handle, contact.Name, "CELL_211", contact.Icon.Name.SetBold(contact.Bold));
                    Logger.Debug("Contact called!");

                    Script.Wait(10);

                    Logger.Debug("Removing notification...");
                    Tools.Ui.RemoveActiveNotification();
                    Logger.Debug("Notification removed!");
                }

            }
            _shouldDraw = false;
        }

        /// <summary>
        /// Display the current call on the phone.
        /// </summary>
        /// <param name="handle">The handle of the phone scaleform.</param>
        /// <param name="contactName">Contact name to display</param>
        /// <param name="statusText">CELL_211 = "DIALING..." / CELL_219 = "CONNECTED"</param>
        /// <param name="picName">Contact icon to display</param>
        public static void DisplayCallUI(int handle, string contactName, string statusText = "CELL_211", string picName = "CELL_300")
        {
            string dialText = Game.GetLocalizedString(statusText); // "DIALING..." translated in current game's language

            Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, handle, "SET_DATA_SLOT");
            Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 4);
            Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 0);
            Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 3);

            Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "STRING");
            Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PHONE_NUMBER, contactName, -1);
            Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);

            Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "CELL_2000");
            Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, picName);
            Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);

            Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, "STRING");
            Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PHONE_NUMBER, dialText, -1);
            Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);

            Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);

            Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, handle, "DISPLAY_VIEW");
            Function.Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, 4);
            Function.Call(Hash.END_SCALEFORM_MOVIE_METHOD);
        }

        /// <summary>
        /// Get the index of the current highlighted contact.
        /// </summary>
        /// <param name="handle">The handle of the phone scaleform.</param>
        /// <returns>Index of the highlighted contact</returns>
        internal int GetSelectedIndex(int handle)
        {
            Function.Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, handle, "GET_CURRENT_SELECTION");
            int num = Function.Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
            while (!Function.Call<bool>(Hash.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY, num))
            {
                Script.Wait(0);
            }
            int data = Function.Call<int>(Hash.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT, num);
            return data;
        }

    }
}
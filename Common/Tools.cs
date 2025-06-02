using GTA;
using GTA.Native;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace iFruitAddon2
{
    internal static class Extensions
    {
        /// <summary>
        /// Modifies the boldness of the contact name.
        /// </summary>
        /// <param name="text">The contact name. Cannot be null.</param>
        /// <param name="bold">A value indicating whether the name should be shown as bold.</param>
        /// <returns>A new string with the casing modified according to the <paramref name="bold"/> parameter.</returns>
        internal static string SetBold(this string text, bool bold)
        {
            if (bold) return text.ToLower();
            else return text.ToUpper();
        }
    }

    internal static class Tools
    {
        /// <summary>
        /// Retrieves the name of the currently executing method, including its class name.
        /// </summary>
        /// <remarks>This method uses the <see cref="System.Diagnostics.StackTrace"/> class to inspect the
        /// call stack. The <paramref name="offset"/> parameter allows skipping additional stack frames, which can be
        /// useful in scenarios such as logging or debugging.</remarks>
        /// <param name="offset">The number of stack frames to skip when determining the current method. Must be non-negative. Use 0 to
        /// retrieve the immediate caller's method.</param>
        /// <returns>A string in the format "ClassName.MethodName" representing the name of the method at the specified stack
        /// frame offset.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static string GetCurrentMethod(int offset = 0)
        {
            var methodInfo = new StackTrace().GetFrame(1 + offset).GetMethod();
            var className = methodInfo.ReflectedType.Name;

            return $"{className}.{methodInfo.Name}";
        }

        internal static class Game
        {
            /// <summary>
            /// Retrieves the handle of the current player's ped in the game.
            /// </summary>
            /// <remarks>The handle can be used to interact with the player's ped in various
            /// game-related operations.</remarks>
            /// <returns>A <see cref="uint"/> representing the handle of the player's ped.</returns>
            internal static uint GetPlayerPedHandle()
            {
                return Function.Call<uint>(Hash.PLAYER_PED_ID);
            }

            /// <summary>
            /// Retrieves the model hash of the player's current ped entity.
            /// </summary>
            /// <returns>The <see cref="PedHash"/> representing the model of the player's ped entity.</returns>
            internal static PedHash GetPlayerPedModelHash()
            {
                return Function.Call<PedHash>(Hash.GET_ENTITY_MODEL, GetPlayerPedHandle());
            }

            /// <summary>
            /// Instructs the player character to stop using their mobile phone.
            /// </summary>
            internal static void TaskPutAwayMobilePhone()
            {
                Function.Call(Hash.TASK_USE_MOBILE_PHONE, GetPlayerPedHandle(), false);
            }

            /// <summary>
            /// Instructs the player character to start using a mobile phone.
            /// </summary>
            internal static void TaskUseMobilePhone()
            {
                Function.Call(Hash.TASK_USE_MOBILE_PHONE, GetPlayerPedHandle(), true);
            }
        }

        internal static class Scripts
        {
            /// <summary>
            /// Destroys the mobile phone associated with the specified handle.
            /// </summary>
            /// <param name="handle">The handle identifying the mobile phone to be destroyed. Must be a valid handle.</param>
            internal static void DestroyPhone(int handle)
            {
                Function.Call(Hash.DESTROY_MOBILE_PHONE, handle);
            }

            /// <summary>
            /// Starts a new script with the specified name and allocates the specified buffer size.
            /// </summary>
            /// <param name="scriptName">The name of the script to start. This must be a valid script name that can be loaded.</param>
            /// <param name="buffer">The size of the buffer to allocate for the script. Must be a positive integer.</param>
            internal static void StartScript(string scriptName, int buffer)
            {
                Function.Call(Hash.REQUEST_SCRIPT, scriptName);

                while (!Function.Call<bool>(Hash.HAS_SCRIPT_LOADED, scriptName))
                {
                    Function.Call(Hash.REQUEST_SCRIPT, scriptName);
                    Script.Yield();
                }

                Function.Call(Hash.START_NEW_SCRIPT, scriptName, buffer);
                Function.Call(Hash.SET_SCRIPT_AS_NO_LONGER_NEEDED, scriptName);
            }

            /// <summary>
            /// Terminates all instances of the specified script.
            /// </summary>
            /// <param name="scriptName">The name of the script to terminate. This parameter cannot be null or empty.</param>
            internal static void TerminateScript(string scriptName)
            {
                Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, scriptName);
            }
        }

        internal static class Ui
        {
            /// <summary>
            /// Remove the current notification.
            /// Useful to remove "The selected contact is no longer available" when you try to call a contact that shouldn't exist (ie: contacts added by iFruitAddon).
            /// </summary>
            internal static void RemoveActiveNotification()
            {
                // Spawning an empty notification
                int notifId = GTA.UI.Notification.Show("");

                // Removing the notification and the previous one
                GTA.UI.Notification.Hide(notifId);
                GTA.UI.Notification.Hide(notifId - 1);
            }
        }
    }
}




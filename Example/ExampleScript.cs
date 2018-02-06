using System;

using GTA;
using iFruitAddon2;

namespace iFruitTester
{
    public class ExampleScript : Script
    {
        CustomiFruit _iFruit;

        public ExampleScript()
        {
            // Custom phone creation
            _iFruit = new CustomiFruit();

            // Phone customization (totally optional)
            _iFruit.CenterButtonColor = System.Drawing.Color.Orange;
            _iFruit.LeftButtonColor = System.Drawing.Color.LimeGreen;
            _iFruit.RightButtonColor = System.Drawing.Color.Purple;
            _iFruit.CenterButtonIcon = SoftKeyIcon.Fire;
            _iFruit.LeftButtonIcon = SoftKeyIcon.Police;
            _iFruit.RightButtonIcon = SoftKeyIcon.Website;

            // New contact (wait 4 seconds (4000ms) before picking up the phone)
            iFruitContact contactA = new iFruitContact("Test contact");
            contactA.Answered += ContactAnswered;   // Linking the Answered event with our function
            contactA.DialTimeout = 4000;            // Delay before answering
            contactA.Active = true;                 // true = the contact is available and will answer the phone
            contactA.Icon = ContactIcon.Blank;      // Contact's icon
            _iFruit.Contacts.Add(contactA);         // Add the contact to the phone

            // New contact (wait 4 seconds before displaying "Busy...")
            iFruitContact contactB = new iFruitContact("Test contact 2");
            contactB.DialTimeout = 4000;
            contactB.Active = false;                // false = the contact is busy
            contactB.Icon = ContactIcon.Blocked;    
            _iFruit.Contacts.Add(contactB);

            Tick += OnTick;
        }

        // Tick Event
        void OnTick(object sender, EventArgs e)
        {
            _iFruit.Update();
        }

        private void ContactAnswered(iFruitContact contact)
        {
            // The contact has answered, we can execute our code
            UI.Notify("The contact has answered.");

            // We need to close the phone at a moment.
            // We can close it as soon as the contact pick up calling _iFruit.Close().
            // Here, we will close the phone in 5 seconds (5000ms).
            _iFruit.Close(5000);
        }

    }
}

using System;

using GTA;
using iFruitAddon2;

public class iFruitAddon2Example : Script
{
    readonly CustomiFruit _iFruit;

    public iFruitAddon2Example()
    {
        // Custom phone creation
        _iFruit = new CustomiFruit();

        // Phone customization (totally optional)
        _iFruit.LeftButtonColor = System.Drawing.Color.LimeGreen;
        _iFruit.CenterButtonColor = System.Drawing.Color.Orange;
        _iFruit.RightButtonColor = System.Drawing.Color.Purple;
        _iFruit.LeftButtonIcon = SoftKeyIcon.Police;
        _iFruit.CenterButtonIcon = SoftKeyIcon.Fire;
        _iFruit.RightButtonIcon = SoftKeyIcon.Website;

        // New contact (wait 4 seconds (4000ms) before picking up the phone)
        iFruitContact contactA = new iFruitContact("Test contact")
        {
            DialTimeout = 4000,            // Delay before answering
            Active = true,                 // true = the contact is available and will answer the phone
            Icon = ContactIcon.Blank      // Contact's icon
        };
        contactA.Answered += ContactAnswered;   // Linking the Answered event with our function
        _iFruit.Contacts.Add(contactA);         // Add the contact to the phone

        // New contact (wait 4 seconds before displaying "Busy...")
        iFruitContact contactB = new iFruitContact("Test contact 2")
        {
            DialTimeout = 4000,
            Active = false,                // false = the contact is busy
            Icon = ContactIcon.Blocked,
            Bold = true                   // Set the contact name in bold
        };
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
        GTA.UI.Notification.Show("The contact has answered.");
		
        // We need to close the phone at a moment.
        // We can close it as soon as the contact pick up calling _iFruit.Close().
        // Here, we will close the phone in 5 seconds (5000ms).
        _iFruit.Close(5000);
    }
}
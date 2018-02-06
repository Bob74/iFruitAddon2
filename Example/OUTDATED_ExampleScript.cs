using System;
using GTA;
using GTA.Math;
using GTA.Native;
using iFruitAddon;

namespace ExampleScript
{
    public class ExampleScript : Script
    {
        CustomiFruit ifruit;

        public ExampleScript()
        {
            ifruit = new CustomiFruit()
            {
                CenterButtonColor = System.Drawing.Color.Orange,
                LeftButtonColor = System.Drawing.Color.LimeGreen,
                RightButtonColor = System.Drawing.Color.Purple,
                CenterButtonIcon = SoftKeyIcon.Fire,
                LeftButtonIcon = SoftKeyIcon.Police,
                RightButtonIcon = SoftKeyIcon.Website
            };

            ifruit.SetWallpaper(new Wallpaper("char_facebook"));
            //or..
            ifruit.SetWallpaper(Wallpaper.BadgerDefault);

            var contact = new iFruitContact("Spawn Adder", 19);
            contact.Answered += Contact_Answered;
            contact.DialTimeout = 8000;
            contact.Active = true;

            //set custom icons by instantiating the ContactIcon class
            contact.Icon = new ContactIcon("char_sasquatch");

            ifruit.Contacts.Add(contact);

            contact = new iFruitContact("Teleport to Waypoint", 20);
            contact.Answered += (s) => Scripts.TeleportToWaypoint();
            contact.DialTimeout = 0;
            contact.Icon = ContactIcon.Target;

            ifruit.Contacts.Add(contact);

            Tick += OnTick;
        }

        private void Contact_Answered(iFruitContact contact)
        {
            Scripts.SpawnVehicle("ADDER");
            UI.Notify("Your Adder has been delivered!");
        }

        void OnTick(object sender, EventArgs e)
        {
            ifruit.Update();
        }

        protected override void Dispose(bool A_0)
        {
            ifruit.Contacts.ForEach(x => x.EndCall());
            base.Dispose(A_0);
        }
    }

    public static class Scripts
    {
        public static void TeleportToWaypoint()
        {
            Blip wpBlip = new Blip(Function.Call<int>(Hash.GET_FIRST_BLIP_INFO_ID, 8));

            if (Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE))
            {
                GTA.Math.Vector3 wpVec = Function.Call<GTA.Math.Vector3>(Hash.GET_BLIP_COORDS, wpBlip);
                Game.Player.Character.Position = wpVec;
            }
            else
            {
                UI.ShowSubtitle("Waypoint not active.");
            }
        }

        public static void SpawnVehicle(string vehiclename)
        {
            Model model = new Model(vehiclename);
            model.Request(1000);
            World.CreateVehicle(model, Game.Player.Character.Position + Game.Player.Character.ForwardVector * 5);
        }
    }
}

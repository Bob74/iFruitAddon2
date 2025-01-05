# iFruitAddon2
Updated version of the original [iFruitAddon](https://github.com/CamxxCore/iFruitAddon) by **CamxxCore**.  
This is a developer resource, it allows you to handle the game's phone in order to add contacts, change the button's appearance, wallpaper and more!

![screen1](https://github.com/user-attachments/assets/5cfe620e-09bc-448a-9314-8a5af4ab76f2)
![screen2](https://github.com/user-attachments/assets/0432c4b4-c388-4fc8-8bce-9ffb05580d76)


![screen3](https://github.com/user-attachments/assets/8850d8d9-d419-4684-a751-a18a6f874f13)


## Installation
- Requires [ScriptHookVDotNet](https://github.com/crosire/scripthookvdotnet/releases) v3
- Put the file like any other SHVDN scripts in your `GTA V\scripts` directory

## How to use (developper)
* Reference `iFruitAddon2.ddl` in your project.
* Copy `iFruitAddon2.ddl` to ScriptHookVDotNet **scripts** folder.

An example script is available [here](https://github.com/Bob74/iFruitAddon2/blob/master/Example/ExampleScript.cs).

If you are used to iFruitAddon, you will see two main differences:
* There is no need to set the index of your contact (they will all be added one after the other at the bottom of the phone's list). It means mods contacts cannot overlaps each others anymore!
* You need to call the CustomiFruit `Close(int)` method when you no longer need the phone (conversation is over, etc.). This method will close the phone after the delay you've specified (in milliseconds). You can also call `Close()` without argument to close the phone immediatly.

## What's new?
* Contact's indexes are set automatically and are shared between mods (you cannot overwrite another mod's contact anymore).
* You can close the phone with the `Close(int)` method. It is useful if you use a contact to open a NativeUI menu. Since NativeUI menus use the same controls to navigate as the phone, you can close the phone to avoid navigating in the menu while browsing your menu.
* You can set the contact name to bold in the contact list (use `.Bold` property of `iFruitContact`).
* Updated list of phone contact's pictures.
* Displays **CONNECTED** on the phone's UI when the contact has answered.
* Automatically localized texts ("DIALING...", "BUSY...", "CONNECTED", etc.).

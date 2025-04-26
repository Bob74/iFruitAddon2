[![GitHub Release](https://img.shields.io/github/v/release/Bob74/iFruitAddon2?logo=github&label=Release&cacheSeconds=3600)](https://github.com/Bob74/iFruitAddon2/releases)
[![NuGet Downloads](https://img.shields.io/nuget/v/iFruitAddon2?logo=nuget&label=NuGet&cacheSeconds=3600)](https://www.nuget.org/packages/iFruitAddon2)

# iFruitAddon2
An updated version of the original [iFruitAddon](https://github.com/CamxxCore/iFruitAddon) by **CamxxCore**.  
This is a developer resource, it allows you to handle the game's phone to add contacts, change the button's appearance, wallpaper, and more!

![screen1](https://raw.githubusercontent.com/Bob74/iFruitAddon2/refs/heads/master/doc/phone1.png)
![screen2](https://raw.githubusercontent.com/Bob74/iFruitAddon2/refs/heads/master/doc/phone2.png)


![screen3](https://raw.githubusercontent.com/Bob74/iFruitAddon2/refs/heads/master/doc/phone3.png)


## Installation
- Requires [ScriptHookVDotNet](https://github.com/crosire/scripthookvdotnet/releases) v3
- Put the file like any other SHVDN scripts in your `GTA V\scripts` directory

### ⚠️ **Reminder to allow mods to create files in your GTA V directory**
By default, mods won't be allowed to create files and folders. This can be an issue since `iFruitAddon2` write its config file in `scripts\iFruitAddon2\`. You need to allow your computer users to modify GTA V main directory:
![Setup file permission](https://raw.githubusercontent.com/Bob74/iFruitAddon2/refs/heads/master/doc/file_permission.png)

## How to use (developer)
* Reference `iFruitAddon2.ddl` in your project.
* Copy `iFruitAddon2.ddl` to ScriptHookVDotNet **scripts** folder.

An example script is available [here](https://github.com/Bob74/iFruitAddon2/blob/master/Example/ExampleScript.cs).

If you are used to iFruitAddon, you will see two main differences:
* There is no need to set the index of your contacts (they will all be added one after the other at the bottom of the phone's list). It means mods' contacts cannot overlap each other anymore!
* You need to call the CustomiFruit `Close(int)` method when you no longer need the phone (conversation is over, etc.). This method will close the phone after the specified delay (in milliseconds). You can also call `Close()` without argument to close the phone immediately.

## What's new?
* Contact indexes are set automatically and are shared between mods (you cannot overwrite another mod's contact anymore).
* You can close the phone using the `Close(int)` method. It is useful if you use a contact to open a NativeUI menu. Since NativeUI menus use the same controls to navigate as the phone, you can close the phone to avoid navigating in the menu while browsing your menu.
* You can set the contact name to bold in the contact list (use `.Bold` property of `iFruitContact`).
* Updated list of phone contact's pictures.
* Displays **CONNECTED** on the phone's UI when the contact has answered.
* Automatically localized texts ("DIALING...", "BUSY...", "CONNECTED", etc.).

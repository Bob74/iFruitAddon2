# iFruitAddon2
Updated version of the original iFruitAddon by CamxxCore.


## Installation
- Requires [ScriptHookVDotNet](https://github.com/crosire/scripthookvdotnet/releases)
- Put the file in your **GTA V\scripts directory**

## How to use (developper)
* Reference `iFruitAddon2.ddl` in your project.
* Copy `iFruitAddon2.ddl` to ScriptHookVDotNet **scripts** folder.

An example script is available [here](https://github.com/Bob74/iFruitAddon2/blob/master/Example/ExampleScript.cs).

If you are used to iFruitAddon, you will see two main differences:
* There is no need to set the index of your contact (they will all be added one after the other at the bottom of the phone's list). It means mods contacts cannot overlaps each others anymore!
* You need to call the CutomiFruit `Close(int)` method when you no longer need the phone (conversation is over, etc.). This method will close the phone after the delay you've specified (in milliseconds). You can also call `Close()` without argument to close the phone immediatly.

## What's new?
* Contact's indexes are set automatically and are shared between mods (you cannot overwrite another mod's contact anymore).
* You can close the phone with the `Close(int)` method. It is useful if you use a contact to open a NativeUI menu. Since NativeUI menus use the same controls to navigate as the phone, you can close the phone to avoid navigating in the menu while browsing your menu.
* Updated list of phone contact's pictures.
* Checks if **iFruitAddon2**'s updates are available when the game starts.

# iFruitAddon2
Updated version of the original iFruitAddon by CamxxCore.


## Installation
- Requires ScriptHookVDotNet
- Put the file in your **GTA V\scripts directory**

## How to use (developper)
* Reference `iFruitAddon2.ddl` in your project.
* Copy `iFruitAddon2.ddl` to ScriptHookVDotNet **scripts** folder.

An example script is available [here](https://github.com/Bob74/iFruitAddon2/blob/master/Example/ExampleScript.cs).

If you are used to iFruitAddon, you will see two main differences:
* There is no need to set the index of your contact (they will all be added one after the other at the bottom of the phone's list). It means mods contacts cannot overlaps each others anymore!
* You need to call the CutomiFruit `Close(int)` method when you no longer need the phone (conversation is over, etc.). This method will close the phone after the delay you've specified (in milliseconds). You can also call `Close()` without argument to close the phone immediatly.

# PriconneReTL Installer
An installer/updater GUI for the [PriconneRe-TL](https://github.com/ImaterialC/PriconneRe-TL) english patch.
Make installing, updating and removing the unofficial english patch for Princess Connect Re:Dive japanese version easier.

Based on [PriconneTL_Updater](https://github.com/touanu/PriconeTL_Updater) by [touanu](https://github.com/touanu)

## Features
- Graphical user interface for easy operation.
- Able to detect game path, installed version and latest available version.
- Multiple operations depending on already installed version and user options, including install/reinstall/uninstall.
- Able to delete the interop assemblies generated by the translation patch. Useful when and aborted / incorrect game start-up causes the interop assemblies get corrupted or incorrectly generated.
- Is able to detect user-important files and keeps them intact during processing, including:
  - XUnityAutoTranslator specific files:
      - _AutoGeneratedTranslations.txt
      - _Preprocessors.txt
      - _Postprocessors.txt
      - _Substitions.txt
  - Configuration files:
      - AutoTranslatorConfig.ini
      - BepInEx.cfg
  - User created files in the patch folders

## Usage
### First / Fresh Install:
If you have never used the patch before, or you don't have it currently installed, just press the *Start!* button, and the application will donwload and install the translation patch for you.  
If you have files left over from a previous installation, the application will keep those.

### Update:
If you already have a version of the translation patch applied, just press the *Start!* button, and the application will update it by deleting the files of the current patch version,  
and downloading the latest files.  
Important files are not touched during this process.

### Force Redownload / Reinstall:
If you check the *Force Redownload* option before pressing the *Start* button, the application will delete the currently installed translation patch version, and download and install the latest release.  
It's like and Uninstall + Install. 
Force Redownload keeps the important config files untouched, but deletes the interop assemblies generated by the translation patch.

### Uninstall:
If you check the *Uninstall* option before pressing the Start button, the application will remove the currently installed translation patch.
Depending on any other options selected, it will either keep or delete config files, user important patch files and/or the interop assemblies.  
For a full uninstall, select all options.  
Please note, that even a full uninstall does NOT remove any files created by the user in the patch directories.

By checking / unchecking the *Show Logs* option, you can view/hide a detailed progress/output log.  
All the operations processed are always logged into the *ReTLInstaller.log* file in the application's folder, regardless of this option.

## Requirements
- .NET 4.7.2 (should already be installed if you're running Windows 10 Version 1803 or above)

## Planned features
- User configurable options, like exclusions, log file path, ability to set game path manually, etc..
- Verify option to check the files of the current installation without actual modifications
- Code cleanup

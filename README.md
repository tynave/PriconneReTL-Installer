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
  - XUnityAutoTranslator specific files (from here on referred as "ignored files"):
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
If you have never used the patch before, or you don't have it currently installed, just press the *Start!* button, and the application will download and install the translation patch for you.  
If you have files left over from a previous installation, the application will keep those.

### Update:
If you already have a version of the translation patch applied, just press the *Start!* button, and the application will update it by deleting the files of the current patch version, and downloading the latest files.  
Config files/ignored files/user files as well as interop aseemblies are not touched during the process.

### Reinstall:
If you check the *Reinstall* option before pressing the *Start* button, the application will delete the currently installed translation patch version, and download and install the latest release.  
It's like and Uninstall + Install. 
Depending on any other options selected, it will either keep or delete config files, ignored files and/or the interop assemblies.  
Does not touch user files.

### Uninstall:
If you check the *Uninstall* option before pressing the Start button, the application will remove the currently installed translation patch.
Depending on any other options selected, it will either keep or delete config files, ignored files and/or the interop assemblies.  
For a full uninstall, select all options.  
Please note, that even a full uninstall does NOT remove any files created by the user in the patch directories.

By checking / unchecking the *Show Logs* option, you can view/hide a detailed progress/output log.  
All the operations processed are always logged into the *ReTLInstaller.log* file in the application's folder, regardless of this option.

_**Update and Reinstall do the same thing, why having both of them then..?**_
When starting to develop the application, Update and Reinstall operations followed different logics.
However, during the development, it turned out, that the github API has certain limitations, which would have made the Update logic have issues if the user skips a few versions of the translation patch and wants to do a bigger update.
So in order to avoid this, the Update logic needed to be changed to the approach that actually matches that of the Reinstall process.
The two main differences however remain:
 - Update never touches the user important files (config/ignored/interops/user created files) while for Reinstall, you can select to have some of these removed / replaced by defulat ones present in the translation patch.
 - Update cannot be performed when you already have the latest translation patch release installed, while Reinstall, as the name implies allows you to even reinstall the latest version.

## Requirements
- .NET 4.7.2 (should already be installed if you're running Windows 10 Version 1803 or above)

## Possible future features
- User configurable options (set game path manually, set log file path, add files to the ignored files, etc..)
- Verify option to check the files of the current installation without actual modifications
- Command line arguments and an autoupdater pre-load plugin for BepInEx 

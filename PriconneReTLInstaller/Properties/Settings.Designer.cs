﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PriconneReTLInstaller.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.8.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <string>BepInEx/Translation/en/Text/_AutoGeneratedTranslations.txt</string>
  <string>BepInEx/Translation/en/Text/_Postprocessors.txt</string>
  <string>BepInEx/Translation/en/Text/_Preprocessors.txt</string>
  <string>BepInEx/Translation/en/Text/_Substitutions.txt</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection ignoreFiles {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ignoreFiles"]));
            }
            set {
                this["ignoreFiles"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <string>BepInEx/config/AutoTranslatorConfig.ini</string>
  <string>BepInEx/config/BepInEx.cfg</string>
  <string>BepInEx/config/PriconneTLFixup.cfg</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection configFiles {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["configFiles"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://api.github.com/repos/ImaterialC/PriconneRe-TL")]
        public string patchGithubApi {
            get {
                return ((string)(this["patchGithubApi"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\nInspired by https://github.com/touanu/PriconeTL_Updater\r\n\r\nAll assets used in t" +
            "his application are properties of CyberAgent, Inc., Cygames, Inc. / their respec" +
            "tive creators.")]
        public string aboutText {
            get {
                return ((string)(this["aboutText"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Install")]
        public string installMode {
            get {
                return ((string)(this["installMode"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Installs the translation patch.\r\nKeeps config files, ignored files and \r\nany user" +
            " created files already present.")]
        public string installModeDescription {
            get {
                return ((string)(this["installModeDescription"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Uninstall")]
        public string uninstallMode {
            get {
                return ((string)(this["uninstallMode"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Removes the translation patch.\r\nKeeps any user created files.\r\nDepending on the o" +
            "ptions selected, keeps or removes config/ignored/interop files.")]
        public string uninstallModeDescription {
            get {
                return ((string)(this["uninstallModeDescription"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Reinstall")]
        public string reinstallMode {
            get {
                return ((string)(this["reinstallMode"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Removes the translation patch, and then installs the latest version.\r\nKeeps any u" +
            "ser created files.\r\nDepending on the options selected, keeps or removes config/i" +
            "gnored/interop files.")]
        public string reinstallModeDescription {
            get {
                return ((string)(this["reinstallModeDescription"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Update")]
        public string updateMode {
            get {
                return ((string)(this["updateMode"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Updates the current translation patch installation by removing the the current ve" +
            "rsion and installing the latest.\r\nKeeps user files, as well as config/ignored/in" +
            "terop files.")]
        public string updateModeDescription {
            get {
                return ((string)(this["updateModeDescription"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Disabled")]
        public string disabledMode {
            get {
                return ((string)(this["disabledMode"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Operation disabled due to an error.\r\nSee log for details.")]
        public string disabledModeDescription {
            get {
                return ((string)(this["disabledModeDescription"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Launch Game")]
        public string launchMode {
            get {
                return ((string)(this["launchMode"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Launches the game using the selected launcher.")]
        public string launchModeDescrption {
            get {
                return ((string)(this["launchModeDescrption"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("No Operation")]
        public string noOperationMode {
            get {
                return ((string)(this["noOperationMode"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("No operation selected.")]
        public string noOperationModeDescription {
            get {
                return ((string)(this["noOperationModeDescription"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool launchState {
            get {
                return ((bool)(this["launchState"]));
            }
            set {
                this["launchState"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://api.github.com/repos/tynave/PriconneReTL-AutoUpdater")]
        public string auGithubApi {
            get {
                return ((string)(this["auGithubApi"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://api.github.com/repos/tynave/PriconneReTL-AutoUpdaterApp")]
        public string auAppGithubApi {
            get {
                return ((string)(this["auAppGithubApi"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string fastLauncherLink {
            get {
                return ((string)(this["fastLauncherLink"]));
            }
            set {
                this["fastLauncherLink"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1.4.0.0")]
        public string LastKnownVersion {
            get {
                return ((string)(this["LastKnownVersion"]));
            }
            set {
                this["LastKnownVersion"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"DMMGamePlayerFastLauncher shortcut not set or not valid!

In order to be able to launch the game via the DMMGamePlayerFastLauncher, you need to set the shortcut of it in the installer. 

If you have moved/removed/renamed the previously set shortcut, please re-set it. 

Press the OK button to open the window for setting the shortcut. Press the Cancel button to abort the operation. 

You can set the shortcut any time by clicking the ""Settings"" icon (scroll) and selecting the ""Launcher Settings"" option, or by clicking on the launcher's name below the ""Launch Game"" checkbox.")]
        public string cannotStartDMMFastLauncherError {
            get {
                return ((string)(this["cannotStartDMMFastLauncherError"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int selectedLauncher {
            get {
                return ((int)(this["selectedLauncher"]));
            }
            set {
                this["selectedLauncher"] = value;
            }
        }
    }
}

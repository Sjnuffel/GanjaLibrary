﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GanjaLibrary {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class GameSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static GameSettings defaultInstance = ((GameSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new GameSettings())));
        
        public static GameSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-25")]
        public int DeathThreshold {
            get {
                return ((int)(this["DeathThreshold"]));
            }
            set {
                this["DeathThreshold"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int MaxHealth {
            get {
                return ((int)(this["MaxHealth"]));
            }
            set {
                this["MaxHealth"] = value;
            }
        }
    }
}

using KaosesCommon.Objects;
using KaosesCommon.Utils;
using KaosesMoreAmmo.Settings;
using KaosesMoreAmmoCore.Settings;
using System;
using System.Reflection;
using CoreConfig = KaosesMoreAmmoCore.Settings.KaosesMoreAmmoCoreConfig;
using CoreFactory = KaosesMoreAmmoCore.Objects.KaosesMoreAmmoCoreFactory;

namespace KaosesMoreAmmo.Objects
{
    /// <summary>
    /// KaosesMoreAmmo Factory Object
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Variable to hold the MCM settings object
        /// </summary>
        private static Config? _settings = null;

        //private static ConfigOther? _settings2 = null;
        private static CoreConfig? _settingscore = null;

        private static InfoMgr? _im = null;

        public static InfoMgr IM
        {
            get
            {
                return _im;
            }
            set
            {
                _im = value;
            }
        }

        /// <summary>
        /// Bool indicates if MCM is a loaded mod
        /// </summary>
        public static bool MCMModuleLoaded { get; set; } = false;

        /// <summary>
        /// MCM Settings Object Instance
        /// </summary>
        public static Config Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = Config.Instance;
                    if (_settings is null)
                    {
                        Factory.IM.ShowMessageBox("Kaoses Temp Beta Failed to load MCM config provider", "Kaoses Temp Beta MCM Error");
                    }
                }
                return _settings;
            }
            set
            {
                _settings = value;
            }
        }
        public static CoreConfig SettingsCore
        {
            get
            {
                if (_settingscore == null)
                {
                    _settingscore = CoreConfig.Instance;
                    if (_settingscore is null)
                    {
                        Factory.IM.ShowMessageBox("KaosesMoreAmmo Core Failed to load config provider", "KaosesMoreAmmo Core Error");
                    }
                }
                return _settingscore;
            }
            set
            {
                _settingscore = value;
            }
        }

        /// <summary>
        /// Mod version
        /// </summary>
        public static string ModVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>
        /// Unused mod config file path
        /// </summary>
        private static string ConfigFilePath
        {

            get
            {
                return @"..\\..\\Modules\\" + SubModule.ModuleId + "\\config.json";
            }
            //set {  = value; }

        }


    }
}

using KaosesCommon;
using KaosesCommon.Objects;
using KaosesCommon.Utils;
using KaosesMoreAmmoCore.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KaosesMoreAmmoCore.Objects
{
    /// <summary>
    /// KaosesMoreAmmoCoreFactory Factory Object
    /// </summary>
    public static class KaosesMoreAmmoCoreFactory
    {
        /// <summary>
        /// Variable to hold the MCM settings object
        /// </summary>
        private static KaosesMoreAmmoCoreConfig _settings = null;

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
        /// MCM Settings Object Instance
        /// </summary>
        public static KaosesMoreAmmoCoreConfig Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = KaosesMoreAmmoCoreConfig.Instance;
                    if (_settings is null)
                    {
                        //IM.ShowMessageBox("KaosesMoreAmmoCoreConfig Failed to load KaosesMoreAmmoCoreConfig provider", "KaosesMoreAmmoCoreConfig Error");
                    }
                }
                return _settings;
            }
            set
            {
                _settings = value;
            }
        }

        /// <summary>
        /// Mod version
        /// </summary>
        public static string ModVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

    }
}

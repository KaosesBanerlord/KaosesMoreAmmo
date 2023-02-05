using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Localization;

namespace KaosesMoreAmmoCore.Settings
{
    public class KaosesMoreAmmoCoreConfig
    {
        private static KaosesMoreAmmoCoreConfig _instance = null;

        private KaosesMoreAmmoCoreConfig()
        {

        }

        public static KaosesMoreAmmoCoreConfig Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KaosesMoreAmmoCoreConfig();
                return _instance;
            }
        }



        #region Debug

        public bool Debug { get; set; } = false;

        public bool LogToFile { get; set; } = false;


        #endregion //~Debug



        public bool LogMissionBehaviours { get; set; } = false;


        ///~ Mod Specific settings 
        #region Arrows
        public bool ArrowMultiplierEnabled { get; set; } = true;
        public float ArrowMultiplier { get; set; } = 1.0f;
        public bool ArrowValueMultiplierEnabled { get; set; } = false;
        public float ArrowValueMultiplier { get; set; } = 1.0f;
        public bool ArrowWeightMultiplierEnabled { get; set; } = false;
        public float ArrowWeightMultiplier { get; set; } = 1.0f;
        #endregion

        #region Bolts
        public bool BoltsMultiplierEnabled { get; set; } = true;
        public float BoltsMultiplier { get; set; } = 1.0f;
        public bool BoltsValueMultiplierEnabled { get; set; } = false;
        public float BoltsValueMultiplier { get; set; } = 1.0f;
        public bool BoltsWeightMultiplierEnabled { get; set; } = false;
        public float BoltsWeightMultiplier { get; set; } = 1.0f;
        #endregion

        #region Thrown
        public bool ThrownMultiplierEnabled { get; set; } = true;
        public float ThrownMultiplier { get; set; } = 1.0f;
        public bool ThrownValueMultiplierEnabled { get; set; } = false;
        public float ThrownValueMultiplier { get; set; } = 1.0f;
        public bool ThrownWeightMultiplierEnabled { get; set; } = false;
        public float ThrownWeightMultiplier { get; set; } = 1.0f;
        public bool ThrownMissionFixMultiplierEnabled { get; set; } = false;
        #endregion

        #region Bullets
        public bool BulletsMultiplierEnabled { get; set; } = true;
        public float BulletsMultiplier { get; set; } = 1.0f;
        public bool BulletsValueMultiplierEnabled { get; set; } = false;
        public float BulletsValueMultiplier { get; set; } = 1.0f;
        public bool BulletsWeightMultiplierEnabled { get; set; } = false;
        public float BulletsWeightMultiplier { get; set; } = 1.0f;

        /*
                public bool BulletsMissionFixMultiplierEnabled { get; set; } = false;*/
        #endregion



    }
}

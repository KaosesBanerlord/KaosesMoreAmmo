using HarmonyLib;
using KaosesCommon.Objects;
using KaosesCommon.Utils;
using KaosesMoreAmmo.Objects;
using KaosesMoreAmmoCore.Objects;
using KaosesMoreAmmoCore.Settings;
using MCM.Abstractions;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using MCM.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using TaleWorlds.Localization;
using static HarmonyLib.Code;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using CoreConfig = KaosesMoreAmmoCore.Settings.KaosesMoreAmmoCoreConfig;
using CoreFactory = KaosesMoreAmmoCore.Objects.KaosesMoreAmmoCoreFactory;

//using MCM.Abstractions.Settings.Base.PerSave;


namespace KaosesMoreAmmo.Settings
{
    //public class Settings : AttributePerSaveSettings<Settings>, ISettingsProviderInterface
    public class Config : AttributeGlobalSettings<Config>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Config()
        {
            PropertyChanged += Settings_PropertyChanged;
        }


        #region ModSettingsStandard
        public override string Id => SubModule.ModuleId;
        public override string FolderName => SubModule.ModuleId;
        public string ModName => "KaosesMoreAmmo";
        public override string FormatType => "json";
        #region Translatable DisplayName 
        // Build mod display name with name and version form the project properties version
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the null ability of reference types.
        public TextObject versionTextObj = new TextObject(typeof(Config).Assembly.GetName().Version?.ToString(3) ?? "");
        public override string DisplayName => new TextObject("{=KaosesMoreAmmoDisplayName}" + ModName + " " + versionTextObj.ToString())!.ToString();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the null ability of reference types.
        #endregion
        public string ModDisplayName { get { return DisplayName; } }
        #endregion

        #region Debug

        [SettingPropertyBool("{=debug}Debug", RequireRestart = false, HintText = "{=debug_desc}Displays mod developer debug information and logs them to the file")]
        [SettingPropertyGroup("Debug", GroupOrder = 1)]
        public bool Debug { get; set; } = false;
        [SettingPropertyBool("{=debuglog}Log to file", RequireRestart = false, HintText = "{=debuglog_desc}Log information messages to the log file as well as errors and debug")]
        [SettingPropertyGroup("Debug", GroupOrder = 2)]
        public bool LogToFile { get; set; } = false;


        [SettingPropertyBool("{=debugharmony}Debug Harmony", RequireRestart = false, HintText = "{=debugharmony_desc}Enable/Disable harmony's debuging logs")]
        [SettingPropertyGroup("Debug", GroupOrder = 2)]
        public bool IsHarmonyDebug { get; set; } = false;


        #endregion //~Debug



        public bool LogMissionBehaviours { get; set; } = false;


        ///~ Mod Specific settings 
        #region Arrows
        [SettingPropertyBool("{=KPM_AME}Arrows Multiplier Enabled", Order = 1, RequireRestart = false,
            HintText = "{=KPM_AMEH}Enables Arrows stack Multiplier")]
        [SettingPropertyGroup("{=KPM_Arrows}Arrows")]
        public bool ArrowMultiplierEnabled { get; set; } = true;

        [SettingPropertyFloatingInteger("{=KPM_SSM}Stack Size Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KPM_SSMH}Multiply stack sizes by the multiplier [Native: 1.0(100%)].")]
        [SettingPropertyGroup("{=KPM_Arrows}Arrows")]
        public float ArrowMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=KPM_PME}Price Multiplier Enabled", Order = 1, RequireRestart = false,
            HintText = "{=KPM_PMEH}Enables Item Price Multiplier")]
        [SettingPropertyGroup("{=KPM_Arrows}Arrows")]
        public bool ArrowValueMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KPM_PM}Price Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KPM_PMH}Multiply price by the multiplier [Native: 1.0(100%)]")]
        [SettingPropertyGroup("{=KPM_Arrows}Arrows")]
        public float ArrowValueMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=KPM_WME}Weight Multiplier Enabled", Order = 1, RequireRestart = false,
            HintText = "{=KPM_WMEH}Enables Weight Multiplier")]
        [SettingPropertyGroup("{=KPM_Arrows}Arrows")]
        public bool ArrowWeightMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KPM_WM}Weight Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KPM_WMH}Multiply item weight by the multiplier [Native: 1.0(100%)]")]
        [SettingPropertyGroup("{=KPM_Arrows}Arrows")]
        public float ArrowWeightMultiplier { get; set; } = 1.0f;
        #endregion

        #region Bolts
        [SettingPropertyBool("{=KPM_BME}Bolts Multiplier Enabled", Order = 1, RequireRestart = false,
            HintText = "{=KPM_BMEH}Enables Bolts stack Multiplier")]
        [SettingPropertyGroup("{=KPM_Bolts}Bolts")]
        public bool BoltsMultiplierEnabled { get; set; } = true;

        [SettingPropertyFloatingInteger("{=KPM_SSM}Stack Size Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KPM_SSMH}Multiply stack sizes by the multiplier [Native: 1.0(100%)].")]
        [SettingPropertyGroup("{=KPM_Bolts}Bolts")]
        public float BoltsMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=KPM_PME}Price Multiplier Enabled", Order = 1, RequireRestart = false,
            HintText = "{=KPM_PMEH}Enables Item Price Multiplier")]
        [SettingPropertyGroup("{=KPM_Bolts}Bolts")]
        public bool BoltsValueMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KPM_PM}Price Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KPM_PMH}Multiply price by the multiplier [Native: 1.0(100%)].")]
        [SettingPropertyGroup("{=KPM_Bolts}Bolts")]
        public float BoltsValueMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=KPM_WME}Weight Multiplier Enabled", Order = 1, RequireRestart = false,
            HintText = "{=KPM_WMEH}Enables Weight Multiplier")]
        [SettingPropertyGroup("{=KPM_Bolts}Bolts")]
        public bool BoltsWeightMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KPM_WM}Weight Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KPM_WMH}Multiply item weight by the multiplier [Native: 1.0(100%)].")]
        [SettingPropertyGroup("{=KPM_Bolts}Bolts")]
        public float BoltsWeightMultiplier { get; set; } = 1.0f;
        #endregion

        #region Thrown
        [SettingPropertyBool("{=KPM_TWME}Thrown Multipliers Enabled", Order = 1, RequireRestart = false,
            HintText = "{=KPM_TWMEH}Enables Thrown Multipliers")]
        [SettingPropertyGroup("{=KPM_Thrown}Thrown")]
        public bool ThrownMultiplierEnabled { get; set; } = true;

        [SettingPropertyFloatingInteger("{=KPM_SSM}Stack Size Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KPM_SSMH}Multiply stack sizes by the multiplier [Native: 1.0(100%)].")]
        [SettingPropertyGroup("{=KPM_Thrown}Thrown")]
        public float ThrownMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=KPM_PME}Price Multiplier Enabled", Order = 1, RequireRestart = false,
            HintText = "{KPM_PMEH}Enables Item Price Multiplier")]
        [SettingPropertyGroup("{=KPM_Thrown}Thrown")]
        public bool ThrownValueMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KPM_PM}Price Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KPM_PMH}Multiply price by the multiplier [Native: 1.0(100%)].")]
        [SettingPropertyGroup("{=KPM_Thrown}Thrown")]
        public float ThrownValueMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=KPM_WME}Weight Multiplier Enabled", Order = 1, RequireRestart = false,
            HintText = "{=KPM_WMEH}Enables Weight Multiplier")]
        [SettingPropertyGroup("{=KPM_Thrown}Thrown")]
        public bool ThrownWeightMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KPM_WM}Weight Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KPM_WMH}Multiply item weight by the multiplier [Native: 1.0(100%)].")]
        [SettingPropertyGroup("{=KPM_Thrown}Thrown")]
        public float ThrownWeightMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=KPM_MTWFE}Thrown Mission stack Fix Enabled", Order = 1, RequireRestart = false,
            HintText = "{KPM_MTWFEH}Enables a temp fix for thrown weapon stack sizes in missions")]
        [SettingPropertyGroup("{=KPM_WorkAround}Work around")]
        public bool ThrownMissionFixMultiplierEnabled { get; set; } = false;
        #endregion

        #region Bullets
        [SettingPropertyBool("{=KPM_BWME}Bullets Multipliers Enabled", Order = 1, RequireRestart = false,
            HintText = "{=KPM_BWMEH}Enables Bullets Multipliers")]
        [SettingPropertyGroup("{=KPM_Bullets}Bullets")]
        public bool BulletsMultiplierEnabled { get; set; } = true;

        [SettingPropertyFloatingInteger("{=KPM_SSM}Stack Size Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KPM_SSMH}Multiply stack sizes by the multiplier [Native: 1.0(100%)].")]
        [SettingPropertyGroup("{=KPM_Bullets}Bullets")]
        public float BulletsMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=KPM_PME}Price Multiplier Enabled", Order = 1, RequireRestart = false,
            HintText = "{KPM_PMEH}Enables Item Price Multiplier")]
        [SettingPropertyGroup("{=KPM_Bullets}Bullets")]
        public bool BulletsValueMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KPM_PM}Price Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KPM_PMH}Multiply price by the multiplier [Native: 1.0(100%)].")]
        [SettingPropertyGroup("{=KPM_Bullets}Bullets")]
        public float BulletsValueMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=KPM_WME}Weight Multiplier Enabled", Order = 1, RequireRestart = false,
            HintText = "{=KPM_WMEH}Enables Weight Multiplier")]
        [SettingPropertyGroup("{=KPM_Bullets}Bullets")]
        public bool BulletsWeightMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KPM_WM}Weight Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KPM_WMH}Multiply item weight by the multiplier [Native: 1.0(100%)].")]
        [SettingPropertyGroup("{=KPM_Bullets}Bullets")]
        public float BulletsWeightMultiplier { get; set; } = 1.0f;

        /*
                [SettingPropertyBool("{=KPM_MTWFE}Thrown Mission stack Fix Enabled", Order = 1, RequireRestart = false,
                    HintText = "{KPM_MTWFEH}Enables a temp fix for thrown weapon stack sizes in missions")]
                [SettingPropertyGroup("{=KPM_WorkAround}Work around")]
                public bool BulletsMissionFixMultiplierEnabled { get; set; } = false;*/
        #endregion


        //~ Presets
        #region Presets
        public override IEnumerable<ISettingsPreset> GetBuiltInPresets()
        {
            foreach (var preset in base.GetBuiltInPresets())
            {
                yield return preset;
            }

            yield return new MemorySettingsPreset(Id, "native all off", "Native All Off", () => new Config
            {

            });


            yield return new MemorySettingsPreset(Id, "native all on", "Native All On", () => new Config
            {
                //TownFoodBonus = 4.0f,
                //SettlementFoodBonusEnabled = true,
                //SettlementProsperityFoodMalusDivisor = 100
            });
        }
        #endregion


        private void Settings_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Change log to file to false if debug is false. IF build mode is debug sets log to file to true if debug is true
            if (e.PropertyName == nameof(Debug))
            {
                if (Debug == false)
                {
                    LogToFile = false;
                }
                else
                {
                }
            }

            CoreConfig config = CoreFactory.Settings;
            Type typModelCls = this.GetType(); //trans is the object name
            foreach (PropertyInfo prop in typModelCls.GetProperties())
            {
                if (typeof(CoreConfig).GetProperty(prop.Name) != null)
                {
                    if (prop.ToString().Contains("MCM.Common.Dropdown"))
                    {
                        // Set any Drop downs manually here
                        //config.DropDownName = DropDownName.SelectedValue.ToString();
                    }
                    else
                    {
                        typeof(CoreConfig).GetProperty(prop.Name).SetValue(config, prop.GetValue(this, null));

                    }
                }
            }

        }

        public void DupValues()
        {

            CoreConfig config = CoreFactory.Settings;
            Type typModelCls = this.GetType(); //trans is the object name
            foreach (PropertyInfo prop in typModelCls.GetProperties())
            {
                if (typeof(CoreConfig).GetProperty(prop.Name) != null)
                {
                    string message = "Name: " + prop.Name + " : ";
                    if (!prop.ToString().Contains("MCM.Common.Dropdown"))
                    {
                        message += prop.GetValue(this, null) + "  Core: " + typeof(CoreConfig).GetProperty(prop.Name).GetValue(config, null).ToString();
                    }
                    else
                    {
                        //message += DropDownName.SelectedValue.ToString() + " core: " + config.DropDownName;
                    }
                    Factory.IM.MessageDebug(message);
                    Factory.IM.Lm(message);
                }
            }
        }

        public void DebugConfigProperties()
        {
            Type typModelCls = this.GetType(); //trans is the object name
            foreach (PropertyInfo prop in typModelCls.GetProperties())
            {
                Factory.IM.MessageDebug("Name: " + prop.Name + " : " + prop.GetValue(this, null));
            }
        }

    }
}

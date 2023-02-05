using KaosesMoreAmmoCore.Objects;
using KaosesMoreAmmoCore.Settings;
using TaleWorlds.Core;

using CoreConfig = KaosesMoreAmmoCore.Settings.KaosesMoreAmmoCoreConfig;
using CoreFactory = KaosesMoreAmmoCore.Objects.KaosesMoreAmmoCoreFactory;

namespace KaosesMoreAmmoCore.Projectiles
{
    public class Arrows
    {
        public static CoreConfig? _settings;
        protected ItemObject? _item;

        public Arrows(ItemObject item)
        {
            _settings = CoreFactory.Settings;
            _item = item;
            if (_item != null)
            {
                if (_settings.ArrowMultiplierEnabled)
                {
                    this.CalculateStack();
                }
                if (_settings.ArrowValueMultiplierEnabled)
                {
                    this.CalculateValue();
                }
                if (_settings.ArrowWeightMultiplierEnabled)
                {
                    this.CalculateWeight();
                }
            }

        }

        public void CalculateStack()
        {
            WeaponComponentData weaponData = _item.PrimaryWeapon;
            float tmpMax = weaponData.MaxDataValue * _settings.ArrowMultiplier;
            short newMax = (short)tmpMax;
            typeof(WeaponComponentData).GetProperty("MaxDataValue").SetValue(weaponData, newMax);
        }

        public void CalculateValue()
        {
            int Oldvalue = _item.Value;
            int value = _item.Value;
            float tmpValue = _item.Value * _settings.ArrowValueMultiplier;
            int newValue = (int)tmpValue;
            typeof(ItemObject).GetProperty("Value").SetValue(_item, newValue);

            //Ux.ShowMessageInfo("old value: " + Oldvalue + "  new value: " + newValue);
            //Logging.Lm("old value: " + Oldvalue + "  new value: " + newValue);
        }

        public void CalculateWeight()
        {
            float tmpValue = _item.Weight * _settings.ArrowWeightMultiplier;
            typeof(ItemObject).GetProperty("Weight").SetValue(_item, tmpValue);
        }

    }
}

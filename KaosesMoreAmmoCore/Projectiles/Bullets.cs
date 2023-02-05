using KaosesMoreAmmoCore.Objects;
using KaosesMoreAmmoCore.Settings;
using TaleWorlds.Core;

using CoreConfig = KaosesMoreAmmoCore.Settings.KaosesMoreAmmoCoreConfig;
using CoreFactory = KaosesMoreAmmoCore.Objects.KaosesMoreAmmoCoreFactory;


namespace KaosesMoreAmmoCore.Projectiles
{
    public class Bullets
    {
        public static CoreConfig? _settings;
        protected ItemObject? _item;

        public Bullets(ItemObject item)
        {
            _settings = CoreFactory.Settings;
            _item = item;
            if (_item != null)
            {
                if (_settings.ThrownMultiplierEnabled)
                {
                    this.CalculateStack();
                }
                if (_settings.ThrownValueMultiplierEnabled)
                {
                    this.CalculateValue();
                }
                if (_settings.ThrownWeightMultiplierEnabled)
                {
                    this.CalculateWeight();
                }
            }

        }

        public void CalculateStack()
        {
            WeaponComponentData weaponData = _item.PrimaryWeapon;
            float tmpMax = weaponData.MaxDataValue * _settings.ThrownMultiplier;
            short newMax = (short)tmpMax;
            typeof(WeaponComponentData).GetProperty("MaxDataValue").SetValue(weaponData, newMax);
        }

        public void CalculateValue()
        {
            _ = _item.Value;
            float tmpValue = _item.Value * _settings.ThrownValueMultiplier;
            int newValue = (int)tmpValue;
            typeof(ItemObject).GetProperty("Value").SetValue(_item, newValue);
        }
        public void CalculateWeight()
        {
            float tmpValue = _item.Weight * _settings.ThrownWeightMultiplier;
            typeof(ItemObject).GetProperty("Weight").SetValue(_item, tmpValue);
        }

    }
}

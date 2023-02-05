using KaosesCommon.Utils;
using KaosesMoreAmmoCore.Projectiles;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using static TaleWorlds.Core.ItemObject;

namespace KaosesMoreAmmoCore.Behaviors
{
    public class KaosesProjctilesCampaignBehaviors : CampaignBehaviorBase
    {
        //private readonly MbEvent<ItemObject, Crafting.OverrideData> _onNewItemCraftedEvent = new MbEvent<ItemObject, Crafting.OverrideData>();
        public override void RegisterEvents()
        {
            try
            {
                CampaignEvents.OnNewItemCraftedEvent.AddNonSerializedListener(this, OnNewItemCraftedEvent);
            }
            catch (Exception ex)
            {
                //Handle exceptions
                IM.MessageError("Kaoses Projectiles Fatal error on RegisterEvents" + ex.ToString());
            }
        }

        public override void SyncData(IDataStore dataStore)
        {

        }

        private void OnNewItemCraftedEvent(ItemObject itemObject, Crafting.OverrideData overrideData, bool isCraftingOrderItem)
        {
            if (itemObject != null)
            {
                if (itemObject.ItemType == ItemTypeEnum.Thrown)
                {
                    Thrown thrown = new Thrown(itemObject);
                }
            }
            if (overrideData != null)
            {

            }
        }

    }
}

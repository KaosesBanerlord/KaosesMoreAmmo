﻿using HarmonyLib;
using KaosesCommon;
using KaosesCommon.Utils;
using KaosesMoreAmmo;
using KaosesMoreAmmo.Objects;
using KaosesMoreAmmo.Settings;
using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using KaosesMoreAmmoCore.Projectiles;
using static TaleWorlds.Core.ItemObject;

using CoreConfig = KaosesMoreAmmoCore.Settings.KaosesMoreAmmoCoreConfig;
using CoreFactory = KaosesMoreAmmoCore.Objects.KaosesMoreAmmoCoreFactory;
using KaosesMoreAmmoCore.Behaviors;

namespace KaosesMoreAmmo
{
    /// <summary>
    /// KaosesTemp Mod
    /// </summary>
    public class SubModule : MBSubModuleBase
    {
        public const bool UsesHarmony = true;
        public const string ModuleId = "KaosesTemp";
        public const string modulePath = @"..\\..\\Modules\\" + ModuleId + "\\";
        public const string HarmonyId = ModuleId + ".harmony";
        private Harmony? _harmony;

        /// <summary>
        /// Called just before the main menu first appears, helpful if your mod depends on other things being set up during the initial load
        /// </summary>
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            new Init();
            try
            {
                if (UsesHarmony)
                {
                    if (Kaoses.IsHarmonyLoaded())
                    {
                        Factory.IM.MessageModLoaded();
                        try
                        {
                            if (_harmony == null)
                            {
                                Harmony.DEBUG = Factory.Settings.IsHarmonyDebug;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                                _harmony = new Harmony(ModuleId);
                                _harmony.PatchAll(Assembly.GetExecutingAssembly());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                            }

                        }
                        catch (Exception ex)
                        {
                            Factory.IM.ShowError(ex, Factory.Settings.ModName + " Harmony Error:");
                        }
                    }
                    else { Factory.IM.MessageHarmonyLoadError(); }
                }
                else
                {
#pragma warning disable CS0162 // Unreachable code detected
                    Factory.IM.MessageModLoaded();
#pragma warning restore CS0162 // Unreachable code detected
                }
            }
            catch (Exception ex)
            {
                Factory.IM.ShowError(ex, "initial Loading Error " + Factory.Settings.ModName);
            }
        }

        /// <summary>
        /// Called during the first loading screen of the game, always the first override to be called, 
        /// this is where you should be doing the bulk of your initial setup
        /// </summary>
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
        }

        /// <summary>
        /// Called once the initialization for a game mode has finished
        /// Called 4th after choosing (Resume Game, Campaign, Custom Battle) from the main menu.
        /// </summary>
        /// <param name="game"></param>
        public override void OnGameInitializationFinished(Game game)
        {

            base.OnGameInitializationFinished(game);
            if (!(game.GameType is Campaign))
            {
                return;
            }

            if (game.GameType is Campaign gameType)
            {
                foreach (ItemObject item in TaleWorlds.CampaignSystem.Extensions.Items.All)
                {
                    if (item != null)
                    {
                        if (item.ItemType == ItemTypeEnum.Arrows || item.ItemType == ItemTypeEnum.Bolts || item.ItemType == ItemTypeEnum.Thrown)
                        {
                            if (item.ItemType == ItemTypeEnum.Arrows)
                            {
                                _ = new Arrows(item);
                            }

                            if (item.ItemType == ItemTypeEnum.Bolts)
                            {
                                _ = new Bolts(item);
                            }

                            if (item.ItemType == ItemTypeEnum.Thrown)
                            {
                                _ = new Thrown(item);
                            }
                            if (item.ItemType == ItemTypeEnum.Bullets)
                            {
                                _ = new Bullets(item);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Called immediately upon loading after selecting a game mode (submodule) from the main menu
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameStarter"></param>
        protected override void OnGameStart(Game game, IGameStarter gameStarter)
        {
            base.OnGameStart(game, gameStarter);
            Config settings = Factory.Settings;
            if (game.GameType is Campaign)
            {
                CampaignGameStarter campaignGameStarter = (CampaignGameStarter)gameStarter;
                campaignGameStarter.AddBehavior(new KaosesProjctilesCampaignBehaviors());
            }
        }

        /// <summary>
        /// Called immediately after loading the selected game mode (submodule) has completed
        /// </summary>
        /// <param name="game"></param>
        public override void BeginGameStart(Game game)
        {
            base.BeginGameStart(game);
        }

        /// <summary>
        /// Called seemingly as loading is ending, not entirely sure of this one
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public override bool DoLoading(Game game)
        {
            return base.DoLoading(game);
        }

        /// <summary>
        /// Called once any game mode is started
        /// </summary>
        /// <param name="game"></param>
        /// <param name="starterObject"></param>
        public override void OnCampaignStart(Game game, object starterObject)
        {
            base.OnCampaignStart(game, starterObject);
        }

        /// <summary>
        /// Called on exiting out of a mission/campaign
        /// </summary>
        /// <param name="game"></param>
        public override void OnGameEnd(Game game)
        {
            base.OnGameEnd(game);
        }

        /// <summary>
        /// Called only after loading a save
        /// </summary>
        /// <param name="game"></param>
        /// <param name="initializerObject"></param>
        public override void OnGameLoaded(Game game, object initializerObject)
        {
            base.OnGameLoaded(game, initializerObject);
        }

        /// <summary>
        /// Called when starting a new save in the campaign mode specifically
        /// </summary>
        /// <param name="game"></param>
        /// <param name="initializerObject"></param>
        public override void OnNewGameCreated(Game game, object initializerObject)
        {
            base.OnNewGameCreated(game, initializerObject);
        }

        /// <summary>
        /// This is called once every frame, you should avoid expensive operations being called directly here and 
        /// instead do as little work as possible for performance reasons.
        /// </summary>
        /// <param name="dt">The time in milliseconds the frame took to complete</param> 
        public override void OnMissionBehaviorInitialize(Mission mission)
        {

        }


        /// <summary>
        /// Called when exiting Bannerlord entirely
        /// </summary>
        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
        }
    }
}
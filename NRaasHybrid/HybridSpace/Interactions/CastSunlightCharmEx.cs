﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using NRaas.HybridSpace.Helpers;
using NRaas.HybridSpace.Interfaces;
using NRaas.HybridSpace.MagicControls;
using NRaas.HybridSpace.Proxies;
using Sims3.Gameplay;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Objects.Alchemy;
using Sims3.Gameplay.Skills;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.UI;
using Sims3.UI.Hud;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.HybridSpace.Interactions
{
    public class CastSunlightCharmEx : MagicWand.CastSunlightCharm, IMagicalInteraction, Common.IPreLoad, Common.IAddInteraction
    {
        static InteractionDefinition sOldSingleton;

        CastSpellProxy<CastSunlightCharmEx> mProxy = new CastSpellProxy<CastSunlightCharmEx>();

        public void OnPreLoad()
        {
            Tunings.Inject<Sim, MagicWand.CastSunlightCharm.Definition, Definition>(false);

            sOldSingleton = MagicWand.CastSunlightCharm.Singleton;
            MagicWand.CastSunlightCharm.Singleton = new Definition();
        }

        public void AddInteraction(Common.InteractionInjectorList interactions)
        {
            interactions.Replace<Sim, MagicWand.CastSunlightCharm.Definition>(MagicWand.CastSunlightCharm.Singleton);
        }

        public MagicWand Wand
        {
            set { mWand = value; }
        }

        public override bool Run()
        {
            try
            {
                return mProxy.Run(this);
            }
            catch (ResetException)
            {
                throw;
            }
            catch (Exception e)
            {
                Common.Exception(Actor, Target, e);
                return false;
            }
        }

        public override void Cleanup()
        {
            base.Cleanup();

            mProxy.Cleanup();
        }

        public new class Definition : MagicWand.CastSunlightCharm.Definition, IMagicalDefinition
        {
            static PersistedSettings.SpellSettings sSettings;

            public override InteractionInstance CreateInstance(ref InteractionInstanceParameters parameters)
            {
                InteractionInstance na = new CastSunlightCharmEx();
                na.Init(ref parameters);
                return na;
            }

            public override string GetInteractionName(Sim actor, Sim target, InteractionObjectPair iop)
            {
                return base.GetInteractionName(actor, target, new InteractionObjectPair(sOldSingleton, target));
            }

            public override bool Test(Sim a, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                if ((isAutonomous) && (a == target))
                {
                    if (OccultTypeHelper.HasType(a, OccultTypes.Vampire)) return false;
                }

                MagicControl control = MagicControl.GetBestControl(a, this);
                if (control == null)
                {
                    greyedOutTooltipCallback = Common.DebugTooltip("No Control");
                    return false;
                }

                return CastSpellEx.CommonSpellTests(a, target, isAutonomous, ref greyedOutTooltipCallback);
            }

            public MagicControl IntendedControl
            {
                get { return WitchControl.sControl; }
            }

            public PersistedSettings.SpellSettings DefaultSettings
            {
                get
                {
                    return new PersistedSettings.SpellSettings(OccultTypes.Witch, MagicWand.kSpellLevels[0x2], CastSunlightCharmEx.kMotiveDrain, 0);
                }
            }

            public PersistedSettings.SpellSettings SpellSettings
            {
                get
                {
                    return sSettings;
                }
                set
                {
                    sSettings = value;
                }
            }
        }
    }
}

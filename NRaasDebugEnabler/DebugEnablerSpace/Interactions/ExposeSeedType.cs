﻿using NRaas.CommonSpace.Interactions;
using NRaas.DebugEnablerSpace.Interfaces;
using Sims3.Gameplay;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Controllers;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.ObjectComponents;
using Sims3.Gameplay.Objects.FoodObjects;
using Sims3.Gameplay.Objects.Gardening;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.StoryProgression;
using Sims3.Gameplay.Utilities;
using Sims3.Gameplay.UI;
using Sims3.SimIFace;
using Sims3.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.DebugEnablerSpace.Interactions
{
    public class ExposeSeedType : DebugEnablerInteraction<GameObject>
    {
        public static readonly InteractionDefinition Singleton = new Definition();

        public override void AddPair(GameObject obj, List<InteractionObjectPair> list)
        {
            if (obj is IHarvestable)
            {
                list.Add(new InteractionObjectPair(Singleton, obj));
            }
        }

        public override bool Run()
        {
            try
            {
                PlantableComponent component = Target.GetComponent<PlantableComponent>();
                if (component == null) return false;

                component.PlayerKnowledgeOfPlantableType = PlayerDisclosure.Exposed;
            }
            catch (Exception e)
            {
                Common.Exception(Actor, Target, e);
            }
            return true;
        }

        [DoesntRequireTuning]
        private class Definition : DebugEnablerDefinition<ExposeSeedType>
        {
            // Methods
            public Definition()
            { }

            public override string GetInteractionName(IActor a, GameObject target, InteractionObjectPair interaction)
            {
                return Common.Localize("ExposeSeed:MenuName");
            }

            public override bool Test(IActor a, GameObject target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                if (!base.Test(a, target, isAutonomous, ref greyedOutTooltipCallback)) return false;

                IHarvestable plant = target as IHarvestable;
                if (plant == null) return false;

                if (!plant.IsSeed) return false;

                PlantableComponent component = target.GetComponent<PlantableComponent>();
                if (component == null) return false;

                return (component.PlayerKnowledgeOfPlantableType == PlayerDisclosure.Concealed);
            }
        }
    }
}
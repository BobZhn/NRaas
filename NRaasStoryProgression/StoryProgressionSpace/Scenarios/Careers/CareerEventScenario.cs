﻿using NRaas.StoryProgressionSpace.Careers;
using NRaas.StoryProgressionSpace.Interfaces;
using NRaas.StoryProgressionSpace.Managers;
using NRaas.CommonSpace.ScoringMethods;
using NRaas.StoryProgressionSpace.Scoring;
using NRaas.StoryProgressionSpace.SimDataElement;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Careers;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Objects;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.StoryProgressionSpace.Scenarios.Careers
{
    public abstract class CareerEventScenario : SimEventScenario<CareerEvent>
    {
        protected CareerEventScenario()
        { }
        protected CareerEventScenario(CareerEventScenario scenario)
            : base (scenario)
        { }

        protected override bool Allow(SimDescription sim)
        {
            if (Event.Career == null)
            {
                IncStat("No Career");
                return false;
            }
            else if (!ManagerCareer.ValidCareer(Event.Career))
            {
                IncStat("No Job");
                return false;
            }

            return base.Allow(sim);
        }
    }
}

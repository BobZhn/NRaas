using NRaas.StoryProgressionSpace.Interfaces;
using NRaas.StoryProgressionSpace.Managers;
using NRaas.StoryProgressionSpace.Personalities;
using NRaas.StoryProgressionSpace.Scenarios.Romances;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.UI;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.UI;
using System;
using System.Collections.Generic;

namespace NRaas.StoryProgressionSpace.Options
{
    public class DisallowPersonalityOption : PersonalityBaseOption, IReadSimLevelOption, IWriteSimLevelOption, IHouseLevelSimOption
    {
        public DisallowPersonalityOption()
        { }

        public override string GetTitlePrefix()
        {
            return "DisallowPersonality";
        }

        protected override string ValuePrefix
        {
            get { return "Disallowed"; }
        }

        public override bool ShouldDisplay()
        {
            if (!GetValue<AllowPersonalityOption, bool>()) return false;

            return base.ShouldDisplay();
        }
    }
}


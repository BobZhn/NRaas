using NRaas.CommonSpace.Helpers;
using NRaas.StoryProgressionSpace.Interfaces;
using NRaas.StoryProgressionSpace.Managers;
using Sims3.Gameplay;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.UI;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using System;
using System.Collections.Generic;

namespace NRaas.StoryProgressionSpace.Options
{
    public class CasteTypeOption : SimTypeOption, IReadCasteLevelOption, IWriteCasteLevelOption, ISimCasteOption, ICasteFilterOption
    {
        public CasteTypeOption()
            : base(new SimType[0])
        { }

        public override string GetTitlePrefix()
        {
            return "CasteType";
        }

        public override bool ShouldDisplay()
        {
            if ((!GetValue<CasteAutoOption, bool>()) && (!GetValue<CasteInheritedOption, bool>())) return false;

            return base.ShouldDisplay();
        }
    }
}


﻿using NRaas.CommonSpace.Options;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.WoohooerSpace.Options.Woohoo
{
    public class ListingOption : OptionList<IWoohooOption>, IPrimaryOption<GameObject>
    {
        public override string GetTitlePrefix()
        {
            return "WoohooInteraction";
        }

        public override ITitlePrefixOption ParentListingOption
        {
            get { return null; }
        }

        public override List<IWoohooOption> GetOptions()
        {
            List<IWoohooOption> results = base.GetOptions();

            results.Add(new SpeciesListingOption(CASAgeGenderFlags.Human));
            results.Add(new SpeciesListingOption(CASAgeGenderFlags.Horse));
            results.Add(new SpeciesListingOption(CASAgeGenderFlags.Cat));
            results.Add(new SpeciesListingOption(CASAgeGenderFlags.Dog));

            return results;
        }
    }
}

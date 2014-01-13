﻿using NRaas.CommonSpace.Options;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Skills;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.VectorSpace.Options.Doctors
{
    public class DoctorsVisitCostSetting : IntegerSettingOption<GameObject>, IDoctorsOption
    {
        protected override int Value
        {
            get
            {
                return Vector.Settings.mDoctorsVisitCost;
            }
            set
            {
                Vector.Settings.mDoctorsVisitCost = value;
            }
        }

        public override string GetTitlePrefix()
        {
            return "DoctorsVisitCost";
        }

        public override ITitlePrefixOption ParentListingOption
        {
            get { return new ListingOption(); }
        }
    }
}

﻿using NRaas.CommonSpace.Dialogs;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.MapTags;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using Sims3.UI.CAS;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.MasterControllerSpace.SelectionCriteria
{
    public class SimNoTrait : SimTraitBase<SimNoTrait.Item>
    {
        public override string GetTitlePrefix()
        {
            return "Criteria.NoTrait";
        }

        public class Item : SimTraitBase<SimNoTrait.Item>.ItemBase
        {
            public Item()
            { }
            public Item(TraitNames guid, int count)
                : base(guid, count)
            { }

            public override bool Test(IMiniSimDescription me, bool fullFamily, IMiniSimDescription actor)
            {
                // Inverted
                return !base.Test(me, fullFamily, actor);
            }
        }
    }
}

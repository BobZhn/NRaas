using NRaas.CommonSpace.Options;
using NRaas.StoryProgressionSpace.Helpers;
using NRaas.StoryProgressionSpace.Interfaces;
using NRaas.StoryProgressionSpace.Managers;
using NRaas.StoryProgressionSpace.Options;
using NRaas.StoryProgressionSpace.Scenarios.Lots;
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

namespace NRaas.StoryProgressionSpace.Options.Immigration
{
    public class NameTakeOption<TManager> : NameTakeBaseOption<TManager>, ISimFromBinOption<TManager>
        where TManager : StoryProgressionObject, ISimFromBinManager
    {
        SimFromBinController mController;

        public NameTakeOption()
            : base(NameTakeType.FemMale)
        { }

        public override string GetTitlePrefix()
        {
            return "ImmigrantName";
        }

        protected override string GetLocalizationValueKey()
        {
            return "ImmigrantNameTakeType";
        }

        public SimFromBinController Controller
        {
            set { mController = value; }
        }

        public override bool ShouldDisplay()
        {
            if (!mController.ShouldDisplayImmigrantOptions()) return false;

            return base.ShouldDisplay();
        }
    }
}


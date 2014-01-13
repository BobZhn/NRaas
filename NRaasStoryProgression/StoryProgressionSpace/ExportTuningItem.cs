﻿using NRaas.CommonSpace.Helpers;
using NRaas.StoryProgressionSpace.Interfaces;
using NRaas.StoryProgressionSpace.Managers;
using Sims3.Gameplay;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRaas.StoryProgressionSpace
{
    public class ExportTuningOption : StringManagerOptionItem<Main>, INotPersistableOption
    {
        public ExportTuningOption()
            : base(null)
        { }

        public override bool ShouldDisplay()
        {
            return true;
        }

        public override string GetTitlePrefix()
        {
            return "ExportTuning";
        }

        protected override bool PrivatePerform()
        {
            Common.WriteLog(FilePersistence.ExportContents(), false);

            SimpleMessageDialog.Show(Common.Localize("ExportSettings:MenuName"), Common.Localize("ExportSettings:Success"));
            return true;
        }
    }
}

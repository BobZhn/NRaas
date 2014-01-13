﻿using NRaas.CommonSpace.Helpers;
using NRaas.CommonSpace.Options;
using NRaas.RetunerSpace.Helpers.FieldInfos;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Skills;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.RetunerSpace.Options.Tunable.Fields
{
    public class TunableFloatOption : TunableGenericOption<float>
    {
        public TunableFloatOption()
        { }
        public TunableFloatOption(TunableFieldInfo field)
            : base(field)
        { }

        public override string GetTitlePrefix()
        {
            return "TunableFloat";
        }

        public override string DisplayValue
        {
            get
            {
                return EAText.GetNumberString(Value);
            }
        }

        public override void SetField(FieldInfo field, XmlDbRow row)
        {
            field.SetValue(null, row.GetFloat("Value"));
        }

        protected override OptionResult Convert(string value, out float result)
        {
            if (!float.TryParse(value, out result))
            {
                SimpleMessageDialog.Show(Name, Common.Localize("Numeric:Error"));
                return OptionResult.Failure;
            }

            return OptionResult.SuccessRetain;
        }

        public override ITunableConvertOption Clone(TunableFieldInfo field)
        {
            return new TunableFloatOption(field);
        }
    }
}

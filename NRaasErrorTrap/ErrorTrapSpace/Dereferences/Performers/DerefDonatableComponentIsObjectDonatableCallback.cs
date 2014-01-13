﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.ObjectComponents;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefDonatableComponentIsObjectDonatableCallback : Dereference<DonatableComponent.IsObjectDonatableCallback>
    {
        protected override DereferenceResult Perform(DonatableComponent.IsObjectDonatableCallback reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            return DereferenceResult.Continue;
        }
    }
}

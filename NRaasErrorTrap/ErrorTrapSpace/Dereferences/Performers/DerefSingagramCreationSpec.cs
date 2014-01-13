﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.ActiveCareer.ActiveCareers;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefSingagramCreationSpec : Dereference<SingagramCreationSpec>
    {
        protected override DereferenceResult Perform(SingagramCreationSpec reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            if (Matches(reference, "Target", field, objects))
            {
                Remove(ref reference.Target);
                return DereferenceResult.Continue;
            }

            return DereferenceResult.Failure;
        }
    }
}

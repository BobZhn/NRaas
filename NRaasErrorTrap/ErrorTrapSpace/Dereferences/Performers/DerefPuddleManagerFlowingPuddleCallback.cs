﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Controllers;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefPuddleManagerFlowingPuddleCallback : Dereference<PuddleManager.FlowingPuddleCallback>
    {
        protected override DereferenceResult Perform(PuddleManager.FlowingPuddleCallback reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            if (Matches(reference, "mSource", field, objects))
            {
                Remove(ref reference.mSource);
                return DereferenceResult.ContinueIfReferenced;
            }

            return DereferenceResult.Failure;
        }
    }
}

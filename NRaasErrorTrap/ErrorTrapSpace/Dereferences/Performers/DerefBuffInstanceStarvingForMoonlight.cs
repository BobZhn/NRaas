﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefBuffInstanceStarvingForMoonlight : Dereference<BuffStarvingForMoonlight.BuffInstanceStarvingForMoonlight>
    {
        protected override DereferenceResult Perform(BuffStarvingForMoonlight.BuffInstanceStarvingForMoonlight reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            ReferenceWrapper result;
            if (Matches(reference, "mOwner", field, objects, out result) != MatchResult.Failure)
            {
                if (Performing)
                {
                    if (result.Valid)
                    {
                        Remove(ref reference.mOwner);
                    }
                    return DereferenceResult.ContinueIfReferenced;
                }
                else
                {
                    return DereferenceResult.Found;
                }
            }

            return DereferenceResult.Failure;
        }
    }
}

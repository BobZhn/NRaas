﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Objects.CookingObjects;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefCake : Dereference<Cake>
    {
        protected override DereferenceResult Perform(Cake reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            if (Matches(reference, "mBirthdaySim", field, objects))
            {
                Remove(ref reference.mBirthdaySim);
                return DereferenceResult.End;
            }

            return DereferenceResult.Failure;
        }
    }
}

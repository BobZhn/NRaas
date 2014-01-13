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
    public class DerefFoodTray : Dereference<FoodTray>
    {
        protected override DereferenceResult Perform(FoodTray reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            if (Matches(reference, "mCookingProcess", field, objects))
            {
                Remove(ref reference.mCookingProcess);
                return DereferenceResult.End;
            }

            return DereferenceResult.Failure;
        }
    }
}

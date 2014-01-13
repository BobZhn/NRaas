﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Objects.Vehicles;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefParkingSpace : Dereference<ParkingSpace>
    {
        protected override DereferenceResult Perform(ParkingSpace reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            ReferenceWrapper result;
            if (Matches(reference, "mReservedVehicle", field, objects, out result) != MatchResult.Failure)
            {
                if (result.Valid)
                {
                    Remove(ref reference.mReservedVehicle);
                }
                return DereferenceResult.End;
            }

            return DereferenceResult.Failure;
        }
    }
}

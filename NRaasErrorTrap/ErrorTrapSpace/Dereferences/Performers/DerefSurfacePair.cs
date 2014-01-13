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
    public class DerefSurfacePair : Dereference<SurfacePair>
    {
        protected override DereferenceResult Perform(SurfacePair reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            if (Matches(reference, "ScriptObjectOn", field, objects))
            {
                // struct
                //Remove(ref reference.ScriptObjectOn);
                return DereferenceResult.Continue;
            }

            return DereferenceResult.Failure;
        }
    }
}

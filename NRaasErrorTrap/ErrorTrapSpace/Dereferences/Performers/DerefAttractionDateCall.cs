﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefAttractionDateCall : Dereference<AttractionDateCall>
    {
        protected override DereferenceResult Perform(AttractionDateCall reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            if (Matches(reference, "mCallingSimDesc", field, objects))
            {
                if (Performing)
                {
                    Remove(ref reference.mCallingSimDesc);
                }
                return DereferenceResult.ContinueIfReferenced;
            }

            return DereferenceResult.Failure;
        }
    }
}

﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Objects.HobbiesSkills;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefHorseJumpDoJump : Dereference<HorseJump.DoJump>
    {
        protected override DereferenceResult Perform(HorseJump.DoJump reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            if (Matches(reference, "mRider", field, objects))
            {
                Remove(ref reference.mRider);
                return DereferenceResult.ContinueIfReferenced;
            }

            return DereferenceResult.Failure;
        }
    }
}

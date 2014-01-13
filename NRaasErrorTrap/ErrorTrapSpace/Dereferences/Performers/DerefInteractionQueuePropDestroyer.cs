﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefInteractionQueuePropDestroyer : Dereference<InteractionQueue.PropDestroyer>
    {
        protected override DereferenceResult Perform(InteractionQueue.PropDestroyer reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            if (Matches(reference, "i", field, objects))
            {
                return DereferenceResult.ContinueIfReferenced;
            }

            return DereferenceResult.Failure;
        }
    }
}

﻿using Smafac.Framework.Core.Repositories.Property;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Repositories.Property
{
    class DeliveryNotePropertyDeleteRepository : PropertyDeleteRepository<DeliveryNoteContext, DeliveryNotePropertyEntity>, IDeliveryNotePropertyDeleteRepository
    {
        public DeliveryNotePropertyDeleteRepository(IDeliveryNoteContextProvider orderContextProvider)
        {
            base.ContextProvider = orderContextProvider;
        }
    }
}

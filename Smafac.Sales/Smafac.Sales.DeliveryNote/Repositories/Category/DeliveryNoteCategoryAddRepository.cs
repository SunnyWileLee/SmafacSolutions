﻿using Smafac.Framework.Core.Repositories.Category;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Repositories.Category
{
    class DeliveryNoteCategoryAddRepository : CategoryAddRepository<DeliveryNoteContext, DeliveryNoteCategoryEntity>, IDeliveryNoteCategoryAddRepository
    {
        public DeliveryNoteCategoryAddRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider  = contextProvider;
        }
    }
}

﻿using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Pms.Purchase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Repositories.CategoryProperty
{
    class PurchaseCategoryPropertyBindRepository : CategoryPropertyBindRepository<PurchaseContext, PurchaseCategoryEntity, PurchasePropertyEntity, PurchaseCategoryPropertyEntity>,
                                                IPurchaseCategoryPropertyBindRepository
    {
        public PurchaseCategoryPropertyBindRepository(IPurchaseContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}

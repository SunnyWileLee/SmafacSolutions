﻿using Smafac.Framework.Core.Repositories.Category;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.Category
{
    class OrderCategorySearchRepository : CategorySearchRepository<OrderContext, OrderCategoryEntity>, IOrderCategorySearchRepository
    {
        public OrderCategorySearchRepository(IOrderContextProvider orderContextProvider)
        {
            base.ContextProvider = orderContextProvider;
        }
    }
}
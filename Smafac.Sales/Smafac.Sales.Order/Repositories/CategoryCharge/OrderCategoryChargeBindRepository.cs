using Smafac.Framework.Core.Repositories.CategoryAssociation;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.CategoryCharge
{
    class OrderCategoryChargeBindRepository : CategoryAssociationBindRepository<OrderContext, OrderCategoryEntity, OrderChargeEntity, OrderCategoryChargeEntity>,
                                                IOrderCategoryChargeBindRepository
    {
        public OrderCategoryChargeBindRepository(IOrderContextProvider orderContextProvider)
        {
            base.ContextProvider = orderContextProvider;
        }
    }
}

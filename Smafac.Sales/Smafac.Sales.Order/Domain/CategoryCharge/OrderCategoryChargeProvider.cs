using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.Category;
using Smafac.Sales.Order.Repositories.CategoryCharge;
using Smafac.Sales.Order.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain.CategoryCharge
{
    class OrderCategoryChargeProvider :
                                CategoryAssociationProvider<OrderCategoryEntity, OrderChargeEntity, OrderChargeModel>,
                                IOrderCategoryChargeProvider
    {
        public OrderCategoryChargeProvider(IOrderCategoryChargeSearchRepository orderCategoryPropertySearchRepository,
                                           IOrderCategorySearchRepository orderCategorySearchRepository)
        {
            base.CategorySearchRepository = orderCategorySearchRepository;
            base.CategoryAssociationSearchRepository = orderCategoryPropertySearchRepository;
        }
    }
}

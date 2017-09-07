using Smafac.Framework.Core.Services.CategoryAssociation;
using Smafac.Sales.Order.Applications.CategoryCharge;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Domain.CategoryCharge;
using Smafac.Sales.Order.Domain.Charge;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.CategoryCharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Services.CategoryCharge
{
    class OrderCategoryChargeSearchService : CategoryAssociationSearchService<OrderCategoryEntity, OrderChargeEntity, OrderChargeModel>,
                                                IOrderCategoryChargeSearchService
    {
        public OrderCategoryChargeSearchService(IOrderCategoryChargeSearchRepository orderCategoryChargeSearchRepository,
            IOrderCategoryChargeProvider orderCategoryChargeProvider
            )
        {

            base.CategoryAssociationProvider = orderCategoryChargeProvider;
            base.EntityAssociationSearchRepository = orderCategoryChargeSearchRepository;
        }
    }
}

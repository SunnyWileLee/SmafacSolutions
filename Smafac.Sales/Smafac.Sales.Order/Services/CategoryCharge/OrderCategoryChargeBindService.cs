using Smafac.Framework.Core.Services.CategoryAssociation;
using Smafac.Sales.Order.Applications.CategoryCharge;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Domain.CategoryCharge;
using Smafac.Sales.Order.Domain.Charge;
using Smafac.Sales.Order.Repositories.Category;
using Smafac.Sales.Order.Repositories.CategoryCharge;
using Smafac.Sales.Order.Repositories.Charge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Services.CategoryCharge
{
    class OrderCategoryChargeBindService : CategoryAssociationBindService<OrderCategoryEntity, OrderChargeEntity>,
                                          IOrderCategoryChargeBindService
    {
        public OrderCategoryChargeBindService(IOrderCategoryChargeBindRepository orderCategoryChargeBindRepository,
                                                IOrderCategoryChargeSearchRepository orderCategoryChargeSearchRepository,
                                                IEnumerable<IOrderCategoryChargeBindTrigger> orderCategoryChargeBindTriggers,
                                                IOrderCategorySearchRepository orderCategorySearchRepository,
                                                IOrderChargeSearchRepository orderChargeSearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = orderCategoryChargeBindRepository;
            base.EntityAssociationSearchRepository = orderCategoryChargeSearchRepository;
            base.CategoryAssociationBindTriggers = orderCategoryChargeBindTriggers;
            base.CategorySearchRepository = orderCategorySearchRepository;
            base.AssociationSearchRepository = orderChargeSearchRepository;
        }
    }
}

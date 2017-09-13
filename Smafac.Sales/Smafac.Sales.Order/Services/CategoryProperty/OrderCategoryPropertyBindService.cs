using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Sales.Order.Applications.CategoryProperty;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Domain.CategoryProperty;
using Smafac.Sales.Order.Repositories.Category;
using Smafac.Sales.Order.Repositories.CategoryProperty;
using Smafac.Sales.Order.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Services.CategoryProperty
{
    class OrderCategoryPropertyBindService : CategoryPropertyBindService<OrderCategoryEntity, OrderPropertyEntity>,
                                        IOrderCategoryPropertyBindService
    {
        public OrderCategoryPropertyBindService(IOrderCategoryPropertyBindRepository categoryPropertyBindRepository,
                                                IOrderCategoryPropertySearchRepository categoryPropertySearchRepository,
                                                IEnumerable<IOrderCategoryPropertyBindTrigger> categoryPropertyBindTriggers,
                                                IOrderCategorySearchRepository categorySearchRepository,
                                                IOrderPropertySearchRepository propertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = categoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = categoryPropertySearchRepository;
            base.CategoryAssociationBindTriggers = categoryPropertyBindTriggers;
            base.CategorySearchRepository = categorySearchRepository;
            base.AssociationSearchRepository = propertySearchRepository;
        }

    }
}

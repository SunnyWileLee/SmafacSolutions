using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Sales.Order.Applications.CategoryProperty;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Services.CategoryProperty
{
    class OrderCategoryPropertyBindService : 
                                        CategoryPropertyBindService<OrderCategoryEntity, OrderPropertyEntity>,
                                        IOrderCategoryPropertyBindService
    {
        public OrderCategoryPropertyBindService(IOrderCategoryPropertyBindRepository orderCategoryPropertyBindRepository,
                                                IOrderCategoryPropertySearchRepository orderCategoryPropertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = orderCategoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = orderCategoryPropertySearchRepository;
        }

    }
}

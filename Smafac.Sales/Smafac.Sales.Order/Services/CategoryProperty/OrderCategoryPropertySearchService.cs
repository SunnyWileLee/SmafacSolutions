using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Sales.Order.Applications.CategoryProperty;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Domain.CategoryProperty;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Services.CategoryProperty
{
    class OrderCategoryPropertySearchService : CategoryPropertySearchService<OrderCategoryEntity, OrderPropertyEntity, OrderPropertyModel>,
                                                IOrderCategoryPropertySearchService
    {
        public OrderCategoryPropertySearchService(IOrderCategoryPropertySearchRepository orderCategoryPropertySearchRepository,
            IOrderCategoryPropertyProvider orderCategoryPropertyProvider
            )
        {
           
            base.CategoryAssociationProvider = orderCategoryPropertyProvider;
            base.EntityAssociationSearchRepository = orderCategoryPropertySearchRepository;
        }
    }
}

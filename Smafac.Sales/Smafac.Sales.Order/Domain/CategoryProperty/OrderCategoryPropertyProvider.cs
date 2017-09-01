using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.Category;
using Smafac.Sales.Order.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain.CategoryProperty
{
    class OrderCategoryPropertyProvider: CategoryPropertyProvider<OrderCategoryEntity, OrderPropertyEntity, OrderPropertyModel> ,
                                        IOrderCategoryPropertyProvider
    {
        public OrderCategoryPropertyProvider(IOrderCategorySearchRepository orderCategorySearchRepository,
                                               IOrderCategoryPropertySearchRepository orderCategoryPropertySearchRepository)
        {
            base.CategorySearchRepository = orderCategorySearchRepository;
            base.CategoryAssociationSearchRepository = orderCategoryPropertySearchRepository;
        }
    }
}

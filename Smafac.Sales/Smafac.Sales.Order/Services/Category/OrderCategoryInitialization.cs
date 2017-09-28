using Smafac.Framework.Core.Services.Category;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Services.Category
{
    class OrderCategoryInitialization : CategoryInitialization<OrderCategoryEntity>
    {
        public OrderCategoryInitialization(IOrderCategoryAddRepository orderCategoryAddRepository,
                                        IOrderCategorySearchRepository orderCategorySearchRepository
                                        )
        {
            base.CategoryAddRepository = orderCategoryAddRepository;
            base.CategorySearchRepository = orderCategorySearchRepository;
        }
    }
}

using Smafac.Framework.Core.Services.Category;
using Smafac.Sales.Order.Applications.Category;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Order.Services.Category
{
    class OrderCategoryUpdateService : CategoryUpdateService<OrderCategoryEntity, OrderCategoryModel>, IOrderCategoryUpdateService
    {
        public OrderCategoryUpdateService(IOrderCategorySearchRepository orderCategorySearchRepository,
                                          IOrderCategoryUpdateRepository orderCategoryUpdateRepository)
        {
            base.CategorySearchRepository = orderCategorySearchRepository;
            base.CategoryUpdateRepository = orderCategoryUpdateRepository;
        }
    }
}

using Smafac.Framework.Core.Services.Category;
using Smafac.Sales.Order.Applications.Category;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.Category;

namespace Smafac.Wms.Order.Services.Category
{
    class OrderCategoryAddService : CategoryAddService<OrderCategoryEntity, OrderCategoryModel>, IOrderCategoryAddService
    {
        public OrderCategoryAddService(IOrderCategoryAddRepository orderCategoryAddRepository,
                                        IOrderCategorySearchRepository orderCategorySearchRepository)
        {
            base.CategoryAddRepository = orderCategoryAddRepository;
            base.CategorySearchRepository = orderCategorySearchRepository;
        }
    }
}

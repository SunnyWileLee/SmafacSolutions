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
    class OrderCategoryDeleteService : CategoryDeleteService<OrderCategoryEntity, OrderCategoryModel>, IOrderCategoryDeleteService
    {
        public OrderCategoryDeleteService(IOrderCategoryDeleteRepository orderCategoryDeleteRepository)
        {
            base.CategoryDeleteRepository = orderCategoryDeleteRepository;
        }

        protected override bool IsUsed(Guid CategoryId)
        {
            return false;
        }
    }
}

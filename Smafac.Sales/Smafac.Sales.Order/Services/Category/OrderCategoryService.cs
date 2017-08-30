using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Category;
using Smafac.Sales.Order.Applications.Category;
using Smafac.Sales.Order.Models;

namespace Smafac.Wms.Order.Services.Category
{
    class OrderCategoryService : IOrderCategoryService
    {
        private readonly IOrderCategoryAddService _orderCategoryAddService;
        private readonly IOrderCategoryDeleteService _orderCategoryDeleteService;
        private readonly IOrderCategorySearchService _orderCategorySearchService;
        private readonly IOrderCategoryUpdateService _orderCategoryUpdateService;

        public OrderCategoryService(IOrderCategoryAddService orderCategoryAddService,
            IOrderCategoryDeleteService orderCategoryDeleteService,
            IOrderCategorySearchService orderCategorySearchService,
            IOrderCategoryUpdateService orderCategoryUpdateService)
        {
            _orderCategoryAddService = orderCategoryAddService;
            _orderCategoryDeleteService = orderCategoryDeleteService;
            _orderCategorySearchService = orderCategorySearchService;
            _orderCategoryUpdateService = orderCategoryUpdateService;
        }

        public ICategoryAddService<OrderCategoryModel> AddService => _orderCategoryAddService;

        public ICategoryDeleteService<OrderCategoryModel> DeleteService => _orderCategoryDeleteService;

        public ICategoryUpdateService<OrderCategoryModel> UpdateService => _orderCategoryUpdateService;

        public ICategorySearchService<OrderCategoryModel> SearchService => _orderCategorySearchService;
    }
}

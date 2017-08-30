using Smafac.Framework.Models;
using Smafac.Sales.Order.Applications.Category;
using Smafac.Sales.Order.Applications.CategoryProperty;
using Smafac.Sales.Order.Applications.Property;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class OrderCategoryController : SmafacController
    {
        private readonly IOrderCategoryService _orderCategoryService;
        private readonly IOrderCategoryPropertyBindService _orderCategoryPropertyBindService;
        private readonly IOrderCategoryPropertySearchService _orderCategoryPropertySearchService;
        private readonly IOrderPropertyService _orderPropertyService;

        public OrderCategoryController(IOrderCategoryService orderCategoryService,
                                       IOrderCategoryPropertyBindService orderCategoryPropertyBindService,
                                       IOrderCategoryPropertySearchService orderCategoryPropertySearchService,
                                       IOrderPropertyService orderPropertyService
                                        )
        {
            _orderCategoryService = orderCategoryService;
            _orderCategoryPropertyBindService = orderCategoryPropertyBindService;
            _orderCategoryPropertySearchService = orderCategoryPropertySearchService;
            _orderPropertyService = orderPropertyService;
        }
        [HttpGet]
        public ActionResult OrderCategoryView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OrderCategorySliceView(Guid? categoryId, int slice)
        {
            CategoryModelSet<OrderCategoryModel> model = (categoryId == null || categoryId.Value == Guid.Empty)
                                         ? new CategoryModelSet<OrderCategoryModel> { Children = _orderCategoryService.SearchService.GetCategories(Guid.Empty), Category = new OrderCategoryModel { Id = Guid.Empty } }
                                         : _orderCategoryService.SearchService.GetCategoryWithChildren(categoryId.Value);
            ViewData["slice"] = slice;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrderCategory(OrderCategoryModel model)
        {
            var result = _orderCategoryService.AddService.AddCategory(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult OrderCategoryPropertyBindView(Guid categoryId)
        {
            var category = _orderCategoryService.SearchService.GetCategory(categoryId);
            ViewData["category"] = category;
            var properties = _orderPropertyService.SearchService.GetProperties();
            var bounds = _orderCategoryPropertySearchService.GetProperties(categoryId).Select(s => s.Id).ToList();
            ViewData["boundIds"] = bounds;
            return View(properties);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult BindProperties(CategoryPropertyCollectionModel model)
        {
            var result = _orderCategoryPropertyBindService.BindProperties(model.CategoryId, model.PropertyIds);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult OrderCategoryPropertyValueView(Guid categoryId)
        {
            var properties = _orderCategoryPropertySearchService.GetPropertiesIncludeParents(categoryId);
            return View(properties);
        }
    }
}
using Smafac.Framework.Models;
using Smafac.Sales.Order.Applications.Category;
using Smafac.Sales.Order.Applications.CategoryCharge;
using Smafac.Sales.Order.Applications.CategoryProperty;
using Smafac.Sales.Order.Applications.Charge;
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
        private readonly IOrderCategoryChargeBindService _orderCategoryChargeBindService;
        private readonly IOrderCategoryChargeSearchService _orderCategoryChargeSearchService;
        private readonly IOrderPropertyService _orderPropertyService;
        private readonly IOrderChargeSearchService _orderChargeSearchService;

        public OrderCategoryController(IOrderCategoryService orderCategoryService,
                                       IOrderCategoryPropertyBindService orderCategoryPropertyBindService,
                                       IOrderCategoryChargeBindService orderCategoryChargeBindService,
                                       IOrderCategoryPropertySearchService orderCategoryPropertySearchService,
                                       IOrderCategoryChargeSearchService orderCategoryChargeSearchService,
                                       IOrderPropertyService orderPropertyService,
                                       IOrderChargeSearchService orderChargeSearchService
                                        )
        {
            _orderChargeSearchService = orderChargeSearchService;
            _orderCategoryService = orderCategoryService;
            _orderCategoryPropertyBindService = orderCategoryPropertyBindService;
            _orderCategoryPropertySearchService = orderCategoryPropertySearchService;
            _orderPropertyService = orderPropertyService;
            _orderCategoryChargeBindService = orderCategoryChargeBindService;
            _orderCategoryChargeSearchService = orderCategoryChargeSearchService;

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
            var bounds = _orderCategoryPropertySearchService.GetAssociations(categoryId).Select(s => s.Id).ToList();
            ViewData["boundIds"] = bounds;
            return View(properties);
        }

        [HttpGet]
        public ActionResult OrderCategoryChargeBindView(Guid categoryId)
        {
            var category = _orderCategoryService.SearchService.GetCategory(categoryId);
            ViewData["category"] = category;
            var charges = _orderChargeSearchService.GetCharges();
            var bounds = _orderCategoryChargeSearchService.GetAssociations(categoryId).Select(s => s.Id).ToList();
            ViewData["boundIds"] = bounds;
            return View(charges);
        }

        [HttpPost]
        public ActionResult BindProperties(CategoryBindIdsModel model)
        {
            var result = _orderCategoryPropertyBindService.BindAssociations(model.CategoryId, model.BindIds);
            return BoolResult(result);
        }

        [HttpPost]
        public ActionResult BindCharges(CategoryBindIdsModel model)
        {
            var result = _orderCategoryChargeBindService.BindAssociations(model.CategoryId, model.BindIds);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult OrderCategoryPropertyValueView(Guid categoryId)
        {
            var properties = _orderCategoryPropertySearchService.GetAssociationsIncludeParents(categoryId);
            return View(properties);
        }

        [HttpGet]
        public ActionResult OrderCategoryChargeValueView(Guid categoryId)
        {
            var properties = _orderCategoryChargeSearchService.GetAssociationsIncludeParents(categoryId);
            return View(properties);
        }
    }
}
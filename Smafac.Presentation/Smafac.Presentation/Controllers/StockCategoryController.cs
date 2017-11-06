using Smafac.Framework.Core.Models;
using Smafac.Wms.Stock.Applications.Category;
using Smafac.Wms.Stock.Applications.CategoryProperty;
using Smafac.Wms.Stock.Applications.Property;
using Smafac.Wms.Stock.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class StockCategoryController : SmafacController
    {
        private readonly IStockCategoryService _purchaseCategoryService;
        private readonly IStockCategoryPropertyBindService _purchaseCategoryPropertyBindService;
        private readonly IStockCategoryPropertySearchService _purchaseCategoryPropertySearchService;
        private readonly IStockPropertyService _purchasePropertyService;

        public StockCategoryController(IStockCategoryService purchaseCategoryService,
                                       IStockCategoryPropertyBindService purchaseCategoryPropertyBindService,
                                       IStockCategoryPropertySearchService purchaseCategoryPropertySearchService,
                                       IStockPropertyService purchasePropertyService
                                        )
        {
            _purchaseCategoryService = purchaseCategoryService;
            _purchaseCategoryPropertyBindService = purchaseCategoryPropertyBindService;
            _purchaseCategoryPropertySearchService = purchaseCategoryPropertySearchService;
            _purchasePropertyService = purchasePropertyService;
        }
        [HttpGet]
        public ActionResult StockCategoryView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StockCategorySliceView(Guid? categoryId, int slice)
        {
            CategoryModelSet<StockCategoryModel> model = (categoryId == null || categoryId.Value == Guid.Empty)
                                         ? new CategoryModelSet<StockCategoryModel> { Children = _purchaseCategoryService.SearchService.GetCategories(Guid.Empty), Category = new StockCategoryModel { Id = Guid.Empty } }
                                         : _purchaseCategoryService.SearchService.GetCategoryWithChildren(categoryId.Value);
            ViewData["slice"] = slice;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddStockCategory(StockCategoryModel model)
        {
            var result = _purchaseCategoryService.AddService.AddCategory(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult StockCategoryPropertyBindView(Guid categoryId)
        {
            var category = _purchaseCategoryService.SearchService.GetCategory(categoryId);
            ViewData["category"] = category;
            var properties = _purchasePropertyService.SearchService.GetColumns();
            var bounds = _purchaseCategoryPropertySearchService.GetAssociations(categoryId).Select(s => s.Id).ToList();
            ViewData["boundIds"] = bounds;
            return View(properties);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult BindProperties(CategoryBindIdsModel model)
        {
            var result = _purchaseCategoryPropertyBindService.BindAssociations(model.CategoryId, model.BindIds);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult StockCategoryPropertyValueView(Guid categoryId)
        {
            var properties = _purchaseCategoryPropertySearchService.GetAssociationsIncludeParents(categoryId);
            return View(properties);
        }
    }
}
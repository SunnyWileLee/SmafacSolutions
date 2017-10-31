using Smafac.Framework.Core.Models;
using Smafac.Pms.Purchase.Applications.Category;
using Smafac.Pms.Purchase.Applications.CategoryProperty;
using Smafac.Pms.Purchase.Applications.Property;
using Smafac.Pms.Purchase.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class PurchaseCategoryController : SmafacController
    {
        private readonly IPurchaseCategoryService _purchaseCategoryService;
        private readonly IPurchaseCategoryPropertyBindService _purchaseCategoryPropertyBindService;
        private readonly IPurchaseCategoryPropertySearchService _purchaseCategoryPropertySearchService;
        private readonly IPurchasePropertyService _purchasePropertyService;

        public PurchaseCategoryController(IPurchaseCategoryService purchaseCategoryService,
                                       IPurchaseCategoryPropertyBindService purchaseCategoryPropertyBindService,
                                       IPurchaseCategoryPropertySearchService purchaseCategoryPropertySearchService,
                                       IPurchasePropertyService purchasePropertyService
                                        )
        {
            _purchaseCategoryService = purchaseCategoryService;
            _purchaseCategoryPropertyBindService = purchaseCategoryPropertyBindService;
            _purchaseCategoryPropertySearchService = purchaseCategoryPropertySearchService;
            _purchasePropertyService = purchasePropertyService;
        }
        [HttpGet]
        public ActionResult PurchaseCategoryView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PurchaseCategorySliceView(Guid? categoryId, int slice)
        {
            CategoryModelSet<PurchaseCategoryModel> model = (categoryId == null || categoryId.Value == Guid.Empty)
                                         ? new CategoryModelSet<PurchaseCategoryModel> { Children = _purchaseCategoryService.SearchService.GetCategories(Guid.Empty), Category = new PurchaseCategoryModel { Id = Guid.Empty } }
                                         : _purchaseCategoryService.SearchService.GetCategoryWithChildren(categoryId.Value);
            ViewData["slice"] = slice;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddPurchaseCategory(PurchaseCategoryModel model)
        {
            var result = _purchaseCategoryService.AddService.AddCategory(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult PurchaseCategoryPropertyBindView(Guid categoryId)
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
        public ActionResult PurchaseCategoryPropertyValueView(Guid categoryId)
        {
            var properties = _purchaseCategoryPropertySearchService.GetAssociationsIncludeParents(categoryId);
            return View(properties);
        }
    }
}
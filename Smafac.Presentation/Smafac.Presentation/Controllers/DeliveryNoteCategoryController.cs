using Smafac.Framework.Models;
using Smafac.Sales.DeliveryNote.Applications.Category;
using Smafac.Sales.DeliveryNote.Applications.CategoryItemProperty;
using Smafac.Sales.DeliveryNote.Applications.CategoryProperty;
using Smafac.Sales.DeliveryNote.Applications.ItemProperty;
using Smafac.Sales.DeliveryNote.Applications.Property;
using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class DeliveryNoteCategoryController : SmafacController
    {
        private readonly IDeliveryNoteCategoryService _noteCategoryService;
        private readonly IDeliveryNoteCategoryPropertyBindService _noteCategoryPropertyBindService;
        private readonly IDeliveryNoteCategoryPropertySearchService _noteCategoryPropertySearchService;
        private readonly IDeliveryNoteCategoryItemPropertyBindService _itemCategoryPropertyBindService;
        private readonly IDeliveryNoteCategoryItemPropertySearchService _itemCategoryPropertySearchService;
        private readonly IDeliveryNotePropertyService _notePropertyService;
        private readonly IDeliveryNoteItemPropertyService _itemPropertyService;

        public DeliveryNoteCategoryController(IDeliveryNoteCategoryService noteCategoryService,
                                        IDeliveryNoteCategoryPropertyBindService noteCategoryPropertyBindService,
                                        IDeliveryNoteCategoryPropertySearchService noteCategoryPropertySearchService,
                                        IDeliveryNotePropertyService notePropertyService,
                                        IDeliveryNoteItemPropertyService itemPropertyService,
                                        IDeliveryNoteCategoryItemPropertyBindService itemCategoryPropertyBindService,
                                        IDeliveryNoteCategoryItemPropertySearchService itemCategoryPropertySearchService
                                        )
        {
            _noteCategoryService = noteCategoryService;
            _noteCategoryPropertyBindService = noteCategoryPropertyBindService;
            _noteCategoryPropertySearchService = noteCategoryPropertySearchService;
            _notePropertyService = notePropertyService;
            _itemPropertyService = itemPropertyService;
            _itemCategoryPropertyBindService = itemCategoryPropertyBindService;
            _itemCategoryPropertySearchService = itemCategoryPropertySearchService;
        }
        [HttpGet]
        public ActionResult DeliveryNoteCategoryView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DeliveryNoteCategorySliceView(Guid? categoryId, int slice)
        {
            CategoryModelSet<DeliveryNoteCategoryModel> model = (categoryId == null || categoryId.Value == Guid.Empty)
                                         ? new CategoryModelSet<DeliveryNoteCategoryModel> { Children = _noteCategoryService.SearchService.GetCategories(Guid.Empty), Category = new DeliveryNoteCategoryModel { Id = Guid.Empty } }
                                         : _noteCategoryService.SearchService.GetCategoryWithChildren(categoryId.Value);
            ViewData["slice"] = slice;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddDeliveryNoteCategory(DeliveryNoteCategoryModel model)
        {
            var result = _noteCategoryService.AddService.AddCategory(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult DeliveryNoteCategoryPropertyBindView(Guid categoryId)
        {
            var category = _noteCategoryService.SearchService.GetCategory(categoryId);
            ViewData["category"] = category;
            var properties = _notePropertyService.SearchService.GetColumns();
            var bounds = _noteCategoryPropertySearchService.GetAssociations(categoryId).Select(s => s.Id).ToList();
            ViewData["boundIds"] = bounds;
            return View(properties);
        }

        [HttpGet]
        public ActionResult DeliveryNoteCategoryItemPropertyBindView(Guid categoryId)
        {
            var category = _noteCategoryService.SearchService.GetCategory(categoryId);
            ViewData["category"] = category;
            var properties = _itemPropertyService.SearchService.GetColumns();
            var bounds = _itemCategoryPropertySearchService.GetAssociations(categoryId).Select(s => s.Id).ToList();
            ViewData["boundIds"] = bounds;
            return View(properties);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult BindProperties(CategoryBindIdsModel model)
        {
            var result = _noteCategoryPropertyBindService.BindAssociations(model.CategoryId, model.BindIds);
            return BoolResult(result);
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult BindItemProperties(CategoryBindIdsModel model)
        {
            var result = _itemCategoryPropertyBindService.BindAssociations(model.CategoryId, model.BindIds);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult DeliveryNoteCategoryPropertyValueView(Guid categoryId)
        {
            var properties = _noteCategoryPropertySearchService.GetAssociationsIncludeParents(categoryId);
            return View(properties);
        }
    }
}
using Smafac.Crm.CustomerFinance.Applications.Category;
using Smafac.Crm.CustomerFinance.Applications.CategoryProperty;
using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Framework.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class CustomerFinanceCategoryController : SmafacController
    {
        private readonly ICustomerFinanceCategoryService _financeCategoryService;
        private readonly ICustomerFinanceCategoryPropertyBindService _financeCategoryPropertyBindService;
        private readonly ICustomerFinanceCategoryPropertySearchService _financeCategoryPropertySearchService;
        private readonly ICustomerFinancePropertyService _financePropertyService;

        public CustomerFinanceCategoryController(ICustomerFinanceCategoryService financeCategoryService,
                                       ICustomerFinanceCategoryPropertyBindService financeCategoryPropertyBindService,
                                       ICustomerFinanceCategoryPropertySearchService financeCategoryPropertySearchService,
                                       ICustomerFinancePropertyService financePropertyService
                                        )
        {
            _financeCategoryService = financeCategoryService;
            _financeCategoryPropertyBindService = financeCategoryPropertyBindService;
            _financeCategoryPropertySearchService = financeCategoryPropertySearchService;
            _financePropertyService = financePropertyService;
        }
        [HttpGet]
        public ActionResult CustomerFinanceCategoryView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CustomerFinanceCategorySliceView(Guid? categoryId, int slice)
        {
            CategoryModelSet<CustomerFinanceCategoryModel> model = (categoryId == null || categoryId.Value == Guid.Empty)
                                         ? new CategoryModelSet<CustomerFinanceCategoryModel> { Children = _financeCategoryService.SearchService.GetCategories(Guid.Empty), Category = new CustomerFinanceCategoryModel { Id = Guid.Empty } }
                                         : _financeCategoryService.SearchService.GetCategoryWithChildren(categoryId.Value);
            ViewData["slice"] = slice;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddCustomerFinanceCategory(CustomerFinanceCategoryModel model)
        {
            var result = _financeCategoryService.AddService.AddCategory(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult CustomerFinanceCategoryPropertyBindView(Guid categoryId)
        {
            var category = _financeCategoryService.SearchService.GetCategory(categoryId);
            ViewData["category"] = category;
            var properties = _financePropertyService.SearchService.GetColumns();
            var bounds = _financeCategoryPropertySearchService.GetAssociations(categoryId).Select(s => s.Id).ToList();
            ViewData["boundIds"] = bounds;
            return View(properties);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult BindProperties(CategoryBindIdsModel model)
        {
            var result = _financeCategoryPropertyBindService.BindAssociations(model.CategoryId, model.BindIds);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult CustomerFinanceCategoryPropertyValueView(Guid categoryId)
        {
            var properties = _financeCategoryPropertySearchService.GetAssociationsIncludeParents(categoryId);
            return View(properties);
        }
    }
}
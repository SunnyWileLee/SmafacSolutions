using Smafac.Framework.Core.Models;
using Smafac.Hrs.Employee.Applications.Category;
using Smafac.Hrs.Employee.Applications.CategoryProperty;
using Smafac.Hrs.Employee.Applications.Property;
using Smafac.Hrs.Employee.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class EmployeeCategoryController : SmafacController
    {
        private readonly IEmployeeCategoryService _employeeCategoryService;
        private readonly IEmployeeCategoryPropertyBindService _employeeCategoryPropertyBindService;
        private readonly IEmployeeCategoryPropertySearchService _employeeCategoryPropertySearchService;
        private readonly IEmployeePropertyService _employeePropertyService;

        public EmployeeCategoryController(IEmployeeCategoryService employeeCategoryService,
                                       IEmployeeCategoryPropertyBindService employeeCategoryPropertyBindService,
                                       IEmployeeCategoryPropertySearchService employeeCategoryPropertySearchService,
                                       IEmployeePropertyService employeePropertyService
                                        )
        {
            _employeeCategoryService = employeeCategoryService;
            _employeeCategoryPropertyBindService = employeeCategoryPropertyBindService;
            _employeeCategoryPropertySearchService = employeeCategoryPropertySearchService;
            _employeePropertyService = employeePropertyService;
        }
        [HttpGet]
        public ActionResult EmployeeCategoryView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EmployeeCategorySliceView(Guid? categoryId, int slice)
        {
            CategoryModelSet<EmployeeCategoryModel> model = (categoryId == null || categoryId.Value == Guid.Empty)
                                         ? new CategoryModelSet<EmployeeCategoryModel> { Children = _employeeCategoryService.SearchService.GetCategories(Guid.Empty), Category = new EmployeeCategoryModel { Id = Guid.Empty } }
                                         : _employeeCategoryService.SearchService.GetCategoryWithChildren(categoryId.Value);
            ViewData["slice"] = slice;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEmployeeCategory(EmployeeCategoryModel model)
        {
            var result = _employeeCategoryService.AddService.AddCategory(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult EmployeeCategoryPropertyBindView(Guid categoryId)
        {
            var category = _employeeCategoryService.SearchService.GetCategory(categoryId);
            ViewData["category"] = category;
            var properties = _employeePropertyService.SearchService.GetColumns();
            var bounds = _employeeCategoryPropertySearchService.GetAssociations(categoryId).Select(s => s.Id).ToList();
            ViewData["boundIds"] = bounds;
            return View(properties);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult BindProperties(CategoryBindIdsModel model)
        {
            var result = _employeeCategoryPropertyBindService.BindAssociations(model.CategoryId, model.BindIds);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult EmployeeCategoryPropertyValueView(Guid categoryId)
        {
            var properties = _employeeCategoryPropertySearchService.GetAssociationsIncludeParents(categoryId);
            return View(properties);
        }
    }
}
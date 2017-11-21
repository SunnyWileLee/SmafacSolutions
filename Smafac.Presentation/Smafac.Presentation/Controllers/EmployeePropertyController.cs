using Smafac.Hrs.Employee.Applications.Property;
using Smafac.Hrs.Employee.Models;
using Smafac.Presentation.Domain;
using System;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class EmployeePropertyController : SmafacController
    {
        private readonly IEmployeePropertyService _employeePropertyService;
        private readonly IPropertyTypeProvider _propertyTypeProvider;

        public EmployeePropertyController(IEmployeePropertyService employeePropertyService,
                    IPropertyTypeProvider propertyTypeProvider)
        {
            _employeePropertyService = employeePropertyService;
            _propertyTypeProvider = propertyTypeProvider;
        }

        [HttpGet]
        public ActionResult EmployeePropertyView()
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            var properties = _employeePropertyService.SearchService.GetColumns();
            return View(properties);
        }

        [HttpGet]
        public ActionResult EmployeePropertyAddView(Guid? propertyId)
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            if (propertyId == null)
            {
                return View();
            }
            else
            {
                var property = _employeePropertyService.SearchService.GetColumn(propertyId.Value);
                return View(property);
            }
        }

        [HttpPost]
        public ActionResult AddEmployeeProperty(EmployeePropertyModel model)
        {
            var result = _employeePropertyService.AddService.AddColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditEmployeeProperty(EmployeePropertyModel model)
        {
            var result = _employeePropertyService.UpdateService.UpdateColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult DeleteEmployeeProperty(Guid id)
        {
            var result = _employeePropertyService.DeleteService.DeleteColumn(id);
            return BoolResult(result);
        }
    }
}
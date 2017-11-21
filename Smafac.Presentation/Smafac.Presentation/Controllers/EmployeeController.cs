using Smafac.Framework.Core.Domain.Exports;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Driver;
using Smafac.Hrs.Employee.Applications;
using Smafac.Hrs.Employee.Applications.Category;
using Smafac.Hrs.Employee.Applications.Property;
using Smafac.Hrs.Employee.Models;
using Smafac.Wms.Goods.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class EmployeeController : SmafacController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeSearchService _employeeSearchService;
        private readonly IEmployeeCategoryService _employeeCategoryService;
        private readonly IEmployeePropertyService _employeePropertyService;
        private readonly IExcelDataHaveColumnExporter _dataExporter;

        public EmployeeController(IEmployeeService EmployeeService,
                                IEmployeeSearchService EmployeeSearchService,
                                IEmployeeCategoryService EmployeeCategoryService,
                                IEmployeePropertyService EmployeePropertyService,
                                IExcelDataHaveColumnExporter dataExporter,
                                ICommandPipeProvider commandPipeProvider)
        {
            _employeeService = EmployeeService;
            _employeeSearchService = EmployeeSearchService;
            _employeeCategoryService = EmployeeCategoryService;
            _dataExporter = dataExporter;
            _employeePropertyService = EmployeePropertyService;
            base.CommandPipeProvider = commandPipeProvider;
        }

        [HttpGet]
        public ActionResult EmployeeView(Guid? goodsId)
        {
            var categories = _employeeCategoryService.SearchService.GetCategories();
            ViewData["categories"] = categories.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["goodsId"] = goodsId;
            return View();
        }
        [HttpGet]
        public ActionResult EmployeePageView(EmployeePageQueryModel query)
        {
            var page = _employeeSearchService.GetEmployeePage(query);
            var employees = page.PageData;
            ViewData["tableColumns"] = page.TableColumns;
            return View(employees);
        }
        [HttpPost]
        public ActionResult EmployeePage(EmployeePageQueryModel query)
        {
            var page = _employeeSearchService.GetEmployeePage(query);
            return Success(page);
        }
        [HttpGet]
        public ActionResult EmployeeAddView()
        {
            var categories = _employeeCategoryService.SearchService.GetLeafCategories()
                            .Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["categories"] = categories;
            var employee = _employeeService.CreateEmptyEmployee();
            return View(employee);
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel model)
        {
            var result = _employeeService.AddEmployee(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel model)
        {
            var result = _employeeService.UpdateService.UpdateEmployee(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult EmployeeDetailView(Guid EmployeeId)
        {
            var employee = _employeeSearchService.GetEmployeeDetail(EmployeeId);
            return View(employee);
        }

        [HttpGet]
        public ActionResult Export(EmployeePageQueryModel query)
        {
            var Employee = _employeeSearchService.GetEmployee(query);
            var properties = _employeePropertyService.SearchService.GetColumns();
            var model = new ExportDataHaveColumnModel<EmployeeModel, EmployeePropertyModel>
            {
                Datas = Employee,
                Columns = properties
            };
            var fileName = _dataExporter.CreateFileName("员工记录");
            var datas = _dataExporter.Export<EmployeeModel, EmployeePropertyModel>(model);
            return File(datas, "application/ms-excel", fileName);
        }
    }
}
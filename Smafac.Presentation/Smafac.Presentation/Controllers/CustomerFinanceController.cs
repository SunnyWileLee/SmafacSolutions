using Smafac.Crm.Customer.Applications;
using Smafac.Crm.CustomerFinance.Applications;
using Smafac.Crm.CustomerFinance.Applications.Category;
using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Framework.Core.Domain.Exports;
using Smafac.Framework.Core.Models;
using Smafac.Presentation.Domain;
using Smafac.Presentation.Domain.CustomerFinance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class CustomerFinanceController : SmafacController
    {
        private readonly ICustomerFinanceService _financeService;
        private readonly ICustomerFinanceSearchService _financeSearchService;
        private readonly ICustomerFinanceCategoryService _financeCategoryService;
        private readonly ICustomerSearchService _customerSearchService;
        private readonly ICustomerFinanceWrapper[] _financeWrappers;
        private readonly ICustomerFinancePropertySearchService _propertySearchService;
        private readonly IExcelDataHaveColumnExporter _dataExporter;

        public CustomerFinanceController(ICustomerFinanceService financeService,
                                ICustomerFinanceSearchService financeSearchService,
                                ICustomerFinanceCategoryService financeCategoryService,
                                ICustomerSearchService customerSearchService,
                                ICustomerFinanceWrapper[] financeWrappers,
                                ICustomerFinancePropertySearchService propertySearchService,
                                IExcelDataHaveColumnExporter dataExporter)
        {
            _financeService = financeService;
            _financeSearchService = financeSearchService;
            _financeCategoryService = financeCategoryService;
            _customerSearchService = customerSearchService;
            _financeWrappers = financeWrappers;
            _propertySearchService = propertySearchService;
            _dataExporter = dataExporter;
        }

        [HttpGet]
        public ActionResult CustomerFinanceView()
        {
            var customers = _customerSearchService.GetCustomers();
            var categories = _financeCategoryService.SearchService.GetCategories();
            ViewData["customers"] = customers.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["categories"] = categories.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            return View();
        }
        [HttpGet]
        public ActionResult CustomerFinancePageView(CustomerFinancePageQueryModel query)
        {
            var page = _financeSearchService.GetCustomerFinancePage(query);
            _financeWrappers.ToList().ForEach(wraper =>
            {
                wraper.Wrapper(page.PageData);
            });
            ViewData["tableColumns"] = page.TableColumns;
            return View(page.PageData);
        }
        [HttpPost]
        public ActionResult CustomerFinancePage(CustomerFinancePageQueryModel query)
        {
            var page = _financeSearchService.GetCustomerFinancePage(query);
            return Success(page);
        }
        [HttpGet]
        public ActionResult CustomerFinanceAddView()
        {
            var categories = _financeCategoryService.SearchService.GetLeafCategories()
                            .Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["categories"] = categories;
            var customers = _customerSearchService.GetCustomers().Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
            ViewData["customers"] = customers;
            var finance = _financeService.CreateEmptyCustomerFinance();
            return View(finance);
        }

        [HttpPost]
        public ActionResult AddCustomerFinance(CustomerFinanceModel model)
        {
            var result = _financeService.AddCustomerFinance(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult CustomerFinanceDetailView(Guid financeId)
        {
            var finance = _financeSearchService.GetCustomerFinanceDetail(financeId);
            _financeWrappers.ToList().ForEach(wraper =>
            {
                wraper.Wrapper(new List<CustomerFinanceModel> { finance.CustomerFinance });
            });
            return View(finance);
        }

        [HttpPost]
        public ActionResult EditCustomerFinance(CustomerFinanceModel model)
        {
            var result = _financeService.UpdateService.UpdateCustomerFinance(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult Export(CustomerFinancePageQueryModel query)
        {
            var customerFinances = _financeSearchService.GetCustomerFinances(query);
            _financeWrappers.ToList().ForEach(wraper =>
            {
                wraper.Wrapper(customerFinances);
            });
            var properties = _propertySearchService.GetColumns();
            var model = new ExportDataHaveColumnModel<CustomerFinanceModel, CustomerFinancePropertyModel>
            {
                Datas = customerFinances,
                Columns = properties
            };
            var fileName = _dataExporter.CreateFileName("客户财务");
            var datas = _dataExporter.Export<CustomerFinanceModel, CustomerFinancePropertyModel>(model);
            return File(datas, "application/ms-excel", fileName);
        }
    }
}
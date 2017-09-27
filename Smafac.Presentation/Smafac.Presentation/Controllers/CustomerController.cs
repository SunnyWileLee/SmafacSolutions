using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Applications.Propety;
using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Domain.Exports;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class CustomerController : SmafacController
    {
        private readonly ICustomerSearchService _customerSearchService;
        private readonly ICustomerService _customerService;
        private readonly ICustomerPropertyService _customerPropertyService;
        private readonly IExcelDataHaveColumnExporter _dataExporter;

        public CustomerController(ICustomerSearchService customerSearchService,
                                    ICustomerPropertyService customerPropertyService,
                                    ICustomerService customerService,
                                    IExcelDataHaveColumnExporter dataExporter)
        {
            _customerSearchService = customerSearchService;
            _customerService = customerService;
            _customerPropertyService = customerPropertyService;
            _dataExporter = dataExporter;
        }

        [HttpGet]
        public ActionResult CustomerView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CustomerPageView(CustomerPageQueryModel query)
        {
            var page = _customerSearchService.GetCustomerPage(query);
            ViewData["tableColumns"] = page.TableColumns;
            return View(page.PageData);
        }
        [HttpGet]
        public ActionResult CustomerDetailView(Guid customerId)
        {
            var customer = _customerSearchService.GetCustomerDetail(customerId);
            return View(customer);
        }
        [HttpGet]
        public ActionResult CustomerAddView(Guid? customerid)
        {
            var model = customerid == null ? _customerService.CreateEmptyCustomer() : _customerSearchService.GetCustomer(customerid.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult CustomerPage(CustomerPageQueryModel query)
        {
            var page = _customerSearchService.GetCustomerPage(query);
            return Success(page);
        }
        [HttpPost]
        public ActionResult AddCustomer(CustomerModel model)
        {
            var result = _customerService.AddCustomer(model);
            return Success(result);
        }

        [HttpPost]
        public ActionResult EditCustomer(CustomerModel model)
        {
            var result = _customerService.UpdateService.UpdateCustomer(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult Export(CustomerPageQueryModel query)
        {
            var customers = _customerSearchService.GetCustomers(query);
            var properties = _customerPropertyService.SearchService.GetColumns();
            var model = new ExportDataHaveColumnModel<CustomerModel, CustomerPropertyModel>
            {
                Datas = customers,
                Columns = properties
            };
            var datas = _dataExporter.Export<CustomerModel, CustomerPropertyModel>(model);
            var fileName = string.Format("客户数据{0}.xlsx", DateTime.Now.ToString("yyyymmddHHmmss"));
            return File(datas, "application/ms-excel", fileName);
        }
    }
}
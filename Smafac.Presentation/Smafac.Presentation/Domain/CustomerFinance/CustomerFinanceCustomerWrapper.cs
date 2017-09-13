using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.Customer.Applications;

namespace Smafac.Presentation.Domain.CustomerFinance
{
    public class CustomerFinanceCustomerWrapper : ICustomerFinanceWrapper
    {
        private readonly ICustomerSearchService _customerSearchService;

        public CustomerFinanceCustomerWrapper(ICustomerSearchService customerSearchService)
        {
            _customerSearchService = customerSearchService;
        }

        public void Wrapper(List<CustomerFinanceModel> finances)
        {
            if (!finances.Any())
            {
                return;
            }
            var customerIds = finances.Select(s => s.CustomerId);
            var customers = _customerSearchService.GetCustomers(customerIds);
            finances.ForEach(order =>
            {
                var customer = customers.FirstOrDefault(s => s.Id == order.CustomerId);
                if (customer != null)
                {
                    order.CustomerName = customer.Name;
                }
            });
        }
    }
}
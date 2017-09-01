using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smafac.Sales.Order.Models;
using Smafac.Crm.Customer.Applications;

namespace Smafac.Presentation.Domain
{
    public class OrderCustomerWrapper : IOrderWrapper
    {
        private readonly ICustomerSearchService _customerSearchService;

        public OrderCustomerWrapper(ICustomerSearchService customerSearchService)
        {
            _customerSearchService = customerSearchService;
        }

        public void Wrapper(List<OrderModel> orders)
        {
            if (!orders.Any())
            {
                return;
            }
            var customerIds = orders.Select(s => s.CustomerId);
            var customers = _customerSearchService.GetCustomers(customerIds);
            orders.ForEach(order =>
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Crm.Customer.Applications;

namespace Smafac.Presentation.Domain.DeliveryNote
{
    public class DeliveryNoteCustomerWrapper : IDeliveryNoteWrapper
    {
        private readonly ICustomerSearchService _customerSearchService;

        public DeliveryNoteCustomerWrapper(ICustomerSearchService customerSearchService)
        {
            _customerSearchService = customerSearchService;
        }

        public void Wrapper(List<DeliveryNoteModel> notes)
        {
            if (!notes.Any())
            {
                return;
            }
            var customerIds = notes.Select(s => s.CustomerId);
            var customers = _customerSearchService.GetCustomers(customerIds);
            notes.ForEach(note =>
            {
                var customer = customers.FirstOrDefault(s => s.Id == note.CustomerId);
                if (customer != null)
                {
                    note.CustomerName = customer.Name;
                }
            });
        }
    }
}
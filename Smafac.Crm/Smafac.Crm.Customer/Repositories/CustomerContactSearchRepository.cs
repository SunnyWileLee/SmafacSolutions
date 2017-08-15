using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerContactSearchRepository : ICustomerContactSearchRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerContactSearchRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }
        public List<CustomerContactModel> GetContactModels(Guid SubscriberId, Guid customerId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var contacts = context.CustomerContacts.Where(s => s.SubscriberId == SubscriberId && s.CustomerId == customerId)
                                        .Select(s => new CustomerContactModel
                                        {
                                            SubscriberId = s.SubscriberId,
                                            CreateTime = s.CreateTime,
                                            CustomerId = s.CustomerId,
                                            Id = s.Id,
                                            MobileNumber = s.MobileNumber,
                                            Name = s.Name
                                        }).ToList();
                return contacts;
            }
        }

        public CustomerContactModel GetContactById(Guid SubscriberId, Guid contactId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var contact = context.CustomerContacts.Where(s => s.SubscriberId == SubscriberId && s.Id == contactId)
                                        .Select(s => new CustomerContactModel
                                        {
                                            SubscriberId = s.SubscriberId,
                                            CreateTime = s.CreateTime,
                                            CustomerId = s.CustomerId,
                                            Id = s.Id,
                                            MobileNumber = s.MobileNumber,
                                            Name = s.Name
                                        }).FirstOrDefault();
                return contact;
            }
        }
    }
}

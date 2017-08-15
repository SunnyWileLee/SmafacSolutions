using Smafac.Crm.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerContactRepository : ICustomerContactRepository
    {

        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerContactRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool AddContact(CustomerContactEntity contact)
        {
            using (var context = _customerContextProvider.Provide())
            {
                context.CustomerContacts.Add(contact);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateContact(CustomerContactEntity contact)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerContacts.FirstOrDefault(s => s.SubscriberId == contact.SubscriberId && s.Id == contact.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.MobileNumber = contact.MobileNumber;
                entity.Name = contact.Name;
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteContact(Guid SubscriberId, Guid contactId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var contact = context.CustomerContacts.FirstOrDefault(s => s.SubscriberId == SubscriberId && s.Id == contactId);
                if (contact == null)
                {
                    return false;
                }
                context.CustomerContacts.Remove(contact);
                return context.SaveChanges() > 0;
            }
        }
    }
}

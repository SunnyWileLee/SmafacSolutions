using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Crm.Customer.Domain;

namespace Smafac.Crm.Customer.Services
{
    class CustomerContactService : ICustomerContactService
    {
        private readonly ICustomerSearchRepository _customerSearchRepository;
        private readonly ICustomerContactRepository _customerContactRepository;

        public CustomerContactService(ICustomerSearchRepository customerSearchRepository,
                                        ICustomerContactRepository customerContactRepository)
        {
            _customerSearchRepository = customerSearchRepository;
            _customerContactRepository = customerContactRepository;
        }

        public bool AddContact(CustomerContactModel model)
        {
            var customer = _customerSearchRepository.GetById(UserContext.Current.SubscriberId, model.CustomerId);
            var contact = customer.CreateContact(model);
            return _customerContactRepository.AddContact(contact);
        }

        public bool UpdateContact(CustomerContactModel model)
        {
            var contact = Mapper.Map<CustomerContactEntity>(model);
            contact.SubscriberId = UserContext.Current.SubscriberId;
            return _customerContactRepository.UpdateContact(contact);
        }

        public bool DeleteContact(Guid contactId)
        {
            return _customerContactRepository.DeleteContact(UserContext.Current.SubscriberId, contactId);
        }
    }
}

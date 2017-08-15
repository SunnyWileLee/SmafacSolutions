using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Services
{
    class CustomerContactSearchService : ICustomerContactSearchService
    {
        private readonly ICustomerContactSearchRepository _customerContactSearchRepository;
        private readonly ICustomerContactPropertyValueRepository _customerContactPropertyValueRepository;

        public CustomerContactSearchService(ICustomerContactSearchRepository customerContactSearchRepository,
                                            ICustomerContactPropertyValueRepository customerContactPropertyValueRepository)
        {
            _customerContactSearchRepository = customerContactSearchRepository;
            _customerContactPropertyValueRepository = customerContactPropertyValueRepository;
        }

        public List<CustomerContactModel> GetContacts(Guid customerId)
        {
            var contacts = _customerContactSearchRepository.GetContactModels(UserContext.Current.SubscriberId, customerId);
            return contacts;
        }

        public CustomerContactDetailModel GetContactDetail(Guid contactId)
        {
            var contact = _customerContactSearchRepository.GetContactById(UserContext.Current.SubscriberId, contactId);
            var properties = _customerContactPropertyValueRepository.GetPropertyValues(UserContext.Current.SubscriberId, contactId);
            var detail = new CustomerContactDetailModel(contact) { PropertyValues = properties };
            return detail;
        }
    }
}

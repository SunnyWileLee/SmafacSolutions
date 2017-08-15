using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Models;

namespace Smafac.Crm.Customer.Services
{
    class CustomerPayTypeService : ICustomerPayTypeService
    {
        private readonly ICustomerPayTypeRepository _customerPayTypeRepository;
        public CustomerPayTypeService(ICustomerPayTypeRepository customerPayTypeRepository)
        {
            _customerPayTypeRepository = customerPayTypeRepository;
        }

        public bool AddPayType(CustomerPayTypeModel model)
        {
            var type = Mapper.Map<CustomerPayTypeEntity>(model);
            type.SubscriberId = UserContext.Current.SubscriberId;
            return _customerPayTypeRepository.AddPayType(type);
        }

        public bool UpdatePayType(CustomerPayTypeModel model)
        {
            var type = Mapper.Map<CustomerPayTypeEntity>(model);
            type.SubscriberId = UserContext.Current.SubscriberId;
            return _customerPayTypeRepository.UpdatePayType(type);
        }

        public bool DeletePayType(Guid payTypeId)
        {
            return _customerPayTypeRepository.DeletePayType(UserContext.Current.SubscriberId, payTypeId);
        }

        public List<CustomerPayTypeModel> GetPayTypes()
        {
            return _customerPayTypeRepository.GetPayTypeModels(UserContext.Current.SubscriberId);
        }
    }
}

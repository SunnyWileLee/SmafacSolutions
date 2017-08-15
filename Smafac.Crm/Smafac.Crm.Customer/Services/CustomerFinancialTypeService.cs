using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Models;

namespace Smafac.Crm.Customer.Services
{
    class CustomerFinancialTypeService : ICustomerFinancialTypeService
    {
        private readonly ICustomerFinancialTypeRepository _customerFinancialTypeRepository;
        public CustomerFinancialTypeService(ICustomerFinancialTypeRepository customerFinancialTypeRepository)
        {
            _customerFinancialTypeRepository = customerFinancialTypeRepository;
        }

        public bool AddType(CustomerFinancialTypeModel model)
        {
            var type = Mapper.Map<CustomerFinancialTypeEntity>(model);
            type.SubscriberId = UserContext.Current.SubscriberId;
            return _customerFinancialTypeRepository.AddFinancialType(type);
        }

        public bool UpdateType(CustomerFinancialTypeModel model)
        {
            var type = Mapper.Map<CustomerFinancialTypeEntity>(model);
            type.SubscriberId = UserContext.Current.SubscriberId;
            return _customerFinancialTypeRepository.UpdateFinancialType(type);
        }

        public bool DeleteType(Guid TypeId)
        {
            return _customerFinancialTypeRepository.DeleteFinancialType(UserContext.Current.SubscriberId, TypeId);
        }

        public List<CustomerFinancialTypeModel> GetTypes()
        {
            return _customerFinancialTypeRepository.GetFinancialTypeModels(UserContext.Current.SubscriberId);
        }
    }
}

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
    class CustomerFinancialStatusService : ICustomerFinancialStatusService
    {
        private readonly ICustomerFinancialStatusRepository _customerFinancialStatusRepository;
        public CustomerFinancialStatusService(ICustomerFinancialStatusRepository customerFinancialStatusRepository)
        {
            _customerFinancialStatusRepository = customerFinancialStatusRepository;
        }

        public bool AddStatus(CustomerFinancialStatusModel model)
        {
            var status = Mapper.Map<CustomerFinancialStatusEntity>(model);
            status.SubscriberId = UserContext.Current.SubscriberId;
            return _customerFinancialStatusRepository.AddFinancialStatus(status);
        }

        public bool UpdateStatus(CustomerFinancialStatusModel model)
        {
            var status = Mapper.Map<CustomerFinancialStatusEntity>(model);
            status.SubscriberId = UserContext.Current.SubscriberId;
            return _customerFinancialStatusRepository.UpdateFinancialStatus(status);
        }

        public bool DeleteStatus(Guid statusId)
        {
            return _customerFinancialStatusRepository.DeleteFinancialStatus(UserContext.Current.SubscriberId, statusId);
        }

        public List<CustomerFinancialStatusModel> GetStatus()
        {
            return _customerFinancialStatusRepository.GetFinancialStatusModels(UserContext.Current.SubscriberId);
        }
    }
}

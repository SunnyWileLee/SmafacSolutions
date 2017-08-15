using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerFinancialStatusRepository : ICustomerFinancialStatusRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerFinancialStatusRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool AddFinancialStatus(CustomerFinancialStatusEntity financialStatus)
        {
            using (var context = _customerContextProvider.Provide())
            {
                context.CustomerFinancialStatuses.Add(financialStatus);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateFinancialStatus(CustomerFinancialStatusEntity financialStatus)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var status = context.CustomerFinancialStatuses.FirstOrDefault(s => s.SubscriberId == financialStatus.SubscriberId && s.Id == financialStatus.Id);
                if (status == null)
                {
                    return false;
                }
                status.Title = financialStatus.Title;
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteFinancialStatus(Guid SubscriberId, Guid financialStatusId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var status = context.CustomerFinancialStatuses.FirstOrDefault(s => s.SubscriberId == SubscriberId && s.Id == financialStatusId);
                if (status == null)
                {
                    return false;
                }
                context.CustomerFinancialStatuses.Remove(status);
                return context.SaveChanges() > 0;
            }
        }

        public List<CustomerFinancialStatusEntity> GetFinancialStatuss(Guid SubscriberId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var statuses = context.CustomerFinancialStatuses.Where(s => s.SubscriberId == SubscriberId).ToList();
                return statuses;
            }
        }

        public List<CustomerFinancialStatusModel> GetFinancialStatusModels(Guid SubscriberId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var statuses = context.CustomerFinancialStatuses.Where(s => s.SubscriberId == SubscriberId)
                                                                .Select(s => new CustomerFinancialStatusModel
                                                                {
                                                                    Id = s.Id,
                                                                    SubscriberId = s.SubscriberId,
                                                                    CreateTime = s.CreateTime,
                                                                    Title = s.Title
                                                                }).ToList();
                return statuses;
            }
        }
    }
}

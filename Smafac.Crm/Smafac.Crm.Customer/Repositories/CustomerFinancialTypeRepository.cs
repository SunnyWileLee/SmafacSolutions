using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerFinancialTypeRepository : ICustomerFinancialTypeRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerFinancialTypeRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool AddFinancialType(CustomerFinancialTypeEntity financialType)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerFinancialTypes.Any(s => s.SubscriberId == financialType.SubscriberId && s.Title == financialType.Title);
                if (entity)
                {
                    return false;
                }
                context.CustomerFinancialTypes.Add(financialType);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateFinancialType(CustomerFinancialTypeEntity financialType)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerFinancialTypes.Add(financialType);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteFinancialType(Guid SubscriberId, Guid financialTypeId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerFinancialTypes.FirstOrDefault(s => s.SubscriberId == SubscriberId && s.Id == financialTypeId);
                if (entity == null)
                {
                    return false;
                }
                context.CustomerFinancialTypes.Remove(entity);
                return context.SaveChanges() > 0;
            }
        }

        public List<CustomerFinancialTypeEntity> GetFinancialTypes(Guid SubscriberId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var types = context.CustomerFinancialTypes.Where(s => s.SubscriberId == SubscriberId).ToList();
                return types;
            }
        }

        public List<CustomerFinancialTypeModel> GetFinancialTypeModels(Guid SubscriberId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var types = context.CustomerFinancialTypes.Where(s => s.SubscriberId == SubscriberId)
                                    .Select(t => new CustomerFinancialTypeModel
                                    {
                                        SubscriberId = t.SubscriberId,
                                        CreateTime = t.CreateTime,
                                        Id = t.Id,
                                        Title = t.Title
                                    }).ToList();
                return types;
            }
        }
    }
}

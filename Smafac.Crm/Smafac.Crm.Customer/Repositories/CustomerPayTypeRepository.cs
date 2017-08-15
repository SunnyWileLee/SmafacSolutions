using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerPayTypeRepository : ICustomerPayTypeRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerPayTypeRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool AddPayType(CustomerPayTypeEntity type)
        {
            using (var context = _customerContextProvider.Provide())
            {
                context.CustomerPayTypes.Add(type);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdatePayType(CustomerPayTypeEntity type)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerPayTypes.FirstOrDefault(s => s.SubscriberId == type.SubscriberId && s.Id == type.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.Title = type.Title;
                return context.SaveChanges() > 0;
            }
        }

        public bool DeletePayType(Guid SubscriberId, Guid typeId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var type = context.CustomerPayTypes.FirstOrDefault(s => s.SubscriberId == SubscriberId && s.Id == typeId);
                if (type == null)
                {
                    return false;
                }
                context.CustomerPayTypes.Remove(type);
                return context.SaveChanges() > 0;
            }
        }

        public List<CustomerPayTypeEntity> GetPayTypes(Guid SubscriberId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var types = context.CustomerPayTypes.Where(s => s.SubscriberId == SubscriberId).ToList();
                return types;
            }
        }

        public List<CustomerPayTypeModel> GetPayTypeModels(Guid SubscriberId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var types = context.CustomerPayTypes.Where(s => s.SubscriberId == SubscriberId)
                                                    .Select(t => new CustomerPayTypeModel
                                                    {
                                                        Id = t.Id,
                                                        SubscriberId = t.SubscriberId,
                                                        CreateTime = t.CreateTime,
                                                        Title = t.Title
                                                    }).ToList();
                return types;
            }
        }
    }
}

using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerLevelRepository : ICustomerLevelRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerLevelRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool AddLevel(CustomerLevelEntity level)
        {
            using (var context = _customerContextProvider.Provide())
            {
                if (context.CustomerLevels.Any(s => s.SubscriberId == level.SubscriberId && s.Title == level.Title))
                {
                    return false;
                }
                context.CustomerLevels.Add(level);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateLevel(CustomerLevelEntity level)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerLevels.FirstOrDefault(s => s.SubscriberId == level.SubscriberId && s.Id == level.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.Title = level.Title;
                entity.Top = level.Top;
                entity.Buttom = level.Buttom;
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteLevel(Guid SubscriberId, Guid levelId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerLevels.FirstOrDefault(s => s.SubscriberId == SubscriberId && s.Id == levelId);
                if (entity == null)
                {
                    return false;
                }
                context.CustomerLevels.Remove(entity);
                return context.SaveChanges() > 0;
            }
        }

        public List<CustomerLevelEntity> GetLevels(Guid SubscriberId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var levels = context.CustomerLevels.Where(s => s.SubscriberId == SubscriberId).ToList();
                return levels;
            }
        }

        public List<CustomerLevelModel> GetLevelModels(Guid SubscriberId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var levels = context.CustomerLevels.Where(s => s.SubscriberId == SubscriberId)
                                        .Select(l => new CustomerLevelModel
                                        {
                                            SubscriberId = l.SubscriberId,
                                            Buttom = l.Buttom,
                                            CreateTime = l.CreateTime,
                                            Id = l.Id,
                                            Title = l.Title,
                                            Top = l.Top
                                        }).ToList();
                return levels;
            }
        }
    }
}

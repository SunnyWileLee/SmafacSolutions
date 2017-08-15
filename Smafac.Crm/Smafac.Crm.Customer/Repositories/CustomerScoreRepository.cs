using Smafac.Crm.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerScoreRepository : ICustomerScoreRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerScoreRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public decimal AddScore(Guid SubscriberId, Guid customerId, decimal score)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerScores.FirstOrDefault(s => s.SubscriberId == SubscriberId && s.CustomerId == customerId);
                if (entity == null)
                {
                    entity = new CustomerScoreEntity
                    {
                        Score = score,
                        SubscriberId = SubscriberId,
                        CustomerId = customerId,
                    };
                    context.CustomerScores.Add(entity);
                }
                entity.Score += score;
                var result = context.SaveChanges();
                return result > 0 ? entity.Score : 0;
            }
        }


        public bool UpdateLevel(Guid SubscriberId, Guid customerId, Guid levelId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var entity = context.CustomerScores.FirstOrDefault(s => s.SubscriberId == SubscriberId && s.CustomerId == customerId);
                if (entity == null)
                {
                    return false;
                }
                entity.LevelId = levelId;
                return context.SaveChanges() > 0;
            }
        }
    }
}

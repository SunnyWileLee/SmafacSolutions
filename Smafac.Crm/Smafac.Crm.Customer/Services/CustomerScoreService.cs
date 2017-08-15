using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Services
{
    class CustomerScoreService : ICustomerScoreService
    {
        private readonly ICustomerScoreRepository _customerScoreRepository;
        private readonly ICustomerLevelRepository _customerLevelRepository;

        public CustomerScoreService(ICustomerScoreRepository customerScoreRepository,
                                    ICustomerLevelRepository customerLevelRepository)
        {
            _customerScoreRepository = customerScoreRepository;
            _customerLevelRepository = customerLevelRepository;
        }

        public bool AddScore(Guid SubscriberId, Guid customerId, decimal score)
        {
            var scoreCurrent = _customerScoreRepository.AddScore(SubscriberId, customerId, score);
            if (scoreCurrent == 0)
            {
                return true;
            }
            var levels = _customerLevelRepository.GetLevels(SubscriberId);
            var levelCurrent = FilterScore(levels, scoreCurrent);
            if (levelCurrent == null)
            {
                return true;
            }
            return _customerScoreRepository.UpdateLevel(SubscriberId, customerId, levelCurrent.Id);
        }

        private CustomerLevelEntity FilterScore(IEnumerable<CustomerLevelEntity> levels, decimal score)
        {
            var levelCurrent = levels.FirstOrDefault(s => s.Buttom >= score && s.Top < score);
            return levelCurrent;
        }
    }
}

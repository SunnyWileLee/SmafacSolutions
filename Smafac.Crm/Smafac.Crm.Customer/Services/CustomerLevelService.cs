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
    class CustomerLevelService : ICustomerLevelService
    {
        private readonly ICustomerLevelRepository _customerLevelRepository;
        public CustomerLevelService(ICustomerLevelRepository customerLevelRepository)
        {
            _customerLevelRepository = customerLevelRepository;
        }
        public bool AddLevel(CustomerLevelModel model)
        {
            var level = Mapper.Map<CustomerLevelEntity>(model);
            level.SubscriberId = UserContext.Current.SubscriberId;
            return _customerLevelRepository.AddLevel(level);
        }

        public bool UpdateLevel(CustomerLevelModel model)
        {
            var level = Mapper.Map<CustomerLevelEntity>(model);
            level.SubscriberId = UserContext.Current.SubscriberId;
            return _customerLevelRepository.UpdateLevel(level);
        }

        public bool DeleteLevel(Guid levelId)
        {
            return _customerLevelRepository.DeleteLevel(UserContext.Current.SubscriberId, levelId);
        }

        public List<CustomerLevelModel> GetLevels()
        {
            return _customerLevelRepository.GetLevelModels(UserContext.Current.SubscriberId);
        }
    }
}

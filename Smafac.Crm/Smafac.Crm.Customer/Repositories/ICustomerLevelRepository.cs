using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerLevelRepository
    {
        bool AddLevel(CustomerLevelEntity level);
        bool UpdateLevel(CustomerLevelEntity level);
        bool DeleteLevel(Guid SubscriberId, Guid levelId);
        List<CustomerLevelEntity> GetLevels(Guid SubscriberId);
        List<CustomerLevelModel> GetLevelModels(Guid SubscriberId);
    }
}

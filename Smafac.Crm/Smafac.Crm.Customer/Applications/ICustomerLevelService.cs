using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerLevelService
    {
        bool AddLevel(CustomerLevelModel model);
        bool UpdateLevel(CustomerLevelModel model);
        bool DeleteLevel(Guid levelId);
        List<CustomerLevelModel> GetLevels();
    }
}

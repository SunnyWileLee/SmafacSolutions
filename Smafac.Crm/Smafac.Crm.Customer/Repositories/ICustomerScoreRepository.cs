using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerScoreRepository
    {
        decimal AddScore(Guid SubscriberId, Guid customerId, decimal score);
        bool UpdateLevel(Guid SubscriberId, Guid customerId, Guid levelId);
    }
}

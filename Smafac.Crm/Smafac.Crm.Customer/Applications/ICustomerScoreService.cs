using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerScoreService
    {
        bool AddScore(Guid SubscriberId, Guid customerId, decimal score);
    }
}

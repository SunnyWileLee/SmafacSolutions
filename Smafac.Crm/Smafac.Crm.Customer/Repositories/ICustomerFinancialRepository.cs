using Smafac.Crm.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerFinancialRepository
    {
        bool AddFinancial(CustomerFinancialEntity financial);
    }
}

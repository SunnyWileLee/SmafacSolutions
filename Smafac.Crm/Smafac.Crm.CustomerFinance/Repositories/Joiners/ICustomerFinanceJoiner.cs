using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Repositories.Joiners
{
    interface ICustomerFinanceJoiner
    {
        IQueryable<CustomerFinanceModel> Join(IQueryable<CustomerFinanceEntity> finances, IQueryable<CustomerFinanceCategoryEntity> categories);
    }
}

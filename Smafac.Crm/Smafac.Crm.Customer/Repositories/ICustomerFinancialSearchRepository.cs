using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerFinancialSearchRepository
    {
        List<CustomerFinancialModel> GetFinancials(CustomerFinancialPageQueryModel query);
        int GetFinancialCount(CustomerFinancialPageQueryModel query);
    }
}

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
    interface ICustomerVisitSearchRepository
    {
        List<CustomerVisitModel> GetVisits(Expression<Func<CustomerVisitEntity, bool>> predicate, int skip, int take);
        int GetVisitCount(Expression<Func<CustomerVisitEntity, bool>> predicate);
    }
}

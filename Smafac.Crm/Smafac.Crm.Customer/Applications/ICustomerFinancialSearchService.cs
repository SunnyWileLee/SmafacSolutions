using Smafac.Crm.Customer.Models;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerFinancialSearchService
    {
        PageModel<CustomerFinancialModel> GetFinancialPage(CustomerFinancialPageQueryModel query);
    }
}

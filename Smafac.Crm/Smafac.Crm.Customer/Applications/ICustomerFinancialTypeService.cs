using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerFinancialTypeService
    {
        bool AddType(CustomerFinancialTypeModel model);
        bool UpdateType(CustomerFinancialTypeModel model);
        bool DeleteType(Guid TypeId);
        List<CustomerFinancialTypeModel> GetTypes();
    }
}

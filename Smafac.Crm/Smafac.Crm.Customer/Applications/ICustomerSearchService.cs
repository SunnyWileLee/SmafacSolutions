using Smafac.Crm.Customer.Models;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerSearchService
    {
        CustomerDetailModel GetCustomerDetail(Guid customerId);
        PageModel<CustomerModel> GetCustomerPage(CustomerPageQueryModel query);
        CustomerModel GetCustomer(Guid customerId);
        List<CustomerModel> GetCustomers(IEnumerable<Guid> customerIds);
    }
}

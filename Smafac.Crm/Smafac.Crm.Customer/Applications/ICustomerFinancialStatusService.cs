using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerFinancialStatusService
    {
        bool AddStatus(CustomerFinancialStatusModel model);
        bool UpdateStatus(CustomerFinancialStatusModel model);
        bool DeleteStatus(Guid statusId);
        List<CustomerFinancialStatusModel> GetStatus();
    }
}

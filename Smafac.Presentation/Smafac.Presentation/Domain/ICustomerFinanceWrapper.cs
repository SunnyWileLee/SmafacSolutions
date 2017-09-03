using Smafac.Crm.CustomerFinance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Presentation.Domain
{
    public interface ICustomerFinanceWrapper
    {
        void Wrapper(List<CustomerFinanceModel> finances);
    }
}

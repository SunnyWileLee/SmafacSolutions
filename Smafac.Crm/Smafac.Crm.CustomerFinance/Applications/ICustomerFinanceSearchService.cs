using Smafac.Crm.CustomerFinance.Models;
using Smafac.Framework.Models;
using System;

namespace Smafac.Crm.CustomerFinance.Applications
{
    public interface ICustomerFinanceSearchService
    {
        PageModel<CustomerFinanceModel> GetCustomerFinancePage(CustomerFinancePageQueryModel query);
        CustomerFinanceModel GetCustomerFinance(Guid orderId);
        CustomerFinanceDetailModel GetCustomerFinanceDetail(Guid orderId);
    }
}

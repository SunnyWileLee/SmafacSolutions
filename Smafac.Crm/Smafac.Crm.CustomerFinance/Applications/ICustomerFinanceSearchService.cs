using Smafac.Crm.CustomerFinance.Models;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;

namespace Smafac.Crm.CustomerFinance.Applications
{
    public interface ICustomerFinanceSearchService
    {
        PageModel<CustomerFinanceModel> GetCustomerFinancePage(CustomerFinancePageQueryModel query);
        List<CustomerFinanceModel> GetCustomerFinances(CustomerFinancePageQueryModel query);
        CustomerFinanceModel GetCustomerFinance(Guid orderId);
        CustomerFinanceDetailModel GetCustomerFinanceDetail(Guid orderId);
    }
}

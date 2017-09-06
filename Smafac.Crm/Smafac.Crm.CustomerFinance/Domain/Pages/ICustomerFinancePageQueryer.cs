using Smafac.Crm.CustomerFinance.Models;
using Smafac.Framework.Core.Domain.Pages;

namespace Smafac.Crm.CustomerFinance.Domain.Pages
{
    interface ICustomerFinancePageQueryer : IPageQueryer<CustomerFinanceModel, CustomerFinancePageQueryModel>
    {
    }
}

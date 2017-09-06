using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Framework.Core.Repositories.Pages;

namespace Smafac.Crm.CustomerFinance.Repositories.Pages
{
    interface ICustomerFinancePageQueryRepository : IPageQueryRepository<CustomerFinanceEntity, CustomerFinanceModel>
    {

    }
}

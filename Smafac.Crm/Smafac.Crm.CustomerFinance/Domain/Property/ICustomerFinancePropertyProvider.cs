using Smafac.Crm.CustomerFinance.Models;
using System;
using System.Collections.Generic;

namespace Smafac.Crm.CustomerFinance.Domain.Property
{
    interface ICustomerFinancePropertyProvider
    {
        List<CustomerFinancePropertyModel> Provide(Guid customerFinanceId);
    }
}

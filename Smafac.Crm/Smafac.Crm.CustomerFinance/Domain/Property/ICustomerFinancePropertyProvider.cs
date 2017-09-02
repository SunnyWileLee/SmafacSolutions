using Smafac.Crm.CustomerFinance.Model;
using System;
using System.Collections.Generic;

namespace Smafac.Crm.CustomerFinance.Domain.Property
{
    interface ICustomerFinancePropertyProvider
    {
        List<CustomerFinancePropertyModel> Provide(Guid customerFinanceId);
    }
}

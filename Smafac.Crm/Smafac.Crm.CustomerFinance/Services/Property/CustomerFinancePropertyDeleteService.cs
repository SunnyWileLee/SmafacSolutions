using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.Property;
using Smafac.Framework.Core.Services.Property;
using System;

namespace Smafac.Crm.CustomerFinance.Services.Property
{
    class CustomerFinancePropertyDeleteService : PropertyDeleteService<CustomerFinancePropertyEntity, CustomerFinancePropertyModel>, ICustomerFinancePropertyDeleteService
    {
        public CustomerFinancePropertyDeleteService(ICustomerFinancePropertyDeleteRepository goodsPropertyDeleteRepository)
        {
            base.PropertyDeleteRepository = goodsPropertyDeleteRepository;
        }

        protected override bool IsUsed(Guid propertyId)
        {
            return false;
        }
    }
}

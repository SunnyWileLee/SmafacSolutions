using Smafac.Crm.Customer.Applications.Propety;
using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories.Property;
using Smafac.Framework.Core.Services.Property;
using System;

namespace Smafac.Crm.Customer.Services.Property
{
    class CustomerPropertyDeleteService : PropertyDeleteService<CustomerPropertyEntity, CustomerPropertyModel>, ICustomerPropertyDeleteService
    {
        public CustomerPropertyDeleteService(ICustomerPropertyDeleteRepository goodsPropertyDeleteRepository)
        {
            base.PropertyDeleteRepository = goodsPropertyDeleteRepository;
        }

        protected override bool IsUsed(Guid propertyId)
        {
            return false;
        }
    }
}

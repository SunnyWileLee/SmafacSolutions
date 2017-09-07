using Smafac.Crm.Customer.Applications.Propety;
using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories.Property;
using Smafac.Framework.Core.Services.Property;
using System;
using System.Collections.Generic;

namespace Smafac.Crm.Customer.Services.Property
{
    class CustomerPropertySearchService : PropertySearchService<CustomerPropertyEntity, CustomerPropertyModel>, ICustomerPropertySearchService
    {

        public CustomerPropertySearchService(ICustomerPropertySearchRepository goodsSearchRepository)
        {
            base.CustomizedColumnSearchRepository = goodsSearchRepository;
        }

        public override List<CustomerPropertyModel> GetColumns(Guid entityId)
        {
            return base.GetColumns();
        }
    }
}

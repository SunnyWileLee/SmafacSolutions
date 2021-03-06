﻿using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Domain.Property;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.Property;
using Smafac.Framework.Core.Services.Property;
using System;
using System.Collections.Generic;

namespace Smafac.Crm.CustomerFinance.Services.Property
{
    class CustomerFinancePropertySearchService : PropertySearchService<CustomerFinancePropertyEntity, CustomerFinancePropertyModel>, ICustomerFinancePropertySearchService
    {
        private readonly ICustomerFinancePropertyProvider _goodsPropertyProvider;

        public CustomerFinancePropertySearchService(ICustomerFinancePropertySearchRepository goodsSearchRepository,
            ICustomerFinancePropertyProvider goodsPropertyProvider)
        {
            base.CustomizedColumnSearchRepository = goodsSearchRepository;
            _goodsPropertyProvider = goodsPropertyProvider;
        }

        public override List<CustomerFinancePropertyModel> GetColumns(Guid entityId)
        {
            return _goodsPropertyProvider.Provide(entityId);
        }
    }
}

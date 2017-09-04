﻿using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.CategoryProperty;

namespace Smafac.Crm.CustomerFinance.Repositories.CategoryProperty
{
    class CustomerFinanceCategoryPropertySearchRepository : CategoryPropertySearchRepository<CustomerFinanceContext, CustomerFinanceCategoryEntity, CustomerFinancePropertyEntity, CustomerFinanceCategoryPropertyEntity>,
                                                  ICustomerFinanceCategoryPropertySearchRepository
    {
        public CustomerFinanceCategoryPropertySearchRepository(ICustomerFinanceContextProvider financeContextProvider)
        {
            base.ContextProvider = financeContextProvider;
        }
    }
}
﻿using Smafac.Crm.CustomerFinance.Applications.Category;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.Category;
using Smafac.Framework.Core.Services.Category;

namespace Smafac.Crm.CustomerFinance.Services.Category
{
    class CustomerFinanceCategoryUpdateService : CategoryUpdateService<CustomerFinanceCategoryEntity, CustomerFinanceCategoryModel>,
                                                ICustomerFinanceCategoryUpdateService
    {
        public CustomerFinanceCategoryUpdateService(ICustomerFinanceCategorySearchRepository goodsCategorySearchRepository,
                                          ICustomerFinanceCategoryUpdateRepository goodsCategoryUpdateRepository)
        {
            base.CategorySearchRepository = goodsCategorySearchRepository;
            base.CategoryUpdateRepository = goodsCategoryUpdateRepository;
        }
    }
}

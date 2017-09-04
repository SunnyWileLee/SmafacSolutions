using Smafac.Crm.CustomerFinance.Applications.Category;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.Category;
using Smafac.Framework.Core.Services.Category;
using System;

namespace Smafac.Crm.CustomerFinance.Services.Category
{
    class CustomerFinanceCategoryDeleteService : CategoryDeleteService<CustomerFinanceCategoryEntity, CustomerFinanceCategoryModel>,
            ICustomerFinanceCategoryDeleteService
    {
        public CustomerFinanceCategoryDeleteService(ICustomerFinanceCategoryDeleteRepository goodsCategoryDeleteRepository)
        {
            base.CategoryDeleteRepository = goodsCategoryDeleteRepository;
        }

        protected override bool IsUsed(Guid CategoryId)
        {
            return false;
        }
    }
}

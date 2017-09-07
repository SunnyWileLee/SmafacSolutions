using Smafac.Crm.CustomerFinance.Repositories;
using Smafac.Crm.CustomerFinance.Repositories.PropertyValue;
using Smafac.Framework.Core.Domain.CategoryProperty;
using System;
using System.Linq.Expressions;

namespace Smafac.Crm.CustomerFinance.Domain.CategoryProperty
{
    class CustomerFinanceCategoryPropertyBindTrigger : CategoryPropertyBindTrigger<CustomerFinanceEntity, CustomerFinanceCategoryEntity, CustomerFinancePropertyEntity, CustomerFinancePropertyValueEntity>,
                                            ICustomerFinanceCategoryPropertyBindTrigger
    {
        public CustomerFinanceCategoryPropertyBindTrigger(ICustomerFinanceSearchRepository customerFinanceSearchRepository,
                                                ICustomerFinancePropertyValueSetRepository customerFinancePropertyValueSetRepository)
        {
            base.EntitySearchRepository = customerFinanceSearchRepository;
            base.AssociationValueAddRepository = customerFinancePropertyValueSetRepository;
        }

        protected override void ModifyValue(CustomerFinancePropertyValueEntity value, Guid financeId, CustomerFinancePropertyEntity property)
        {
            base.ModifyValue(value, financeId, property);
            value.CustomerFinanceId = financeId;
        }

        protected override Expression<Func<CustomerFinanceEntity, bool>> CreateEntityPredicate(CustomerFinanceCategoryEntity category)
        {
            return finance => finance.CategoryId == category.Id;
        }
    }
}

using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.Pages;
using Smafac.Crm.CustomerFinance.Repositories.Property;
using Smafac.Crm.CustomerFinance.Repositories.PropertyValue;
using Smafac.Framework.Core.Domain.Pages;
using Smafac.Framework.Core.Repositories.Query;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Crm.CustomerFinance.Domain.Pages
{
    class CustomerFinancePageQueryer : PageQueryer<CustomerFinanceEntity, CustomerFinanceModel, CustomerFinancePageQueryModel, CustomerFinancePropertyValueModel, CustomerFinancePropertyEntity>
                                    , ICustomerFinancePageQueryer
    {
        public CustomerFinancePageQueryer(IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                    ICustomerFinancePageQueryRepository pageQueryRepository,
                                    ICustomerFinancePropertyValueSearchRepository propertyValueSearchRepository,
                                    ICustomerFinancePropertySearchRepository propertySearchRepository
                                    )
        {
            base.QueryExpressionCreaterProvider = queryExpressionCreaterProvider;
            base.PageQueryRepository = pageQueryRepository;
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
            base.PropertySearchRepository = propertySearchRepository;
        }

        protected override void SetPropertyValues(CustomerFinanceModel model, IEnumerable<CustomerFinancePropertyValueModel> properties)
        {
            model.Properties = base.WrapperPropertyValues(properties);
        }
    }
}

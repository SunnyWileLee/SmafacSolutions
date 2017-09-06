using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories.Pages;
using Smafac.Crm.Customer.Repositories.Property;
using Smafac.Crm.Customer.Repositories.PropertyValue;
using Smafac.Framework.Core.Domain.Pages;
using Smafac.Framework.Core.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain.Pages
{
    class CustomerPageQueryer : PageQueryer<CustomerEntity, CustomerModel, CustomerPageQueryModel, CustomerPropertyValueModel, CustomerPropertyEntity>
                                , ICustomerPageQueryer
    {
        public CustomerPageQueryer(IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                    ICustomerPageQueryRepository pageQueryRepository,
                                    ICustomerPropertyValueSearchRepository propertyValueSearchRepository,
                                    ICustomerPropertySearchRepository propertySearchRepository
                                    )
        {
            base.QueryExpressionCreaterProvider = queryExpressionCreaterProvider;
            base.PageQueryRepository = pageQueryRepository;
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
            base.PropertySearchRepository = propertySearchRepository;
        }

        protected override void SetPropertyValues(CustomerModel model, IEnumerable<CustomerPropertyValueModel> properties)
        {
            model.Properties = base.WrapperPropertyValues(properties);
        }
    }
}

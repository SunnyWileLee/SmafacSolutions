using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.Pages;
using Smafac.Crm.CustomerFinance.Repositories.Property;
using Smafac.Crm.CustomerFinance.Repositories.PropertyValue;
using Smafac.Framework.Core.Domain.Pages;
using Smafac.Framework.Core.Repositories.Query;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Smafac.Crm.CustomerFinance.Repositories;
using Smafac.Framework.Core.Models;

namespace Smafac.Crm.CustomerFinance.Domain.Pages
{
    class CustomerFinancePageQueryer : PageQueryer<CustomerFinanceEntity, CustomerFinanceModel, CustomerFinancePageQueryModel, CustomerFinancePropertyValueModel, CustomerFinancePropertyEntity>
                                    , ICustomerFinancePageQueryer
    {
        public CustomerFinancePageQueryer(IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                    ICustomerFinancePageQueryRepository pageQueryRepository,
                                    ICustomerFinancePropertyValueSearchRepository propertyValueSearchRepository,
                                    ICustomerFinancePropertySearchRepository propertySearchRepository,
                                    ICustomerFinanceSearchRepository entitySearchRepository
                                    )
        {
            base.QueryExpressionCreaterProvider = queryExpressionCreaterProvider;
            base.PageQueryRepository = pageQueryRepository;
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
            base.PropertySearchRepository = propertySearchRepository;
            base.EntitySearchRepository = entitySearchRepository;
        }

        protected override List<CustomerFinanceModel> QueryModels(Expression<Func<CustomerFinanceEntity, bool>> predicate)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var repository = base.EntitySearchRepository as ICustomerFinanceSearchRepository;
            var models = repository.GetModels(subscriberId, predicate);
            return models;
        }

        protected override void SetPropertyValues(CustomerFinanceModel model, IEnumerable<CustomerFinancePropertyValueModel> properties)
        {
            model.Properties = base.WrapperPropertyValues(properties);
        }
    }
}

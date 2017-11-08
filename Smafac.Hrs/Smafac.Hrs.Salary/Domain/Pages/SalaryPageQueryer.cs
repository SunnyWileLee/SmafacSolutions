using Smafac.Framework.Core.Domain.Pages;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories;
using Smafac.Hrs.Salary.Repositories.Pages;
using Smafac.Hrs.Salary.Repositories.Property;
using Smafac.Hrs.Salary.Repositories.PropertyValue;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Smafac.Framework.Core.Models;

namespace Smafac.Hrs.Salary.Domain.Pages
{
    class SalaryPageQueryer : PageQueryer<SalaryEntity, SalaryModel, SalaryPageQueryModel, SalaryPropertyValueModel, SalaryPropertyEntity>
                           , ISalaryPageQueryer
    {
        public SalaryPageQueryer(IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                    ISalaryPageQueryRepository pageQueryRepository,
                                    ISalaryPropertyValueSearchRepository propertyValueSearchRepository,
                                    ISalaryPropertySearchRepository propertySearchRepository,
                                    ISalarySearchRepository entitySearchRepository
                                    )
        {
            base.QueryExpressionCreaterProvider = queryExpressionCreaterProvider;
            base.PageQueryRepository = pageQueryRepository;
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
            base.PropertySearchRepository = propertySearchRepository;
            base.EntitySearchRepository = entitySearchRepository;
        }

        protected override List<SalaryModel> QueryModels(Expression<Func<SalaryEntity, bool>> predicate)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var repository = base.EntitySearchRepository as ISalarySearchRepository;
            var models = repository.GetSalary(subscriberId, predicate);
            return models;
        }

        protected override void SetPropertyValues(SalaryModel model, IEnumerable<SalaryPropertyValueModel> properties)
        {
            model.Properties = base.WrapperPropertyValues(properties);
        }
    }
}

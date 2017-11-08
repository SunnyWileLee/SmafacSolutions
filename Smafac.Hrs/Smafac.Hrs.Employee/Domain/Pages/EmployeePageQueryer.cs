using Smafac.Framework.Core.Domain.Pages;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories;
using Smafac.Hrs.Employee.Repositories.Pages;
using Smafac.Hrs.Employee.Repositories.Property;
using Smafac.Hrs.Employee.Repositories.PropertyValue;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Smafac.Framework.Core.Models;

namespace Smafac.Hrs.Employee.Domain.Pages
{
    class EmployeePageQueryer : PageQueryer<EmployeeEntity, EmployeeModel, EmployeePageQueryModel, EmployeePropertyValueModel, EmployeePropertyEntity>
                           , IEmployeePageQueryer
    {
        public EmployeePageQueryer(IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                    IEmployeePageQueryRepository pageQueryRepository,
                                    IEmployeePropertyValueSearchRepository propertyValueSearchRepository,
                                    IEmployeePropertySearchRepository propertySearchRepository,
                                    IEmployeeSearchRepository entitySearchRepository
                                    )
        {
            base.QueryExpressionCreaterProvider = queryExpressionCreaterProvider;
            base.PageQueryRepository = pageQueryRepository;
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
            base.PropertySearchRepository = propertySearchRepository;
            base.EntitySearchRepository = entitySearchRepository;
        }

        protected override List<EmployeeModel> QueryModels(Expression<Func<EmployeeEntity, bool>> predicate)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var repository = base.EntitySearchRepository as IEmployeeSearchRepository;
            var models = repository.GetEmployee(subscriberId, predicate);
            return models;
        }

        protected override void SetPropertyValues(EmployeeModel model, IEnumerable<EmployeePropertyValueModel> properties)
        {
            model.Properties = base.WrapperPropertyValues(properties);
        }
    }
}

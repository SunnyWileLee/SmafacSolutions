using Smafac.Framework.Core.Domain.Pages;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories;
using Smafac.Hrs.Attendance.Repositories.Pages;
using Smafac.Hrs.Attendance.Repositories.Property;
using Smafac.Hrs.Attendance.Repositories.PropertyValue;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Smafac.Framework.Core.Models;

namespace Smafac.Hrs.Attendance.Domain.Pages
{
    class AttendancePageQueryer : PageQueryer<AttendanceEntity, AttendanceModel, AttendancePageQueryModel, AttendancePropertyValueModel, AttendancePropertyEntity>
                           , IAttendancePageQueryer
    {
        public AttendancePageQueryer(IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                    IAttendancePageQueryRepository pageQueryRepository,
                                    IAttendancePropertyValueSearchRepository propertyValueSearchRepository,
                                    IAttendancePropertySearchRepository propertySearchRepository,
                                    IAttendanceSearchRepository entitySearchRepository
                                    )
        {
            base.QueryExpressionCreaterProvider = queryExpressionCreaterProvider;
            base.PageQueryRepository = pageQueryRepository;
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
            base.PropertySearchRepository = propertySearchRepository;
            base.EntitySearchRepository = entitySearchRepository;
        }

        protected override List<AttendanceModel> QueryModels(Expression<Func<AttendanceEntity, bool>> predicate)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var repository = base.EntitySearchRepository as IAttendanceSearchRepository;
            var models = repository.GetAttendance(subscriberId, predicate);
            return models;
        }

        protected override void SetPropertyValues(AttendanceModel model, IEnumerable<AttendancePropertyValueModel> properties)
        {
            model.Properties = base.WrapperPropertyValues(properties);
        }
    }
}

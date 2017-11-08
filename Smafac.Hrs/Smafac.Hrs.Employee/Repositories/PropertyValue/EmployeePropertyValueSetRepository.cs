using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Hrs.Employee.Domain;
using System;
using System.Linq;

namespace Smafac.Hrs.Employee.Repositories.PropertyValue
{
    class EmployeePropertyValueSetRepository : PropertyValueSetRepository<EmployeeContext, EmployeePropertyValueEntity>
                                                , IEmployeePropertyValueSetRepository
    {
        public EmployeePropertyValueSetRepository(IEmployeeContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override bool HasSetValue(IQueryable<EmployeePropertyValueEntity> values, Guid entityId)
        {
            return values.Any(s => s.EmployeeId.Equals(entityId));
        }

        protected override bool VerifyEntityId(Guid entityId, EmployeePropertyValueEntity value)
        {
            return !entityId.Equals(value.EmployeeId);
        }
    }
}

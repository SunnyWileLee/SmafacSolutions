using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Hrs.Salary.Domain;
using System;
using System.Linq;

namespace Smafac.Hrs.Salary.Repositories.PropertyValue
{
    class SalaryPropertyValueSetRepository : PropertyValueSetRepository<SalaryContext, SalaryPropertyValueEntity>
                                                , ISalaryPropertyValueSetRepository
    {
        public SalaryPropertyValueSetRepository(ISalaryContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override bool HasSetValue(IQueryable<SalaryPropertyValueEntity> values, Guid entityId)
        {
            return values.Any(s => s.SalaryId.Equals(entityId));
        }

        protected override bool VerifyEntityId(Guid entityId, SalaryPropertyValueEntity value)
        {
            return !entityId.Equals(value.SalaryId);
        }
    }
}

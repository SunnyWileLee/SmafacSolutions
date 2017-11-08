using Smafac.Framework.Core.Domain.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Smafac.Hrs.Attendance.Repositories;
using Smafac.Hrs.Attendance.Repositories.PropertyValue;

namespace Smafac.Hrs.Attendance.Domain.CategoryProperty
{
    class AttendanceCategoryPropertyBindTrigger : CategoryPropertyBindTrigger<AttendanceEntity, AttendanceCategoryEntity, AttendancePropertyEntity, AttendancePropertyValueEntity>,
                                            IAttendanceCategoryPropertyBindTrigger
    {
        public AttendanceCategoryPropertyBindTrigger(IAttendanceSearchRepository searchRepository,
                                                IAttendancePropertyValueSetRepository propertyValueSetRepository)
        {
            base.EntitySearchRepository = searchRepository;
            base.AssociationValueAddRepository = propertyValueSetRepository;
        }

        protected override void ModifyValue(AttendancePropertyValueEntity value, Guid goodsId, AttendancePropertyEntity property)
        {
            base.ModifyValue(value, goodsId, property);
            value.AttendanceId = goodsId;
        }

        protected override Expression<Func<AttendanceEntity, bool>> CreateEntityPredicate(AttendanceCategoryEntity category)
        {
            return goods => goods.CategoryId == category.Id;
        }
    }
}

using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories.Joiners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Repositories
{
    class AttendanceSearchRepository : EntitySearchRepository<AttendanceContext, AttendanceEntity>, IAttendanceSearchRepository
    {
        private readonly IAttendanceJoiner _goodsJoiner;

        public AttendanceSearchRepository(IAttendanceContextProvider contextProvider,
                                    IAttendanceJoiner goodsJoiner)
        {
            base.ContextProvider = contextProvider;
            _goodsJoiner = goodsJoiner;
        }

        public List<AttendanceModel> GetAttendance(Guid subscriberId, Expression<Func<AttendanceEntity, bool>> predicate)
        {
            using (var context = ContextProvider.Provide())
            {
                var goodses = context.Attendances.Where(s => s.SubscriberId == subscriberId).Where(predicate);
                return _goodsJoiner.Join(goodses, context.AttendanceCategories).ToList();
            }
        }

        public AttendanceModel GetAttendance(Guid subscriberId, Guid goodsId)
        {
            using (var context = ContextProvider.Provide())
            {
                var goodses = context.Attendances.Where(s => s.SubscriberId == subscriberId && s.Id == goodsId);
                return _goodsJoiner.Join(goodses, context.AttendanceCategories).FirstOrDefault();
            }
        }
    }
}

using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories.Joiners;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Hrs.Attendance.Repositories.Pages
{
    class AttendancePageQueryRepository : PageQueryRepository<AttendanceContext, AttendanceEntity, AttendanceModel>
                                                , IAttendancePageQueryRepository
    {
        private readonly IAttendanceJoiner _goodsJoiner;

        public AttendancePageQueryRepository(IAttendanceContextProvider contextProvider,
                                        IAttendanceJoiner goodsJoiner)
        {
            base.ContextProvider = contextProvider;
            _goodsJoiner = goodsJoiner;
        }

        protected override List<AttendanceModel> SelectModel(IQueryable<AttendanceEntity> query, AttendanceContext context)
        {
            var models = _goodsJoiner.Join(query, context.AttendanceCategories);
            return models.ToList();
        }
    }
}

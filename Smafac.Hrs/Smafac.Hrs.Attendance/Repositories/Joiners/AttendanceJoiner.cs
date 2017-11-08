using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Models;
using System.Linq;

namespace Smafac.Hrs.Attendance.Repositories.Joiners
{
    class AttendanceJoiner : IAttendanceJoiner
    {
        public IQueryable<AttendanceModel> Join(IQueryable<AttendanceEntity> attendances, IQueryable<AttendanceCategoryEntity> categories)
        {
            var query = from attendance in attendances
                        join category in categories on attendance.CategoryId equals category.Id
                        select new AttendanceModel
                        {
                            CategoryId = attendance.CategoryId,
                            SubscriberId = attendance.SubscriberId,
                            CategoryName = category.Name,
                            CreateTime = attendance.CreateTime,
                            Id = attendance.Id,
                            BeginTime = attendance.BeginTime,
                            EndTime = attendance.EndTime

                        };
            return query;
        }
    }
}

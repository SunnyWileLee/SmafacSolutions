using Smafac.Framework.Core.Models;
using Smafac.Hrs.Attendance.Applications;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Domain.Pages;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories;
using Smafac.Hrs.Attendance.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Hrs.Attendance.Services
{
    class AttendanceSearchService : IAttendanceSearchService
    {
        private readonly IAttendanceSearchRepository _searchRepository;
        private readonly IAttendancePropertyValueSearchRepository _propertyValueSearchRepository;
        private readonly IAttendancePageQueryer _pageQueryer;

        public AttendanceSearchService(IAttendanceSearchRepository searchRepository,
                                    IAttendancePropertyValueSearchRepository propertyValueSearchRepository,
                                    IAttendancePageQueryer pageQueryer
                                    )
        {
            _searchRepository = searchRepository;
            _propertyValueSearchRepository = propertyValueSearchRepository;
            _pageQueryer = pageQueryer;
        }

        public List<AttendanceModel> GetAttendance(IEnumerable<Guid> employeeIds)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            Expression<Func<AttendanceEntity, bool>> predicate = s => employeeIds.Contains(s.Id);
            return _searchRepository.GetAttendance(subscriberId, predicate);
        }

        public AttendanceModel GetAttendance(Guid employeeId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var employee = _searchRepository.GetAttendance(subscriberId, employeeId);
            var properties = _propertyValueSearchRepository.GetPropertyValues(subscriberId, employeeId);
            employee.Properties = properties;
            return employee;
        }

        public List<AttendanceModel> GetAttendance(AttendancePageQueryModel query)
        {
            return _pageQueryer.Query(query);
        }

        public AttendanceDetailModel GetAttendanceDetail(Guid employeeId)
        {
            var employee = this.GetAttendance(employeeId);
            return new AttendanceDetailModel { Attendance = employee };
        }


        public PageModel<AttendanceModel> GetAttendancePage(AttendancePageQueryModel query)
        {
            return _pageQueryer.QueryPage(query);
        }
    }
}

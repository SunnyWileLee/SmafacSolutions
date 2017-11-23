using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Employee.Applications;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Presentation.Domain.Attendance
{
    public class AttendanceEmployeeWrapper : IAttendanceWrapper
    {
        private readonly IEmployeeSearchService _employeeSearchService;

        public AttendanceEmployeeWrapper(IEmployeeSearchService employeeSearchService)
        {
            _employeeSearchService = employeeSearchService;
        }

        public void Wrapper(List<AttendanceModel> attendances)
        {
            if (!attendances.Any())
            {
                return;
            }
            var employeeIds = attendances.Select(s => s.EmployeeId);
            var employeees = _employeeSearchService.GetEmployee(employeeIds);
            attendances.ForEach(order =>
            {
                var employee = employeees.FirstOrDefault(s => s.Id == order.EmployeeId);
                if (employee != null)
                {
                    order.EmployeeName = employee.Name;
                }
            });
        }
    }
}
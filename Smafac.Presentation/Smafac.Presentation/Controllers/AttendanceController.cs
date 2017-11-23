using Smafac.Framework.Core.Domain.Exports;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Driver;
using Smafac.Hrs.Attendance.Applications;
using Smafac.Hrs.Attendance.Applications.Category;
using Smafac.Hrs.Attendance.Applications.Property;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Employee.Applications;
using Smafac.Presentation.Domain.Attendance;
using Smafac.Wms.Goods.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class AttendanceController : SmafacController
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IAttendanceSearchService _attendanceSearchService;
        private readonly IAttendanceCategoryService _attendanceCategoryService;
        private readonly IAttendancePropertyService _attendancePropertyService;
        private readonly IEmployeeSearchService _employeeSearchService;
        private readonly IExcelDataHaveColumnExporter _dataExporter;
        private readonly IAttendanceWrapper[] _attendanceWrappers;

        public AttendanceController(IAttendanceService AttendanceService,
                                IAttendanceSearchService AttendanceSearchService,
                                IAttendanceCategoryService AttendanceCategoryService,
                                IAttendancePropertyService AttendancePropertyService,
                                IExcelDataHaveColumnExporter dataExporter,
                                IEmployeeSearchService employeeSearchService,
                                IAttendanceWrapper[] attendanceWrappers,
                                ICommandPipeProvider commandPipeProvider)
        {
            _attendanceService = AttendanceService;
            _attendanceSearchService = AttendanceSearchService;
            _attendanceCategoryService = AttendanceCategoryService;
            _dataExporter = dataExporter;
            _attendancePropertyService = AttendancePropertyService;
            _employeeSearchService = employeeSearchService;
            _attendanceWrappers = attendanceWrappers;
            base.CommandPipeProvider = commandPipeProvider;
        }

        [HttpGet]
        public ActionResult AttendanceView(Guid? employeeId)
        {
            var categories = _attendanceCategoryService.SearchService.GetCategories();
            ViewData["categories"] = categories.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            var query = new AttendancePageQueryModel { };
            if (employeeId != null)
            {
                query.EmployeeId = employeeId.Value;
            }
            return View(query);
        }
        [HttpGet]
        public ActionResult AttendancePageView(AttendancePageQueryModel query)
        {
            var page = _attendanceSearchService.GetAttendancePage(query);
            var attendances = page.PageData;
            if (attendances.Any())
            {
                _attendanceWrappers.ToList().ForEach(wrapper =>
                {
                    wrapper.Wrapper(attendances);
                });
            }
            ViewData["tableColumns"] = page.TableColumns;
            return View(attendances);
        }
        [HttpPost]
        public ActionResult AttendancePage(AttendancePageQueryModel query)
        {
            var page = _attendanceSearchService.GetAttendancePage(query);
            return Success(page);
        }
        [HttpGet]
        public ActionResult AttendanceAddView(Guid employeeId)
        {
            var categories = _attendanceCategoryService.SearchService.GetLeafCategories()
                            .Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["categories"] = categories;
            var attendance = _attendanceService.CreateEmptyAttendance();
            var employee = _employeeSearchService.GetEmployee(employeeId);
            attendance.EmployeeId = employeeId;
            attendance.EmployeeName = employee.Name;
            return View(attendance);
        }

        [HttpPost]
        public ActionResult AddAttendance(AttendanceModel model)
        {
            var result = _attendanceService.AddAttendance(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditAttendance(AttendanceModel model)
        {
            var result = _attendanceService.UpdateService.UpdateAttendance(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult AttendanceDetailView(Guid AttendanceId)
        {
            var attendance = _attendanceSearchService.GetAttendanceDetail(AttendanceId);
            _attendanceWrappers.ToList().ForEach(wrapper =>
            {
                wrapper.Wrapper(new List<AttendanceModel> { attendance.Attendance });
            });
            return View(attendance);
        }

        [HttpGet]
        public ActionResult Export(AttendancePageQueryModel query)
        {
            var Attendance = _attendanceSearchService.GetAttendance(query);
            var properties = _attendancePropertyService.SearchService.GetColumns();
            var model = new ExportDataHaveColumnModel<AttendanceModel, AttendancePropertyModel>
            {
                Datas = Attendance,
                Columns = properties
            };
            var fileName = _dataExporter.CreateFileName("员工记录");
            var datas = _dataExporter.Export<AttendanceModel, AttendancePropertyModel>(model);
            return File(datas, "application/ms-excel", fileName);
        }
    }
}
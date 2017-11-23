using Smafac.Hrs.Attendance.Applications.Property;
using Smafac.Hrs.Attendance.Models;
using Smafac.Presentation.Domain;
using System;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class AttendancePropertyController : SmafacController
    {
        private readonly IAttendancePropertyService _attendancePropertyService;
        private readonly IPropertyTypeProvider _propertyTypeProvider;

        public AttendancePropertyController(IAttendancePropertyService attendancePropertyService,
                    IPropertyTypeProvider propertyTypeProvider)
        {
            _attendancePropertyService = attendancePropertyService;
            _propertyTypeProvider = propertyTypeProvider;
        }

        [HttpGet]
        public ActionResult AttendancePropertyView()
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            var properties = _attendancePropertyService.SearchService.GetColumns();
            return View(properties);
        }

        [HttpGet]
        public ActionResult AttendancePropertyAddView(Guid? propertyId)
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            if (propertyId == null)
            {
                return View();
            }
            else
            {
                var property = _attendancePropertyService.SearchService.GetColumn(propertyId.Value);
                return View(property);
            }
        }

        [HttpPost]
        public ActionResult AddAttendanceProperty(AttendancePropertyModel model)
        {
            var result = _attendancePropertyService.AddService.AddColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditAttendanceProperty(AttendancePropertyModel model)
        {
            var result = _attendancePropertyService.UpdateService.UpdateColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult DeleteAttendanceProperty(Guid id)
        {
            var result = _attendancePropertyService.DeleteService.DeleteColumn(id);
            return BoolResult(result);
        }
    }
}
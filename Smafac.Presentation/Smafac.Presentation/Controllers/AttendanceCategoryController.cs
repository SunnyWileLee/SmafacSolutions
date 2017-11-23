using Smafac.Framework.Core.Models;
using Smafac.Hrs.Attendance.Applications.Category;
using Smafac.Hrs.Attendance.Applications.CategoryProperty;
using Smafac.Hrs.Attendance.Applications.Property;
using Smafac.Hrs.Attendance.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class AttendanceCategoryController : SmafacController
    {
        private readonly IAttendanceCategoryService _attendanceCategoryService;
        private readonly IAttendanceCategoryPropertyBindService _attendanceCategoryPropertyBindService;
        private readonly IAttendanceCategoryPropertySearchService _attendanceCategoryPropertySearchService;
        private readonly IAttendancePropertyService _attendancePropertyService;

        public AttendanceCategoryController(IAttendanceCategoryService attendanceCategoryService,
                                       IAttendanceCategoryPropertyBindService attendanceCategoryPropertyBindService,
                                       IAttendanceCategoryPropertySearchService attendanceCategoryPropertySearchService,
                                       IAttendancePropertyService attendancePropertyService
                                        )
        {
            _attendanceCategoryService = attendanceCategoryService;
            _attendanceCategoryPropertyBindService = attendanceCategoryPropertyBindService;
            _attendanceCategoryPropertySearchService = attendanceCategoryPropertySearchService;
            _attendancePropertyService = attendancePropertyService;
        }
        [HttpGet]
        public ActionResult AttendanceCategoryView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AttendanceCategorySliceView(Guid? categoryId, int slice)
        {
            CategoryModelSet<AttendanceCategoryModel> model = (categoryId == null || categoryId.Value == Guid.Empty)
                                         ? new CategoryModelSet<AttendanceCategoryModel> { Children = _attendanceCategoryService.SearchService.GetCategories(Guid.Empty), Category = new AttendanceCategoryModel { Id = Guid.Empty } }
                                         : _attendanceCategoryService.SearchService.GetCategoryWithChildren(categoryId.Value);
            ViewData["slice"] = slice;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAttendanceCategory(AttendanceCategoryModel model)
        {
            var result = _attendanceCategoryService.AddService.AddCategory(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult AttendanceCategoryPropertyBindView(Guid categoryId)
        {
            var category = _attendanceCategoryService.SearchService.GetCategory(categoryId);
            ViewData["category"] = category;
            var properties = _attendancePropertyService.SearchService.GetColumns();
            var bounds = _attendanceCategoryPropertySearchService.GetAssociations(categoryId).Select(s => s.Id).ToList();
            ViewData["boundIds"] = bounds;
            return View(properties);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult BindProperties(CategoryBindIdsModel model)
        {
            var result = _attendanceCategoryPropertyBindService.BindAssociations(model.CategoryId, model.BindIds);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult AttendanceCategoryPropertyValueView(Guid categoryId)
        {
            var properties = _attendanceCategoryPropertySearchService.GetAssociationsIncludeParents(categoryId);
            return View(properties);
        }
    }
}
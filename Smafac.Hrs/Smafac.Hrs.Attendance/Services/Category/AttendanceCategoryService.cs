using Smafac.Hrs.Attendance.Applications.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Category;
using Smafac.Hrs.Attendance.Models;

namespace Smafac.Hrs.Attendance.Services.Category
{
    class AttendanceCategoryService : IAttendanceCategoryService
    {
        private readonly IAttendanceCategoryAddService _categoryAddService;
        private readonly IAttendanceCategoryDeleteService _categoryDeleteService;
        private readonly IAttendanceCategorySearchService _categorySearchService;
        private readonly IAttendanceCategoryUpdateService _categoryUpdateService;

        public AttendanceCategoryService(IAttendanceCategoryAddService categoryAddService,
            IAttendanceCategoryDeleteService categoryDeleteService,
            IAttendanceCategorySearchService categorySearchService,
            IAttendanceCategoryUpdateService categoryUpdateService)
        {
            _categoryAddService = categoryAddService;
            _categoryDeleteService = categoryDeleteService;
            _categorySearchService = categorySearchService;
            _categoryUpdateService = categoryUpdateService;
        }

        public ICategoryAddService<AttendanceCategoryModel> AddService => _categoryAddService;

        public ICategoryDeleteService<AttendanceCategoryModel> DeleteService => _categoryDeleteService;

        public ICategoryUpdateService<AttendanceCategoryModel> UpdateService => _categoryUpdateService;

        public ICategorySearchService<AttendanceCategoryModel> SearchService => _categorySearchService;
    }
}

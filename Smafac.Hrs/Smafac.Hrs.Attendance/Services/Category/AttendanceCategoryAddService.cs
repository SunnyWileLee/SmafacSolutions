using Smafac.Hrs.Attendance.Applications.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Hrs.Attendance.Models;
using Smafac.Framework.Core.Services.Category;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Repositories.Category;

namespace Smafac.Hrs.Attendance.Services.Category
{
    class AttendanceCategoryAddService : CategoryAddService<AttendanceCategoryEntity, AttendanceCategoryModel>, IAttendanceCategoryAddService
    {
        public AttendanceCategoryAddService(IAttendanceCategoryAddRepository categoryAddRepository,
                                        IAttendanceCategorySearchRepository categorySearchRepository)
        {
            base.CategoryAddRepository = categoryAddRepository;
            base.CategorySearchRepository = categorySearchRepository;
        }
    }
}

using Smafac.Framework.Core.Services.Category;
using Smafac.Hrs.Attendance.Applications.Category;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Models;
using Smafac.Hrs.Attendance.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Services.Category
{
    class AttendanceCategoryUpdateService : CategoryUpdateService<AttendanceCategoryEntity, AttendanceCategoryModel>, IAttendanceCategoryUpdateService
    {
        public AttendanceCategoryUpdateService(IAttendanceCategorySearchRepository categorySearchRepository,
                                          IAttendanceCategoryUpdateRepository categoryUpdateRepository)
        {
            base.CategorySearchRepository = categorySearchRepository;
            base.CategoryUpdateRepository = categoryUpdateRepository;
        }
    }
}

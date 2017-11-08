using Smafac.Framework.Core.Services.Category;
using Smafac.Hrs.Attendance.Domain;
using Smafac.Hrs.Attendance.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Services.Category
{
    class AttendanceCategoryInitialization : CategoryInitialization<AttendanceCategoryEntity>
    {
        public AttendanceCategoryInitialization(IAttendanceCategoryAddRepository categoryAddRepository,
                                        IAttendanceCategorySearchRepository categorySearchRepository
                                        )
        {
            base.CategoryAddRepository = categoryAddRepository;
            base.CategorySearchRepository = categorySearchRepository;
        }

        public override void Init(Guid subscriberId)
        {
            if (CategorySearchRepository.Any(subscriberId))
            {
                return;
            }
            IEnumerable<AttendanceCategoryEntity> categories = new List<AttendanceCategoryEntity> {
                new AttendanceCategoryEntity{
                    Name="出勤",
                    SubscriberId=subscriberId
                },
                new AttendanceCategoryEntity{
                    Name="请假",
                    SubscriberId=subscriberId
                }
            };
            CategoryAddRepository.AddEntities(categories);
        }
    }
}

using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Attendance.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Repositories
{
    class AttendanceContext : SmafacContext
    {
        public DbSet<AttendanceEntity> Attendances { get; set; }
        public DbSet<AttendanceCategoryEntity> AttendanceCategories { get; set; }
        public DbSet<AttendanceCategoryPropertyEntity> AttendanceCategoryProperties { get; set; }
        public DbSet<AttendancePropertyEntity> AttendanceProperties { get; set; }
        public DbSet<AttendancePropertyValueEntity> AttendancePropertyValues { get; set; }
    }
}

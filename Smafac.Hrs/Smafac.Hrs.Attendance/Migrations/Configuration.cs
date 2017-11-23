namespace Smafac.Hrs.Attendance.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Smafac.Hrs.Attendance.Repositories.AttendanceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Smafac.Hrs.Attendance.Repositories.AttendanceContext";
        }

        protected override void Seed(Smafac.Hrs.Attendance.Repositories.AttendanceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

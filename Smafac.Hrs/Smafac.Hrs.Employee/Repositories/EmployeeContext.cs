using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Employee.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Repositories
{
    class EmployeeContext : SmafacContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<EmployeeCategoryEntity> EmployeeCategories { get; set; }
        public DbSet<EmployeeCategoryPropertyEntity> EmployeeCategoryProperties { get; set; }
        public DbSet<EmployeePropertyEntity> EmployeeProperties { get; set; }
        public DbSet<EmployeePropertyValueEntity> EmployeePropertyValues { get; set; }
    }
}

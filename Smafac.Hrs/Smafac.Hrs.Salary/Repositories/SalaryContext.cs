using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Salary.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Repositories
{
    class SalaryContext : SmafacContext
    {
        public DbSet<SalaryEntity> Salarys { get; set; }
        public DbSet<SalaryCategoryEntity> SalaryCategories { get; set; }
        public DbSet<SalaryCategoryPropertyEntity> SalaryCategoryProperties { get; set; }
        public DbSet<SalaryPropertyEntity> SalaryProperties { get; set; }
        public DbSet<SalaryPropertyValueEntity> SalaryPropertyValues { get; set; }
    }
}

using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Repositories
{
    class CustomerFinanceContext : SmafacContext
    {
        public DbSet<CustomerFinanceCategoryPropertyEntity> CustomerFinanceCategoryProperties { get; set; }
        public DbSet<CustomerFinanceCategoryEntity> CustomerFinanceCategories { get; set; }
        public DbSet<CustomerFinanceEntity> CustomerFinances{ get; set; }
        public DbSet<CustomerFinancePropertyEntity> CustomerFinanceProperties { get; set; }
        public DbSet<CustomerFinancePropertyValueEntity> CustomerFinancePropertyValues { get; set; }
    }
}

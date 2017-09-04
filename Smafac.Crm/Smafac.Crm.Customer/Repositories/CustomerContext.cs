using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerContext : SmafacContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CustomerPropertyEntity> CustomerProperties { get; set; }
        public DbSet<CustomerPropertyValueEntity> CustomerPropertyValues { get; set; }
    }
}

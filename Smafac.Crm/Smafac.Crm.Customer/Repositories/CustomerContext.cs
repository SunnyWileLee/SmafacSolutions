using Smafac.Crm.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerContext : DbContext
    {
        public CustomerContext()
            : base("MssqlConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CustomerPropertyEntity> CustomerProperties { get; set; }
        public DbSet<CustomerPropertyValueEntity> CustomerPropertyValues { get; set; }
        public DbSet<CustomerLevelEntity> CustomerLevels { get; set; }
        public DbSet<CustomerPayTypeEntity> CustomerPayTypes { get; set; }
        public DbSet<CustomerContactEntity> CustomerContacts { get; set; }
        public DbSet<CustomerContactPropertyEntity> CustomerContactPropertites { get; set; }
        public DbSet<CustomerContactPropertyValueEntity> CustomerContactPropertyValues { get; set; }
        public DbSet<CustomerScoreEntity> CustomerScores { get; set; }
        public DbSet<CustomerVisitEntity> CustomerVisits { get; set; }
        public DbSet<CustomerReceiveEntity> CustomerReceives { get; set; }
    }
}

using Smafac.Account.Subscriber.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Repositories
{
    class SubscriberContext : DbContext
    {
        public SubscriberContext()
            : base("MssqlConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PassportEntity> Passports { get; set; }
        public DbSet<SubscriberEntity> Subscribers { get; set; }
        public DbSet<SignInEntity> SignIns { get; set; }
    }
}

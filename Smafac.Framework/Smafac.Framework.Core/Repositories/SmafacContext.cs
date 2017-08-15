using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public abstract class SmafacContext : DbContext
    {
        public SmafacContext()
            : base("MssqlConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

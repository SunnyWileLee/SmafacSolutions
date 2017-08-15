using Smafac.ServiceCenter.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Repositories
{
    class ServiceCenterContext : DbContext
    {
        public DbSet<ApiEntity> Apis { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }
    }
}

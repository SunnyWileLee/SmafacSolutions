using Smafac.Infrustructure.Base;
using Smafac.Infrustructure.Config.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Config.Repositories
{
    class ConfigContext : InfrustructureContext
    {
        public DbSet<ConfigEntity> Configs { get; set; }
    }
}

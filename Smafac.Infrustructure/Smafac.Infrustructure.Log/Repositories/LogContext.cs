using Smafac.Infrustructure.Base;
using Smafac.Infrustructure.Log.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Log.Repositories
{
    class LogContext : InfrustructureContext
    {
        public DbSet<LogEntity> Logs { get; set; }
    }
}

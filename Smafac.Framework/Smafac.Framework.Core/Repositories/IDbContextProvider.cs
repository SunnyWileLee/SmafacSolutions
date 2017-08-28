using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public interface IDbContextProvider<TDbContext> where TDbContext : DbContext
    {
        TDbContext Provide();
        TDbContext ProvideSlave();
    }
}

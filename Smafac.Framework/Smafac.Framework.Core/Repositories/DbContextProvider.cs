using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public abstract class DbContextProvider : IDbContextProvider<SmafacContext>
    {
        public abstract SmafacContext Provide();

        public abstract SmafacContext ProvideSlave();
    }
}

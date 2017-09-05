using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Domain.CustomizedColumn;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.CustomizedColumn
{
    public abstract class CustomizedColumnAddRepository<TContext, TCustomizedColumn> : EntityAddRepository<TContext, TCustomizedColumn>, ICustomizedColumnAddRepository<TCustomizedColumn>
         where TCustomizedColumn : CustomizedColumnEntity
         where TContext : DbContext
    {

    }
}

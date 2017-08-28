using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public abstract class EntityRepository<TContext, TEntity> : IEntityRepository<TEntity>
        where TEntity : SaasBaseEntity
        where TContext : DbContext
    {
        public virtual IDbContextProvider<TContext> ContextProvider { get; protected set; }
    }
}

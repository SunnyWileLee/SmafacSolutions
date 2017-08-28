using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Property
{
    public abstract class PropertySearchRepository<TContext, TProperty> : EntitySearchRepository<TContext, TProperty>, IPropertySearchRepository<TProperty>
         where TProperty : PropertyEntity
         where TContext : DbContext
    {
        public virtual bool Any(Guid subscriberId, string name)
        {
            using (var context = ContextProvider.Provide())
            {
                return context.Set<TProperty>().Any(s => s.SubscriberId == subscriberId && s.Name.Equals(name));
            }
        }
    }
}

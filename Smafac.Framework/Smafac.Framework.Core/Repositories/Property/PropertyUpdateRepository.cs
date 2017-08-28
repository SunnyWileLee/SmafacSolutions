using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Property
{
    public abstract class PropertyUpdateRepository<TContext, TProperty> : EntityUpdateRepository<TContext, TProperty>, IPropertyUpdateRepository<TProperty>
         where TProperty : PropertyEntity
         where TContext : DbContext
    {
        protected override void SetValue(TProperty entity, TProperty souce)
        {
            entity.Name = souce.Name;
        }
    }
}

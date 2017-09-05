using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Repositories.CustomizedColumn;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Property
{
    public abstract class PropertyUpdateRepository<TContext, TProperty> : CustomizedColumnUpdateRepository<TContext, TProperty>, IPropertyUpdateRepository<TProperty>
         where TProperty : PropertyEntity
         where TContext : DbContext
    {
        protected override void SetValue(TProperty entity, TProperty source)
        {
            base.SetValue(entity, source);
        }
    }
}

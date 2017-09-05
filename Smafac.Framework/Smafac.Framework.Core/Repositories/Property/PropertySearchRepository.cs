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
    public abstract class PropertySearchRepository<TContext, TProperty> : CustomizedColumnSearchRepository<TContext, TProperty>, IPropertySearchRepository<TProperty>
         where TProperty : PropertyEntity
         where TContext : DbContext
    {

    }
}

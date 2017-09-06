using Smafac.Framework.Core.Domain.CustomizedColumn;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace Smafac.Framework.Core.Repositories.CustomizedColumn
{
    public abstract class CustomizedColumnSearchRepository<TContext, TCustomizedColumn> : EntitySearchRepository<TContext, TCustomizedColumn>, ICustomizedColumnSearchRepository<TCustomizedColumn>
         where TCustomizedColumn : CustomizedColumnEntity
         where TContext : DbContext
    {
        public virtual bool Any(Guid subscriberId, string name)
        {
            using (var context = ContextProvider.Provide())
            {
                return context.Set<TCustomizedColumn>().Any(s => s.SubscriberId == subscriberId && s.Name.Equals(name));
            }
        }

        public IEnumerable<TCustomizedColumn> SelectTableColumns(Guid subscriberId)
        {
            using (var context = ContextProvider.Provide())
            {
                var columns = context.Set<TCustomizedColumn>().Where(s => s.SubscriberId == subscriberId && s.IsTableColumn)
                                .ToList();
                return columns;
            }
        }
    }
}

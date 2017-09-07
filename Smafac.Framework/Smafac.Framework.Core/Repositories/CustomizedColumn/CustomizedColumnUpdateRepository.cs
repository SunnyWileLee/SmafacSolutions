using Smafac.Framework.Core.Domain.CustomizedColumn;
using System.Data.Entity;

namespace Smafac.Framework.Core.Repositories.CustomizedColumn
{
    public abstract class CustomizedColumnUpdateRepository<TContext, TCustomizedColumn> : EntityUpdateRepository<TContext, TCustomizedColumn>, ICustomizedColumnUpdateRepository<TCustomizedColumn>
         where TCustomizedColumn : CustomizedColumnEntity
         where TContext : DbContext
    {
        protected override void SetValue(TCustomizedColumn entity, TCustomizedColumn source)
        {
            entity.Name = source.Name;
            entity.IsDeleteAssociations = source.IsDeleteAssociations;
            entity.IsTableColumn = source.IsTableColumn;
        }
    }
}

using Smafac.Framework.Core.Domain.CustomizedColumn;
using System.Data.Entity;

namespace Smafac.Framework.Core.Repositories.CustomizedColumn
{
    public abstract class CustomizedColumnDeleteRepository<TContext, TCustomizedColumn> : EntityDeleteRepository<TContext, TCustomizedColumn>, ICustomizedColumnDeleteRepository<TCustomizedColumn>
         where TCustomizedColumn : CustomizedColumnEntity
         where TContext : DbContext
    {

    }
}

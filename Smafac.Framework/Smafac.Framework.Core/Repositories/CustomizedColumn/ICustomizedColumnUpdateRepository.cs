using Smafac.Framework.Core.Domain.CustomizedColumn;

namespace Smafac.Framework.Core.Repositories.CustomizedColumn
{
    public interface ICustomizedColumnUpdateRepository<TCustomizedColumn> : IEntityUpdateRepository<TCustomizedColumn>
        where TCustomizedColumn : CustomizedColumnEntity
    {
    }
}

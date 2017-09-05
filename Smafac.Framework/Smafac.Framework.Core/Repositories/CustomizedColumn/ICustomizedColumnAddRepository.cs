using Smafac.Framework.Core.Domain.CustomizedColumn;

namespace Smafac.Framework.Core.Repositories.CustomizedColumn
{
    public interface ICustomizedColumnAddRepository<TCustomizedColumn> : IEntityAddRepository<TCustomizedColumn>
        where TCustomizedColumn : CustomizedColumnEntity
    {
    }
}

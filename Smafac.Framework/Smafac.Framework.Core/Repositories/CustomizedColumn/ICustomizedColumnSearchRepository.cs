using Smafac.Framework.Core.Domain.CustomizedColumn;
using System;

namespace Smafac.Framework.Core.Repositories.CustomizedColumn
{
    public interface ICustomizedColumnSearchRepository<TCustomizedColumn> : IEntitySearchRepository<TCustomizedColumn>
        where TCustomizedColumn : CustomizedColumnEntity
    {
        bool Any(Guid subscriberId, string name);
    }
}

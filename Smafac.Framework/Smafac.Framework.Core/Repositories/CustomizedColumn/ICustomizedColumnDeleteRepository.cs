using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Domain.CustomizedColumn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.CustomizedColumn
{
    public interface ICustomizedColumnDeleteRepository<TCustomizedColumn> : IEntityDeleteRepository<TCustomizedColumn>
        where TCustomizedColumn : CustomizedColumnEntity
    {
    }
}

using Smafac.Framework.Core.Domain.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.CustomizedColumn
{
    public interface ICustomizedColumnAddTrigger<TCustomizedColumnEntity> : IEntityTrigger<TCustomizedColumnEntity>
        where TCustomizedColumnEntity : CustomizedColumnEntity
    {
        bool Added(TCustomizedColumnEntity entity);
    }
}

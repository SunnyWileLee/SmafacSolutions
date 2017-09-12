using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Triggers
{
    public interface IEntityDeleteTrigger<TEntity> : IEntityTrigger<TEntity>
        where TEntity : SaasBaseEntity
    {
        bool Deleted(TEntity entity);
    }
}

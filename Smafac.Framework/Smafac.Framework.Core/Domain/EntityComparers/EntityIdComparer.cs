using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.EntityComparers
{
    public class EntityIdComparer<TEntity> : IEqualityComparer<TEntity> where TEntity : SaasBaseEntity
    {
        public bool Equals(TEntity x, TEntity y)
        {
            if (x == null)
                return y == null;
            return x.Id == y.Id && x.SubscriberId == y.SubscriberId;
        }

        public int GetHashCode(TEntity obj)
        {
            if (obj == null)
                return 0;
            return obj.Id.GetHashCode();
        }
    }
}

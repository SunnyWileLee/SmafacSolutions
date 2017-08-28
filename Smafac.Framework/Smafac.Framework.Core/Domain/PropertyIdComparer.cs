using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public class PropertyIdComparer<TProperty> : IEqualityComparer<TProperty> where TProperty : PropertyEntity
    {
        public bool Equals(TProperty x, TProperty y)
        {
            if (x == null)
                return y == null;
            return x.Id == y.Id && x.SubscriberId == y.SubscriberId;
        }

        public int GetHashCode(TProperty obj)
        {
            if (obj == null)
                return 0;
            return obj.Id.GetHashCode();
        }
    }
}

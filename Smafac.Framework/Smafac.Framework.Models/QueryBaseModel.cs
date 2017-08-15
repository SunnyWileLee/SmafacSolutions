using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class QueryBaseModel
    {
        public Guid SubscriberId { get; set; }

        public virtual Expression<Func<TEntity, bool>> CreatePredicate<TEntity>()
            where TEntity : class
        {
            return s => true;
        }
    }
}

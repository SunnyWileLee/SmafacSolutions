using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public abstract class QueryBaseModel
    {
        public Guid SubscriberId { get; set; }

        public virtual Expression CreateExpressionBody(Expression param)
        {
            return null;
        }
    }
}

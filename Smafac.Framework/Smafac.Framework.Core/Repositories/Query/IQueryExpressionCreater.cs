using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Query
{
    public interface IQueryExpressionCreater<TEntity> where TEntity : SaasBaseEntity
    {
        Expression<Func<TEntity, bool>> Create(QueryBaseModel model);
    }
}

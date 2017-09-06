using Smafac.Framework.Core.Domain;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Pages
{
    public interface IPageQueryRepository<TEntity, TModel>
        where TEntity : SaasBaseEntity
        where TModel : SaasBaseModel
    {
        List<TModel> QueryPage(Guid subscriberId, Expression<Func<TEntity, bool>> predicate, int skip, int take);
        int QueryCount(Guid subscriberId, Expression<Func<TEntity, bool>> predicate);
    }
}

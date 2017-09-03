using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Query
{
    public interface IQueryExpressionCreaterProvider
    {
        IQueryExpressionCreater<TEntity> Provide<TEntity>() where TEntity : SaasBaseEntity;
    }
}

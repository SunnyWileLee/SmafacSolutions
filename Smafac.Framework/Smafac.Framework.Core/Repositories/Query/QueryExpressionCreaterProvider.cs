using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Domain;

namespace Smafac.Framework.Core.Repositories.Query
{
    class QueryExpressionCreaterProvider : IQueryExpressionCreaterProvider
    {
        private readonly IQueryPropertyProvider _queryPropertyProvider;

        public QueryExpressionCreaterProvider(IQueryPropertyProvider queryPropertyProvider)
        {
            _queryPropertyProvider = queryPropertyProvider;
        }

        public IQueryExpressionCreater<TEntity> Provide<TEntity>() where TEntity : SaasBaseEntity
        {
            return new QueryExpressionCreater<TEntity>(_queryPropertyProvider);
        }
    }
}

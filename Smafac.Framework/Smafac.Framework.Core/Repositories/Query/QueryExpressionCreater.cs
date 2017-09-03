using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Models;
using System.Linq.Expressions;

namespace Smafac.Framework.Core.Repositories.Query
{
    class QueryExpressionCreater<TEntity> : IQueryExpressionCreater<TEntity> where TEntity : SaasBaseEntity
    {
        private readonly IQueryPropertyProvider _queryPropertyProvider;

        public QueryExpressionCreater(IQueryPropertyProvider queryPropertyProvider)
        {
            _queryPropertyProvider = queryPropertyProvider;
        }

        public Expression<Func<TEntity, bool>> Create(QueryBaseModel model)
        {
            var param = this.CreateParameter();
            Expression body = null;
            var properties = _queryPropertyProvider.Provide(model);
            foreach (var property in properties)
            {
                var value = property.Property.GetValue(model);

                if (!property.Query.AllowDefault)
                {
                    if (property.Property.PropertyType.IsValueType)
                    {
                        var defaultValue = Activator.CreateInstance(property.Property.PropertyType);
                        if (value.Equals(defaultValue))//务必用equals比较，==是不对的
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (value == null)
                        {
                            continue;
                        }
                    }
                }

                var expression = property.Query.CreateExpression(param, value);
                if (body == null)
                {
                    body = expression;
                }
                else
                {
                    body = Expression.AndAlso(body, expression);
                }
            };
            Expression<Func<TEntity, bool>> filter = body == null ? s => true : Expression.Lambda<Func<TEntity, bool>>(body, param);
            return filter;
        }

        private ParameterExpression CreateParameter()
        {
            return Expression.Parameter(typeof(TEntity), "param");
        }
    }
}

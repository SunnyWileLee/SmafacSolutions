using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using AutoMapper;

namespace Smafac.Framework.Core.Repositories.Pages
{
    public abstract class PageQueryRepository<TContext, TEntity, TModel> : EntityRepository<TContext, TEntity>,
                                                                        IPageQueryRepository<TEntity, TModel>
        where TContext : DbContext
        where TEntity : SaasBaseEntity
        where TModel : SaasBaseModel
    {
        public int QueryCount(Guid subscriberId, Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = base.ContextProvider.Provide())
            {
                var count = CreateQuery(context, subscriberId).Count(predicate);
                return count;
            }
        }

        public List<TModel> QueryPage(Guid subscriberId, Expression<Func<TEntity, bool>> predicate, int skip, int take)
        {
            using (var context = base.ContextProvider.Provide())
            {
                var query = this.OrderQuery(CreateQuery(context, subscriberId).Where(predicate))
                                .Skip(skip).Take(take);
                return SelectModel(query, context);
            }
        }

        protected virtual List<TModel> SelectModel(IQueryable<TEntity> query, TContext context)
        {
            return Mapper.Map<List<TModel>>(query.ToList());
        }

        protected virtual IQueryable<TEntity> OrderQuery(IQueryable<TEntity> query)
        {
            return query.OrderByDescending(s => s.CreateTime);
        }

        protected virtual IQueryable<TEntity> CreateQuery(DbContext context, Guid subscriberId)
        {
            return context.Set<TEntity>().Where(s => s.SubscriberId == subscriberId);
        }

    }
}

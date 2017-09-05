using Smafac.Framework.Core.Domain;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.PropertyValue
{
    public abstract class PropertyValueSearchRepository<TContext, TPropertyValue, TProperty, TPropertyValueModel> : EntityRepository<TContext, TPropertyValue>,
                                             IPropertyValueSearchRepository<TPropertyValueModel>
         where TContext : DbContext
         where TPropertyValue : PropertyValueEntity
         where TProperty : PropertyEntity
         where TPropertyValueModel : PropertyValueModel
    {
        public virtual bool Any(Guid subscriberId, Guid propertyId)
        {
            using (var context = base.ContextProvider.Provide())
            {
                return context.Set<TPropertyValue>().Any(s => s.SubscriberId == subscriberId && s.PropertyId == propertyId);
            }
        }

        public List<TPropertyValueModel> GetPropertyValues(Guid subscriberId, Guid entityId)
        {
            using (var context = base.ContextProvider.Provide())
            {
                var values = SelectValues(context.Set<TPropertyValue>(), subscriberId, entityId);
                var properties = context.Set<TProperty>().Where(s => s.SubscriberId == subscriberId);
                var query = this.JoinProperty(values, properties);
                return query.ToList();
            }
        }
        protected virtual IQueryable<TPropertyValue> SelectValues(IQueryable<TPropertyValue> values, Guid subscriberId, Guid entityId)
        {
            var predicate = CreateEntityQueryExpression(entityId);
            return values.Where(s => s.SubscriberId == subscriberId).Where(predicate);
        }
        protected virtual IQueryable<TPropertyValue> SelectValues(IQueryable<TPropertyValue> values, Guid subscriberId, IEnumerable<Guid> entityIds)
        {
            var predicate = CreateEntityQueryExpression(entityIds);
            return values.Where(s => s.SubscriberId == subscriberId).Where(predicate);
        }

        protected abstract Expression<Func<TPropertyValue, bool>> CreateEntityQueryExpression(Guid entityId);
        protected abstract Expression<Func<TPropertyValue, bool>> CreateEntityQueryExpression(IEnumerable<Guid> entityIds);

        protected abstract IQueryable<TPropertyValueModel> JoinProperty(IQueryable<TPropertyValue> values, IQueryable<TProperty> properties);

        public IEnumerable<IGrouping<Guid, TPropertyValueModel>> GetPropertyValues(Guid subscriberId, IEnumerable<Guid> entityIds)
        {
            using (var context = base.ContextProvider.Provide())
            {
                var values = SelectValues(context.Set<TPropertyValue>(), subscriberId, entityIds);
                var properties = context.Set<TProperty>().Where(s => s.SubscriberId == subscriberId);
                var query = this.JoinProperty(values, properties);
                return GroupValues(query).ToList();
            }
        }

        protected abstract IEnumerable<IGrouping<Guid, TPropertyValueModel>> GroupValues(IEnumerable<TPropertyValueModel> values);
    }
}

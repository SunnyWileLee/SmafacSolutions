using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.PropertyValue
{
    public abstract class PropertyValueSetRepository<TContext, TPropertyValue> : EntityRepository<TContext, TPropertyValue>
                                                            , IPropertyValueSetRepository<TPropertyValue>
        where TContext : DbContext
        where TPropertyValue : PropertyValueEntity
    {
        protected virtual bool AutoCover
        {
            get
            {
                return false;
            }
        }

        public virtual bool AddPropertyValues(Guid entityId, IEnumerable<TPropertyValue> values)
        {
            if (values.Any(s => s.IsAnonymous()))
            {
                return false;
            }
            if (values.Any(s => this.VerifyEntityId(entityId, s)))
            {
                return false;
            }
            using (var context = base.ContextProvider.Provide())
            {
                var valueQuery = context.Set<TPropertyValue>();
                if (HasSetValue(valueQuery, entityId))
                {
                    return false;
                }
                valueQuery.AddRange(values);
                return context.SaveChanges() > 0;
            }
        }

        protected abstract bool VerifyEntityId(Guid entityId, TPropertyValue value);
        protected abstract bool HasSetValue(IQueryable<TPropertyValue> values, Guid entityId);

        public virtual bool SetPropertyValue(TPropertyValue model)
        {
            using (var context = base.ContextProvider.Provide())
            {
                var value = context.Set<TPropertyValue>().FirstOrDefault(s => s.SubscriberId == model.SubscriberId && s.Id == model.Id);
                if (value == null)
                {
                    return false;
                }
                ModifyValue(value, model);
                return context.SaveChanges() > 0;
            }
        }

        protected virtual void ModifyValue(TPropertyValue source, TPropertyValue value)
        {
            source.Value = value.Value;
        }
    }
}

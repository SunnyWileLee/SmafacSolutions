using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.CategoryProperty
{
    public abstract class CategoryPropertyBindRepository<TContext, TCategory, TProperty, TCategoryProperty> : ICategoryPropertyBindRepository<TCategory, TProperty>
        where TContext : DbContext
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
        where TCategoryProperty : CategoryPropertyEntity
    {
        public virtual IDbContextProvider<TContext> ContextProvider { get; protected set; }

        public virtual bool BindProperties(Guid subscriberId, Guid categoryId, IEnumerable<Guid> propertyIds)
        {
            using (var context = ContextProvider.Provide())
            {
                if (!context.Set<TCategory>().Any(s => s.SubscriberId == subscriberId && s.Id == categoryId))
                {
                    return false;
                }
                var allPropertyIds = context.Set<TProperty>().Where(s => s.SubscriberId == subscriberId).Select(s => s.Id).ToList();
                if (propertyIds.Any(p => !allPropertyIds.Contains(p)))
                {
                    return false;
                }
                var binds = this.CreateBinds(subscriberId, categoryId, propertyIds);
                context.Set<TCategoryProperty>().AddRange(binds);
                return context.SaveChanges() > 0;
            }
        }

        protected virtual IEnumerable<TCategoryProperty> CreateBinds(Guid subscriberId, Guid categoryId, IEnumerable<Guid> propertyIds)
        {
            var binds = propertyIds.Select(propertyId =>
            {
                var bind = default(TCategoryProperty);
                bind.SubscriberId = subscriberId;
                bind.CategoryId = categoryId;
                bind.PropertyId = propertyId;
                return bind;
            });
            return binds;
        }

        public virtual bool UnbindProperties(Guid subscriberId, Guid categoryId)
        {
            using (var context = ContextProvider.Provide())
            {
                var properties = context.Set<TCategoryProperty>().Where(s => s.SubscriberId == subscriberId && s.CategoryId == categoryId);
                context.Set<TCategoryProperty>().RemoveRange(properties);
                return context.SaveChanges() > 0;
            }
        }
    }
}

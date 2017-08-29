using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.CategoryProperty
{
    public abstract class CategoryPropertySearchRepository<TContext, TCategory, TProperty, TCategoryProperty> : ICategoryPropertySearchRepository<TCategory, TProperty>
        where TContext : DbContext
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
        where TCategoryProperty : CategoryPropertyEntity
    {

        public virtual IDbContextProvider<TContext> ContextProvider { get; protected set; }

        public virtual List<TProperty> GetProperties(Guid subscriberId, Guid categoryId)
        {
            using (var context = ContextProvider.Provide())
            {
                var propertyIds = context.Set<TCategoryProperty>()
                                        .Where(s => s.SubscriberId == subscriberId && s.CategoryId == categoryId)
                                        .Select(s => s.PropertyId).ToList();

                var properties = context.Set<TProperty>()
                                        .Where(s => s.SubscriberId == subscriberId && propertyIds.Contains(s.Id))
                                        .ToList();
                return properties;
            }
        }

        public virtual bool IsBound(Guid subscriberId, Guid categoryId)
        {
            using (var context = ContextProvider.Provide())
            {
                return context.Set<TCategoryProperty>().Any(s => s.SubscriberId == subscriberId && s.CategoryId == categoryId);
            }
        }
    }
}

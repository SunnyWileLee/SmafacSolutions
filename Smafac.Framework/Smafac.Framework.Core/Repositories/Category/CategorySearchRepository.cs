using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Category
{
    public abstract class CategorySearchRepository<TContext, TCategory> : EntitySearchRepository<TContext, TCategory>,
                                                                            ICategorySearchRepository<TCategory>
         where TCategory : CategoryEntity
         where TContext : DbContext
    {
        public virtual bool Any(Guid subscriberId, string name)
        {
            using (var context = ContextProvider.Provide())
            {
                return context.Set<TCategory>().Any(s => s.SubscriberId == subscriberId && s.Name.Equals(name));
            }
        }

        public virtual bool Any(Guid subscriberId)
        {
            using (var context = ContextProvider.Provide())
            {
                return context.Set<TCategory>().Any(s => s.SubscriberId == subscriberId);
            }
        }

        public virtual List<TCategory> GetCategories(Guid subscriberId, Guid parentId)
        {
            using (var context = ContextProvider.Provide())
            {
                return context.Set<TCategory>().Where(s => s.SubscriberId == subscriberId && s.ParentId.Equals(parentId)).ToList();
            }
        }

        public virtual TCategory GetCategory(Guid subscriberId, Guid categoryId)
        {
            using (var context = ContextProvider.Provide())
            {
                return context.Set<TCategory>().FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id.Equals(categoryId));
            }
        }
    }
}

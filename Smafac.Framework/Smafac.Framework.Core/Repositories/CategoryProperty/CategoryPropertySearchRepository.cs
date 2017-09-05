using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Repositories.CategoryAssociation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.CategoryProperty
{
    public abstract class CategoryPropertySearchRepository<TContext, TCategory, TProperty, TCategoryProperty> :
        CategoryAssociationSearchRepository<TContext, TCategory, TProperty, TCategoryProperty>,
        ICategoryPropertySearchRepository<TCategory, TProperty>
        where TContext : DbContext
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
        where TCategoryProperty : CategoryPropertyEntity
    {
        protected override IEnumerable<Guid> GetAssociationIds(IQueryable<TCategoryProperty> binds, Guid entityId)
        {
            var propertyIds = binds.Where(s => s.CategoryId == entityId)
                .Select(s => s.PropertyId).ToList();
            return propertyIds;
        }
        public override bool Any(Guid subscriberId, Guid associationId)
        {
            using (var context = ContextProvider.Provide())
            {
                return context.Set<TCategoryProperty>().Any(s => s.SubscriberId == subscriberId && s.PropertyId == associationId);
            }
        }
    }
}

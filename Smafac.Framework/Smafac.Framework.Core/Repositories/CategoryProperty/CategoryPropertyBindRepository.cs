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
    public abstract class CategoryPropertyBindRepository<TContext, TCategory, TProperty, TCategoryProperty> :
        CategoryAssociationBindRepository<TContext, TCategory, TProperty, TCategoryProperty>,
        ICategoryPropertyBindRepository<TCategory, TProperty>
        where TContext : DbContext
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
        where TCategoryProperty : CategoryPropertyEntity
    {
        protected override IEnumerable<TCategoryProperty> CreateBinds(Guid subscriberId, Guid categoryId, IEnumerable<Guid> propertyIds)
        {
            var binds = propertyIds.Select(propertyId =>
            {
                var bind = Activator.CreateInstance<TCategoryProperty>();
                bind.SubscriberId = subscriberId;
                bind.CategoryId = categoryId;
                bind.PropertyId = propertyId;
                return bind;
            });
            return binds;
        }

        protected override IEnumerable<TCategoryProperty> GetBinds(IQueryable<TCategoryProperty> binds, Guid entityId)
        {
            return binds.Where(s => s.CategoryId.Equals(entityId));
        }
    }
}

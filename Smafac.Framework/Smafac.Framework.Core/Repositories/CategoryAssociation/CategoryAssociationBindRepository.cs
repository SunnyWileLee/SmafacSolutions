using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Repositories.CategoryAssociation;
using Smafac.Framework.Core.Repositories.EntityAssociation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.CategoryAssociation
{
    public abstract class CategoryAssociationBindRepository<TContext, TCategory, TAssociation, TCategoryAssociation> :
        EntityAssociationBindRepository<TContext, TCategory, TAssociation, TCategoryAssociation>,
        ICategoryAssociationBindRepository<TCategory, TAssociation>
        where TContext : DbContext
        where TCategory : CategoryEntity
        where TAssociation : SaasBaseEntity
        where TCategoryAssociation : CategoryAssociationEntity
    {
        protected override IEnumerable<TCategoryAssociation> CreateBinds(Guid subscriberId, Guid categoryId, IEnumerable<Guid> propertyIds)
        {
            var binds = propertyIds.Select(propertyId =>
            {
                var bind = Activator.CreateInstance<TCategoryAssociation>();
                bind.SubscriberId = subscriberId;
                bind.CategoryId = categoryId;
                return bind;
            });
            return binds;
        }
    }
}

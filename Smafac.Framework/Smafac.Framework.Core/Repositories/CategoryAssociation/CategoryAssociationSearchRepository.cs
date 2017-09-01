using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Repositories.EntityAssociation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.CategoryAssociation
{
    public abstract class CategoryAssociationSearchRepository<TContext, TCategory, TAssociation, TCategoryAssociation> :
        EntityAssociationSearchRepository<TContext, TCategory, TAssociation, TCategoryAssociation>,
        IEntityAssociationSearchRepository<TCategory, TAssociation>
        where TContext : DbContext
        where TCategory : CategoryEntity
        where TAssociation : SaasBaseEntity
        where TCategoryAssociation : CategoryAssociationEntity
    {

        protected override bool IsBound(IQueryable<TCategoryAssociation> binds, Guid entityId)
        {
            return binds.Any(s => s.CategoryId == entityId);
        }
    }
}

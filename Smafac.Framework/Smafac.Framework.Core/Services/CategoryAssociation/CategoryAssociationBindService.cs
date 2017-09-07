using Smafac.Framework.Core.Applications.CategoryAssociation;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Domain.CategoryAssociation;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories;
using Smafac.Framework.Core.Repositories.Category;
using Smafac.Framework.Core.Services.EntityAssociation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services.CategoryAssociation
{
    public abstract class CategoryAssociationBindService<TCategory, TAssociation> :
                            EntityAssociationBindService<TCategory, TAssociation>,
                            ICategoryAssociationBindService
         where TCategory : CategoryEntity
        where TAssociation : SaasBaseEntity
    {
        public virtual IEnumerable<ICategoryAssociationBindTrigger<TCategory, TAssociation>> CategoryAssociationBindTriggers
        {
            get; protected set;
        }

        public virtual ICategorySearchRepository<TCategory> CategorySearchRepository
        {
            get; protected set;
        }

        public virtual IEntitySearchRepository<TAssociation> AssociationSearchRepository
        {
            get; protected set;
        }

        protected override bool Compensate(Guid categoryId, IEnumerable<Guid> compensates)
        {
            var compensate = true;
            if (CategoryAssociationBindTriggers == null)
            {
                return compensate;
            }
            var subscriberId = UserContext.Current.SubscriberId;
            var category = CategorySearchRepository.GetEntity(subscriberId, categoryId);
            if (category == null)
            {
                return false;
            }
            var associations = AssociationSearchRepository.GetEntities(subscriberId, s => compensates.Contains(s.Id));
            associations.ForEach(association =>
            {
                CategoryAssociationBindTriggers.ToList().ForEach(
                    trigger =>
                    {
                        compensate &= trigger.Bound(category, association);
                    }
                    );
            });
            return compensate;
        }
    }
}

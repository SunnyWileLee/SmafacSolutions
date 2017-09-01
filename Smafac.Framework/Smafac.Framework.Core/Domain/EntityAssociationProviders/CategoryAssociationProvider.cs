using AutoMapper;
using Smafac.Framework.Core.Domain.EntityComparers;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Category;
using Smafac.Framework.Core.Repositories.CategoryAssociation;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.EntityAssociationProviders
{
    public abstract class CategoryAssociationProvider<TCategory, TAssociation, TAssociationModel> :
                        IEntityAssociationProvider<TAssociationModel>
    where TCategory : CategoryEntity
    where TAssociation : SaasBaseEntity
    where TAssociationModel : SaasBaseModel
    {
        public virtual ICategorySearchRepository<TCategory> CategorySearchRepository
        {
            get; protected set;
        }

        public virtual ICategoryAssociationSearchRepository<TCategory, TAssociation> CategoryAssociationSearchRepository
        {
            get; protected set;
        }

        public virtual List<TAssociationModel> ProvideAssociations(Guid entityId)
        {
            var associations = this.GetAssociations(entityId);
            return Mapper.Map<List<TAssociationModel>>(associations);
        }

        protected virtual CategoryEntity GetCategory(Guid categoryId)
        {
            return CategorySearchRepository.GetCategory(UserContext.Current.SubscriberId, categoryId);
        }

        protected virtual IEnumerable<TAssociation> GetAssociations(Guid entityId)
        {
            if (entityId == Guid.Empty)
            {
                return new List<TAssociation>();
            }
            var category = this.GetCategory(entityId);
            if (category == null)
            {
                return new List<TAssociation>();
            }
            var associations = CategoryAssociationSearchRepository.GetAssociations(UserContext.Current.SubscriberId, entityId);
            if (category.IsRoot())
            {
                return associations.ToList();
            }
            return this.GetAssociations(category.ParentId).Union(associations).Distinct(new EntityIdComparer<TAssociation>()).ToList();
        }
    }
}

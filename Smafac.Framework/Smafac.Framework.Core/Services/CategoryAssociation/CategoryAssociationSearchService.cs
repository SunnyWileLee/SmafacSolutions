using Smafac.Framework.Core.Applications.CategoryAssociation;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Framework.Core.Services.EntityAssociation;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services.CategoryAssociation
{
    public abstract class CategoryAssociationSearchService<TCategory, TAssociation, TAssociationModel> :
                    EntityAssociationSearchService<TCategory, TAssociation, TAssociationModel>,
                    ICategoryAssociationSearchService<TAssociationModel>
        where TCategory : CategoryEntity
        where TAssociation : SaasBaseEntity
        where TAssociationModel : SaasBaseModel

    {
        public virtual IEntityAssociationProvider<TAssociationModel> CategoryAssociationProvider
        {
            get; protected set;
        }

        public virtual List<TAssociationModel> GetAssociationsIncludeParents(Guid categoryId)
        {
            var associations = CategoryAssociationProvider.ProvideAssociations(categoryId);
            return associations;
        }
    }
}

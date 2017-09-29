using Smafac.Framework.Core.Applications.EntityAssociation;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;

namespace Smafac.Framework.Core.Applications.CategoryAssociation
{
    public interface ICategoryAssociationSearchService<TAssociationModel> : IEntityAssociationSearchService<TAssociationModel>
        where TAssociationModel : SaasBaseModel
    {
        List<TAssociationModel> GetAssociationsIncludeParents(Guid categoryId);
    }
}

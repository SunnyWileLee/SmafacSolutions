using Smafac.Framework.Core.Applications.EntityAssociation;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.CategoryAssociation
{
    public interface ICategoryAssociationSearchService<TAssociation> : IEntityAssociationSearchService<TAssociation>
        where TAssociation : SaasBaseModel
    {
        List<TAssociation> GetPropertiesIncludeParents(Guid categoryId);
    }
}

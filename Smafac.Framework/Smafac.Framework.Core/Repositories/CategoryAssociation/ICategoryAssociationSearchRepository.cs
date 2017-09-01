using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Repositories.EntityAssociation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.CategoryAssociation
{
    public interface ICategoryAssociationSearchRepository<TCategory, TAssociation>: IEntityAssociationSearchRepository<TCategory, TAssociation>
        where TCategory : CategoryEntity
        where TAssociation : SaasBaseEntity
    {

    }
}

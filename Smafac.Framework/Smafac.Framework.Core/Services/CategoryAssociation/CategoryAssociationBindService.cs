using Smafac.Framework.Core.Applications.CategoryAssociation;
using Smafac.Framework.Core.Domain;
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
    }
}

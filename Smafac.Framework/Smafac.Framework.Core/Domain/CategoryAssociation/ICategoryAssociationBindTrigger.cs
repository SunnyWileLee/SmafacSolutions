using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.CategoryAssociation
{
    public interface ICategoryAssociationBindTrigger<TCategory, TAssociation>
        where TCategory : CategoryEntity
        where TAssociation : SaasBaseEntity
    {
        bool Bound(TCategory category, TAssociation association);
    }
}

using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Repositories.CategoryAssociation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.CategoryProperty
{
    public interface ICategoryPropertySearchRepository<TCategory, TProperty> : ICategoryAssociationSearchRepository<TCategory, TProperty>
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
    {

    }
}

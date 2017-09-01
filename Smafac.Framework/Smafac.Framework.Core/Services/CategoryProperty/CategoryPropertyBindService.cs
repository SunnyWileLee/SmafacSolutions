using Smafac.Framework.Core.Applications.CategoryProperty;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryAssociation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services.CategoryProperty
{
    public abstract class CategoryPropertyBindService<TCategory, TProperty> :
        CategoryAssociationBindService<TCategory, TProperty>,
        ICategoryPropertyBindService
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
    {

    }
}

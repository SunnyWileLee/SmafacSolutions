using Smafac.Framework.Core.Applications.CategoryProperty;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Framework.Core.Services.CategoryAssociation;

namespace Smafac.Framework.Core.Services.CategoryProperty
{
    public abstract class CategoryPropertySearchService<TCategory, TProperty, TPropertyModel> :
        CategoryAssociationSearchService<TCategory, TProperty, TPropertyModel>,
        ICategoryPropertySearchService<TPropertyModel>
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
        where TPropertyModel : PropertyModel
    {

    }
}

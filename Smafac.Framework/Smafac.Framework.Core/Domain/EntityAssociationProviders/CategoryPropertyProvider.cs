using AutoMapper;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Repositories.Category;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.CategoryProperty;

namespace Smafac.Framework.Core.Domain.EntityAssociationProviders
{
    public abstract class CategoryPropertyProvider<TCategory, TProperty, TPropertyModel> :
        CategoryAssociationProvider<TCategory, TProperty, TPropertyModel>
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
        where TPropertyModel : PropertyModel
    {

    }
}

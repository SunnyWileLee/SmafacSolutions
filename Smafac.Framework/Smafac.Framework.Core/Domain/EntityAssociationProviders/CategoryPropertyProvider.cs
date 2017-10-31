using Smafac.Framework.Core.Models;

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

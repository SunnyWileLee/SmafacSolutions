using Smafac.Framework.Core.Applications.Property;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Services.CustomizedColumn;

namespace Smafac.Framework.Core.Services.Property
{
    public abstract class PropertyDeleteService<TProperty, TPropertyModel> : CustomizedColumnDeleteService<TProperty, TPropertyModel>,
        IPropertyDeleteService<TPropertyModel>
        where TProperty : PropertyEntity
        where TPropertyModel : PropertyModel
    {

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications
{
    public interface IPropertyService<TPropertyModel> where TPropertyModel : PropertyModel
    {
        bool AddProperty(TPropertyModel model);
        bool UpdateProperty(TPropertyModel model);
        bool DeleteProperty(Guid propertyId);
        List<TPropertyModel> GetProperties();
        List<TPropertyModel> GetProperties(Guid entityId);
    }
}

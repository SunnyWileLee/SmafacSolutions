using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.PropertyValue
{
    public interface IPropertyValueSearchRepository<TPropertyValueModel> where TPropertyValueModel : PropertyValueModel
    {
        List<TPropertyValueModel> GetPropertyValues(Guid subscriberId, Guid entityId);
        IEnumerable<IGrouping<Guid, TPropertyValueModel>> GetPropertyValues(Guid subscriberId, IEnumerable<Guid> entityIds);
        bool Any(Guid subscriberId, Guid propertyId);
    }
}

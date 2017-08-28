using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public interface IPropertyRepository<TProperty> where TProperty : PropertyEntity
    {
        bool AddProperty(TProperty property);
        List<TProperty> GetProperties(Guid subscriberId);
        bool UpdateProperty(TProperty property);
        bool DeleteProperty(Guid subscriberId, Guid propertyId);
        bool Any(Guid subscriberId, string name);
    }
}

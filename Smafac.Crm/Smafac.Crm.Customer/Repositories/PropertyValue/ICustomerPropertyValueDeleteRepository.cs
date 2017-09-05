using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories.PropertyValue
{
    interface ICustomerPropertyValueDeleteRepository : IPropertyValueDeleteRepository<CustomerPropertyValueEntity>
    {
    }
}

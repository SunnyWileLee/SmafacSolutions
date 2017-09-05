using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Repositories.CustomizedColumn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Property
{
    public interface IPropertyUpdateRepository<TProperty> : ICustomizedColumnUpdateRepository<TProperty>
        where TProperty : PropertyEntity
    {
    }
}

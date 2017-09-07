using Smafac.Framework.Core.Domain.CustomizedColumn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Property
{
    public interface IPropertyAddTrigger<TProperty> : ICustomizedColumnAddTrigger<TProperty>
        where TProperty : PropertyEntity
    {

    }
}

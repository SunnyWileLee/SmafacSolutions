using Smafac.Framework.Core.Applications.CustomizedColumn;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.Property
{
    public interface IPropertyUpdateService<TPropertyModel>: ICustomizedColumnUpdateService<TPropertyModel>
        where TPropertyModel : PropertyModel
    {
        
    }
}

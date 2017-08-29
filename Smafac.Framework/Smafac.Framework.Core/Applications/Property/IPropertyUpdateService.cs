using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.Property
{
    public interface IPropertyUpdateService<TPropertyModel> where TPropertyModel : PropertyModel
    {
        bool UpdateProperty(TPropertyModel model);
    }
}

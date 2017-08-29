using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public interface ICategoryPropertyProvider<TProperty, TPropertyModel>
        where TProperty : PropertyEntity
        where TPropertyModel : PropertyModel
    {
        List<TPropertyModel> ProvideProperties(Guid categoryId);
    }
}

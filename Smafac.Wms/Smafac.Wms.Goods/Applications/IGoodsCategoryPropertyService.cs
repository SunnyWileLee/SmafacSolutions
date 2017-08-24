using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Applications
{
    public interface IGoodsCategoryPropertyService
    {
        List<PropertyModel> GetPropertiesIncludeParents(Guid categoryId);
        List<PropertyModel> GetProperties(Guid categoryId);
        bool BindProperties(Guid categoryId, IEnumerable<Guid> propertyIds);
    }
}

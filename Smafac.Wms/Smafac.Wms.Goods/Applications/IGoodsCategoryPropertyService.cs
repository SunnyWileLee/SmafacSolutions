using Smafac.Framework.Models;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Applications
{
    public interface IGoodsCategoryPropertyService
    {
        List<GoodsPropertyModel> GetPropertiesIncludeParents(Guid categoryId);
        List<GoodsPropertyModel> GetProperties(Guid categoryId);
        bool BindProperties(Guid categoryId, IEnumerable<Guid> propertyIds);
    }
}

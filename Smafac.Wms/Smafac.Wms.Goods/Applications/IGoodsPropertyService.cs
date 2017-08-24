using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Applications
{
    public interface IGoodsPropertyService
    {
        bool AddProperty(GoodsPropertyModel model);
        bool UpdateProperty(GoodsPropertyModel model);
        bool DeleteProperty(Guid propertyId);
        List<GoodsPropertyModel> GetProperties();
        List<GoodsPropertyModel> GetProperties(Guid goodsId);
    }
}

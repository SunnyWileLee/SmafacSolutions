using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    interface IGoodsPropertyRepository
    {
        bool AddProperty(GoodsPropertyEntity property);
        List<GoodsPropertyEntity> GetProperties(Guid subscriberId);
        bool UpdateProperty(GoodsPropertyModel model);
        bool DeleteProperty(Guid subscriberId, Guid propertyId);
        bool Any(Guid subscriberId, string name);
        bool IsUsed(Guid subscriberId, Guid propertyId);
    }
}

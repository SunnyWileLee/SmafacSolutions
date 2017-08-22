using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    interface IGoodsPropertyValueRepository
    {
        bool SetPropertyValue(GoodsPropertyValueEntity value);
        List<GoodsPropertyValueModel> GetPropertyValues(Guid SubscriberId, Guid goodsId);
        IEnumerable<IGrouping<Guid, GoodsPropertyValueModel>> GetPropertyValues(Guid SubscriberId, IEnumerable<Guid> goodsIds);
        bool Any(Guid SubscriberId, Guid propertyId);
    }
}

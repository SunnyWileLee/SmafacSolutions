using Smafac.Framework.Core.Services.Property;
using Smafac.Wms.Goods.Applications.Property;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Services.Property
{
    class GoodsPropertyDeleteService : PropertyDeleteService<GoodsPropertyEntity, GoodsPropertyModel>, IGoodsPropertyDeleteService
    {
        public GoodsPropertyDeleteService(IGoodsPropertyDeleteRepository goodsPropertyDeleteRepository)
        {
            base.PropertyDeleteRepository = goodsPropertyDeleteRepository;
        }

        protected override bool IsUsed(Guid propertyId)
        {
            return false;
        }
    }
}

using Smafac.Wms.Goods.Applications.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Wms.Goods.Models;
using Smafac.Framework.Core.Services.Property;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Repositories.Property;

namespace Smafac.Wms.Goods.Services.Property
{
    class GoodsPropertyAddService : PropertyAddService<GoodsPropertyEntity, GoodsPropertyModel>, IGoodsPropertyAddService
    {
        public GoodsPropertyAddService(IGoodsPropertyAddRepository goodsPropertyAddRepository,
                                        IGoodsPropertySearchRepository goodsPropertySearchRepository)
        {
            base.CustomizedColumnAddRepository = goodsPropertyAddRepository;
            base.CustomizedColumnSearchRepository = goodsPropertySearchRepository;
        }
    }
}

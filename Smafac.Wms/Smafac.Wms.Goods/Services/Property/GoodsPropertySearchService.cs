using Smafac.Framework.Core.Services.Property;
using Smafac.Wms.Goods.Applications.Property;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Domain.Property;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Services.Property
{
    class GoodsPropertySearchService : PropertySearchService<GoodsPropertyEntity, GoodsPropertyModel>, IGoodsPropertySearchService
    {
        private readonly IGoodsPropertyProvider _goodsPropertyProvider;

        public GoodsPropertySearchService(IGoodsPropertySearchRepository goodsSearchRepository,
            IGoodsPropertyProvider goodsPropertyProvider)
        {
            base.CustomizedColumnSearchRepository = goodsSearchRepository;
            _goodsPropertyProvider = goodsPropertyProvider;
        }

        public override List<GoodsPropertyModel> GetColumns(Guid entityId)
        {
            return _goodsPropertyProvider.Provide(entityId);
        }
    }
}

using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Wms.Goods.Applications.CategoryProperty;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Domain.CategoryProperty;
using Smafac.Wms.Goods.Repositories.Category;
using Smafac.Wms.Goods.Repositories.CategoryProperty;
using Smafac.Wms.Goods.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Services.CategoryProperty
{
    class GoodsCategoryPropertyBindService : CategoryPropertyBindService<GoodsCategoryEntity, GoodsPropertyEntity>,
                                        IGoodsCategoryPropertyBindService
    {
        public GoodsCategoryPropertyBindService(IGoodsCategoryPropertyBindRepository goodsCategoryPropertyBindRepository,
                                                IGoodsCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
                                                IEnumerable<IGoodsCategoryPropertyBindTrigger> goodsCategoryPropertyBindTriggers,
                                                IGoodsCategorySearchRepository goodsCategorySearchRepository,
                                                IGoodsPropertySearchRepository goodsPropertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = goodsCategoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = goodsCategoryPropertySearchRepository;
            base.CategoryAssociationBindTriggers = goodsCategoryPropertyBindTriggers;
            base.CategorySearchRepository = goodsCategorySearchRepository;
            base.AssociationSearchRepository = goodsPropertySearchRepository;
        }
    }
}

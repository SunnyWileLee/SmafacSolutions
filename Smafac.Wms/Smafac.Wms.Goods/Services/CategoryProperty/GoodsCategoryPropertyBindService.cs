using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Wms.Goods.Applications.CategoryProperty;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Repositories.CategoryProperty;
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
                                                IGoodsCategoryPropertySearchRepository goodsCategoryPropertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = goodsCategoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = goodsCategoryPropertySearchRepository;
        }

    }
}

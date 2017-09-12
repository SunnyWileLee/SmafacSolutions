using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Wms.Goods.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories.CategoryProperty
{
    class GoodsCategoryPropertySearchRepository : CategoryPropertySearchRepository<GoodsContext, GoodsCategoryEntity, GoodsPropertyEntity, GoodsCategoryPropertyEntity>,
                                                  IGoodsCategoryPropertySearchRepository
    {
        public GoodsCategoryPropertySearchRepository(IGoodsContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Models;
using Smafac.Wms.Goods.Repositories;
using Smafac.Framework.Core.Models;
using AutoMapper;
using Smafac.Wms.Goods.Models;
using Smafac.Framework.Core.Domain;
using Smafac.Wms.Goods.Repositories.Category;
using Smafac.Wms.Goods.Repositories.CategoryProperty;

namespace Smafac.Wms.Goods.Domain
{
    class GoodsCategoryPropertyProvider : CategoryPropertyProvider<GoodsCategoryEntity, GoodsPropertyEntity, GoodsPropertyModel>,
                                            IGoodsCategoryPropertyProvider
    {

        public GoodsCategoryPropertyProvider(IGoodsCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
                                            IGoodsCategorySearchRepository goodsCategorySearchRepository)
        {
            base.CategorySearchRepository = goodsCategorySearchRepository;
            base.CategoryPropertySearchRepository = goodsCategoryPropertySearchRepository;
        }
    }
}

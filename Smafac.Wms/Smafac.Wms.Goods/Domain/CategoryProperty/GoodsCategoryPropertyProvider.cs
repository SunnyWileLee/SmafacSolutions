﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Models;
using Smafac.Wms.Goods.Repositories;
using Smafac.Framework.Core.Models;
using AutoMapper;
using Smafac.Wms.Goods.Models;
using Smafac.Framework.Core.Domain;
using Smafac.Wms.Goods.Repositories.Category;
using Smafac.Wms.Goods.Repositories.CategoryProperty;
using Smafac.Framework.Core.Domain.EntityAssociationProviders;

namespace Smafac.Wms.Goods.Domain.CategoryProperty
{
    class GoodsCategoryPropertyProvider : CategoryPropertyProvider<GoodsCategoryEntity, GoodsPropertyEntity, GoodsPropertyModel>,
                                            IGoodsCategoryPropertyProvider
    {

        public GoodsCategoryPropertyProvider(IGoodsCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
                                            IGoodsCategorySearchRepository goodsCategorySearchRepository)
        {
            base.CategorySearchRepository = goodsCategorySearchRepository;
            base.CategoryAssociationSearchRepository = goodsCategoryPropertySearchRepository;
        }
    }
}

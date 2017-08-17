﻿using Smafac.Wms.Goods.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    interface IGoodsCategoryRepository
    {
        bool AddCategory(GoodsCategoryEntity entity);
        bool UpdateCategory(GoodsCategoryEntity entity);
        bool DeleteCategory(Guid subscriberId, Guid categoryId);
        List<GoodsCategoryEntity> GetCategories(Guid subscriberId, Guid parentId);
    }
}

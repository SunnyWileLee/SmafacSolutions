using Smafac.Framework.Core.Services.Category;
using Smafac.Wms.Goods.Applications.Category;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Services.Category
{
    class GoodsCategoryDeleteService : CategoryDeleteService<GoodsCategoryEntity, GoodsCategoryModel>, IGoodsCategoryDeleteService
    {
        public GoodsCategoryDeleteService(IGoodsCategoryDeleteRepository goodsCategoryDeleteRepository)
        {
            base.CategoryDeleteRepository = goodsCategoryDeleteRepository;
        }

        protected override bool IsUsed(Guid CategoryId)
        {
            return false;
        }
    }
}

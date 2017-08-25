using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Applications
{
    public interface IGoodsCategroySearchService
    {
        GoodsCategoryModel GetCategory(Guid id);
        GoodsCategoryModel GetCategoryWithChildren(Guid id);
        List<GoodsCategoryModel> GetCategories(Guid parentId);
        List<GoodsCategoryModel> GetLeafCategories();
    }
}

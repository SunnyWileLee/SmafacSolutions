using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Applications
{
    public interface IGoodsCategoryService
    {
        bool AddCategory(GoodsCategoryModel model);
        bool UpdateCategory(GoodsCategoryModel model);
        bool DeleteCategory(Guid categoryId);
        List<GoodsCategoryModel> GetCategories(Guid parentId);
    }
}

using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.Category
{
    public interface ICategorySearchService<TCategoryModel> where TCategoryModel : CategoryModel
    {
        TCategoryModel GetCategory(Guid id);
        CategoryModelSet<TCategoryModel> GetCategoryWithChildren(Guid id);
        List<TCategoryModel> GetCategories();
        List<TCategoryModel> GetCategories(Guid parentId);
        List<TCategoryModel> GetLeafCategories();
    }
}

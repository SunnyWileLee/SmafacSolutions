using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.Category
{
    public interface ICategoryService<TCategoryModel>
        where TCategoryModel : CategoryModel
    {
        ICategoryAddService<TCategoryModel> AddService { get; }
        ICategoryDeleteService<TCategoryModel> DeleteService { get; }
        ICategoryUpdateService<TCategoryModel> UpdateService { get; }
        ICategorySearchService<TCategoryModel> SearchService { get; }
    }
}

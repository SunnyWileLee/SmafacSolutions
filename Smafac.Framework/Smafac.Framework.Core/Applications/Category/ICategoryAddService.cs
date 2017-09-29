using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.Category
{
    public interface ICategoryAddService<TCategoryModel> where TCategoryModel : CategoryModel
    {
        bool AddCategory(TCategoryModel model);
    }
}

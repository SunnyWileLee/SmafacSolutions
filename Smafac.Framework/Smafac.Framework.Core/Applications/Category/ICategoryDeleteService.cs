using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.Category
{
    public interface ICategoryDeleteService<TCategoryModel> where TCategoryModel : CategoryModel
    {
        bool DeleteCategory(Guid CategoryId);
    }
}

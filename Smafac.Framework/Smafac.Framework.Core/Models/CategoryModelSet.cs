using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Models
{
    public class CategoryModelSet<TCategoryModel> where TCategoryModel : CategoryModel
    {
        public CategoryModelSet()
        {
            Category = default(TCategoryModel);
            Children = new List<TCategoryModel>();
        }

        public CategoryModelSet(TCategoryModel category, List<TCategoryModel> children)
        {
            Category = category;
            Children = children;
        }

        public TCategoryModel Category { get; set; }
        public List<TCategoryModel> Children { get; set; }
    }
}

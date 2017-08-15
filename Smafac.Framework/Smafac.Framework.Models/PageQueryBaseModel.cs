using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class PageQueryBaseModel : QueryBaseModel
    {
        public const int DefaultPageSize = 20;
        public PageQueryBaseModel()
        {
            PageSize = DefaultPageSize;
        }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public int Skip
        {
            get
            {
                return PageSize * PageIndex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public abstract class PageQueryBaseModel : QueryBaseModel
    {
        public const int DefaultPageSize = 20;
        public PageQueryBaseModel()
        {
            PageSize = DefaultPageSize;
        }
        public virtual int PageSize { get; set; }
        public virtual int PageIndex { get; set; }

        public virtual int Skip
        {
            get
            {
                return PageSize * PageIndex;
            }
        }
    }
}

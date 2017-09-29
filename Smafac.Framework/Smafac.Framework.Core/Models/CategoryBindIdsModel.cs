using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Models
{
    public class CategoryBindIdsModel
    {
        public Guid CategoryId { get; set; }
        public List<Guid> BindIds { get; set; }
    }
}

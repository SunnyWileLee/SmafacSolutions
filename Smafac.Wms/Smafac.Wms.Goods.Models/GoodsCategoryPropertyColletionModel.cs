using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Models
{
    public class GoodsCategoryPropertyColletionModel : SaasBaseModel
    {
        public Guid CategoryId { get; set; }
        public List<Guid> PropertyIds { get; set; }
    }
}

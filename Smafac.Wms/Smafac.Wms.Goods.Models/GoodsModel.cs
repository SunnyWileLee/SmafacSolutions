using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Models
{
    public class GoodsModel : SaasBaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

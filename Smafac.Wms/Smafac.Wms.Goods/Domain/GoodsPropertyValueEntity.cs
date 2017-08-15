using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Domain
{
    class GoodsPropertyValueEntity : SaasBaseEntity
    {
        public Guid GoodsId { get; set; }
        public Guid PropertyId { get; set; }
        public string Value { get; set; }
    }
}

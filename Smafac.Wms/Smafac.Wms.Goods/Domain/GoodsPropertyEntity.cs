using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Domain
{
    class GoodsPropertyEntity : SaasBaseEntity
    {
        [MaxLength(50)]
        public string Title { get; set; }
    }
}

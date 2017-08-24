using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Domain
{
    [Table("GoodsCategoryProperty")]
    class GoodsCategoryPropertyEntity : SaasBaseEntity
    {
        public Guid CategoryId { get; set; }
        public Guid PropertyId { get; set; }
    }
}

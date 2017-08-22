using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Domain
{
    [Table("GoodsCategory")]
    class GoodsCategoryEntity : TreeNodeEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}

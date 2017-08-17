using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Domain
{
    class GoodsCategoryEntity : RecursionEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}

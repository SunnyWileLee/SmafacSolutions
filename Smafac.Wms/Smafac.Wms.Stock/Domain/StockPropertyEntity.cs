using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Domain
{
    [Table("StockProperty")]
    class StockPropertyEntity : PropertyEntity
    {
        public StockPropertyValueEntity CreateEmptyValue()
        {
            return this.CreateValue(Guid.Empty, string.Empty);
        }

        public StockPropertyValueEntity CreateValue(Guid goodsId, string value)
        {
            var propertyValue = base.CreateValueBase<StockPropertyValueEntity>(value);
            propertyValue.StockId = goodsId;
            return propertyValue;
        }
    }
}

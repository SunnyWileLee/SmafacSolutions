using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Models
{
    public class StockDetailModel : SaasBaseModel
    {
        public StockModel Stock { get; set; }
    }
}

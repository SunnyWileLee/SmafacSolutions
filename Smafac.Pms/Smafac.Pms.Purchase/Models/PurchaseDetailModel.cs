using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Models
{
    public class PurchaseDetailModel : SaasBaseModel
    {
        public PurchaseModel Purchase { get; set; }
    }
}

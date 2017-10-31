using Smafac.Framework.Core.Models;
using Smafac.Pms.Purchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Domain.Property
{
    interface IPurchasePropertyProvider
    {
        List<PurchasePropertyModel> Provide(Guid goodsId);
    }
}

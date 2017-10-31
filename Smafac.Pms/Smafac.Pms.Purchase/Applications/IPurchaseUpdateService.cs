using Smafac.Pms.Purchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Applications
{
    public interface IPurchaseUpdateService
    {
        bool UpdatePurchase(PurchaseModel model);
    }
}

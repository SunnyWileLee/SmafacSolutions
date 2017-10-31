using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Repositories
{
    class PurchaseContextProvider : IPurchaseContextProvider
    {
        public PurchaseContext Provide()
        {
            return new PurchaseContext();
        }

        public PurchaseContext ProvideSlave()
        {
            return new PurchaseContext();
        }
    }
}

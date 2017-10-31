using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Repositories
{
    interface IPurchaseContextProvider : IDbContextProvider<PurchaseContext>
    {

    }
}

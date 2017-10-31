using Smafac.Pms.Purchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Presentation.Domain.Purchase
{
    public interface IPurchaseWrapper
    {
        void Wrapper(List<PurchaseModel> purchases);
    }
}

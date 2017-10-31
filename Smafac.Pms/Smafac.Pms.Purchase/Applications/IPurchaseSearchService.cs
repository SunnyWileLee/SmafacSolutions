using Smafac.Framework.Core.Models;
using Smafac.Pms.Purchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Applications
{
    public interface IPurchaseSearchService
    {
        PurchaseModel GetPurchase(Guid goodsId);
        PurchaseDetailModel GetPurchaseDetail(Guid goodsId);
        List<PurchaseModel> GetPurchase(string key);
        PageModel<PurchaseModel> GetPurchasePage(PurchasePageQueryModel query);
        List<PurchaseModel> GetPurchase(PurchasePageQueryModel query);
        List<PurchaseModel> GetPurchase(IEnumerable<Guid> goodsIds);
    }
}

using Smafac.Framework.Core.Domain.Pages;
using Smafac.Pms.Purchase.Models;

namespace Smafac.Pms.Purchase.Domain.Pages
{
    interface IPurchasePageQueryer : IPageQueryer<PurchaseModel, PurchasePageQueryModel>
    {
    }
}

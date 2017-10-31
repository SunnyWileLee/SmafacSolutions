using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Pms.Purchase.Domain;

namespace Smafac.Pms.Purchase.Repositories.PropertyValue
{
    class PurchasePropertyValueDeleteRepository : PropertyValueDeleteRepository<PurchaseContext, PurchasePropertyValueEntity>,
                                                IPurchasePropertyValueDeleteRepository
    {

        public PurchasePropertyValueDeleteRepository(IPurchaseContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}

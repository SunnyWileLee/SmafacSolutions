using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Wms.Goods.Domain;

namespace Smafac.Wms.Goods.Repositories.PropertyValue
{
    class GoodsPropertyValueDeleteRepository : PropertyValueDeleteRepository<GoodsContext, GoodsPropertyValueEntity>,
                                                IGoodsPropertyValueDeleteRepository
    {

        public GoodsPropertyValueDeleteRepository(IGoodsContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}

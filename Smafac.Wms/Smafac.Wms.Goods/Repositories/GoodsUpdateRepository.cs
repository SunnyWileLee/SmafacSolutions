using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Wms.Goods.Models;
using Smafac.Framework.Core.Repositories;
using Smafac.Wms.Goods.Domain;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsUpdateRepository : EntityUpdateRepository<GoodsContext, GoodsEntity>,
                                    IGoodsUpdateRepository
    {
        public GoodsUpdateRepository(IGoodsContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override void SetValue(GoodsEntity entity, GoodsEntity source)
        {
            entity.Name = source.Name;
            entity.Price = source.Price;
        }
    }
}

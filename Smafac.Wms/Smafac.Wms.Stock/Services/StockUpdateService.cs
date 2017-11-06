using Smafac.Wms.Stock.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories;
using AutoMapper;
using Smafac.Wms.Stock.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Wms.Stock.Repositories.PropertyValue;

namespace Smafac.Wms.Stock.Services
{
    class StockUpdateService : IStockUpdateService
    {
        private readonly IStockUpdateRepository _goodsUpdateRepository;
        private readonly IStockPropertyValueSetRepository _goodsPropertyValueSetRepository;

        public StockUpdateService(IStockUpdateRepository goodsUpdateRepository,
                                    IStockPropertyValueSetRepository goodsPropertyValueSetRepository)
        {
            _goodsUpdateRepository = goodsUpdateRepository;
            _goodsPropertyValueSetRepository = goodsPropertyValueSetRepository;
        }

        public bool UpdateStock(StockModel model)
        {
            var goods = Mapper.Map<StockEntity>(model);
            goods.SubscriberId = UserContext.Current.SubscriberId;
            var update = _goodsUpdateRepository.UpdateEntity(goods);

            if (update && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.StockId = goods.Id;
                    property.SubscriberId = goods.SubscriberId;
                    var value = Mapper.Map<StockPropertyValueEntity>(property);
                    update &= _goodsPropertyValueSetRepository.SetPropertyValue(value);
                });
            }
            return update;
        }
    }
}

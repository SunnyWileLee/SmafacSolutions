using Smafac.Wms.Stock.Applications;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Wms.Stock.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Wms.Stock.Repositories.PropertyValue;

namespace Smafac.Wms.Stock.Services
{
    class StockService : IStockService
    {
        private readonly IStockAddRepository _goodsRepository;
        private readonly IStockPropertyValueSetRepository _goodsPropertyValueSetRepository;

        public StockService(IStockAddRepository goodsRepository,
                            IStockUpdateService updateService,
                            IStockPropertyValueSetRepository goodsPropertyValueSetRepository
                            )
        {
            _goodsRepository = goodsRepository;
            _goodsPropertyValueSetRepository = goodsPropertyValueSetRepository;
            UpdateService = updateService;
        }

        public IStockUpdateService UpdateService { get; set; }

        public bool AddStock(StockModel model)
        {
            var goods = Mapper.Map<StockEntity>(model);
            goods.SubscriberId = UserContext.Current.SubscriberId;
            var add = _goodsRepository.AddEntity(goods);

            if (add && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.StockId = goods.Id;
                    property.SubscriberId = goods.SubscriberId;
                });
                var values = Mapper.Map<List<StockPropertyValueEntity>>(model.Properties);
                return _goodsPropertyValueSetRepository.AddPropertyValues(goods.Id, values);
            }
            return add;
        }

        public StockModel CreateEmptyStock()
        {
            return new StockModel();
        }
    }
}

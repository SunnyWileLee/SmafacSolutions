using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Models;
using Smafac.Framework.Core.Models;
using AutoMapper;
using Smafac.Framework.Core.Domain;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories;

namespace Smafac.Sales.Order.Domain.Property
{
    class OrderCategoryPropertyProvider : CategoryPropertyProvider<OrderPropertyEntity>, IOrderCategoryPropertyProvider
    {
        //private readonly IOrderCategoryPropertyRepository _OrderCategoryPropertyRepository;
        //private readonly IOrderCategoryRepository _OrderCategoryRepository;

        //public OrderCategoryPropertyProvider(IOrderCategoryPropertyRepository OrderCategoryPropertyRepository,
        //                                    IOrderCategoryRepository OrderCategoryRepository)
        //{
        //    _OrderCategoryPropertyRepository = OrderCategoryPropertyRepository;
        //    _OrderCategoryRepository = OrderCategoryRepository;
        //}

        //public List<OrderPropertyModel> Provide(Guid categoryId)
        //{
        //    var properties = base.ProvideProperties(categoryId);
        //    return Mapper.Map<List<OrderPropertyModel>>(properties);
        //}

        //protected override CategoryEntity GetCategory(Guid categoryId)
        //{
        //    return _OrderCategoryRepository.GetCategory(UserContext.Current.SubscriberId, categoryId);
        //}

        //protected override IEnumerable<OrderPropertyEntity> GetProperties(Guid categoryId)
        //{
        //    return _OrderCategoryPropertyRepository.GetProperties(UserContext.Current.SubscriberId, categoryId) ?? new List<OrderPropertyEntity>();
        //}
        public List<OrderPropertyModel> Provide(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        protected override CategoryEntity GetCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<OrderPropertyEntity> GetProperties(Guid categoryId)
        {
            throw new NotImplementedException();
        }
    }
}

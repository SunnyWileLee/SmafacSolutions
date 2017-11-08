using Smafac.Framework.Core.Models;
using Smafac.Hrs.Employee.Domain.CategoryProperty;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories;
using System;
using System.Collections.Generic;

namespace Smafac.Hrs.Employee.Domain.Property
{
    class EmployeePropertyProvider : IEmployeePropertyProvider
    {
        private readonly IEmployeeSearchRepository _goodsSearchRepository;
        private readonly IEmployeeCategoryPropertyProvider _goodsCategoryPropertyProvider;

        public EmployeePropertyProvider(IEmployeeSearchRepository goodsSearchRepository,
                                    IEmployeeCategoryPropertyProvider goodsCategoryPropertyProvider
                                    )
        {
            _goodsSearchRepository = goodsSearchRepository;
            _goodsCategoryPropertyProvider = goodsCategoryPropertyProvider;
        }

        public List<EmployeePropertyModel> Provide(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _goodsSearchRepository.GetEmployee(subscriberId, goodsId);
            return _goodsCategoryPropertyProvider.ProvideAssociations(goods.CategoryId);
        }
    }
}

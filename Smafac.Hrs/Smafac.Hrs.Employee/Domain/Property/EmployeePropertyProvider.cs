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
        private readonly IEmployeeSearchRepository _searchRepository;
        private readonly IEmployeeCategoryPropertyProvider _categoryPropertyProvider;

        public EmployeePropertyProvider(IEmployeeSearchRepository searchRepository,
                                    IEmployeeCategoryPropertyProvider categoryPropertyProvider
                                    )
        {
            _searchRepository = searchRepository;
            _categoryPropertyProvider = categoryPropertyProvider;
        }

        public List<EmployeePropertyModel> Provide(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _searchRepository.GetEmployee(subscriberId, goodsId);
            return _categoryPropertyProvider.ProvideAssociations(goods.CategoryId);
        }
    }
}

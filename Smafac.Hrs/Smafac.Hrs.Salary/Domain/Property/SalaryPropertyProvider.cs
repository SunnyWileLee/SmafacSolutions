using Smafac.Framework.Core.Models;
using Smafac.Hrs.Salary.Domain.CategoryProperty;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories;
using System;
using System.Collections.Generic;

namespace Smafac.Hrs.Salary.Domain.Property
{
    class SalaryPropertyProvider : ISalaryPropertyProvider
    {
        private readonly ISalarySearchRepository _goodsSearchRepository;
        private readonly ISalaryCategoryPropertyProvider _goodsCategoryPropertyProvider;

        public SalaryPropertyProvider(ISalarySearchRepository goodsSearchRepository,
                                    ISalaryCategoryPropertyProvider goodsCategoryPropertyProvider
                                    )
        {
            _goodsSearchRepository = goodsSearchRepository;
            _goodsCategoryPropertyProvider = goodsCategoryPropertyProvider;
        }

        public List<SalaryPropertyModel> Provide(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _goodsSearchRepository.GetSalary(subscriberId, goodsId);
            return _goodsCategoryPropertyProvider.ProvideAssociations(goods.CategoryId);
        }
    }
}

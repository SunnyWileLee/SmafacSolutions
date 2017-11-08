using Smafac.Framework.Core.Models;
using Smafac.Hrs.Salary.Applications;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Domain.Pages;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories;
using Smafac.Hrs.Salary.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Hrs.Salary.Services
{
    class SalarySearchService : ISalarySearchService
    {
        private readonly ISalarySearchRepository _goodsSearchRepository;
        private readonly ISalaryPropertyValueSearchRepository _goodsPropertyValueSearchRepository;
        private readonly ISalaryPageQueryer _goodsPageQueryer;

        public SalarySearchService(ISalarySearchRepository goodsSearchRepository,
                                    ISalaryPropertyValueSearchRepository goodsPropertyValueSearchRepository,
                                    ISalaryPageQueryer goodsPageQueryer
                                    )
        {
            _goodsSearchRepository = goodsSearchRepository;
            _goodsPropertyValueSearchRepository = goodsPropertyValueSearchRepository;
            _goodsPageQueryer = goodsPageQueryer;
        }

        public List<SalaryModel> GetSalary(IEnumerable<Guid> goodsIds)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            Expression<Func<SalaryEntity, bool>> predicate = s => goodsIds.Contains(s.Id);
            return _goodsSearchRepository.GetSalary(subscriberId, predicate);
        }

        public SalaryModel GetSalary(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _goodsSearchRepository.GetSalary(subscriberId, goodsId);
            var properties = _goodsPropertyValueSearchRepository.GetPropertyValues(subscriberId, goodsId);
            goods.Properties = properties;
            return goods;
        }

        public List<SalaryModel> GetSalary(SalaryPageQueryModel query)
        {
            return _goodsPageQueryer.Query(query);
        }

        public SalaryDetailModel GetSalaryDetail(Guid goodsId)
        {
            var goods = this.GetSalary(goodsId);
            return new SalaryDetailModel { Salary = goods };
        }


        public PageModel<SalaryModel> GetSalaryPage(SalaryPageQueryModel query)
        {
            return _goodsPageQueryer.QueryPage(query);
        }
    }
}

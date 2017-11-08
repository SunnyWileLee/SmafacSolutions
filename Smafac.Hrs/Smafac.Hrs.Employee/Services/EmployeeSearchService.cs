﻿using Smafac.Framework.Core.Models;
using Smafac.Hrs.Employee.Applications;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Domain.Pages;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories;
using Smafac.Hrs.Employee.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Hrs.Employee.Services
{
    class EmployeeSearchService : IEmployeeSearchService
    {
        private readonly IEmployeeSearchRepository _goodsSearchRepository;
        private readonly IEmployeePropertyValueSearchRepository _goodsPropertyValueSearchRepository;
        private readonly IEmployeePageQueryer _goodsPageQueryer;

        public EmployeeSearchService(IEmployeeSearchRepository goodsSearchRepository,
                                    IEmployeePropertyValueSearchRepository goodsPropertyValueSearchRepository,
                                    IEmployeePageQueryer goodsPageQueryer
                                    )
        {
            _goodsSearchRepository = goodsSearchRepository;
            _goodsPropertyValueSearchRepository = goodsPropertyValueSearchRepository;
            _goodsPageQueryer = goodsPageQueryer;
        }

        public List<EmployeeModel> GetEmployee(IEnumerable<Guid> goodsIds)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            Expression<Func<EmployeeEntity, bool>> predicate = s => goodsIds.Contains(s.Id);
            return _goodsSearchRepository.GetEmployee(subscriberId, predicate);
        }

        public EmployeeModel GetEmployee(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _goodsSearchRepository.GetEmployee(subscriberId, goodsId);
            var properties = _goodsPropertyValueSearchRepository.GetPropertyValues(subscriberId, goodsId);
            goods.Properties = properties;
            return goods;
        }

        public List<EmployeeModel> GetEmployee(EmployeePageQueryModel query)
        {
            return _goodsPageQueryer.Query(query);
        }

        public EmployeeDetailModel GetEmployeeDetail(Guid goodsId)
        {
            var goods = this.GetEmployee(goodsId);
            return new EmployeeDetailModel { Employee = goods };
        }


        public PageModel<EmployeeModel> GetEmployeePage(EmployeePageQueryModel query)
        {
            return _goodsPageQueryer.QueryPage(query);
        }
    }
}

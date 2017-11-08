using Smafac.Hrs.Employee.Applications;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Hrs.Employee.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Hrs.Employee.Repositories.PropertyValue;

namespace Smafac.Hrs.Employee.Services
{
    class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeAddRepository _goodsRepository;
        private readonly IEmployeePropertyValueSetRepository _goodsPropertyValueSetRepository;

        public EmployeeService(IEmployeeAddRepository goodsRepository,
                            IEmployeeUpdateService updateService,
                            IEmployeePropertyValueSetRepository goodsPropertyValueSetRepository
                            )
        {
            _goodsRepository = goodsRepository;
            _goodsPropertyValueSetRepository = goodsPropertyValueSetRepository;
            UpdateService = updateService;
        }

        public IEmployeeUpdateService UpdateService { get; set; }

        public bool AddEmployee(EmployeeModel model)
        {
            var goods = Mapper.Map<EmployeeEntity>(model);
            goods.SubscriberId = UserContext.Current.SubscriberId;
            var add = _goodsRepository.AddEntity(goods);

            if (add && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.EmployeeId = goods.Id;
                    property.SubscriberId = goods.SubscriberId;
                });
                var values = Mapper.Map<List<EmployeePropertyValueEntity>>(model.Properties);
                return _goodsPropertyValueSetRepository.AddPropertyValues(goods.Id, values);
            }
            return add;
        }

        public EmployeeModel CreateEmptyEmployee()
        {
            return new EmployeeModel();
        }
    }
}

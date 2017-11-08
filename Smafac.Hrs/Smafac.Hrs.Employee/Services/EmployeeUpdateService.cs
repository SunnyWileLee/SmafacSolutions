using Smafac.Hrs.Employee.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories;
using AutoMapper;
using Smafac.Hrs.Employee.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Hrs.Employee.Repositories.PropertyValue;

namespace Smafac.Hrs.Employee.Services
{
    class EmployeeUpdateService : IEmployeeUpdateService
    {
        private readonly IEmployeeUpdateRepository _goodsUpdateRepository;
        private readonly IEmployeePropertyValueSetRepository _propertyValueSetRepository;

        public EmployeeUpdateService(IEmployeeUpdateRepository goodsUpdateRepository,
                                    IEmployeePropertyValueSetRepository propertyValueSetRepository)
        {
            _goodsUpdateRepository = goodsUpdateRepository;
            _propertyValueSetRepository = propertyValueSetRepository;
        }

        public bool UpdateEmployee(EmployeeModel model)
        {
            var goods = Mapper.Map<EmployeeEntity>(model);
            goods.SubscriberId = UserContext.Current.SubscriberId;
            var update = _goodsUpdateRepository.UpdateEntity(goods);

            if (update && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.EmployeeId = goods.Id;
                    property.SubscriberId = goods.SubscriberId;
                    var value = Mapper.Map<EmployeePropertyValueEntity>(property);
                    update &= _propertyValueSetRepository.SetPropertyValue(value);
                });
            }
            return update;
        }
    }
}

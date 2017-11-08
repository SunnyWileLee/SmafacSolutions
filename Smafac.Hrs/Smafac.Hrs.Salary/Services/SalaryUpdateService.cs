using Smafac.Hrs.Salary.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories;
using AutoMapper;
using Smafac.Hrs.Salary.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Hrs.Salary.Repositories.PropertyValue;

namespace Smafac.Hrs.Salary.Services
{
    class SalaryUpdateService : ISalaryUpdateService
    {
        private readonly ISalaryUpdateRepository _goodsUpdateRepository;
        private readonly ISalaryPropertyValueSetRepository _goodsPropertyValueSetRepository;

        public SalaryUpdateService(ISalaryUpdateRepository goodsUpdateRepository,
                                    ISalaryPropertyValueSetRepository goodsPropertyValueSetRepository)
        {
            _goodsUpdateRepository = goodsUpdateRepository;
            _goodsPropertyValueSetRepository = goodsPropertyValueSetRepository;
        }

        public bool UpdateSalary(SalaryModel model)
        {
            var goods = Mapper.Map<SalaryEntity>(model);
            goods.SubscriberId = UserContext.Current.SubscriberId;
            var update = _goodsUpdateRepository.UpdateEntity(goods);

            if (update && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.SalaryId = goods.Id;
                    property.SubscriberId = goods.SubscriberId;
                    var value = Mapper.Map<SalaryPropertyValueEntity>(property);
                    update &= _goodsPropertyValueSetRepository.SetPropertyValue(value);
                });
            }
            return update;
        }
    }
}

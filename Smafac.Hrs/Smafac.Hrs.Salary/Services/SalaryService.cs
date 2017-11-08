using Smafac.Hrs.Salary.Applications;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Hrs.Salary.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Hrs.Salary.Repositories.PropertyValue;

namespace Smafac.Hrs.Salary.Services
{
    class SalaryService : ISalaryService
    {
        private readonly ISalaryAddRepository _goodsRepository;
        private readonly ISalaryPropertyValueSetRepository _goodsPropertyValueSetRepository;

        public SalaryService(ISalaryAddRepository goodsRepository,
                            ISalaryUpdateService updateService,
                            ISalaryPropertyValueSetRepository goodsPropertyValueSetRepository
                            )
        {
            _goodsRepository = goodsRepository;
            _goodsPropertyValueSetRepository = goodsPropertyValueSetRepository;
            UpdateService = updateService;
        }

        public ISalaryUpdateService UpdateService { get; set; }

        public bool AddSalary(SalaryModel model)
        {
            var goods = Mapper.Map<SalaryEntity>(model);
            goods.SubscriberId = UserContext.Current.SubscriberId;
            var add = _goodsRepository.AddEntity(goods);

            if (add && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.SalaryId = goods.Id;
                    property.SubscriberId = goods.SubscriberId;
                });
                var values = Mapper.Map<List<SalaryPropertyValueEntity>>(model.Properties);
                return _goodsPropertyValueSetRepository.AddPropertyValues(goods.Id, values);
            }
            return add;
        }

        public SalaryModel CreateEmptySalary()
        {
            return new SalaryModel();
        }
    }
}

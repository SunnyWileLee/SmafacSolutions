using Smafac.Framework.Core.Services.Property;
using Smafac.Hrs.Salary.Applications.Property;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Domain.Property;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Services.Property
{
    class SalaryPropertyDeleteService : PropertyDeleteService<SalaryPropertyEntity, SalaryPropertyModel>, ISalaryPropertyDeleteService
    {
        public SalaryPropertyDeleteService(ISalaryPropertyDeleteRepository goodsPropertyDeleteRepository,
                                          ISalaryPropertySearchRepository goodsPropertySearchRepository,
                                          ISalaryPropertyUsedChecker[] goodsFinancePropertyUsedCheckers,
                                          ISalaryPropertyDeleteTrigger[] goodsPropertyDeleteTriggers)
        {
            base.CustomizedColumnDeleteRepository = goodsPropertyDeleteRepository;
            base.CustomizedColumnUsedCheckers = goodsFinancePropertyUsedCheckers;
            base.CustomizedColumnSearchRepository = goodsPropertySearchRepository;
            base.CustomizedColumnDeleteTriggers = goodsPropertyDeleteTriggers;
        }
    }
}

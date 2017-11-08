using Smafac.Framework.Core.Services.Property;
using Smafac.Hrs.Salary.Applications.Property;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Services.Property
{
    class SalaryPropertyUpdateService : PropertyUpdateService<SalaryPropertyEntity, SalaryPropertyModel>, ISalaryPropertyUpdateService
    {
        public SalaryPropertyUpdateService(ISalaryPropertySearchRepository goodsPropertySearchRepository,
                                          ISalaryPropertyUpdateRepository goodsPropertyUpdateRepository)
        {
            base.CustomizedColumnSearchRepository = goodsPropertySearchRepository;
            base.CustomizedColumnUpdateRepository = goodsPropertyUpdateRepository;
        }
    }
}

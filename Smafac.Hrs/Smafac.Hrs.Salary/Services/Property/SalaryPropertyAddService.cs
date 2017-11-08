using Smafac.Hrs.Salary.Applications.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Hrs.Salary.Models;
using Smafac.Framework.Core.Services.Property;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Repositories.Property;

namespace Smafac.Hrs.Salary.Services.Property
{
    class SalaryPropertyAddService : PropertyAddService<SalaryPropertyEntity, SalaryPropertyModel>, ISalaryPropertyAddService
    {
        public SalaryPropertyAddService(ISalaryPropertyAddRepository goodsPropertyAddRepository,
                                        ISalaryPropertySearchRepository goodsPropertySearchRepository)
        {
            base.CustomizedColumnAddRepository = goodsPropertyAddRepository;
            base.CustomizedColumnSearchRepository = goodsPropertySearchRepository;
        }
    }
}

using Smafac.Framework.Core.Services.Property;
using Smafac.Hrs.Employee.Applications.Property;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Domain.Property;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Services.Property
{
    class EmployeePropertyDeleteService : PropertyDeleteService<EmployeePropertyEntity, EmployeePropertyModel>, IEmployeePropertyDeleteService
    {
        public EmployeePropertyDeleteService(IEmployeePropertyDeleteRepository goodsPropertyDeleteRepository,
                                          IEmployeePropertySearchRepository goodsPropertySearchRepository,
                                          IEmployeePropertyUsedChecker[] goodsFinancePropertyUsedCheckers,
                                          IEmployeePropertyDeleteTrigger[] goodsPropertyDeleteTriggers)
        {
            base.CustomizedColumnDeleteRepository = goodsPropertyDeleteRepository;
            base.CustomizedColumnUsedCheckers = goodsFinancePropertyUsedCheckers;
            base.CustomizedColumnSearchRepository = goodsPropertySearchRepository;
            base.CustomizedColumnDeleteTriggers = goodsPropertyDeleteTriggers;
        }
    }
}

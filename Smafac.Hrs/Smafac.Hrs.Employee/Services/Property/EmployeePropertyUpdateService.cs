using Smafac.Framework.Core.Services.Property;
using Smafac.Hrs.Employee.Applications.Property;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Services.Property
{
    class EmployeePropertyUpdateService : PropertyUpdateService<EmployeePropertyEntity, EmployeePropertyModel>, IEmployeePropertyUpdateService
    {
        public EmployeePropertyUpdateService(IEmployeePropertySearchRepository goodsPropertySearchRepository,
                                          IEmployeePropertyUpdateRepository goodsPropertyUpdateRepository)
        {
            base.CustomizedColumnSearchRepository = goodsPropertySearchRepository;
            base.CustomizedColumnUpdateRepository = goodsPropertyUpdateRepository;
        }
    }
}

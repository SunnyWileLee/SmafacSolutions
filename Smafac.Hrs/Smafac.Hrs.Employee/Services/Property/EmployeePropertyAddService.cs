using Smafac.Hrs.Employee.Applications.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Hrs.Employee.Models;
using Smafac.Framework.Core.Services.Property;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Repositories.Property;

namespace Smafac.Hrs.Employee.Services.Property
{
    class EmployeePropertyAddService : PropertyAddService<EmployeePropertyEntity, EmployeePropertyModel>, IEmployeePropertyAddService
    {
        public EmployeePropertyAddService(IEmployeePropertyAddRepository propertyAddRepository,
                                        IEmployeePropertySearchRepository propertySearchRepository)
        {
            base.CustomizedColumnAddRepository = propertyAddRepository;
            base.CustomizedColumnSearchRepository = propertySearchRepository;
        }
    }
}

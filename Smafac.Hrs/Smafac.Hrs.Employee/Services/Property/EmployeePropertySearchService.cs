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
    class EmployeePropertySearchService : PropertySearchService<EmployeePropertyEntity, EmployeePropertyModel>, IEmployeePropertySearchService
    {
        private readonly IEmployeePropertyProvider _propertyProvider;

        public EmployeePropertySearchService(IEmployeePropertySearchRepository searchRepository,
            IEmployeePropertyProvider propertyProvider)
        {
            base.CustomizedColumnSearchRepository = searchRepository;
            _propertyProvider = propertyProvider;
        }

        public override List<EmployeePropertyModel> GetColumns(Guid entityId)
        {
            return _propertyProvider.Provide(entityId);
        }
    }
}

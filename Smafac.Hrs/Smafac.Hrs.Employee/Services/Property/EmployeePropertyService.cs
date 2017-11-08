using Smafac.Hrs.Employee.Applications.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Property;
using Smafac.Hrs.Employee.Models;

namespace Smafac.Hrs.Employee.Services.Property
{
    class EmployeePropertyService : IEmployeePropertyService
    {
        public EmployeePropertyService(IEmployeePropertyAddService propertyAddService,
            IEmployeePropertyDeleteService propertyDeleteService,
            IEmployeePropertySearchService propertySearchService,
            IEmployeePropertyUpdateService propertyUpdateService)
        {
            AddService = propertyAddService;
            DeleteService = propertyDeleteService;
            SearchService = propertySearchService;
            UpdateService = propertyUpdateService;
        }

        public IEmployeePropertyAddService AddService { get; set; }
        public IEmployeePropertyDeleteService DeleteService { get; set; }
        public IEmployeePropertySearchService SearchService { get; set; }
        public IEmployeePropertyUpdateService UpdateService { get; set; }
    }
}

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
        public EmployeePropertyService(IEmployeePropertyAddService goodsPropertyAddService,
            IEmployeePropertyDeleteService goodsPropertyDeleteService,
            IEmployeePropertySearchService goodsPropertySearchService,
            IEmployeePropertyUpdateService goodsPropertyUpdateService)
        {
            AddService = goodsPropertyAddService;
            DeleteService = goodsPropertyDeleteService;
            SearchService = goodsPropertySearchService;
            UpdateService = goodsPropertyUpdateService;
        }

        public IEmployeePropertyAddService AddService { get; set; }
        public IEmployeePropertyDeleteService DeleteService { get; set; }
        public IEmployeePropertySearchService SearchService { get; set; }
        public IEmployeePropertyUpdateService UpdateService { get; set; }
    }
}

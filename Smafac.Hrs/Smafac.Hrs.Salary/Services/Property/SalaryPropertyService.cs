using Smafac.Hrs.Salary.Applications.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Property;
using Smafac.Hrs.Salary.Models;

namespace Smafac.Hrs.Salary.Services.Property
{
    class SalaryPropertyService : ISalaryPropertyService
    {
        public SalaryPropertyService(ISalaryPropertyAddService goodsPropertyAddService,
            ISalaryPropertyDeleteService goodsPropertyDeleteService,
            ISalaryPropertySearchService goodsPropertySearchService,
            ISalaryPropertyUpdateService goodsPropertyUpdateService)
        {
            AddService = goodsPropertyAddService;
            DeleteService = goodsPropertyDeleteService;
            SearchService = goodsPropertySearchService;
            UpdateService = goodsPropertyUpdateService;
        }

        public ISalaryPropertyAddService AddService { get; set; }
        public ISalaryPropertyDeleteService DeleteService { get; set; }
        public ISalaryPropertySearchService SearchService { get; set; }
        public ISalaryPropertyUpdateService UpdateService { get; set; }
    }
}

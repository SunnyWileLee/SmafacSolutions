using Smafac.Framework.Core.Applications.Property;
using Smafac.Hrs.Salary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Applications.Property
{
    public interface ISalaryPropertyService 
    {
        ISalaryPropertyAddService AddService { get; set; }
        ISalaryPropertyDeleteService DeleteService { get; set; }
        ISalaryPropertySearchService SearchService { get; set; }
        ISalaryPropertyUpdateService UpdateService { get; set; }
    }
}

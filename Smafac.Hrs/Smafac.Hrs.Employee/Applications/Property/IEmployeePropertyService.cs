using Smafac.Framework.Core.Applications.Property;
using Smafac.Hrs.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Applications.Property
{
    public interface IEmployeePropertyService 
    {
        IEmployeePropertyAddService AddService { get; set; }
        IEmployeePropertyDeleteService DeleteService { get; set; }
        IEmployeePropertySearchService SearchService { get; set; }
        IEmployeePropertyUpdateService UpdateService { get; set; }
    }
}

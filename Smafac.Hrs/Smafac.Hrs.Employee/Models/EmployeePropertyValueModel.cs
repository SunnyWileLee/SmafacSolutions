using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Models
{
    public class EmployeePropertyValueModel : PropertyValueModel
    {
        public Guid EmployeeId { get; set; }
    }
}

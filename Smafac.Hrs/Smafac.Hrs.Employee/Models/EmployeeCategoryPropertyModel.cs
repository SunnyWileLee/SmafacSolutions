using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Models
{
    public class EmployeeCategoryPropertyModel : SaasBaseModel
    {
        public Guid CategoryId { get; set; }
        public Guid PropertyId { get; set; }
    }
}

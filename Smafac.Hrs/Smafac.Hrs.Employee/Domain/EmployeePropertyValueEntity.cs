using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Domain
{
    [Table("EmployeePropertyValue")]
    class EmployeePropertyValueEntity : PropertyValueEntity
    {
        public Guid EmployeeId { get; set; }
    }
}

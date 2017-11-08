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
    [Table("Employee")]
    class EmployeeEntity : SaasBaseEntity
    {
        public EmployeeEntity()
        {
            EmployeeDate = DateTime.Now;
        }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Identity { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        public DateTime EmployeeDate { get; set; }
        public Guid CategoryId { get; set; }
    }
}

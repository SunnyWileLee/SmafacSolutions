using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Domain
{
    [Table("Salary")]
    class SalaryEntity : SaasBaseEntity
    {
        public SalaryEntity()
        {
            SalaryDate = DateTime.Now;
        }
        public decimal Amount { get; set; }
        public DateTime SalaryDate { get; set; }
        public Guid CategoryId { get; set; }
    }
}

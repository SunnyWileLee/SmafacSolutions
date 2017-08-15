using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Domain
{
    [Table("Api")]
    class ApiEntity
    {
        public Guid ServiceId { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(500)]
        public string Url { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime PublishTime { get; set; }
    }
}

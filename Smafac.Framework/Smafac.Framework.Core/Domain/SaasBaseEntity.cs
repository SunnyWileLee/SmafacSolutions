using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
   public  class SaasBaseEntity
    {
       public SaasBaseEntity()
       {
           Id = Guid.NewGuid();
           CreateTime = DateTime.Now;
       }
       [Key]
       public Guid Id { get; set; }
       public Guid SubscriberId { get; set; }
       public DateTime CreateTime { get; set; }
    }
}

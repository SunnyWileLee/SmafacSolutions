using Smafac.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Domain
{
    [Table("ServiceSubscription")]
    class ServiceSubscriptionEntity
    {
        public string AppId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime DeadLine { get; set; }
        public SubscriptionStatus Status { get; set; }
    }
}

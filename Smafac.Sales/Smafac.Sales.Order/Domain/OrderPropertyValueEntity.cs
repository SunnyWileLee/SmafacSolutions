using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain
{
    class OrderPropertyValueEntity : PropertyValueEntity
    {
        public Guid OrderId { get; set; }
    }
}

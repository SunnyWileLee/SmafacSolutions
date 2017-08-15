using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Models
{
    public class CustomerContactDetailModel : CustomerContactModel
    {
        public CustomerContactDetailModel()
        {
 
        }

        public CustomerContactDetailModel(CustomerContactModel contact)
        {
            this.SubscriberId = contact.SubscriberId;
            this.CreateTime = contact.CreateTime;
            this.CustomerId = contact.CustomerId;
            this.Id = contact.Id;
            this.MobileNumber = contact.MobileNumber;
            this.Name = contact.Name;
        }
        public List<CustomerContactPropertyValueModel> PropertyValues { get; set; }
    }
}

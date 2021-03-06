﻿using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Smafac.Crm.Customer.Domain
{
    [Table("Customer")]
    class CustomerEntity : SaasBaseEntity
    {
        public CustomerEntity()
        {
            KnownDate = DateTime.Now;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime KnownDate { get; set; }
        public string MobileNumber { get; set; }
        public Guid LevelId { get; set; }

        public CustomerPropertyValueEntity SetProperty(Guid propertyId, string value)
        {
            return new CustomerPropertyValueEntity
            {
                SubscriberId = this.SubscriberId,
                CustomerId = this.Id,
                PropertyId = propertyId,
                Value = value
            };
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public abstract class PropertyEntity : SaasBaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }

        protected virtual TPropertyValueEntity CreateValueBase<TPropertyValueEntity>(string value) where TPropertyValueEntity : PropertyValueEntity
        {
            var propertyValue = default(TPropertyValueEntity);
            propertyValue.PropertyId = this.Id;
            propertyValue.SubscriberId = this.SubscriberId;
            propertyValue.Value = value;

            return propertyValue;
        }
    }
}

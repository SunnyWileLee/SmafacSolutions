﻿using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Models
{
    public class CustomerModel : HavePropertyModel
    {

        public CustomerModel()
        {
            KnownDate = DateTime.Now;
        }

        [Display(Name = "名称")]
        [ExportColumn]
        public string Name { get; set; }
        [Display(Name = "地址")]
        [ExportColumn]
        public string Address { get; set; }
        [Display(Name = "认识时间")]
        [ExportColumn]
        public DateTime KnownDate { get; set; }
        [Display(Name = "联系方式")]
        public string MobileNumber { get; set; }
        public Guid LevelId { get; set; }
        [Display(Name = "等级")]
        public string LevelName { get; set; }
        public List<CustomerPropertyValueModel> Properties { get; set; }

        public override IEnumerable<PropertyValueModel> PropertyValues
        {
            get
            {
                if (Properties == null)
                {
                    return new List<PropertyValueModel> { };
                }
                return Properties.Cast<PropertyValueModel>();
            }
        }
    }
}

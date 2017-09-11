﻿using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Smafac.Crm.CustomerFinance.Models
{
    public class CustomerFinancePageQueryModel : DateSpanPageQueryModel
    {
        [Display(Name = "分类")]
        [QueryProperty]
        public Guid CategoryId { get; set; }
        [Display(Name = "客户")]
        [QueryProperty]
        public Guid CustomerId { get; set; }

        protected override string DateColumn
        {
            get
            {
                return "FinanceTime";
            }
        }
    }
}

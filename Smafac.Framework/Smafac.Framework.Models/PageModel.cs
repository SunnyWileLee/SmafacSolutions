﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class PageModel<TModel> where TModel : class
    {
        public List<TModel> PageData { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage
        {
            get
            {
                return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(TotalCount) / PageSize));
            }
        }
    }
}

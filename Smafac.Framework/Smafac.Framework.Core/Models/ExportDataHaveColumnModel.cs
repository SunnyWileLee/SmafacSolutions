using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Models
{
    public class ExportDataHaveColumnModel<TData, TColumn> : ExportDataModel<TData>
        where TData : SaasBaseModel
        where TColumn : CustomizedColumnModel
    {
        public List<TColumn> Columns { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class ExportDataModel<TData, TColumn>
        where TData : SaasBaseModel
        where TColumn : CustomizedColumnModel
    {
        public List<TData> Datas { get; set; }
        public List<TColumn> Columns { get; set; }
    }
}

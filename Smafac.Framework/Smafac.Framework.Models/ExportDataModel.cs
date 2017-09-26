using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class ExportDataModel<TData> : IExportable
         where TData : SaasBaseModel
    {
        public List<TData> Datas { get; set; }
    }
}

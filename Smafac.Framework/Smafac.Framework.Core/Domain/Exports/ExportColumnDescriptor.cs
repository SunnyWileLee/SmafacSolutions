using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Exports
{
    public class ExportColumnDescriptor : IExportColumnDescriptor
    {
        public string DisplayName { get; set; }
        public int Order { get; set; }
    }
}

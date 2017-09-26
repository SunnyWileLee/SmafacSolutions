using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Exports
{
    public class ExportPropertyColumnDescriptor
    {
        public ExportPropertyColumnDescriptor(PropertyInfo property)
        {
            Property = property;
            DisplayName = property.Name;
        }

        public PropertyInfo Property { get; private set; }
        public string DisplayName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Exports
{
    public abstract class DataExporter : IDataExporter
    {
        protected virtual string FileNameExtension
        {
            get
            {
                return ".xlsx";
            }
        }

        public virtual string CreateFileName(string module)
        {
            var fileName = string.Format("{0}数据{1}.{2}", module, DateTime.Now.ToString("yyyymmddHHmmss"), FileNameExtension);
            return fileName;
        }
    }
}

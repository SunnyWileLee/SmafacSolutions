using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.CustomizedColumn
{
    public interface ICustomizedColumnUsedChecker<TColumn> where TColumn : CustomizedColumnEntity
    {
        bool Check(TColumn column);
    }
}

using Smafac.Framework.Core.Models;
using Smafac.Hrs.Salary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Domain.Property
{
    interface ISalaryPropertyProvider
    {
        List<SalaryPropertyModel> Provide(Guid goodsId);
    }
}

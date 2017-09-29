using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.CustomizedColumn
{
    public interface ICustomizedColumnDeleteService<TCustomizedColumnModel> where TCustomizedColumnModel : CustomizedColumnModel
    {
        bool DeleteColumn(Guid columnId);
    }
}

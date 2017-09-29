using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.CustomizedColumn
{
    public interface ICustomizedColumnSearchService<TCustomizedColumnModel> where TCustomizedColumnModel : CustomizedColumnModel
    {
        List<TCustomizedColumnModel> GetColumns();
        List<TCustomizedColumnModel> GetColumns(Guid entityId);
        TCustomizedColumnModel GetColumn(Guid id);
    }
}

using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.CustomizedColumn
{
    public interface ICustomizedColumnAddService<TCustomizedColumnModel> where TCustomizedColumnModel : CustomizedColumnModel
    {
        bool AddColumn(TCustomizedColumnModel model);
    }
}

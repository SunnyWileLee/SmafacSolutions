using Smafac.ServiceCenter.Core.Domain;
using Smafac.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Repositories
{
    interface IApiRepository
    {
        bool AddApi(ApiEntity api);
        bool DeleteApi(string code);
        bool UpdateApi(ApiModel model);
        bool Exist(string code);
    }
}

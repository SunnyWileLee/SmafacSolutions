using Smafac.ServiceCenter.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Repositories
{
    interface IServiceSearchRepository
    {
        ServiceEntity GetServiceById(Guid id);
        ServiceEntity GetServiceByName(string name);
    }
}

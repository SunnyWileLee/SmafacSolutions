using Smafac.ServiceCenter.Core.Domain;
using Smafac.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Repositories
{
    interface IServiceRepository
    {
        bool AddService(ServiceEntity service);
        bool DeleteService(string name);
        bool UpdateService(ServiceModel model);
        bool ExistService(string name);
    }
}

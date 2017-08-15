using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.ServiceCenter.Core.Domain;
using Smafac.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Services
{
    public class ServiceCenterAutoMapper : SmafacAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<ServiceEntity, ServiceModel>(cfg);
            base.BipassMapper<ApiEntity, ApiModel>(cfg);
        }
    }
}

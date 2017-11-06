using AutoMapper;
using Smafac.Infrustructure.Base;
using Smafac.Infrustructure.Config.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Config.Models
{
    class ConfigAutoMapper : InfrustructureAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<ConfigEntity, ConfigModel>(cfg);
        }
    }
}

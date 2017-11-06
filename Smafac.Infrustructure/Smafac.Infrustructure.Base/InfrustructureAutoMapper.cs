using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Base
{
    public abstract class InfrustructureAutoMapper : IInfrustructureAutoMapper
    {
        public abstract void CreateMapper(IMapperConfigurationExpression cfg);
        protected virtual void BipassMapper<T1, T2>(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<T1, T2>();
            cfg.CreateMap<T2, T1>();
        }
    }
}

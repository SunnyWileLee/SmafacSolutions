using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Base
{
    public interface IInfrustructureAutoMapper
    {
        void CreateMapper(IMapperConfigurationExpression cfg);
    }
}

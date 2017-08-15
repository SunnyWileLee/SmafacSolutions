using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Models
{
    public interface IAutoMapper
    {
        void CreateMapper(IMapperConfigurationExpression cfg);
    }
}

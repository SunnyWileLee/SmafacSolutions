using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Models
{
    class AutoMapperProxy : IAutoMapperProxy
    {
        private readonly IAutoMapper[] _mappers;
        public AutoMapperProxy(IAutoMapper[] mappers)
        {
            _mappers = mappers;
        }
        public void CreateMapper()
        {
            Mapper.Initialize(cfg =>
            {
                foreach (var mapper in _mappers)
                {
                    mapper.CreateMapper(cfg);
                }
            });
        }
    }
}

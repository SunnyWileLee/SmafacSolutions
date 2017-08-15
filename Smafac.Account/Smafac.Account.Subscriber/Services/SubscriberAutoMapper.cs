using AutoMapper;
using Smafac.Account.Subscriber.Domain;
using Smafac.Account.Subscriber.Models;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Services
{
    class SubscriberAutoMapper : SmafacAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<SignInEntity, SignInModel>(cfg);
        }
    }
}

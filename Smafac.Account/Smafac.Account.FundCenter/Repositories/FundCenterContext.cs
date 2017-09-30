using Smafac.Account.FundCenter.Domain;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Repositories
{
    class FundCenterContext : SmafacContext
    {
        public DbSet<SubscriberFundEntity> SubscriberFunds { get; }
        public DbSet<ConsumeThingEntity> ConsumeThings { get; set; }
    }
}

using Smafac.Account.FundCenter.Domain;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Repositories
{
    interface IFundUpdateRepository : IEntityUpdateRepository<SubscriberFundEntity>
    {
        bool AddBalance(Guid subscriberId,decimal amount);
        bool MinusBalance(Guid subscriberId, decimal amount);
    }
}

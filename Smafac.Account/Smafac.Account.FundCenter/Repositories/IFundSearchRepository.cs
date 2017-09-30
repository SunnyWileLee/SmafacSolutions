using Smafac.Account.FundCenter.Domain;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Repositories
{
    interface IFundSearchRepository : IEntitySearchRepository<SubscriberFundEntity>
    {
        SubscriberFundEntity First(Guid subscriberId);
    }
}

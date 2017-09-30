using Smafac.Account.FundCenter.Domain;
using Smafac.Account.FundCenter.Models;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Repositories
{
    interface IConsumeThingSearchRepository : IEntitySearchRepository<ConsumeThingEntity>
    {
        ConsumeThingEntity GetByType(ConsumeThingType type);
    }
}

using Smafac.Account.FundCenter.Domain;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Repositories
{
    class ConsumeAddRepository : EntityAddRepository<FundCenterContext, ConsumeEntity>, IConsumeAddRepository
    {
        public ConsumeAddRepository(IFundCenterContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}

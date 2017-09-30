using Smafac.Account.FundCenter.Domain;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Account.FundCenter.Models;

namespace Smafac.Account.FundCenter.Repositories
{
    class ConsumeThingSearchRepository : EntitySearchRepository<FundCenterContext, ConsumeThingEntity>,
                                        IConsumeThingSearchRepository
    {
        public ConsumeThingSearchRepository(IFundCenterContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        public ConsumeThingEntity GetByType(ConsumeThingType type)
        {
            using (var context = ContextProvider.Provide())
            {
                return context.ConsumeThings.FirstOrDefault(s => s.Type == type);
            }
        }
    }
}

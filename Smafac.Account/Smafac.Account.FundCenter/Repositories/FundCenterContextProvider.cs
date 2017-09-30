using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Repositories
{
    class FundCenterContextProvider : IFundCenterContextProvider
    {
        public FundCenterContext Provide()
        {
            return new FundCenterContext();
        }

        public FundCenterContext ProvideSlave()
        {
            return new FundCenterContext();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Domain.Consume
{
    interface IBalanceChecker
    {
        bool Check(Guid subscriberId);
    }
}

using Smafac.Account.FundCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Infrustructure
{
    public class ConsumeAttribute : Attribute
    {
        public ConsumeAttribute(ConsumeThingType thingType)
        {
            ThingType = thingType;
        }

        public ConsumeThingType ThingType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Repositories
{
    class DeliveryNoteContextProvider : IDeliveryNoteContextProvider
    {
        public DeliveryNoteContext Provide()
        {
            return new DeliveryNoteContext();
        }

        public DeliveryNoteContext ProvideSlave()
        {
            return new DeliveryNoteContext();
        }
    }
}

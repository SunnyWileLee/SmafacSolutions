using Smafac.Framework.Core.Repositories;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using System;

namespace Smafac.Sales.DeliveryNote.Repositories
{
    interface IDeliveryNoteSearchRepository : IEntitySearchRepository<DeliveryNoteEntity>
    {
        DeliveryNoteModel GetDeliveryNote(Guid subscriberId, Guid id);
    }
}

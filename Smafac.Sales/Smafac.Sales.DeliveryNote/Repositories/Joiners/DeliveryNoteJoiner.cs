using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using System.Linq;

namespace Smafac.Sales.DeliveryNote.Repositories.Joiners
{
    class DeliveryNoteJoiner : IDeliveryNoteJoiner
    {
        public IQueryable<DeliveryNoteModel> Join(IQueryable<DeliveryNoteEntity> notes, IQueryable<DeliveryNoteCategoryEntity> categories)
        {
            var query = from note in notes
                        join category in categories on note.CategoryId equals category.Id
                        select new DeliveryNoteModel
                        {
                            CategoryId = note.CategoryId,
                            SubscriberId = note.SubscriberId,
                            CategoryName = category.Name,
                            CreateTime = note.CreateTime,
                            Id = note.Id,
                            CustomerId = note.CustomerId,
                            Memo = note.Memo,
                            Amount = note.Amount,
                            DeliveryTime = note.DeliveryTime
                        };
            return query;
        }
    }
}

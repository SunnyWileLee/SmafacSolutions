using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.Joiners;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Sales.DeliveryNote.Repositories.Pages
{
    class DeliveryNotePageQueryRepository : PageQueryRepository<DeliveryNoteContext, DeliveryNoteEntity, DeliveryNoteModel>
                                                , IDeliveryNotePageQueryRepository
    {
        private readonly IDeliveryNoteJoiner _noteJoiner;

        public DeliveryNotePageQueryRepository(IDeliveryNoteContextProvider contextProvider,
                                        IDeliveryNoteJoiner noteJoiner)
        {
            base.ContextProvider = contextProvider;
            _noteJoiner = noteJoiner;
        }

        protected override List<DeliveryNoteModel> SelectModel(IQueryable<DeliveryNoteEntity> query, DeliveryNoteContext context)
        {
            var models = _noteJoiner.Join(query, context.DeliveryNoteCategories);
            return models.ToList();
        }
    }
}

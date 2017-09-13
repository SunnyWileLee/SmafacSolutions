using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Sales.DeliveryNote.Applications.CategoryProperty;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Domain.CategoryProperty;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Services.CategoryProperty
{
    class DeliveryNoteCategoryPropertySearchService : CategoryPropertySearchService<DeliveryNoteCategoryEntity, DeliveryNotePropertyEntity, DeliveryNotePropertyModel>,
                                                IDeliveryNoteCategoryPropertySearchService
    {
        public DeliveryNoteCategoryPropertySearchService(IDeliveryNoteCategoryPropertySearchRepository ctegoryPropertySearchRepository,
                                                        IDeliveryNoteCategoryPropertyProvider categoryPropertyProvider
                                                        )
        {

            base.CategoryAssociationProvider = categoryPropertyProvider;
            base.EntityAssociationSearchRepository = ctegoryPropertySearchRepository;
        }
    }
}

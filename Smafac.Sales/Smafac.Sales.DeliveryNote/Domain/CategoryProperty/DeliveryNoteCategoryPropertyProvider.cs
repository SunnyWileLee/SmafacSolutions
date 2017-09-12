using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.Category;
using Smafac.Sales.DeliveryNote.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Domain.CategoryProperty
{
    class DeliveryNoteCategoryPropertyProvider: CategoryPropertyProvider<DeliveryNoteCategoryEntity, DeliveryNotePropertyEntity, DeliveryNotePropertyModel> ,
                                        IDeliveryNoteCategoryPropertyProvider
    {
        public DeliveryNoteCategoryPropertyProvider(IDeliveryNoteCategorySearchRepository categorySearchRepository,
                                               IDeliveryNoteCategoryPropertySearchRepository categoryPropertySearchRepository)
        {
            base.CategorySearchRepository = categorySearchRepository;
            base.CategoryAssociationSearchRepository = categoryPropertySearchRepository;
        }
    }
}

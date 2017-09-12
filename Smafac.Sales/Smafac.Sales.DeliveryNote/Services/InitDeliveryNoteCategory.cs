using Smafac.Framework.Core.Applications;
using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Services
{
    class InitDeliveryNoteCategory : IInitDatas
    {
        private readonly IDeliveryNoteCategoryAddRepository _deliveryNoteCategoryAddRepository;
        private readonly IDeliveryNoteCategorySearchRepository _deliveryNoteCategorySearchRepository;

        public InitDeliveryNoteCategory(IDeliveryNoteCategoryAddRepository deliveryNoteCategoryAddRepository,
                                        IDeliveryNoteCategorySearchRepository deliveryNoteCategorySearchRepository
                                        )
        {
            _deliveryNoteCategoryAddRepository = deliveryNoteCategoryAddRepository;
            _deliveryNoteCategorySearchRepository = deliveryNoteCategorySearchRepository;
        }

        public void Init()
        {
            var subscriberId = UserContext.Current.SubscriberId;
            if (_deliveryNoteCategorySearchRepository.Any(subscriberId))
            {
                return;
            }
            var category = new DeliveryNoteCategoryEntity
            {
                Name = "默认分类",
                SubscriberId = subscriberId
            };
            _deliveryNoteCategoryAddRepository.AddEntity(category);
        }
    }
}

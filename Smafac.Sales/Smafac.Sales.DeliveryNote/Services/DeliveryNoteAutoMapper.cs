using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Services
{
    class DeliveryNoteAutoMapper : SmafacAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<DeliveryNoteCategoryEntity, DeliveryNoteCategoryModel>(cfg);
            base.BipassMapper<DeliveryNoteEntity, DeliveryNoteModel>(cfg);
            base.BipassMapper<DeliveryNoteItemEntity, DeliveryNoteItemModel>(cfg);
            base.BipassMapper<DeliveryNoteItemPropertyEntity, DeliveryNoteItemPropertyModel>(cfg);
            base.BipassMapper<DeliveryNoteItemPropertyValueEntity, DeliveryNoteItemPropertyValueModel>(cfg);
            base.BipassMapper<DeliveryNotePropertyEntity, DeliveryNotePropertyModel>(cfg);
            base.BipassMapper<DeliveryNotePropertyValueEntity, DeliveryNotePropertyValueModel>(cfg);
        }
    }
}

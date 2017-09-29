using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Applications;
using Smafac.Sales.DeliveryNote.Domain.Pages;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories;
using Smafac.Sales.DeliveryNote.Repositories.PropertyValue;
using System;
using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Repositories.ItemProperty;
using System.Linq;
using System.Collections.Generic;
using Smafac.Sales.DeliveryNote.Repositories.Item;
using Smafac.Sales.DeliveryNote.Repositories.ItemPropertyValue;
using Smafac.Sales.DeliveryNote.Domain.CategoryItemProperty;

namespace Smafac.Sales.DeliveryNote.Services
{
    class DeliveryNoteSearchService : IDeliveryNoteSearchService
    {
        private readonly IDeliveryNoteSearchRepository _noteSearchRepository;
        private readonly IDeliveryNotePropertyValueSearchRepository _notePropertyValueSearchRepository;
        private readonly IDeliveryNotePageQueryer _notePageQueryer;
        private readonly IDeliveryNoteItemPropertySearchRepository _itemPropertySearchRepository;
        private readonly IDeliveryNoteItemSearchRepository _itemSearchRepository;
        private readonly IDeliveryNoteItemPropertyValueSearchRepository _itemPropertyValueSearchRepository;
        private readonly IDeliveryNoteCategoryItemPropertyProvider _categoryItemPropertyProvider;

        public DeliveryNoteSearchService(IDeliveryNoteSearchRepository noteSearchRepository,
                                    IDeliveryNotePropertyValueSearchRepository notePropertyValueSearchRepository,
                                    IDeliveryNotePageQueryer notePageQueryer,
                                    IDeliveryNoteItemPropertySearchRepository itemPropertySearchRepository,
                                    IDeliveryNoteItemSearchRepository itemSearchRepository,
                                    IDeliveryNoteItemPropertyValueSearchRepository itemPropertyValueSearchRepository,
                                    IDeliveryNoteCategoryItemPropertyProvider categoryItemPropertyProvider
                                    )
        {
            _noteSearchRepository = noteSearchRepository;
            _notePropertyValueSearchRepository = notePropertyValueSearchRepository;
            _notePageQueryer = notePageQueryer;
            _itemPropertySearchRepository = itemPropertySearchRepository;
            _itemSearchRepository = itemSearchRepository;
            _itemPropertyValueSearchRepository = itemPropertyValueSearchRepository;
            _categoryItemPropertyProvider = categoryItemPropertyProvider;
        }

        public DeliveryNoteModel GetDeliveryNote(Guid noteId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var note = _noteSearchRepository.GetDeliveryNote(subscriberId, noteId);
            var properties = _notePropertyValueSearchRepository.GetPropertyValues(subscriberId, noteId);
            var model = Mapper.Map<DeliveryNoteModel>(note);
            model.Properties = properties;
            return model;
        }

        public DeliveryNoteDetailModel GetDeliveryNoteDetail(Guid noteId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var note = this.GetDeliveryNote(noteId);
            var itemTableColumns = _itemPropertySearchRepository.SelectTableColumns(subscriberId)
                                .Select(s => new CustomizedColumnModel
                                {
                                    Name = s.Name,
                                    Id = s.Id,
                                }).ToList();
            var itemPoperties = _categoryItemPropertyProvider.ProvideAssociations(note.CategoryId);
            return new DeliveryNoteDetailModel
            {
                DeliveryNote = note,
                ItemTableColumns = itemTableColumns,
                Items = GetItems(note.Id),
                ItemProperties = itemPoperties
            };
        }

        private List<DeliveryNoteItemModel> GetItems(Guid noteId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var items = _itemSearchRepository.GetEntities(subscriberId, s => s.DeliveryNoteId == noteId);
            if (items.Any())
            {
                var ids = items.Select(s => s.Id);
                var properties = _itemPropertyValueSearchRepository.GetPropertyValues(UserContext.Current.SubscriberId, ids);
                return items.Select(item =>
                {
                    var model = Mapper.Map<DeliveryNoteItemModel>(item);
                    var ps = properties.FirstOrDefault(s => s.Key == item.Id);
                    model.Properties = ps == null ? new List<DeliveryNoteItemPropertyValueModel>() : ps.ToList();
                    return model;
                }).ToList();
            }
            return new List<DeliveryNoteItemModel>();
        }

        public PageModel<DeliveryNoteModel> GetDeliveryNotePage(DeliveryNotePageQueryModel query)
        {
            return _notePageQueryer.QueryPage(query);
        }
    }
}

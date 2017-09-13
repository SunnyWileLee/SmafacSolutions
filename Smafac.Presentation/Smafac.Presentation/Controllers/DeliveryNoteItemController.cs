using Smafac.Presentation.Domain.DeliveryNote;
using Smafac.Sales.DeliveryNote.Applications.Item;
using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class DeliveryNoteItemController : SmafacController
    {
        private readonly IDeliveryNoteItemService _itemService;
        private readonly IDeliveryNoteItemUpdateService _itemUpdateService;
        private readonly IDeliveryNoteItemSearchService _itemSearchService;
        private readonly IDeliveryNoteItemWrapper[] _itemWrappers;

        public DeliveryNoteItemController(IDeliveryNoteItemService itemService,
                                        IDeliveryNoteItemUpdateService itemUpdateService,
                                        IDeliveryNoteItemSearchService itemSearchService,
                                        IDeliveryNoteItemWrapper[] itemWrappers)
        {
            _itemService = itemService;
            _itemUpdateService = itemUpdateService;
            _itemSearchService = itemSearchService;
            _itemWrappers = itemWrappers;
        }

        [HttpPost]
        public ActionResult AddNoteItem(DeliveryNoteItemModel model)
        {
            var result = _itemService.AddDeliveryNoteItem(model);
            return BoolResult(result);
        }

        [HttpPost]
        public ActionResult EditNoteItem(DeliveryNoteItemModel model)
        {
            var result = _itemUpdateService.UpdateDeliveryNoteItem(model);
            return BoolResult(result);
        }
        [HttpGet]
        public ActionResult DeliveryNoteEditView(Guid itemId)
        {
            var item = _itemSearchService.GetItem(itemId);
            _itemWrappers.ToList().ForEach(wrapper =>
            {
                wrapper.Wrapper(new List<DeliveryNoteItemModel> { item });
            });
            return View(item);
        }
    }
}
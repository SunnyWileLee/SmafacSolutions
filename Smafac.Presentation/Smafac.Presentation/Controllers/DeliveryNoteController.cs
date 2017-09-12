using Smafac.Sales.DeliveryNote.Applications;
using Smafac.Sales.DeliveryNote.Applications.Category;
using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class DeliveryNoteController : SmafacController
    {
        private readonly IDeliveryNoteService _noteService;
        private readonly IDeliveryNoteSearchService _noteSearchService;
        private readonly IDeliveryNoteCategoryService _noteCategoryService;

        public DeliveryNoteController(IDeliveryNoteService noteService,
                                IDeliveryNoteSearchService noteSearchService,
                                IDeliveryNoteCategoryService noteCategoryService)
        {
            _noteService = noteService;
            _noteSearchService = noteSearchService;
            _noteCategoryService = noteCategoryService;
        }

        [HttpGet]
        public ActionResult DeliveryNoteView()
        {
            var categories = _noteCategoryService.SearchService.GetCategories();
            ViewData["categories"] = categories.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            return View();
        }
        [HttpGet]
        public ActionResult DeliveryNotePageView(DeliveryNotePageQueryModel query)
        {
            var page = _noteSearchService.GetDeliveryNotePage(query);
            ViewData["tableColumns"] = page.TableColumns;
            return View(page.PageData);
        }
        [HttpPost]
        public ActionResult DeliveryNotePage(DeliveryNotePageQueryModel query)
        {
            var page = _noteSearchService.GetDeliveryNotePage(query);
            return Success(page);
        }
        [HttpGet]
        public ActionResult DeliveryNoteAddView()
        {
            var categories = _noteCategoryService.SearchService.GetLeafCategories()
                            .Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["categories"] = categories;
            var note = _noteService.CreateEmptyDeliveryNote();
            return View(note);
        }

        [HttpPost]
        public ActionResult AddDeliveryNote(DeliveryNoteModel model)
        {
            var result = _noteService.AddDeliveryNote(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditDeliveryNote(DeliveryNoteModel model)
        {
            var result = _noteService.UpdateService.UpdateDeliveryNote(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult DeliveryNoteDetailView(Guid noteId)
        {
            var note = _noteSearchService.GetDeliveryNoteDetail(noteId);
            return View(note);
        }
    }
}
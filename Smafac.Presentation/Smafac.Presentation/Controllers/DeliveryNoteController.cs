using Smafac.Crm.Customer.Applications;
using Smafac.Presentation.Domain.DeliveryNote;
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
        private readonly ICustomerSearchService _customerSearchService;
        private readonly IDeliveryNoteWrapper[] _noteWrappers;

        public DeliveryNoteController(IDeliveryNoteService noteService,
                                IDeliveryNoteSearchService noteSearchService,
                                ICustomerSearchService customerSearchService,
                                IDeliveryNoteCategoryService noteCategoryService,
                                IDeliveryNoteWrapper[] noteWrappers)
        {
            _noteService = noteService;
            _noteSearchService = noteSearchService;
            _noteCategoryService = noteCategoryService;
            _customerSearchService = customerSearchService;
            _noteWrappers = noteWrappers;
        }

        [HttpGet]
        public ActionResult DeliveryNoteView()
        {
            var categories = _noteCategoryService.SearchService.GetCategories();
            ViewData["categories"] = categories.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            var customers = _customerSearchService.GetCustomers().Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["customers"] = customers;
            return View();
        }
        [HttpGet]
        public ActionResult DeliveryNotePageView(DeliveryNotePageQueryModel query)
        {
            var page = _noteSearchService.GetDeliveryNotePage(query);
            var notes = page.PageData;
            if (notes.Any())
            {
                _noteWrappers.ToList().ForEach(wrapper =>
                {
                    wrapper.Wrapper(notes);
                });
            }
            ViewData["tableColumns"] = page.TableColumns;
            return View(notes);
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

            var customers = _customerSearchService.GetCustomers().Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["customers"] = customers;
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
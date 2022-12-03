using BusTicket.Business.Abstract;
using BusTicket.Core;
using BusTicket.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BusTicket.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IMidlineService _midlineService;

        public HomeController(ITripService tripService, IMidlineService midlineService)
        {
            _tripService = tripService;
            _midlineService = midlineService;
        }

        public async Task<IActionResult> Index()
        {
            var midlines = await _midlineService.GetAllAsync();
            var tripSearchModel = new TripSearchModel()
            {
                MidLines = midlines
            };
            return View(tripSearchModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TripSearchModel SearchModel)
        {
            if (ModelState.IsValid)
            {
                SearchModel.Date = Jobs.UpdateDateFormat(SearchModel.Date);
                return RedirectToAction("TripList","BusTicket", SearchModel);
            }
            else
            {
                var midlines = await _midlineService.GetAllAsync();
                SearchModel.MidLines = midlines;
            }
            return View(SearchModel);
        }

    }
}
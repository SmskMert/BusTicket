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

        public HomeController(ITripService tripService)
        {
            _tripService = tripService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(TripSearchModel SearchModel)
        {
            if (ModelState.IsValid)
            {
                SearchModel.Date = Jobs.UpdateDateFormat(SearchModel.Date);
                var trips = await _tripService.GetAllTripsWDetails();
                return RedirectToAction("TripList","BusTicket", SearchModel);
            };
            return View(SearchModel);
        }

    }
}
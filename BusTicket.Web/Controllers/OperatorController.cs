using BusTicket.Business.Abstract;
using BusTicket.Core;
using BusTicket.Entity;
using BusTicket.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusTicket.Web.Controllers
{
    [Authorize(Roles = "Operator")]
    public class OperatorController : Controller
    {
        private readonly ITripService _TripService;
        private readonly ILineService _LineService;
        private readonly IBusService _BusService;
        private readonly IDriverService _DriverService;
        private readonly ITripDetailService _TripDetailService;
        private readonly IMidlineService _MidlineService;
        public OperatorController(ITripService TripService, ILineService lineService, IBusService busService, IDriverService driverService, IMidlineService midlineService, ITripDetailService tripDetailModel)
        {
            _TripService = TripService;
            _LineService = lineService;
            _BusService = busService;
            _DriverService = driverService;
            _TripDetailService = tripDetailModel;
            _MidlineService = midlineService;
        }

        #region LineTripActions

        //public async Task<IActionResult> TripList()
        //{
        //    var trips = await _TripService.GetAllTripsWDetails();
        //    return View(trips);
        //}

        public async Task<IActionResult> LineList()
        {
            var lines = await _LineService.GetLinesWithTripsAsync();
            return View(lines);
        }

        public async Task<IActionResult> LineDetails(int id)
        {
            var line = await _LineService.GetLineWithDetailsAsync(id);
            return View(line);
        }

        public async Task<IActionResult> CreateLine()
        {
            var createLineModel = new CreateLineModel
            {
                Buses = await _BusService.GetAllAsync(),
                Drivers = await _DriverService.GetAllAsync()
            };
            return View(createLineModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLine(CreateLineModel createLine)
        {
            if (createLine.Stops.Contains(null) || createLine.Time.Contains(null) || createLine.Fares.Contains(null))
            {
                if (createLine.Stops.Contains(null))
                {
                    ModelState.AddModelError("", "All stops must be filled");
                }
                if (createLine.Time.Contains(null))
                {
                    ModelState.AddModelError("", "All Time inputs must be filled");
                }
                if (createLine.Fares.Contains(null))
                {
                    ModelState.AddModelError("", "All Fares inputs must be filled");
                }
                var stopTimeFares = new List<StopTimeFareModel>();
                for (int i = 0; i < createLine.Stops.Count; i++)
                {
                    var stopTimeFare = new StopTimeFareModel()
                    {
                        Stop = createLine.Stops[i],
                        Time = createLine.Time[i],
                        Fare = i == createLine.Stops.Count - 1 ? null : createLine.Fares[i]
                    };
                    stopTimeFares.Add(stopTimeFare);
                }
                createLine.StopTimeFares = stopTimeFares;
                createLine.Drivers = await _DriverService.GetAllAsync();
                createLine.Buses = await _BusService.GetAllAsync();
                return View(createLine);
            }

            var line = new Line()
            {

                Destination = createLine.Stops.Last(),
                StartingPoint = createLine.Stops.First()
            };

            await _LineService.CreateAsync(line);

            for (int i = 0; i < (createLine.Stops.Count - 1); i++)
            {
                MidLine midline = new()
                {
                    MidLineOrder = i + 1,
                    StartingPoint = createLine.Stops[i],
                    Destination = createLine.Stops[i + 1],
                    LineId = line.Id
                };
                await _MidlineService.CreateAsync(midline);
            }

            TripDetail tripDetail = new()
            {
                BusId = (int)createLine.BusId,
                DriverId = (int)createLine.DriverId
            };
            await _TripDetailService.CreateAsync(tripDetail);

            line = await _LineService.GetLineWithDetailsAsync(line.Id);

            for (int x = 0; x < line.MidLines.Count; x++)
            {
                Trip trip = new()
                {
                    MidLineId = line.MidLines[x].Id,
                    ScheduleDate = Jobs.UpdateDateFormat(createLine.Date),
                    DepartureTime = createLine.Time[x],
                    ArrivalTime = createLine.Time[x + 1],
                    FareAmount = decimal.Parse(createLine.Fares[x]),
                    TripDetailId = tripDetail.Id
                };
                await _TripService.CreateAsync(trip);
            }


            return RedirectToAction("LineList");
        }
        #endregion


        #region BusActions
        public async Task<IActionResult> BusList()
        {
            var buses = await _BusService.GetAllAsync();
            return View(buses);
        }

        public IActionResult CreateBus()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBus(BusModel busModel)
        {
            if (!ModelState.IsValid)
            {
                return View(busModel);
            }
            var bus = new Bus()
            {
                Capacity = (int)busModel.Capacity,
                HasWifi = busModel.HasWifi,
                HasUSB = busModel.HasUSB,
                HasSeatScreen = busModel.HasSeatScreen
            };
            await _BusService.CreateAsync(bus);

            return RedirectToAction("BusList");
        }

        public async Task<IActionResult> UpdateBus(int id)
        {
            var bus = await _BusService.GetByIdAsync(id);
            BusModel busModel = new()
            {
                Id = bus.Id,
                Capacity = bus.Capacity,
                HasWifi = bus.HasWifi,
                HasUSB = bus.HasUSB,
                HasSeatScreen = bus.HasSeatScreen
            };
            return View(busModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBus(BusModel busModel)
        {
            var bus = await _BusService.GetByIdAsync((int)busModel.Id);
            bus.Capacity = (int)busModel.Capacity;
            bus.HasUSB = busModel.HasUSB;
            bus.HasWifi = busModel.HasWifi;
            bus.HasSeatScreen = busModel.HasSeatScreen;

            return RedirectToAction("BusList");

        }
        public async Task<IActionResult> DeleteBus(int id)
        {
            var bus = await _BusService.GetByIdAsync(id);
            await _BusService.DeleteAsync(bus);

            return RedirectToAction("BusList");

        }
        #endregion
    }
}

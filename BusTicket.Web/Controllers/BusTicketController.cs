using BusTicket.Business.Abstract;
using BusTicket.Core;
using BusTicket.Entity;
using BusTicket.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusTicket.Web.Controllers
{
    public class BusTicketController : Controller
    {
        private readonly ITripService _tripService;
        private readonly ICustomerService _customerService;
        private readonly ITicketService _ticketService;

        public BusTicketController(ITripService ITripService, ICustomerService customerService, ITicketService ticketService)
        {
            _tripService = ITripService;
            _customerService = customerService;
            _ticketService = ticketService;
        }



        public async Task<IActionResult> TripList(TripSearchModel searchModel)
        {
            if (searchModel!= null)
            {
            var trips = await _tripService.GetTripsBySearch(searchModel.Origin, searchModel.Destination, searchModel.Date);
            return View(trips);
            }
            return NotFound();
        }

        public async Task<IActionResult> SeatSelection(int id)
        {
            var trip = await _tripService.GetTripWithDetails(id);
            var seatSelectionModel = new SeatSelectionModel()
            {
                Trip = trip,
                Tickets = trip.Tickets
            };
            return View(seatSelectionModel);
        }

        [HttpPost]
            public async Task<IActionResult> SeatSelection(SeatSelectionModel seatSelectionModel)
        {
            if (!ModelState.IsValid)
            {
                var trip = await _tripService.GetTripWithDetails(int.Parse(seatSelectionModel.TripId));
                seatSelectionModel.Trip = trip;
                seatSelectionModel.Tickets = trip.Tickets;
                return View(seatSelectionModel);
            }
            return RedirectToAction("PassangerDetails", seatSelectionModel);
        }

        public IActionResult PassangerDetails(SeatSelectionModel seatSelectionModel)
        {
            var passangerDetails = new PassangerDetailsModel()
            {
                TripId = seatSelectionModel.TripId,
                SelectedSeatNo = seatSelectionModel.SelectedSeatNo
            };
            return View(passangerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> PassangerDetails(PassangerDetailsModel passangerDetails)
        {
            if (!ModelState.IsValid)
            {
                return View(passangerDetails);
            }
            var customer = new Customer()
            {
                FName = passangerDetails.FName,
                LName = passangerDetails.LName,
                Gender = passangerDetails.Gender,
                Age = passangerDetails.Age,
                Contact = passangerDetails.Contact,
                Email = passangerDetails.Email
            };
            await _customerService.CreateAsync(customer);
          
                var displayTicket = new DisplayTicketModel()
                {
                    CustomerId = customer.Id,
                    TripId = passangerDetails.TripId,
                    SelectedSeatNo = passangerDetails.SelectedSeatNo
                };
            return RedirectToAction("DisplayTicket", displayTicket);
            
        }
        
        public async Task<IActionResult> DisplayTicket(DisplayTicketModel displayTicket)
        {
            var customer = await _customerService.GetByIdAsync(displayTicket.CustomerId);
            if (customer == null) return NotFound();
            else displayTicket.Customer = customer;

            var ticket = new Ticket()
            {
                SeatNo = int.Parse(displayTicket.SelectedSeatNo),
                TripId = int.Parse(displayTicket.TripId),
                CustomerId = customer.Id
            };
            await _ticketService.CreateAsync(ticket);
            ticket = await _ticketService.GetTicketWithTrip(ticket.Id);
            displayTicket.Ticket = ticket;

            return View(displayTicket);
        }
    }
}

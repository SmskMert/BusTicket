using BusTicket.Business.Abstract;
using BusTicket.Core;
using BusTicket.Entity;
using BusTicket.Web.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Model.V2.Subscription;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Xml.Linq;
using Options = Iyzipay.Options;

namespace BusTicket.Web.Controllers
{
    public class BusTicketController : Controller
    {
        private readonly ITripService _tripService;
        private readonly ICustomerService _customerService;
        private readonly ITicketService _ticketService;
        private readonly ILineService _lineService;

        public BusTicketController(ITripService ITripService, ICustomerService customerService, ITicketService ticketService, ILineService lineService)
        {
            _tripService = ITripService;
            _customerService = customerService;
            _ticketService = ticketService;
            _lineService = lineService;
        }

        public async Task<IActionResult> TripList(TripSearchModel searchModel)
        {
            if (searchModel != null)
            {
                var lines = await _lineService.GetLinesBySearchAsync(searchModel.Origin, searchModel.Destination);
                if (lines.Count == 0)
                {
                    return View(new List<CombinedTripsModel>());
                }
                else
                {
                    var TripsToBeListed = new List<CombinedTripsModel>();
                    foreach (var line in lines)
                    {
                        var trips = await _tripService.GetTripsBySearchAndLine(searchModel.Origin, searchModel.Destination, searchModel.Date, line.Id);
                        if (trips.Count == 0)
                        {
                            continue;
                        }
                        decimal totalPrice = 0;
                        string combinedTripIds = "";
                        foreach (var trip in trips)
                        {
                            totalPrice += trip.FareAmount;
                        }
                        for (int i = 0; i < trips.Count; i++)
                        {

                            combinedTripIds = i != trips.Count - 1 ? combinedTripIds + trips[i].Id.ToString() + "-" : combinedTripIds + trips[i].Id.ToString();
                        }

                        CombinedTripsModel combinedTripsModel = new()
                        {
                            CombinedTrips = trips,
                            TotalPrice = totalPrice,
                            CombinedTripIds = combinedTripIds
                        };
                        TripsToBeListed.Add(combinedTripsModel);
                    }
                    return View(TripsToBeListed);
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> SeatSelection(string id)
        {
            var ids = id.Split('-');
            List<Trip> trips = new List<Trip>();
            List<Ticket> tickets = new List<Ticket>();
            foreach (var tripId in ids)
            {
                var trip = await _tripService.GetTripWithDetails(int.Parse(tripId));
                tickets.AddRange(trip.Tickets);
                trips.Add(trip);
            }
            decimal totalPrice = 0;
            foreach (var trip in trips)
            {
                totalPrice += trip.FareAmount;
            }
            var seatSelectionModel = new SeatSelectionModel()
            {
                Trips = trips,
                Tickets = tickets,
                TripId = id,
                TotalPrice = totalPrice

            };
            return View(seatSelectionModel);
        }

        [HttpPost]
        public async Task<IActionResult> SeatSelection(SeatSelectionModel seatSelectionModel)
        {
            if (!ModelState.IsValid)
            {
                var ids = seatSelectionModel.TripId.Split('-');
                List<Trip> trips = new List<Trip>();
                List<Ticket> tickets = new List<Ticket>();
                foreach (var tripId in ids)
                {
                    var trip = await _tripService.GetTripWithDetails(int.Parse(tripId));
                    tickets.AddRange(trip.Tickets);
                    trips.Add(trip);
                }
                seatSelectionModel.Tickets = tickets;
                seatSelectionModel.Trips = trips;
                return View(seatSelectionModel);
            }
            return RedirectToAction("PassangerDetails", seatSelectionModel);
        }

        public async Task<IActionResult> PassangerDetails(SavedPassangerInfoModel savedPassangerInfo)
        {
            var passangerDetails = new PassangerDetailsModel()
            {
                TripId = savedPassangerInfo.TripId,
                SelectedSeatNo = savedPassangerInfo.SelectedSeatNo,
                FName = savedPassangerInfo.FName,
                LName = savedPassangerInfo.LName,
                Age = savedPassangerInfo.Age,
                Gender = savedPassangerInfo.Gender,
                Email = savedPassangerInfo.Email,
                Contact = savedPassangerInfo.Contact,
                TotalPrice = savedPassangerInfo.TotalPrice
            };

            if (User.Identity.IsAuthenticated)
            {
                passangerDetails.Customer = await _customerService.GetCustomerByUserNameAsync(User.Identity.Name);
            }
            return View(passangerDetails);
        }

        public async Task<IActionResult> UseSavedPassangerInfo(string tripId, string selectedSeatNo, string totalPrice)
        {
            var customer = await _customerService.GetCustomerByUserNameAsync(User.Identity.Name);
            var savedPassangerInfo = new SavedPassangerInfoModel();
            savedPassangerInfo.FName = customer.FName;
            savedPassangerInfo.LName = customer.LName;
            savedPassangerInfo.Age = customer.Age;
            savedPassangerInfo.Gender = customer.Gender;
            savedPassangerInfo.Email = customer.Email;
            savedPassangerInfo.Contact = customer.Contact;
            savedPassangerInfo.TripId = tripId;
            savedPassangerInfo.TotalPrice = decimal.Parse(totalPrice);
            savedPassangerInfo.SelectedSeatNo = selectedSeatNo;

            return RedirectToAction("PassangerDetails", savedPassangerInfo);
        }

        [HttpPost]
        public async Task<IActionResult> PassangerDetails(PassangerDetailsModel passangerDetails)
        {
            if (!ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    passangerDetails.Customer = await _customerService.GetCustomerByUserNameAsync(User.Identity.Name);
                }
                return View(passangerDetails);
            }


            var customer = new Entity.Customer()
            {
                FName = passangerDetails.FName,
                LName = passangerDetails.LName,
                Gender = passangerDetails.Gender,
                Age = passangerDetails.Age,
                Contact = passangerDetails.Contact,
                Email = passangerDetails.Email
            };

            Entity.Customer savedCustomerDetails = null;
            if (User.IsInRole("Customer"))
            {
                savedCustomerDetails = await _customerService.GetCustomerByUserNameAsync(User.Identity.Name);
            }
            if (passangerDetails.SavePassangerDetails)
            {
                if (savedCustomerDetails == null)
                {
                    customer.UserName = User.IsInRole("Customer") ? User.Identity.Name : null;
                    await _customerService.CreateAsync(customer);
                }
                else
                {
                    customer.Id = savedCustomerDetails.Id;
                    savedCustomerDetails.FName = passangerDetails.FName;
                    savedCustomerDetails.LName = passangerDetails.LName;
                    savedCustomerDetails.Gender = passangerDetails.Gender;
                    savedCustomerDetails.Age = passangerDetails.Age;
                    savedCustomerDetails.Contact = passangerDetails.Contact;
                    savedCustomerDetails.Email = passangerDetails.Email;
                    await _customerService.UpdateAsync(savedCustomerDetails);
                }
            }
            else if (customer.FName == savedCustomerDetails.FName &&
                    customer.LName == savedCustomerDetails.LName &&
                    customer.Gender == savedCustomerDetails.Gender &&
                    customer.Contact == savedCustomerDetails.Contact &&
                    customer.Email == savedCustomerDetails.Email &&
                    customer.Age == savedCustomerDetails.Age)
            {
                customer.Id = savedCustomerDetails.Id;
            }
            else
            {
                await _customerService.CreateAsync(customer);
            }

            #region IyzicoPayment
            var price = passangerDetails.TotalPrice.ToString();
            price = price.Remove(price.Length - 2);

            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = price;
            request.PaidPrice = price;
            request.Currency = Currency.TRY.ToString();
            request.BasketId = "B67832";
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = $"https://localhost:7104/BusTicket/DisplayTicket?customerId={customer.Id.ToString()}&tripId={passangerDetails.TripId}&selectedSeatNo={passangerDetails.SelectedSeatNo}";

            List<int> enabledInstallments = new List<int>();
            enabledInstallments.Add(2);
            enabledInstallments.Add(3);
            enabledInstallments.Add(6);
            enabledInstallments.Add(9);
            request.EnabledInstallments = enabledInstallments;

            Buyer buyer = new Buyer();
            buyer.Id = customer.Id.ToString();
            buyer.Name = customer.FName;
            buyer.Surname = customer.LName;
            buyer.GsmNumber = customer.Contact;
            buyer.Email = customer.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = customer.FName + " " + customer.LName;
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = customer.FName + " " + customer.LName;
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "BusTicket";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = price;
            basketItems.Add(firstBasketItem);
            request.BasketItems = basketItems;
            Options options = new Options()
            {
                ApiKey = "sandbox-VNzU2mkeUTEjWLZTQQbkALcrhwN8RKaB",
                SecretKey = "sandbox-cHPcn21hfcbEkfahHyukl3mEqtjKehpB",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };
            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
            ViewBag.checkoutFormInitialize = checkoutFormInitialize.CheckoutFormContent;
            #endregion

            return View(passangerDetails);
        }


        public async Task<IActionResult> DisplayTicket(string customerId, string tripId, string selectedSeatNo)
        {

            TempData["Message"] = Jobs.CreateMessage("Payment Successful", "The transaction is succesfully completed", "success");

            #region IyzicoCheckoutForm
            //Options options = new Options()
            //{
            //    ApiKey = "sandbox-VNzU2mkeUTEjWLZTQQbkALcrhwN8RKaB",
            //    SecretKey = "sandbox-cHPcn21hfcbEkfahHyukl3mEqtjKehpB",
            //    BaseUrl = "https://sandbox-api.iyzipay.com"
            //};

            //RetrieveCheckoutFormRequest formRequest = new RetrieveCheckoutFormRequest();
            //formRequest.Token = "token";

            //CheckoutForm checkoutForm = CheckoutForm.Retrieve(formRequest, options);
            //ViewBag.checkoutFormRequest = checkoutForm;
            #endregion

            var customer = await _customerService.GetByIdAsync(int.Parse(customerId));
            DisplayTicketModel displayTicket = new();
            if (customer == null) return NotFound();
            else displayTicket.Customer = customer;

            var ids = tripId.Split('-');

            var pnrForTickets = Jobs.PnrNoGenerator();
            List<Ticket> allTickets = await _ticketService.GetAllAsync();
            foreach (var ticket in allTickets)
            {
                pnrForTickets = ticket.PnrNo == pnrForTickets ? Jobs.PnrNoGenerator() : pnrForTickets;
            }

            displayTicket.Tickets = new List<Ticket>();
            foreach (var id in ids)
            {
                var ticket = new Ticket()
                {
                    SeatNo = int.Parse(selectedSeatNo),
                    TripId = int.Parse(id),
                    CustomerId = customer.Id,
                    PnrNo = pnrForTickets
                };
                await _ticketService.CreateAsync(ticket);
                ticket = await _ticketService.GetTicketWithTrip(ticket.Id);
                if (ticket == null) return NotFound();
                displayTicket.Tickets.Add(ticket);
            }


            return View(displayTicket);
        }

        [Authorize]
        public async Task<IActionResult> DisplayUserTickets()
        {
            var userName = User.Identity.Name;
            var usersCustomerId = await _customerService.GetCustomerByUserNameAsync(userName);
            var usersTickets = await _ticketService.GetTicketsByCustomerIdAsync(usersCustomerId.Id);

            var pnrNos = new List<string>();
            usersTickets.ForEach(ticket =>
            {
                if (!pnrNos.Contains(ticket.PnrNo))
                {
                    pnrNos.Add(ticket.PnrNo);
                }
            });

            var combinedTicketModels = new List<CombinedTicketModel>();
            foreach (var pnr in pnrNos)
            {
                CombinedTicketModel combinedTicketModel = new();
                foreach (var usersTicket in usersTickets)
                {
                    if (usersTicket.PnrNo == pnr)
                    {
                        combinedTicketModel.Tickets.Add(usersTicket);
                    }
                }
                combinedTicketModels.Add(combinedTicketModel);
            }

            return View(combinedTicketModels);
        }
        public async Task<IActionResult> TicketDetails(string pnr)
        {
            var combinedTickets = await _ticketService.GetTicketsByPnrAsync(pnr);
            DisplayTicketModel displayTicket = new()
            {
                Tickets = combinedTickets,
                Customer = combinedTickets.First().Customer
            };
            return View("DisplayTicket", displayTicket);
        }
    }

}

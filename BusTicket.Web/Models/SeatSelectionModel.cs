using BusTicket.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusTicket.Web.Models
{
    public class SeatSelectionModel
    {
        public List<Trip>? Trips { get; set; } = null!;

        public string? TripId { get; set; }
        public List<Ticket>? Tickets { get; set; } = null!;

        [Required(ErrorMessage = "Please Select a seat!")]
        public string? SelectedSeatNo { get; set; }
        public decimal TotalPrice { get; set; }

    }
}

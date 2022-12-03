using BusTicket.Entity;

namespace BusTicket.Web.Models
{
    public class DisplayTicketModel
    {
        public Customer? Customer { get; set; }
        public List<Ticket>? Tickets { get; set; } = null!;
        public int CustomerId { get; set; }
        public string? TripId { get; set; }
        public string? SelectedSeatNo { get; set; }
    }
}

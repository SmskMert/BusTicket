using BusTicket.Entity;

namespace BusTicket.Web.Models
{
    public class DisplayTicketModel
    {
        public Customer? Customer { get; set; }
        public Ticket? Ticket { get; set; }
        public int CustomerId { get; set; }
        public string? TripId { get; set; }
        public string? SelectedSeatNo { get; set; }
    }
}

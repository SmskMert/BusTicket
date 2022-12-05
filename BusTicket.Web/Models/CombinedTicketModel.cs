using BusTicket.Entity;

namespace BusTicket.Web.Models
{
    public class CombinedTicketModel
    {
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}

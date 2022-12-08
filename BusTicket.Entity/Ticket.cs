using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Entity
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SeatNo { get; set; }
        public bool IsBooked { get; set; }
        public string? PnrNo { get; set; }
        public int TripId { get; set; } //FK
        public Trip? Trip { get; set; } //NavProp

        public int CustomerId { get; set; } //FK
        public Customer? Customer { get; set; } //NavProp

        public string? UserName { get; set; }

    }
}

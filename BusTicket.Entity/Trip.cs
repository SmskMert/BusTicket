using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Entity
{
    public class Trip
    {
        public int Id { get; set; }

        public int MidLineId { get; set; }
        public MidLine MidLine { get; set; } = null!;

        public int TripDetailId { get; set; }
        public TripDetail TripDetail { get; set; } = null!;

        public List<Ticket> Tickets { get; set; } = null!; //NavProp

        //public DateOnly ScheduleDate { get; set; }
        public string? ScheduleDate { get; set; }

        //public TimeOnly DepartureTime { get; set; }
        public string? DepartureTime { get; set; }

        //public TimeOnly ArrivalTime { get; set; }
        public string? ArrivalTime { get; set; }

        public string? Remarks { get; set; }

        public decimal FareAmount { get; set; }

    }
}

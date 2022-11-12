using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Entity
{
    public class MidLine
    {
        public int Id { get; set; }
        public string? StartingPoint { get; set; }
        public string? Destination { get; set; }
        public int LineId { get; set; }
        public int MidLineOrder { get; set; }
        public Line? Line { get; set; }
        public List<Trip> Trips { get; set; } = null!;
    }
}

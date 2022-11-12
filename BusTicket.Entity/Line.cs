using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Entity
{
    public class Line
    {
        public int Id { get; set; }
        public string? StartingPoint { get; set; }
        public string? Destination { get; set; }
        public List<MidLine> MidLines { get; set; } = null!;
    }
}

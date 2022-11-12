using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Entity
{
    public class Driver
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }

        public List<TripDetail> TripDetails { get; set; } = null!; //NavProp

    }
}

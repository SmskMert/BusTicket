using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Entity
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //public List<Bus> Buses { get; set; } = null!;

        public List<TripDetail> TripDetails { get; set; } = null!;
    }
}

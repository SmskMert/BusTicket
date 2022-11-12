using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Entity
{
    public class TripDetail
    {
        public int Id { get; set; }

        public int BusId { get; set; } //FK
        public Bus? Bus { get; set; } //NavProp

        public int DriverId { get; set; } //FK
        public Driver Driver { get; set; } = null!; //NavProp

        public int? CompanyId { get; set; } //FK
        public Company Company { get; set; } = null!; //NavProp

        public List<Trip> Trips { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Entity
{
    public class Bus
    {
        public int Id { get; set; }
        public int Capacity { get; set; }

        public List<TripDetail> TripDetails { get; set; } = null!;  //NavProp

        //public int? CompanyId { get; set; } //FK
        //public Company Company { get; set; } = null!; //NavProp

        public bool HasWifi { get; set; }
        public bool HasUSB { get; set; }
        public bool HasSeatScreen { get; set; }
    }
}

using BusTicket.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusTicket.Web.Models
{
    public class BusModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="Capacity must be provided!")]
        public int? Capacity { get; set; }

        //public List<TripDetail>? TripDetails { get; set; } = null!;

        //public int? CompanyId { get; set; } 
        //public Company Company { get; set; } = null!; 
        public bool HasWifi { get; set; }
        public bool HasUSB { get; set; }
        public bool HasSeatScreen { get; set; }
    }
}

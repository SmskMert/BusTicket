using BusTicket.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusTicket.Web.Models
{
    public class UpdateLineModel
    {
        public List<string> Stops { get; set; } = null!;
        public List<string> Time { get; set; } = null!;
        public List<string> Fares { get; set; } = null!;
        public List<StopTimeFareModel>? StopTimeFares { get; set; } = null!;
        [Required(ErrorMessage ="BusId Must be selected")]
        public int? BusId { get; set; }
        [Required(ErrorMessage = "Driver Must be selected")]
        public int? DriverId { get; set; }

        [Required(ErrorMessage = "Date Must be selected")]
        public string Date { get; set; }
        public List<Bus>? Buses { get; set; }
        public List<Driver>? Drivers { get; set; }
    }
}
